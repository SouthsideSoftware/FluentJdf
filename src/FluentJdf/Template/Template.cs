//using System;
//using System.IO;
//using System.Collections.Specialized;
//using System.Text;
//using System.Data;
//using System.Diagnostics;
//using FluentJdf.Resources;
//using Infrastructure.Core.Logging;

//namespace FluentJdf.Template
//{
//    /// <summary>
//    /// This class represents a JDF file containing replacement variables that
//    ///  will be filled with values to generate a new JdfTree.
//    /// </summary>
//    public class Template {
//        static readonly ILog logger = LogManager.GetLogger(typeof (Template));
//        private enum States {Text, Var, Val, TableName, TableTag, Comment};

//        private string _name;
//        private TemplateItemCollection _items;

//        private static string _cacheKeyPrefix = "Tp_";

//        /// <summary>
//        /// Construct an XML template from a file.
//        /// </summary>
//        /// <param name="fileName">The file to use.</param>
//        protected internal Template(string fileName)
//        {
//            _name = fileName;
//            Load();
//        }

//        /// <summary>
//        /// Gets the template items collection of this template.
//        /// </summary>
//        public TemplateItemCollection TemplateItems
//        {
//            get
//            {
//                return _items;
//            }
//        }

//        /// <summary>
//        /// Gets the name of the template.
//        /// </summary>
//        public string Name
//        {
//            get
//            {
//                return _name;
//            }
//        }

//        private void Load()
//        {
//            TemplateItem parent = null;

//            _items = new TemplateItemCollection();
//            StreamReader reader = null;

//            try
//            {
//                reader = new StreamReader(_name);
//            } 
//            catch (Exception err) {
//                string mess = string.Format(Messages.CouldNotOpen, _name);
//                logger.Error(mess, err);
//                throw new TemplateApiException(mess, err);
//            }

//            StringBuilder staticText = new StringBuilder(100);

//            int lineNumber = 1;
//            int positionInLine = -1;

//            try 
//            {
//                States currentState = States.Text;
					
//                StringBuilder varName = new StringBuilder(50);
//                StringBuilder defaultValue = new StringBuilder(50);
//                StringBuilder tableName = new StringBuilder(50);
//                StringBuilder tableTag = new StringBuilder(50);
//                char c = ' ';

//                while (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                {
//                    switch (currentState)
//                    {
//                        case States.Text:
//                        switch (c)
//                        {
//                            case '[':
//                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                {
//                                    if (c == ':')
//                                    {
//                                        currentState = States.Var;
//                                        if (staticText.Length > 0)
//                                        {
//                                            StaticTemplateItem item = new StaticTemplateItem(parent, "static", lineNumber, positionInLine, staticText.ToString());
//                                            if (parent == null)
//                                            {
//                                                _items.Add(item);
//                                            }
//                                        }
//                                        staticText.Remove(0, staticText.Length);
//                                        varName.Remove(0, varName.Length);
//                                        defaultValue.Remove(0, defaultValue.Length);
//                                        tableName.Remove(0, tableName.Length);
//                                        tableTag.Remove(0, tableName.Length);
//                                    } 
//                                    else if (c == '%')
//                                    {
//                                        currentState = States.TableTag;
//                                        if (staticText.Length > 0)
//                                        {
//                                            StaticTemplateItem item = new StaticTemplateItem(parent, "static", lineNumber, positionInLine, staticText.ToString());
//                                            if (parent == null)
//                                            {
//                                                _items.Add(item);
//                                            }
//                                        }
//                                        staticText.Remove(0, staticText.Length);
//                                        varName.Remove(0, varName.Length);
//                                        defaultValue.Remove(0, defaultValue.Length);
//                                        tableName.Remove(0, tableName.Length);
//                                        tableTag.Remove(0, tableTag.Length);
//                                    }
//                                    else 
//                                    {
//                                        staticText.Append("[");
//                                    }
//                                }
//                                break;
//                            case '<':
//                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                {
//                                    if (c == '!')
//                                    {
//                                        if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                        {
//                                            if (c == '-')
//                                            {
//                                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                                {
//                                                    if (c == '-')
//                                                    {
//                                                        currentState = States.Comment;
//                                                    } 
//                                                    else 
//                                                    {
//                                                        staticText.Append("<!-");
//                                                    }
//                                                } 
//                                                else 
//                                                {
//                                                    staticText.Append("<!-");
//                                                }
//                                            } 
//                                            else 
//                                            {
//                                                staticText.Append("<!");
//                                            }
//                                        } 
//                                        else 
//                                        {
//                                            staticText.Append("<!");
//                                        }
//                                    } 
//                                    else 
//                                    {
//                                        staticText.Append("<");
//                                    }
//                                } 
//                                else 
//                                {
//                                    staticText.Append("<");
//                                }
//                                break;
//                            }
//                            if (currentState == States.Text)
//                            {
//                                staticText.Append(c);
//                            }
//                            break;
//                        case States.Comment:
//                            if (c == '-')
//                            {
//                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                {
//                                    if (c == '-')
//                                    {
//                                        if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                        {
//                                            if (c == '>')
//                                            {
//                                                currentState = States.Text;
//                                            } 
//                                        } 
//                                        else 
//                                        {
//                                            OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF.  An XML comment must end with '-->'."));
//                                        }
//                                    }
//                                } 
//                                else 
//                                {
//                                    OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF.  An XML comment must end with '-->'."));
//                                }
//                            }
//                            break;
//                        case States.TableTag:
//                            //if the character is non-blank or one non-blank was encountered in this tag
//                            if (c == '%')
//                            {
//                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                {
//                                    if (c != ']')
//                                    {
//                                        OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "']' expected"));
//                                    }
//                                } 
//                                else 
//                                {
//                                    OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF"));
//                                }
//                                if (tableTag.ToString() == "end table")
//                                {
//                                    if (parent == null)
//                                    {
//                                        OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "[%end table%] without corresponding [%table(<tablename>)%]"));
//                                    }
//                                    //tables can be nested, this "pops" the stack of parents
//                                    parent = parent.Parent;
//                                    currentState = States.Text;
//                                    break;
//                                } 
//                                else if (tableTag.ToString() == "table")
//                                {
//                                    OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "table requires table name parameter"));
//                                } 
//                                else 
//                                {
//                                    OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "unknown [% tag " + tableTag.ToString()));
//                                }

//                            } 
//                            else if (c == '(')
//                            {
//                                if (tableTag.ToString() == "table")
//                                {
//                                    currentState = States.TableName;
//                                    break;
//                                } 
//                                else 
//                                {
//                                    OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "'(' not expected"));
//                                }
//                            }
//                            tableTag.Append(c);
//                            break;
//                        case States.TableName:
//                            if (c == ')')
//                            {
//                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                {
//                                    if (c != '%')
//                                    {
//                                        OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "'%' expected"));
//                                    } 
//                                    else 
//                                    {
//                                        if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                        {
//                                            if (c != ']')
//                                            {
//                                                OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "']' expected"));
//                                            }
//                                        } 
//                                        else 
//                                        {
//                                            OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF"));
//                                        }
//                                        if (tableName.Length > 0)
//                                        {
//                                            string tName = tableName.ToString();
//                                            TemplateItem newParent = new TableTemplateItem(parent, tName, lineNumber, positionInLine, tName);
//                                            if (parent == null)
//                                            {
//                                                _items.Add(newParent);
//                                            }
//                                            parent = newParent;
//                                            currentState = States.Text;
//                                        } 
//                                        else 
//                                        {
//                                            OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "[%table(<table name>%} must have table name specified."));
//                                        }
//                                    }
//                                } 
//                                else 
//                                {
//                                    OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF"));
//                                }
//                            }
//                            tableName.Append(c);
//                            break;
//                        case States.Var:
//                            switch (c)
//                            {
//                                case ':':
//                                    if (varName.Length == 0)
//                                    {
//                                        OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Variable name is zero length"));
//                                    }
//                                    if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                    {
//                                        if (c != ']')
//                                        {
//                                            OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "']' expected"));
//                                        }
//                                    } 
//                                    else 
//                                    {
//                                        OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF"));
//                                    }
//                                    VariableTemplateItem item = new VariableTemplateItem(parent, varName.ToString(), lineNumber, positionInLine, null);
//                                    if (parent == null)
//                                    {
//                                        _items.Add(item);
//                                    }
//                                    currentState = States.Text;
//                                    break;
//                                case '=':
//                                    if (varName.Length == 0)
//                                    {
//                                        OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Variable name is zero length"));
//                                    }
//                                    currentState = States.Val;
//                                    break;
//                                default:
//                                    varName.Append(c);
//                                    break;
//                            }
//                            break;
//                        case States.Val:
//                        switch (c)
//                        {
//                            case ':':
//                                if (defaultValue.Length == 0)
//                                {
//                                    OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Default value is zero length"));
//                                }
//                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
//                                {
//                                    if (c != ']')
//                                    {
//                                        OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "']' expected"));
//                                    }
//                                } 
//                                else 
//                                {
//                                    OAIException.Throw(new TemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF"));
//                                }
//                                string def = defaultValue.ToString().Trim();
//                                if (def.EndsWith("()"))
//                                {
//                                    FormulaTemplateItem item = FormulaTemplateItemFactory.CreateFormulaItem(parent, varName.ToString(), lineNumber, positionInLine, def);
//                                    if (parent == null)
//                                    {
//                                        _items.Add(item);
//                                    }
//                                } 
//                                else 
//                                {
//                                    VariableTemplateItem item = new VariableTemplateItem(parent, varName.ToString(), lineNumber, positionInLine, def);
//                                    if (parent == null)
//                                    {
//                                        _items.Add(item);
//                                    }
//                                }
//                                currentState = States.Text;
//                                break;
//                            default:
//                                defaultValue.Append(c);
//                                break;
//                        }
//                            break;
//                    }
//                }			
//            }
//            finally 
//            {
//                reader.Close();
//                if (staticText.Length > 0)
//                {
//                    TemplateItem item = new StaticTemplateItem(parent, "static", lineNumber, positionInLine, staticText.ToString());
//                    if (parent == null)
//                    {
//                        _items.Add(item);
//                    }
//                }

//                if (parent != null)
//                {
//                    OAIException.Throw(new TemplateApiException("One or more [%table tags is not closed with an [%end table"));
//                }
//            }
//        }

//        /// <summary>
//        /// Generate a tree for this template.
//        /// </summary>
//        /// <param name="vars">StringDictionary containing the name/value pairs for simple fields.</param>
//        /// <param name="dataSet">A DataSet containing one table for each table replacement field in the template.</param>
//        /// <param name="priority">A SchemaPriority setting to control schema validation.</param>
//        /// <param name="fixupIds">True to fixup ids in the file automatically.  If false, IDs will be left as is.</param>
//        /// <param name="jobId">The new JobID value.</param>
//        /// <returns>The tree containing the generated JDF.</returns>
//        protected internal JdfTree Generate(StringDictionary vars, DataSet dataSet, SchemaPriority priority, bool fixupIds, string jobId)
//        {
//            JdfTree tree = null;

//            MemoryStream buffStream = new MemoryStream();
//            StreamWriter writer = new StreamWriter(buffStream);
//            try
//            {
//                _items.Generate(writer, vars, dataSet);

//                writer.Flush();

//                buffStream.Seek(0, SeekOrigin.Begin);

//                if (Config.LogTreeParse)
//                {
//                    OAIException.LogMessage("*** DUMP DATA GENERATED FROM TEMPLATE BEFORE PARSE ***");
//                    StreamReader reader = new StreamReader(StreamHelper.CopyToMemoryStream(buffStream, false));
//                    try
//                    {
//                        OAIException.LogMessage(reader.ReadToEnd());
//                    } 
//                    finally 
//                    {
//                        reader.Close();
//                    }

//                }

//                if (fixupIds)
//                {
//                    tree = GenerateNewIds(buffStream, jobId, priority);
//                } 
//                else 
//                {
//                    tree = new JdfTree(buffStream, priority);
//                }
//            } 
//            finally 
//            {
//                writer.Close();
//                buffStream.Close();
//            }

//            if (tree.TypeOfTree == TreeType.Jdf)
//            {
//                //the instance document is not a template so set Template to false in the root
//                tree.Root.SetAttributeValue("Template", "false");
//            }
			
//            return tree;
//        }

//        private bool ReadNext(StreamReader reader, StringBuilder staticText, ref int lineNumber, ref int positionInLine, ref char charRead)
//        {
//            int r = 0;
//            while ((r = reader.Read()) != -1)
//            {
//                charRead = (char)r;
//                positionInLine++;
//                if (charRead == '\n')
//                {
//                    staticText.Append(charRead);
//                    positionInLine = 0;
//                    lineNumber++;
//                } 
//                else if (charRead == '\r')
//                {
//                    staticText.Append(charRead);
//                    positionInLine++;
//                }
//                else 
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        private JdfTree GenerateNewIds(MemoryStream stream, string jobId, SchemaPriority priority)
//        {
//            JdfTree tree = new JdfTree(stream, priority);
//            tree.Root.RecursiveAssignUniqueId(true);

//            if (tree.Root is JdfElement)
//            {
//                tree.Root.SetAttributeValue("JobID", jobId);
//            }
		
//            return tree;
//        }

//        /// <summary>
//        /// Returns a string representation of this template.
//        /// </summary>
//        /// <returns>A string representation of this template.</returns>
//        public override string ToString()
//        {
//            return "Template " + _name;
//        }

//        /// <summary>
//        /// Dump the current template and all its field information to the
//        /// current trace listeners.
//        /// </summary>
//        public void Dump()
//        {
//            Trace.WriteLine(ToString());
//            Trace.Indent();
//            _items.Dump();
//            Trace.Unindent();
//        }
//    }
//}

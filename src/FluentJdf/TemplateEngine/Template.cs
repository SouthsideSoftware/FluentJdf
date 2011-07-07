using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Xml.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Logging;

namespace FluentJdf.TemplateEngine
{
    /// <summary>
    /// This class represents a JDF file containing replacement variables that
    ///  will be filled with values to generate a new JdfTree.
    /// </summary>
    public class Template
    {
        static readonly ILog logger = LogManager.GetLogger(typeof(Template));
        private enum States { Text, Var, Val, TableName, TableTag, Comment };

        private readonly string name;
        private TemplateItemCollection items;


        /// <summary>
        /// Construct an XML template from a file.
        /// </summary>
        /// <param name="fileName">The file to use.</param>
        public Template(string fileName)
        {
            ParameterCheck.StringRequiredAndNotWhitespace(fileName, "fileName");
            if (!File.Exists(fileName)) {
                throw new ArgumentException("File does not exist");
            }
            if (!Path.IsPathRooted(fileName)) {
                fileName = Path.Combine(ApplicationInformation.Directory, fileName);
            }
            name = fileName;
            Load(File.OpenRead(fileName));
        }

        /// <summary>
        /// Construct a JDF template from a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="name"></param>
        public Template(Stream stream, string name) {
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");
            ParameterCheck.ParameterRequired(stream, "stream");

            this.name = name;
            Load(stream);
        }

        /// <summary>
        /// Gets the template items collection of this template.
        /// </summary>
        public TemplateItemCollection TemplateItems
        {
            get
            {
                return items;
            }
        }

        /// <summary>
        /// Gets the name of the template.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        private void Load(Stream stream)
        {
            TemplateItem parent = null;

            items = new TemplateItemCollection();
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(stream);
            }
            catch (Exception err)
            {
                string mess = string.Format(Messages.CouldNotOpen, name);
                logger.Error(mess, err);
                throw new TemplateApiException(mess, err);
            }

            StringBuilder staticText = new StringBuilder(100);

            int lineNumber = 1;
            int positionInLine = -1;

            try
            {
                States currentState = States.Text;

                StringBuilder varName = new StringBuilder(50);
                StringBuilder defaultValue = new StringBuilder(50);
                StringBuilder tableName = new StringBuilder(50);
                StringBuilder tableTag = new StringBuilder(50);
                char c = ' ';

                while (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                {
                    switch (currentState)
                    {
                        case States.Text:
                            switch (c)
                            {
                                case '[':
                                    if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                    {
                                        if (c == ':')
                                        {
                                            currentState = States.Var;
                                            if (staticText.Length > 0)
                                            {
                                                StaticTemplateItem item = new StaticTemplateItem(parent, "static", lineNumber, positionInLine, staticText.ToString());
                                                if (parent == null)
                                                {
                                                    items.Add(item);
                                                }
                                            }
                                            staticText.Remove(0, staticText.Length);
                                            varName.Remove(0, varName.Length);
                                            defaultValue.Remove(0, defaultValue.Length);
                                            tableName.Remove(0, tableName.Length);
                                            tableTag.Remove(0, tableName.Length);
                                        }
                                        else if (c == '%')
                                        {
                                            currentState = States.TableTag;
                                            if (staticText.Length > 0)
                                            {
                                                StaticTemplateItem item = new StaticTemplateItem(parent, "static", lineNumber, positionInLine, staticText.ToString());
                                                if (parent == null)
                                                {
                                                    items.Add(item);
                                                }
                                            }
                                            staticText.Remove(0, staticText.Length);
                                            varName.Remove(0, varName.Length);
                                            defaultValue.Remove(0, defaultValue.Length);
                                            tableName.Remove(0, tableName.Length);
                                            tableTag.Remove(0, tableTag.Length);
                                        }
                                        else
                                        {
                                            staticText.Append("[");
                                        }
                                    }
                                    break;
                                case '<':
                                    if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                    {
                                        if (c == '!')
                                        {
                                            if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                            {
                                                if (c == '-')
                                                {
                                                    if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                                    {
                                                        if (c == '-')
                                                        {
                                                            currentState = States.Comment;
                                                        }
                                                        else
                                                        {
                                                            staticText.Append("<!-");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        staticText.Append("<!-");
                                                    }
                                                }
                                                else
                                                {
                                                    staticText.Append("<!");
                                                }
                                            }
                                            else
                                            {
                                                staticText.Append("<!");
                                            }
                                        }
                                        else
                                        {
                                            staticText.Append("<");
                                        }
                                    }
                                    else
                                    {
                                        staticText.Append("<");
                                    }
                                    break;
                            }
                            if (currentState == States.Text)
                            {
                                staticText.Append(c);
                            }
                            break;
                        case States.Comment:
                            if (c == '-')
                            {
                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                {
                                    if (c == '-')
                                    {
                                        if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                        {
                                            if (c == '>')
                                            {
                                                currentState = States.Text;
                                            }
                                        }
                                        else
                                        {
                                            LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF.  An XML comment must end with '-->'.");
                                        }
                                    }
                                }
                                else
                                {
                                    LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF.  An XML comment must end with '-->'.");
                                }
                            }
                            break;
                        case States.TableTag:
                            //if the character is non-blank or one non-blank was encountered in this tag
                            if (c == '%')
                            {
                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                {
                                    if (c != ']')
                                    {
                                        LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "']' expected");
                                    }
                                }
                                else
                                {
                                    LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF");
                                }
                                if (tableTag.ToString() == "end table")
                                {
                                    if (parent == null)
                                    {
                                        LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "[%end table%] without corresponding [%table(<tablename>)%]");
                                    }
                                    //tables can be nested, this "pops" the stack of parents
                                    parent = parent.Parent;
                                    currentState = States.Text;
                                    break;
                                }
                                else if (tableTag.ToString() == "table")
                                {
                                    LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "table requires table name parameter");
                                }
                                else
                                {
                                    LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "unknown [% tag " + tableTag.ToString());
                                }

                            }
                            else if (c == '(')
                            {
                                if (tableTag.ToString() == "table")
                                {
                                    currentState = States.TableName;
                                    break;
                                }
                                else
                                {
                                    LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "'(' not expected");
                                }
                            }
                            tableTag.Append(c);
                            break;
                        case States.TableName:
                            if (c == ')')
                            {
                                if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                {
                                    if (c != '%')
                                    {
                                        LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "'%' expected");
                                    }
                                    else
                                    {
                                        if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                        {
                                            if (c != ']')
                                            {
                                                LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "']' expected");
                                            }
                                        }
                                        else
                                        {
                                            LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF");
                                        }
                                        if (tableName.Length > 0)
                                        {
                                            string tName = tableName.ToString();
                                            TemplateItem newParent = new TableTemplateItem(parent, tName, lineNumber, positionInLine, tName);
                                            if (parent == null)
                                            {
                                                items.Add(newParent);
                                            }
                                            parent = newParent;
                                            currentState = States.Text;
                                        }
                                        else
                                        {
                                            LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "[%table(<table name>%} must have table name specified.");
                                        }
                                    }
                                }
                                else
                                {
                                    LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF");
                                }
                            }
                            tableName.Append(c);
                            break;
                        case States.Var:
                            switch (c)
                            {
                                case ':':
                                    if (varName.Length == 0)
                                    {
                                        LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Variable name is zero length");
                                    }
                                    if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                    {
                                        if (c != ']')
                                        {
                                            LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "']' expected");
                                        }
                                    }
                                    else
                                    {
                                        LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF");
                                    }
                                    VariableTemplateItem item = new VariableTemplateItem(parent, varName.ToString(), lineNumber, positionInLine, null);
                                    if (parent == null)
                                    {
                                        items.Add(item);
                                    }
                                    currentState = States.Text;
                                    break;
                                case '=':
                                    if (varName.Length == 0)
                                    {
                                        LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Variable name is zero length");
                                    }
                                    currentState = States.Val;
                                    break;
                                default:
                                    varName.Append(c);
                                    break;
                            }
                            break;
                        case States.Val:
                            switch (c)
                            {
                                case ':':
                                    if (defaultValue.Length == 0)
                                    {
                                        LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Default value is zero length");
                                    }
                                    if (ReadNext(reader, staticText, ref lineNumber, ref positionInLine, ref c))
                                    {
                                        if (c != ']')
                                        {
                                            LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "']' expected");
                                        }
                                    }
                                    else
                                    {
                                        LogAndThrowTemplateExpansionException(lineNumber, positionInLine, "Unexpected EOF");
                                    }
                                    string def = defaultValue.ToString().Trim();
                                    if (def.EndsWith("()"))
                                    {
                                        FormulaTemplateItem item = FormulaTemplateItemFactory.CreateFormulaItem(parent, varName.ToString(), lineNumber, positionInLine, def);
                                        if (parent == null)
                                        {
                                            items.Add(item);
                                        }
                                    }
                                    else
                                    {
                                        VariableTemplateItem item = new VariableTemplateItem(parent, varName.ToString(), lineNumber, positionInLine, def);
                                        if (parent == null)
                                        {
                                            items.Add(item);
                                        }
                                    }
                                    currentState = States.Text;
                                    break;
                                default:
                                    defaultValue.Append(c);
                                    break;
                            }
                            break;
                    }
                }
            }
            finally
            {
                reader.Close();
                if (staticText.Length > 0)
                {
                    TemplateItem item = new StaticTemplateItem(parent, "static", lineNumber, positionInLine, staticText.ToString());
                    if (parent == null)
                    {
                        items.Add(item);
                    }
                }

                if (parent != null)
                {
                    LogAndThrowTemplateApiException("One or more [%table tags is not closed with an [%end table");
                }
            }
        }

        /// <summary>
        /// Generate a tree for this template.
        /// </summary>
        /// <param name="vars">Name/value pairs.</param>
        /// <param name="makeIdsUnique">True to make ids in the file globally unique.  If false, IDs will be taken from the template.</param>
        /// <param name="jobId">The new JobID value.</param>
        /// <returns>The tree containing the generated JDF.</returns>
        public XDocument Generate(Dictionary<string, object> vars, string jobId = null, bool makeIdsUnique = true) {
            ParameterCheck.ParameterRequired(vars, "vars");

            XDocument tree = null;

            var buffStream = new TempFileStream();
            StreamWriter writer = new StreamWriter(buffStream);
            try
            {
                items.Generate(writer, vars);

                writer.Flush();

                buffStream.Seek(0, SeekOrigin.Begin);

                if (makeIdsUnique)
                {
                    tree = GenerateNewIds(buffStream, jobId);
                }
                else
                {
                    tree = XDocument.Load(buffStream);
                }
            }
            finally
            {
                writer.Close();
                buffStream.Close();
            }

            if (tree.XmlType() == XmlType.Jdf)
            {
                //the instance document is not a template so set Template to false in the root
                tree.Root.SetAttributeValue("Template", "false");
            }

            RemoveNullValueAttributes(tree);

            return tree;
        }

        void RemoveNullValueAttributes(XDocument tree) {
            var attributesToNull = new List<XName>();
            foreach (var element in tree.Descendants()) {
                attributesToNull.Clear();
                foreach (var attribute in element.Attributes()) {
                    if (attribute.Value == JdfDefaultFormulaTemplateItem.NullValuePlaceholder) {
                        attributesToNull.Add(attribute.Name);
                    }
                }
                foreach (var attributeName in attributesToNull) {
                    element.SetAttributeValue(attributeName, null);
                }
            }
        }

        private bool ReadNext(StreamReader reader, StringBuilder staticText, ref int lineNumber, ref int positionInLine, ref char charRead)
        {
            int r = 0;
            while ((r = reader.Read()) != -1)
            {
                charRead = (char)r;
                positionInLine++;
                if (charRead == '\n')
                {
                    staticText.Append(charRead);
                    positionInLine = 0;
                    lineNumber++;
                }
                else if (charRead == '\r')
                {
                    staticText.Append(charRead);
                    positionInLine++;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        private XDocument GenerateNewIds(Stream stream, string jobId) {
            var tree = XDocument.Load(stream);
            tree.Root.RecursiveSetUniqueId("TI_");

            if (tree.Root.IsJdfElement())
            {
                tree.Root.SetJobId(jobId);
            }

            return tree;
        }

        /// <summary>
        /// Returns a string representation of this template.
        /// </summary>
        /// <returns>A string representation of this template.</returns>
        public override string ToString()
        {
            return "Template " + name;
        }

        void LogAndThrowTemplateExpansionException(int lineNumber, int positionInLine, string message) {
            logger.ErrorFormat(Messages.ErrorAtLineAndColumn, message, lineNumber, positionInLine);
            throw new TemplateExpansionException(lineNumber, positionInLine, message);
        }

        void LogAndThrowTemplateApiException(string message)
        {
            logger.ErrorFormat(message);
            throw new TemplateApiException(message);
        }
    }


}

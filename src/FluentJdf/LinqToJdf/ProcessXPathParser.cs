using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {

    /// <summary>
    /// Class designed to provide parsing functions for the <see cref="XPathExtensions.ProcessXPathSelectElements"/> method
    /// </summary>
    public class ProcessXPathParser {

        /// <summary>
        /// process: costant.
        /// </summary>
        public const string PROCESS = "process:";

        /// <summary>
        /// The Full expression that was parsed.
        /// </summary>
        public string FullExpression {
            get;
            private set;
        }

        /// <summary>
        /// The Name of the Process
        /// </summary>
        public string ProcessName {
            get;
            private set;
        }

        /// <summary>
        /// Resource Name
        /// </summary>
        public string ResourceName {
            get;
            private set;
        }

        /// <summary>
        /// The <see cref="ResourceUsage"/>
        /// </summary>
        public ResourceUsage ResourceUsage {
            get;
            private set;
        }

        /// <summary>
        /// The Remaining XPath statement that will be used once we find the Process.
        /// </summary>
        public string XPathStatement {
            get;
            private set;
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="expression">The expression to parse</param>
        public ProcessXPathParser(string expression) {
            ParameterCheck.StringRequiredAndNotWhitespace(expression, "expression");
            this.FullExpression = expression;
            this.ResourceUsage = ResourceUsage.Input;
            ParseExpression();
        }

        /// <summary>
        /// Parse the Statement 
        /// <para>Syntax is process:[process]/[resource[@usage=input|output (defaults to input)]/[remaining xpath]</para>
        /// </summary>
        /// <param name="expression">The expression to parse</param>
        /// <returns></returns>
        public static ProcessXPathParser Parse(string expression) {
            return new ProcessXPathParser(expression);
        }

        /// <summary>
        /// Parse the expression.
        /// <para>//process:DigitalPrinting/DigitalPrintingParams[@usage=input]/rest of the xpath executed against JdfXPathSelectElement(s)</para>
        /// </summary>
        private void ParseExpression() {
            if (!FullExpression.StartsWith(PROCESS)) {
                XPathStatement = FullExpression;
            }
            else {
                var tempExpression = FullExpression.Substring(PROCESS.Length);
                var findIndex = tempExpression.IndexOf('/');
                if (findIndex == -1) {
                    throw new ApplicationException(string.Format("Invalid Expression at Process {0}", FullExpression));
                }
                ProcessName = tempExpression.Substring(0, findIndex);

                //TODO determine if we validate it against the ProcessType Valid list.

                tempExpression = tempExpression.Substring(findIndex + 1);
                findIndex = tempExpression.IndexOf('/');
                if (findIndex == -1) {
                    ResourceName = tempExpression;
                    return;
                }
                XPathStatement = tempExpression.Substring(findIndex + 1);
                tempExpression = tempExpression.Substring(0, findIndex);
                findIndex = tempExpression.IndexOf('[');
                if (findIndex == -1) {
                    ResourceName = tempExpression;
                }
                else {
                    ResourceName = tempExpression.Substring(0, findIndex);
                    tempExpression = tempExpression.Substring(findIndex + 1);
                    tempExpression = tempExpression.Substring(0, tempExpression.Length - 1);
                    var parts = tempExpression.Split('=');
                    if (parts.Length < 2) {
                        throw new ApplicationException(string.Format("Invalid Expression at Usage {0}", FullExpression));
                    }
                    ResourceUsage usage = LinqToJdf.ResourceUsage.Unknown;
                    if (Enum.TryParse<ResourceUsage>(parts[1], true, out usage)) {
                        ResourceUsage = usage;
                    }
                }
            }
        }
    }
}

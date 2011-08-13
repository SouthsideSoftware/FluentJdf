using System;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;

namespace FluentJdf.TemplateEngine {
    /// <summary>
    /// A custom template formula that may take parameters
    /// </summary>
    public class CustomFormula {
        static ILog logger = LogManager.GetLogger(typeof(CustomFormula));
        readonly Delegate customFunction;
        readonly string name;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="func"></param>
        public CustomFormula(string name, Delegate func) {
            ParameterCheck.ParameterRequired(func, "func");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            this.name = name;
            customFunction = func;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public CustomFormula(string name, Func<string> func) {
            ParameterCheck.ParameterRequired(func, "func");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            customFunction = func;
            this.name = name;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomFormula(string name, Func<string, string> func) {
            ParameterCheck.ParameterRequired(func, "func");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            customFunction = func;
            this.name = name;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomFormula(string name, Func<string, string, string> func) {
            ParameterCheck.ParameterRequired(func, "func");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            customFunction = func;
            this.name = name;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomFormula(string name, Func<string, string, string, string> func) {
            ParameterCheck.ParameterRequired(func, "func");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            customFunction = func;
            this.name = name;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomFormula(string name, Func<string, string, string, string, string> func) {
            ParameterCheck.ParameterRequired(func, "func");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            customFunction = func;
            this.name = name;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomFormula(string name, Func<string, string, string, string, string, string> func) {
            ParameterCheck.ParameterRequired(func, "func");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            customFunction = func;
            this.name = name;
        }

        /// <summary>
        /// Execute the custom formula
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public string Execute(params object[] parms) {
            try {
                return (string) customFunction.DynamicInvoke(parms);
            } catch (Exception err) {
                var errorMessage =
                    string.Format(
                        "Failed to call custom template formula.  Most likely cause is a mismatch between the number of parameters passed and the function signature.  " +
                        "The custom function must return a string.  " +
                        "Number of parameters {0}.  Type of custom formula function {1}",
                        parms.Length, customFunction.GetType().FullName);
                logger.Error(errorMessage, err);
                throw new TemplateApiException(errorMessage, err);

            }
        }
    }
}
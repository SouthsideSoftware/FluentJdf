using System.Collections.Generic;
using System.Linq;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core.CodeContracts
{
    /// <summary>
    /// Precondition checking for methods.
    /// </summary>
    public static class ParameterCheck
    {
        private static string GetParameterRequiredErrorMessage(string parameterName)
        {
            return string.Format(Messages.ParameterCheck_GetParameterRequiredErrorMessage, parameterName);
        }

        private static void ParameterNameRequired(string parameterName)
        {
            Require(!string.IsNullOrEmpty(parameterName), GetParameterRequiredErrorMessage("parameterName"));
        }

        /// <summary>
        /// Throw a Precondition exception if the provided string
        /// is null, empty or contains only whitespace.
        /// </summary>
        /// <param name="parameter">Teh string parameter to check.</param>
        /// <param name="parameterName">The name of the string parameter (used in error messages).</param>
        /// <exception cref="PreconditionException">
        /// <para>The parameter is null, empty or contains only whitespace.</para>
        /// <para>- or -</para>
        /// <para>The parameter name is null, empty or all whitespace</para>
        /// </exception>
        public static void StringRequiredAndNotWhitespace(string parameter, string parameterName) {
            ParameterNameRequired(parameterName);

            Require(!string.IsNullOrWhiteSpace(parameter), string.Format(Messages.ParameterCheck_StringRequiredAndNotWhitespace, parameterName));
        }

        /// <summary>
        /// Throws a Precondition exception if the provided object
        /// is null
        /// </summary>
        /// <param name="parameter">The object to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="PreconditionException">
        /// <para>The object is null</para>
        /// <para>- or -</para>
        /// <para>The parameter name is null, empty or all whitespace</para>
        /// </exception>
        public static void ParameterRequired(object parameter, string parameterName)
        {
            ParameterNameRequired(parameterName);

            Require(parameter != null, GetParameterRequiredErrorMessage(parameterName));
        }

        /// <summary>
        /// Throws a Precondition exception if the provided integer is zero
        /// </summary>
        /// <param name="parameter">The integer to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="PreconditionException">
        /// <para>The integer is zero</para>
        /// <para>- or -</para>
        /// <para>The parameter name is null, empty or all whitespace</para>
        /// </exception>
        public static void IntParameterIsNonZero(int parameter, string parameterName)
        {
            ParameterNameRequired(parameterName);

            Require(parameter != 0, string.Format(Messages.ParameterCheck_IntParameterIsNonZero, parameterName));
        }

        /// <summary>
        /// Throws a Precondition exception if the provided integer is not greater than zero
        /// </summary>
        /// <param name="parameter">The integer to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="PreconditionException">
        /// <para>The integer is not greater than zero.</para>
        /// <para>- or -</para>
        /// <para>The parameter name is null, empty or all whitespace</para>
        /// </exception>
        public static void IntParameterGreaterThanZero(int parameter, string parameterName)
        {
            ParameterNameRequired(parameterName);

            Require(parameter > 0, string.Format(Messages.ParameterCheck_IntParameterGreaterThanZero, parameterName));
        }

        /// <summary>
        /// Throws a Precondition exception if the provided list is null or does not contain at least one member
        /// </summary>
        /// <typeparam name="T">The type of list</typeparam>
        /// <param name="listParameter">A list of type T.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <exception cref="PreconditionException">
        /// <para>The list is null</para>
        /// <para>- or -</para>
        /// <para>The list does not contain at least one element</para>
        /// <para>- or -</para>
        /// <para>The parameter name is null, empty or all whitespace</para>
        /// </exception>
        public static void ListMustContainAtLeastOne<T>(IList<T> listParameter, string parameterName)
        {
            ParameterRequired(listParameter, parameterName);

            Require(listParameter.Count > 0, string.Format(Messages.ParameterCheck_ListMustContainAtLeastOne, parameterName));
        }

        /// <summary>
        /// Throws a Precondition exception if the provided IEnumerable is null or does not contain at least one member
        /// </summary>
        /// <typeparam name="T">The type of enumerated object</typeparam>
        /// <param name="enumerable">An IEnumerable of type T.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <exception cref="PreconditionException">
        /// <para>The enumerable is null</para>
        /// <para>- or -</para>
        /// <para>The enumerable does not contain at least one element</para>
        /// <para>- or -</para>
        /// <para>The parameter name is null, empty or all whitespace</para>
        /// </exception>
        public static void MustContainAtLeastOne<T>(IEnumerable<T> enumerable, string parameterName)
        {
            ParameterRequired(enumerable, parameterName);

            Require(enumerable.Count() > 0, string.Format(Messages.ParameterCheck_ListMustContainAtLeastOne, parameterName));
        }

        private static void Require(bool assertion, string message)
        {
            if (!assertion) throw new PreconditionException(message);
        }
    }
}

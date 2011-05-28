namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJdfDifferenceListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void ElementNameDifference(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void DifferentElements(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void DifferentAttributes(string message);
    }
}

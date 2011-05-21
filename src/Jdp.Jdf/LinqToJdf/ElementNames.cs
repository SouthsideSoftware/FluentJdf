using System.Xml.Linq;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Name helpers for JDF
    /// </summary>
    public static class ElementNames
    {
        /// <summary>
        /// Generate the name of the link element
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static XName Link(this XName elementName)
        {
            return elementName + "Link";
        }

#pragma warning disable 1591

        public static XName Address = Globals.JdfName("Address");
        public static XName ArtDeliveryIntent = Globals.JdfName("ArtDeliveryIntent");
        public static XName BinderBrand = Globals.JdfName("BinderBrand");
        public static XName BinderName = Globals.JdfName("BinderName");
        public static XName BindingSide = Globals.JdfName("BindingSide");
        public static XName BindingType = Globals.JdfName("BindingType");
        public static XName BinderMaterial = Globals.JdfName("BinderMaterial");
        public static XName BindingColor = Globals.JdfName("BindingColor");
        public static XName BindingColorDetails = Globals.JdfName("BindingColorDetails");
        public static XName BindingIntent = Globals.JdfName("BindingIntent");
        public static XName ColorantControl = Globals.JdfName("ColorantControl");
        public static XName ComChannel = Globals.JdfName("ComChannel");
        public static XName Comment = Globals.JdfName("Comment");
        public static XName Company = Globals.JdfName("Company");
        public static XName Component = Globals.JdfName("Component");
        public static XName Contact = Globals.JdfName("Contact");
        public static XName CustomerInfo = Globals.JdfName("CustomerInfo");
        public static XName DeliveryIntent = Globals.JdfName("DeliveryIntent");
        public static XName DeliveryParams = Globals.JdfName("DeliveryParams");
        public static XName DevCapPool = Globals.JdfName("DevCapPool");
        public static XName DevCap = Globals.JdfName("DevCap");
        public static XName DevCaps = Globals.JdfName("DevCaps");
        public static XName Device = Globals.JdfName("Device");
        public static XName DeviceCap = Globals.JdfName("DeviceCap");
        public static XName DigitalPrintingParams = Globals.JdfName("DigitalPrintingParams");
        public static XName Drop = Globals.JdfName("Drop");
        public static XName DropIntent = Globals.JdfName("DropIntent");
        public static XName DropItem = Globals.JdfName("DropItem");
        public static XName DropItemIntent = Globals.JdfName("DropItemIntent");
        public static XName Earliest = Globals.JdfName("Earliest");
        public static XName ExtendedAddress = Globals.JdfName("ExtendedAddress");
        public static XName FileSpec = Globals.JdfName("FileSpec");
        public static XName Fold = Globals.JdfName("Fold");
        public static XName FoldingCatalog = Globals.JdfName("FoldingCatalog");
        public static XName FoldingIntent = Globals.JdfName("FoldingIntent");
        public static XName FoldingParams = Globals.JdfName("FoldingParams");
        public static XName GeneralId = Globals.JdfName("GeneralID");
        public static XName Hole = Globals.JdfName("Hole");
        public static XName HoleLine = Globals.JdfName("HoleLine");
        public static XName HoleList = Globals.JdfName("HoleList");
        public static XName HoleMakingIntent = Globals.JdfName("HoleMakingIntent");
        public static XName HoleMakingParams = Globals.JdfName("HoleMakingParams");
        public static XName HoleType = Globals.JdfName("HoleType");
        public static XName JDF = Globals.JdfName("JDF");
        public static XName JMF = Globals.JdfName("JMF");
        public static XName LayoutElement = Globals.JdfName("LayoutElement");
        public static XName LayoutPreparationParams = Globals.JdfName("LayoutPreparationParams");
        public static XName Media = Globals.JdfName("Media");
        public static XName MediaIntent = Globals.JdfName("MediaIntent");
        public static XName MediaRef = Globals.JdfName("MediaRef");
        public static XName Method = Globals.JdfName("Method");
        public static XName Notification = Globals.JdfName("Notification");
        public static XName Required = Globals.JdfName("Required");
        public static XName ResourceInfo = Globals.JdfName("ResourceInfo");
        public static XName ResourceLinkPool = Globals.JdfName("ResourceLinkPool");
        public static XName ResourcePool = Globals.JdfName("ResourcePool");
        public static XName Response = Globals.JdfName("Response");
        public static XName RingBinding = Globals.JdfName("RingBinding");
        public static XName RingBindingParams = Globals.JdfName("RingBindingParams");
        public static XName RingDiameter = Globals.JdfName("RingDiameter");
        public static XName RingMechanic = Globals.JdfName("RingMechanic");
        public static XName RingSystem = Globals.JdfName("RingSystem");
        public static XName RivetsExposed = Globals.JdfName("RivetsExposed");
        public static XName RunList = Globals.JdfName("RunList");
        public static XName ServiceLevel = Globals.JdfName("ServiceLevel");
        public static XName StitchNumber = Globals.JdfName("StitchNumber");
        public static XName StitchingParams = Globals.JdfName("StitchingParams");
        public static XName Transfer = Globals.JdfName("Transfer");
        public static XName Value = Globals.JdfName("Value");
        public static XName ViewBinder = Globals.JdfName("ViewBinder");

#pragma warning restore 1591

    }
}

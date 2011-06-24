using System.Xml.Linq;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Name helpers for JDF
    /// </summary>
    public static class ProcessType
    {
#pragma warning disable 1591

        /// <summary>
        /// Gets the fully qualified name of a JDF type attribute in the JDF namespace.
        /// </summary>
        /// <param name="jdfElementType"></param>
        /// <returns></returns>
        public static XName XsiJdfElementType(string jdfElementType)
        {
            return Globals.JdfNamespace.GetName(jdfElementType);
        }

        public static string AdhesiveBinding = "AdhesiveBinding";
        public static string Approval = "Approval";
        public static string AssetListCreation = "AssetListCreation";
        public static string Bending = "Bending";
        public static string BlockPreparation = "BlockPreparation";
        public static string BoxFolding = "BoxFolding";
        public static string BoxPacking = "BoxPacking";
        public static string Buffer = "Buffer";
        public static string Bundling = "Bundling";
        public static string CaseMaking = "CaseMaking";
        public static string CasingIn = "CasingIn";
        public static string ChannelBinding = "ChannelBinding";
        public static string CoilBinding = "CoilBinding";
        public static string Collecting = "Collecting";
        public static string ColorCorrection = "ColorCorrection";
        public static string ColorSpaceConversion = "ColorSpaceConversion";
        public static string Combine = "Combine";
        public static string Combined = "Combined";
        public static string ContactCopying = "ContactCopying";
        public static string ContoneCalibration = "ContoneCalibration";
        public static string ConventionalPrinting = "ConventionalPrinting";
        public static string CoverApplication = "CoverApplication";
        public static string Creasing = "Creasing";
        public static string Cutting = "Cutting";
        public static string CylinderLayoutPreparation = "CylinderLayoutPreparation";
        public static string DBDocTemplateLayout = "DBDocTemplateLayout";
        public static string DBTemplateMerging = "DBTemplateMerging";
        public static string Delivery = "Delivery";
        public static string DieDesign = "DieDesign";
        public static string DieLayoutProduction = "DieLayoutProduction";
        public static string DieMaking = "DieMaking";
        public static string DigitalDelivery = "DigitalDelivery";
        public static string DigitalPrinting = "DigitalPrinting";
        public static string Dividing = "Dividing";
        public static string Embossing = "Embossing";
        public static string EndSheetGluing = "EndSheetGluing";
        public static string Feeding = "Feeding";
        public static string FilmToPlateCopying = "FilmToPlateCopying";
        public static string Folding = "Folding";
        public static string FormatConversion = "FormatConversion";
        public static string Gathering = "Gathering";
        public static string Gluing = "Gluing";
        public static string HeadBandApplication = "HeadBandApplication";
        public static string HoleMaking = "HoleMaking";
        public static string IDPrinting = "IDPrinting";
        public static string ImageReplacement = "ImageReplacement";
        public static string ImageSetting = "ImageSetting";
        public static string Imposition = "Imposition";
        public static string InkZoneCalculation = "InkZoneCalculation";
        public static string Inserting = "Inserting";
        public static string Intent = "Product";
        public static string Interpreting = "Interpreting";
        public static string Jacketing = "Jacketing";
        public static string Labeling = "Labeling";
        public static string Laminating = "Laminating";
        public static string LayoutElementProduction = "LayoutElementProduction";
        public static string LayoutPreparation = "LayoutPreparation";
        public static string LayoutShifting = "LayoutShifting";
        public static string LongitudinalRibbonOperations = "LongitudinalRibbonOperations";
        public static string ManualLabor = "ManualLabor";
        public static string Numbering = "Numbering";
        public static string Ordering = "Ordering";
        public static string PDFToPSConversion = "PDFToPSConversion";
        public static string PDLCreation = "PDLCreation";
        public static string PSToPDFConversion = "PSToPDFConversion";
        public static string Packing = "Packing";
        public static string PageAssigning = "PageAssigning";
        public static string Palletizing = "Palletizing";
        public static string Perforating = "Perforating";
        public static string PlasticCombBinding = "PlasticCombBinding";
        public static string Preflight = "Preflight";
        public static string PreviewGeneration = "PreviewGeneration";
        public static string PrintRolling = "PrintRolling";
        public static string ProcessGroup = "ProcessGroup";
        public static string Product = "Product";
        public static string Proofing = "Proofing";
        public static string QualityControl = "QualityControl";
        public static string RasterReading = "RasterReading";
        public static string Rendering = "Rendering";
        public static string ResourceDefinition = "ResourceDefinition";
        public static string RingBinding = "RingBinding";
        public static string SaddleStitching = "SaddleStitching";
        public static string Scanning = "Scanning";
        public static string Screening = "Screening";
        public static string Separation = "Separation";
        public static string ShapeCutting = "ShapeCutting";
        public static string ShapeDefProduction = "ShapeDefProduction";
        public static string Shrinking = "Shrinking";
        public static string SideSewing = "SideSewing";
        public static string SoftProofing = "SoftProofing";
        public static string SpinePreparation = "SpinePreparation";
        public static string SpineTaping = "SpineTaping";
        public static string Split = "Split";
        public static string Stacking = "Stacking";
        public static string StaticBlocking = "StaticBlocking";
        public static string Stitching = "Stitching";
        public static string Strapping = "Strapping";
        public static string StripBinding = "StripBinding";
        public static string Stripping = "Stripping";
        public static string ThreadSealing = "ThreadSealing";
        public static string ThreadSewing = "ThreadSewing";
        public static string Tiling = "Tiling";
        public static string Trapping = "Trapping";
        public static string Trimming = "Trimming";
        public static string Varnishing = "Varnishing";
        public static string Verification = "Verification";
        public static string WebInlineFinishing = "WebInlineFinishing";
        public static string WireCombBinding = "WireCombBinding";
        public static string Wrapping = "Wrapping";

#pragma warning restore 1591

    }
}
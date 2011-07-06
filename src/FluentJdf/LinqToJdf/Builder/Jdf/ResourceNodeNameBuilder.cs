using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jdf {

    //Note: ResourceNodeBuilder items generated with ResourceGenerator.linq

    /// <summary>
    /// Factory to create resources.
    /// </summary>
    public class ResourceNodeNameBuilder {

        internal JdfNodeBuilder ParentJdf;
        readonly ResourceUsage usage;

        internal ResourceNodeNameBuilder(JdfNodeBuilder jdfNodeBuilder, ResourceUsage usage) {
            ParameterCheck.ParameterRequired(jdfNodeBuilder, "jdfNodeBuilder");

            ParentJdf = jdfNodeBuilder;
            this.usage = usage;
        }

        /// <summary>
        /// Create a Address and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Address(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Address, usage, id);
        }

        /// <summary>
        /// Create a AdhesiveBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder AdhesiveBindingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.AdhesiveBindingParams, usage, id);
        }

        /// <summary>
        /// Create a ApprovalParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ApprovalParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ApprovalParams, usage, id);
        }

        /// <summary>
        /// Create a ApprovalSuccess and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ApprovalSuccess(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ApprovalSuccess, usage, id);
        }

        /// <summary>
        /// Create a ArtDeliveryIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ArtDeliveryIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ArtDeliveryIntent, usage, id);
        }

        /// <summary>
        /// Create a Assembly and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Assembly(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Assembly, usage, id);
        }

        /// <summary>
        /// Create a AssetListCreationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder AssetListCreationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.AssetListCreationParams, usage, id);
        }

        /// <summary>
        /// Create a AutomatedOverPrintParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder AutomatedOverPrintParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.AutomatedOverPrintParams, usage, id);
        }

        /// <summary>
        /// Create a BarcodeCompParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BarcodeCompParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BarcodeCompParams, usage, id);
        }

        /// <summary>
        /// Create a BarcodeReproParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BarcodeReproParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BarcodeReproParams, usage, id);
        }

        /// <summary>
        /// Create a BendingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BendingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BendingParams, usage, id);
        }

        /// <summary>
        /// Create a BinderySignature and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BinderySignature(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BinderySignature, usage, id);
        }

        /// <summary>
        /// Create a BindingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BindingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BindingIntent, usage, id);
        }

        /// <summary>
        /// Create a BlockPreparationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BlockPreparationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BlockPreparationParams, usage, id);
        }

        /// <summary>
        /// Create a BoxFoldingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BoxFoldingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BoxFoldingParams, usage, id);
        }

        /// <summary>
        /// Create a BoxPackingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BoxPackingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BoxPackingParams, usage, id);
        }

        /// <summary>
        /// Create a BufferParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BufferParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BufferParams, usage, id);
        }

        /// <summary>
        /// Create a Bundle and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Bundle(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Bundle, usage, id);
        }

        /// <summary>
        /// Create a BundlingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BundlingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BundlingParams, usage, id);
        }

        /// <summary>
        /// Create a ByteMap and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ByteMap(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ByteMap, usage, id);
        }

        /// <summary>
        /// Create a CaseMakingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CaseMakingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CaseMakingParams, usage, id);
        }

        /// <summary>
        /// Create a CasingInParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CasingInParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CasingInParams, usage, id);
        }

        /// <summary>
        /// Create a ChannelBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ChannelBindingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ChannelBindingParams, usage, id);
        }

        /// <summary>
        /// Create a CIELABMeasuringField and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CIELABMeasuringField(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CIELABMeasuringField, usage, id);
        }

        /// <summary>
        /// Create a CoilBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CoilBindingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CoilBindingParams, usage, id);
        }

        /// <summary>
        /// Create a CollectingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CollectingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CollectingParams, usage, id);
        }

        /// <summary>
        /// Create a Color and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Color(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Color, usage, id);
        }

        /// <summary>
        /// Create a ColorantAlias and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorantAlias(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ColorantAlias, usage, id);
        }

        /// <summary>
        /// Create a ColorantControl and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorantControl(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ColorantControl, usage, id);
        }

        /// <summary>
        /// Create a ColorControlStrip and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorControlStrip(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ColorControlStrip, usage, id);
        }

        /// <summary>
        /// Create a ColorCorrectionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorCorrectionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ColorCorrectionParams, usage, id);
        }

        /// <summary>
        /// Create a ColorIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ColorIntent, usage, id);
        }

        /// <summary>
        /// Create a ColorMeasurementConditions and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorMeasurementConditions(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ColorMeasurementConditions, usage, id);
        }

        /// <summary>
        /// Create a ColorPool and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorPool(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ColorPool, usage, id);
        }

        /// <summary>
        /// Create a ColorSpaceConversionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorSpaceConversionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ColorSpaceConversionParams, usage, id);
        }

        /// <summary>
        /// Create a ComChannel and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ComChannel(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ComChannel, usage, id);
        }

        /// <summary>
        /// Create a Company and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Company(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Company, usage, id);
        }

        /// <summary>
        /// Create a Component and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Component(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Component, usage, id);
        }

        /// <summary>
        /// Create a Contact and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Contact(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Contact, usage, id);
        }

        /// <summary>
        /// Create a ContactCopyParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ContactCopyParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ContactCopyParams, usage, id);
        }

        /// <summary>
        /// Create a ContentList and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ContentList(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ContentList, usage, id);
        }

        /// <summary>
        /// Create a ConventionalPrintingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ConventionalPrintingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ConventionalPrintingParams, usage, id);
        }

        /// <summary>
        /// Create a CoverApplicationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CoverApplicationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CoverApplicationParams, usage, id);
        }

        /// <summary>
        /// Create a CreasingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CreasingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CreasingParams, usage, id);
        }

        /// <summary>
        /// Create a CustomerInfo and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CustomerInfo(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CustomerInfo, usage, id);
        }

        /// <summary>
        /// Create a CutBlock and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CutBlock(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CutBlock, usage, id);
        }

        /// <summary>
        /// Create a CutMark and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CutMark(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CutMark, usage, id);
        }

        /// <summary>
        /// Create a CuttingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CuttingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CuttingParams, usage, id);
        }

        /// <summary>
        /// Create a CylinderLayout and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CylinderLayout(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CylinderLayout, usage, id);
        }

        /// <summary>
        /// Create a CylinderLayoutPreparationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CylinderLayoutPreparationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.CylinderLayoutPreparationParams, usage, id);
        }

        /// <summary>
        /// Create a DBMergeParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DBMergeParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DBMergeParams, usage, id);
        }

        /// <summary>
        /// Create a DBRules and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DBRules(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DBRules, usage, id);
        }

        /// <summary>
        /// Create a DBSchema and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DBSchema(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DBSchema, usage, id);
        }

        /// <summary>
        /// Create a DBSelection and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DBSelection(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DBSelection, usage, id);
        }

        /// <summary>
        /// Create a DeliveryIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DeliveryIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DeliveryIntent, usage, id);
        }

        /// <summary>
        /// Create a DeliveryParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DeliveryParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DeliveryParams, usage, id);
        }

        /// <summary>
        /// Create a DensityMeasuringField and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DensityMeasuringField(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DensityMeasuringField, usage, id);
        }

        /// <summary>
        /// Create a DevelopingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DevelopingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DevelopingParams, usage, id);
        }

        /// <summary>
        /// Create a Device and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Device(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Device, usage, id);
        }

        /// <summary>
        /// Create a DeviceMark and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DeviceMark(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DeviceMark, usage, id);
        }

        /// <summary>
        /// Create a DeviceNSpace and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DeviceNSpace(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DeviceNSpace, usage, id);
        }

        /// <summary>
        /// Create a DieLayout and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DieLayout(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DieLayout, usage, id);
        }

        /// <summary>
        /// Create a DieLayoutProductionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DieLayoutProductionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DieLayoutProductionParams, usage, id);
        }

        /// <summary>
        /// Create a DigitalDeliveryParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DigitalDeliveryParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DigitalDeliveryParams, usage, id);
        }

        /// <summary>
        /// Create a DigitalMedia and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DigitalMedia(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DigitalMedia, usage, id);
        }

        /// <summary>
        /// Create a DigitalPrintingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DigitalPrintingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DigitalPrintingParams, usage, id);
        }

        /// <summary>
        /// Create a DividingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DividingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.DividingParams, usage, id);
        }

        /// <summary>
        /// Create a ElementColorParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ElementColorParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ElementColorParams, usage, id);
        }

        /// <summary>
        /// Create a EmbossingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder EmbossingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.EmbossingIntent, usage, id);
        }

        /// <summary>
        /// Create a EmbossingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder EmbossingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.EmbossingParams, usage, id);
        }

        /// <summary>
        /// Create a Employee and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Employee(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Employee, usage, id);
        }

        /// <summary>
        /// Create a EndSheetGluingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder EndSheetGluingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.EndSheetGluingParams, usage, id);
        }

        /// <summary>
        /// Create a ExposedMedia and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ExposedMedia(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ExposedMedia, usage, id);
        }

        /// <summary>
        /// Create a ExternalImpositionTemplate and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ExternalImpositionTemplate(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ExternalImpositionTemplate, usage, id);
        }

        /// <summary>
        /// Create a FeedingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FeedingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.FeedingParams, usage, id);
        }

        /// <summary>
        /// Create a FileSpec and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FileSpec(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.FileSpec, usage, id);
        }

        /// <summary>
        /// Create a FitPolicy and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FitPolicy(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.FitPolicy, usage, id);
        }

        /// <summary>
        /// Create a Fold and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Fold(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Fold, usage, id);
        }

        /// <summary>
        /// Create a FoldingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FoldingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.FoldingIntent, usage, id);
        }

        /// <summary>
        /// Create a FoldingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FoldingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.FoldingParams, usage, id);
        }

        /// <summary>
        /// Create a FontParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FontParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.FontParams, usage, id);
        }

        /// <summary>
        /// Create a FontPolicy and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FontPolicy(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.FontPolicy, usage, id);
        }

        /// <summary>
        /// Create a FormatConversionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FormatConversionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.FormatConversionParams, usage, id);
        }

        /// <summary>
        /// Create a GatheringParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder GatheringParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.GatheringParams, usage, id);
        }

        /// <summary>
        /// Create a GlueApplication and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder GlueApplication(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.GlueApplication, usage, id);
        }

        /// <summary>
        /// Create a GlueLine and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder GlueLine(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.GlueLine, usage, id);
        }

        /// <summary>
        /// Create a GluingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder GluingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.GluingParams, usage, id);
        }

        /// <summary>
        /// Create a HeadBandApplicationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder HeadBandApplicationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.HeadBandApplicationParams, usage, id);
        }

        /// <summary>
        /// Create a Hole and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Hole(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Hole, usage, id);
        }

        /// <summary>
        /// Create a HoleLine and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder HoleLine(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.HoleLine, usage, id);
        }

        /// <summary>
        /// Create a HoleMakingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder HoleMakingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.HoleMakingIntent, usage, id);
        }

        /// <summary>
        /// Create a HoleMakingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder HoleMakingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.HoleMakingParams, usage, id);
        }

        /// <summary>
        /// Create a IdentificationField and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder IdentificationField(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.IdentificationField, usage, id);
        }

        /// <summary>
        /// Create a IDPrintingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder IDPrintingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.IDPrintingParams, usage, id);
        }

        /// <summary>
        /// Create a ImageCompressionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ImageCompressionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ImageCompressionParams, usage, id);
        }

        /// <summary>
        /// Create a ImageReplacementParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ImageReplacementParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ImageReplacementParams, usage, id);
        }

        /// <summary>
        /// Create a ImageSetterParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ImageSetterParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ImageSetterParams, usage, id);
        }

        /// <summary>
        /// Create a Ink and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Ink(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Ink, usage, id);
        }

        /// <summary>
        /// Create a InkZoneCalculationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InkZoneCalculationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.InkZoneCalculationParams, usage, id);
        }

        /// <summary>
        /// Create a InkZoneProfile and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InkZoneProfile(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.InkZoneProfile, usage, id);
        }

        /// <summary>
        /// Create a InsertingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InsertingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.InsertingIntent, usage, id);
        }

        /// <summary>
        /// Create a InsertingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InsertingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.InsertingParams, usage, id);
        }

        /// <summary>
        /// Create a InsertSheet and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InsertSheet(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.InsertSheet, usage, id);
        }

        /// <summary>
        /// Create a InterpretedPDLData and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InterpretedPDLData(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.InterpretedPDLData, usage, id);
        }

        /// <summary>
        /// Create a InterpretingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InterpretingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.InterpretingParams, usage, id);
        }

        /// <summary>
        /// Create a JacketingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder JacketingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.JacketingParams, usage, id);
        }

        /// <summary>
        /// Create a JobField and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder JobField(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.JobField, usage, id);
        }

        /// <summary>
        /// Create a LabelingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LabelingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.LabelingParams, usage, id);
        }

        /// <summary>
        /// Create a LaminatingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LaminatingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.LaminatingIntent, usage, id);
        }

        /// <summary>
        /// Create a LaminatingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LaminatingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.LaminatingParams, usage, id);
        }

        /// <summary>
        /// Create a Layout and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Layout(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Layout, usage, id);
        }

        /// <summary>
        /// Create a LayoutElement and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutElement(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.LayoutElement, usage, id);
        }

        /// <summary>
        /// Create a LayoutElementProductionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutElementProductionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.LayoutElementProductionParams, usage, id);
        }

        /// <summary>
        /// Create a LayoutIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.LayoutIntent, usage, id);
        }

        /// <summary>
        /// Create a LayoutPreparationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutPreparationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.LayoutPreparationParams, usage, id);
        }

        /// <summary>
        /// Create a LayoutShift and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutShift(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.LayoutShift, usage, id);
        }

        /// <summary>
        /// Create a LongitudinalRibbonOperationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LongitudinalRibbonOperationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.LongitudinalRibbonOperationParams, usage, id);
        }

        /// <summary>
        /// Create a ManualLaborParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ManualLaborParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ManualLaborParams, usage, id);
        }

        /// <summary>
        /// Create a Media and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Media(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Media, usage, id);
        }

        /// <summary>
        /// Create a MediaIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder MediaIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.MediaIntent, usage, id);
        }

        /// <summary>
        /// Create a MediaSource and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder MediaSource(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.MediaSource, usage, id);
        }

        /// <summary>
        /// Create a MiscConsumable and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder MiscConsumable(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.MiscConsumable, usage, id);
        }

        /// <summary>
        /// Create a NodeInfo and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder NodeInfo(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.NodeInfo, usage, id);
        }

        /// <summary>
        /// Create a NumberingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder NumberingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.NumberingIntent, usage, id);
        }

        /// <summary>
        /// Create a NumberingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder NumberingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.NumberingParams, usage, id);
        }

        /// <summary>
        /// Create a ObjectResolution and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ObjectResolution(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ObjectResolution, usage, id);
        }

        /// <summary>
        /// Create a OrderingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder OrderingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.OrderingParams, usage, id);
        }

        /// <summary>
        /// Create a PackingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PackingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PackingIntent, usage, id);
        }

        /// <summary>
        /// Create a PackingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PackingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PackingParams, usage, id);
        }

        /// <summary>
        /// Create a PageAssignParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PageAssignParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PageAssignParams, usage, id);
        }

        /// <summary>
        /// Create a PageList and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PageList(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PageList, usage, id);
        }

        /// <summary>
        /// Create a Pallet and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Pallet(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Pallet, usage, id);
        }

        /// <summary>
        /// Create a PalletizingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PalletizingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PalletizingParams, usage, id);
        }

        /// <summary>
        /// Create a PDFToPSConversionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PDFToPSConversionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PDFToPSConversionParams, usage, id);
        }

        /// <summary>
        /// Create a PDLCreationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PDLCreationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PDLCreationParams, usage, id);
        }

        /// <summary>
        /// Create a PDLResourceAlias and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PDLResourceAlias(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PDLResourceAlias, usage, id);
        }

        /// <summary>
        /// Create a PerforatingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PerforatingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PerforatingParams, usage, id);
        }

        /// <summary>
        /// Create a Person and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Person(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Person, usage, id);
        }

        /// <summary>
        /// Create a PlaceHolderResource and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PlaceHolderResource(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PlaceHolderResource, usage, id);
        }

        /// <summary>
        /// Create a PlasticCombBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PlasticCombBindingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PlasticCombBindingParams, usage, id);
        }

        /// <summary>
        /// Create a PlateCopyParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PlateCopyParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PlateCopyParams, usage, id);
        }

        /// <summary>
        /// Create a PreflightAnalysis and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightAnalysis(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PreflightAnalysis, usage, id);
        }

        /// <summary>
        /// Create a PreflightInventory and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightInventory(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PreflightInventory, usage, id);
        }

        /// <summary>
        /// Create a PreflightParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PreflightParams, usage, id);
        }

        /// <summary>
        /// Create a PreflightProfile and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightProfile(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PreflightProfile, usage, id);
        }

        /// <summary>
        /// Create a PreflightReport and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightReport(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PreflightReport, usage, id);
        }

        /// <summary>
        /// Create a PreflightReportRulePool and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightReportRulePool(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PreflightReportRulePool, usage, id);
        }

        /// <summary>
        /// Create a PreviewGenerationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreviewGenerationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PreviewGenerationParams, usage, id);
        }

        /// <summary>
        /// Create a PrintCondition and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PrintCondition(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PrintCondition, usage, id);
        }

        /// <summary>
        /// Create a PrintRollingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PrintRollingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PrintRollingParams, usage, id);
        }

        /// <summary>
        /// Create a ProductionIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ProductionIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ProductionIntent, usage, id);
        }

        /// <summary>
        /// Create a ProductionPath and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ProductionPath(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ProductionPath, usage, id);
        }

        /// <summary>
        /// Create a ProofingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ProofingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ProofingIntent, usage, id);
        }

        /// <summary>
        /// Create a ProofingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ProofingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ProofingParams, usage, id);
        }

        /// <summary>
        /// Create a PSToPDFConversionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PSToPDFConversionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PSToPDFConversionParams, usage, id);
        }

        /// <summary>
        /// Create a PublishingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PublishingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.PublishingIntent, usage, id);
        }

        /// <summary>
        /// Create a QualityControlParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder QualityControlParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.QualityControlParams, usage, id);
        }

        /// <summary>
        /// Create a QualityControlResult and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder QualityControlResult(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.QualityControlResult, usage, id);
        }

        /// <summary>
        /// Create a RasterReadingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RasterReadingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.RasterReadingParams, usage, id);
        }

        /// <summary>
        /// Create a RefAnchor and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RefAnchor(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.RefAnchor, usage, id);
        }

        /// <summary>
        /// Create a RegisterMark and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RegisterMark(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.RegisterMark, usage, id);
        }

        /// <summary>
        /// Create a RegisterRibbon and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RegisterRibbon(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.RegisterRibbon, usage, id);
        }

        /// <summary>
        /// Create a RenderingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RenderingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.RenderingParams, usage, id);
        }

        /// <summary>
        /// Create a ResourceDefinitionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ResourceDefinitionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ResourceDefinitionParams, usage, id);
        }

        /// <summary>
        /// Create a RingBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RingBindingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.RingBindingParams, usage, id);
        }

        /// <summary>
        /// Create a RollStand and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RollStand(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.RollStand, usage, id);
        }

        /// <summary>
        /// Create a RunList and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RunList(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.RunList, usage, id);
        }

        /// <summary>
        /// Create a SaddleStitchingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SaddleStitchingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.SaddleStitchingParams, usage, id);
        }

        /// <summary>
        /// Create a ScanParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ScanParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ScanParams, usage, id);
        }

        /// <summary>
        /// Create a ScavengerArea and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ScavengerArea(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ScavengerArea, usage, id);
        }

        /// <summary>
        /// Create a ScreeningIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ScreeningIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ScreeningIntent, usage, id);
        }

        /// <summary>
        /// Create a ScreeningParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ScreeningParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ScreeningParams, usage, id);
        }

        /// <summary>
        /// Create a SeparationControlParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SeparationControlParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.SeparationControlParams, usage, id);
        }

        /// <summary>
        /// Create a Shape and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Shape(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Shape, usage, id);
        }

        /// <summary>
        /// Create a ShapeCuttingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShapeCuttingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ShapeCuttingIntent, usage, id);
        }

        /// <summary>
        /// Create a ShapeCuttingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShapeCuttingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ShapeCuttingParams, usage, id);
        }

        /// <summary>
        /// Create a ShapeDef and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShapeDef(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ShapeDef, usage, id);
        }

        /// <summary>
        /// Create a ShapeDefProductionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShapeDefProductionParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ShapeDefProductionParams, usage, id);
        }

        /// <summary>
        /// Create a Sheet and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Sheet(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Sheet, usage, id);
        }

        /// <summary>
        /// Create a ShrinkingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShrinkingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ShrinkingParams, usage, id);
        }

        /// <summary>
        /// Create a SideSewingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SideSewingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.SideSewingParams, usage, id);
        }

        /// <summary>
        /// Create a SizeIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SizeIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.SizeIntent, usage, id);
        }

        /// <summary>
        /// Create a SpinePreparationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SpinePreparationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.SpinePreparationParams, usage, id);
        }

        /// <summary>
        /// Create a SpineTapingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SpineTapingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.SpineTapingParams, usage, id);
        }

        /// <summary>
        /// Create a StackingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StackingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.StackingParams, usage, id);
        }

        /// <summary>
        /// Create a StaticBlockingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StaticBlockingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.StaticBlockingParams, usage, id);
        }

        /// <summary>
        /// Create a StitchingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StitchingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.StitchingParams, usage, id);
        }

        /// <summary>
        /// Create a Strap and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Strap(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Strap, usage, id);
        }

        /// <summary>
        /// Create a StrappingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StrappingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.StrappingParams, usage, id);
        }

        /// <summary>
        /// Create a StripBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StripBindingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.StripBindingParams, usage, id);
        }

        /// <summary>
        /// Create a StrippingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StrippingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.StrippingParams, usage, id);
        }

        /// <summary>
        /// Create a Surface and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Surface(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Surface, usage, id);
        }

        /// <summary>
        /// Create a ThreadSealingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ThreadSealingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ThreadSealingParams, usage, id);
        }

        /// <summary>
        /// Create a ThreadSewingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ThreadSewingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.ThreadSewingParams, usage, id);
        }

        /// <summary>
        /// Create a Tile and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Tile(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Tile, usage, id);
        }

        /// <summary>
        /// Create a Tool and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Tool(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.Tool, usage, id);
        }

        /// <summary>
        /// Create a TransferCurve and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TransferCurve(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.TransferCurve, usage, id);
        }

        /// <summary>
        /// Create a TransferCurvePool and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TransferCurvePool(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.TransferCurvePool, usage, id);
        }

        /// <summary>
        /// Create a TransferFunctionControl and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TransferFunctionControl(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.TransferFunctionControl, usage, id);
        }

        /// <summary>
        /// Create a TrappingDetails and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TrappingDetails(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.TrappingDetails, usage, id);
        }

        /// <summary>
        /// Create a TrappingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TrappingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.TrappingParams, usage, id);
        }

        /// <summary>
        /// Create a TrapRegion and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TrapRegion(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.TrapRegion, usage, id);
        }

        /// <summary>
        /// Create a TrimmingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TrimmingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.TrimmingParams, usage, id);
        }

        /// <summary>
        /// Create a UsageCounter and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder UsageCounter(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.UsageCounter, usage, id);
        }

        /// <summary>
        /// Create a VarnishingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder VarnishingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.VarnishingParams, usage, id);
        }

        /// <summary>
        /// Create a VerificationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder VerificationParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.VerificationParams, usage, id);
        }

        /// <summary>
        /// Create a WebInlineFinishingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder WebInlineFinishingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.WebInlineFinishingParams, usage, id);
        }

        /// <summary>
        /// Create a WireCombBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder WireCombBindingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.WireCombBindingParams, usage, id);
        }

        /// <summary>
        /// Create a WrappingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder WrappingParams(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.WrappingParams, usage, id);
        }

        /// <summary>
        /// Create a resource with the given name and return a factory to operate in it.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public ResourceNodeBuilder ResourceWithName(XName resourceName) {
            ParameterCheck.ParameterRequired(resourceName, "resourceName");

            return new ResourceNodeBuilder(ParentJdf, resourceName, usage);
        }
    }
}
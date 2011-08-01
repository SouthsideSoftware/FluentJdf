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
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Address, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a AdhesiveBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder AdhesiveBindingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.AdhesiveBindingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ApprovalParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ApprovalParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ApprovalParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ApprovalSuccess and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ApprovalSuccess(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ApprovalSuccess, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ArtDeliveryIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ArtDeliveryIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ArtDeliveryIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a Assembly and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Assembly(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Assembly, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a AssetListCreationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder AssetListCreationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.AssetListCreationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a AutomatedOverPrintParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder AutomatedOverPrintParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.AutomatedOverPrintParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a BarcodeCompParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BarcodeCompParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BarcodeCompParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a BarcodeReproParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BarcodeReproParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BarcodeReproParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a BendingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BendingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BendingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a BinderySignature and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BinderySignature(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BinderySignature, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a BindingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BindingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BindingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a BlockPreparationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BlockPreparationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BlockPreparationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a BoxFoldingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BoxFoldingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BoxFoldingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a BoxPackingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BoxPackingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BoxPackingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a BufferParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BufferParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BufferParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Bundle and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Bundle(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Bundle, usage, id);
            retVal.Element.SetClass("Quantity");
            return retVal;
        }

        /// <summary>
        /// Create a BundlingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder BundlingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.BundlingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ByteMap and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ByteMap(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ByteMap, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CaseMakingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CaseMakingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CaseMakingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CasingInParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CasingInParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CasingInParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ChannelBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ChannelBindingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ChannelBindingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CIELABMeasuringField and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CIELABMeasuringField(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CIELABMeasuringField, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CoilBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CoilBindingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CoilBindingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CollectingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CollectingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CollectingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Color and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Color(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Color, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ColorantAlias and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorantAlias(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ColorantAlias, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ColorantControl and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorantControl(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ColorantControl, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ColorControlStrip and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorControlStrip(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ColorControlStrip, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ColorCorrectionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorCorrectionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ColorCorrectionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ColorIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ColorIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a ColorMeasurementConditions and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorMeasurementConditions(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ColorMeasurementConditions, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ColorPool and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorPool(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ColorPool, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ColorSpaceConversionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ColorSpaceConversionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ColorSpaceConversionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ComChannel and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ComChannel(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ComChannel, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Company and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Company(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Company, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Component and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Component(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Component, usage, id);
            retVal.Element.SetClass("Quantity");
            return retVal;
        }

        /// <summary>
        /// Create a Contact and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Contact(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Contact, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ContactCopyParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ContactCopyParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ContactCopyParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ContentList and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ContentList(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ContentList, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ConventionalPrintingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ConventionalPrintingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ConventionalPrintingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CoverApplicationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CoverApplicationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CoverApplicationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CreasingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CreasingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CreasingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CustomerInfo and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CustomerInfo(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CustomerInfo, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CutBlock and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CutBlock(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CutBlock, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CutMark and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CutMark(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CutMark, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CuttingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CuttingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CuttingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CylinderLayout and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CylinderLayout(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CylinderLayout, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a CylinderLayoutPreparationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder CylinderLayoutPreparationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.CylinderLayoutPreparationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DBMergeParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DBMergeParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DBMergeParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DBRules and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DBRules(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DBRules, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DBSchema and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DBSchema(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DBSchema, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DBSelection and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DBSelection(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DBSelection, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DeliveryIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DeliveryIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DeliveryIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a DeliveryParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DeliveryParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DeliveryParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DensityMeasuringField and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DensityMeasuringField(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DensityMeasuringField, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DevelopingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DevelopingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DevelopingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Device and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Device(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Device, usage, id);
            retVal.Element.SetClass("Implementation");
            return retVal;
        }

        /// <summary>
        /// Create a DeviceMark and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DeviceMark(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DeviceMark, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DeviceNSpace and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DeviceNSpace(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DeviceNSpace, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DieLayout and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DieLayout(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DieLayout, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DieLayoutProductionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DieLayoutProductionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DieLayoutProductionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DigitalDeliveryParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DigitalDeliveryParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DigitalDeliveryParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DigitalMedia and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DigitalMedia(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DigitalMedia, usage, id);
            retVal.Element.SetClass("Handling");
            return retVal;
        }

        /// <summary>
        /// Create a DigitalPrintingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DigitalPrintingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DigitalPrintingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a DividingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder DividingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.DividingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ElementColorParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ElementColorParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ElementColorParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a EmbossingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder EmbossingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.EmbossingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a EmbossingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder EmbossingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.EmbossingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Employee and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Employee(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Employee, usage, id);
            retVal.Element.SetClass("Implementation");
            return retVal;
        }

        /// <summary>
        /// Create a EndSheetGluingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder EndSheetGluingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.EndSheetGluingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ExposedMedia and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ExposedMedia(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ExposedMedia, usage, id);
            retVal.Element.SetClass("Handling");
            return retVal;
        }

        /// <summary>
        /// Create a ExternalImpositionTemplate and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ExternalImpositionTemplate(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ExternalImpositionTemplate, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a FeedingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FeedingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.FeedingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a FileSpec and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FileSpec(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.FileSpec, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a FitPolicy and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FitPolicy(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.FitPolicy, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Fold and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Fold(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Fold, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a FoldingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FoldingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.FoldingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a FoldingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FoldingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.FoldingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a FontParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FontParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.FontParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a FontPolicy and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FontPolicy(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.FontPolicy, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a FormatConversionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder FormatConversionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.FormatConversionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a GatheringParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder GatheringParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.GatheringParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a GlueApplication and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder GlueApplication(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.GlueApplication, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a GlueLine and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder GlueLine(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.GlueLine, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a GluingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder GluingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.GluingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a HeadBandApplicationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder HeadBandApplicationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.HeadBandApplicationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Hole and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Hole(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Hole, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a HoleLine and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder HoleLine(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.HoleLine, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a HoleMakingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder HoleMakingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.HoleMakingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a HoleMakingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder HoleMakingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.HoleMakingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a IdentificationField and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder IdentificationField(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.IdentificationField, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a IDPrintingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder IDPrintingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.IDPrintingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ImageCompressionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ImageCompressionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ImageCompressionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ImageReplacementParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ImageReplacementParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ImageReplacementParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ImageSetterParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ImageSetterParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ImageSetterParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Ink and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Ink(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Ink, usage, id);
            retVal.Element.SetClass("Consumable");
            return retVal;
        }

        /// <summary>
        /// Create a InkZoneCalculationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InkZoneCalculationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.InkZoneCalculationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a InkZoneProfile and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InkZoneProfile(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.InkZoneProfile, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a InsertingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InsertingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.InsertingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a InsertingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InsertingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.InsertingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a InsertSheet and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InsertSheet(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.InsertSheet, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a InterpretedPDLData and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InterpretedPDLData(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.InterpretedPDLData, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a InterpretingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder InterpretingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.InterpretingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a JacketingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder JacketingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.JacketingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a JobField and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder JobField(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.JobField, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a LabelingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LabelingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.LabelingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a LaminatingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LaminatingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.LaminatingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a LaminatingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LaminatingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.LaminatingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Layout and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Layout(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Layout, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a LayoutElement and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutElement(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.LayoutElement, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a LayoutElementProductionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutElementProductionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.LayoutElementProductionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a LayoutIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.LayoutIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a LayoutPreparationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutPreparationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.LayoutPreparationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a LayoutShift and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LayoutShift(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.LayoutShift, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a LongitudinalRibbonOperationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder LongitudinalRibbonOperationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.LongitudinalRibbonOperationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ManualLaborParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ManualLaborParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ManualLaborParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Media and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Media(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Media, usage, id);
            retVal.Element.SetClass("Consumable");
            return retVal;
        }

        /// <summary>
        /// Create a MediaIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder MediaIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.MediaIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a MediaSource and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder MediaSource(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.MediaSource, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a MiscConsumable and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder MiscConsumable(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.MiscConsumable, usage, id);
            retVal.Element.SetClass("Consumable");
            return retVal;
        }

        /// <summary>
        /// Create a NodeInfo and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder NodeInfo(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.NodeInfo, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a NumberingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder NumberingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.NumberingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a NumberingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder NumberingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.NumberingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ObjectResolution and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ObjectResolution(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ObjectResolution, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a OrderingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder OrderingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.OrderingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PackingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PackingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PackingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a PackingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PackingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PackingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PageAssignParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PageAssignParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PageAssignParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PageList and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PageList(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PageList, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Pallet and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Pallet(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Pallet, usage, id);
            retVal.Element.SetClass("Consumable");
            return retVal;
        }

        /// <summary>
        /// Create a PalletizingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PalletizingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PalletizingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PDFToPSConversionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PDFToPSConversionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PDFToPSConversionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PDLCreationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PDLCreationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PDLCreationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PDLResourceAlias and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PDLResourceAlias(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PDLResourceAlias, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PerforatingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PerforatingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PerforatingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Person and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Person(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Person, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PlaceHolderResource and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PlaceHolderResource(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PlaceHolderResource, usage, id);
            retVal.Element.SetClass("PlaceHolder");
            return retVal;
        }

        /// <summary>
        /// Create a PlasticCombBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PlasticCombBindingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PlasticCombBindingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PlateCopyParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PlateCopyParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PlateCopyParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PreflightAnalysis and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightAnalysis(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PreflightAnalysis, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PreflightInventory and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightInventory(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PreflightInventory, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PreflightParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PreflightParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PreflightProfile and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightProfile(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PreflightProfile, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PreflightReport and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightReport(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PreflightReport, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PreflightReportRulePool and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreflightReportRulePool(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PreflightReportRulePool, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PreviewGenerationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PreviewGenerationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PreviewGenerationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PrintCondition and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PrintCondition(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PrintCondition, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PrintRollingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PrintRollingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PrintRollingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ProductionIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ProductionIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ProductionIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a ProductionPath and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ProductionPath(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ProductionPath, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ProofingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ProofingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ProofingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a ProofingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ProofingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ProofingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PSToPDFConversionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PSToPDFConversionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PSToPDFConversionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a PublishingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder PublishingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.PublishingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a QualityControlParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder QualityControlParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.QualityControlParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a QualityControlResult and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder QualityControlResult(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.QualityControlResult, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a RasterReadingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RasterReadingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.RasterReadingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a RefAnchor and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RefAnchor(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.RefAnchor, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a RegisterMark and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RegisterMark(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.RegisterMark, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a RegisterRibbon and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RegisterRibbon(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.RegisterRibbon, usage, id);
            retVal.Element.SetClass("Consumable");
            return retVal;
        }

        /// <summary>
        /// Create a RenderingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RenderingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.RenderingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ResourceDefinitionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ResourceDefinitionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ResourceDefinitionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a RingBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RingBindingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.RingBindingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a RollStand and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RollStand(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.RollStand, usage, id);
            retVal.Element.SetClass("Handling");
            return retVal;
        }

        /// <summary>
        /// Create a RunList and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder RunList(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.RunList, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a SaddleStitchingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SaddleStitchingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.SaddleStitchingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ScanParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ScanParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ScanParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ScavengerArea and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ScavengerArea(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ScavengerArea, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ScreeningIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ScreeningIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ScreeningIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a ScreeningParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ScreeningParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ScreeningParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a SeparationControlParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SeparationControlParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.SeparationControlParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Shape and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Shape(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Shape, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ShapeCuttingIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShapeCuttingIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ShapeCuttingIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a ShapeCuttingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShapeCuttingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ShapeCuttingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ShapeDef and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShapeDef(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ShapeDef, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ShapeDefProductionParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShapeDefProductionParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ShapeDefProductionParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Sheet and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Sheet(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Sheet, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ShrinkingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ShrinkingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ShrinkingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a SideSewingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SideSewingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.SideSewingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a SizeIntent and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SizeIntent(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.SizeIntent, usage, id);
            retVal.Element.SetClass("Intent");
            return retVal;
        }

        /// <summary>
        /// Create a SpinePreparationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SpinePreparationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.SpinePreparationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a SpineTapingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder SpineTapingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.SpineTapingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a StackingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StackingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.StackingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a StaticBlockingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StaticBlockingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.StaticBlockingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a StitchingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StitchingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.StitchingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Strap and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Strap(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Strap, usage, id);
            retVal.Element.SetClass("Consumable");
            return retVal;
        }

        /// <summary>
        /// Create a StrappingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StrappingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.StrappingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a StripBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StripBindingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.StripBindingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a StrippingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder StrippingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.StrippingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Surface and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Surface(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Surface, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ThreadSealingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ThreadSealingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ThreadSealingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a ThreadSewingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder ThreadSewingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.ThreadSewingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Tile and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Tile(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Tile, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a Tool and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder Tool(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.Tool, usage, id);
            retVal.Element.SetClass("Handling");
            return retVal;
        }

        /// <summary>
        /// Create a TransferCurve and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TransferCurve(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.TransferCurve, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a TransferCurvePool and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TransferCurvePool(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.TransferCurvePool, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a TransferFunctionControl and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TransferFunctionControl(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.TransferFunctionControl, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a TrappingDetails and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TrappingDetails(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.TrappingDetails, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a TrappingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TrappingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.TrappingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a TrapRegion and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TrapRegion(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.TrapRegion, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a TrimmingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder TrimmingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.TrimmingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a UsageCounter and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder UsageCounter(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.UsageCounter, usage, id);
            retVal.Element.SetClass("Consumable");
            return retVal;
        }

        /// <summary>
        /// Create a VarnishingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder VarnishingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.VarnishingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a VerificationParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder VerificationParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.VerificationParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a WebInlineFinishingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder WebInlineFinishingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.WebInlineFinishingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a WireCombBindingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder WireCombBindingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.WireCombBindingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
        }

        /// <summary>
        /// Create a WrappingParams and return a builder to operate on it.
        /// </summary>
        /// <param name="id">An optional id, otherwise a unique id will be created</param>
        public ResourceNodeBuilder WrappingParams(string id = null) {
            var retVal = new ResourceNodeBuilder(ParentJdf, Resource.WrappingParams, usage, id);
            retVal.Element.SetClass("Parameter");
            return retVal;
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
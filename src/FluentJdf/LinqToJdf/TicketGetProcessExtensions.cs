using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;
using System.Xml;

namespace FluentJdf.LinqToJdf {

    //WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING 
    //This will be refactored and generated and the Class Types will change. Do not cast to these objects, just use the fluent Methods.
    //WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING 

    /*
     
    Ticket.GetProcess().Bending(); This gets first bending process. 

    Ticket.GetProcesses().Bending(); This gets an enumerator over bending processes. MAYBE LATER?

    Ticket.GetProcess().Named(my xustom xname); This gets a named process.

    Ticket.GetProcesses().Named(my custom xname); This gets an enumerator over named processes. MAYBE LATER?

    Ticket.GetProcess().Named(ProcessType.Bending); This gets bending too since that is the xname for Bending in the JDF namespace.

    Ticket.GetProcess().Bending().WithInput().RunList() This gets the first run list resource that is an input of the first bending.

    Ticket().GetProcess().Bending().WithInputs().RunList() This gets all run list resources that are an input of the first bending. MAYBE LATER.

    You can always stick SelectJDFDescendant(s) onto the end of one of these. Obviously, anything involving a return that is more than one 
    element makes everything more complicated. That's why I indicated we might defer those into another issue to be tackled later.    
    */

    /// <summary>
    /// Extension methods for <see cref="Ticket"/> Class for GetProcess()
    /// </summary>
    public static class TicketGetProcessExtensions {

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static TicketGetProcess GetProcess(this Ticket ticket) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            return new TicketGetProcess(ticket);
        }

        /// <summary>
        /// Get intent node.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static TicketProcess GetIntent(this Ticket ticket) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            var ticketGetProcess = new TicketGetProcess(ticket);
            return ticketGetProcess.Named(ProcessType.Intent);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class TicketGetProcess {
        /// <summary>
        /// AdhesiveBinding
        /// </summary>
        /// <returns></returns>
        public TicketProcess AdhesiveBinding() {
            return Named(ProcessType.AdhesiveBinding);
        }

        /// <summary>
        /// Approval
        /// </summary>
        /// <returns></returns>
        public TicketProcess Approval() {
            return Named(ProcessType.Approval);
        }

        /// <summary>
        /// AssetListCreation
        /// </summary>
        /// <returns></returns>
        public TicketProcess AssetListCreation() {
            return Named(ProcessType.AssetListCreation);
        }

        /// <summary>
        /// Bending
        /// </summary>
        /// <returns></returns>
        public TicketProcess Bending() {
            return Named(ProcessType.Bending);
        }

        /// <summary>
        /// BlockPreparation
        /// </summary>
        /// <returns></returns>
        public TicketProcess BlockPreparation() {
            return Named(ProcessType.BlockPreparation);
        }

        /// <summary>
        /// BoxFolding
        /// </summary>
        /// <returns></returns>
        public TicketProcess BoxFolding() {
            return Named(ProcessType.BoxFolding);
        }

        /// <summary>
        /// BoxPacking
        /// </summary>
        /// <returns></returns>
        public TicketProcess BoxPacking() {
            return Named(ProcessType.BoxPacking);
        }

        /// <summary>
        /// Buffer
        /// </summary>
        /// <returns></returns>
        public TicketProcess Buffer() {
            return Named(ProcessType.Buffer);
        }

        /// <summary>
        /// Bundling
        /// </summary>
        /// <returns></returns>
        public TicketProcess Bundling() {
            return Named(ProcessType.Bundling);
        }

        /// <summary>
        /// CaseMaking
        /// </summary>
        /// <returns></returns>
        public TicketProcess CaseMaking() {
            return Named(ProcessType.CaseMaking);
        }

        /// <summary>
        /// CasingIn
        /// </summary>
        /// <returns></returns>
        public TicketProcess CasingIn() {
            return Named(ProcessType.CasingIn);
        }

        /// <summary>
        /// ChannelBinding
        /// </summary>
        /// <returns></returns>
        public TicketProcess ChannelBinding() {
            return Named(ProcessType.ChannelBinding);
        }

        /// <summary>
        /// CoilBinding
        /// </summary>
        /// <returns></returns>
        public TicketProcess CoilBinding() {
            return Named(ProcessType.CoilBinding);
        }

        /// <summary>
        /// Collecting
        /// </summary>
        /// <returns></returns>
        public TicketProcess Collecting() {
            return Named(ProcessType.Collecting);
        }

        /// <summary>
        /// ColorCorrection
        /// </summary>
        /// <returns></returns>
        public TicketProcess ColorCorrection() {
            return Named(ProcessType.ColorCorrection);
        }

        /// <summary>
        /// ColorSpaceConversion
        /// </summary>
        /// <returns></returns>
        public TicketProcess ColorSpaceConversion() {
            return Named(ProcessType.ColorSpaceConversion);
        }

        /// <summary>
        /// Combine
        /// </summary>
        /// <returns></returns>
        public TicketProcess Combine() {
            return Named(ProcessType.Combine);
        }

        /// <summary>
        /// Combined
        /// </summary>
        /// <returns></returns>
        public TicketProcess Combined() {
            return Named(ProcessType.Combined);
        }

        /// <summary>
        /// ContactCopying
        /// </summary>
        /// <returns></returns>
        public TicketProcess ContactCopying() {
            return Named(ProcessType.ContactCopying);
        }

        /// <summary>
        /// ContoneCalibration
        /// </summary>
        /// <returns></returns>
        public TicketProcess ContoneCalibration() {
            return Named(ProcessType.ContoneCalibration);
        }

        /// <summary>
        /// ConventionalPrinting
        /// </summary>
        /// <returns></returns>
        public TicketProcess ConventionalPrinting() {
            return Named(ProcessType.ConventionalPrinting);
        }

        /// <summary>
        /// CoverApplication
        /// </summary>
        /// <returns></returns>
        public TicketProcess CoverApplication() {
            return Named(ProcessType.CoverApplication);
        }

        /// <summary>
        /// Creasing
        /// </summary>
        /// <returns></returns>
        public TicketProcess Creasing() {
            return Named(ProcessType.Creasing);
        }

        /// <summary>
        /// Cutting
        /// </summary>
        /// <returns></returns>
        public TicketProcess Cutting() {
            return Named(ProcessType.Cutting);
        }

        /// <summary>
        /// CylinderLayoutPreparation
        /// </summary>
        /// <returns></returns>
        public TicketProcess CylinderLayoutPreparation() {
            return Named(ProcessType.CylinderLayoutPreparation);
        }

        /// <summary>
        /// DBDocTemplateLayout
        /// </summary>
        /// <returns></returns>
        public TicketProcess DBDocTemplateLayout() {
            return Named(ProcessType.DBDocTemplateLayout);
        }

        /// <summary>
        /// DBTemplateMerging
        /// </summary>
        /// <returns></returns>
        public TicketProcess DBTemplateMerging() {
            return Named(ProcessType.DBTemplateMerging);
        }

        /// <summary>
        /// Delivery
        /// </summary>
        /// <returns></returns>
        public TicketProcess Delivery() {
            return Named(ProcessType.Delivery);
        }

        /// <summary>
        /// DieDesign
        /// </summary>
        /// <returns></returns>
        public TicketProcess DieDesign() {
            return Named(ProcessType.DieDesign);
        }

        /// <summary>
        /// DieLayoutProduction
        /// </summary>
        /// <returns></returns>
        public TicketProcess DieLayoutProduction() {
            return Named(ProcessType.DieLayoutProduction);
        }

        /// <summary>
        /// DieMaking
        /// </summary>
        /// <returns></returns>
        public TicketProcess DieMaking() {
            return Named(ProcessType.DieMaking);
        }

        /// <summary>
        /// DigitalDelivery
        /// </summary>
        /// <returns></returns>
        public TicketProcess DigitalDelivery() {
            return Named(ProcessType.DigitalDelivery);
        }

        /// <summary>
        /// DigitalPrinting
        /// </summary>
        /// <returns></returns>
        public TicketProcess DigitalPrinting() {
            return Named(ProcessType.DigitalPrinting);
        }

        /// <summary>
        /// Dividing
        /// </summary>
        /// <returns></returns>
        public TicketProcess Dividing() {
            return Named(ProcessType.Dividing);
        }

        /// <summary>
        /// Embossing
        /// </summary>
        /// <returns></returns>
        public TicketProcess Embossing() {
            return Named(ProcessType.Embossing);
        }

        /// <summary>
        /// EndSheetGluing
        /// </summary>
        /// <returns></returns>
        public TicketProcess EndSheetGluing() {
            return Named(ProcessType.EndSheetGluing);
        }

        /// <summary>
        /// Feeding
        /// </summary>
        /// <returns></returns>
        public TicketProcess Feeding() {
            return Named(ProcessType.Feeding);
        }

        /// <summary>
        /// FilmToPlateCopying
        /// </summary>
        /// <returns></returns>
        public TicketProcess FilmToPlateCopying() {
            return Named(ProcessType.FilmToPlateCopying);
        }

        /// <summary>
        /// Folding
        /// </summary>
        /// <returns></returns>
        public TicketProcess Folding() {
            return Named(ProcessType.Folding);
        }

        /// <summary>
        /// FormatConversion
        /// </summary>
        /// <returns></returns>
        public TicketProcess FormatConversion() {
            return Named(ProcessType.FormatConversion);
        }

        /// <summary>
        /// Gathering
        /// </summary>
        /// <returns></returns>
        public TicketProcess Gathering() {
            return Named(ProcessType.Gathering);
        }

        /// <summary>
        /// Gluing
        /// </summary>
        /// <returns></returns>
        public TicketProcess Gluing() {
            return Named(ProcessType.Gluing);
        }

        /// <summary>
        /// HeadBandApplication
        /// </summary>
        /// <returns></returns>
        public TicketProcess HeadBandApplication() {
            return Named(ProcessType.HeadBandApplication);
        }

        /// <summary>
        /// HoleMaking
        /// </summary>
        /// <returns></returns>
        public TicketProcess HoleMaking() {
            return Named(ProcessType.HoleMaking);
        }

        /// <summary>
        /// IDPrinting
        /// </summary>
        /// <returns></returns>
        public TicketProcess IDPrinting() {
            return Named(ProcessType.IDPrinting);
        }

        /// <summary>
        /// ImageReplacement
        /// </summary>
        /// <returns></returns>
        public TicketProcess ImageReplacement() {
            return Named(ProcessType.ImageReplacement);
        }

        /// <summary>
        /// ImageSetting
        /// </summary>
        /// <returns></returns>
        public TicketProcess ImageSetting() {
            return Named(ProcessType.ImageSetting);
        }

        /// <summary>
        /// Imposition
        /// </summary>
        /// <returns></returns>
        public TicketProcess Imposition() {
            return Named(ProcessType.Imposition);
        }

        /// <summary>
        /// InkZoneCalculation
        /// </summary>
        /// <returns></returns>
        public TicketProcess InkZoneCalculation() {
            return Named(ProcessType.InkZoneCalculation);
        }

        /// <summary>
        /// Inserting
        /// </summary>
        /// <returns></returns>
        public TicketProcess Inserting() {
            return Named(ProcessType.Inserting);
        }

        /// <summary>
        /// Interpreting
        /// </summary>
        /// <returns></returns>
        public TicketProcess Interpreting() {
            return Named(ProcessType.Interpreting);
        }

        /// <summary>
        /// Jacketing
        /// </summary>
        /// <returns></returns>
        public TicketProcess Jacketing() {
            return Named(ProcessType.Jacketing);
        }

        /// <summary>
        /// Labeling
        /// </summary>
        /// <returns></returns>
        public TicketProcess Labeling() {
            return Named(ProcessType.Labeling);
        }

        /// <summary>
        /// Laminating
        /// </summary>
        /// <returns></returns>
        public TicketProcess Laminating() {
            return Named(ProcessType.Laminating);
        }

        /// <summary>
        /// LayoutElementProduction
        /// </summary>
        /// <returns></returns>
        public TicketProcess LayoutElementProduction() {
            return Named(ProcessType.LayoutElementProduction);
        }

        /// <summary>
        /// LayoutPreparation
        /// </summary>
        /// <returns></returns>
        public TicketProcess LayoutPreparation() {
            return Named(ProcessType.LayoutPreparation);
        }

        /// <summary>
        /// LayoutShifting
        /// </summary>
        /// <returns></returns>
        public TicketProcess LayoutShifting() {
            return Named(ProcessType.LayoutShifting);
        }

        /// <summary>
        /// LongitudinalRibbonOperations
        /// </summary>
        /// <returns></returns>
        public TicketProcess LongitudinalRibbonOperations() {
            return Named(ProcessType.LongitudinalRibbonOperations);
        }

        /// <summary>
        /// ManualLabor
        /// </summary>
        /// <returns></returns>
        public TicketProcess ManualLabor() {
            return Named(ProcessType.ManualLabor);
        }

        /// <summary>
        /// Numbering
        /// </summary>
        /// <returns></returns>
        public TicketProcess Numbering() {
            return Named(ProcessType.Numbering);
        }

        /// <summary>
        /// Ordering
        /// </summary>
        /// <returns></returns>
        public TicketProcess Ordering() {
            return Named(ProcessType.Ordering);
        }

        /// <summary>
        /// Packing
        /// </summary>
        /// <returns></returns>
        public TicketProcess Packing() {
            return Named(ProcessType.Packing);
        }

        /// <summary>
        /// PageAssigning
        /// </summary>
        /// <returns></returns>
        public TicketProcess PageAssigning() {
            return Named(ProcessType.PageAssigning);
        }

        /// <summary>
        /// Palletizing
        /// </summary>
        /// <returns></returns>
        public TicketProcess Palletizing() {
            return Named(ProcessType.Palletizing);
        }

        /// <summary>
        /// PDFToPSConversion
        /// </summary>
        /// <returns></returns>
        public TicketProcess PDFToPSConversion() {
            return Named(ProcessType.PDFToPSConversion);
        }

        /// <summary>
        /// PDLCreation
        /// </summary>
        /// <returns></returns>
        public TicketProcess PDLCreation() {
            return Named(ProcessType.PDLCreation);
        }

        /// <summary>
        /// Perforating
        /// </summary>
        /// <returns></returns>
        public TicketProcess Perforating() {
            return Named(ProcessType.Perforating);
        }

        /// <summary>
        /// PlasticCombBinding
        /// </summary>
        /// <returns></returns>
        public TicketProcess PlasticCombBinding() {
            return Named(ProcessType.PlasticCombBinding);
        }

        /// <summary>
        /// Preflight
        /// </summary>
        /// <returns></returns>
        public TicketProcess Preflight() {
            return Named(ProcessType.Preflight);
        }

        /// <summary>
        /// PreviewGeneration
        /// </summary>
        /// <returns></returns>
        public TicketProcess PreviewGeneration() {
            return Named(ProcessType.PreviewGeneration);
        }

        /// <summary>
        /// PrintRolling
        /// </summary>
        /// <returns></returns>
        public TicketProcess PrintRolling() {
            return Named(ProcessType.PrintRolling);
        }

        /// <summary>
        /// ProcessGroup
        /// </summary>
        /// <returns></returns>
        public TicketProcess ProcessGroup() {
            return Named(ProcessType.ProcessGroup);
        }

        /// <summary>
        /// Product
        /// </summary>
        /// <returns></returns>
        public TicketProcess Product() {
            return Named(ProcessType.Product);
        }

        /// <summary>
        /// Proofing
        /// </summary>
        /// <returns></returns>
        public TicketProcess Proofing() {
            return Named(ProcessType.Proofing);
        }

        /// <summary>
        /// PSToPDFConversion
        /// </summary>
        /// <returns></returns>
        public TicketProcess PSToPDFConversion() {
            return Named(ProcessType.PSToPDFConversion);
        }

        /// <summary>
        /// QualityControl
        /// </summary>
        /// <returns></returns>
        public TicketProcess QualityControl() {
            return Named(ProcessType.QualityControl);
        }

        /// <summary>
        /// RasterReading
        /// </summary>
        /// <returns></returns>
        public TicketProcess RasterReading() {
            return Named(ProcessType.RasterReading);
        }

        /// <summary>
        /// Rendering
        /// </summary>
        /// <returns></returns>
        public TicketProcess Rendering() {
            return Named(ProcessType.Rendering);
        }

        /// <summary>
        /// ResourceDefinition
        /// </summary>
        /// <returns></returns>
        public TicketProcess ResourceDefinition() {
            return Named(ProcessType.ResourceDefinition);
        }

        /// <summary>
        /// RingBinding
        /// </summary>
        /// <returns></returns>
        public TicketProcess RingBinding() {
            return Named(ProcessType.RingBinding);
        }

        /// <summary>
        /// SaddleStitching
        /// </summary>
        /// <returns></returns>
        public TicketProcess SaddleStitching() {
            return Named(ProcessType.SaddleStitching);
        }

        /// <summary>
        /// Scanning
        /// </summary>
        /// <returns></returns>
        public TicketProcess Scanning() {
            return Named(ProcessType.Scanning);
        }

        /// <summary>
        /// Screening
        /// </summary>
        /// <returns></returns>
        public TicketProcess Screening() {
            return Named(ProcessType.Screening);
        }

        /// <summary>
        /// Separation
        /// </summary>
        /// <returns></returns>
        public TicketProcess Separation() {
            return Named(ProcessType.Separation);
        }

        /// <summary>
        /// ShapeCutting
        /// </summary>
        /// <returns></returns>
        public TicketProcess ShapeCutting() {
            return Named(ProcessType.ShapeCutting);
        }

        /// <summary>
        /// ShapeDefProduction
        /// </summary>
        /// <returns></returns>
        public TicketProcess ShapeDefProduction() {
            return Named(ProcessType.ShapeDefProduction);
        }

        /// <summary>
        /// Shrinking
        /// </summary>
        /// <returns></returns>
        public TicketProcess Shrinking() {
            return Named(ProcessType.Shrinking);
        }

        /// <summary>
        /// SideSewing
        /// </summary>
        /// <returns></returns>
        public TicketProcess SideSewing() {
            return Named(ProcessType.SideSewing);
        }

        /// <summary>
        /// SoftProofing
        /// </summary>
        /// <returns></returns>
        public TicketProcess SoftProofing() {
            return Named(ProcessType.SoftProofing);
        }

        /// <summary>
        /// SpinePreparation
        /// </summary>
        /// <returns></returns>
        public TicketProcess SpinePreparation() {
            return Named(ProcessType.SpinePreparation);
        }

        /// <summary>
        /// SpineTaping
        /// </summary>
        /// <returns></returns>
        public TicketProcess SpineTaping() {
            return Named(ProcessType.SpineTaping);
        }

        /// <summary>
        /// Split
        /// </summary>
        /// <returns></returns>
        public TicketProcess Split() {
            return Named(ProcessType.Split);
        }

        /// <summary>
        /// Stacking
        /// </summary>
        /// <returns></returns>
        public TicketProcess Stacking() {
            return Named(ProcessType.Stacking);
        }

        /// <summary>
        /// StaticBlocking
        /// </summary>
        /// <returns></returns>
        public TicketProcess StaticBlocking() {
            return Named(ProcessType.StaticBlocking);
        }

        /// <summary>
        /// Stitching
        /// </summary>
        /// <returns></returns>
        public TicketProcess Stitching() {
            return Named(ProcessType.Stitching);
        }

        /// <summary>
        /// Strapping
        /// </summary>
        /// <returns></returns>
        public TicketProcess Strapping() {
            return Named(ProcessType.Strapping);
        }

        /// <summary>
        /// StripBinding
        /// </summary>
        /// <returns></returns>
        public TicketProcess StripBinding() {
            return Named(ProcessType.StripBinding);
        }

        /// <summary>
        /// Stripping
        /// </summary>
        /// <returns></returns>
        public TicketProcess Stripping() {
            return Named(ProcessType.Stripping);
        }

        /// <summary>
        /// ThreadSealing
        /// </summary>
        /// <returns></returns>
        public TicketProcess ThreadSealing() {
            return Named(ProcessType.ThreadSealing);
        }

        /// <summary>
        /// ThreadSewing
        /// </summary>
        /// <returns></returns>
        public TicketProcess ThreadSewing() {
            return Named(ProcessType.ThreadSewing);
        }

        /// <summary>
        /// Tiling
        /// </summary>
        /// <returns></returns>
        public TicketProcess Tiling() {
            return Named(ProcessType.Tiling);
        }

        /// <summary>
        /// Trapping
        /// </summary>
        /// <returns></returns>
        public TicketProcess Trapping() {
            return Named(ProcessType.Trapping);
        }

        /// <summary>
        /// Trimming
        /// </summary>
        /// <returns></returns>
        public TicketProcess Trimming() {
            return Named(ProcessType.Trimming);
        }

        /// <summary>
        /// Varnishing
        /// </summary>
        /// <returns></returns>
        public TicketProcess Varnishing() {
            return Named(ProcessType.Varnishing);
        }

        /// <summary>
        /// Verification
        /// </summary>
        /// <returns></returns>
        public TicketProcess Verification() {
            return Named(ProcessType.Verification);
        }

        /// <summary>
        /// WebInlineFinishing
        /// </summary>
        /// <returns></returns>
        public TicketProcess WebInlineFinishing() {
            return Named(ProcessType.WebInlineFinishing);
        }

        /// <summary>
        /// WireCombBinding
        /// </summary>
        /// <returns></returns>
        public TicketProcess WireCombBinding() {
            return Named(ProcessType.WireCombBinding);
        }

        /// <summary>
        /// Wrapping
        /// </summary>
        /// <returns></returns>
        public TicketProcess Wrapping() {
            return Named(ProcessType.Wrapping);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class TicketGetProcess {

        Ticket _ticket;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ticket"></param>
        public TicketGetProcess(Ticket ticket) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            _ticket = ticket;
        }

        //ProcessType.Bending.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TicketProcess Named(XName name) {
            ParameterCheck.ParameterRequired(name, "name");
            var processElements = _ticket.GetJdfNodesContainingProcessType(name.LocalName);

            return new TicketProcess(_ticket, processElements);
        }

    }

    //Ticket.GetProcess().Bending().WithInput().RunList() This gets the first run list resource that is an input of the first bending.

    /// <summary>
    /// 
    /// </summary>
    public class TicketProcess {

        Ticket _ticket;
        IEnumerable<XElement> _elements;

        /// <summary>
        /// The element
        /// </summary>
        public IEnumerable<XElement> Elements {
            get {
                return _elements;
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="elements"></param>
        public TicketProcess(Ticket ticket, IEnumerable<XElement> elements) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            ParameterCheck.ParameterRequired(elements, "elements");
            _ticket = ticket;
            _elements = elements;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TicketResouces WithInput() {
            return new TicketResouces(_ticket, Elements.GetCurrentJDFResourceLinkPoolResolvedItemForUsage(ResourceUsage.Input), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public TicketResouces WithInput(XName resourceName) {
            return new TicketResouces(_ticket, WithReducer(Elements, resourceName, ResourceUsage.Input), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TicketResouces WithOutput() {
            return new TicketResouces(_ticket, Elements.GetCurrentJDFResourceLinkPoolResolvedItemForUsage(ResourceUsage.Output), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public TicketResouces WithOutput(XName resourceName) {
            return new TicketResouces(_ticket, WithReducer(Elements, resourceName, ResourceUsage.Output), false);
        }

        private static IEnumerable<XElement> WithReducer(IEnumerable<XElement> elements, XName resourceName, ResourceUsage usage) {
            return elements.GetCurrentJDFResourceLinkPoolResolvedItemForUsage(usage).Where(item => {
                var ns = resourceName.NamespaceName;

                if (string.IsNullOrWhiteSpace(ns)) {
                    ns = Globals.JdfNamespace.NamespaceName;
                }

                return item.Name != null && item.Name.LocalName == resourceName.LocalName && item.Name.NamespaceName == ns;

            });
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class TicketResouces {

        /// <summary>
        /// Address
        /// </summary>
        /// <returns></returns>
        public TicketResouces Address() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Address, _child), true);
        }

        /// <summary>
        /// AdhesiveBindingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces AdhesiveBindingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.AdhesiveBindingParams, _child), true);
        }

        /// <summary>
        /// ApprovalParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ApprovalParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ApprovalParams, _child), true);
        }

        /// <summary>
        /// ApprovalSuccess
        /// </summary>
        /// <returns></returns>
        public TicketResouces ApprovalSuccess() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ApprovalSuccess, _child), true);
        }

        /// <summary>
        /// ArtDeliveryIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces ArtDeliveryIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ArtDeliveryIntent, _child), true);
        }

        /// <summary>
        /// Assembly
        /// </summary>
        /// <returns></returns>
        public TicketResouces Assembly() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Assembly, _child), true);
        }

        /// <summary>
        /// AssetListCreationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces AssetListCreationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.AssetListCreationParams, _child), true);
        }

        /// <summary>
        /// AutomatedOverPrintParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces AutomatedOverPrintParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.AutomatedOverPrintParams, _child), true);
        }

        /// <summary>
        /// BarcodeCompParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces BarcodeCompParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BarcodeCompParams, _child), true);
        }

        /// <summary>
        /// BarcodeReproParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces BarcodeReproParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BarcodeReproParams, _child), true);
        }

        /// <summary>
        /// BendingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces BendingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BendingParams, _child), true);
        }

        /// <summary>
        /// BinderySignature
        /// </summary>
        /// <returns></returns>
        public TicketResouces BinderySignature() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BinderySignature, _child), true);
        }

        /// <summary>
        /// BindingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces BindingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BindingIntent, _child), true);
        }

        /// <summary>
        /// BlockPreparationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces BlockPreparationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BlockPreparationParams, _child), true);
        }

        /// <summary>
        /// BoxFoldingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces BoxFoldingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BoxFoldingParams, _child), true);
        }

        /// <summary>
        /// BoxPackingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces BoxPackingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BoxPackingParams, _child), true);
        }

        /// <summary>
        /// BufferParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces BufferParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BufferParams, _child), true);
        }

        /// <summary>
        /// Bundle
        /// </summary>
        /// <returns></returns>
        public TicketResouces Bundle() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Bundle, _child), true);
        }

        /// <summary>
        /// BundlingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces BundlingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.BundlingParams, _child), true);
        }

        /// <summary>
        /// ByteMap
        /// </summary>
        /// <returns></returns>
        public TicketResouces ByteMap() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ByteMap, _child), true);
        }

        /// <summary>
        /// CaseMakingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces CaseMakingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CaseMakingParams, _child), true);
        }

        /// <summary>
        /// CasingInParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces CasingInParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CasingInParams, _child), true);
        }

        /// <summary>
        /// ChannelBindingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ChannelBindingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ChannelBindingParams, _child), true);
        }

        /// <summary>
        /// CIELABMeasuringField
        /// </summary>
        /// <returns></returns>
        public TicketResouces CIELABMeasuringField() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CIELABMeasuringField, _child), true);
        }

        /// <summary>
        /// CoilBindingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces CoilBindingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CoilBindingParams, _child), true);
        }

        /// <summary>
        /// CollectingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces CollectingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CollectingParams, _child), true);
        }

        /// <summary>
        /// Color
        /// </summary>
        /// <returns></returns>
        public TicketResouces Color() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Color, _child), true);
        }

        /// <summary>
        /// ColorantAlias
        /// </summary>
        /// <returns></returns>
        public TicketResouces ColorantAlias() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ColorantAlias, _child), true);
        }

        /// <summary>
        /// ColorantControl
        /// </summary>
        /// <returns></returns>
        public TicketResouces ColorantControl() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ColorantControl, _child), true);
        }

        /// <summary>
        /// ColorControlStrip
        /// </summary>
        /// <returns></returns>
        public TicketResouces ColorControlStrip() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ColorControlStrip, _child), true);
        }

        /// <summary>
        /// ColorCorrectionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ColorCorrectionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ColorCorrectionParams, _child), true);
        }

        /// <summary>
        /// ColorIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces ColorIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ColorIntent, _child), true);
        }

        /// <summary>
        /// ColorMeasurementConditions
        /// </summary>
        /// <returns></returns>
        public TicketResouces ColorMeasurementConditions() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ColorMeasurementConditions, _child), true);
        }

        /// <summary>
        /// ColorPool
        /// </summary>
        /// <returns></returns>
        public TicketResouces ColorPool() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ColorPool, _child), true);
        }

        /// <summary>
        /// ColorSpaceConversionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ColorSpaceConversionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ColorSpaceConversionParams, _child), true);
        }

        /// <summary>
        /// ComChannel
        /// </summary>
        /// <returns></returns>
        public TicketResouces ComChannel() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ComChannel, _child), true);
        }

        /// <summary>
        /// Company
        /// </summary>
        /// <returns></returns>
        public TicketResouces Company() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Company, _child), true);
        }

        /// <summary>
        /// Component
        /// </summary>
        /// <returns></returns>
        public TicketResouces Component() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Component, _child), true);
        }

        /// <summary>
        /// Contact
        /// </summary>
        /// <returns></returns>
        public TicketResouces Contact() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Contact, _child), true);
        }

        /// <summary>
        /// ContactCopyParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ContactCopyParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ContactCopyParams, _child), true);
        }

        /// <summary>
        /// ContentList
        /// </summary>
        /// <returns></returns>
        public TicketResouces ContentList() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ContentList, _child), true);
        }

        /// <summary>
        /// ConventionalPrintingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ConventionalPrintingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ConventionalPrintingParams, _child), true);
        }

        /// <summary>
        /// CoverApplicationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces CoverApplicationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CoverApplicationParams, _child), true);
        }

        /// <summary>
        /// CreasingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces CreasingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CreasingParams, _child), true);
        }

        /// <summary>
        /// CustomerInfo
        /// </summary>
        /// <returns></returns>
        public TicketResouces CustomerInfo() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CustomerInfo, _child), true);
        }

        /// <summary>
        /// CutBlock
        /// </summary>
        /// <returns></returns>
        public TicketResouces CutBlock() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CutBlock, _child), true);
        }

        /// <summary>
        /// CutMark
        /// </summary>
        /// <returns></returns>
        public TicketResouces CutMark() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CutMark, _child), true);
        }

        /// <summary>
        /// CuttingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces CuttingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CuttingParams, _child), true);
        }

        /// <summary>
        /// CylinderLayout
        /// </summary>
        /// <returns></returns>
        public TicketResouces CylinderLayout() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CylinderLayout, _child), true);
        }

        /// <summary>
        /// CylinderLayoutPreparationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces CylinderLayoutPreparationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.CylinderLayoutPreparationParams, _child), true);
        }

        /// <summary>
        /// DBMergeParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces DBMergeParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DBMergeParams, _child), true);
        }

        /// <summary>
        /// DBRules
        /// </summary>
        /// <returns></returns>
        public TicketResouces DBRules() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DBRules, _child), true);
        }

        /// <summary>
        /// DBSchema
        /// </summary>
        /// <returns></returns>
        public TicketResouces DBSchema() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DBSchema, _child), true);
        }

        /// <summary>
        /// DBSelection
        /// </summary>
        /// <returns></returns>
        public TicketResouces DBSelection() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DBSelection, _child), true);
        }

        /// <summary>
        /// DeliveryIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces DeliveryIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DeliveryIntent, _child), true);
        }

        /// <summary>
        /// DeliveryParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces DeliveryParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DeliveryParams, _child), true);
        }

        /// <summary>
        /// DensityMeasuringField
        /// </summary>
        /// <returns></returns>
        public TicketResouces DensityMeasuringField() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DensityMeasuringField, _child), true);
        }

        /// <summary>
        /// DevelopingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces DevelopingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DevelopingParams, _child), true);
        }

        /// <summary>
        /// Device
        /// </summary>
        /// <returns></returns>
        public TicketResouces Device() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Device, _child), true);
        }

        /// <summary>
        /// DeviceMark
        /// </summary>
        /// <returns></returns>
        public TicketResouces DeviceMark() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DeviceMark, _child), true);
        }

        /// <summary>
        /// DeviceNSpace
        /// </summary>
        /// <returns></returns>
        public TicketResouces DeviceNSpace() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DeviceNSpace, _child), true);
        }

        /// <summary>
        /// DieLayout
        /// </summary>
        /// <returns></returns>
        public TicketResouces DieLayout() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DieLayout, _child), true);
        }

        /// <summary>
        /// DieLayoutProductionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces DieLayoutProductionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DieLayoutProductionParams, _child), true);
        }

        /// <summary>
        /// DigitalDeliveryParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces DigitalDeliveryParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DigitalDeliveryParams, _child), true);
        }

        /// <summary>
        /// DigitalMedia
        /// </summary>
        /// <returns></returns>
        public TicketResouces DigitalMedia() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DigitalMedia, _child), true);
        }

        /// <summary>
        /// DigitalPrintingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces DigitalPrintingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DigitalPrintingParams, _child), true);
        }

        /// <summary>
        /// DividingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces DividingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.DividingParams, _child), true);
        }

        /// <summary>
        /// ElementColorParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ElementColorParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ElementColorParams, _child), true);
        }

        /// <summary>
        /// EmbossingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces EmbossingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.EmbossingIntent, _child), true);
        }

        /// <summary>
        /// EmbossingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces EmbossingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.EmbossingParams, _child), true);
        }

        /// <summary>
        /// Employee
        /// </summary>
        /// <returns></returns>
        public TicketResouces Employee() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Employee, _child), true);
        }

        /// <summary>
        /// EndSheetGluingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces EndSheetGluingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.EndSheetGluingParams, _child), true);
        }

        /// <summary>
        /// ExposedMedia
        /// </summary>
        /// <returns></returns>
        public TicketResouces ExposedMedia() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ExposedMedia, _child), true);
        }

        /// <summary>
        /// ExternalImpositionTemplate
        /// </summary>
        /// <returns></returns>
        public TicketResouces ExternalImpositionTemplate() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ExternalImpositionTemplate, _child), true);
        }

        /// <summary>
        /// FeedingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces FeedingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.FeedingParams, _child), true);
        }

        /// <summary>
        /// FileSpec
        /// </summary>
        /// <returns></returns>
        public TicketResouces FileSpec() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.FileSpec, _child), true);
        }

        /// <summary>
        /// FitPolicy
        /// </summary>
        /// <returns></returns>
        public TicketResouces FitPolicy() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.FitPolicy, _child), true);
        }

        /// <summary>
        /// Fold
        /// </summary>
        /// <returns></returns>
        public TicketResouces Fold() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Fold, _child), true);
        }

        /// <summary>
        /// FoldingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces FoldingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.FoldingIntent, _child), true);
        }

        /// <summary>
        /// FoldingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces FoldingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.FoldingParams, _child), true);
        }

        /// <summary>
        /// FontParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces FontParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.FontParams, _child), true);
        }

        /// <summary>
        /// FontPolicy
        /// </summary>
        /// <returns></returns>
        public TicketResouces FontPolicy() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.FontPolicy, _child), true);
        }

        /// <summary>
        /// FormatConversionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces FormatConversionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.FormatConversionParams, _child), true);
        }

        /// <summary>
        /// GatheringParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces GatheringParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.GatheringParams, _child), true);
        }

        /// <summary>
        /// GlueApplication
        /// </summary>
        /// <returns></returns>
        public TicketResouces GlueApplication() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.GlueApplication, _child), true);
        }

        /// <summary>
        /// GlueLine
        /// </summary>
        /// <returns></returns>
        public TicketResouces GlueLine() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.GlueLine, _child), true);
        }

        /// <summary>
        /// GluingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces GluingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.GluingParams, _child), true);
        }

        /// <summary>
        /// HeadBandApplicationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces HeadBandApplicationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.HeadBandApplicationParams, _child), true);
        }

        /// <summary>
        /// Hole
        /// </summary>
        /// <returns></returns>
        public TicketResouces Hole() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Hole, _child), true);
        }

        /// <summary>
        /// HoleLine
        /// </summary>
        /// <returns></returns>
        public TicketResouces HoleLine() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.HoleLine, _child), true);
        }

        /// <summary>
        /// HoleMakingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces HoleMakingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.HoleMakingIntent, _child), true);
        }

        /// <summary>
        /// HoleMakingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces HoleMakingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.HoleMakingParams, _child), true);
        }

        /// <summary>
        /// IdentificationField
        /// </summary>
        /// <returns></returns>
        public TicketResouces IdentificationField() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.IdentificationField, _child), true);
        }

        /// <summary>
        /// IDPrintingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces IDPrintingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.IDPrintingParams, _child), true);
        }

        /// <summary>
        /// ImageCompressionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ImageCompressionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ImageCompressionParams, _child), true);
        }

        /// <summary>
        /// ImageReplacementParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ImageReplacementParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ImageReplacementParams, _child), true);
        }

        /// <summary>
        /// ImageSetterParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ImageSetterParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ImageSetterParams, _child), true);
        }

        /// <summary>
        /// Ink
        /// </summary>
        /// <returns></returns>
        public TicketResouces Ink() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Ink, _child), true);
        }

        /// <summary>
        /// InkZoneCalculationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces InkZoneCalculationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.InkZoneCalculationParams, _child), true);
        }

        /// <summary>
        /// InkZoneProfile
        /// </summary>
        /// <returns></returns>
        public TicketResouces InkZoneProfile() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.InkZoneProfile, _child), true);
        }

        /// <summary>
        /// InsertingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces InsertingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.InsertingIntent, _child), true);
        }

        /// <summary>
        /// InsertingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces InsertingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.InsertingParams, _child), true);
        }

        /// <summary>
        /// InsertSheet
        /// </summary>
        /// <returns></returns>
        public TicketResouces InsertSheet() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.InsertSheet, _child), true);
        }

        /// <summary>
        /// InterpretedPDLData
        /// </summary>
        /// <returns></returns>
        public TicketResouces InterpretedPDLData() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.InterpretedPDLData, _child), true);
        }

        /// <summary>
        /// InterpretingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces InterpretingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.InterpretingParams, _child), true);
        }

        /// <summary>
        /// JacketingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces JacketingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.JacketingParams, _child), true);
        }

        /// <summary>
        /// JobField
        /// </summary>
        /// <returns></returns>
        public TicketResouces JobField() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.JobField, _child), true);
        }

        /// <summary>
        /// LabelingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces LabelingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.LabelingParams, _child), true);
        }

        /// <summary>
        /// LaminatingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces LaminatingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.LaminatingIntent, _child), true);
        }

        /// <summary>
        /// LaminatingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces LaminatingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.LaminatingParams, _child), true);
        }

        /// <summary>
        /// Layout
        /// </summary>
        /// <returns></returns>
        public TicketResouces Layout() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Layout, _child), true);
        }

        /// <summary>
        /// LayoutElement
        /// </summary>
        /// <returns></returns>
        public TicketResouces LayoutElement() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.LayoutElement, _child), true);
        }

        /// <summary>
        /// LayoutElementProductionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces LayoutElementProductionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.LayoutElementProductionParams, _child), true);
        }

        /// <summary>
        /// LayoutIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces LayoutIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.LayoutIntent, _child), true);
        }

        /// <summary>
        /// LayoutPreparationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces LayoutPreparationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.LayoutPreparationParams, _child), true);
        }

        /// <summary>
        /// LayoutShift
        /// </summary>
        /// <returns></returns>
        public TicketResouces LayoutShift() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.LayoutShift, _child), true);
        }

        /// <summary>
        /// LongitudinalRibbonOperationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces LongitudinalRibbonOperationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.LongitudinalRibbonOperationParams, _child), true);
        }

        /// <summary>
        /// ManualLaborParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ManualLaborParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ManualLaborParams, _child), true);
        }

        /// <summary>
        /// Media
        /// </summary>
        /// <returns></returns>
        public TicketResouces Media() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Media, _child), true);
        }

        /// <summary>
        /// MediaIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces MediaIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.MediaIntent, _child), true);
        }

        /// <summary>
        /// MediaSource
        /// </summary>
        /// <returns></returns>
        public TicketResouces MediaSource() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.MediaSource, _child), true);
        }

        /// <summary>
        /// MiscConsumable
        /// </summary>
        /// <returns></returns>
        public TicketResouces MiscConsumable() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.MiscConsumable, _child), true);
        }

        /// <summary>
        /// NodeInfo
        /// </summary>
        /// <returns></returns>
        public TicketResouces NodeInfo() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.NodeInfo, _child), true);
        }

        /// <summary>
        /// NumberingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces NumberingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.NumberingIntent, _child), true);
        }

        /// <summary>
        /// NumberingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces NumberingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.NumberingParams, _child), true);
        }

        /// <summary>
        /// ObjectResolution
        /// </summary>
        /// <returns></returns>
        public TicketResouces ObjectResolution() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ObjectResolution, _child), true);
        }

        /// <summary>
        /// OrderingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces OrderingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.OrderingParams, _child), true);
        }

        /// <summary>
        /// PackingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces PackingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PackingIntent, _child), true);
        }

        /// <summary>
        /// PackingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PackingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PackingParams, _child), true);
        }

        /// <summary>
        /// PageAssignParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PageAssignParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PageAssignParams, _child), true);
        }

        /// <summary>
        /// PageList
        /// </summary>
        /// <returns></returns>
        public TicketResouces PageList() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PageList, _child), true);
        }

        /// <summary>
        /// Pallet
        /// </summary>
        /// <returns></returns>
        public TicketResouces Pallet() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Pallet, _child), true);
        }

        /// <summary>
        /// PalletizingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PalletizingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PalletizingParams, _child), true);
        }

        /// <summary>
        /// PDFToPSConversionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PDFToPSConversionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PDFToPSConversionParams, _child), true);
        }

        /// <summary>
        /// PDLCreationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PDLCreationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PDLCreationParams, _child), true);
        }

        /// <summary>
        /// PDLResourceAlias
        /// </summary>
        /// <returns></returns>
        public TicketResouces PDLResourceAlias() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PDLResourceAlias, _child), true);
        }

        /// <summary>
        /// PerforatingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PerforatingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PerforatingParams, _child), true);
        }

        /// <summary>
        /// Person
        /// </summary>
        /// <returns></returns>
        public TicketResouces Person() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Person, _child), true);
        }

        /// <summary>
        /// PlaceHolderResource
        /// </summary>
        /// <returns></returns>
        public TicketResouces PlaceHolderResource() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PlaceHolderResource, _child), true);
        }

        /// <summary>
        /// PlasticCombBindingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PlasticCombBindingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PlasticCombBindingParams, _child), true);
        }

        /// <summary>
        /// PlateCopyParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PlateCopyParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PlateCopyParams, _child), true);
        }

        /// <summary>
        /// PreflightAnalysis
        /// </summary>
        /// <returns></returns>
        public TicketResouces PreflightAnalysis() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PreflightAnalysis, _child), true);
        }

        /// <summary>
        /// PreflightInventory
        /// </summary>
        /// <returns></returns>
        public TicketResouces PreflightInventory() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PreflightInventory, _child), true);
        }

        /// <summary>
        /// PreflightParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PreflightParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PreflightParams, _child), true);
        }

        /// <summary>
        /// PreflightProfile
        /// </summary>
        /// <returns></returns>
        public TicketResouces PreflightProfile() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PreflightProfile, _child), true);
        }

        /// <summary>
        /// PreflightReport
        /// </summary>
        /// <returns></returns>
        public TicketResouces PreflightReport() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PreflightReport, _child), true);
        }

        /// <summary>
        /// PreflightReportRulePool
        /// </summary>
        /// <returns></returns>
        public TicketResouces PreflightReportRulePool() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PreflightReportRulePool, _child), true);
        }

        /// <summary>
        /// PreviewGenerationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PreviewGenerationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PreviewGenerationParams, _child), true);
        }

        /// <summary>
        /// PrintCondition
        /// </summary>
        /// <returns></returns>
        public TicketResouces PrintCondition() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PrintCondition, _child), true);
        }

        /// <summary>
        /// PrintRollingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PrintRollingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PrintRollingParams, _child), true);
        }

        /// <summary>
        /// ProductionIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces ProductionIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ProductionIntent, _child), true);
        }

        /// <summary>
        /// ProductionPath
        /// </summary>
        /// <returns></returns>
        public TicketResouces ProductionPath() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ProductionPath, _child), true);
        }

        /// <summary>
        /// ProofingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces ProofingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ProofingIntent, _child), true);
        }

        /// <summary>
        /// ProofingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ProofingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ProofingParams, _child), true);
        }

        /// <summary>
        /// PSToPDFConversionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces PSToPDFConversionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PSToPDFConversionParams, _child), true);
        }

        /// <summary>
        /// PublishingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces PublishingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.PublishingIntent, _child), true);
        }

        /// <summary>
        /// QualityControlParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces QualityControlParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.QualityControlParams, _child), true);
        }

        /// <summary>
        /// QualityControlResult
        /// </summary>
        /// <returns></returns>
        public TicketResouces QualityControlResult() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.QualityControlResult, _child), true);
        }

        /// <summary>
        /// RasterReadingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces RasterReadingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.RasterReadingParams, _child), true);
        }

        /// <summary>
        /// RefAnchor
        /// </summary>
        /// <returns></returns>
        public TicketResouces RefAnchor() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.RefAnchor, _child), true);
        }

        /// <summary>
        /// RegisterMark
        /// </summary>
        /// <returns></returns>
        public TicketResouces RegisterMark() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.RegisterMark, _child), true);
        }

        /// <summary>
        /// RegisterRibbon
        /// </summary>
        /// <returns></returns>
        public TicketResouces RegisterRibbon() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.RegisterRibbon, _child), true);
        }

        /// <summary>
        /// RenderingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces RenderingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.RenderingParams, _child), true);
        }

        /// <summary>
        /// ResourceDefinitionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ResourceDefinitionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ResourceDefinitionParams, _child), true);
        }

        /// <summary>
        /// RingBindingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces RingBindingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.RingBindingParams, _child), true);
        }

        /// <summary>
        /// RollStand
        /// </summary>
        /// <returns></returns>
        public TicketResouces RollStand() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.RollStand, _child), true);
        }

        /// <summary>
        /// RunList
        /// </summary>
        /// <returns></returns>
        public TicketResouces RunList() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.RunList, _child), true);
        }

        /// <summary>
        /// SaddleStitchingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces SaddleStitchingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.SaddleStitchingParams, _child), true);
        }

        /// <summary>
        /// ScanParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ScanParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ScanParams, _child), true);
        }

        /// <summary>
        /// ScavengerArea
        /// </summary>
        /// <returns></returns>
        public TicketResouces ScavengerArea() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ScavengerArea, _child), true);
        }

        /// <summary>
        /// ScreeningIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces ScreeningIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ScreeningIntent, _child), true);
        }

        /// <summary>
        /// ScreeningParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ScreeningParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ScreeningParams, _child), true);
        }

        /// <summary>
        /// SeparationControlParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces SeparationControlParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.SeparationControlParams, _child), true);
        }

        /// <summary>
        /// Shape
        /// </summary>
        /// <returns></returns>
        public TicketResouces Shape() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Shape, _child), true);
        }

        /// <summary>
        /// ShapeCuttingIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces ShapeCuttingIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ShapeCuttingIntent, _child), true);
        }

        /// <summary>
        /// ShapeCuttingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ShapeCuttingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ShapeCuttingParams, _child), true);
        }

        /// <summary>
        /// ShapeDef
        /// </summary>
        /// <returns></returns>
        public TicketResouces ShapeDef() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ShapeDef, _child), true);
        }

        /// <summary>
        /// ShapeDefProductionParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ShapeDefProductionParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ShapeDefProductionParams, _child), true);
        }

        /// <summary>
        /// Sheet
        /// </summary>
        /// <returns></returns>
        public TicketResouces Sheet() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Sheet, _child), true);
        }

        /// <summary>
        /// ShrinkingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ShrinkingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ShrinkingParams, _child), true);
        }

        /// <summary>
        /// SideSewingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces SideSewingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.SideSewingParams, _child), true);
        }

        /// <summary>
        /// SizeIntent
        /// </summary>
        /// <returns></returns>
        public TicketResouces SizeIntent() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.SizeIntent, _child), true);
        }

        /// <summary>
        /// SpinePreparationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces SpinePreparationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.SpinePreparationParams, _child), true);
        }

        /// <summary>
        /// SpineTapingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces SpineTapingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.SpineTapingParams, _child), true);
        }

        /// <summary>
        /// StackingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces StackingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.StackingParams, _child), true);
        }

        /// <summary>
        /// StaticBlockingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces StaticBlockingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.StaticBlockingParams, _child), true);
        }

        /// <summary>
        /// StitchingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces StitchingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.StitchingParams, _child), true);
        }

        /// <summary>
        /// Strap
        /// </summary>
        /// <returns></returns>
        public TicketResouces Strap() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Strap, _child), true);
        }

        /// <summary>
        /// StrappingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces StrappingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.StrappingParams, _child), true);
        }

        /// <summary>
        /// StripBindingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces StripBindingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.StripBindingParams, _child), true);
        }

        /// <summary>
        /// StrippingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces StrippingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.StrippingParams, _child), true);
        }

        /// <summary>
        /// Surface
        /// </summary>
        /// <returns></returns>
        public TicketResouces Surface() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Surface, _child), true);
        }

        /// <summary>
        /// ThreadSealingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ThreadSealingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ThreadSealingParams, _child), true);
        }

        /// <summary>
        /// ThreadSewingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces ThreadSewingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.ThreadSewingParams, _child), true);
        }

        /// <summary>
        /// Tile
        /// </summary>
        /// <returns></returns>
        public TicketResouces Tile() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Tile, _child), true);
        }

        /// <summary>
        /// Tool
        /// </summary>
        /// <returns></returns>
        public TicketResouces Tool() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.Tool, _child), true);
        }

        /// <summary>
        /// TransferCurve
        /// </summary>
        /// <returns></returns>
        public TicketResouces TransferCurve() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.TransferCurve, _child), true);
        }

        /// <summary>
        /// TransferCurvePool
        /// </summary>
        /// <returns></returns>
        public TicketResouces TransferCurvePool() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.TransferCurvePool, _child), true);
        }

        /// <summary>
        /// TransferFunctionControl
        /// </summary>
        /// <returns></returns>
        public TicketResouces TransferFunctionControl() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.TransferFunctionControl, _child), true);
        }

        /// <summary>
        /// TrappingDetails
        /// </summary>
        /// <returns></returns>
        public TicketResouces TrappingDetails() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.TrappingDetails, _child), true);
        }

        /// <summary>
        /// TrappingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces TrappingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.TrappingParams, _child), true);
        }

        /// <summary>
        /// TrapRegion
        /// </summary>
        /// <returns></returns>
        public TicketResouces TrapRegion() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.TrapRegion, _child), true);
        }

        /// <summary>
        /// TrimmingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces TrimmingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.TrimmingParams, _child), true);
        }

        /// <summary>
        /// UsageCounter
        /// </summary>
        /// <returns></returns>
        public TicketResouces UsageCounter() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.UsageCounter, _child), true);
        }

        /// <summary>
        /// VarnishingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces VarnishingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.VarnishingParams, _child), true);
        }

        /// <summary>
        /// VerificationParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces VerificationParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.VerificationParams, _child), true);
        }

        /// <summary>
        /// WebInlineFinishingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces WebInlineFinishingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.WebInlineFinishingParams, _child), true);
        }

        /// <summary>
        /// WireCombBindingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces WireCombBindingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.WireCombBindingParams, _child), true);
        }

        /// <summary>
        /// WrappingParams
        /// </summary>
        /// <returns></returns>
        public TicketResouces WrappingParams() {
            return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.WrappingParams, _child), true);
        }


    }

    /// <summary>
    /// 
    /// </summary>
    public partial class TicketResouces {

        Ticket _ticket;
        IEnumerable<XElement> _elements;
        bool _child = false;

        /// <summary>
        /// The element
        /// </summary>
        public IEnumerable<XElement> Elements {
            get {
                return _elements;
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="elements"></param>
        /// <param name="child"></param>
        public TicketResouces(Ticket ticket, IEnumerable<XElement> elements, bool child) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            ParameterCheck.ParameterRequired(elements, "elements");
            _ticket = ticket;
            _elements = elements;
            _child = child;
        }
    }

}

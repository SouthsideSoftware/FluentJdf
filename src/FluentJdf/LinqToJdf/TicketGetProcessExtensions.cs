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
            return new TicketResouces(_ticket, Elements.GetCurrentJDFResourceLinkPoolResolvedItemForUsage(ResourceUsage.Input));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public TicketResouces WithInput(XName resourceName) {
            return new TicketResouces(_ticket, WithReducer(Elements, resourceName, ResourceUsage.Input));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TicketResouces WithOutput() {
            return new TicketResouces(_ticket, Elements.GetCurrentJDFResourceLinkPoolResolvedItemForUsage(ResourceUsage.Output));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public TicketResouces WithOutput(XName resourceName) {
            return new TicketResouces(_ticket, WithReducer(Elements, resourceName, ResourceUsage.Output));
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

        //private static IEnumerable<XElement> ProcessXPathSelectElements(Ticket document, string processName) {
        //    //process:DigitalPrinting/DigitalPrintingParams[@usage=input]/rest of the xpath executed against JdfXPathSelectElement(s)
        //    ParameterCheck.ParameterRequired(document, "document");
        //    ParameterCheck.StringRequiredAndNotWhitespace(processName, "processXPath");

        //    var processElements = document.GetJdfNodesContainingProcessType(processName);
        //    foreach (var processElement in processElements) {
        //        var link = processElement.GetResourceLinkPoolResolvedItem(parser.ResourceName, parser.ResourceUsage);
        //        if (link != null) {
        //            if (!string.IsNullOrWhiteSpace(parser.XPathStatement)) {
        //                //You must wrap the document in the normalizer or you may not obtain the xml correctly.
        //                using (var resolver = new RefExtensionsNormalizer(processElement)) {
        //                    var xPath = new XPathDecorator(parser.XPathStatement).PrefixNames("jdf");
        //                    foreach (var item in link.XPathSelectElements(xPath, MakeNamespaceResolver(namespaceManager))) {
        //                        yield return item;
        //                    }
        //                }
        //            }
        //            else {
        //                yield return link;
        //            }
        //        }
        //    }
        //}
    }

    //Ticket.GetProcess().Bending().WithInput().RunList() This gets the first run list resource that is an input of the first bending.

    /// <summary>
    /// 
    /// </summary>
    public partial class TicketResouces {

        /// <summary>
        /// Address
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Address() {
            return Elements.Where(item => item.Name == Resource.Address);
        }

        /// <summary>
        /// AdhesiveBindingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> AdhesiveBindingParams() {
            return Elements.Where(item => item.Name == Resource.AdhesiveBindingParams);
        }

        /// <summary>
        /// ApprovalParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ApprovalParams() {
            return Elements.Where(item => item.Name == Resource.ApprovalParams);
        }

        /// <summary>
        /// ApprovalSuccess
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ApprovalSuccess() {
            return Elements.Where(item => item.Name == Resource.ApprovalSuccess);
        }

        /// <summary>
        /// ArtDeliveryIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ArtDeliveryIntent() {
            return Elements.Where(item => item.Name == Resource.ArtDeliveryIntent);
        }

        /// <summary>
        /// Assembly
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Assembly() {
            return Elements.Where(item => item.Name == Resource.Assembly);
        }

        /// <summary>
        /// AssetListCreationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> AssetListCreationParams() {
            return Elements.Where(item => item.Name == Resource.AssetListCreationParams);
        }

        /// <summary>
        /// AutomatedOverPrintParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> AutomatedOverPrintParams() {
            return Elements.Where(item => item.Name == Resource.AutomatedOverPrintParams);
        }

        /// <summary>
        /// BarcodeCompParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BarcodeCompParams() {
            return Elements.Where(item => item.Name == Resource.BarcodeCompParams);
        }

        /// <summary>
        /// BarcodeReproParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BarcodeReproParams() {
            return Elements.Where(item => item.Name == Resource.BarcodeReproParams);
        }

        /// <summary>
        /// BendingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BendingParams() {
            return Elements.Where(item => item.Name == Resource.BendingParams);
        }

        /// <summary>
        /// BinderySignature
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BinderySignature() {
            return Elements.Where(item => item.Name == Resource.BinderySignature);
        }

        /// <summary>
        /// BindingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BindingIntent() {
            return Elements.Where(item => item.Name == Resource.BindingIntent);
        }

        /// <summary>
        /// BlockPreparationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BlockPreparationParams() {
            return Elements.Where(item => item.Name == Resource.BlockPreparationParams);
        }

        /// <summary>
        /// BoxFoldingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BoxFoldingParams() {
            return Elements.Where(item => item.Name == Resource.BoxFoldingParams);
        }

        /// <summary>
        /// BoxPackingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BoxPackingParams() {
            return Elements.Where(item => item.Name == Resource.BoxPackingParams);
        }

        /// <summary>
        /// BufferParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BufferParams() {
            return Elements.Where(item => item.Name == Resource.BufferParams);
        }

        /// <summary>
        /// Bundle
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Bundle() {
            return Elements.Where(item => item.Name == Resource.Bundle);
        }

        /// <summary>
        /// BundlingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> BundlingParams() {
            return Elements.Where(item => item.Name == Resource.BundlingParams);
        }

        /// <summary>
        /// ByteMap
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ByteMap() {
            return Elements.Where(item => item.Name == Resource.ByteMap);
        }

        /// <summary>
        /// CaseMakingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CaseMakingParams() {
            return Elements.Where(item => item.Name == Resource.CaseMakingParams);
        }

        /// <summary>
        /// CasingInParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CasingInParams() {
            return Elements.Where(item => item.Name == Resource.CasingInParams);
        }

        /// <summary>
        /// ChannelBindingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ChannelBindingParams() {
            return Elements.Where(item => item.Name == Resource.ChannelBindingParams);
        }

        /// <summary>
        /// CIELABMeasuringField
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CIELABMeasuringField() {
            return Elements.Where(item => item.Name == Resource.CIELABMeasuringField);
        }

        /// <summary>
        /// CoilBindingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CoilBindingParams() {
            return Elements.Where(item => item.Name == Resource.CoilBindingParams);
        }

        /// <summary>
        /// CollectingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CollectingParams() {
            return Elements.Where(item => item.Name == Resource.CollectingParams);
        }

        /// <summary>
        /// Color
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Color() {
            return Elements.Where(item => item.Name == Resource.Color);
        }

        /// <summary>
        /// ColorantAlias
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ColorantAlias() {
            return Elements.Where(item => item.Name == Resource.ColorantAlias);
        }

        /// <summary>
        /// ColorantControl
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ColorantControl() {
            return Elements.Where(item => item.Name == Resource.ColorantControl);
        }

        /// <summary>
        /// ColorControlStrip
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ColorControlStrip() {
            return Elements.Where(item => item.Name == Resource.ColorControlStrip);
        }

        /// <summary>
        /// ColorCorrectionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ColorCorrectionParams() {
            return Elements.Where(item => item.Name == Resource.ColorCorrectionParams);
        }

        /// <summary>
        /// ColorIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ColorIntent() {
            return Elements.Where(item => item.Name == Resource.ColorIntent);
        }

        /// <summary>
        /// ColorMeasurementConditions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ColorMeasurementConditions() {
            return Elements.Where(item => item.Name == Resource.ColorMeasurementConditions);
        }

        /// <summary>
        /// ColorPool
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ColorPool() {
            return Elements.Where(item => item.Name == Resource.ColorPool);
        }

        /// <summary>
        /// ColorSpaceConversionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ColorSpaceConversionParams() {
            return Elements.Where(item => item.Name == Resource.ColorSpaceConversionParams);
        }

        /// <summary>
        /// ComChannel
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ComChannel() {
            return Elements.Where(item => item.Name == Resource.ComChannel);
        }

        /// <summary>
        /// Company
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Company() {
            return Elements.Where(item => item.Name == Resource.Company);
        }

        /// <summary>
        /// Component
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Component() {
            return Elements.Where(item => item.Name == Resource.Component);
        }

        /// <summary>
        /// Contact
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Contact() {
            return Elements.Where(item => item.Name == Resource.Contact);
        }

        /// <summary>
        /// ContactCopyParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ContactCopyParams() {
            return Elements.Where(item => item.Name == Resource.ContactCopyParams);
        }

        /// <summary>
        /// ContentList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ContentList() {
            return Elements.Where(item => item.Name == Resource.ContentList);
        }

        /// <summary>
        /// ConventionalPrintingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ConventionalPrintingParams() {
            return Elements.Where(item => item.Name == Resource.ConventionalPrintingParams);
        }

        /// <summary>
        /// CoverApplicationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CoverApplicationParams() {
            return Elements.Where(item => item.Name == Resource.CoverApplicationParams);
        }

        /// <summary>
        /// CreasingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CreasingParams() {
            return Elements.Where(item => item.Name == Resource.CreasingParams);
        }

        /// <summary>
        /// CustomerInfo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CustomerInfo() {
            return Elements.Where(item => item.Name == Resource.CustomerInfo);
        }

        /// <summary>
        /// CutBlock
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CutBlock() {
            return Elements.Where(item => item.Name == Resource.CutBlock);
        }

        /// <summary>
        /// CutMark
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CutMark() {
            return Elements.Where(item => item.Name == Resource.CutMark);
        }

        /// <summary>
        /// CuttingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CuttingParams() {
            return Elements.Where(item => item.Name == Resource.CuttingParams);
        }

        /// <summary>
        /// CylinderLayout
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CylinderLayout() {
            return Elements.Where(item => item.Name == Resource.CylinderLayout);
        }

        /// <summary>
        /// CylinderLayoutPreparationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> CylinderLayoutPreparationParams() {
            return Elements.Where(item => item.Name == Resource.CylinderLayoutPreparationParams);
        }

        /// <summary>
        /// DBMergeParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DBMergeParams() {
            return Elements.Where(item => item.Name == Resource.DBMergeParams);
        }

        /// <summary>
        /// DBRules
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DBRules() {
            return Elements.Where(item => item.Name == Resource.DBRules);
        }

        /// <summary>
        /// DBSchema
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DBSchema() {
            return Elements.Where(item => item.Name == Resource.DBSchema);
        }

        /// <summary>
        /// DBSelection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DBSelection() {
            return Elements.Where(item => item.Name == Resource.DBSelection);
        }

        /// <summary>
        /// DeliveryIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DeliveryIntent() {
            return Elements.Where(item => item.Name == Resource.DeliveryIntent);
        }

        /// <summary>
        /// DeliveryParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DeliveryParams() {
            return Elements.Where(item => item.Name == Resource.DeliveryParams);
        }

        /// <summary>
        /// DensityMeasuringField
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DensityMeasuringField() {
            return Elements.Where(item => item.Name == Resource.DensityMeasuringField);
        }

        /// <summary>
        /// DevelopingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DevelopingParams() {
            return Elements.Where(item => item.Name == Resource.DevelopingParams);
        }

        /// <summary>
        /// Device
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Device() {
            return Elements.Where(item => item.Name == Resource.Device);
        }

        /// <summary>
        /// DeviceMark
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DeviceMark() {
            return Elements.Where(item => item.Name == Resource.DeviceMark);
        }

        /// <summary>
        /// DeviceNSpace
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DeviceNSpace() {
            return Elements.Where(item => item.Name == Resource.DeviceNSpace);
        }

        /// <summary>
        /// DieLayout
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DieLayout() {
            return Elements.Where(item => item.Name == Resource.DieLayout);
        }

        /// <summary>
        /// DieLayoutProductionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DieLayoutProductionParams() {
            return Elements.Where(item => item.Name == Resource.DieLayoutProductionParams);
        }

        /// <summary>
        /// DigitalDeliveryParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DigitalDeliveryParams() {
            return Elements.Where(item => item.Name == Resource.DigitalDeliveryParams);
        }

        /// <summary>
        /// DigitalMedia
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DigitalMedia() {
            return Elements.Where(item => item.Name == Resource.DigitalMedia);
        }

        /// <summary>
        /// DigitalPrintingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DigitalPrintingParams() {
            return Elements.Where(item => item.Name == Resource.DigitalPrintingParams);
        }

        /// <summary>
        /// DividingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> DividingParams() {
            return Elements.Where(item => item.Name == Resource.DividingParams);
        }

        /// <summary>
        /// ElementColorParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ElementColorParams() {
            return Elements.Where(item => item.Name == Resource.ElementColorParams);
        }

        /// <summary>
        /// EmbossingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> EmbossingIntent() {
            return Elements.Where(item => item.Name == Resource.EmbossingIntent);
        }

        /// <summary>
        /// EmbossingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> EmbossingParams() {
            return Elements.Where(item => item.Name == Resource.EmbossingParams);
        }

        /// <summary>
        /// Employee
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Employee() {
            return Elements.Where(item => item.Name == Resource.Employee);
        }

        /// <summary>
        /// EndSheetGluingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> EndSheetGluingParams() {
            return Elements.Where(item => item.Name == Resource.EndSheetGluingParams);
        }

        /// <summary>
        /// ExposedMedia
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ExposedMedia() {
            return Elements.Where(item => item.Name == Resource.ExposedMedia);
        }

        /// <summary>
        /// ExternalImpositionTemplate
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ExternalImpositionTemplate() {
            return Elements.Where(item => item.Name == Resource.ExternalImpositionTemplate);
        }

        /// <summary>
        /// FeedingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> FeedingParams() {
            return Elements.Where(item => item.Name == Resource.FeedingParams);
        }

        /// <summary>
        /// FileSpec
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> FileSpec() {
            return Elements.Where(item => item.Name == Resource.FileSpec);
        }

        /// <summary>
        /// FitPolicy
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> FitPolicy() {
            return Elements.Where(item => item.Name == Resource.FitPolicy);
        }

        /// <summary>
        /// Fold
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Fold() {
            return Elements.Where(item => item.Name == Resource.Fold);
        }

        /// <summary>
        /// FoldingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> FoldingIntent() {
            return Elements.Where(item => item.Name == Resource.FoldingIntent);
        }

        /// <summary>
        /// FoldingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> FoldingParams() {
            return Elements.Where(item => item.Name == Resource.FoldingParams);
        }

        /// <summary>
        /// FontParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> FontParams() {
            return Elements.Where(item => item.Name == Resource.FontParams);
        }

        /// <summary>
        /// FontPolicy
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> FontPolicy() {
            return Elements.Where(item => item.Name == Resource.FontPolicy);
        }

        /// <summary>
        /// FormatConversionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> FormatConversionParams() {
            return Elements.Where(item => item.Name == Resource.FormatConversionParams);
        }

        /// <summary>
        /// GatheringParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> GatheringParams() {
            return Elements.Where(item => item.Name == Resource.GatheringParams);
        }

        /// <summary>
        /// GlueApplication
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> GlueApplication() {
            return Elements.Where(item => item.Name == Resource.GlueApplication);
        }

        /// <summary>
        /// GlueLine
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> GlueLine() {
            return Elements.Where(item => item.Name == Resource.GlueLine);
        }

        /// <summary>
        /// GluingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> GluingParams() {
            return Elements.Where(item => item.Name == Resource.GluingParams);
        }

        /// <summary>
        /// HeadBandApplicationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> HeadBandApplicationParams() {
            return Elements.Where(item => item.Name == Resource.HeadBandApplicationParams);
        }

        /// <summary>
        /// Hole
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Hole() {
            return Elements.Where(item => item.Name == Resource.Hole);
        }

        /// <summary>
        /// HoleLine
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> HoleLine() {
            return Elements.Where(item => item.Name == Resource.HoleLine);
        }

        /// <summary>
        /// HoleMakingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> HoleMakingIntent() {
            return Elements.Where(item => item.Name == Resource.HoleMakingIntent);
        }

        /// <summary>
        /// HoleMakingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> HoleMakingParams() {
            return Elements.Where(item => item.Name == Resource.HoleMakingParams);
        }

        /// <summary>
        /// IdentificationField
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> IdentificationField() {
            return Elements.Where(item => item.Name == Resource.IdentificationField);
        }

        /// <summary>
        /// IDPrintingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> IDPrintingParams() {
            return Elements.Where(item => item.Name == Resource.IDPrintingParams);
        }

        /// <summary>
        /// ImageCompressionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ImageCompressionParams() {
            return Elements.Where(item => item.Name == Resource.ImageCompressionParams);
        }

        /// <summary>
        /// ImageReplacementParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ImageReplacementParams() {
            return Elements.Where(item => item.Name == Resource.ImageReplacementParams);
        }

        /// <summary>
        /// ImageSetterParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ImageSetterParams() {
            return Elements.Where(item => item.Name == Resource.ImageSetterParams);
        }

        /// <summary>
        /// Ink
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Ink() {
            return Elements.Where(item => item.Name == Resource.Ink);
        }

        /// <summary>
        /// InkZoneCalculationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> InkZoneCalculationParams() {
            return Elements.Where(item => item.Name == Resource.InkZoneCalculationParams);
        }

        /// <summary>
        /// InkZoneProfile
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> InkZoneProfile() {
            return Elements.Where(item => item.Name == Resource.InkZoneProfile);
        }

        /// <summary>
        /// InsertingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> InsertingIntent() {
            return Elements.Where(item => item.Name == Resource.InsertingIntent);
        }

        /// <summary>
        /// InsertingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> InsertingParams() {
            return Elements.Where(item => item.Name == Resource.InsertingParams);
        }

        /// <summary>
        /// InsertSheet
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> InsertSheet() {
            return Elements.Where(item => item.Name == Resource.InsertSheet);
        }

        /// <summary>
        /// InterpretedPDLData
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> InterpretedPDLData() {
            return Elements.Where(item => item.Name == Resource.InterpretedPDLData);
        }

        /// <summary>
        /// InterpretingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> InterpretingParams() {
            return Elements.Where(item => item.Name == Resource.InterpretingParams);
        }

        /// <summary>
        /// JacketingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> JacketingParams() {
            return Elements.Where(item => item.Name == Resource.JacketingParams);
        }

        /// <summary>
        /// JobField
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> JobField() {
            return Elements.Where(item => item.Name == Resource.JobField);
        }

        /// <summary>
        /// LabelingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> LabelingParams() {
            return Elements.Where(item => item.Name == Resource.LabelingParams);
        }

        /// <summary>
        /// LaminatingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> LaminatingIntent() {
            return Elements.Where(item => item.Name == Resource.LaminatingIntent);
        }

        /// <summary>
        /// LaminatingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> LaminatingParams() {
            return Elements.Where(item => item.Name == Resource.LaminatingParams);
        }

        /// <summary>
        /// Layout
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Layout() {
            return Elements.Where(item => item.Name == Resource.Layout);
        }

        /// <summary>
        /// LayoutElement
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> LayoutElement() {
            return Elements.Where(item => item.Name == Resource.LayoutElement);
        }

        /// <summary>
        /// LayoutElementProductionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> LayoutElementProductionParams() {
            return Elements.Where(item => item.Name == Resource.LayoutElementProductionParams);
        }

        /// <summary>
        /// LayoutIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> LayoutIntent() {
            return Elements.Where(item => item.Name == Resource.LayoutIntent);
        }

        /// <summary>
        /// LayoutPreparationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> LayoutPreparationParams() {
            return Elements.Where(item => item.Name == Resource.LayoutPreparationParams);
        }

        /// <summary>
        /// LayoutShift
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> LayoutShift() {
            return Elements.Where(item => item.Name == Resource.LayoutShift);
        }

        /// <summary>
        /// LongitudinalRibbonOperationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> LongitudinalRibbonOperationParams() {
            return Elements.Where(item => item.Name == Resource.LongitudinalRibbonOperationParams);
        }

        /// <summary>
        /// ManualLaborParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ManualLaborParams() {
            return Elements.Where(item => item.Name == Resource.ManualLaborParams);
        }

        /// <summary>
        /// Media
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Media() {
            return Elements.Where(item => item.Name == Resource.Media);
        }

        /// <summary>
        /// MediaIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> MediaIntent() {
            return Elements.Where(item => item.Name == Resource.MediaIntent);
        }

        /// <summary>
        /// MediaSource
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> MediaSource() {
            return Elements.Where(item => item.Name == Resource.MediaSource);
        }

        /// <summary>
        /// MiscConsumable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> MiscConsumable() {
            return Elements.Where(item => item.Name == Resource.MiscConsumable);
        }

        /// <summary>
        /// NodeInfo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> NodeInfo() {
            return Elements.Where(item => item.Name == Resource.NodeInfo);
        }

        /// <summary>
        /// NumberingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> NumberingIntent() {
            return Elements.Where(item => item.Name == Resource.NumberingIntent);
        }

        /// <summary>
        /// NumberingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> NumberingParams() {
            return Elements.Where(item => item.Name == Resource.NumberingParams);
        }

        /// <summary>
        /// ObjectResolution
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ObjectResolution() {
            return Elements.Where(item => item.Name == Resource.ObjectResolution);
        }

        /// <summary>
        /// OrderingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> OrderingParams() {
            return Elements.Where(item => item.Name == Resource.OrderingParams);
        }

        /// <summary>
        /// PackingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PackingIntent() {
            return Elements.Where(item => item.Name == Resource.PackingIntent);
        }

        /// <summary>
        /// PackingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PackingParams() {
            return Elements.Where(item => item.Name == Resource.PackingParams);
        }

        /// <summary>
        /// PageAssignParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PageAssignParams() {
            return Elements.Where(item => item.Name == Resource.PageAssignParams);
        }

        /// <summary>
        /// PageList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PageList() {
            return Elements.Where(item => item.Name == Resource.PageList);
        }

        /// <summary>
        /// Pallet
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Pallet() {
            return Elements.Where(item => item.Name == Resource.Pallet);
        }

        /// <summary>
        /// PalletizingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PalletizingParams() {
            return Elements.Where(item => item.Name == Resource.PalletizingParams);
        }

        /// <summary>
        /// PDFToPSConversionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PDFToPSConversionParams() {
            return Elements.Where(item => item.Name == Resource.PDFToPSConversionParams);
        }

        /// <summary>
        /// PDLCreationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PDLCreationParams() {
            return Elements.Where(item => item.Name == Resource.PDLCreationParams);
        }

        /// <summary>
        /// PDLResourceAlias
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PDLResourceAlias() {
            return Elements.Where(item => item.Name == Resource.PDLResourceAlias);
        }

        /// <summary>
        /// PerforatingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PerforatingParams() {
            return Elements.Where(item => item.Name == Resource.PerforatingParams);
        }

        /// <summary>
        /// Person
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Person() {
            return Elements.Where(item => item.Name == Resource.Person);
        }

        /// <summary>
        /// PlaceHolderResource
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PlaceHolderResource() {
            return Elements.Where(item => item.Name == Resource.PlaceHolderResource);
        }

        /// <summary>
        /// PlasticCombBindingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PlasticCombBindingParams() {
            return Elements.Where(item => item.Name == Resource.PlasticCombBindingParams);
        }

        /// <summary>
        /// PlateCopyParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PlateCopyParams() {
            return Elements.Where(item => item.Name == Resource.PlateCopyParams);
        }

        /// <summary>
        /// PreflightAnalysis
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PreflightAnalysis() {
            return Elements.Where(item => item.Name == Resource.PreflightAnalysis);
        }

        /// <summary>
        /// PreflightInventory
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PreflightInventory() {
            return Elements.Where(item => item.Name == Resource.PreflightInventory);
        }

        /// <summary>
        /// PreflightParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PreflightParams() {
            return Elements.Where(item => item.Name == Resource.PreflightParams);
        }

        /// <summary>
        /// PreflightProfile
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PreflightProfile() {
            return Elements.Where(item => item.Name == Resource.PreflightProfile);
        }

        /// <summary>
        /// PreflightReport
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PreflightReport() {
            return Elements.Where(item => item.Name == Resource.PreflightReport);
        }

        /// <summary>
        /// PreflightReportRulePool
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PreflightReportRulePool() {
            return Elements.Where(item => item.Name == Resource.PreflightReportRulePool);
        }

        /// <summary>
        /// PreviewGenerationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PreviewGenerationParams() {
            return Elements.Where(item => item.Name == Resource.PreviewGenerationParams);
        }

        /// <summary>
        /// PrintCondition
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PrintCondition() {
            return Elements.Where(item => item.Name == Resource.PrintCondition);
        }

        /// <summary>
        /// PrintRollingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PrintRollingParams() {
            return Elements.Where(item => item.Name == Resource.PrintRollingParams);
        }

        /// <summary>
        /// ProductionIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ProductionIntent() {
            return Elements.Where(item => item.Name == Resource.ProductionIntent);
        }

        /// <summary>
        /// ProductionPath
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ProductionPath() {
            return Elements.Where(item => item.Name == Resource.ProductionPath);
        }

        /// <summary>
        /// ProofingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ProofingIntent() {
            return Elements.Where(item => item.Name == Resource.ProofingIntent);
        }

        /// <summary>
        /// ProofingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ProofingParams() {
            return Elements.Where(item => item.Name == Resource.ProofingParams);
        }

        /// <summary>
        /// PSToPDFConversionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PSToPDFConversionParams() {
            return Elements.Where(item => item.Name == Resource.PSToPDFConversionParams);
        }

        /// <summary>
        /// PublishingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> PublishingIntent() {
            return Elements.Where(item => item.Name == Resource.PublishingIntent);
        }

        /// <summary>
        /// QualityControlParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> QualityControlParams() {
            return Elements.Where(item => item.Name == Resource.QualityControlParams);
        }

        /// <summary>
        /// QualityControlResult
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> QualityControlResult() {
            return Elements.Where(item => item.Name == Resource.QualityControlResult);
        }

        /// <summary>
        /// RasterReadingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> RasterReadingParams() {
            return Elements.Where(item => item.Name == Resource.RasterReadingParams);
        }

        /// <summary>
        /// RefAnchor
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> RefAnchor() {
            return Elements.Where(item => item.Name == Resource.RefAnchor);
        }

        /// <summary>
        /// RegisterMark
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> RegisterMark() {
            return Elements.Where(item => item.Name == Resource.RegisterMark);
        }

        /// <summary>
        /// RegisterRibbon
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> RegisterRibbon() {
            return Elements.Where(item => item.Name == Resource.RegisterRibbon);
        }

        /// <summary>
        /// RenderingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> RenderingParams() {
            return Elements.Where(item => item.Name == Resource.RenderingParams);
        }

        /// <summary>
        /// ResourceDefinitionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ResourceDefinitionParams() {
            return Elements.Where(item => item.Name == Resource.ResourceDefinitionParams);
        }

        /// <summary>
        /// RingBindingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> RingBindingParams() {
            return Elements.Where(item => item.Name == Resource.RingBindingParams);
        }

        /// <summary>
        /// RollStand
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> RollStand() {
            return Elements.Where(item => item.Name == Resource.RollStand);
        }

        /// <summary>
        /// RunList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> RunList() {
            return Elements.Where(item => item.Name == Resource.RunList);
        }

        /// <summary>
        /// SaddleStitchingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> SaddleStitchingParams() {
            return Elements.Where(item => item.Name == Resource.SaddleStitchingParams);
        }

        /// <summary>
        /// ScanParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ScanParams() {
            return Elements.Where(item => item.Name == Resource.ScanParams);
        }

        /// <summary>
        /// ScavengerArea
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ScavengerArea() {
            return Elements.Where(item => item.Name == Resource.ScavengerArea);
        }

        /// <summary>
        /// ScreeningIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ScreeningIntent() {
            return Elements.Where(item => item.Name == Resource.ScreeningIntent);
        }

        /// <summary>
        /// ScreeningParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ScreeningParams() {
            return Elements.Where(item => item.Name == Resource.ScreeningParams);
        }

        /// <summary>
        /// SeparationControlParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> SeparationControlParams() {
            return Elements.Where(item => item.Name == Resource.SeparationControlParams);
        }

        /// <summary>
        /// Shape
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Shape() {
            return Elements.Where(item => item.Name == Resource.Shape);
        }

        /// <summary>
        /// ShapeCuttingIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ShapeCuttingIntent() {
            return Elements.Where(item => item.Name == Resource.ShapeCuttingIntent);
        }

        /// <summary>
        /// ShapeCuttingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ShapeCuttingParams() {
            return Elements.Where(item => item.Name == Resource.ShapeCuttingParams);
        }

        /// <summary>
        /// ShapeDef
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ShapeDef() {
            return Elements.Where(item => item.Name == Resource.ShapeDef);
        }

        /// <summary>
        /// ShapeDefProductionParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ShapeDefProductionParams() {
            return Elements.Where(item => item.Name == Resource.ShapeDefProductionParams);
        }

        /// <summary>
        /// Sheet
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Sheet() {
            return Elements.Where(item => item.Name == Resource.Sheet);
        }

        /// <summary>
        /// ShrinkingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ShrinkingParams() {
            return Elements.Where(item => item.Name == Resource.ShrinkingParams);
        }

        /// <summary>
        /// SideSewingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> SideSewingParams() {
            return Elements.Where(item => item.Name == Resource.SideSewingParams);
        }

        /// <summary>
        /// SizeIntent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> SizeIntent() {
            return Elements.Where(item => item.Name == Resource.SizeIntent);
        }

        /// <summary>
        /// SpinePreparationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> SpinePreparationParams() {
            return Elements.Where(item => item.Name == Resource.SpinePreparationParams);
        }

        /// <summary>
        /// SpineTapingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> SpineTapingParams() {
            return Elements.Where(item => item.Name == Resource.SpineTapingParams);
        }

        /// <summary>
        /// StackingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> StackingParams() {
            return Elements.Where(item => item.Name == Resource.StackingParams);
        }

        /// <summary>
        /// StaticBlockingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> StaticBlockingParams() {
            return Elements.Where(item => item.Name == Resource.StaticBlockingParams);
        }

        /// <summary>
        /// StitchingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> StitchingParams() {
            return Elements.Where(item => item.Name == Resource.StitchingParams);
        }

        /// <summary>
        /// Strap
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Strap() {
            return Elements.Where(item => item.Name == Resource.Strap);
        }

        /// <summary>
        /// StrappingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> StrappingParams() {
            return Elements.Where(item => item.Name == Resource.StrappingParams);
        }

        /// <summary>
        /// StripBindingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> StripBindingParams() {
            return Elements.Where(item => item.Name == Resource.StripBindingParams);
        }

        /// <summary>
        /// StrippingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> StrippingParams() {
            return Elements.Where(item => item.Name == Resource.StrippingParams);
        }

        /// <summary>
        /// Surface
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Surface() {
            return Elements.Where(item => item.Name == Resource.Surface);
        }

        /// <summary>
        /// ThreadSealingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ThreadSealingParams() {
            return Elements.Where(item => item.Name == Resource.ThreadSealingParams);
        }

        /// <summary>
        /// ThreadSewingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> ThreadSewingParams() {
            return Elements.Where(item => item.Name == Resource.ThreadSewingParams);
        }

        /// <summary>
        /// Tile
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Tile() {
            return Elements.Where(item => item.Name == Resource.Tile);
        }

        /// <summary>
        /// Tool
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> Tool() {
            return Elements.Where(item => item.Name == Resource.Tool);
        }

        /// <summary>
        /// TransferCurve
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> TransferCurve() {
            return Elements.Where(item => item.Name == Resource.TransferCurve);
        }

        /// <summary>
        /// TransferCurvePool
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> TransferCurvePool() {
            return Elements.Where(item => item.Name == Resource.TransferCurvePool);
        }

        /// <summary>
        /// TransferFunctionControl
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> TransferFunctionControl() {
            return Elements.Where(item => item.Name == Resource.TransferFunctionControl);
        }

        /// <summary>
        /// TrappingDetails
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> TrappingDetails() {
            return Elements.Where(item => item.Name == Resource.TrappingDetails);
        }

        /// <summary>
        /// TrappingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> TrappingParams() {
            return Elements.Where(item => item.Name == Resource.TrappingParams);
        }

        /// <summary>
        /// TrapRegion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> TrapRegion() {
            return Elements.Where(item => item.Name == Resource.TrapRegion);
        }

        /// <summary>
        /// TrimmingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> TrimmingParams() {
            return Elements.Where(item => item.Name == Resource.TrimmingParams);
        }

        /// <summary>
        /// UsageCounter
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> UsageCounter() {
            return Elements.Where(item => item.Name == Resource.UsageCounter);
        }

        /// <summary>
        /// VarnishingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> VarnishingParams() {
            return Elements.Where(item => item.Name == Resource.VarnishingParams);
        }

        /// <summary>
        /// VerificationParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> VerificationParams() {
            return Elements.Where(item => item.Name == Resource.VerificationParams);
        }

        /// <summary>
        /// WebInlineFinishingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> WebInlineFinishingParams() {
            return Elements.Where(item => item.Name == Resource.WebInlineFinishingParams);
        }

        /// <summary>
        /// WireCombBindingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> WireCombBindingParams() {
            return Elements.Where(item => item.Name == Resource.WireCombBindingParams);
        }

        /// <summary>
        /// WrappingParams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> WrappingParams() {
            return Elements.Where(item => item.Name == Resource.WrappingParams);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class TicketResouces {

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
        public TicketResouces(Ticket ticket, IEnumerable<XElement> elements) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            ParameterCheck.ParameterRequired(elements, "elements");
            _ticket = ticket;
            _elements = elements;
        }
    }

}

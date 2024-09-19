using Azure.Core.Pipeline;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web;

namespace NComprobantesPDF
{
    public class HtmlToPDF
    {
        public iTextSharp.text.Rectangle TamañoPagina { get; set; }
        public bool MostrarNumerosDePagina { get; set; }
        public string CabeceraHTML { get; set; }
        public string FooterImage { get; set; }

        public string CabeceraPrimerPaginaHTML { get; set; }

        public string Titulo { get; set; }

        public int MargenSuperior { get; set; }
        public int MargenInferior { get; set; }
        public int MargenIzquierdo { get; set; }
        public int MargenDerecho { get; set; }
        public string PalabrasClave { get; set; }
        public string Asunto { get; set; }

        public HtmlToPDF()
        {
            TamañoPagina = PageSize.LETTER;
            MostrarNumerosDePagina = false;
            CabeceraHTML = string.Empty;
            FooterImage = string.Empty;
            Titulo = string.Empty;
            PalabrasClave = string.Empty;
            Asunto = string.Empty;
            MargenSuperior = 40;
            MargenInferior = 40;
            MargenIzquierdo = 30;
            MargenDerecho = 30;
        }
        
        public IEnumerable<byte> ConvertHtmlToPDF(string htmltext, string cssruta)
        {
            //Create a byte array that will eventually hold our final PDF
            byte[] bytes;

            //Boilerplate iTextSharp setup here
            //Create a stream that we can write to, in this case a MemoryStream
            using (var ms = new MemoryStream())
            {
                //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                using (var doc = new Document(TamañoPagina, MargenIzquierdo, MargenDerecho, MargenSuperior, MargenInferior))
                {
                    var writer = PdfWriter.GetInstance(doc, ms);
                    var hf = new HeaderFooter
                    {
                        MostrarNumerosDePagina = MostrarNumerosDePagina,
                        CabeceraHTML = CabeceraHTML,
                        FooterImage = FooterImage,
                        CabeceraPrimerPaginaHTML = CabeceraPrimerPaginaHTML
                    };
                    if (string.IsNullOrWhiteSpace(cssruta) == false) hf.CabeceraCSS = File.ReadAllText(cssruta); //(HttpContext.Current.Server.MapPath(cssruta));
                    writer.PageEvent = hf;
                    //writer.SetFullCompression(); //Usar Compresion

                    //Open the document for writing
                    doc.Open();

                    doc.AddAuthor("Nico Chamorro y Milton Sarkissian");
                    doc.AddCreationDate();
                    doc.AddProducer();
                    doc.AddCreator("Nico Chamorro y Milton Sarkissian");


                    if (string.IsNullOrWhiteSpace(PalabrasClave) == false) doc.AddKeywords(PalabrasClave);
                    if (string.IsNullOrWhiteSpace(Titulo) == false) doc.AddTitle(Titulo);
                    if (string.IsNullOrWhiteSpace(Asunto) == false) doc.AddSubject(Asunto);

                    var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
                    tagProcessors.RemoveProcessor(HTML.Tag.IMG); // remove the default processor
                    tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor()); // use our new processor

                    var cssFiles = new CssFilesImpl();
                    cssFiles.Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
                    var cssResolver = new StyleAttrCSSResolver(cssFiles);
                    if (string.IsNullOrWhiteSpace(cssruta) == false) cssResolver.AddCssFile(cssruta, true); //(HttpContext.Current.Server.MapPath(cssruta), true);

                    var charset = Encoding.UTF8;
                    var hpc = new HtmlPipelineContext(new CssAppliersImpl(new XMLWorkerFontProvider()));
                    hpc.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(tagProcessors); // inject the tagProcessors
                    var htmlPipeline = new HtmlPipeline(hpc, new PdfWriterPipeline(doc, writer));
                    var pipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
                    var worker = new XMLWorker(pipeline, true);
                    var xmlParser = new XMLParser(true, worker, charset);
                    xmlParser.Parse(new StringReader(htmltext));
                    doc.Close();
                    bytes = ms.ToArray();
                }
            }

            return bytes;
        }
    }
}
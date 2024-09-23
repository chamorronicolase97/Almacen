using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;

namespace NComprobantesPDF
{
    public class HeaderFooter : PdfPageEventHelper
    {
        protected List<ElementList> header;
        protected ElementList header2;
        protected ElementList headerPrimerPagina;
        protected ElementList footer;
        private PdfTemplate template;

        public string CabeceraHTML { get; set; }
        public string FooterImage { get; set; }
        public BaseFont BaseFont { get; set; }
        public bool MostrarNumerosDePagina { get; set; }
        public string CabeceraCSS { get; set; }
        public string CabeceraPrimerPaginaHTML { get; set; }

        public HeaderFooter()
        {
            MostrarNumerosDePagina = false;
            CabeceraCSS = null;
            headerPrimerPagina = null;
            header = new List<ElementList>();
        }

        // we override the onOpenDocument method
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    var h = XMLWorkerHelper.ParseToElementList(CabeceraHTML, CabeceraCSS);
                    header.Add(h);
                }

                if (string.IsNullOrWhiteSpace(CabeceraPrimerPaginaHTML) == false) headerPrimerPagina = XMLWorkerHelper.ParseToElementList(CabeceraPrimerPaginaHTML, CabeceraCSS);
                BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                var cb = writer.DirectContent;
                template = cb.CreateTemplate(50, 50);
            }
            catch (Exception)
            {
            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            var cb = writer.DirectContent;
            var pageSize = document.PageSize;

            var pageN = writer.PageNumber;
            var text = pageN + " de ";

            if (MostrarNumerosDePagina)
            {
                var len = BaseFont.GetWidthPoint(text, 8);
                cb.SetRGBColorFill(100, 100, 100);
                cb.BeginText();
                cb.SetFontAndSize(BaseFont, 8);
                cb.SetTextMatrix(pageSize.GetRight(40) - len, pageSize.GetBottom(30));
                cb.ShowText(text);
                cb.EndText();
                cb.AddTemplate(template, pageSize.GetRight(40), pageSize.GetBottom(30));
            }

            if (string.IsNullOrWhiteSpace(FooterImage) == false)
            {
                iTextSharp.text.Image imgfoot = iTextSharp.text.Image.GetInstance(FooterImage);
                imgfoot.SetAbsolutePosition(0, 0);
                imgfoot.ScaleAbsoluteWidth(pageSize.Width);
                var template2 = cb.CreateTemplate(pageSize.Width, imgfoot.Height);
                template2.AddImage(imgfoot);
                cb.AddTemplate(template2, 0, pageSize.GetBottom(10));
            }
            try
            {
                var ct = new ColumnText(cb);
                ct.SetSimpleColumn(new iTextSharp.text.Rectangle(pageSize.GetLeft(document.LeftMargin), pageSize.GetTop(15), pageSize.GetRight(document.RightMargin), pageSize.GetTop(document.TopMargin)));
                if (headerPrimerPagina != null && pageN == 1)
                {
                    foreach (IElement e in headerPrimerPagina)
                    {
                        ct.AddElement(e);
                    }
                }
                else
                {
                    if (header.Count >= pageN - 1)
                    {
                        foreach (IElement e in header[pageN - 1])
                        {
                            ct.AddElement(e);
                        }
                    }
                }

                ct.Go();
            }
            catch (DocumentException)
            {
                throw;
            }
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            if (MostrarNumerosDePagina && template != null)
            {
                template.BeginText();
                template.SetFontAndSize(BaseFont, 8);
                template.SetTextMatrix(0, 0);
                template.ShowText("" + writer.PageNumber);
                template.EndText();
            }
        }
    }
}

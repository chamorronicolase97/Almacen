using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using System;
using System.Collections.Generic;

namespace NComprobantesPDF
{
    public class CustomImageTagProcessor : iTextSharp.tool.xml.html.Image
    {
        public override IList<IElement> End(IWorkerContext ctx, Tag tag, IList<IElement> currentContent)
        {
            var attributes = tag.Attributes;
            if (!attributes.TryGetValue(HTML.Attribute.SRC, out string src))
            {
                return new List<IElement>(1);
            }

            if (string.IsNullOrEmpty(src))
            {
                return new List<IElement>(1);
            }

            if (tag.Name == "img" && src.StartsWith("data:image/", StringComparison.InvariantCultureIgnoreCase))
            {
                var image = iTextSharp.text.Image.GetInstance(src);

                var list = new List<IElement>();
                var htmlPipelineContext = GetHtmlPipelineContext(ctx);
                list.Add(GetCssAppliers().Apply(new Chunk((iTextSharp.text.Image)GetCssAppliers().Apply(image, tag, htmlPipelineContext), 0, 0, true), tag, htmlPipelineContext));
                return list;
            }
            else
            {
                return base.End(ctx, tag, currentContent);
            }
        }
    }
}

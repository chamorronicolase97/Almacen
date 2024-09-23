
using Almacen.Clases.Administracion;
using Almacen.Clases.Venta;
using NComprobantesPDF;
using System;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace NEntidadesFinancieras
{
    public class ComprobanteVentaPDF : ComprobantePDFBase
    {
        private readonly Venta _venta;
        private readonly Cliente _cliente;
        private readonly List<DetalleVenta> _detallesVenta;
        

        public ComprobanteVentaPDF(Venta venta, List<DetalleVenta> DetalleVenta)
        {
            _detallesVenta = DetalleVenta;
            _venta = venta;
            _cliente = _venta.Cliente;          

            FileName = $"Comrpobante Venta nro {_venta.ID}.pdf";

            PDFConverter = new HtmlToPDF
            {
                Titulo = "COMPROBANTE VENTA",
                Asunto = $"Venta nro {_venta.ID}",
                PalabrasClave = "COMPROBANTE VENTA",
                CabeceraHTML = GetEncabezado(),                
                TamañoPagina = iTextSharp.text.PageSize.LETTER
            };
        }

        public string GenerarHtml()
        {
            string cuerpoHTML = @"<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Comprobante de Venta</title>
    <style>
        body {font - family: Arial, sans-serif;
            margin: 0 auto;
            padding: 20px;
            width: 600px;
        }
        .comprobante {border: 1px solid #ccc;
            padding: 20px;
            margin-top: 20px;
        }
        h1 {text - align: center;
        }
        .empresa, .cliente, .venta {margin - bottom: 20px;
        }
        table {width: 100%;
            border-collapse: collapse;
        }
        th, td {padding: 10px;
            text-align: left;
            border: 1px solid #ccc;
        }
        .total {text - align: right;
            font-size: 18px;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <h1>Comprobante de Venta</h1>

    <div class='comprobante'>
        <div class='empresa'>
            <strong>Nombre de la Empresa:</strong> <span>#EMPERESA#</span>
        </div>
        
        <div class='venta'>
            <strong>Número de Venta:</strong> <span>#NROVENTA#</span><br>
            <strong>Fecha de la Venta:</strong> <span>#FECHAVENTA#</span>
        </div>

        <div class='cliente'>
            <strong>Nombre del Cliente:</strong> <span>#CLIENTE#</span>
        </div>

        <table>
            <thead>
                <tr>
                    <th>Descripción</th>
                    <th>Cantidad</th>
                    <th>Precio Unitario</th>
                    <th>Subtotal</th>
                </tr>
            </thead>
            <tbody>
                #DETALLE#
           </tbody>
        </table>                   
<div class='total'>
            <strong>Total:</strong> <span>$#TOTAL#</span>
        </div>
</div>
</body>
</html>
";

            return DetalleVenta(cuerpoHTML);
        }

        private string DetalleVenta(string cuerpoHTML)
        {
            cuerpoHTML = cuerpoHTML.Replace("#EMPRESA#", $"Sarkissian y Chamorro S.R.L.");// AGREGAR PARAMETROS DE SISTEMAS.

            cuerpoHTML = cuerpoHTML.Replace("#NROVENTA#", $"{_venta.ID}");

            cuerpoHTML = cuerpoHTML.Replace("#FECHAVENTA#", $"{_venta.FechaVenta.ToString("dd/MM/yyyy")}");

            cuerpoHTML = cuerpoHTML.Replace("#CLIENTE#", $"{_venta.Cliente.Denominacion}");
            
            cuerpoHTML = cuerpoHTML.Replace("#TOTAL#", $"{_venta.Total:00.00}");

            string detalleventa = ""; 
            foreach(DetalleVenta dv in _detallesVenta )
            {
                detalleventa += $"<tr><td>{dv.Producto.Descripcion}</td>                    <td>{dv.Cantidad}</td>                   <td>${dv.Producto.ValorVenta}</td>                    <td>${dv.SubTotal}</td></tr>";
            }

            cuerpoHTML = cuerpoHTML.Replace("#DETALLE#", detalleventa);

            return cuerpoHTML;
        }

        public override byte[] GetContent()
        {
            try
            {
                return PDFConverter.ConvertHtmlToPDF(GenerarHtml(), "C:\\Users\\Mutual de AMR\\Desktop\\NET\\TP Integrador\\Almacen\\Clases\\Comprobante/ComprobantePDF.css").ToArray();
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Error generando comprobante de venta", ex);
            }
        }

        public override async Task<byte[]> GetContentAsync()
        {
            try
            {
                return PDFConverter.ConvertHtmlToPDF(GenerarHtml(), "~/Content/ComprobantePDF.css").ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error generando comprobante de venta", ex);
            }
        }
    }
}

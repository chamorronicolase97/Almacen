
using Almacen.Clases.Administracion;
using Almacen.Clases.Venta;
using NComprobantesPDF;
using System;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using Almacen.Clases.Compra;

namespace NEntidadesFinancieras
{
    public class ComprobantePedidoPDF : ComprobantePDFBase
    {
        private readonly Pedido _pedido;
        private readonly List<DetallePedido> _detallesPedido;
        

        public ComprobantePedidoPDF(Pedido Pedido, List<DetallePedido> DetallePedido)
        {
            _pedido = Pedido;
            _detallesPedido = DetallePedido;     

            FileName = $"Comrpobante Pedido nro {_pedido.ID}.pdf";

            PDFConverter = new HtmlToPDF
            {
                Titulo = "COMPROBANTE PEDIDO",
                Asunto = $"Pedido nro {_pedido.ID}",
                PalabrasClave = "COMPROBANTE PEDIDO",
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
    <h1>Nota de Pedido</h1>

    <div class='comprobante'>
        <div class='empresa'>
            <strong>Nombre de la Empresa:</strong> <span>#EMPRESA#</span>
        </div>
        
        <div class='venta'>
            <strong>Número de Pedido:</strong> <span>#NROPEDIDO#</span><br>
            <strong>Fecha de Entrega:</strong> <span>#FECHAPEDIDO#</span>
        </div>

        <div class='cliente'>
            <strong>Razón Social del Proveedor:</strong> <span>#PROVEEDOR#</span>
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
           <p> <strong>Total:</strong> <span>$#TOTAL#</span> </p>
        </div>
</div>
</body>
</html>
";

            return DetallePedido(cuerpoHTML);
        }

        private string DetallePedido(string cuerpoHTML)
        {
            cuerpoHTML = cuerpoHTML.Replace("#EMPRESA#", $"Sarkissian y Chamorro S.R.L.");// AGREGAR PARAMETROS DE SISTEMAS.

            cuerpoHTML = cuerpoHTML.Replace("#NROPEDIDO#", $"{_pedido.ID}");

            cuerpoHTML = cuerpoHTML.Replace("#FECHAPEDIDO#", $"{_pedido.FechaEntrega.ToString("dd/MM/yyyy")}");

            cuerpoHTML = cuerpoHTML.Replace("#PROVEEDOR#", $"{_pedido.Proveedor.RazonSocial}");
            

            string detallePedido = ""; 
            decimal total = 0;
            foreach(DetallePedido dv in _detallesPedido )
            {
                detallePedido += $"<tr><td>{dv.Producto.Descripcion}</td>                    <td>{dv.Cantidad}</td>                   <td>${dv.CostoUnitario}</td>                    <td>${dv.CostoUnitario * dv.Cantidad}</td></tr>";
                total += dv.CostoUnitario * dv.Cantidad;
            }
            cuerpoHTML = cuerpoHTML.Replace("#TOTAL#", $"{total:00.00}");
            cuerpoHTML = cuerpoHTML.Replace("#DETALLE#", detallePedido);

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

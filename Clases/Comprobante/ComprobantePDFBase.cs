using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace NComprobantesPDF
{
    public class ComprobantePDFBase : IComprobantePDF
    {
        public string ContentType { get; set; } = "application/octet-stream";
        public string FileName { get; set; }
        public HtmlToPDF PDFConverter { get; set; }

        public void GuardarComprobante(string RutaBase)
        {
            string rutaArchivo = Path.Combine(RutaBase, FileName);
            byte[] content = GetContent();

            FileStream sourceStreamSolicitud = File.Open(rutaArchivo, FileMode.OpenOrCreate);
            sourceStreamSolicitud.Seek(0, SeekOrigin.End);

            Task tSolicitud = sourceStreamSolicitud.WriteAsync(content, 0, content.Length);
            tSolicitud.ContinueWith(_ => sourceStreamSolicitud.Dispose());
        }

        public async Task GuardarComprobanteAsync(string RutaBase)
        {
            string rutaArchivo = Path.Combine(RutaBase, FileName);
            byte[] content = await GetContentAsync();

            FileStream sourceStreamSolicitud = File.Open(rutaArchivo, FileMode.OpenOrCreate);
            sourceStreamSolicitud.Seek(0, SeekOrigin.End);

            await sourceStreamSolicitud.WriteAsync(content, 0, content.Length).ContinueWith(_ => sourceStreamSolicitud.Dispose());
        }

        public virtual byte[] GetContent()
        {
            throw new NotImplementedException();
        }

        public virtual Task<byte[]> GetContentAsync()
        {
            throw new NotImplementedException();
        }

        #region Partes HTML Estándar

        /// <summary> Encabezado estándar para comprobantes </summary>
        public string GetEncabezado()
        {
            // Obtener el directorio donde se está ejecutando la aplicación
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //C:\Users\Mutual de AMR\Desktop\NET\TP Integrador\Almacen\Imagenes\logo.png

            // Construir la ruta al archivo
            string logoPath = Path.Combine(appDirectory, "Content", "logo.png");

            string encabezado = $@"<tr>
    <td>
        <!-- Agrega atributos como width, height, alt, style, etc. -->
        <img src='{logoPath}' alt='Logo Empresa' width='100' height='100' style='border: 1px solid #000; margin-right: 10px;'/>
    </td>
    <td colspan='2'>
        <p class='cabecera'>
            <span>Sarkissian & Chamorro S.R.L.</span>
            <br/>
            <span>WhatsApp 341 388 0950 - 2000 Rosario - Santa Fe</span>
        </p>
    </td>
</tr>";

            return encabezado;
        }

        /// <summary> Mensaje para reimpresión </summary>
        public string GetReimpresionAviso()
        {
            const string aviso = @"<tr><td colspan='3'>
                                   <div class='leyenda'>
                                     COMPROBANTE REIMPRESO
                                   </div>
                                 </td></tr>";

            return aviso;
        }
       

        /// <summary> Fecha en footer estándar para comprobantes </summary>
        public string GetFechaComprobante()
        {
            string fecha = $@"<tr><td colspan='3'>
                               <p class='fechaComprobante'>{DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
                           </td></tr>";

            return fecha;
        }

        #endregion
    }
}

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NComprobantesPDF
{
    public class FileStreamPDFBase : IComprobantePDF
    {
        public string ContentType { get; set; }
        public string FileRoute { get; set; }
        public string FileName { get; set; }

        public FileStreamPDFBase(string FileRoute)
        {
            ContentType = "application/pdf";
            this.FileRoute = FileRoute;
            this.FileName = FileRoute.Split('/', '\\').Last();
        }

        public FileStreamPDFBase(string FileRoute, string FileName)
        {
            ContentType = "application/pdf";
            this.FileRoute = FileRoute;
            this.FileName = FileName;
        }

        public void GuardarComprobante(string RutaBase) => throw new NotImplementedException();
        public Task GuardarComprobanteAsync(string RutaBase) => throw new NotImplementedException();

        public byte[] GetContent()
        {
            try
            {
                return File.ReadAllBytes(FileRoute);
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo obtener el contenido del archivo: {FileRoute}", ex);
            }
        }

        public async Task<byte[]> GetContentAsync()
        {
            try
            {
                return await Task.Run(() => File.ReadAllBytes(FileRoute));
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo obtener el contenido del archivo: {FileRoute}", ex);
            }
        }
    }
}


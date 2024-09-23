using System.Threading.Tasks;

namespace NComprobantesPDF
{
    public interface IComprobantePDF
    {
        string ContentType { get; }
        string FileName { get; }
        void GuardarComprobante(string RutaBase);
        Task GuardarComprobanteAsync(string RutaBase);
        byte[] GetContent();
        Task<byte[]> GetContentAsync();
    }
}
namespace Exta.Domain.Models
{
    public class TempCheck
    {
        public string ContentType { get; }
        public byte[] Data { get; }

        public TempCheck(
            string contentType,
            byte[] data
        )
        {
            ContentType = contentType;
            Data = data;
        }
    }
}
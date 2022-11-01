namespace Diiage.Directory.Core.Interfaces.Services.Models
{
    public class Mail<T>
    {
        public string Recipient { get; set; }
        public string SubjectTemplate { get; set; }
        public string BodyTemplate { get; set; }
        public T Parameters { get; set; }
    }
}

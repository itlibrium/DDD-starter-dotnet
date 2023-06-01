namespace MyCompany.ECommerce.TechnicalStuff.Api.Versioning
{
    public class ApiVersionDocumentOptions
    {
        public string PathPrefix { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool UseEndpointVersioning { get; set; }
    }
}
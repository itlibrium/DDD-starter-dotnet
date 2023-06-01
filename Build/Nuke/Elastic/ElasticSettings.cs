namespace MyCompany.ECommerce.Nuke.Elastic
{
    public class ElasticSettings
    {
        public const string Key = "Elastic";
        
        public string ElasticsearchVersion { get; set; }
        public string ElasticsearchConfigDirectory { get; set; }
        public string KibanaVersion { get; set; }
        public string KibanaConfigDirectory { get; set; }
        public string SuperUserName { get; set; }
        public string SuperUserPassword { get; set; }
        public string Kibana01UserName { get; set; }
        public string Kibana01UserPassword { get; set; }
        public string KibanaEncryptionKey { get; set; }
    }
}
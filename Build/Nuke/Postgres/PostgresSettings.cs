namespace MyCompany.ECommerce.Nuke.Postgres;

public record PostgresSettings
{
    public const string Key = "Postgres";
        
    public string ConnectionString { get; set; }
}
namespace MyCompany.ECommerce.TechnicalStuff.Persistence.RepoDb;

public interface DbRootEntity<out TId>
{
    TId Id { get; }
    int Version { get; }
}
namespace MyCompany.Crm.TechnicalStuff;

public interface DataEquals<in T>
{
    bool HasSameDataAs(T other);
}
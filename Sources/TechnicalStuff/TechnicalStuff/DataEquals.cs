namespace MyCompany.ECommerce.TechnicalStuff;

public interface DataEquals<in T>
{
    bool HasSameDataAs(T other);
}
namespace MyCompany.ECommerce.TechnicalStuff;

public class PermanentInfrastructureError : InfrastructureError
{
    public PermanentInfrastructureError() { }

    public PermanentInfrastructureError(string message) : base(message) { }

    public PermanentInfrastructureError(string message, Exception innerException) :
        base(message, innerException) { }
}
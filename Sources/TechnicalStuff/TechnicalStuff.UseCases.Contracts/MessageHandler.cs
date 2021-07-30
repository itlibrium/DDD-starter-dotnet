using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.UseCases
{
    public interface MessageHandler
    {
        Task Handle(Message message);
    }
}
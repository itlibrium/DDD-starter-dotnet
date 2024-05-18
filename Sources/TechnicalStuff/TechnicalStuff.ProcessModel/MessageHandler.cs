using System.Threading.Tasks;

namespace MyCompany.ECommerce.TechnicalStuff.ProcessModel;

public interface MessageHandler
{
    Task Handle(Message message);
}
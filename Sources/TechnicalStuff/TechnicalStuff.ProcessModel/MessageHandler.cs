using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.ProcessModel
{
    public interface MessageHandler
    {
        Task Handle(Message message);
    }
}
using BrokerService.Services.Interfaces.Base;
using BrokerService.Services.Models;

namespace BrokerService.Domain.Interfaces.Services
{
    public interface IMessageService
    {
        bool SendMessage(MessageModel message);
    }

}

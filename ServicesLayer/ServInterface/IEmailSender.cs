using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IEmailSender
    {
        //Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);


    }
}

using MimeKit;
using SistemaDeLogin.Infra.CrossCutting.Identity.ConfigEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.ApplicationIdentity.Interfaces
{
    public interface IEmailServices
    {
        void SendEmail(Message message);
    }
}

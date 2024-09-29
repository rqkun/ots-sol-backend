﻿using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(MessageModel message);
    }
}

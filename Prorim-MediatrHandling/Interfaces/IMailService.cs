﻿using FbSoft_MediatrHandling.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.Interfaces
{
    public interface IMailService
    {
        bool SendMail(EmailDTO data);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMobile.core.Notifications;
public class Notificacao
{

    public Notificacao(string message)
    {
        Message = message;
    }

    public string? Message { get; }

}

﻿using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface  IRandomReceiver: IGrainWithGuidKey
    {
        Task SendMessage(string message);
    }
}

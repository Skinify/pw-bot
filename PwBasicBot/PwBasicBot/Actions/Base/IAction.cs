using PwBasicBot.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwBasicBot.Actions
{
    public interface IAction
    {
        void Start(IntPtr gameWindowHandler);
        void Finish();
        ActionStatusEnum GetActionStatus();
    }
}

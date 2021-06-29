using System;

namespace PwBasicBot.Mode.ActionsModes
{
    public class BaseBotActionMode
    {
        private Type[] actionList;
        private int actionCounter = 0;

        public BaseBotActionMode(params Type[] actionList)
        {
            this.actionList = actionList;
        }

        public Type NextAction()
        {
            if (actionCounter == actionList.Length)
                actionCounter = 0;

            Type nextAction = actionList[actionCounter];
            actionCounter++;
            
            return nextAction;
        }

    }
}

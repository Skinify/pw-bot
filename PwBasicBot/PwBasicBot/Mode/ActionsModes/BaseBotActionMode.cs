using System;

namespace PwBasicBot.Mode.ActionsModes
{
    public class BaseBotActionMode
    {
        private readonly Type[] actionList;
        private int actionCounter = 0;
        public string modeName;

        public BaseBotActionMode(string modeName, params Type[] actionList)
        {
            this.modeName = modeName;
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

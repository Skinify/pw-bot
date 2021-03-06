using System;

namespace PwBasicBot.Mode.ActionsModes
{
    public class ActionMode
    {
        private readonly Type[] actionList;
        private static int actionCounter = 0;
        public string modeName;

        public ActionMode(string modeName, params Type[] actionList)
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

        public static void ResetCounter()
        {
            actionCounter = 0;
        }
    }
}

using PwBasicBot.Enuns;

namespace PwBasicBot.Actions
{
    public abstract class BaseAction
    {
        public ActionStatusEnum ActionStatus { get; protected set; } = ActionStatusEnum.STARTING;
    }
}

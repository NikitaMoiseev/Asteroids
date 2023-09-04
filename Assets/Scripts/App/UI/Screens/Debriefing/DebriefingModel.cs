using System;

namespace App.UI.Screens.Debriefing
{
    public class DebriefingModel
    {
        public float Score { get; }
        public event Action ContinueAction;

        public DebriefingModel(Action continueAction, float score) 
        {
            Score = score;
            ContinueAction += continueAction;
        }

        public void Continue() => ContinueAction?.Invoke();
    }
}
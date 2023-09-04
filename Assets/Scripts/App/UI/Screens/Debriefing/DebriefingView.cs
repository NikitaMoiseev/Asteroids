using System;
using TMPro;
using UI;
using UnityEngine;

namespace App.UI.Screens.Debriefing
{
    public class DebriefingView : MonoBehaviour
    {
        [SerializeField] private string _scoreTitle = "Score: ";
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private ActionButton _actionButton;

        public void SetScore(float value)
        {
            _score.SetText(_scoreTitle + value);
        }

        public void InitButton(Action continueAction)
        {
            _actionButton.Init(continueAction);
        }
    }
}
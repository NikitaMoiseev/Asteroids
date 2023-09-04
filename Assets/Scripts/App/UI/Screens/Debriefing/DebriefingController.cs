using System;
using UnityEngine;

namespace App.UI.Screens.Debriefing
{
    public class DebriefingController : MonoBehaviour
    {
        [SerializeField] private DebriefingView _debriefingView;

        public void Init(DebriefingModel debriefingModel)
        {
            SetActive(true);
            Action buttonAction = () => SetActive(false);
            _debriefingView.SetScore(debriefingModel.Score);
            _debriefingView.InitButton(buttonAction + debriefingModel.Continue);
        }

        public void SetActive(bool value) => gameObject.SetActive(value);
    }
}
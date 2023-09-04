using System;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class ActionButton : MonoBehaviour
    {
        private Action _action;
        private UnityEngine.UI.Button _button;

        public UnityEngine.UI.Button Button => _button ??= GetComponent<UnityEngine.UI.Button>();

        public void Init(Action action)
        {
            _action = action;
        }
        private void Awake()
        {
            Button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(OnClick);
            _action = null;
        }

        private void OnClick()
        {
            _action?.Invoke();
        }
    }
}
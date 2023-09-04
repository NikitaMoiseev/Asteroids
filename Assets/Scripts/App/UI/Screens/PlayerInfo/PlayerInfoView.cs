using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace App.UI.Screens.PlayerInfo
{
    public class PlayerInfoView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _prefab;
        [SerializeField] private Transform _parent;

        private List<TextMeshProUGUI> _texsts = new List<TextMeshProUGUI>();

        public void SetText(string[] strings)
        {
            int i = 0;
            for (; i < _texsts.Count && i < strings.Length; i++)
            {
                _texsts[i].gameObject.SetActive(true);
                _texsts[i].SetText(strings[i]);
            }
            for (; i < strings.Length; i++)
            {
                _texsts.Add(AddNewText());
                _texsts[i].SetText(strings[i]);
            }
            for (; i < _texsts.Count; i++)
            {
                _texsts[i].gameObject.SetActive(false);
            }
        }

        private TextMeshProUGUI AddNewText()
        {
            var text = Instantiate(_prefab, _parent).GetComponent<TextMeshProUGUI>();
            text.gameObject.SetActive(true);
            return text;
        }
    }
}
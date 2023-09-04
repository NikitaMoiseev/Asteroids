using System;
using UnityEngine;

namespace App.UI.Screens.PlayerInfo
{
    public class PlayerInfoController : MonoBehaviour, IDisposable
    {
        [SerializeField] private PlayerInfoView _playerInfoView;
        public void Init(PlayerInfoModel playerInfoModel)
        {
            gameObject.SetActive(true);
            _playerInfoView.SetText(playerInfoModel.Strings);
        }

        public void Dispose() => gameObject.SetActive(false);
    }
}
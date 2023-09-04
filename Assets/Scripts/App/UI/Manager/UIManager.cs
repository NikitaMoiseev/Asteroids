using App.UI.Screens.Debriefing;
using App.UI.Screens.PlayerInfo;
using UnityEngine;

namespace App.UI.Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private DebriefingController _debriefingController;
        [SerializeField] private PlayerInfoController _playerInfoController;
        public void SetDebriefingScreen(DebriefingModel debriefingModel)
        {
            _debriefingController.Init(debriefingModel);
            _playerInfoController.Dispose();
        }
        public void SetPlayerInfoScreen(PlayerInfoModel playerInfoModel)
        {
            if (playerInfoModel == null)
                return;
            _playerInfoController.Init(playerInfoModel);
        }
    }
}
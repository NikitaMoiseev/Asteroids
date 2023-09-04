using App.CommonUnit.Config;
using App.CommonUnit.Model;
using App.Player.Manager;

namespace App.Enemy.Model
{
    public class ChasePlayerMovementModel : UnitMovementModel
    {
        private PlayerManager _playerManager;
        public Unit.Unit PlayerUnit => _playerManager.Player;
        public ChasePlayerMovementModel(UnitConfig config, PlayerManager playerManager) : base(config)
        {
            _playerManager = playerManager;
        }
    }
}
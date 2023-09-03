using App.CommonUnit.Config.Attack;
using App.CommonUnit.Model;
using App.Player.Model;
using ObjectFactory;

namespace App.Player.Manager
{
    public class PlayerManager
    {
        public Unit.Unit Player { get; private set; }


        public void SpawnPlayer(IObjectFactory factory, AttackConfigsSO attackConfigsSO)
        {
            Player = factory.Create<Unit.Unit>("Player");
            var playerModel = new PlayerUnitModel(new UnitHealthModel(1), new UnitMovementModel(2), new ReloadableAttackModel(attackConfigsSO.GetConfig("Test"), factory), null);
            Player.Init(playerModel);
        }
    }
}
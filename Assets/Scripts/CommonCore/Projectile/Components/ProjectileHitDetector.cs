using CommonComponents;
using Projectile.Model;
using UnityEngine;

namespace Projectile.Components
{
    public class ProjectileHitDetector : MonoBehaviour, IInitializable<IProjectileModel>
    {
        private IProjectileModel _model;
        public void Init(IProjectileModel data)
        {
            _model = data;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out Unit.Unit unit))
                _model.Damage(unit);
        }
    }
}
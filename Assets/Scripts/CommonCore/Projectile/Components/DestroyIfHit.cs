using CommonComponents;
using ObjectFactory.Components;
using Projectile.Model;
using UnityEngine;

namespace Unit.Components
{
    [RequireComponent(typeof(Destroyer))]
    public class DestroyIfHit : MonoBehaviour, IInitializable<IProjectileModel>
    {
        private IProjectileModel _model;
        private Destroyer _destroyer;

        public void Init(IProjectileModel model)
        {
            _model = model;
            _destroyer = gameObject.GetComponent<Destroyer>();
            _model.OnDamage += Destroy;
        }

        public void Destroy() => _destroyer.Destroy();

        private void OnDisable() => Dispose();

        private void Dispose()
        {
            if (_model != null)
                _model.OnDamage -= Destroy;
            _model = null;
        }
    }
}
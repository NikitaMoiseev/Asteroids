using Extensions;
using Projectile.Model;
using UnityEngine;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        private IProjectileModel _model;

        public void Init(IProjectileModel projectileModel)
        {
            _model = projectileModel;
            InitComponents();
        }

        private void InitComponents() => gameObject.InitAllComponentsInChildren(_model);
    }
}
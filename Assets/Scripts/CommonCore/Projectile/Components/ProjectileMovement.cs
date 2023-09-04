using CommonComponents;
using Projectile.Model;
using UnityEngine;

namespace Projectile.Components
{
    public class ProjectileMovement : MonoBehaviour, IInitializable<IProjectileModel>
    {
        [SerializeField] private float _speed;

        private IProjectileModel _model;
        public void Init(IProjectileModel data)
        {
            _model = data;
        }

        public void Update()
        {
            transform.position += _model.Direction * _speed * Time.deltaTime;
        }
    }
}
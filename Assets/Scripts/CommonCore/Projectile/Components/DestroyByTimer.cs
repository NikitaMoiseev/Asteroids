using CommonComponents;
using ObjectFactory.Components;
using Projectile.Model;
using UnityEngine;

namespace Unit.Components
{
    [RequireComponent(typeof(Destroyer))]
    public class DestroyByTimer : MonoBehaviour, IInitializable<IProjectileModel>
    {
        [SerializeField] private float _duration;
        private IProjectileModel _model;
        private Destroyer _destroyer;
        private float _timer;

        public void Init(IProjectileModel model)
        {
            _model = model;
            _destroyer = gameObject.GetComponent<Destroyer>();
            _timer = 0;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _duration)
            {
                Destroy();
            }
        }

        public void Destroy() => _destroyer.Destroy();

        private void OnDisable() => Dispose();

        private void Dispose()
        {
            _model = null;
        }
    }
}
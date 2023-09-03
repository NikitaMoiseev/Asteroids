using CommonComponents;
using Unit.Model;
using UnityEngine;

namespace Unit.Components
{
    public class UnitRotation : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IMovementModel _movementModel;

        public void Init(IUnitModel model)
        {
            _movementModel = model.MovementModel;
        }

        public void Update()
        {
            var rotation = Quaternion.AngleAxis(_movementModel.RotateSpeed * Time.deltaTime, Vector3.forward);
            transform.rotation *= rotation;
        }

        private void OnDisable() => _movementModel = null;
    }
}
using CommonComponents;
using Unit.Model;
using UnityEngine;

namespace Unit.Components
{
    public class UnitRotation : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IRotateModel _rotateModel;

        public void Init(IUnitModel model)
        {
            _rotateModel = model.RotateModel;
        }

        public void Update()
        {
            var rotation = Quaternion.AngleAxis(_rotateModel.RotateAngleValue * Time.deltaTime, Vector3.forward);
            transform.rotation *= rotation;
        }

        private void OnDisable() => _rotateModel = null;
    }
}
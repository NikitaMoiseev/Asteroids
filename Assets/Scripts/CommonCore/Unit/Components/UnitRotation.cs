using CommonComponents;
using Unit.Model;
using UnityEngine;

namespace Unit.Components
{
    public class UnitRotation : MonoBehaviour, IInitializable<Unit>
    {
        private IRotateModel _rotateModel;

        public void Init(Unit data)
        {
            _rotateModel = data.Model.RotateModel;
        }

        public void Update()
        {
            var rotation = Quaternion.AngleAxis(_rotateModel.RotateAngleValue * Time.deltaTime, Vector3.forward);
            transform.rotation *= rotation;
        }

        private void OnDisable() => _rotateModel = null;
    }
}
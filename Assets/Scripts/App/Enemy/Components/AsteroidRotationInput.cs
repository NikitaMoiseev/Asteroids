using CommonComponents;
using Unit.Model;
using UnityEngine;

namespace App.Enemy.Components
{
    public class AsteroidRotationInput : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IRotateModel _rotateModel;
        public void Init(IUnitModel model)
        {
            _rotateModel = model.RotateModel;
            _rotateModel.SetRotateDirection(Random.Range(-1f, 1f));
        }
    }
}
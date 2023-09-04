using CommonComponents;
using Unit.Model;
using UnityEngine;

namespace App.Enemy.Components
{
    public class AsteroidRotationInput : MonoBehaviour, IInitializable<Unit.Unit>
    {
        private IRotateModel _rotateModel;
        public void Init(Unit.Unit data)
        {
            _rotateModel = data.Model.RotateModel;
            _rotateModel.SetRotateDirection(Random.Range(-1f, 1f));
        }
    }
}
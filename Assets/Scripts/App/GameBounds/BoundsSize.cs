using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.GameBounds
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BoundsSize : MonoBehaviour
    {
        [SerializeField] private Vector2 _screenSizeOffsets;
        private BoxCollider2D _boxCollider;
        private Vector2 _size;

        public Vector2 Size => _size;

        public void Init()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            _size = GetScreenSize() + _screenSizeOffsets;
            _boxCollider.size = _size;
        }

        private Vector2 GetScreenSize()
        {
            var screenWorldSize = 
                Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - 
                Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            return screenWorldSize;
        }
    }
}
using UnityEngine;
using System;

namespace CommonCore.ObjectPool
{
    [Serializable]
    public class PoolParams
    {
        [SerializeField] private bool _detectInitialCapacityShortage = true;
        [SerializeField] private int _initialCapacity = 10;
        [SerializeField] private int _maxCapacity = 1000;
        [SerializeField] private int _sizeIncrementStep = 1;

        public bool DetectInitialCapacityShortage => _detectInitialCapacityShortage;
        public int InitialCapacity => _initialCapacity;
        public int MaxCapacity => _maxCapacity;
        public int SizeIncrementStep => _sizeIncrementStep;
    }
}
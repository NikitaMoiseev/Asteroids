﻿using System;

namespace ObjectPool.Pool
{
    public interface IObjectPool<T> : IDisposable
    {
        public int CountAll { get; }
        public int CountActive { get; }
        public int CountInactive { get; }
        void ReleaseAllActive();
        T Get();
        void Release(T element);
    }
}
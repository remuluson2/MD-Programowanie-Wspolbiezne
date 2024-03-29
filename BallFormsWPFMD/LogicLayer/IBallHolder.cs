﻿using System;
using System.Collections.Specialized;

namespace LogicLayer
{
    public abstract class IBallHolder : INotifyCollectionChanged, IDisposable
    {
        public abstract event NotifyCollectionChangedEventHandler? CollectionChanged;

        public abstract int Count { get; }

        public abstract void AddBall();
        public abstract void DelBall(int index);

        public abstract void Clear();
        public abstract void Dispose();

        public abstract void InitBalls(int ballsNumber);

        public abstract void SetNewArea(double width, double height);
        public abstract void SetNewSize(int size);

        public abstract void StartTimer();
        public abstract void StopTimer();
    }
}

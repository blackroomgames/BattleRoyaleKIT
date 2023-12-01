using System;
using UnityEngine;
using BlackECS;
using BlackECS.Entities;

using Code.Pool;
using Code.Unit.Strategy;

namespace Code.Unit
{
    public sealed class UnitPresentor : IDisposable
    {
        private readonly UnitPool Pool;

        public UnitPresentor(
            UnitModel model,
            UnitView view,
            IStrategy strategy, 
            UnitPool pool)
        {
            Model = model;
            View = view;
            Strategy = strategy;
            Pool = pool;

            Entity = World.CreateEntity();
        }

        public UnitModel Model { get; }
        public UnitView View { get; }
        public IStrategy Strategy { get; }
        public Entity Entity { get; }
        
        public void Dispose()
        {
            Entity?.Destroy();
            Model.Dispose();
            Strategy.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}

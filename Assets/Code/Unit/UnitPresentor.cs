using System;
using UnityEngine;
using BlackECS;
using BlackECS.Entities;

using Code.Unit.Strategy;

namespace Code.Unit
{
    public sealed class UnitPresentor : IDisposable
    {
        public UnitPresentor(
            UnitModel model,
            UnitView view,
            IStrategy strategy)
        {
            Model = model;
            View = view;
            Strategy = strategy;
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

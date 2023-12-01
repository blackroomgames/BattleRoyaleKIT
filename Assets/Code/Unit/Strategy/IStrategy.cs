using System;

namespace Code.Unit.Strategy
{
    public interface IStrategy : IDisposable
    {
        void Execute(UnitPresentor owner);
        void Update(UnitPresentor owner);
    }
}

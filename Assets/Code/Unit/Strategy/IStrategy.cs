using System;

namespace Code.Unit.Strategy
{
    public interface IStrategy : IDisposable
    {
        void Execute();
        void Update();
    }
}

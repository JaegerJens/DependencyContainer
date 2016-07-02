using System;
using System.Collections.Generic;

namespace DependencyContainer
{
    public interface IResolve
    {
        T Resolve<T>();
    }

    public class RecursiveDiContainer : IResolve
    {
        private readonly Dictionary<Type, Func<IResolve, object>> _container;

        public RecursiveDiContainer()
        {
            _container = new Dictionary<Type, Func<IResolve, object>>();
        }

        public void Register<T>(Func<IResolve, T> creator)
        {
            Func<IResolve, object> activator = r => creator(r);
            _container.Add(typeof(T), activator);
        }

        public T Resolve<T>()
        {
            Func<IResolve, object> result = null;
            if (_container.TryGetValue(typeof(T), out result))
            {
                return (T)result(this);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}

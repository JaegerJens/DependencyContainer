using System;

namespace DependencyContainer
{
    public interface iA { }
    public class A : iA
    {
        public A()
        {
            Console.WriteLine("A");
        }
    }

    public interface iB { }
    public class B : iB
    {
        public B(iA a)
        {
            Console.WriteLine("B");
        }
    }

    public interface iC { }
    public class C : iC
    {
        public C(iA a, iB b)
        {
            Console.WriteLine("C");
        }
    }
}

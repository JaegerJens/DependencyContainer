using System;

namespace DependencyContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Recursive DI Container");
            var rc = new RecursiveDiContainer();
            rc.Register<iA>(r => new A());
            rc.Register<iB>(r => new B(r.Resolve<iA>()));
            rc.Register<iC>(r => new C(r.Resolve<iA>(), r.Resolve<iB>()));
            var c1 = rc.Resolve<iC>();

            Console.WriteLine("Static DI Container");
            var sc = new StaticDiPattern();
            var c2 = sc.ResolveIC;

            Console.ReadKey();
        }
    }
}

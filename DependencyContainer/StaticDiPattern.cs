namespace DependencyContainer
{
    public class StaticDiPattern
    {
        public iA ResolveIA => new A();

        public iB ResolveIB => new B(ResolveIA);
        
        public iC ResolveIC => new C(ResolveIA, ResolveIB);
    }
}

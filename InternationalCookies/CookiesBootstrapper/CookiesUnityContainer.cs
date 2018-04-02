using Unity;

namespace CookiesBootstrapper
{
    public static class CookiesUnityContainer
    {
        static CookiesUnityContainer()
        {
            Current = new UnityContainer();
           // Current.RegisterType(typeof(ICustomerrepo))
        }
        public static IUnityContainer Current { get; private set; }
    }
}

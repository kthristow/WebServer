namespace WebServer.MvcFramework
{
    public interface IServiceCollection
    {
        void Add<TSource, TDestination>();
        object CreateInstance(Type type);
    }
}

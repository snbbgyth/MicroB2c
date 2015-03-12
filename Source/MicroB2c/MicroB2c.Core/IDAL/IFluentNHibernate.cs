using NHibernate;

namespace MicroB2c.Core.IDAL
{
    public interface IFluentNHibernate
    {
        ISession GetSession();
    }
}

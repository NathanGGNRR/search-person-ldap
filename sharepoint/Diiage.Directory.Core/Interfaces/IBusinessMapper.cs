using System.Linq;

namespace Diiage.Directory.Core.Interfaces
{
    /// <summary>
    /// Mapper (Entities <> Models (ie. DTOs)) interface.
    /// </summary>
    public interface IBusinessMapper
    {
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source);

        TDestination Map<TDestination>(object source);

        TDestination Map<TSource, TDestination>(TSource source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}

using Diiage.Directory.Core.Interfaces;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Diiage.Directory.Infrastructure.Mapping
{
    public class Mapper : IBusinessMapper
    {
        private readonly IConfigurationProvider _mapperConfiguration;
        private readonly IMapper _mapperEngine;

        public Mapper()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<MainProfile>(); });
            _mapperEngine = _mapperConfiguration.CreateMapper();
        }

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return source.ProjectTo<TDestination>(_mapperConfiguration);
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapperEngine.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapperEngine.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapperEngine.Map<TSource, TDestination>(source, destination);
        }
    }
}

using AutoMapper;
using Zone.Core.Response;
namespace Zone.Core
{
    public class PaginatedListConverter<TSource, TDestination> : ITypeConverter<PaginatedList<TSource>, PaginatedList<TDestination>>
    {
        public PaginatedList<TDestination> Convert(PaginatedList<TSource> source, PaginatedList<TDestination> destination, ResolutionContext context)
        {
            var collection = source.Select(m=>context.Mapper.Map<TSource, TDestination>(m)).ToList();
            return new PaginatedList<TDestination>(collection, source.TotalRecords, source.Offset, source.Limit);
        }

    }
}

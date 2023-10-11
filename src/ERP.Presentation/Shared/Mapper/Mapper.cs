using AutoMapper;

namespace ERP.Presentation.Shared.Mapper;

public static class Mapper<TDestination, TSource>
{
    public static TDestination MappClasses(TSource command)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());

        var mapper = config.CreateMapper();
        return mapper.Map<TDestination>(command);
    }

    public static IEnumerable<TDestination> MapEnumList(IEnumerable<TSource> source)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());

        var mapper = config.CreateMapper();
        return mapper.Map<IEnumerable<TDestination>>(source);
    }

    public static IList<TDestination> MapList(IList<TSource> source)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());

        var mapper = config.CreateMapper();
        return mapper.Map<IList<TDestination>>(source);
    }
}
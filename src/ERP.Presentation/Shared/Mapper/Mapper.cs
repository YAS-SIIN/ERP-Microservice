using AutoMapper;

namespace ERP.Presentation.Shared.Mapper;

public static class Mapper<TDestination, TOrigin>
{
    public static TDestination MappClasses(TOrigin command)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<TOrigin, TDestination>());

        var mapper = config.CreateMapper();
        return mapper.Map<TDestination>(command);
    }    
}
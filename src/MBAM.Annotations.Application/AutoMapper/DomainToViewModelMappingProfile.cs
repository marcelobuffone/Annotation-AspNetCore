using AutoMapper;
using MBAM.Annotations.Application.ViewModels;
using MBAM.Annotations.Domain.Annotations;
using System.Linq;

namespace MBAM.Annotations.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AnnotationHistoryViewModel, AnnotationHistory>().ReverseMap();

            CreateMap<AnnotationViewModel, Annotation>();

            CreateMap<Annotation, AnnotationViewModel>()
                    .ForMember(dest => dest.LastUpdate, opts => opts.MapFrom(src => src.AnnotationHistory.OrderBy(e => e.CreateDate).LastOrDefault().CreateDate))
                    .ForMember(dest => dest.AnnotationHistory, opts => opts.MapFrom(src => src.AnnotationHistory));

            CreateMap<Annotation, AnnotationHistoryViewModel>()
                    .ForMember(dest => dest.AnnotationId, opts => opts.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.AnnotationHistory.OrderBy(e => e.CreateDate).LastOrDefault().Title))
                    .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.AnnotationHistory.OrderBy(e => e.CreateDate).LastOrDefault().Description))
                    .ForMember(dest => dest.LastUpdate, opts => opts.MapFrom(src => src.AnnotationHistory.OrderBy(e => e.CreateDate).LastOrDefault().CreateDate))
                    .ForMember(dest => dest.CreateDate, opts => opts.MapFrom(src => src.AnnotationHistory.OrderBy(e => e.CreateDate).FirstOrDefault().CreateDate));

        }
    }
}

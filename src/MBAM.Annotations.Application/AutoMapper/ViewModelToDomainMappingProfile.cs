using AutoMapper;
using MBAM.Annotations.Application.ViewModels;
using MBAM.Annotations.Domain.Annotations.Commands;

namespace MBAM.Annotations.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AnnotationHistoryViewModel, RegisterAnnotationCommand>()
                .ConstructUsing(c => new RegisterAnnotationCommand(c.Title, c.Description));

            CreateMap<AnnotationHistoryViewModel, UpdateAnnotationCommand>()
                .ConstructUsing(c => new UpdateAnnotationCommand(c.Title, c.Description, c.Id));

            CreateMap<AnnotationViewModel, DeleteAnnotationCommand>()
                .ConstructUsing(c => new DeleteAnnotationCommand(c.Id));
        }
    }
}

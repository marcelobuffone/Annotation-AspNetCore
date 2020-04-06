using MBAM.Annotations.Application.AutoMapper;
using MBAM.Annotations.Application.Interfaces;
using MBAM.Annotations.Application.Services;
using MBAM.Annotations.Domain.Annotations.Commands;
using MBAM.Annotations.Domain.Annotations.Events;
using MBAM.Annotations.Domain.Annotations.Repository;
using MBAM.Annotations.Domain.Core.Bus;
using MBAM.Annotations.Domain.Core.Events;
using MBAM.Annotations.Domain.Core.Notifications;
using MBAM.Annotations.Domain.Interfaces;
using MBAM.Annotations.Infra.CrossCutting.AspNetFilters;
using MBAM.Annotations.Infra.CrossCutting.Bus;
using MBAM.Annotations.Infra.Data.Context;
using MBAM.Annotations.Infra.Data.Repository;
using MBAM.Annotations.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MBAM.Annotations.Infra.CrossCutting.IOC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //App
            services.AddSingleton(AutoMapperConfiguration.RegisterMappings().CreateMapper());
            services.AddScoped<IAnnotationAppService, AnnotationAppService>();

            //domain commands
            services.AddScoped<IHandler<RegisterAnnotationCommand>, AnnotationCommandHandler>();
            services.AddScoped<IHandler<UpdateAnnotationCommand>, AnnotationCommandHandler>();
            services.AddScoped<IHandler<DeleteAnnotationCommand>, AnnotationCommandHandler>();

            //domain eventos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IHandler<AnnotationRegistredEvent>, AnnotationEventHandler>();
            services.AddScoped<IHandler<AnnotationUpdatedEvent>, AnnotationEventHandler>();
            services.AddScoped<IHandler<AnnotationDeletedEvent>, AnnotationEventHandler>();
            
            //infra data
            services.AddScoped<IAnnotationRepository, AnnotationRespository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AnnotationsContext>();

            //infra bus
            services.AddScoped<IBus, InMemoryBus>();

            //infra filter
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLogger>();

        }
    }
}

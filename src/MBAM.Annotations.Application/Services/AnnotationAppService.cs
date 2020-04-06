using AutoMapper;
using MBAM.Annotations.Application.Interfaces;
using MBAM.Annotations.Application.ViewModels;
using MBAM.Annotations.Domain.Annotations.Commands;
using MBAM.Annotations.Domain.Annotations.Repository;
using MBAM.Annotations.Domain.Core.Bus;
using System;
using System.Collections.Generic;

namespace MBAM.Annotations.Application.Services
{
    public class AnnotationAppService : IAnnotationAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IAnnotationRepository _annotationRepository;

        public AnnotationAppService(IBus bus, IMapper mapper, IAnnotationRepository annotationRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _annotationRepository = annotationRepository;
        }

        public void Register(AnnotationHistoryViewModel annotationViewModel)
        {
            var registerHistoryCommand = _mapper.Map<RegisterAnnotationCommand>(annotationViewModel);
            _bus.SendCommand(registerHistoryCommand);

        }
        public void Update(AnnotationHistoryViewModel annotationViewModel)
        {
            var updateAnnotationCommand = _mapper.Map<UpdateAnnotationCommand>(annotationViewModel);
            _bus.SendCommand(updateAnnotationCommand);
        }
        public void Remove(Guid id)
        {
            _bus.SendCommand(new DeleteAnnotationCommand(id));
        }

        public IEnumerable<AnnotationViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<AnnotationViewModel>>(_annotationRepository.GetAll());
        }

        public AnnotationViewModel GetById(Guid id)
        {
            return _mapper.Map<AnnotationViewModel>(_annotationRepository.GetById(id));
        }

        public AnnotationHistoryViewModel GetLastHistoryByAnnotationId(Guid id)
        {
            return _mapper.Map<AnnotationHistoryViewModel>(_annotationRepository.GetLastHistoryById(id));
        }

        public void Dispose()
        {
            _annotationRepository.Dispose();
        }
    }
}

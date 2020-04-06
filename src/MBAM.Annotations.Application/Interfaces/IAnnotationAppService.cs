using MBAM.Annotations.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace MBAM.Annotations.Application.Interfaces
{
    public interface IAnnotationAppService : IDisposable
    {
        void Register(AnnotationHistoryViewModel annotationViewModel);
        void Update(AnnotationHistoryViewModel annotationViewModel);
        void Remove(Guid id);
        IEnumerable<AnnotationViewModel> GetAll();
        AnnotationViewModel GetById(Guid id);
        AnnotationHistoryViewModel GetLastHistoryByAnnotationId(Guid id);

    }
}

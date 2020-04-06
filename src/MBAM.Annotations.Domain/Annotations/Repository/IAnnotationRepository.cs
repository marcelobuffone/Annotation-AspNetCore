using MBAM.Annotations.Domain.Interfaces;
using System;

namespace MBAM.Annotations.Domain.Annotations.Repository
{
    public interface IAnnotationRepository : IRepository<Annotation>
    {
        Annotation GetLastHistoryById(Guid id);
        void AddHistory(AnnotationHistory annotationHistory);
    }
}

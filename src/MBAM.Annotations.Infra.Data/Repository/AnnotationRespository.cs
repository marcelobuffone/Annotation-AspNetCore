using Dapper;
using MBAM.Annotations.Domain.Annotations;
using MBAM.Annotations.Domain.Annotations.Repository;
using MBAM.Annotations.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MBAM.Annotations.Infra.Data.Repository
{
    public class AnnotationRespository : Repository<Annotation>, IAnnotationRepository
    {
        public AnnotationRespository(AnnotationsContext context) : base(context)
        {
        }

        public override IEnumerable<Annotation> GetAll()
        {
            return DbSet.Include(e => e.AnnotationHistory);
        }

        public override Annotation GetById(Guid id)
        {
            return DbSet.Include(e => e.AnnotationHistory).FirstOrDefault(e => e.Id == id);
        }

        public Annotation GetLastHistoryById(Guid id)
        {
            return DbSet.Include(e => e.AnnotationHistory).FirstOrDefault(e => e.Id == id);
        }

        public void AddHistory(AnnotationHistory annotationHistory)
        {
            Db.AnnotationHistories.Add(annotationHistory);
        }

    }
}

using MBAM.Annotations.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MBAM.Annotations.Domain.Annotations
{
    public class Annotation : Entity<Annotation>
    {
        public Annotation(string title, string description)
        {
            Id = Guid.NewGuid();
            AddHistory(new AnnotationHistory(title, description, Id));
        }

        public Annotation(Guid id,string title, string description)
        {
            Id = id;
            AddHistory(new AnnotationHistory(title, description, Id));
        }

        private Annotation() { }

        public virtual List<AnnotationHistory> AnnotationHistory { get; private set; }

        public void AddHistory(AnnotationHistory annotationHistory)
        {
            AnnotationHistory = new List<AnnotationHistory> { annotationHistory };
        }

        public override bool IsValid()
        {
            Validation();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        private void Validation()
        {

        }

        public static class AnnotationFactory
        {
            public static Annotation NewAnnotation(Guid id, string title, string description)
            {
                var annotation = new Annotation(id, title, description);
                
                return annotation;
            }

        }

    }
}

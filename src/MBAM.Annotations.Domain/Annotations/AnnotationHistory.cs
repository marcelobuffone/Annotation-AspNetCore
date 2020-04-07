using FluentValidation;
using MBAM.Annotations.Domain.Core.Models;
using System;

namespace MBAM.Annotations.Domain.Annotations
{
    public class AnnotationHistory : Entity<AnnotationHistory>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreateDate { get; protected set; }
        public Annotation Annotation { get; private set; }
        public Guid AnnotationId { get; private set; }

        public AnnotationHistory(string title, string description, Guid annotationId)
        {
            Id = Guid.NewGuid();
            Title = title;

            Description = description;
            AnnotationId = annotationId;
            CreateDate = DateTime.Now;
            RemoveEmptyLines();
        }

        protected AnnotationHistory() { }

        public override bool IsValid()
        {
            Validation();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        private void Validation()
        {
            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("Title cannot be empty")
                .Length(2, 100).WithMessage("Title Min. 2 Max. 100 Characters");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Description cannot be empty");
        }

        private void RemoveEmptyLines()
        {
            while (Description.Contains("\r\n\r\n"))
            {
                Description = Description.Replace("\r\n\r\n", "\r\n");
            }
        }
    }
}

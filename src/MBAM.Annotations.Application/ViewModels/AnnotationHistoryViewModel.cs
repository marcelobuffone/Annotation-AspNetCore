using System;
using System.ComponentModel.DataAnnotations;

namespace MBAM.Annotations.Application.ViewModels
{
    public class AnnotationHistoryViewModel
    {
        public AnnotationHistoryViewModel()
        {

        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AnnotationId { get; private set; }
        public DateTime LastUpdate { get; protected set; }
        public DateTime CreateDate { get; protected set; }
    }
}

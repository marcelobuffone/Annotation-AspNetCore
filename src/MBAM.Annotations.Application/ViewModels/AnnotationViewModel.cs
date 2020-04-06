using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MBAM.Annotations.Application.ViewModels
{
    public class AnnotationViewModel
    {
        public AnnotationViewModel()
        {

        }

        [Key]
        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime LastUpdate { get; set; }

        public string LastTitle => FormatLongString(AnnotationHistory.OrderBy(e => e.CreateDate).LastOrDefault().Title);
        public string LastDescription => FormatLongString(AnnotationHistory.OrderBy(e => e.CreateDate).LastOrDefault().Description);

        public List<AnnotationHistoryViewModel> AnnotationHistory { get; set; }

        private string FormatLongString(string name)
        {
            if (name.Length < 25) return name;

            return $"{name.Substring(0, 24)}...";
        }
    }
}

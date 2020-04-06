using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MBAM.Annotations.Application.ViewModels;
using MBAM.Annotations.Application.Interfaces;
using MBAM.Annotations.Domain.Core.Notifications;

namespace MBAM.Annotations.Presentation.Controllers
{
    [Route("Annotations")]
    [Route("")]
    public class AnnotationsController : BaseController
    {
        private readonly IAnnotationAppService _annotationAppService;

        public AnnotationsController(IAnnotationAppService annotationAppService,
                                     IDomainNotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _annotationAppService = annotationAppService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(_annotationAppService.GetAll().OrderByDescending(e => e.LastUpdate));
        }

        [Route("Detail/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null) return NotFound();

            var annotationViewModel = _annotationAppService.GetById(id.Value);

            if (annotationViewModel == null) return NotFound();

            return View(annotationViewModel);
        }

        [Route("New")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("New")]
        public IActionResult Create(AnnotationHistoryViewModel annotationViewModel)
        {
            if (!ModelState.IsValid) return View(annotationViewModel);

             _annotationAppService.Register(annotationViewModel);
            
            if (IsValidOperation()) return RedirectToAction("Index");

            return View(annotationViewModel);
        }

        [Route("Edit/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annotationViewModel = _annotationAppService.GetLastHistoryByAnnotationId(id.Value);
            if (annotationViewModel == null)
            {
                return NotFound();
            }
            return View(annotationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id:guid}")]
        public IActionResult Edit(AnnotationHistoryViewModel annotationViewModel)
        {
            if (!ModelState.IsValid) return View(annotationViewModel);

            _annotationAppService.Update(annotationViewModel);

            if (IsValidOperation()) return RedirectToAction("Index");

            return View(annotationViewModel);
        }

        [Route("Delete/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var annotationViewModel = _annotationAppService.GetLastHistoryByAnnotationId(id.Value);

            if (annotationViewModel == null) return NotFound();

            return View(annotationViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id:guid}")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _annotationAppService.Remove(id);
            return RedirectToAction("Index");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Model;
using Microsoft.AspNetCore.Mvc;
using MVC_Frontend.Repositories;

namespace Assignment1.Controllers
{
    public class TrainingController : Controller
    {
        private IMyRepository _myRepository;

        public TrainingController(IMyRepository myRepository)
        {
            _myRepository = myRepository;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            var trainings = await _myRepository.GetAllTrainings();
            ViewBag.TotalDuration = trainings.Sum(t => t.Duration);
            return View(trainings);
        }


        // GET: Trainings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Training training)
        {
            if (ModelState.IsValid)
            {
                await _myRepository.AddTraining(training);
                return RedirectToAction(nameof(Index));
            }
            return View(training);
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var training = await _myRepository.GetTrainingById(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // DELETE: Trainings/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            var training = await _myRepository.GetTrainingById(id);
            if (training == null)
            {
                return NotFound();
            }
            await _myRepository.DeleteTraining(training.Id); // Änderung hier
            return RedirectToAction(nameof(Index));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Egzamin2023.Models;
using Egzamin2023.Services;

namespace Egzamin2023.Controllers
{
    public class ExamController : Controller
    {
        private readonly IDateProvider _dateProvider;
        private readonly NoteService _noteService;


        public ExamController(IDateProvider dateProvider, NoteService noteService)
        {
            _dateProvider = dateProvider;
            _noteService = noteService;
        }

        public IActionResult Index() => View(_noteService.GetAll().Where(x => x.Deadline > _dateProvider.CurrentDate.AddHours(1)).ToList());

        [HttpGet]
        public IActionResult Create() // pomieniamy "View() na Create(), tworzymy ścieżkę "Exam/Create.cshtml" w Views.
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (note.Deadline < _dateProvider.CurrentDate.AddHours(1))
                ModelState.AddModelError("Deadline", "Czas ważności musi być o godzinę późniejszy od bieżącego czasu!");

            if (ModelState.IsValid)
            {
                _noteService.Add(note);
                return RedirectToAction("Index");
            }


            return View(note);
        }

        public IActionResult Details(string id)
        {
            var target = _noteService.GetById(id);

            if (target is null)
                return BadRequest();

            return View(target);
        }
    }
}
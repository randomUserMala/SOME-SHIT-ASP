using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Egzamin2023.Models;
using Egzamin2023.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Egzamin2023.Controllers
{
    public class ExamController : Controller
    {
        private readonly IDateProvider _dateProvider;

        public ExamController(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }


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
                return RedirectToAction("Index");


            return View(note);
        }
    }
}
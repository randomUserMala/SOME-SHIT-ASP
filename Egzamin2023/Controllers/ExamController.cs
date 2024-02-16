using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Egzamin2023.Models;


namespace Egzamin2023.Controllers
{
    public class ExamController : Controller
    {
        [HttpGet]
        public IActionResult Create() // pomieniamy "View() na Create(), tworzymy ścieżkę "Exam/Create.cshtml" w Views.
        {
            return View();
        }
    }
}


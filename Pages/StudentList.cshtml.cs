using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace StudentTodo.Pages
{
    public class StudentList : PageModel
    {
        private readonly ILogger<StudentList> _logger;

        public StudentList(ILogger<StudentList> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}
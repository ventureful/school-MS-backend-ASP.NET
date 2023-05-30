using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTodo.Api.Models;

namespace StudentTodo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly DbSchoolManagementContext _schoolContext;

        public StudentController(DbSchoolManagementContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _schoolContext.TbStudentLists.ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _schoolContext.TbStudentLists.FirstOrDefaultAsync(s => s.StudentId == id);

            return Ok(student);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchByTitle([FromQuery] SearchTitle searchTitle)
        {
            Console.WriteLine(searchTitle.Title);
            // TestStudentRepository repository = new TestStudentRepository();
            var students = new List<TbStudentList>();

            if(searchTitle.Title == null) {
                students = await _schoolContext.TbStudentLists.ToListAsync();
            }
            else {
                students = await _schoolContext.TbStudentLists.Where(
                    s => s.StudentTitle.ToLower().Contains(searchTitle.Title.ToLower())
                ).ToListAsync();
            }

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(TbStudentList payload)
        {
            _schoolContext.TbStudentLists.Add(payload);
            await _schoolContext.SaveChangesAsync();

            return Ok(payload);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(TbStudentList payload)
        {
            _schoolContext.TbStudentLists.Update(payload);
            await _schoolContext.SaveChangesAsync();

            return Ok(payload);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var studentToDelete = await _schoolContext.TbStudentLists.FirstOrDefaultAsync(s => s.StudentId == id);

            if(studentToDelete == null) {
                return NotFound();
            }

            _schoolContext.TbStudentLists.Remove(studentToDelete);
            await _schoolContext.SaveChangesAsync();

            return Ok();
        }
    }
}   
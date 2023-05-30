using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentTodo.Api.Models
{
    [Table("tb_student")]
    public class Student : DbContext
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("student_name")]
        public string Name { get; set; }

        [Column("student_gender")]
        public Gender Gender { get; set; }

        // public IEnumerable<Gender>? AllGenders { get; set; }

        [Column("student_title")]
        public string? Title { get; set; }

        [Column("student_description")]
        public string? Description { get; set; }
    }
}
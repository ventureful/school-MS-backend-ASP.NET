using System;
using System.Collections.Generic;

namespace StudentTodo;

public partial class TbStudentList
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string? StudentTitle { get; set; }

    public string? StudentDescription { get; set; }

    public int StudentGender { get; set; }
}

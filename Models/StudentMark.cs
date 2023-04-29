using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp12.Models;

[Table("StudentMark")]
public partial class StudentMark
{
    [Key]
    public int StudentMarkId { get; set; }

    public int? StudentId { get; set; }

    public int? ExamId { get; set; }

    public Nullable<int> Markk { get; set; } 
    [ForeignKey("ExamId")]
    [InverseProperty("StudentMarks")]
    public virtual Exam? Exam { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentMarks")]
    public virtual Student? Student { get; set; }
}

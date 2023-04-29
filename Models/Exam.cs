using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp12.Models;

[Table("Exam")]
public partial class Exam
{
    [Key]
    public int ExamId { get; set; }

    public int? SubjectId { get; set; }

    //[StringLength(50)]
    //[Unicode(false)]
    public string Date { get; set; } 

    public short? Term { get; set; }

    [InverseProperty("Exam")]
    public virtual ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();

    [ForeignKey("SubjectId")]
    [InverseProperty("Exams")]
    public virtual Subject? Subject { get; set; }
}

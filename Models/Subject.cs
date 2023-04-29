using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp12.Models;

[Table("Subject")]
public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    public int? DepartmentId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SubjectName { get; set; }

    public int? MinimumDegree { get; set; }

    public short? Term { get; set; }

    public short? SubjectYear { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Subjects")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Subject")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}

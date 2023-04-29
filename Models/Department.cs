using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp12.Models;

[Table("Department")]
public partial class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DepartmentName { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("Department")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}

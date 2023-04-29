using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ConsoleApp12.Models;

[Table("Student")]
[Index("Phone", Name = "UQ__Student__5C7E359E556C7A58", IsUnique = true)]
[Index("Email", Name = "UQ__Student__A9D1053439A497ED", IsUnique = true)]
[Index("UserName", Name = "UQ__Student__C9F28456A8F49D69", IsUnique = true)]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    public int? RegisterDate { get; set; }//if DateTime i can not modify or let user enter a date..

    public int? DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Students")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();

    [InverseProperty("Subject")]
    public virtual ICollection<SubjectLecture> SubjectLectures { get; set; } = new List<SubjectLecture>();
    IQueryable<Student> student { get; set; } = null!;
    EntityQueryable<Student> students { get; set; }



    //public static implicit operator Student(Student v) => throw new NotImplementedException();
}

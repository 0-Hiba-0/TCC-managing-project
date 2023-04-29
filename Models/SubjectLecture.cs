using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp12.Models;

[Table("SubjectLecture")]
public partial class SubjectLecture
{
    [Key]
    public int SubjectLectureId { get; set; }

    public int? SubjectId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Title { get; set; }

    [Column(TypeName = "text")]
    public string? Context { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("SubjectLectures")]
    public virtual Student? Subject { get; set; }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DOOR.EF.Models;

[PrimaryKey("SectionId", "StudentId", "SchoolId")]
[Table("ENROLLMENT")]
[Index("StudentId", "SectionId", Name = "ENR_PK", IsUnique = true)]
[Index("SectionId", Name = "ENR_SECT_FK_I")]
public partial class Enrollment
{
    [Key]
    [Column("STUDENT_ID")]
    [Precision(8)]
    public int StudentId { get; set; }

    [Key]
    [Column("SECTION_ID")]
    [Precision(8)]
    public int SectionId { get; set; }

    [Column("ENROLL_DATE", TypeName = "DATE")]
    public DateTime EnrollDate { get; set; }

    [Column("FINAL_GRADE")]
    [Precision(3)]
    public byte? FinalGrade { get; set; }

    [Column("CREATED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("CREATED_DATE", TypeName = "DATE")]
    public DateTime CreatedDate { get; set; }

    [Column("MODIFIED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string ModifiedBy { get; set; } = null!;

    [Column("MODIFIED_DATE", TypeName = "DATE")]
    public DateTime ModifiedDate { get; set; }

    [Key]
    [Column("SCHOOL_ID")]
    [Precision(8)]
    public int SchoolId { get; set; }

    [InverseProperty("S")]
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    [ForeignKey("SectionId, SchoolId")]
    [InverseProperty("Enrollments")]
    public virtual Section S { get; set; } = null!;

    [ForeignKey("StudentId, SchoolId")]
    [InverseProperty("Enrollments")]
    public virtual Student SNavigation { get; set; } = null!;

    [ForeignKey("SchoolId")]
    [InverseProperty("Enrollments")]
    public virtual School School { get; set; } = null!;
}

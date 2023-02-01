﻿using System.Runtime.InteropServices;

namespace Qualminds.Ems.Core.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }
    public virtual Department? Department { get; set; } = null!;
}
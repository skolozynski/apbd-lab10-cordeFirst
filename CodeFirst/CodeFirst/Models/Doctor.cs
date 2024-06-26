﻿using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models;

public class Doctor
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
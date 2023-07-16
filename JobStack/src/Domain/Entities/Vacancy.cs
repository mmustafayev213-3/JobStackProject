﻿using JobStack.Domain.Common;


namespace JobStack.Domain.Entities;

public class Vacancy:BaseAuditableEntity
{
    public string TitleName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Salary { get; set; }
    public string Address { get; set; }
    public string? Experience { get; set; }
    public string? ResponsibilityName { get; set; }
    public string[]? ResponsibilitiesArray { get; set; }
    public string? SkillName { get; set; }
    public string[]? SkillsArray { get; set; }


    public int CategoryId { get; set; }
    public int JobTypeId { get; set; }
    public JobType JobType { get; set; }
    public Category Category { get; set; } = null!;

}

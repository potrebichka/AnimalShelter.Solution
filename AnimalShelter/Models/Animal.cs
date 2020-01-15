using System;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public int SpeciesId { get; set; }
    public virtual Species Species { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfAdmittance { get; set; }
    public string Breed { get; set; }
  }
}
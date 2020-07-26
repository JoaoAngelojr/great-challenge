using System;
using System.ComponentModel.DataAnnotations;

namespace great_challenge.Models
{
    public class User
    {
        public User() { }

        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(450, ErrorMessage = "The Name cannot exceed 450 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "The Cpf value cannot exceed 11 characters.")]  
        public string Cpf { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "The Rg value cannot exceed 13 characters.")] 
        public string Rg { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(450, ErrorMessage = "The Mother's name cannot exceed 450 characters.")]
        public string MothersName { get; set; }

        [Required]
        [StringLength(450, ErrorMessage = "The Father's name cannot exceed 450 characters.")]
        public string FathersName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
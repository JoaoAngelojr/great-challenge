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
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        public string Rg { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string MothersName { get; set; }

        [Required]
        public string FathersName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using PF.Core.Validation;

namespace PF.FooDomain.v1.Controllers.Data
{
    public class Patient
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [NotEmpty]
        public DateTimeOffset BirthDate { get; set; }

        public string EmailAddress { get; set; }

        [NotEmpty]
        public Guid PatientGuid { get; set; }

        public string SocialSecurityNumber { get; set; }
    }
}

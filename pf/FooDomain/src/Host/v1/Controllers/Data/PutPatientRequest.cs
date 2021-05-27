using System.ComponentModel.DataAnnotations;

namespace PF.FooDomain.v1.Controllers.Data
{
    public class PutPatientRequest
    {
        [Required]
        public Patient Patient { get; set; }
    }
}

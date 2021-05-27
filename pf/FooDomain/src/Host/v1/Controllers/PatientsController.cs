using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PF.FooDomain.v1.Controllers.Data;
using PF.Core.AspNetCore.Results;

namespace PF.FooDomain.v1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        [HttpGet("{patientGuid}")]
        public async Task<ActionResult<GetPatientResponse>> GetAsync(
            Guid patientGuid,
            CancellationToken cancellationToken = default)
        {
            return Ok(
                new GetPatientResponse
                {
                    Patient = new Patient
                    {
                        FirstName = "Tyrion",
                        LastName = "Lannister",
                        BirthDate = DateTimeOffset.UtcNow.Date.AddYears(-48),
                        EmailAddress = "tyrion-lannister@not-real.com",
                        PatientGuid = patientGuid,
                        SocialSecurityNumber = "123-12-1234"
                    }
                });
        }

        [HttpPost]
        [ProducesResponseType(typeof(PostPatientResponse), 201)]
        public async Task<ActionResult<PostPatientResponse>> PostAsync(
            [FromBody] PostPatientRequest request,
            CancellationToken cancellationToken = default)
        {
            return Created(
                $"/api/v1/patients/{request.Patient.PatientGuid}",
                new PostPatientResponse
                {
                    Patient = new Patient
                    {
                        FirstName = request.Patient.FirstName,
                        LastName = request.Patient.LastName,
                        BirthDate = request.Patient.BirthDate,
                        EmailAddress = request.Patient.EmailAddress,
                        PatientGuid = request.Patient.PatientGuid,
                        SocialSecurityNumber = request.Patient.SocialSecurityNumber
                    }
                });
        }

        [HttpPut("{patientGuid}")]
        public async Task<ActionResult<PutPatientResponse>> PutAsync(
            Guid patientGuid,
            [FromBody] PutPatientRequest request,
            CancellationToken cancellationToken = default)
        {
            if (patientGuid != request.Patient.PatientGuid)
            {
                return ErrorResult.BadRequest(
                    $"Patient guid provided in url parameter ({patientGuid}) must match what is specified in the request body ({request.Patient.PatientGuid}).",
                    "ModelValidationError");
            }

            return Ok(
                new PutPatientResponse
                {
                    Patient = new Patient
                    {
                        FirstName = request.Patient.FirstName,
                        LastName = request.Patient.LastName,
                        BirthDate = request.Patient.BirthDate,
                        EmailAddress = request.Patient.EmailAddress,
                        PatientGuid = request.Patient.PatientGuid,
                        SocialSecurityNumber = request.Patient.SocialSecurityNumber
                    }
                });
        }
    }
}

using EAppointment.Application.Commons.Results;
using EAppointment.Application.Features.Auths.Commands.Login;
using EAppointment.Application.Features.Auths.DTOs;
using EAppointment.Application.Features.Doctors.Commands.Create;
using EAppointment.Application.Features.Doctors.Commands.Delete;
using EAppointment.Application.Features.Doctors.Commands.Update;
using EAppointment.Application.Features.Doctors.Queries.GetAll;
using EAppointment.WebAPI.Abstractions;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace EAppointment.WebAPI.Controllers
{
    public sealed class DoctorsController(IMediator _mediator) : ApiController(_mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute]GetAllDoctorQueryRequest getAllDoctorQueryRequest, CancellationToken cancellationToken)
        {
            Result<List<Application.Features.Doctors.DTOs.GetAllDoctorDTO>> response = await _mediator.Send(getAllDoctorQueryRequest, cancellationToken);
            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDoctorCommandRequest createDoctorCommandRequest, CancellationToken cancellationToken)
        {
            Result<Application.Features.Doctors.DTOs.DoctorDTO> response = await _mediator.Send(createDoctorCommandRequest, cancellationToken);
            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpDelete("/api/[controller]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteDoctorCommandRequest deleteDoctorCommandRequest, CancellationToken cancellationToken)
        {
            Result<string> response = await _mediator.Send(deleteDoctorCommandRequest, cancellationToken);
            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDoctorCommandRequest updateDoctorCommandRequest, CancellationToken cancellationToken)
        {
            Result<Application.Features.Doctors.DTOs.DoctorDTO> response = await _mediator.Send(updateDoctorCommandRequest, cancellationToken);
            return StatusCode((int)response.HttpStatusCode, response);
        }
    }
}

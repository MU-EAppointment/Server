using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Application.Commons.Results;
using EAppointment.Application.Features.Doctors.DTOs;
using EAppointment.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace EAppointment.Application.Features.Doctors.Queries.GetAll
{
    public sealed record GetAllDoctorQueryRequest() : IRequest<Result<List<GetAllDoctorDTO>>>;

    internal sealed class GetAllDoctorQueryHandler(IQueryRepository<Doctor> _doctorQueryRepository) : IRequestHandler<GetAllDoctorQueryRequest, Result<List<GetAllDoctorDTO>>>
    {
        public async ValueTask<Result<List<GetAllDoctorDTO>>> Handle(GetAllDoctorQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllDoctorDTO>? doctors = await _doctorQueryRepository.GetAll().Where(d => d.IsActive).OrderBy(d => d.Department).ThenBy(d => d.FirstName).ProjectToType<GetAllDoctorDTO>().ToListAsync(cancellationToken);

            return Result<List<GetAllDoctorDTO>>.Success(doctors);
        }
    }
}

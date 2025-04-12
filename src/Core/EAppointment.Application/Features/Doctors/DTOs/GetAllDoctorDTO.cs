using EAppointment.Domain.Enums;

namespace EAppointment.Application.Features.Doctors.DTOs
{
    public readonly record  struct GetAllDoctorDTO(Guid Id, string FirstName, string LastName, string Department, string FullName);
}

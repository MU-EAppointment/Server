using EAppointment.Application.Features.Doctors.Commands.Create;
using EAppointment.Application.Features.Doctors.Commands.Update;
using EAppointment.Application.Features.Doctors.DTOs;
using EAppointment.Domain.Entities;
using EAppointment.Domain.Enums;
using Mapster;

namespace EAppointment.Application.Features.Doctors.Mappings
{
    internal sealed class DoctorMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Doctor, GetAllDoctorDTO>()
                .Map(dest => dest.Department, src => src.Department);

            config.NewConfig<CreateDoctorCommandRequest, Doctor>()
                .Map(dest => dest.Department, src => DepartmentEnum.FromValue(src.Department));

            config.NewConfig<UpdateDoctorCommandRequest, Doctor>()
                .Map(dest => dest.Department, src => DepartmentEnum.FromValue(src.Department));
        }
    }
}

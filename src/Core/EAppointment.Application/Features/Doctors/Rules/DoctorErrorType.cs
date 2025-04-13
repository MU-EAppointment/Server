using EAppointment.Application.Abstractions.Commons.Exceptions;
using EAppointment.Application.Commons.Exceptions;

namespace EAppointment.Application.Features.Doctors.Rules
{
    public readonly record struct DoctorErrorType(byte Code, string Message) : IErrorType
    {
        public static readonly ErrorType DoctorNotFound = new(020, "Doctor Not Found");
    }
}

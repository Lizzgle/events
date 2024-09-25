using AutoMapper;
using Events.Application.Users.Commands.Registration;
using Events.Domain.Entities;

namespace Events.Application.Common.Mapper.UserMapping
{
    public class RegistrationCommandToUser : Profile
    {
        public RegistrationCommandToUser() 
        {
            CreateMap<RegistrationCommand, User>();
        }
    }
}

using AutoMapper;
using Events.Application.Users.Commands.Registration;
using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

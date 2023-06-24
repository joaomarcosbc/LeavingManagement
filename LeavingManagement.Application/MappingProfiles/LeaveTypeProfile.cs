using AutoMapper;
using LeavingManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using LeavingManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using LeavingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavingManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDTO, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
        }
    }
}

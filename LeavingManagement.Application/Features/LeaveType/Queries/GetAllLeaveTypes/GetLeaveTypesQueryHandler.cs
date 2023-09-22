﻿using AutoMapper;
using LeavingManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavingManagement.Application.Logging;

namespace LeavingManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger; 

        public GetLeaveTypesQueryHandler(
            IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            // 1- Query the database
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();

            // 2- Convert data objects to DTO objects
            var data = _mapper.Map<List<LeaveTypeDTO>>(leaveTypes);

            // 3- Return lis of DTO objects
            _logger.LogInformation("Leave types were retrieved successfully.");
            return data;
        }
    }
}

using AutoMapper;
using LeavingManagement.Application.Contracts.Persistence;
using LeavingManagement.Application.Exceptions;
using MediatR;

namespace LeavingManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // 1- Validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid LeaveType", validationResult);
            }

            // 2- Convert to Domain Entity object
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

            // 3- Add to Database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            // 4 - Return record Id
            return leaveTypeToCreate.Id;
        }
    }
}

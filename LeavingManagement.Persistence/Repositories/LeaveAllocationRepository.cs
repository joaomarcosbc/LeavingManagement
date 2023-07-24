using LeavingManagement.Application.Contracts.Persistence;
using LeavingManagement.Domain;
using LeavingManagement.Persistence.DatabaseContext;

namespace LeavingManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(LeavingManagementDatabaseContext context) : base(context)
        {
        }
    }
}

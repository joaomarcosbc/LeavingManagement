using LeavingManagement.Application.Contracts.Persistence;
using LeavingManagement.Domain;
using LeavingManagement.Persistence.DatabaseContext;

namespace LeavingManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(LeavingManagementDatabaseContext context) : base(context)
        {
        }
    }
}

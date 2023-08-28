using LeavingManagement.Application.Models.Email;

namespace LeavingManagement.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}

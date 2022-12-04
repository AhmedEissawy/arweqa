using System.Threading.Tasks;

namespace OA.Service.Interfaces.Infrastructure
{
    public interface IOtpService
    {
        Task<bool> SendConfirmationCode(string phone);
        Task<bool> ValidateConfirmationCode(string phone,string code);
    }
}

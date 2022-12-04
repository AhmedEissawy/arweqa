using Microsoft.AspNetCore.Identity;
using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces.Infrastructure
{
    public interface IJwtGenerator
    {
        Task<string> CreateTokenAsync(ApplicationUser user);
    }
}

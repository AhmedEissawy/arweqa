using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Interfaces
{
    public interface IUserAccessor
    {
        string GetCurrentUserId();
    }
}

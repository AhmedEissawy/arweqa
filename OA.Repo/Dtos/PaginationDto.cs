using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Dtos
{
    public class PaginationDto
    {
        public int PageSize { get; set; } = 30;

        public int PageNo { get; set; } = 1;
    }
}
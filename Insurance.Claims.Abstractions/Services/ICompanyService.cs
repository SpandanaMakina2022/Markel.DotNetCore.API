using Insurance.Claims.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Claims.Abstractions.Services
{
    public interface ICompanyService
    {
        Task<Company> Get(int id);
    }
}

using UAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Repositories
{
    public interface ITestReadRepository: IReadRepository<Test,int>
    {
    }
}

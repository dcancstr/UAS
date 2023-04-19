using UAS.Application.Repositories;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Persistence.Repositories;

namespace UAS.Persistence.Repositories
{
    public class TestReadRepository : ReadRepository<Test,int>, ITestReadRepository
    {
        public TestReadRepository(UASDbContext context) : base(context)
        {
        }
    }
}

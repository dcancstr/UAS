using UAS.Application.Repositories;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.Repositories
{
    public class TestWriteRepository : WriteRepository<Test,int>, ITestWriteRepository
    {
        public TestWriteRepository(UASDbContext context) : base(context)
        {
        }
    }
}

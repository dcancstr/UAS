using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
namespace UAS.Domain.Entities.Common
{
    //[Index(nameof(Id), IsUnique = true)]
    public class BaseEntity<TKey>
    {
        //[Key] 
        public TKey Id { get; set; }
        public DateTime CDate { get; set; }
        public DateTime EDate { get; set; }
        public bool Deleted { get; set; } = false;
        public long CreateUserIdentityId { get; set; } = 0;
        public long ChangeUserIdentityId { get; set; } = 0;
        public long RecordStatusId { get; set; } = 0;
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public bool IfTransferredToSecondary { get; set; } = false;

    }
}

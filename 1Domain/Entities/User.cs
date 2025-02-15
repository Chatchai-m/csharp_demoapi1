using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Domain.Entities
{
    public class User : _BaseEntity, _IBaseEntity
    {
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? is_active { get; set; }
        public ICollection<Token> Tokens { get; }

        [StringLength(255)]
        public string email { get; set; }
        [StringLength(255)]
        public string password { get; set; }
        [StringLength(255)]
        public string? firstname { get; set; }
        [StringLength(255)]
        public string? lastname { get; set; }
        [StringLength(1000)]
        public string roles { get; set; }  // multi-select [ADMIN, ACCOUNTING, FINANCE, USER ]
        public string? info { get; set; }
    }
}

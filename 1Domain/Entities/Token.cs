using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Domain.Entities
{
    public class Token : _BaseEntity, _IBaseEntity
    {
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? is_active { get; set; }
        public User User { get; set; }
        [StringLength(255)]
        public string token { get; set; }
        public int time_out { get; set; } // unit  minute
        public string? ip_address { get; set; }
        [StringLength(20)]
        public string status { get; set; } // ['ACTIVE', 'COMPLETED', 'INACTIVE', 'EXPIRED']

        [StringLength(255)]
        public string app_name { get; set; }
        public Int64 user_id { get; set; }
    }
}

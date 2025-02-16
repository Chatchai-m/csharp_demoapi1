using System.ComponentModel.DataAnnotations;

namespace _1Domain.Entities
{
    public class Car : _BaseEntity, _IBaseEntity
    {
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        [StringLength(255)]
        public string? model { get; set; }
        public int? year { get; set; }
        [StringLength(255)]
        public string? plate_no { get; set; }

    }
}

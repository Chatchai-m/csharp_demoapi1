using _1Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Core.Interfaces.Services
{
    public interface ICarService
    {
        Task<bool> UpsertCarAsync(CarDTO dto);

    }

    public class CarDTO
    {
        public Int64 id { get; set; }
        public string? model { get; set; }
        public int? year { get; set; }
        public string? plate_no { get; set; }
    }

}

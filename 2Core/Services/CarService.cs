using _2Core.Interfaces.Infra.Database;
using _2Core.Interfaces.Services;
using _1Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Core.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitWork _unitWork;
        private readonly IDateTimeService _dateTimeService;
        public CarService(IUnitWork unitWork, IDateTimeService dateTimeService)
        {
            _unitWork = unitWork;
            _dateTimeService = dateTimeService;
        }

        public async Task<bool> UpsertCarAsync(CarDTO dto)
        {
            DateTime dateTime = _dateTimeService.Now;
            Car car_instance = _unitWork.CarRepository.GetQueryable().Where(x => x.id == dto.id).FirstOrDefault();

            if (car_instance == null)
            {
                car_instance = new Car();
                car_instance.created_at = dateTime;
            }
            car_instance.updated_at = dateTime;
            car_instance.model = dto.model;
            car_instance.year = dto.year;
            car_instance.plate_no = dto.model;
            await _unitWork.CarRepository.InsertOrUpdateAsynce(car_instance);
            return true;
        }
    }
}

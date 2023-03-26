using System;
using System.Runtime.ConstrainedExecution;
using PT_WEB_API_SDM.Data;
using PT_WEB_API_SDM.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PT_WEB_API_SDM.Services
{
	public class CarService
	{
		private readonly CarRepository _carRepository;
		public CarService(CarRepository carRepository)
		{
			_carRepository = carRepository;
		}
		public async Task<IEnumerable<Car>> GetAllCars()
		{
			var cars = await _carRepository.GetAllCars();
			if (cars.Count() == 0)
			{
				throw new Exception("No se encontraron carros en la base de datos");
			}
			if (cars.Any(c => c == null))
			{
				throw new Exception("Se encontraron carros nulos en la lista.");
			}
			return cars;
		}
		public async Task<Car> GetcarById(int id)
		{
			var car = await _carRepository.GetCarById(id);
			if (car == null)
			{
				throw new Exception($"El carro con el id: {id} no se encontro en la base de datos");
			}
			return car;
		}
		public async Task CreateCar(Car car)
		{
			if (car == null)
			{
				throw new ArgumentException("El objeto car recibido es nulo");
			}
			if (car.Year < 1900 || car.Year > DateTime.Now.Year + 2)
			{
				throw new ArgumentException("El año del vehículo no representa un valor válido para el sistema", nameof(car.Year));
			}
			if (car.Price < 0)
			{
				throw new ArgumentException("El precio del vehículo no puede ser menor a 0", nameof(car.Price));
			}
			await _carRepository.CreateCar(car);
		}

		public async Task UpdateCar(int id, Car updateCar)
		{
			var car = await _carRepository.GetCarById(id);
			if (car == null)
			{
				throw new Exception("No se encontró ese carro en la base de datos");
			}
			if (id <= 0)
			{
               throw new Exception("El id del carro no es válido");
            }
			if(id != car.Id)
			{
				throw new Exception("El id no coincide");
			}
            if (updateCar.Year < 1900 || updateCar.Year > DateTime.Now.Year + 2)
            {
                throw new ArgumentException("El año del vehículo no representa un valor válido para el sistema", nameof(car.Year));
            }
            if (updateCar.Price < 0)
            {
                throw new ArgumentException("El precio del vehículo no puede ser menor a 0", nameof(car.Price));
            }

			car.Brand = updateCar.Brand;
			car.Model = updateCar.Model;
			car.Year = updateCar.Year;
			car.Price = updateCar.Price;
			car.StatusIsNew = updateCar.StatusIsNew;
			car.Image = updateCar.Image;
            await _carRepository.UpdateCar(car);
        }
        public async Task DeleteCar(int id)
		{
            var carExists = await _carRepository.GetCarById(id);
            if (carExists == null)
            {
                throw new Exception($"No se encontró ese carro en la base de datos con el id {id}");
            }
            if (id <= 0)
            {
                throw new Exception("El id suministrado no es válido");
            }
            await _carRepository.DeleteCar(id);

        }
		public async Task<List<Car>> SearchCarByBrandAndModel(string brand, string model)
		{

			 return await _carRepository.SearchCarByBrandAndModel(brand, model);
        }
	}
}


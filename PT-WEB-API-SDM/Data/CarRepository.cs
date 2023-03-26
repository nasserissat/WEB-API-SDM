using System;
using Microsoft.EntityFrameworkCore;
using PT_WEB_API_SDM.Models;

namespace PT_WEB_API_SDM.Data
{
	public class CarRepository
	{
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
		{
            _context = context;
        }
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }
        public async Task<Car> GetCarById(int id)
        {
            return await _context.Cars.FindAsync(id);
             
        }
        public async Task CreateCar(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCar(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if(car == null)
            {
                throw new InvalidOperationException($"No se pudo encontrar el carro con el ID {id}");
            }
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
	}
}


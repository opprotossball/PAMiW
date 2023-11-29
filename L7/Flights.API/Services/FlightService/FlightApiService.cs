﻿using Microsoft.EntityFrameworkCore;
using P02Travel.API.Models;
using P03Travel.Shared;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;
using System;

namespace P02Travel.API.Services.FlightService
{
    public class FlightApiService : IFlightService
    {
        private readonly DataContext _dataContext;

        public FlightApiService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<Flight>> GetFlightAsync(int id)
        {
            try
            {
                var flights = await _dataContext.Flights
                    .Where(x => x.Id == id)
                    .ToListAsync();
                if (flights.Count == 0)
                {
                    return new ServiceResponse<Flight>()
                    {
                        Data = null,
                        Message = $"Flight with id {id} does not exist",
                        Success = false
                    };
                }
                return new ServiceResponse<Flight>()
                {
                    Data = flights.FirstOrDefault(),
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<Flight>()
                {
                    Data = null,
                    Message = "Cannot get flight",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Flight>> AddFlightAsync(Flight flight)
        {
            try
            {
                _dataContext.Flights.Add(flight);
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Flight>() { Data = flight, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Flight>()
                {
                    Data = flight,
                    Message = "Cannot create flight",
                    Success = false
                };
            };
        }

        public async Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int num)
        {
            try
            {
                var flights = await _dataContext.Flights
                    .Take(num)
                    .ToListAsync();
                return new ServiceResponse<List<Flight>>()
                {
                    Data = flights,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Flight>>()
                {
                    Data = null,
                    Message = "Cannot get flights",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Flight>> ModifyFlightAsync(Flight flight)
        {
            try
            {
                var edited = new Flight() { Id = flight.Id };
                _dataContext.Flights.Attach(edited);
                edited.Airlines = flight.Airlines;
                edited.From = flight.From;
                edited.To = flight.To;
                edited.Price = flight.Price;
                edited.DepartureTime = flight.DepartureTime;
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Flight> { Data = edited, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Flight>
                {
                    Data = null,
                    Success = false,
                    Message = "Cannot update flight"
                };
            }
        }

        public async Task<ServiceResponse<bool>> DeleteFlightAsync(int id)
        {
            var flight = new Flight() { Id = id };
            _dataContext.Flights.Attach(flight);
            _dataContext.Flights.Remove(flight);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<bool> { Success = true, Data = true };
        }

        public async Task<ServiceResponse<List<Flight>>> GetFromToAsync(string from, string to)
        {
            try
            {
                var flights = await _dataContext.Flights
                    .Where(x => x.From == from && x.To == to)
                    .ToListAsync();
                return new ServiceResponse<List<Flight>>()
                {
                    Data = flights,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Flight>>()
                {
                    Data = null,
                    Message = $"Cannot get flights for this relation",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<List<Flight>>> SearchFlightsAsync(string searchTerm, int page, int pageSize)
        {
            IQueryable<Flight> query = _dataContext.Flights;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => (x.Airlines.Contains(searchTerm) || x.From.Contains(searchTerm) || x.To.Contains(searchTerm)));
            }
            var flights = await query
                .Skip(pageSize * page)
                .Take(pageSize)
                .ToListAsync();
            try
            {
                var response = new ServiceResponse<List<Flight>>()
                {
                    Data = flights,
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Flight>>()
                {
                    Data = null,
                    Message = "Cannot get flights",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int page, int pageSize)
        {
            try
            {
                var flights = await _dataContext.Flights
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToListAsync();
                return new ServiceResponse<List<Flight>>()
                {
                    Data = flights,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Flight>>()
                {
                    Data = null,
                    Message = "Cannot get flights",
                    Success = false
                };
            }
        }

    }
}

using DevTrustTest.Interfaces;
using DevTrustTest.Models;
using System.Collections.Generic;
using System;
using DevTrustTest.Enums;
using System.Threading.Tasks;

namespace DevTrustTest.Services;

internal class DummyCarDataService : ICarDataService
{
    public async Task<List<CarModel>> GetCarData()
    {
        var data = new List<CarModel>();
        for (var i = 0; i < 15; i++)
        {
            data.Add(new CarModel
            {
                CarId = Random.Shared.Next(1_000, 1_000_000),
                Number = $"BC{Random.Shared.Next(1000, 9999)}HC",
                Mark = (Random.Shared.Next(0, 5)) switch
                {
                    0 => "Mercedes-Benz",
                    1 => "Toyota",
                    2 => "Nissan",
                    3 => "BMW",
                    4 => "Ford",
                    _ => "Mercedes-Benz"
                },
                CarType = (Random.Shared.Next(0, 4)) switch
                {
                    0 => CarType.Sedan,
                    1 => CarType.Pickup,
                    2 => CarType.Hatchback,
                    3 => CarType.Coupe,
                    _ => CarType.Sedan
                },
                CreateDate = new DateOnly(Random.Shared.Next(2012, 2023), Random.Shared.Next(1, 13), Random.Shared.Next(1, 31))
            });
        }
        return data;
    }
}

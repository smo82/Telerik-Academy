using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;
using CarRentalSystem.Data;
using CarRentalSystem.Models;

namespace CarRentalSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarRentalSystem.Data.CarRentalSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CarRentalSystemContext context)
        {
            List<CarState> carStates = context.States.ToList();
            if (carStates.Count == 0)
            {
                string[] states = new string[] { "free", "rented" };

                foreach (string state in states)
                {
                    CarState carState = new CarState()
                    {
                        Value = state
                    };

                    context.States.Add(carState);
                }

                context.SaveChanges();
            }

            CarState carFreeState = context.States.FirstOrDefault(cs => cs.Value == "free");
            List<Store> stores = context.Stores.ToList();
            if (stores.Count == 0)
            {
                string[] storeNames = new string[] { "Store1", "Store2", "Store3" };

                foreach (string storeName in storeNames)
                {
                    Store store = new Store()
                    {
                        Name = storeName,
                        Latitude = 23.333m,
                        Longitude = 41.111m
                    };

                    context.Stores.Add(store);

                    for (int i = 0; i < 5; i++)
                    {
                        Car car = new Car()
                        {
                            Make = "CarMake" + i,
                            Model = "Model" + i,
                            Year = 1982 + i,
                            Power = 74 + i*10,
                            Engine = 2000 + i*100,
                            Store = store,
                            State = carFreeState
                        };

                        context.Cars.Add(car);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}

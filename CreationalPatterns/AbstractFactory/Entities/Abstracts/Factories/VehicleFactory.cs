﻿using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Factories
{
    //Abstract Factory Abstraction
    public abstract class VehicleFactory : IVehicleFactory
    {
        public abstract Car CreateCar();
        public abstract Airplane CreateAirplane();
        public abstract Ship CreateShip();
    }
}

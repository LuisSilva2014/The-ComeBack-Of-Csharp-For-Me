using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LuisPracticeCsharp2026
{

    interface IVehicle
    {
        public void StopEngine();
    }

    public abstract class Vehicle : IVehicle
    {
        public abstract int Id { get; set; }
        public abstract string Brand { get; set; }
        public abstract string Model { get; set; }
        public abstract int Year { get; set; }

        // constructior 
        public Vehicle(int? id, string? brand, string? model, int? year)
        {
            this.Id = id ?? -1;
            this.Brand = brand ?? string.Empty;
            this.Model = model ?? string.Empty; // This should not work for those who called it
            this.Year = year ?? -1;
        }

        public abstract void StartEngine();
        public void StopEngine() // contract
        {
            return;
        }
        public virtual void DisplayInfo()
        {

        }


        //        StartEngine() must be abstract.
        //StopEngine() should be implemented in the base class.
        //DisplayInfo() should be virtual.
    }


    //dERIVED CLASS
    public class xCar : Vehicle
    {
        public override int Id { get; set; }
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override int Year { get; set; }
        public xCar(int? id = null, string? brand = null, string? model = null, int? year = null)
            : base(id, brand, model, year) // the base class is demanding the values to be there instanciated as well
        {
            //base(id, brand, model, year);
            this.Id = id ?? -1;
            this.Brand = brand ?? string.Empty;
            this.Model = model ?? string.Empty; // This should not work for those who called it
            this.Year = year ?? -1;
            base.StopEngine();

            //return IMPORTANT:	A Constructors have no return type
        }
        public override void StartEngine()
        {
            Console.WriteLine("Car engine started with push button.");
        }
    }

    public class xTruck : Vehicle
    {
        public override int Id { get; set; }
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override int Year { get; set; }
        public xTruck(int id, string brand, string model, int year)
            : base(id, brand, model, year) // the base class is demanding the values to be there instanciated as well
        {
            //base(id, brand, model, year);
            this.Id = id;
            this.Brand = brand;
            this.Model = model; // This should not work for those who called it
            this.Year = year;

            base.StopEngine();

            //return IMPORTANT:	A Constructors have no return type
        }
        public override void StartEngine()
        {
            Console.WriteLine("Truck diesel engine started.");
        }
    }
    class xMotorcycle : Vehicle
    {
        public override int Id { get; set; }
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override int Year { get; set; }
        public xMotorcycle(int id, string brand, string model, int year)
            : base(id, brand, model, year) // the base class is demanding the values to be there instanciated as well
        {
            //base(id, brand, model, year);
            this.Id = id;
            this.Brand = brand;
            this.Model = model; // This should not work for those who called it
            this.Year = year;

            base.StopEngine();

            //return IMPORTANT:	A Constructors have no return type
        }
        public override void StartEngine()
        {
            Console.WriteLine("Motorcycle engine started with kick start.");
        }
    }


    public class VehicleManager
    {
        public List<Vehicle> List = [];

        public void Add(Vehicle item)
        {
            List.Add(item);
        }

        public bool Remove(int id)
        {
            Vehicle item = FindVehicle(id);
            if (item != null)
            {
                List.Remove(item);
                return true;
            }
            return false;
        }

        public Vehicle FindVehicle(int id)
        {
            Vehicle item = List.First(t => t.Id == id);
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public void DisplayAllVehicles()
        {
            foreach (Vehicle item in List)
            {
                Console.WriteLine($"{item.Id} {item.Brand} {item.Model} {item.Year}");
            }
        }


    }


}
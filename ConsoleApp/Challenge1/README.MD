Let's do Challenge #1: Vehicle Management System, but I'll present it like a real coding exercise so you can solve it yourself before looking at a solution.

Problem Statement

Build a Vehicle Management System using inheritance and polymorphism.

Step 1: Create an Abstract Base Class

Create an abstract class called Vehicle.

Properties
int Id
string Brand
string Model
int Year

Constructor

The constructor should initialize all properties.

Methods
StartEngine()
StopEngine()
DisplayInfo()


Requirements:

StartEngine() must be abstract.
StopEngine() should be implemented in the base class.
DisplayInfo() should be virtual.
Step 2: Create Derived Classes

Create the following classes:

Car
Truck
Motorcycle


Each class inherits from Vehicle.

Car

Override:

StartEngine()


Output:

Car engine started with push button.

Truck

Override:

StartEngine()


Output:

Truck diesel engine started.

Motorcycle

Override:

StartEngine()


Output:

Motorcycle engine started with kick start.

Step 3: Create VehicleManager

Create a class called:

VehicleManager


Store vehicles in:

List<Vehicle>


Implement:

AddVehicle(Vehicle vehicle)
RemoveVehicle(int id)
FindVehicle(int id)
DisplayAllVehicles()

Step 4: Test Program

Create the following vehicles:

Toyota Camry 2022
Ford F150 2023
Honda CBR 2024


Add them to the manager.

Then:

Display all vehicles
Start all engines
Find vehicle with Id = 2
Remove vehicle with Id = 1
Display all vehicles again
Expected Output
Vehicle Added: Toyota Camry
Vehicle Added: Ford F150
Vehicle Added: Honda CBR

ID:1 Brand:Toyota Model:Camry Year:2022
ID:2 Brand:Ford Model:F150 Year:2023
ID:3 Brand:Honda Model:CBR Year:2024

Car engine started with push button.
Truck diesel engine started.
Motorcycle engine started with kick start.

Found Vehicle:
ID:2 Brand:Ford Model:F150 Year:2023

Vehicle Removed.

Remaining Vehicles:
ID:2 Brand:Ford Model:F150 Year:2023
ID:3 Brand:Honda Model:CBR Year:2024

Bonus Challenges (Harder)

After you finish the basic version, add:

Bonus 1

Add a property:

decimal FuelLevel


Prevent starting the engine when fuel is 0.

Bonus 2

Add another derived class:

ElectricCar


With:

BatteryLevel


Instead of fuel.

Bonus 3

Add interface:

IMaintainable

void Service();


Implement it in all vehicle types.

Bonus 4 (Senior Level)

Create:

Garage<T>


using Generics.

Example:

Garage<Car>
Garage<Truck>


Only vehicles of that type can be stored.

UML Diagram
          Vehicle (abstract)
          -----------------
          Id
          Brand
          Model
          Year
          -----------------
          StartEngine()
          StopEngine()
          DisplayInfo()

               ▲
     ┌─────────┼─────────┐
     │         │         │
    Car      Truck   Motorcycle

               │
               ▼

         VehicleManager
         --------------
         List<Vehicle>
         AddVehicle()
         RemoveVehicle()
         FindVehicle()
         DisplayAllVehicles()


💡 Rule: Try solving it without using if (vehicle is Car) or switch statements. Use pure inheritance and polymorphism. That's where the real OOP learning happens.
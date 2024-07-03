# Garage Management System 

This project is a garage management system implemented in C#. It allows for the registration, management, and servicing of vehicles in a garage.

## Features

- **Register a New Vehicle**: Add new vehicles to the garage.
- **List License Numbers**: Display all vehicle license numbers in the garage.
- **Filter by Status**: Display vehicle license numbers filtered by their status.
- **Change Vehicle Status**: Update the status of specific vehicles.
- **Inflate Wheels**: Inflate the wheels of a vehicle to their maximum.
- **Refuel Vehicles**: Refuel gasoline-powered vehicles.
- **Charge Vehicles**: Charge electric vehicles.
- **View Vehicle Details**: Display full details of a specific vehicle.

## Classes

The project consists of several classes:

- **Vehicle**: An abstract class that represents a vehicle in the garage.
  - **Car**, **Motorcycle**, **Truck**: Classes that inherit from Vehicle and represent specific types of vehicles.
- **Engine**: An abstract class that represents an engine in a vehicle.
  - **ElectricEngine**, **FuelEngine**: Classes that inherit from Engine and represent specific types of engines.
- **GarageManager**: A class that manages the operations in the garage.
- **GarageCard**: A class that holds the owner's details and the vehicle's status.
- **RegisteredVehicle**: A class that represents a vehicle registered in the garage.
- **IPropertyHolder**: An interface implemented by Vehicle and GarageCard.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/ilaish/Garage-Management-System.git
    ```
2. Navigate to the project directory:
    ```bash
    cd Garage-Management-System
    ```
3. Open the solution file in your preferred C# IDE (like Visual Studio).
4. Build and run the project.

## Diagram of the Design

![solutionDiagram](https://github.com/ilaish/Garage-Management-System/assets/47937649/dbfa1383-29fa-4b1f-8d6c-6e9670b82593)

## Usage

Follow the prompts in the console application to manage the vehicles in the garage.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License.

---

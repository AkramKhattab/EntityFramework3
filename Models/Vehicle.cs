namespace MyBackendProject.Models
{
    #region Inheritance Example

    // Base class for vehicles
    public abstract class Vehicle
    {
        // Primary key for the Vehicle entity
        public int Id { get; set; }

        // Brand of the vehicle
        public string Brand { get; set; }

        // Model of the vehicle
        public string Model { get; set; }

        // Year of manufacture
        public int Year { get; set; }

        // Abstract method to be implemented by derived classes
        public abstract string GetVehicleType();
    }

    #endregion
}
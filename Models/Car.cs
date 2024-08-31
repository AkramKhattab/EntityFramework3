namespace MyBackendProject.Models
{
    #region Inheritance Example

    // Car class inheriting from Vehicle
    public class Car : Vehicle
    {
        // Number of doors the car has
        public int NumberOfDoors { get; set; }

        // Implementation of the abstract method from Vehicle
        public override string GetVehicleType()
        {
            return "Car";
        }
    }

    #endregion
}
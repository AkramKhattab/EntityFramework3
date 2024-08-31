namespace MyBackendProject.Models
{
    #region Inheritance Example

    // Motorcycle class inheriting from Vehicle
    public class Motorcycle : Vehicle
    {
        // Type of the motorcycle (e.g., Sport, Cruiser, etc.)
        public string MotorcycleType { get; set; }

        // Implementation of the abstract method from Vehicle
        public override string GetVehicleType()
        {
            return "Motorcycle";
        }
    }

    #endregion
}
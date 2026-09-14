using System.Globalization;

namespace OOP_01
{
    internal class Program
    {
        internal struct DeliveryAddress
        {
            public string City;
            public string Street;
            public int BuildingNumber;

            public DeliveryAddress(string city, string street, int buildingNumber)
            {
                City = city;
                Street = street;
                BuildingNumber = buildingNumber;
            }
            public string GetFullAddress()
            {
                return $"{BuildingNumber} {Street} ,{City}";
            }

        }
        internal struct Shipment
        {
            int TrackingCode;
            string Description;
            int Weight;
            decimal DeliveryFee;

            public string GetDestination(DeliveryAddress adress)
            {
                return (adress.GetFullAddress());

            }
            public void SetTrackingCode(int trackingCode)
            {
                if (trackingCode > 0)
                {
                    TrackingCode = trackingCode;
                }
                else if (trackingCode < 0)
                {
                    throw new ArgumentException("Tracking code must be a positive number.");

                }
                else if (trackingCode.ToString() is null || trackingCode.ToString() == " " || trackingCode.ToString() == string.Empty)
                {
                    throw new ArgumentException("Tracking code cannot be null or empty.");

                }
                this.TrackingCode = trackingCode;
            }
            public void SetDescription(string description)
            {
                if (string.IsNullOrWhiteSpace(description) || description == string.Empty)
                {
                    throw new ArgumentException("Description cannot be null or empty.");
                }
                this.Description = description;
            }

            public void SetWeight(int weight)
            {
                if (weight <= 0)
                {
                    throw new ArgumentException("Weight must be a positive number.");
                }
                this.Weight = weight;
            }
            public void SetDeliveryFee(decimal fee)
            {
                if (fee <= 0)
                {
                    throw new ArgumentException("Delivery fee must be a positive number.");
                }
                this.DeliveryFee = fee;
            }
            public decimal GetDeliveryFee()
            {
                return DeliveryFee + (Weight * 5);
            }
            //Constructor
            public Shipment(string TrackingCode)
            {
                SetTrackingCode(int.Parse(TrackingCode));
                this.Description = "Unknown";
                Weight = 1;
                DeliveryFee = 50;
                GetDestination(new DeliveryAddress("New York", "5th Avenue", 123));
            }
            public Shipment(string TrackingCode, string Description, int Weight, decimal DeliveryFee)
            {
                SetTrackingCode(int.Parse(TrackingCode));
                SetDescription(Description);
                SetWeight(Weight);
                SetDeliveryFee(DeliveryFee);
                GetDestination(new DeliveryAddress("New York", "5th Avenue", 123));
            }
            public void UpdateDeilveryFee(decimal newFee)
            {
                if(newFee>0)
                {
                    DeliveryFee = newFee;
                }
                else
                {
                    throw new ArgumentException("Delivery fee must be a positive number.");
                }
            }
            public string PrintShipmentDetails()
            {
                return $"Tracking Code: {TrackingCode}, Description: {Description}, Weight: {Weight}kg, Delivery Fee: ${GetDeliveryFee()}";
            }

        }


                static void Main(string[] args)
        {
            DeliveryAddress address = new DeliveryAddress("New York", "5th Avenue", 123);
            DeliveryAddress address1 = address;
            address1.City = "Los Angeles";
            address1.Street = "Sunset Boulevrd";
            address1.BuildingNumber = 456;
            Console.WriteLine(address.GetFullAddress());
            Console.WriteLine(address1.GetFullAddress());
        }
    }
}

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

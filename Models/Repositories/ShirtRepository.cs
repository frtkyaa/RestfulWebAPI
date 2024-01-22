namespace CatalogWebapp.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirtList = new List<Shirt>()
        {
            new Shirt {ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 30, Size = 10},
            new Shirt {ShirtId = 2, Brand = "My Brand", Color = "Red", Gender = "Men", Price = 35, Size = 12},
            new Shirt {ShirtId = 3, Brand = "Your Brand", Color = "Pink", Gender = "Women", Price = 28, Size = 7},
            new Shirt {ShirtId = 4, Brand = "Your Brand", Color = "Dark-Blue", Gender = "Women", Price = 30, Size = 9},
        };

        public static List<Shirt> GetShirts()
        {
            return shirtList;
        }
        public static bool ShirtExists(int id)
        {
            return shirtList.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id) // Return elements can be null.
        {
            return shirtList.FirstOrDefault(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? Brand, string? Gender,string? Color,int? Size )
        {
            return shirtList.FirstOrDefault(x => 
            !string.IsNullOrEmpty(Brand) &&
            !string.IsNullOrEmpty(x.Brand) &&
            x.Brand.Equals(Brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrEmpty(Gender) &&
            !string.IsNullOrEmpty(x.Gender) &&
            x.Gender.Equals(Gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(Color) &&
            !string.IsNullOrWhiteSpace (x.Color) &&
            x.Color.Equals(Color, StringComparison.OrdinalIgnoreCase) &&
            Size.HasValue &&
            x.Size.HasValue &&
            Size.Value == x.Size.Value);
        }

        public static void AddShirt(Shirt shirt)
        {
            // The new object doesn't contain a shirtId because we don't know what the ID is
            // Because this is not a DB. We have to manually generate the ID.
            int maxId = shirtList.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;

            shirtList.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            // Lanquage - Integrated Query ile bir koleksiyon üzerinde belirli koşula uyan ilk öğeyi bulur.
            // (x => x.ShirtId == shirt.ShirtId) --> Bu bir lambda ifadesidir.

            var shirtToUpdate = shirtList.First(x => x.ShirtId == shirt.ShirtId); 

            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;

        }

        public static void DeleteShirt(int shirtId)
        {
            var shirt = GetShirtById(shirtId);
            if (shirt != null)
            {
                shirtList.Remove(shirt);
            }

        }
    }
}



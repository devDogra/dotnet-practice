using Fliu.Filters;

namespace Fliu.Models.Repositories
{
    public static class ShirtsRepository
    {
        private static List<Shirt> shirts = new List<Shirt>() {
            new Shirt() { Brand="A", Price=100, Size=7, Gender="Women", ShirtId=1000, ForGym=true},
            new Shirt() { Brand="B", Price=200, Size=9, Gender="Men", ShirtId=2000, ForGym=false},
            new Shirt() { Brand="C", Price=300, Size=8, Gender="Men", ShirtId=3000, ForGym=true},
            new Shirt() { Brand="D", Price=400, Size=12, Gender="Women", ShirtId=4000, ForGym=false},
        };

        public static bool ShirtExists(int id)
        {
            return shirts.Any(s => s.ShirtId == id);
        }
        public static List<Shirt> GetShirts(int? n)
        {
            if (n >= shirts.Count) return shirts;
            if (n == null) return shirts; 
            return shirts.Slice(0, n.Value); 
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }
    }
}

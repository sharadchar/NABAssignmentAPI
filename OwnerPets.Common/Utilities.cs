using System.Collections.Generic;
using System.Linq;

namespace OwnerPets.Common
{
    public static class Utilities
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }

            return !enumerable.Any();
        }
    }
}

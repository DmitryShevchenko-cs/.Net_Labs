namespace Task1_Extension;

    public static class ExtensionProject
    {
        public static void Main()
        {

        }

        public static string Reverse(this string str)
        {
            var chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static int CountElement(this string str, char symbol) => 
            str.ToCharArray().Count(c => c.Equals(symbol));

        public static int CountElement<T>(this T[] array, T element) =>
            array.Count(e => e.Equals(element));

        public static T[] MakeUnique<T>(this T[] arr) => 
            arr.Distinct().ToArray();
    }



namespace ConsoleApp
{
    public class Operations
    {
        // 4 DelegateOperation
        public static int Add(int x, int y)
        {
            return x + y;
        }

        // 4 GenericDelegateOperation & FuncOperation
        public static float Add(float x, float y)
        {
            return x + y;
        }

        // 4 ActionOperation
        public static void Add(decimal x, decimal y)
        {
            Console.WriteLine(x + y);
        }

        // 4 PredicateOperation
        public static bool CompareWith100(int sum)
        {
            return sum == 100 ? true : false;
        }

        // 4 DelegateOperation
        public static int Multiply(int x, int y)
        {
            return x + y;
        }

        // 4 GenericDelegateOperation & FuncOperation
        public static float Multiply(float x, float y)
        {
            return x + y;
        }

        // 4 ActionOperation
        public static void Multiply(decimal x, decimal y)
        {
            Console.WriteLine(x + y);
        }

        // 4 PredicateOperation
        public static bool DivisibleBy100(int sum)
        {
            return sum % 100 == 0 ? true : false;
        }




    }
}

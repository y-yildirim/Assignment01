
namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OperationDelegates operationDelegates = new(30, 40);

            Console.WriteLine("Add operation using OperationDelegate: " + operationDelegates.Operation(Operations.Add));
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Add operation using GenericOperationDelegate<float>: " + operationDelegates.GenericOperation(Operations.Add));
            Console.WriteLine("----------------------------------------------------------------");
            Console.Write("Add operation using Action<int, int> : ");
            operationDelegates.ActionOperation(Operations.Add);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Add operation using Func<float, float, float> : " + operationDelegates.FuncOperation(Operations.Add));
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Comparing sum with 100 using Predicate<int> : " + operationDelegates.PredicateOperation(Operations.CompareWith100));
        }

    }
}
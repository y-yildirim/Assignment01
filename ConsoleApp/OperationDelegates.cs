namespace ConsoleApp
{
    public class OperationDelegates
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        public OperationDelegates(int num1, int num2)
        {
            Num1 = num1;
            Num2 = num2;
        }

        public delegate int OperationDelegate(int x, int y);
        public delegate T GenericOperationDelegate<T>(T x, T y);

        public int Operation(OperationDelegate operationDelegate)
        {
            return operationDelegate(Num1, Num2);
        }

        public float GenericOperation(GenericOperationDelegate<float> genericOperationDelegate)
        {
            return genericOperationDelegate(Num1, Num2);
        }

        public void ActionOperation(Action<decimal, decimal> action)
        {
            action(Num1, Num2);
        }

        public float FuncOperation(Func<float, float, float> func)
        {
            return func(Num1, Num2);
        }

        public bool PredicateOperation(Predicate<int> predicate)
        {
            return predicate(Num1 + Num2);
        }

    }
}

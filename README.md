# Func, Action & Predicate Delegates

In this article, we'll cover built-in generic delegate types namely `Action`, `Func` and `Predicate`. But before, let's talk about what the `delegate` is.


## Delegate

Delegate is a type-safe pointer (reference-type) can hold and point to the address of the method that has the same signature and return type as that of the delegate.

To declare a delegate, the parameters and return type that the referenced function expects are provided.

Example:

```C#
public delegate int OperationDelegate(int x, int y);

public int Sum(int a, int b){
    return a + b;
}

public int Multiply(int a, int b){
    return a * b;
}
```

As you can see above, we declared a delegate and two methods that takes two int parameters and returns an int. Now, let's address and call these methods to the delegate object named `operationDelegate`.

```C#
static void Main(string[] args)
{
    OperationDelegate operationDelegate = Sum;
    // Can be written as using "Invoke" method: operationDelegate.Invoke(3, 5);
    Console.WriteLine(operationDelegate(3, 5));

    operationDelegate += Multiply;
    Console.WriteLine(operationDelegate(3, 5));
}
```
Output:

```shell
8
15
```

> **_NOTE:_** The delegate object (`operationDelegate`) addresses both methods after adding `Multiply` method by using `+=` operator but returns the return value of the last method (`15`). The returned values of all subscribers can be obtained by using [GetInvocationList()](https://stackoverflow.com/a/29999261/8008117).

### Generic Delegates

A delegate type may contain generic type parameters/return type. As shown in the following code snippet the delegate named `concat` is used as a function pointer for the method which takes `string, ìnt` parameters and returns a `string`:

> 
```C#
public delegate TResult GenericOperationDelegate<T1, T2, TResult>(T1 x, T2 y);

public string Concat(string a, int b)
{
    return a + b;
}

GenericOperationDelegate<string, int, string> concat = Concat;
Console.WriteLine(concat("Hello", 1));
```

> **_NOTE:_** The generic type must be specified when you set a target method and must match with the method's signature.


## `Action <in T1, in T2, …>`
Action is equivalent to  a generic delegate with return type is `void` and receive paramater(s). This delegate can be used to pass a method as a parameter without explicitly declaring a custom delegate.

```C#
public delegate void Action<in T>(T arg);
```

Here we see that our `Action` delegate can point to methods that take parameters of type `T` (ie any type) and then returns `void`.

An `Action` delegate can be initialized using the `new` keyword or by directly assigning a method.

In the following example the `Action` delegate named `concat` adresses two methods. When we call `concat("Hello", "World")` the two methods addressed by the `Action` run respectively.

```C#
Action<string, string> concat = WriteConcatenated;
concat += WriteLineByLine;

concat("Hello", "World");

void WriteConcatenated(string str1, string str2)
{
   Console.WriteLine(str1 + " " + str2);
}

void WriteLineByLine(string str1, string str2){
    Console.WriteLine(str1);
    Console.WriteLine(str2);
}
```

Output:

```shell
Hello World
Hello
World
```

> **_NOTE:_** Action can accept up to 16 input parameters of different types but it doesn’t return any value.

## `Predicate<in T>` Delegate
Predicate is equivalent to a delegate can only accept a single param and has bool return type. This delegate is generally used for the comparison related operations.

Example:

```C#
bool IsUpperCase(string str)
{
    return str.Equals(str.ToUpper());
}

static void Main(string[] args)
{
    Predicate<string> isUpper = IsUpperCase;

    bool result = isUpper("hello world!!");

    Console.WriteLine(result);
}
```

Output: 
```shell
False
```


This delegate is used by several methods of the Array and List<T> classes to search for elements in the collection.

## `Func<in T1, in T2, ..., out TResult>` Delegate
`Func` is similar to `Action`, but has a return value, unlike `Action`. The last parameter in the `Func` delegate is always considered as an `out` parameter to return the value. The input parameters are optional but the out parameter (return value) is mandatory to pass in the `Func` delegate.

Example:

```C#
Func<int, int, int> funcDelegate = Add;

Console.WriteLine("Adding two numbers (10+20) using Func: " + funcDelegate(10, 20));

int Add(int x, int y){
    return x + y;
}

```

Output: 

```shell
Adding two numbers (10+20) using Func: 30
```

> **_NOTES:_** 
> 1. All three can be used with method, anonymous method and lambda expression.
> 
> 2. These delegate types (`Action`, `Predicate`, `Func`) are used more frequently for the Collection Extension methods as lambda expressions:

```C#
Predicate<string> predicate = name => name.Length >= 4;
IEnumerable<string> filteredNameList = nameList.FindAll(predicate);
// OR
IEnumerable<string> filteredNameList = nameList.FindAll(name => name.Length >= 4);


```
using System.ComponentModel;

namespace WiredBrainCofee.SpecialCases
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new Container<string>();
            _ = new Container<string>();
            _ = new Container<int>();
            var container=new Container<int>();

            Console.WriteLine($"Container<string>: {Container<string>.InstanceCount}");
            Console.WriteLine($"Container<int>: {Container<int>.InstanceCount}");
            Console.WriteLine($"Container<bool>: {Container<bool>.InstanceCount}");
            Console.WriteLine($"ContainerBase: {ContainerBase.InstanceCountBase}");

            //here we don't have to tell compiler that <string> cause it can detect that from parameter
            container.PrintItem("Printing this in generic method in generic class");

            var result = Add(4.5, 5.7);
            Console.WriteLine($"Result={result}");
        }

        private static T Add<T>(T v1, T v2) where T: notnull

        {
            dynamic a=v1;
            dynamic b=v2;
            return a + b; 
            
        }
    }
    class ContainerBase
    {
        public ContainerBase() => InstanceCountBase++;

        public static int InstanceCountBase { get; private set; }
    }
    class Container<T> : ContainerBase
    {
        public Container() => InstanceCount++;

        public static int InstanceCount { get; private set; }

        public void PrintItem<TItem>(TItem item)
        {
            Console.WriteLine($"Item: {item}");
        }
    }
}
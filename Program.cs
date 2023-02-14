
internal static class Program
{


        public static  Func<double, double> AddOneOperation = AddOne;
        public static  Func<double, double> SquareOperation = Square;
        public static  Func<double, double> DivideByTwoOperation = DivideByTwo;
        public static Func<double, double> CalculateOperations = ComposeFunctions(AddOne, Square, DivideByTwo);

        public static Func<double , double> ComposeOperationsGeneric(){
            return AddOneOperation.Compose(SquareOperation).Compose(DivideByTwoOperation);
        } 
        

        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> F1, Func<T2, T3> F2)
        {
            return (x) => F2(F1(x));
        }

        public static Func<double, double> ComposeFunctions(Func<double, double> F1, Func<double, double> F2, Func<double, double> F3)
        {

            return (x) => F3(F2(F1(x)));
        }

        public static double AddOne(double x)
        {
            return x + 1;
        }

        public static double Square(double x)
        {
            return x * x;
        }

        public static double DivideByTwo(double x)
        {
            return x / 2;
        }
        private static void Main(string[] args)
        {
            var Numbers = new List<double> { 5, 8, 6, 7, 10, 18, 22 };

        // Numbers.Select(x=> DivideByTwo(Square(AddOne(x)))).ToList().ForEach(x=> Console.WriteLine(x));
        // Console.ReadLine();


        // Numbers.Select(x => AddOne(x)).Select(x => Square(x)).Select(x => DivideByTwo(x)).ToList().ForEach(x => Console.WriteLine(x));
        // Console.ReadLine();

            // Numbers.Select(x => CalculateOperations(x)).ToList().ForEach(x => Console.WriteLine(x));
        
            // Console.ReadLine();

            
            Numbers.Select(x => ComposeOperationsGeneric()).ToList().ForEach(x => Console.WriteLine(x));
        
            Console.ReadLine();
        
        }
}
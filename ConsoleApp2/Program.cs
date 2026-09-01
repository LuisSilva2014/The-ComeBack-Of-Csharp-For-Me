using Microsoft.VisualBasic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LuisPracticeCsharp2026;
namespace console1
{
    internal class Program
    {


        static void RefReview()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("===============RefReview======================");
            Console.WriteLine("String assignment challenge");

            string A = "A";
            string B = "B";
            string C = A; // passing as reference
            A = B;

            Console.WriteLine("Will C be equal to A?");
            Console.WriteLine($"A is: {A}");
            Console.WriteLine($"C is: {C}");
            Console.WriteLine($"Are they equal? {C == A}");
            Console.WriteLine("====================================");

            Console.WriteLine("Passing by Reference challenge");
            string _A = "A";
            string _B = "B";
            ref string _C = ref _A; // passing as reference, POINTER
            _A = _B;

            Console.WriteLine("Will C be equal to A?");
            Console.WriteLine($"A is: {_A}");
            Console.WriteLine($"C is: {_C}");
            Console.WriteLine($"Are they equal? {_C == _A}");
        }

        static void Conversions()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("=========Conversion and casting ==============");

            double[] a = { 1.3, 2.3 };
            Console.WriteLine(a.ToString());
            Console.WriteLine(Convert.ToString(a[0]));
        }



        static void UserInputs()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("========= UserInputs ==============");

            Console.WriteLine("Enter username: ");
            string userName = Console.ReadLine();
            // Print the value of the variable (userName), which will display the input value
            Console.WriteLine("Username is: " + userName);

            Console.WriteLine("Enter your age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your age is: " + age);
        }

        static void EvenOddNumber()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("========= EvenOddNumber ==============");
            string? input = Console.ReadLine();
            int outNumber = -1;
            bool converted = Int32.TryParse(input, out outNumber);
            if (converted)
            {
                int resultDiv = (int)outNumber % 2;
                Console.WriteLine(resultDiv == 0 ? "Is an even number" : "Is an odd number");
            }
            else
            {
                Console.WriteLine("Not supported");
            }

        }

        static void HighestValue()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("========= HighestValue ==============");
            int x = Int32.Parse(Console.ReadLine());
            int y = Int32.Parse(Console.ReadLine());
            int max = Math.Max(x, y);
            Console.WriteLine($"The max is:{max}");

            double z = 10.8342130492389;
            double roundedTo = Math.Round(z, MidpointRounding.ToNegativeInfinity);
            Console.WriteLine($"The roundedTo is:{roundedTo}");


        }
        static void StringLocation()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("========= StringLocation ==============");
            string mystring = "Hello Luis this a string to be found";
            Console.WriteLine(mystring);
            int startIndex = mystring.IndexOf("Luis");
            Console.WriteLine($"Found at index:  {startIndex.ToString()}");
            string subS = mystring.Substring(startIndex, mystring.Length - startIndex);
            Console.WriteLine($"Sub string after:  {subS}");



            //check for palyndrome word
            //exemple: ana, ullu
            Console.WriteLine("========= Palyndrome word check ==============");
            Console.WriteLine("Enter the world:");

            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"No input");
                return;
            }
            IEnumerable<char> reverse = input.Reverse();
            string backwardsInput = string.Empty;
            for (int i = 0; i < reverse.Count(); i++)
            {
                //backwardsInput += reverse[i]; // not works for this datatype
                backwardsInput += reverse.ElementAt(i);
            }



            //string backwardsInput = new string(input.Reverse().ToArray());
            //Console.WriteLine($"Is palindrome: {backwardsInput.Equa


            Console.WriteLine($"Is palyndrome odl school: {backwardsInput.Equals(input)} ");
            //string b = input.Reverse().ToArray();
            string b = new string(input.Reverse().ToArray());
            //string b1 = new string(['a', 'n', 'a']);


            Console.WriteLine($"Is palyndrome fast: {b.Equals(input)} ");
            Console.WriteLine($"This is a \n new line");
            Console.WriteLine($"This is a new line with \ttab");
            Console.WriteLine($"This is a new line with \bbackspace ");

            //Short Hand If...Else(Ternary Operator)
            //variable = (condition) ? expressionTrue : expressionFalse;

            string[] carsList = { "toyota", "chevy" };
            foreach (var car in carsList)
            {
                Console.WriteLine(car);
            }

        }



        static void RecapVarAndDynamic()
        {
            Console.WriteLine("========= RecapVarAndDynamic==============");
            Console.WriteLine("'Var' take the type the compiler implies");
            var val1 = 1.0;
            var val2 = true;
            var val3 = "Hello var";
            string kindV = val1.GetType().ToString();
            Console.WriteLine("The type of val1 is: " + kindV);
            Console.WriteLine("The type of val2 is: " + val2.GetType());
            Console.WriteLine("The type of val3 is: " + val3.GetType());

            // during the debugging the kidn applied to var can be determine by not on the dynamic
            Console.WriteLine("'dynamic' take the type the at runtime");
            dynamic dynamic1 = 1.0;
            dynamic dynamic2 = true;
            dynamic dynamic3 = "Hello dynamic";

            string kindD = dynamic1.GetType().ToString();
            Console.WriteLine("The type of dynamic1 is: " + kindD);
            Console.WriteLine("The type of dynamic2 is: " + dynamic2.GetType());

        }


        static void _Arrays()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("========= _Arrays ==============");

            string[] strings = { "luis", "diana" };
            string[] strings1 = new string[4] { "luis", "diana", "cecilia", "jorge" }; // prereserved
            string[] strings2 = new string[] { "luis", "diana" }; // will be taken dynbamicat

            strings1.Where(t => t.Equals("luis"));
            strings1.GroupBy(t => t); ;
            //string[] strings3;
            //strings3 = { "hello" }; // will cause an error as need to be predefined
            int[] numbers = new int[] { 10, 100, 2 };
            numbers.Min();

            Console.WriteLine("========= Multi arrays ==============");

            //2d dymentions arrays
            int[,] numbers2d = {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };

            numbers2d[0, 0] = -1;
            Console.WriteLine("numbers2d in pos 0,0 is " + numbers2d[0, 0]); // must be -1 not 1
                                                                             //for 3d dymentions arrays we can use

            //for (int x = 0; x < numbers2d.Length; x++)
            for (int x = 0; x < numbers2d.GetLength(0); x++)  // when looping dymension we use GetLength and not lents as this expect a dimention numebr
            {
                for (int y = 0; y < numbers2d.GetLength(1); y++)
                {
                    Console.WriteLine($"Position ({x},{y})={numbers2d[x, y]}  ");
                }
            }

            //int [,] 2dnumber = new int[,] {  { 1, 2, 3 }, { 4, 5, 6 }
            //int[,,] numbers3d = {
            //    {
            //          { 10, 100, 2 },
            //          { 10, 100, 2 }
            //    },
            //   {
            //          { 10, 100, 2 },
            //          { 10, 100, 2 }
            //    },
            //};
            //numbers3d[0,0,0] = 5;

        }

        public static void challegeMaxProfits()
        {
            //Stock Buy Sell : https://www.w3schools.com/practice/practice.php?problem=WEEKLY021&lang=csharp
            //Instructions
            //The first line of input contains an integer N.

            //The next N lines each contain one integer representing the stock price on that day.

            //You may buy on one day and sell on a later day.

            //Print the maximum profit possible.

            //If no profit is possible, print 0.

            //Input used in test:
            //            6
            //7
            //1
            //5
            //3
            //6
            //4
            //Important:
            //            To solve the problem your code has to return a correct result for other values as well.
            //            Expected Output
            //            5
            //            Reason: Buy on day 2(price = 1), sell on day 5(price = 6).Profit = 6 - 1 = 5.


            //int n = int.Parse(Console.ReadLine());
            //int[] prices = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    prices[i] = int.Parse(Console.ReadLine().Trim());
            //}


            //            int[] prices = new int[] { 7,
            //1,
            //5,
            //3,
            //6,
            //4};
            int[] prices = new int[] {
8,
3,
2,
1
};

            //int[] profits;
            //IEnumerable<int> profits = new IEnumerable<int>(); // can not be declated like this since it is an interface not a clas, you can not instanciate an interface.
            List<int> profits = new List<int>();
            for (int i = 0; i < prices.Length; i++)
            {

                for (int ii = i + 1; ii < (prices.Length); ii++)
                {
                    int x = prices[i];
                    int y = prices[ii];
                    int profit = (y - x);
                    //profits.Append(profit);
                    profits.Add(profit);
                }
            }

            int maxValue = Math.Max(0, profits.Max()); // or defualt to zero if negative
            Console.WriteLine(maxValue);

            // 1,2,3,4
            // Find and print the maximum profit
        }

        //ABOUT ACCESS MODIFIERS
        //public class : Accesible anywhare that import it
        //internal class : Accesible internal assembly
        //private class : Accesible only within the class
        // NO SPECIFIED: will take as internal
     
        public enum AnimalKind
        {
            Dog = 1,
            Cat = 2
        }


         class Animal
        {
            public string Name { get; set; } = string.Empty;
            public AnimalKind kind { get; set; }

            string _department = string.Empty;

            public string Department{
                get
                {
                    return _department; // Encapsulation, hidden properties / /To make sure sensitive data is hidden from unauthorized access.
                }
                //set
                //{
                    //.. Not available
                //}
            }
            public string GetDepartment() {  return _department; }

            public Animal(string name, AnimalKind kind)
            {
                this.kind = kind;
                this.Name = name;
                if (kind == AnimalKind.Dog)
                    this._department = $"{nameof(AnimalKind.Dog)}";
                //this.Department = $"{AnimalKind.Dog.ToString()}";

            }
        }

        class Car
        {
            public string manufacturing { get; set; } = string.Empty;
            protected string protectedString { get; set; } = string.Empty;  // protected ALLOW to be acessed withing the inheritaded class
        }

        sealed class Train // A sealed class can not be inheritated
        {
            protected string manufacturing { get; set; } = string.Empty;
        }

        class Trasnportation : Car
        //class Trasnportation: Train // A sealed class can not be inheritated
        {
            public string provider { get; set; } = string.Empty;
            public Trasnportation()
            {
                base.protectedString = string.Empty; //  accessitble for his parent
            }
        }

        //-----------------------------------------------------cs_polymorphism in classes with overwrite
        class _Animal // parent or base class
        {
            //public void AnimalSound() { Console.WriteLine("An animal makes a sound");  }
            public virtual void AnimalSound() { Console.WriteLine("An animal makes a sound");  } // virtual allow to be overwrited as need it
        }

        class _Dog: _Animal // Child
        {
            public void AnimalSound() { Console.WriteLine("wow wow"); }
        }
        class _Cat : _Animal // Child
        {
            //public void AnimalSound() { Console.WriteLine("mew mew"); } // without the overwrite it will take the the AnimalSound from Parent
            public override void AnimalSound() { Console.WriteLine("mew mew2");  } // we need to make as virtual or abstract the parent one
        }


        //-----------------------------------------------------abstract classes

        abstract class __Animal // parent or base class
        {
            //An abstract object did not have a body
            public abstract void AnimalSound(); // { Console.WriteLine("An animal makes a sound"); } // virtual allow to be overwrited as need it

            // but we can still use regular methods
            public void Sleep()
            {
                Console.WriteLine("Zzz");
            }
        }

        class __Dog : __Animal // Child
        {
            public override void AnimalSound() { Console.WriteLine("wow wow"); }
        }
        class __Cat : __Animal // Child
        {
            //public void AnimalSound() { Console.WriteLine("mew mew"); } // without the overwrite it will take the the AnimalSound from Parent
            public override void AnimalSound() { Console.WriteLine("mew mew2"); } // we need to make as virtual or abstract the parent one
        }


        internal static void OOPRecap()
        {
            Animal Animal = new Animal("Montoya", AnimalKind.Dog);
            Animal.Name = "Montoya";

            Console.WriteLine(Animal.GetDepartment());
            Console.WriteLine(Animal.Department);

                Console.WriteLine("================= Inheritance ==========");
            Trasnportation trasnportation = new Trasnportation();
            trasnportation.manufacturing = "Ford";
            trasnportation.manufacturing = "Ford";


            Console.WriteLine("================= cs_polymorphism in classes with overwrite ==========");
            _Animal _animal1 = new _Animal();
            _animal1.AnimalSound();
            _Cat _animal = new _Cat();
            _animal.AnimalSound();

            Console.WriteLine("================= abstract clasess and inherantec ==========");
            //__Animal __animal1 = new __Animal(); // This throws an erro as an abstract and or interface can be instanciated, you must used in another class
            //__animal1.AnimalSound(); 
            __Cat __animal = new __Cat();                     
            __animal.AnimalSound();


            Console.WriteLine("================= vehicle managment |  abstract clasess and inherantec ==========");
            // Test cases
            // VehicleManager VehicleManager = new VehicleManager();
            VehicleManager vm = new VehicleManager();
            //var car = new Vehicle(); // is not posible
            var car = new xCar()
            {
                Id = 1, Brand = "Toyota", Model = "Camry", Year = 2022
            };
            vm.Add(car); // even thought is expecting a vehicle class this is is compatible as its parent is the base class

            var motorcycle = new xMotorcycle(2, "Yamaha", "T", 1998);
            vm.Add(motorcycle);
            vm.DisplayAllVehicles();
            vm.Remove(2);
            vm.DisplayAllVehicles();
        }

        //-----------------------------------------------------------------------------------x
        //-----------------------------------------------------------------------------------x
        static void Main(string[] args)
        {
            bool _continue = true;
            while (_continue)
            {
                //RefReview();
                //Conversions();
                //UserInputs();
                //EvenOddNumber();
                //HighestValue();
                //StringLocation();
                //RecapVarAndDynamic();
                //_Arrays();
                //challegeMaxProfits();
                OOPRecap();

                //================================
                Console.WriteLine("Please enter Y/N to continue");
                string ?input = Console.ReadLine(); // can be empty or null
                //char ?input2 = Console.ReadKey(); // can be empty or null
                if (System.String.IsNullOrEmpty(input))
                    _continue = false;
                else
                {
                    char yesOrNo = Convert.ToChar(input?.ToLower());
                       _continue = yesOrNo == 'y';
                }

                if (_continue)
                {
                    Console.Clear();
                }
            }
        }


     
    }

}

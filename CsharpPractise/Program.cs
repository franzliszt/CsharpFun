

namespace CsharpPractise {
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading;
    using R = System.Reflection;
    using System.Threading.Tasks;
    using System.Linq;
    using Indexing;
    /*
        *****************************************************************************************
            Dette inneholder kun kode for å teste og lære nye aspekter i C#.
            Dette innholdet må ikke brukes til å vurdere hvorvidt oppsett og struktur er god.
            Det er kun små programmer som ikke skal brukes til annet enn ny lærdom.
        *****************************************************************************************
    */

    class Refleksjon { R.PropertyInfo p; }
    class Product {
        readonly string name;
        public string Name { get; }
        readonly decimal price;
        public decimal Price { get; }

        public Product(string name, decimal price) {
            this.name = name;
            this.price = price;
        }

        public static List<Product> GetProductSamples() {
            // spesifiserer navnene til argumentene
            return new List<Product> {
                new Product (name: "Computer", price: 9000),
                new Product (name: "Screen", price: 4000),
                new Product(name: "car", price: 500000)
            };
        }

        public override string ToString() {
            return string.Format($"{name}: {price}");
        }
    }
    public sealed class Program {

        public static void Main(string[] args) {
            //Indexing.Sentence sentence = new Indexing.Sentence();
            //string word = sentence[0];
            //Console.WriteLine(word);

            //Console.WriteLine("Rectangular array:");
            //foreach (var i in YieldRectangularArray()) {
            //    Console.Write($"{i} ");
            //}

            //Console.WriteLine("\nJagged array:");
            //foreach (var item in YieldJaggedArray()) {
            //    Console.Write("{0} ", item);
            //}
            ////TestMemento.Test();
            ////string output = "\nDette er en melding til alle brukere av innenlands flyreiser:";
            ////foreach (var letter in output.ToCharArray()) {
            ////    Console.Write(letter);
            ////    Thread.Sleep(100);
            ////}
            ////A a = new D();
            ////a.DoWork();
            ////((D)a).DoWork();

            ////Derived derived = new Derived();
            ////derived.DoWork();
            ////((Base)derived).DoWork();



            //int[] array2 = new int[] { 2, 6, 4, 8, 9, 5, 7, 1, 4, 55, 6, 8, 3, 8, 3, 31, 0 };
            ////Console.WriteLine("\n\nSortedSet");
            ////SortedSet<int> sorted = new SortedSet<int>(array2);
            ////foreach (int n in sorted)
            ////    Console.Write("{0}", n);

            //Console.WriteLine("\n\nOriginal Array2:");
            //foreach (int n in array2)
            //    Console.Write("{0} ", n);

            //Console.WriteLine("\n\nReversed array2:");
            //reverse(array2);
            //foreach (int n in array2)
            //    Console.Write("{0} ", n);

            //Console.WriteLine("\n\nSorted ascending:");
            //SortAscending(array2);
            //foreach (int n in array2)
            //    Console.Write("{0} ", n);

            //Console.WriteLine("\n\nSorted descending:");
            //SortDescending(array2);
            //foreach (var item in array2) {
            //    Console.Write("{0} ", item);

            //}

            //Console.WriteLine("\n\nRemoved duplicates:");
            //SortAscending(array2);
            //foreach (int item in RemoveDuplicate(array2)) {
            //    Console.Write("{0} ", item);
            //}

            //Console.WriteLine("\n\nPrint fibonacci:");
            //PrintFibonacci(10);

            //Console.WriteLine("\n\nFibonacci to array:");
            //foreach (int n in FibonacciToArray(10))
            //    Console.Write("{0} ", n);

            //Console.WriteLine("\n\nCount numbers in array2:");
            //foreach (var item in CountNumbers(new List<int>(array2)))
            //    Console.WriteLine("Key: {0} => {1}", item.Key, item.Value);


            ////Console.WriteLine("\n\nEnter a string:");
            ////string input = Console.ReadLine();
            ////Console.WriteLine("You wrote: {0}", input);
            //////SortedSet<char> set = new SortedSet<char>(CountCharactes(input).Keys); // alle nøkler
            ////IDictionary<char, Dictionary<char, int>> dictionary = MapWordsAlphabetic(new List<char>(ToChar(input)));
            ////PrintDictionary(dictionary);

            ////WriteToFile(@"C:\Users\Stian\Desktop\test.txt", "Dette er en ny linje1.");


            //int a, b;
            //Split(2343, out a, out b);

            //int randomNumber;
            //RandomNumber(out randomNumber);
            ////Console.WriteLine(Sum(2, 3, 2, 3, 2, 3, 2));

            //OptionalParamter(); // skriver ut 10, 0
            //OptionalParamter(100); // skriver ut 100, 0
            //OptionalParamter(y: 90); // skriver 10, 90
            //OptionalParamter(y: 9, x: 2); // skriver 2, 9 (x, y)

            ////Console.WriteLine($"Kaller array: { NullOperator("k",null,"u")[0]?.ToUpper() ?? "NULLL" }");

            //NullOperatorIsNull();
            //TestGoto2();

            //del myDel = x => x * x;
            //int j = myDel(5);

            //TestDelegate testDelegate = n => {
            //    string s = n + " World";
            //    Console.WriteLine(s);
            //};
            //testDelegate("Hello");

            Func<int, bool> myFunc = x => x == 5;
            bool result = myFunc(4); // false

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddNumbers = numbers.Count(n => n % 2 != 0);
            var firstNumberLessThan6 = numbers.TakeWhile(n => n < 6);
            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);

            MyCollection<int> myCol = new MyCollection<int>(10);
            for (int i = 0; i < myCol.Length; i++) {
                myCol[i] = 2 * i;
            }

            Console.WriteLine("myCol contains: ");
            foreach (var i in myCol)
                Console.Write($"{i} ");
            

            Console.WriteLine("\n\nPress a key to quit...");
            Console.ReadKey();
        } // end Main
        

        static int Endre1(ref int a) => a = 2;
        static void Endre2(out int a) => a = 10;

        private static async void Click() {
            await ExampleMethodAsync();
            Console.WriteLine("\r\nControl returned to Click.\r\n");
        }
        static async Task ExampleMethodAsync() {
            await Task.Delay(1000);
        }

        delegate int del(int i);
        delegate void TestDelegate(string s);
        public delegate TResult Func<T, TResult>(T arg0);

        static void TestGoto2() {
            int i = 1;
            startLoop:
            if (i <= 5) {
                Console.Write(i + " ");
                i++;
                goto startLoop;
            }
        }

        public enum Values : byte {a = 2, b = a * 2, c = b * 2 } 

        static void TestGoto() {
            int x = 10;

            switch (x) {
                case 9:
                    Console.Write("Ni");
                    break;
                case 88:
                    Console.Write("Joker");
                    break;
                case 10:
                    goto case 88;
                default:
                    Console.Write("Tapte");
                    break;
            }
        }


        static void NullOperatorIsNull() {
            Random r = null;
            int? result = r?.Next(1, 20);
            int output = result ?? 1;
            Console.WriteLine(output); // 1
        }
        static int Foo1(int x) => x * 2;
        static void Foo2(int x) => Console.WriteLine(x);

        static string[] NullOperator(params string[] strings) {
            // x?.?y.z tilsvarer x == null ? null : (x.y == null) ? null : x.y.x);
            string[] output = new string[strings.Length];

            Console.WriteLine((strings[0]?.ToLower() != null) ? "Ikke null" : "Jeg var visst null");

            for (int i = 0; i < strings.Length; i++) {
                output[i] = strings[i] ?? "Jeg er null"; // hvis denne posisjonen er null, få default verdi
            }
            output[0] = strings[1]?.ToUpper(); // gi meg denne verdien ToUpper hvis den ikke er null, ellers null.
            return output;
        }

        static void OptionalParamter(int x = 10, int y = 0) {
            Console.WriteLine($"Default paramtere er {x}, {y}");
        }

        static int Sum(params int[] ints) {
            int sum = 0;
            for (int i = 0; i < ints.Length; i++) {
                sum += ints[i];
            }
            return sum;
        }

        static void RandomNumber(out int a) {
            Random rnd = new Random();
            a = rnd.Next();
        }

        static void Split(int number, out int c, out int d) {
            string temp = number.ToString();
            string a = temp.Substring(0, 2); // 23
            int a1 = Int32.Parse(a.Substring(0, 1));
            int b1 = Int32.Parse(a.Substring(1));
            Swap(ref a1, ref b1);
            c = Int32.Parse(a1 + "" + b1);
            a = temp.Substring(2);
            a1 = Int32.Parse(a.Substring(0, 1));
            b1 = Int32.Parse(a.Substring(1));
            Swap(ref a1, ref b1);
            d = Int32.Parse(a1 + "" + b1);
        }

        static void PassByReference(ref int input) {
            input *= 2;
        }

        static void Swap(ref int a, ref int b) {
            int temp = a;
            a = b;
            b = temp;
        }

        static IEnumerable<int> YieldRectangularArray() {
            // kompilator infererer typen
            var a = new[,] {
                { 1,2,3,4},
                { 2,2,4,4},
                { 2,2,4,4}
            };

            for (int i = 0; i < a.GetLength(0); i++) {
                for (int j = 0; j < a.GetLength(1); j++) {
                    yield return a[i, j];
                }
            }
        }

        static IEnumerable<int> YieldJaggedArray() {
            var jagged = new int[][] {
                new int[] {2,3,4,3},
                new int[] {4,6,8},
                new int[] {8,9}
            };

            for (int i = 0; i < jagged.Length; i++) {
                for (int j = 0; j < jagged[i].Length; j++) {
                    yield return jagged[i][j];
                }
            }
        }

        public static void ShowGalaxies() {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy) {
                Console.WriteLine($"{theGalaxy.Name} {theGalaxy.MegaLightYears.ToString()}");
            }
        }

        public static void YieldExample() {
            foreach (int i in Power(2, 8)) {
                Console.WriteLine($"{i} ");
            }
        }

        private static IEnumerable<int> Power(int number, int exponent) {
            int result = 1;
            for (int i = 0; i < exponent; i++) {
                result *= number;
                yield return result;
            }
        }

        public static void YieldExample2() {
            var navn = "donald duck";
            foreach (var letter in navn.ToCharArray()) {
                Console.Write($"{letter}");
            }
        }

        private static IEnumerable<char> Letters(char[] array) {
            for (int i = 0; i < array.Length; i++) {
                yield return array[i];
            }
        }

        public static void InterpolatedString(string fname, string lname, string city) {
            var output = $"Hello, {fname} {lname}. You live in {city}. 2 + 2 = {2 + 2}";
            Console.WriteLine(output);
        }

        public static bool ValidateFirstname(string name) {
            //string pattern = @"^[A-Z]{1}[a-z]{1,5}";
            string pattern = @"^[a-zæøåA-zÆØÅ]{2,30}$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(name);
        }

        public static bool ValidateZipcode(string code) {
            string pattern = @"^[0-9]{4}$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(code);
        }

        private static Dictionary<char, int> CountWords(string input) {
            return null;
        }

        public static char[] ToChar(string input) {
            input = Regex.Replace(input, @"\s+", "");
            return input.ToCharArray();
        }

        public static IDictionary<char, Dictionary<char, int>> MapWordsAlphabetic(List<char> list) {
            IDictionary<char, Dictionary<char, int>> dictionary = new Dictionary<char, Dictionary<char, int>>();
            SortedSet<char> sortedCharacters = new SortedSet<char>(list); // ikke nødvendig
            new List<char>(sortedCharacters).ForEach((char key) => dictionary.Add(key, new Dictionary<char, int>()));

            new List<char>(list).ForEach((char key) => {
                if (dictionary.ContainsKey(key)) {
                    Dictionary<char, int> inner;
                    if (dictionary.TryGetValue(key, out inner)) {
                        if (inner.ContainsKey(key))
                            inner[key]++;
                        else
                            inner.Add(key, 1);
                    }
                }
            });

            return dictionary;
        }

        private static void PrintDictionary(IDictionary<char, Dictionary<char, int>> dictionary) {
            SortedSet<char> sorted = new SortedSet<char>(dictionary.Keys);
            new List<char>(sorted).ForEach(key => {
                Console.WriteLine("{0}:", key.ToString().ToUpper());
                foreach (KeyValuePair<char, int> item in dictionary[key]) {
                    if (item.Key == key)
                        Console.WriteLine("\t{0}:{1}", item.Key, item.Value);
                }
            });
        }


        private static void WriteToFile(string path, string newText) {
            using (StreamWriter writer = new StreamWriter(path)) {
                writer.WriteLine(newText);
            }
        }

        private static void ReadFile(string path) {

        }

        static int[] RemoveDuplicate(int[] a) {
            HashSet<int> singles = new HashSet<int>();
            for (int i = 0; i < a.Length; i++) {
                if (!singles.Contains(a[i]))
                    singles.Add(a[i]);
            }
            List<int> b = new List<int>();
            foreach (int n in singles)
                b.Add(n);

            return b.ToArray();
        }

        static void PrintFibonacci(int n) {
            if (n > 1) {
                int a = 0;
                int b = 1;
                int sum = a + b;
                Console.Write("{0} {1} ", a, b);
                for (int i = 2; i <= n; i++) {
                    Console.Write("{0} ", sum);
                    a = b;
                    b = sum;
                    sum = a + b;
                }
            }
        }

        static int[] FibonacciToArray(int n) {
            int[] array = null;
            if (n > 1) {
                array = new int[n + 1];
                array[0] = 0;
                array[1] = 1;
                for (int i = 2; i < array.Length; i++) {
                    int a = array[i - 2];
                    int b = array[i - 1];
                    array[i] = a + b;
                }
            }
            return array;
        }

        // Read only example**************
        int money = 9;
        public decimal Worth => money; // get
        // public decimal Init { get; set; } = 100;
        // *******************************

        public static string FizzBuzz(int n) {
            if (n > 0 && n <= 100) {
                if (n % 15 == 0)
                    return "FizzBuzz";
                else if (n % 5 == 0)
                    return "Buzz";
                else if (n % 3 == 0)
                    return "Fizz";
            }
            return null;
        }

        static void reverse(int[] a) {
            int n = a.Length;
            for (int left = 0, right = n - 1; left < right; left++, right--) {
                int temp = a[left];
                a[left] = a[right];
                a[right] = temp;
            }
        }

        static void SortAscending(int[] a) {
            int temp = 0;
            for (int i = 0; i < a.Length; i++) {
                for (int j = 0; j < a.Length - 1; j++) {
                    int rigth = a[j + 1];
                    int left = a[j];
                    if (rigth < left) {
                        temp = rigth;
                        a[j + 1] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        static void SortDescending(int[] a) {
            for (int i = 0; i < a.Length - 1; i++) {
                for (int j = i; j < a.Length - 1; j++) {
                    if (a[i] < a[j + 1] && i < (j + 1)) {
                        int temp = a[j + 1];
                        a[j + 1] = a[i];
                        a[i] = temp;
                    }
                }
            }
        }

        static Dictionary<int, int> CountNumbers(List<int> list) {
            Dictionary<int, int> map = new Dictionary<int, int>();
            list.ForEach((int n) => {
                if (map.ContainsKey(n)) {
                    map[n]++;
                } else
                    map.Add(n, 1);
            });
            return map;
        }

        private static Dictionary<string, int> WordCountFromFile() {
            var path = @"C:\Users\Stian\Desktop\test.txt";
            string text = File.ReadAllText(path);

            //string[] words = file.Split(' ');
            Console.WriteLine(text);
            return null;
        }

        public static bool IsOdd(int i) {
            return (i % 2) != 0;

        }

        internal delegate void Delegate(String input);

        class Base {
            public virtual void DoWork() {
                Console.WriteLine("DoWork from Base");
            }
        }

        class Derived : Base {

            public new void DoWork() {
                Console.WriteLine("DOwork declared from Derived");
            }
        }


        class A {
            internal virtual void DoWork() {
                Console.WriteLine("Base class A");
            }



            internal void Tester(Delegate d) {

            }
        }

        class B : A {
            internal new virtual void DoWork() {
                Console.WriteLine("Derived class B");
            }
        }
        class C : B {
            internal sealed override void DoWork() {
                Console.WriteLine("Derived class C");
            }
        }
        class D : C {
            internal new void DoWork() {
                Console.WriteLine("Derived class D new DoWork()");
            }
        }

        struct GenericList<T> {
            internal void Add(T input) { }
        }

        class Stian {
            readonly string myName = "Stian";
        }

        class Galaxies {
            public IEnumerable<Galaxy> NextGalaxy {
                get {
                    yield return new Galaxy() { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy() { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy() { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy() { Name = "Andromeda", MegaLightYears = 3 };
                }
            }
        }

        class Galaxy {
            public String Name { get; set; }
            public int MegaLightYears { get; set; }
        }

        class Diverse {
            decimal x;
            public decimal X {
                get { return x; }
                private set { x = Math.Round(value, 2); }
            }

            static string[] IndexingStringToNewStringArray() {
                string[] s = { "perfekt", "hei", null, "på", "badet" };
                string[] output = new string[s.Length];

                for (int i = s.Length - 1; i >= 0; i++) {
                    output[i] = s[i]?.ToUpper() ?? "default";
                }

                return output;
            }
        }
    }
} // end namespace

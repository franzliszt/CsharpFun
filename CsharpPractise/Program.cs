

namespace CsharpPractise {
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Threading;
    using System.Diagnostics;
    public class Program {
        internal static void Main(string[] args) {
            //A a = new D();
            //a.DoWork();
            //((D)a).DoWork();

            //Derived derived = new Derived();
            //derived.DoWork();
            //((Base)derived).DoWork();
            
            

            int[] array2 = new int[] { 2, 6, 4, 8, 9, 5, 7, 1, 4, 55, 6, 8, 3, 8, 3, 31, 0 };
            //Console.WriteLine("\n\nSortedSet");
            //SortedSet<int> sorted = new SortedSet<int>(array2);
            //foreach (int n in sorted)
            //    Console.Write("{0}", n);

            Console.WriteLine("\n\nOriginal Array2:");
            foreach (int n in array2)
                Console.Write("{0} ", n);

            Console.WriteLine("\n\nReversed array2:");
            reverse(array2);
            foreach (int n in array2)
                Console.Write("{0} ", n);

            Console.WriteLine("\n\nSorted ascending:");
            SortAscending(array2);
            foreach (int n in array2)
                Console.Write("{0} ", n);

            Console.WriteLine("\n\nSorted descending:");
            SortDescending(array2);
            foreach (var item in array2) {
                Console.Write("{0} ", item);
                
            }

            Console.WriteLine("\n\nRemoved duplicates:");
            SortAscending(array2);
            foreach (int item in RemoveDuplicate(array2)) {
                Console.Write("{0} ", item);
            }

            Console.WriteLine("\n\nPrint fibonacci:");
            PrintFibonacci(10);

            Console.WriteLine("\n\nFibonacci to array:");
            foreach (int n in FibonacciToArray(10))
                Console.Write("{0} ", n);

            Console.WriteLine("\n\nCount numbers in array2:");
            foreach (var item in CountNumbers(new List<int>(array2)))
                Console.WriteLine("Key: {0} => {1}", item.Key, item.Value);


            //Console.WriteLine("\n\nEnter a string:");
            //string input = Console.ReadLine();
            //Console.WriteLine("You wrote: {0}", input);
            ////SortedSet<char> set = new SortedSet<char>(CountCharactes(input).Keys); // alle nøkler
            //IDictionary<char, Dictionary<char, int>> dictionary = MapWordsAlphabetic(new List<char>(ToChar(input)));
            //PrintDictionary(dictionary);

            //WriteToFile(@"C:\Users\Stian\Desktop\test.txt", "Dette er en ny linje1.");
            InterpolatedString("Donald", "Duck", "Andeby");
            

            YieldExample2();
            Console.WriteLine();
            Console.WriteLine();
            ShowGalaxies();


            Console.WriteLine("\n\nPress a key to quit...");
            Console.ReadKey();
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
            foreach (var letter in ToChar(navn)) {
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

        static void FizzBuzz(int n) {
            if (n > 0 && n <= 100) {
                if (n % 15 == 0)
                    Console.WriteLine("\nFizzBuzz");
                else if (n % 5 == 0)
                    Console.WriteLine("\nBuzz");
                else if (n % 3 == 0)
                    Console.WriteLine("\nFizz");
            }
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
} // end namespace

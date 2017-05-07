using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPractise {
    class Immutable2 {
        public string Name { get; private set; }
        public int Age { get; }

        private Immutable2(string name, int age) {
            Name = name;
            Age = age;
        }

        // factory method
        public static Immutable2 CreateImmutable2(string name, int age) {
            return new Immutable2(age: age, name: name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPractise {
    class Immutable1 {
        public string Name { get; private set; }
        public int Age { get; }

        public Immutable1(string name, int age) {
            Name = name;
            Age = age;
        }
    }
}

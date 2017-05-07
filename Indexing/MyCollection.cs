using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing {
    public class MyCollection <T> {
        private T[] MyList;
        private int counter;
        private int size;
        public int Length => size;

        public MyCollection(int size) {
            this.size = size;
            MyList = new T[size];
            counter = 0;
        }

        public T this[int index] {
            get { return MyList[index]; }
            set {
                if (index > MyList.Length)
                    throw new ArgumentOutOfRangeException("Index out of range.");
                else
                    MyList[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator() {
            foreach (var i in MyList)
                yield return i;
        }
    }
}

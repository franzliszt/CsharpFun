using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPractise {
    class DesignPatterns {
        
    }

    class Singleton {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton Instance {
            get {
                if (instance == null) {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    class Memento {
        public string State { get; }

        public Memento(string state) {
            State = state;
        }
    }

    class Handler {
        public Memento _Memento { get; set; }
    }

    class Originator {
        private string state;

        public string State {
            get {
                return state;
            }
            set {
                state = value;
                Console.WriteLine($"State = {state}");
            }
        }

        public Memento CreateMemento() {
            return new Memento(state);
        }

        public void SetMemento(Memento mem) {
            Console.WriteLine("Restoring state...");
            State = mem.State;
        }

    }

    public class TestMemento {
        public static void Test() {
            Originator o = new Originator();
            o.State = "On";

            Handler handler = new Handler();
            handler._Memento = o.CreateMemento();

            o.State = "Off";

            o.SetMemento(handler._Memento);
        }
    }
    
}

namespace Indexing
{
    public class Sentence {
        string[] words = "The quick and the dead".Split();
        public string this[int wordNumber] {
            get { return words[wordNumber]; }
            set { words[wordNumber] = value; }
        }

        //public string this[int wordNumber] => words[wordNumber]; // read-only
    }
}

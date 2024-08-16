namespace KonsoleWriting
{
    class WriteText//only for print text
    {
        private string alphabet_down = "abcdefghijklmnopqrstuvwxyz";//For saved and changed alphabet_down

        private string alphabet_up = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";//For saved and changed alphabet_up

        private string symbols = " !.,?`';:></\n";//this is place for saved another symbols

        private string word;//For saved word
        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        private string prefix = "";//for saved prefix
        public string Prefix { get { return prefix; } }

        private int length;//For saved length of word
        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public void GenerationText()
        {
            for (int i = 0; i < length; i++)
            {
                char currentChar = word[i];//The symbol we are looking for
                int a = 0;
                // Programm check all alphabits, what we have.
                // And if we don't have currentChar in alphabits, we add this symbols.
                if (!alphabet_down.Contains(currentChar) && char.IsLower(currentChar))
                    alphabet_down += currentChar;
                else if (!alphabet_up.Contains(currentChar) && char.IsUpper(currentChar))
                    alphabet_up += currentChar;
                else if (!symbols.Contains(currentChar) && !alphabet_down.Contains(currentChar)
                    && !alphabet_up.Contains(currentChar))
                    symbols = symbols.Substring(0, symbols.Length - 2) + currentChar + symbols.Substring(symbols.Length - 2);


                if (char.IsUpper(currentChar))
                {
                    while (currentChar != alphabet_up[a])
                    {
                        Console.Write(alphabet_up[a]);
                        Thread.Sleep(1);
                        Console.Write("\b \b");
                        a++;
                    };

                }
                else if (char.IsLower(currentChar))
                {
                    while (currentChar != alphabet_down[a])
                    {
                        Console.Write(alphabet_down[a]);
                        Thread.Sleep(1);
                        Console.Write("\b \b");
                        a++;
                    };
                }
                else
                {
                    while (currentChar != symbols[a])
                    {
                        Console.Write(symbols[a]);
                        Thread.Sleep(1);
                        Console.Write("\b \b");
                        a++;
                    };
                }
                Console.Write(currentChar);
            }
        }

        public void Check()
        {
            Console.WriteLine($"\nAlphabet_Down:        {alphabet_down}\n" +
                $"Alphabet_Up:          {alphabet_up}\n" +
                $"Symbols:             {symbols}\n" +
                $"Word:                 {word}\n" +
                $"Length word:          {length}\n" +
                $"Length alphabet_down: {alphabet_down.Length}\n" +
                $"Length alphabet_up:   {alphabet_up.Length}\n");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            WriteText write = new WriteText();
            Console.Write("Hello, i`m writer. Put your text here and i will write your text." +
                "\nText: ");

            string textInput = Console.ReadLine();
            //save all data
            write.Word = textInput;
            write.Length = write.Word.Length;
            //check all date
            write.Check();
            write.GenerationText();
            write.Check();
            Console.ReadLine();
        }
    }
}
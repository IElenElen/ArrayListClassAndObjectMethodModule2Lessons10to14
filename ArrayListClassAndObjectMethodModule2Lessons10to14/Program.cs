namespace ArrayListClassAndObjectMethodModule2Lessons10to14
{
    public class Program
    {
        static void Main(string[] _)
        {

            bool isOnlyFirstRun = true;
            PoetryLibrary library = new();

            while (true)
            {
                if(isOnlyFirstRun)
                {
                    Console.WriteLine("Wita Cię Biblioteka poezji :-)");
                    Console.WriteLine();
                    isOnlyFirstRun = false;
                }
                else
                {
                    Console.Clear();
                }

                Console.WriteLine("Co chcesz zrobić?. Wybierz opcję: ");
                Console.WriteLine();
                Console.WriteLine("1. Dodaj do biblioteki nowy wiersz.");
                Console.WriteLine();
                Console.WriteLine("2. Usuń wiersz z biblioteki.");
                Console.WriteLine();
                Console.WriteLine("3. Wyszukaj wiersz: a) po autorze b) po tytule.");
                Console.WriteLine();
                Console.WriteLine("4. Wyświetl wszystkie wiersze.");
                Console.WriteLine();
                Console.WriteLine("5. Wyświetl wszystkie wiersze z danej epoki literackiej.");
                Console.WriteLine();
                Console.WriteLine("6. Wyświetl liczbę wierszy w każdej epoce literackiej.");
                Console.WriteLine();
                Console.WriteLine("7. Wyjdż z biblioteki.");
                Console.WriteLine();

                string? userChoice = Console.ReadLine();

                if (int.TryParse(userChoice, out int value))
                {
                    if (value == 7)
                    {
                        Console.WriteLine();
                        PoetryLibrary.ExitLibrary();
                        break;
                    }

                    else if (value >= 1 && value <= 6)
                    {
                        library.SelectedOption(value);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Podaj nr operacji do wykonania.");
                        Console.WriteLine();
                    }
                }

                else
                {
                    Console.WriteLine("Błąd. Wprowadź porządany wybór operacji: 1-8.");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Naciśnij Enter, aby kontynuować...");
                Console.ReadLine();
            }
        }
    }
}


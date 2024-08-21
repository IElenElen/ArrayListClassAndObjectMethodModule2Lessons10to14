using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArrayListClassAndObjectMethodModule2Lessons10to14
{
    public class PoetryLibrary
    {
        private readonly List<Poem> poems = [];

        private readonly Poem poem = new();
        public readonly string? PoemsByPeriod;

        public void AddPoem(Poem poem)
        {
            Console.WriteLine();
            Console.WriteLine("Podaj tytuł wiersza: .");
            Console.WriteLine();
            Console.WriteLine("Podaj autora wiersza: .");
            Console.WriteLine();
            Console.WriteLine("Podaj epokę literacką wiersza: .");
            Console.WriteLine();
            Console.WriteLine("Podaj treść wiersza: .");
            Console.WriteLine();
            poem.Title = Console.ReadLine();
            poem.Author = Console.ReadLine();
            poem.LiteraryPeriod = Console.ReadLine();
            poem.Content = Console.ReadLine();

            if (poem != null)
            {
                poems.Add(poem);
                Console.WriteLine();
                Console.WriteLine("Dodano wiersz do biblioteki.");
            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine("Nie można dodać pustej linii. Podaj poprawne dane.");
                Console.WriteLine();
            }
        }

        public void RemovePoem(string? title)
        {
            Console.WriteLine();
            Console.WriteLine("Podaj tytuł wiersza.");
            Console.WriteLine();
            poem.Title = Console.ReadLine();

            var poemToRemove = poems.FirstOrDefault(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (poemToRemove != null)
            {
                poems.Remove(poemToRemove);
                Console.WriteLine();
                Console.WriteLine("Usunieto wiersz z biblioteki.");
            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine("Wiersz o podanym tytule nie został znaleziony w zbiorze.");
                Console.WriteLine();
            }
        }

        public void FindPoem(string? titleSearch, string? authorSearch)
        {
            string? userAnswer;
            if (titleSearch == null && authorSearch == null)
            {
                Console.WriteLine();
                Console.WriteLine("Podaj tytuł wiersza lub nazwisko autora.");
                Console.WriteLine();

                userAnswer = Console.ReadLine();
            }
            else
            {
                userAnswer = titleSearch ?? authorSearch;
            }

            if (string.IsNullOrWhiteSpace(userAnswer))
            {
                Console.WriteLine();
                Console.WriteLine("Brak podanego tytułu lub nazwiska.");
                Console.WriteLine();
                return;
            }

            bool found = false;

            foreach (var poem in poems)
            {
                bool matchesTitle = !string.IsNullOrEmpty(titleSearch) && poem.Title.Contains(titleSearch, StringComparison.OrdinalIgnoreCase);
                bool matchesAuthor = !string.IsNullOrEmpty(authorSearch) && poem.Author.Contains(authorSearch, StringComparison.OrdinalIgnoreCase);  
                
                if (matchesTitle || matchesAuthor)
                {
                    Console.WriteLine($"Oto żądany wiersz: {poem.Title}, {poem.Author}.");
                    found = true;
                }
                }
            if (!found)
            {
                Console.WriteLine();
                Console.WriteLine("Nie ma w zbiorze takiego wiersza.");
                Console.WriteLine();
            }
        }

        public List<Poem> GetListAllPoems()
        {
            Console.WriteLine();
            Console.WriteLine("Oto lista wszystkich wierszy:");
            Console.WriteLine();

            foreach (var poem in poems)
            {
                Console.WriteLine($"{poem.Title} - {poem.Author} ({poem.LiteraryPeriod})");
            }
            return poems;
        }

        public List<Poem> ListPoemsByPeriod(string? period)
        {
            Console.WriteLine();
            Console.WriteLine("Podaj epokę litercaką: ");
            Console.WriteLine();

            string? answerPeriod = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(answerPeriod))
            {
                Console.WriteLine("Błąd. Podaj epokę literacką.");
                Console.WriteLine();
            }

            var poemsByPeriod = poems.Where(p => p.LiteraryPeriod.Equals(period, StringComparison.OrdinalIgnoreCase)).ToList();

            if (answerPeriod != null && poemsByPeriod.Count > 0)
            {
                Console.WriteLine($"Wiersze z epoki {period}:");
                Console.WriteLine();
                foreach (var poem in poemsByPeriod)
                {
                    Console.WriteLine($"{poem.Title} - {poem.Author}");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Nie znaleziono wierszy z epoki {period}.");
                Console.WriteLine();
            }

            return poemsByPeriod;
        }

        public int[] GetPoemCountsByPeriod()
        {
            int[] counts = new int[10];

            foreach (var poem in poems)
            {
                switch (poem.LiteraryPeriod)
                {
                    case "Starożytność":
                        counts[0]++;
                        break;

                    case "Średniowiecze":
                        counts[1]++;
                        break;

                    case "Renesans":
                        counts[2]++;
                        break;

                    case "Barok":
                        counts[3]++;
                        break;

                    case "Oświecenie":
                        counts[4]++;
                        break;

                    case "Romantyzm":
                        counts[5]++;
                        break;

                    case "Realizm":
                        counts[6]++;
                        break;

                    case "Modernizm":
                        counts[7]++;
                            break;

                    case "Postmodernizm":
                        counts[8]++;
                        break;

                    case "Współczesność":
                        counts[9]++;
                        break;
                }
            }
            string[] periods = { "Starożytność", "Średniowiecze", "Renesans", "Barok", "Oświecenie", "Romantyzm", "Realizm", "Modernizm", "Postmodernizm", "Współczesność" };

            for (int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{periods[i]}: {counts[i]} wierszy");
            }
            return counts;
        }

        public static void ExitLibrary()
        {
            Console.WriteLine("Żegnaj. Do zobaczenia następnym razem.");
        }

        public void SelectedOption(int value)
        {
            switch (value) 
            {
                case 1:
                    AddPoem(new Poem());
                    break;

                case 2:
                    RemovePoem(poem.Title);
                    break;

                case 3:
                    FindPoem(null, null);
                    break;

                case 4:
                    GetListAllPoems();
                    break;

                case 5:
                    ListPoemsByPeriod(PoemsByPeriod);
                    break;

                case 6:
                    GetPoemCountsByPeriod();
                    break;

                case 7:
                    ExitLibrary();
                    break;

                default:
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }
        }
    }
}

using System.IO;
using System.Windows;

namespace WordGameApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads a dictionary from a file and stores words in a dictionary with their lowercase form as the key.
        /// </summary>
        private static Dictionary<string, List<string>> ReadDictionary()
        {
            String line;
            var dictionary = new Dictionary<string, List<string>>();
            // Woerterbuch von hier: https://github.com/davidak/wortliste
            var uri = new Uri("/wortliste.txt", UriKind.Relative);
            var resourceStream = Application.GetResourceStream(uri);

            StreamReader sr = new(resourceStream.Stream);
            line = sr.ReadLine();
            while (line != null)
            {
                if (dictionary.TryGetValue(line.ToLower(), out var lst))
                {
                    lst.Add(line);
                }
                else
                {
                    dictionary.Add(line.ToLower(), [line]);
                }
                line = sr.ReadLine();
            }
            sr.Close();

            return dictionary;
        }

        /// <summary>
        /// Handles the click event of the button and arranges the input string.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(GetAnagrams(InputBox.Text));
        }

        /// <summary>
        /// Arranges the characters of a string and returns valid word permutations based on the dictionary.
        /// </summary>
        /// <param name="input">The input string to be arranged.</param>
        /// <returns>A string containing possible word permutations, one per line.</returns>
        private static string GetAnagrams(string s)
        {
            string sLower = s.ToLower();
            var dictionary = ReadDictionary();
            List<string> proposals = PermutationHelper.Arrange(sLower);
            List<string> filteredList = [];
            foreach (string word in proposals)
            {
                if (dictionary != null && dictionary.TryGetValue(word, out var value))
                {
                    foreach (string variant in value)
                    {
                        if (!filteredList.Contains(variant))
                        {
                            filteredList.Add(variant);
                        }
                    }
                }
            }
            return string.Join("\n", filteredList);
        }
    }

    public static class PermutationHelper
    { 
        /// <summary>
        /// Recursively generates all permutations of the given string.
        /// </summary>
        /// <param name="input">The string to permute.</param>
        /// <returns>A list of all possible permutations.</returns>
        public static List<string> Arrange(string s)
        {
            if (s == "")
            {
                return [""];
            }
            else
            {
                return InsertEverywhere(s[0], Arrange(s.Substring(1)));
            }
        }

        /// <summary>
        /// Inserts a character into every possible position of each word in a list.
        /// </summary>
        /// <param name="character">The character to insert.</param>
        /// <param name="words">The list of words to modify.</param>
        /// <returns>A list of words with the character inserted in all possible positions.</returns>
        private static List<string> InsertEverywhere(char a, List<string> words)
        {
            List<string> result = [];
            foreach (string word in words)
            {
                for (int i = 0; i < word.Length + 1; i++)
                {
                    result.Add(word.Insert(i, a.ToString()));
                }
            }
            return result;
        }
    }
}
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

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

        private Dictionary<string, List<string>> ReadDictionary()
        {
            String line;
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            // Woerterbuch von hier: https://github.com/davidak/wortliste
            var uri = new Uri("/wortliste.txt", UriKind.Relative);
            var resourceStream = Application.GetResourceStream(uri);
            try
            {                
                StreamReader sr = new StreamReader(resourceStream.Stream);
                line = sr.ReadLine();
                while (line != null)
                {
                    List<string> lst;
                    if (dictionary.TryGetValue(line.ToLower(), out lst))
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
                Console.ReadLine();
            }
            catch (Exception e)
            {
                MessageBox.Show("Konnte die Wörterbuch Datei nicht finden. Zeige alle Permutationen.");
            }
            return dictionary;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Arrange(InputBox.Text));
        }

        private string Arrange(string s)
        {
            string sLower = s.ToLower();
            Dictionary<string, List<string>> dictionary = ReadDictionary();
            List<string> proposals = _Arrange(sLower);
            List<string> filteredList = [];
            bool noDict = dictionary == null;
            foreach (string word in proposals)
            {
                if (!noDict && dictionary.Keys.Contains(word)) {
                    foreach (string variant in dictionary[word])
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

        private static List<string> _Arrange(string s)
        {
            if (s == "")
            {
                return [""];
            } else
            {
                return InsertEverywhere(s[0], _Arrange(s.Substring(1)));
            }    
        }

        private static List<string> InsertEverywhere(char a, List<string> words)
        {
            List<string> result = new();
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
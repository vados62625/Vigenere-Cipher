using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string source;
        string key;
        string result;
        string encrypted;
        char[,] rusTable = new char[33, 33];
        char[] rusAlph = new char[32];


        public string Encrypt(string source, string key)
        {
            string keyNewLength = "";
            string encryptedString = "";
            while (keyNewLength.Length <= source.Length)
            {
                keyNewLength += key;
            }
            result = keyNewLength.Substring(0, source.Length); 
            for (int i = 0; i < source.Length; i++)
            {
                if (((int)(source[i]) < 1072) || ((int)(source[i]) > 1103))
                {
                    encryptedString += source[i];
                }
                int n = 0;
                while (n < 33)
                {
                    if (source[i] == rusTable[n, 0])
                    {
                        int m = 0;
                        for (int j = 0; j < 33; j++)
                        {
                            while (m < 33)
                            {
                                if (result[i] == rusTable[0, m])
                                {
                                    encryptedString += rusTable[n, m];                                                                        
                                }
                                m++;
                            }                            
                        }
                    }   
                    n++;
                }
            }
            return encryptedString;
        }


        public string Decrypt(string encrypted, string key)
        {
            string keyNewLength = "";
            string decryptedString = "";

            while (keyNewLength.Length <= encrypted.Length)
            {
                keyNewLength += key;
            }
            result = keyNewLength.Substring(0, encrypted.Length);
            for (int i = 0; i < result.Length; i++)
            {
                if (((int)(encrypted[i]) < 1072) || ((int)(encrypted[i]) > 1103))
                {
                    decryptedString += encrypted[i];
                }
                int n = 0;
                while (n < 33)
                {
                    if (result[i] == rusTable[0, n])
                    {
                        int m = 0;
                        for (int j = 0; j < 33; j++)
                        {
                            while (m < 33)
                            {
                                if (encrypted[i] == rusTable[m, n])
                                {
                                    decryptedString += rusTable[m, 0];
                                }
                                m++;
                            }
                        }
                    }
                    n++;
                }
            }
            return decryptedString;
        }


        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var src = new TextRange(text1.Document.ContentStart, text1.Document.ContentEnd);
            source = src.Text;
            encrypted = src.Text;
        }


        private void encr_Click(object sender, RoutedEventArgs e)
        {
            Class1.createRusAlph(rusAlph);
            Class1.createTable(rusTable, 0, rusAlph);
            var enc = new TextRange(resultText.Document.ContentStart, resultText.Document.ContentEnd);
            enc.Text = Encrypt(source, key);
        }


        private void keyText_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            key = keyText.Text;

        }


        private void text1_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            try
            {
                e.Handled = !(Char.IsLetter(e.Text, 0) && Char.IsLower(e.Text, 0));
            }
            catch
            {
                MessageBox.Show("Вы можете вводить только строчные буквы!");
            }
        }


        private void keyText_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            try
            {
                e.Handled = !(Char.IsLetter(e.Text, 0) && Char.IsLower(e.Text, 0));
            }
            catch
            {
                MessageBox.Show("Вы можете вводить только строчные буквы!");
            }
        }


        private void decr_Click(object sender, RoutedEventArgs e)
        {
            Class1.createRusAlph(rusAlph);
            Class1.createTable(rusTable, 0, rusAlph);
            var dec = new TextRange(resultText.Document.ContentStart, resultText.Document.ContentEnd);
            dec.Text = Decrypt(source, key);
        }
    }
}
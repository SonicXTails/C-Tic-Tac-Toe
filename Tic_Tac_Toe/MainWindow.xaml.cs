using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
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

namespace Tic_Tac_Toe
{
    public partial class MainWindow : Window
    {
        Button[] B;
        public MainWindow()
        {
            InitializeComponent();
            B = new Button[9] { _1, _2, _3, _4, _5, _6, _7, _8, _9 };

            foreach (Button b in B)
            {
                b.IsEnabled = false;
                b.Content = " ";
            }
        }

        private void Win_O_X(string btnContent)
        {
            if ((B[0].Content == btnContent && B[1].Content == btnContent && B[2].Content == btnContent) ||
                (B[3].Content == btnContent && B[4].Content == btnContent && B[5].Content == btnContent) ||
                (B[6].Content == btnContent && B[7].Content == btnContent && B[8].Content == btnContent) || // Вертикали

                (B[0].Content == btnContent && B[3].Content == btnContent && B[6].Content == btnContent) ||
                (B[1].Content == btnContent && B[4].Content == btnContent && B[7].Content == btnContent) ||
                (B[2].Content == btnContent && B[5].Content == btnContent && B[8].Content == btnContent) || // Горизонтали

                (B[0].Content == btnContent && B[4].Content == btnContent && B[8].Content == btnContent) || // Диагонали
                (B[2].Content == btnContent && B[4].Content == btnContent && B[6].Content == btnContent)) 
            {
                if (btnContent == "X")
                {
                    MessageBox.Show("Победил игрок X");

                    foreach (Button b in B)
                    {
                        b.IsEnabled = true;
                        b.Content = " ";
                    }
                }
                else if (btnContent == "O") 
                {
                    MessageBox.Show("Победил игрок O");

                    foreach (Button b in B)
                    {
                        b.IsEnabled = true;
                        b.Content = " ";
                    }
                }
            }
            else if (B[0].IsEnabled == false && B[1].IsEnabled == false && B[2].IsEnabled == false &&
                     B[3].IsEnabled == false && B[4].IsEnabled == false && B[5].IsEnabled == false &&
                     B[6].IsEnabled == false && B[7].IsEnabled == false && B[8].IsEnabled == false)
            {
                MessageBox.Show("Ничья!");

                foreach (Button b in B)
                {
                    b.IsEnabled = true;
                    b.Content = " ";
                }
            }
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {

            Win_O_X((sender as Button).Content.ToString());

            (sender as Button).Content = "X";
            (sender as Button).IsEnabled = false;

            Random r = new Random();
            int number = r.Next(0, 9);

            if (B[0].IsEnabled == false && B[1].IsEnabled == false && B[2].IsEnabled == false &&
                B[3].IsEnabled == false && B[4].IsEnabled == false && B[5].IsEnabled == false &&
                B[6].IsEnabled == false && B[7].IsEnabled == false && B[8].IsEnabled == false)
            {
                // Ничё не надо и так работает :3
            }
            else
            {
                while (B[number].IsEnabled == false)
                {
                    number = r.Next(0, 9);
                }

                B[number].Content = "O";
                B[number].IsEnabled = false;

                Win_O_X(B[number].Content.ToString());
            }

            Win_O_X((sender as Button).Content.ToString());
        }


        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button b in B)
            {
                b.IsEnabled = true;
                b.Content = " ";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Оно тут надо. Лучше не убирать.
        }

    }
}


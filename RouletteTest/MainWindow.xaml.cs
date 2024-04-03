using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RouletteTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateNumberSlots();
        }

        private void GenerateNumberSlots()
        {
            for (int i = 0; i < 12; i++)
            {
                NumbersGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < 3; i++)
            {
                NumbersGrid.RowDefinitions.Add(new RowDefinition());
            }
            int[,] numbers = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10, 11, 12 },
                { 13, 14, 15 },
                { 16, 17, 18 },
                { 19, 20, 21 },
                { 22, 23, 24 },
                { 25, 26, 27 },
                { 28, 29, 30 },
                { 31, 32, 33 },
                { 34, 35, 36 }
            };
            int[] redNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

            for (int col = 0; col < 12; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    int num = numbers[col, row];
                    var border = new Border
                    {
                        Background = redNumbers.Contains(num) ? Brushes.Red : Brushes.Black,
                        BorderBrush = Brushes.White,
                        BorderThickness = new Thickness(2),
                        Height = 60,
                        Width = 60,
                        Margin = new Thickness(2, 2, 2, 2)
                    };

                    var textBlock = new TextBlock
                    {
                        Text = num.ToString(),
                        Foreground = Brushes.White,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 24
                    };

                    border.Child = textBlock;
                    Grid.SetRow(border, 2 - row); // Invert
                    Grid.SetColumn(border, col);
                    NumbersGrid.Children.Add(border);
                }
            }
        }

    }
}



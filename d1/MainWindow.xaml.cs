using System;
using System.Collections.Generic;
using System.Linq;
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

namespace d1
{

    public partial class MainWindow : Window
    {
        BitmapImage mine = new BitmapImage(new Uri(@"pack://application:,,,/imj/mine.png", UriKind.Absolute));
        generator gen = new generator();
        int minCount = 5;
        int open = 1;

        public MainWindow()

        {
            InitializeComponent();

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            BtnBomb btn = (BtnBomb)sender;

            //получение значения лежащего в Tag
            int n = (int)((Button)sender).Tag;

            if (gen.getCell(n%5, n/5) == -1)
            {
                BtnBomb[] bb = new BtnBomb[ugr.Children.Count];
                ugr.Children.CopyTo(bb, 0);

                for (int i = 0; i < bb.Length; i++)
                {
                    if (gen.getCell(i % 5, i / 5) == -1)
                    {
                        //создание контейнера для хранения изображения
                        Image img = new Image();

                        //запись картинки с миной в контейнер
                        img.Source = mine;
                        //создание компонента для отображения изображения
                        StackPanel stackPnl = new StackPanel();
                        //установка толщины границ компонента
                        stackPnl.Margin = new Thickness(1);
                        //добавление контейнера с картинкой в компонент
                        stackPnl.Children.Add(img);
                        //запись компонента в кнопку
                        bb[i].Content = stackPnl;
                    }
                    
                }
                MessageBox.Show("Вы проиграли");
                ugr.IsEnabled = false;
            }
            else
            {
                open++;
                //установка фона нажатой кнопки, цвета и размера шрифта
                ((Button)sender).Background = Brushes.White;
                ((Button)sender).Foreground = Brushes.Red;
                ((Button)sender).FontSize = 23;
                //запись в нажатую кнопку её номера
                ((Button)sender).Content = gen.getCell(n%5, n/5) ;

                if (open == (5*5 - minCount))
                {
                    MessageBox.Show("Вы выиграли!");
                    ugr.IsEnabled = false;
                }

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ugr.Children.Clear();
            open = 0;
            ugr.IsEnabled = true;

            gen.set(5);
            gen.plant(minCount);
            gen.ciferki();

            Random bomb = new Random();


            //указыается количество строк и столбцов в сетке
            ugr.Rows = 5;
            ugr.Columns = 5;
            //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
            ugr.Width = 5 * (40 + 4);
            ugr.Height = 5 * (40 + 4);
            //толщина границ сетки
            ugr.Margin = new Thickness(5, 5, 5, 5);

            for (int i = 0; i < 5 * 5; i++)
            {
                //создание кнопки
                BtnBomb btn = new BtnBomb();
                //запись номера кнопки
                btn.Tag = i;
                //установка размеров кнопки
                btn.Width = 40;
                btn.Height = 40;
                //текст на кнопке
                btn.Content = " ";

                if (bomb.Next(0, 25) < 12)
                {
                    btn.isBomb = true;
                }

                btn.Margin = new Thickness(2);
                //при нажатии кнопки, будет вызываться метод Btn_Click
                btn.Click += Btn_Click;
                //добавление кнопки в сетку
                ugr.Children.Add(btn);
            }
        }
    }

    class BtnBomb: Button
    {
        public bool isBomb;
    }
}

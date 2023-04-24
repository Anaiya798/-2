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

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> _bigImg = new Dictionary<string, string>()
        {
            {"milkBtn", "Imgs/Icons/Diary/milk.jpg" },
            {"cheeseBtn", "Imgs/Icons/Diary/cheese.jpeg" },
            {"youghurtBtn", "Imgs/Icons/Diary/youghurt.jpg" },
            {"icecreamBtn", "Imgs/Icons/Diary/icecream.jpg" },
            {"sourcreamBtn", "Imgs/Icons/Diary/sourcream.jpg" },
            {"cucumbersBtn", "Imgs/Icons/Fruit/cucumbers.jpg" },
            {"tomatoesBtn", "Imgs/Icons/Fruit/tomatoes.jpeg" },
            {"appleBtn", "Imgs/Icons/Fruit/apple.jpeg" },
            {"peachBtn", "Imgs/Icons/Fruit/peach.jpg" },
            {"breadBtn", "Imgs/Icons/Bakery/bread.jpg" },
            {"loafBtn", "Imgs/Icons/Bakery/loaf.jpg" },
            {"gingerbreadBtn", "Imgs/Icons/Bakery/gingerbread.jpg" },
            {"pretzelBtn", "Imgs/Icons/Bakery/pretzel.jpg" }
        };

        private Dictionary<string, string> _bigImgText = new Dictionary<string, string>()
        {
            {"milkBtn", "Свежее финское молоко, без лактозы" },
            {"cheeseBtn", "Сыр \"Ламбер\", тот самый вкус Алтая" },
            {"youghurtBtn", "Натуральный финский йогурт, клубника" },
            {"icecreamBtn", "Золотой стандарт мороженого" },
            {"sourcreamBtn", "Сметана \"Простоквашино\", красная цена" },
            {"cucumbersBtn", "Огурцы короткоплодные" },
            {"tomatoesBtn", "Томаты сливовидные, хит сезона" },
            {"appleBtn", "Яблоки, новый урожай" },
            {"peachBtn", "Персики сочные, успейте попробовать" },
            {"breadBtn", "Хлеб бородинский" },
            {"loafBtn", "Батон низкокалорийный" },
            {"gingerbreadBtn", "Тульский пряник - гордость наших пекарей" },
            {"pretzelBtn", "Соленый крендель - лучший к чаю" }
        };
        public Dictionary<string, string> BigImg
        {
            get { return _bigImg; }
            private set { }
        }
        public Dictionary<string, string> BigImgText
        {
            get { return _bigImgText;}
            private set { }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowBigImg(object sender, RoutedEventArgs e)
        {
            string btnName = ((Button)e.OriginalSource).Name;
            outputImage.Source = new BitmapImage(new Uri(BigImg[btnName], UriKind.Relative));
            outputText.Text = BigImgText[btnName];
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

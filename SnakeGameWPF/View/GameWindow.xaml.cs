using System.Windows;
using SnakeGameWPF.ViewModel;

namespace SnakeGameWPF.View
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            DataContext = new GameWindowViewModel();
        }
    }
}

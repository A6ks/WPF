using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AnimateOut();
        }
    }
}

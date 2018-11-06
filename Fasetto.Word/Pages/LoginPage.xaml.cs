using System.Security;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel> , IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The secure password fot this page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}

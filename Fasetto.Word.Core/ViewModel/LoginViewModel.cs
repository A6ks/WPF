using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Member

        

        #endregion

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        public SecureString Password { get; set; }

        /// <summary>
        /// A flag indicate if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to register for a new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public LoginViewModel()
        {            
            //Create commands            
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));

            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                var email = this.Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

            });
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>       
        public async Task RegisterAsync()
        {
            //TODO: Go to register page?
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;

            await Task.Delay(1);
        }
    }
}

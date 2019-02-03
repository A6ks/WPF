using System.Threading.Tasks;
using System.Windows;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// The application implementation of the <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            // Create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            Task.Run(() => {
                // Run on UI thread
                Application.Current.Dispatcher.Invoke(() =>
                {
                    try
                    {
                        //Show Dialog
                        new DialogWindow().ShowDialog();
                    }
                    finally
                    {
                        // Le caller know we finished
                        tcs.TrySetResult(true);
                    }
                })
            });

            return tcs.Task;
        }
    }
}

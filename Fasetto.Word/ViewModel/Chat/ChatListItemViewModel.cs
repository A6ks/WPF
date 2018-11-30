namespace Fasetto.Word
{
    /// <summary>
    /// A view model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The display name of this chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The initials to show for the profile pricture background
        /// </summary>
        public string Intials { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }
    }
}

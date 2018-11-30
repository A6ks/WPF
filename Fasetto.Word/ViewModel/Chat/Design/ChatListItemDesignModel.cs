namespace Fasetto.Word
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singelton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Intials = "LM";
            Name = "Luke";
            Message = "This chat app is awasome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        /// <summary>
        /// True to show the attachment menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// True if any popup menu is visible
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible;

        /// <summary>
        /// The view model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        #endregion

        #region Public commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListViewModel()
        {
            // Create commands
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }
                
        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is ckicked show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            // Toggle meny visibility
            AttachmentMenuVisible ^= true;
        }

        /// <summary>
        /// When the popup clickaway area is clicked hide any popups
        /// </summary>
        public void PopupClickaway()
        {
            // Hide attachment menu
            AttachmentMenuVisible = false;
        } 

        #endregion
    }
}

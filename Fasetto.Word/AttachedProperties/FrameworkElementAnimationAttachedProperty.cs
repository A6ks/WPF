using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// A base class to run any animation method when a booelean is set to true
    /// and a reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnamateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool> 
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public properties

        /// <summary>
        /// A flag indicating if this is the first time this property has been loaded
        /// </summary>
        public bool FirstLoad { get; set; } = true;
               
        #endregion

        #region Protected Properties

        /// <summary>
        /// True if this is the very first time the value has been updated
        /// Used to make sure we run the logic at least onece during first load
        /// </summary>
        protected bool mFirstFire = true;

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //Get the framework element
            if (!(sender is FrameworkElement element))
                return;

            // Don't fire if the value doesn't change
            if ((bool)sender.GetValue(ValueProperty) == (bool)value && !mFirstFire)
                return;

            // No longer first fire
            mFirstFire = false;

            // On first load...
            if(FirstLoad)
            {
                // Start off hidden before we dicide how to animate 
                // if we are to be animated out initially
                if(!(bool)value)
                    element.Visibility = Visibility.Hidden;

                // Create a single self-unhookable event
                // for the element Loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = async (ss, ee) =>
                {
                    // Slight delay after load is needed for some elements to get laid out
                    // and their width/heights correctly calculated
                    await Task.Delay(5);

                    // Unhook ourselves
                    element.Loaded -= onLoaded;

                    //Do desired animation
                    DoAnimation(element, (bool)value);

                    // No longer first load
                    FirstLoad = false;
                };

                //Hook into the Loaded event of the element
                element.Loaded += onLoaded;
            }
            else            
                //Do desired animation
                DoAnimation(element, (bool)value);

        }
        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="value">The new value</param>       
        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
    }

    /// <summary>
    /// Animates a framework element sliding it in from the left on show
    /// and sliding out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnamateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //Animate in
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);

        }
    }

    /// <summary>
    /// Animates a framework element sliding up from the bottom on show
    /// and sliding out to the buttom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnamateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //Animate in
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : .3f, keepMargin: false);

        }
    }

    /// <summary>
    /// Animates a framework element sliding up from the bottom on show
    /// and sliding out to the buttom on hide
    /// NOTES: Keep the margin
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnamateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //Animate in
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f);
            else
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : .3f);

        }
    }

    /// <summary>
    /// Animates a framework element fading in on show
    /// and fading out on hide
    /// </summary>
    public class AnimateFadeInProperty : AnamateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //Animate in
                await element.FadeInAsync(FirstLoad ? 0 : 0.3f);
            else
                await element.FadeOutAsync(FirstLoad ? 0 : 0.3f);

        }
    }
}

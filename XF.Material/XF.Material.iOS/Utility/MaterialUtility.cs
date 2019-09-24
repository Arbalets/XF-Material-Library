using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF.Material.Forms.Utilities;
using XF.Material.iOS.Utility;

[assembly: Dependency(typeof(MaterialUtility))]
namespace XF.Material.iOS.Utility
{
    /// <inheritdoc />
    /// <summary>
    /// Concrete implementation which provides methods that can be used to change platform-specific configurations.
    /// </summary>
    public class MaterialUtility : IMaterialUtility
    {
        public void ChangeStatusBarColor(Color color)
        {
            var isColorDark = color.ToCGColor().IsColorDark();
            UIApplication.SharedApplication.StatusBarStyle = isColorDark ? UIStatusBarStyle.LightContent : UIStatusBarStyle.Default;

            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                // TODO: This is a temp solution, see https://stackoverflow.com/questions/58069085/change-status-bar-colour-on-ios13
                var statusBar = new UIView(UIApplication.SharedApplication.StatusBarFrame)
                {
                    BackgroundColor = color.ToUIColor()
                };
                UIApplication.SharedApplication.Windows[0].AddSubview(statusBar);
            }
            else
            {
                if (UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) is UIView statusBar)
                    statusBar.BackgroundColor = color.ToUIColor();
            }
        }
    }
}
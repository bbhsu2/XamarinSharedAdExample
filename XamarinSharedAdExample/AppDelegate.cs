using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace XamarinSharedAdExample
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        //Create a reference of AppDelegate so we can access Navigation and other properties
        public static AppDelegate Reference;

        public bool IsAdSupported = true;

        UIWindow window;
        CustomAd adBanner; 
        UINavigationController navigation;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Reference = this;

            window = new UIWindow(UIScreen.MainScreen.Bounds);
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes{
                TextColor = UIColor.White
            });

            var tvc = new MyTableViewController(ShowMyViewController);
            navigation = new UINavigationController(tvc);

            navigation.NavigationBar.TintColor = UIColor.White;
            navigation.NavigationBar.BarTintColor = UIColor.Blue;
            
            window.RootViewController = navigation;
            if (IsAdSupported)
                window.RootViewController.Add(adBanner = new CustomAd());
            window.MakeKeyAndVisible();
            return true;
        }

        public void ShowMyViewController(string Content)
        {
            navigation.PushViewController(new MyViewController(Content), true);
        }
    }
}


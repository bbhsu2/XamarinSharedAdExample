/*
    Xamarin Shared Ad Example
 *  www.github.com/bbhsu2/XamarinSharedAdExample
 *  Written by Bernard Hsu
 *  4/27/2014
 */

using MonoTouch.UIKit;

namespace XamarinSharedAdExample
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
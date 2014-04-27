/*
    Xamarin Shared Ad Example
 *  www.github.com/bbhsu2/XamarinSharedAdExample
 *  Written by Bernard Hsu
 *  4/27/2014
 */

using MonoTouch.iAd;
using MonoTouch.UIKit;
using System;

namespace XamarinSharedAdExample
{
    class CustomAd : ADBannerView
    {
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            //set the bounds for the ad
            var bounds = UIScreen.MainScreen.Bounds;

            //the top bar (status + nav) is 64pts in heght see http://www.idev101.com/code/User_Interface/sizes.html, so push everything down by 64
            this.Frame = new System.Drawing.RectangleF(0, 64, bounds.Width, Frame.Height);

            //Set the AdLoaded handler to hide the ad depending on the setting.
            this.AdLoaded += (object sender, EventArgs e) =>
            {
                if (AppDelegate.Reference.IsAdSupported)
                    this.Hidden = false;
                else
                    this.Hidden = true;
            };
        }
    }
}
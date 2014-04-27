/*
    Xamarin Shared Ad Example
 *  www.github.com/bbhsu2/XamarinSharedAdExample
 *  Written by Bernard Hsu
 *  4/27/2014
 */

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using System;
using System.Collections.Generic;
using System.Drawing;

namespace XamarinSharedAdExample
{
    class MyTableViewController : UITableViewController
    {
        public Action<string> TableItemTapped = delegate { };

        List<string> sampleContent;

        public MyTableViewController(Action<string> NavigationHandler)
        {
            Title = "Table View Controller";

            //Set the RowSelected method in the TableViewSource to point to a centralized Navigation method 
            //that lives in the AppDelegate
            TableItemTapped = NavigationHandler;

            //Set the Back button to just an arrow when we navigation to MyViewController
            NavigationItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, handler: null);

            //This data populates the table.
            sampleContent = new List<string>()
            {
                "Hello",
                "My Name is",
                "Bernard",
                "This is a cool",
                "Xamarin iOS Demo",
                "So that you can have",
                "A universal advertisement",
                "I hope this helps!",
                "I <3 Xamarin!"
            };

            TableView.Source = new MyTableViewSource(selections => TableItemTapped(selections), sampleContent);
        }

        //this is the important method for setting the table position when the Ad is loaded or not
        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            if (AppDelegate.Reference.IsAdSupported)
            {
                //Shift table down if ad is present
                this.TableView.Frame = new RectangleF(0, 50, View.Bounds.Width, View.Bounds.Height);

                //set the table so all cells are reachable during scroll
                TableView.ContentInset = new UIEdgeInsets(64, 0, 50, 0); 
            }
        }


        class MyTableViewSource : UITableViewSource
        {
            readonly Action<string> ItemTapped;
            
            public IReadOnlyList<string> Content;
            
            string cellId = "TableCell";

            public MyTableViewSource(Action<string> ItemTapped, List<string> Content)
            {
                this.ItemTapped = ItemTapped;
                this.Content = Content;
            }

            public override int RowsInSection(UITableView tableview, int section)
            {
                return Content.Count;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (Content == null)
                    return;
                ItemTapped(Content[indexPath.Row]);
                tableView.DeselectRow(indexPath, false);
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell = tableView.DequeueReusableCell(cellId) ?? new UITableViewCell(UITableViewCellStyle.Default, cellId);

                cell.TextLabel.Text = Content[indexPath.Row];
                cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

                return cell;
            }
        }
    }
}
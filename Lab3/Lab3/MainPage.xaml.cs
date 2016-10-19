using Lab3.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.EntityFrameworkCore;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new BloggingContext())
            {
                Blogs.ItemsSource = db.Blogs.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BloggingContext())
            {
                if (NewBlogUrl.Text != "")
                {
                    var blog = new Blog { Url = NewBlogUrl.Text };
                    db.Blogs.Add(blog);
                    db.SaveChanges();

                }

                Blogs.ItemsSource = db.Blogs.ToList();

                // clear add textbox
                NewBlogUrl.Text = "";
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BloggingContext())
            {
                var blog = new Blog { Url = NewBlogUrl.Text };

                if (Blogs.SelectedItem != null || SearchResults.SelectedItem != null)
                {
                    if (Blogs.SelectedItem != null)
                    {
                        db.Blogs.Remove(Blogs.SelectedItem as Blog);
                        db.SaveChanges();
                    } else
                    {
                        db.Blogs.Remove(SearchResults.SelectedItem as Blog);
                        db.SaveChanges();

                    }

                    // reload the items
                    Blogs.ItemsSource = db.Blogs.ToList();

                    // reload the search results
                    var blogs = db.Blogs.Where(b => b.Url.ToLower().Contains(SearchBox.Text.ToString().ToLower()));
                    SearchResults.ItemsSource = blogs.ToList();

                }
  
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new BloggingContext())
            {
                var blogs = db.Blogs.Where(b => b.Url.ToLower().Contains(SearchBox.Text.ToString().ToLower()));

                SearchResults.ItemsSource = blogs.ToList();

                if(SearchResults.Items.Count < 1)
                {
                    SearchResultStackPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    SearchResultStackPanel.Visibility = Visibility.Visible;
                }


            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace efiszkiProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class gamesszubienica1 : Page
    {
        public static string baza = "";
        public gamesszubienica1()
        {
            this.InitializeComponent();
            SetCombo();
            gamesstandardlearningnext.IsEnabled = false;
        }
        private async void SetCombo()
        {
            var path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //var files = await folder.GetFilesAsync();

            IReadOnlyList<StorageFile> fList = await folder.GetFilesAsync();
            foreach (var f in fList)
            {
                //Debug.WriteLine(f.DisplayName);
                if (f.DisplayName.Equals("AppData"))
                {
                    comboboxdostepnebazy.Items.Add("eFiszki");
                }
                else
                {
                    comboboxdostepnebazy.Items.Add(f.DisplayName);
                }
            };
        }

        private void comboboxdostepnebazy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gamesstandardlearningnext.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Games));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            baza = comboboxdostepnebazy.SelectedValue.ToString();
            this.Frame.Navigate(typeof(gamesszubienica2));
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}

﻿using FinanceApp.Models;
using FinanceApp.Views;
using System;
using Xamarin.Forms;

namespace FinanceApp.Behaviors
{
    public class ListViewBehavior : Behavior<ListView>
	{
		ListView listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            listView = bindable;
            listView.ItemSelected += ListView_ItemSelected;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            listView.ItemSelected -= ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Item selectedItem = listView.SelectedItem as Item;
            Application.Current.MainPage.Navigation.PushAsync(new PostPage(selectedItem));
        }
    }
}


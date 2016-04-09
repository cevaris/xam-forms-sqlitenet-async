using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SqliteAsyncExample.ViewModels;

namespace SqliteAsyncExample.Views
{
    public partial class MoviesPage : ContentPage
    {
        public MoviesPage()
        {
            InitializeComponent();

            BindingContext = new MoviesViewModel (this);
        }
    }
}


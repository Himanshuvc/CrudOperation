using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Crud
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Title = "Select Option";
            StackLayout st = new StackLayout();
            Button btn = new Button();
            btn.Text = "Add Company";
            btn.Clicked += btnclicked;
            st.Children.Add(btn);

            Button btn1 = new Button();
            btn1.Text = "Get";
            btn1.Clicked += btnclickedGet;
            st.Children.Add(btn1);

            Button btn2 = new Button();
            btn2.Text = "Edit";
            btn2.Clicked += btnclickededit;
            st.Children.Add(btn2);

            Button btn3 = new Button();
            btn3.Text = "Delete";
            btn3.Clicked += btnclickedDel;
            st.Children.Add(btn3);
            Content = st;
        }

        private async void btnclickedDel(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DelComapny());
        }

        private async void btnclickededit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditComapny());
        }

        private async void btnclickedGet(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllCompany());
        }

        private async void btnclicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCompany());
        }
    }
}

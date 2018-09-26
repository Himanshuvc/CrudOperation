using Crud.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crud
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCompany : ContentPage
    {
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");

        public AddCompany()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            db.CreateTable<Company>();
            var maxPk = db.Table<Company>().OrderByDescending(c => c.ID).FirstOrDefault();

            Company company = new Company()
            {
                ID = (maxPk == null ? 1 : maxPk.ID + 1),
                Name = Cname.Text,
                Address = CAdd.Text
            };
            db.Insert(company);
            await DisplayAlert(null, company.Name, "ok");
            await Navigation.PopAsync();
        }
    }
}
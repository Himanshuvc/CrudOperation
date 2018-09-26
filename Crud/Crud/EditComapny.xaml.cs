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
	public partial class EditComapny : ContentPage
    {
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");
        Company _company = new Company();
        public EditComapny ()
		{
			InitializeComponent ();
            var db = new SQLiteConnection(_dbpath);
            lstAllcomp.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
        }

        private void lstAllcomp_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = (Company)e.SelectedItem;
            Cid.Text = _company.ID.ToString();
            Cname.Text = _company.Name.ToString();
            CAdd.Text = _company.Address.ToString();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            Company com = new Company()
            {
                ID = Convert.ToInt32(Cid.Text),
                Name = Cname.Text,
                Address = CAdd.Text

            };
            db.Update(com);
            await Navigation.PopAsync();
        }
    }
}
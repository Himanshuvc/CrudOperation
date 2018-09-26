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
	public partial class DelComapny : ContentPage
    {
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");
        Company _com = new Company();
        public DelComapny ()
		{
			InitializeComponent ();
            var db = new SQLiteConnection(_dbpath);
            lstAllcomp1.ItemsSource= db.Table<Company>().OrderBy(x => x.Name).ToList();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            db.Table<Company>().Delete(x => x.ID == _com.ID);
            await Navigation.PopAsync();
        }

        private void lstAllcomp_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _com = (Company)e.SelectedItem;
        }
    }
}
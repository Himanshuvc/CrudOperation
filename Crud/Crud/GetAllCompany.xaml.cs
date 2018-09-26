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
	public partial class GetAllCompany : ContentPage
	{
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");
        
        public GetAllCompany ()
		{
			InitializeComponent ();
            this.Title = "All Companies";
            var db = new SQLiteConnection(_dbpath);
            lstAllcomp.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
		}
	}
}
using AlphaVet.Helpers;

namespace AlphaVet
{
    public partial class App : Application
    {
            static SQLiteDBhelpers _db;

        public static SQLiteDBhelpers Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");
                    _db = new SQLiteDBhelpers(path);
                }
                return _db;
            }
        }
        public App() 
        { 
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}


using AlphaVet.Helpers;

namespace AlphaVet
{
    public partial class App : Application
    {
        static SQLiteDBhelpers _db;
        static clientesqlhelper _clientedb;
        static animalsqlhelper _animaldb;
        static usersqlhelper _userdb;

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

        public static clientesqlhelper clientedb
        {
            get
            {
                if (_clientedb == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");
                    _clientedb = new clientesqlhelper(path);
                }
                return _clientedb;
            }
        }

        public static animalsqlhelper animaldb
        {
            get
            {
                if (_animaldb == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");
                    _animaldb = new animalsqlhelper(path);
                }
                return _animaldb;
            }
        }

        public static usersqlhelper userdb
        {
            get
            {
                if (_userdb == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");
                    _userdb = new usersqlhelper(path);
                }
                return _userdb;
            }
        }

        public App() 
        { 
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}


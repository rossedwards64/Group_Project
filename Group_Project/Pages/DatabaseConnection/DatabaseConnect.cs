using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group_Project.Pages.DatabaseConnection
{
    public class DatabaseConnect
    {
        public string DatabaseString ()
        {
            string DbString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\redwa\Documents\Uni Work\Web\C# Module\Group Project\Group_Project\Group_Project\Data\Database.mdf;Integrated Security=True";
            return DbString;
        }
    }
}

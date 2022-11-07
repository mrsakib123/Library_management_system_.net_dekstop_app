using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace LibrararyManagement
{
    class connection
    {
        public SqlConnection thisConnection = new SqlConnection("Data Source=DESKTOP-7TK67LC\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;");
    }

}

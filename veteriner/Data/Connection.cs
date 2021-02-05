using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veteriner.Data
{
    class Connection
    {
      //Constructor Connection
       public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AJC749U\SQLEXPRESS;Initial Catalog=Veteriner;Integrated Security=True");
       //veri tabanı pathı

        public void Baglan()
        {
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                con.Close();
            }

        }

    }
}

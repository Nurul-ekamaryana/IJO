using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
//using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;



namespace Tugas_PBO_2_DataBase
{
    internal class Module
    {
        string konek;
        //MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        // dt = new DataTable();

        public Module()
        {
            konek = "server=localhost;Uid=root;database=akademik";
        }

        public void GetDataTable(string sql)
        {
            DataTable result = new DataTable();
            MySqlConnection conn = new MySqlConnection(konek);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            result.Load(dr);
            conn.Close();
            //return result;
        }

        public void ExecuteQuery(string sql)
        {
            MySqlConnection conn = new MySqlConnection(konek);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void TampiList(ListView lv, string sql)
        {
            MySqlConnection conn = new MySqlConnection(konek);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            lv.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new
                ListViewItem(reader.GetString(0).ToString());
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                lv.Items.Add(item);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
        }

        public void Bersih(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Text = "";
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Software_Toko
{
    class Database
    {
        MySqlConnection con;
        String konf = "Server=localhost;port=3306;UID=root;PWD=;Database=db_retail";
        DataTable dt;

        public String loginUser(String user, String pass)
        {
            dt = new DataTable();
            String result = "0";
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "select count(*) from tb_user where namauser='" + user + "' and sandi='" + pass + "' and status='1'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                adapter.Fill(dt);
                result = dt.Rows[0][0].ToString();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return result;
            }
        }

        public DataTable getDataUser(String value)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "select * from tb_user WHERE namauser ='" + value + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                adapter.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dt;
            }
        }

        public void updateLastLogin(String id)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "update tb_user set last_login=NOW() where id_user='" + id + "'";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable showtDataUser()
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "SELECT id_user, id_pegawai, role, namauser, sandi, IF(tb_user.`status`='1','aktif','nonaktif') AS STATUS, last_login FROM tb_user";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                adapter.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dt;
            }
        }

        public DataTable showtDataPegawai()
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "SELECT id_pegawai, CONCAT(nama_depan, ' ',nama_belakang) AS nama, IF(tb_master_pegawai.`status`='1','aktif','nonaktif') AS STATUS FROM tb_master_pegawai";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                adapter.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dt;
            }
        }

        public void addUser(String idEmployee, String role, String uname, String upass, int status)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "insert into master_user (role, username, passwd, id_employee, status) values('" + role + "','" + uname + "','" + upass + "','" + idEmployee + "','" + status + "')";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void addPegawai(String idEmployee, String role, String uname, String upass, int status)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "insert into master_user (role, username, passwd, id_employee, status) values('" + role + "','" + uname + "','" + upass + "','" + idEmployee + "','" + status + "')";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

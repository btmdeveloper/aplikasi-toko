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

        public DataTable showMasterBarang()
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "SELECT tb_master_barang.id_barang AS 'Kode Barang',tb_master_barang.nama_barang AS 'Nama Barang',tb_master_barang.satuan AS Satuan, SUM(tb_stok.stok_barang) AS 'Stok Barang', tb_master_barang.harga_jual AS 'Harga Jual Barang'" +
                                    " FROM tb_master_barang INNER JOIN tb_stok" +
                                    " WHERE tb_master_barang.id_barang=tb_stok.id_barang" +
                                    " GROUP BY tb_master_barang.id_barang"+
                                    " ORDER BY tb_master_barang.id_barang";
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

        public void insertTbMasterBarang(string id_barang, string nama_barang, string satuan, double harga)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "INSERT INTO tb_master_barang(id_barang, nama_barang, satuan, harga_jual) VALUES ('" +
                    id_barang + "','" + nama_barang + "','" + satuan + "','" + harga + "');";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void updateTbMasterBarang(string nama, string satuan, double harga, string id)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "UPDATE tb_master_barang SET nama_barang='" + nama + "',satuan='" + satuan + "',harga_jual='" + harga + "' WHERE id_barang='" + id + "'";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable selectTbMasterBarang(string id_barang)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                //query.CommandText = "select * from '" + tabel + "'";
                query.CommandText = "SELECT * FROM tb_master_barang WHERE id_barang='" + id_barang + "'";
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

        public void insertTbStok(string id_barang, int stok, double hrg_beli)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "INSERT INTO tb_stok(id_barang, stok_barang, harga_beli, tanggal_stok) VALUES ('" +
                    id_barang + "','" + stok + "','" + hrg_beli + "', NOW());";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void updateTbStok(int stokbaru, int id_stok)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "UPDATE tb_stok SET stok_barang='" + stokbaru + "',tanggal_stok=NOW() WHERE id_stok='" + id_stok + "'";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable selectTbStok(string id_barang, double harga_beli)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                //query.CommandText = "select * from '" + tabel + "'";
                query.CommandText = "SELECT id_stok,stok_barang FROM tb_stok WHERE id_barang='" + id_barang + "' AND harga_beli='" + harga_beli + "'";
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

        public DataTable selectTotalStok(string id_barang)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                //query.CommandText = "select * from '" + tabel + "'";
                query.CommandText = "SELECT SUM(stok_barang) FROM tb_stok WHERE id_barang='" + id_barang + "'";
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

        public DataTable selectDetailStok(string id_barang)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                //query.CommandText = "select * from '" + tabel + "'";
                query.CommandText = "SELECT id_stok,stok_barang,harga_beli FROM tb_stok WHERE id_barang='" + id_barang + "' AND stok_barang>0 ORDER BY id_stok";
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

        public void insertTbPembelian(string id_pembelian, double total_pembelian, double total_bayar, double kembalian, string id_pegawai)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "INSERT INTO tb_pembelian(no_faktur, tgl_pembelian, total_pembelian, total_bayar, kembali, id_pegawai) VALUES ('" +
                    id_pembelian + "',NOW(),'" + total_pembelian + "','" + total_bayar + "','" + kembalian + "','" + id_pegawai + "');";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void insertTbDetailPembelian(string id_pembelian, string id_barang, double hrg_beli, int qty, double diskon, double total, int stok_awal, int stok_akhir)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "INSERT INTO tb_detail_pembelian(no_faktur, id_barang, harga_beli, jumlah_barang, diskon, total, stok_awal, stok_akhir) VALUES ('" +
                    id_pembelian + "','" + id_barang + "','" + hrg_beli + "','" + qty + "','" + diskon + "','" + total + "','" + stok_awal + "','" + stok_akhir + "');";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void insertTbPenjualan(string id_penjualan, double total_penjualan, double total_bayar, double kembalian, string id_pegawai)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "INSERT INTO tb_penjualan(no_faktur, tgl_penjualan, total_penjualan, total_bayar, kembali, id_pegawai) VALUES ('" +
                    id_penjualan + "',NOW(),'" + total_penjualan + "','" + total_bayar + "','" + kembalian + "','" + id_pegawai + "');";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void insertTbDetailPenjualan(string id_penjualan, string id_barang, double hrg_jual, int qty, double diskon, double total_jual, double hrg_beli, double total_beli, int stok_awal, int stok_akhir)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "INSERT INTO tb_detail_penjualan(no_faktur, id_barang, harga_jual, jumlah_barang, diskon, total_jual, harga_beli, total_beli, stok_awal, stok_akhir) VALUES ('" +
                    id_penjualan + "','" + id_barang + "','" + hrg_jual + "','" + qty + "','" + diskon + "','" + total_jual + "', '" + hrg_beli + "','" + total_beli + "','" + stok_awal + "','" + stok_akhir + "');";
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

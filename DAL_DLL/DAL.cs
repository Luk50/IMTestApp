using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace DAL_DLL
{
    public class DAL
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IMCon"].ConnectionString);

        public SqlConnection GetCon()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error:\n\r"+ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public int ExeNonQuery(SqlCommand cmd)
        {
            int rowsaffected = -1;
            try
            {
                cmd.Connection = GetCon();               
                rowsaffected = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Execution error:\n\r" + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rowsaffected;
        }

        public object ExeScalar(SqlCommand cmd)
        {
            object obj = -1;
            try
            {
                cmd.Connection = GetCon();
                obj = cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Execution error:\n\r" + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return obj;
        }

        public DataTable ExeReader(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = GetCon();
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Execution error:\n\r" + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable ExeAdapter(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = GetCon();
                SqlDataAdapter sda = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Execution error:\n\r" + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}

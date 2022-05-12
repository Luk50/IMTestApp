using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL_DLL;
using BEL_DLL;

namespace BAL_DLL
{
    public class BAL
    {
        public DAL db = new DAL();
        public BEL info = new BEL();

        public DataTable Login(BEL info)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spLogin"               
            };
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = info.UserName;
            cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = info.UserPassword;
            return db.ExeReader(cmd);
        }

        public int InsertUser(BEL info)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO Users VALUES ('" + info.UserName + "','" + info.UserPassword + "','" + info.RoleID + "')"
            };
            return db.ExeNonQuery(cmd);
        }

        public int InsertRole(BEL info)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO Roles VALUES ('" + info.RoleName + "')"
            };
            return db.ExeNonQuery(cmd);
        }

        public int DeleteUser(BEL info)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM Users WHERE UserName = '" + info.UserName + "'"
            };
            return db.ExeNonQuery(cmd);
        }

        public int DeleteRole(BEL info)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM Roless WHERE RoleUser = '" + info.RoleName + "'"
            };
            return db.ExeNonQuery(cmd);
        }

        public int UpdateUser(BEL info)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "UPDATE Users SET UserName = '" + info.UserName + "' WHERE UserID = '"+ info.UserID +"'"
            };
            return db.ExeNonQuery(cmd);
        }

        public int UpdateRole(BEL info)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "UPDATE Roles SET RoleName = '" + info.RoleName + "' WHERE UserID = '" + info.RoleID + "'"
            };
            return db.ExeNonQuery(cmd);
        }

        public DataTable ReadUsers()
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM USERS"
            };
            return db.ExeReader(cmd);
        }

        public DataTable ReadRoles()
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM ROLES"
            };
            return db.ExeReader(cmd);
        }
    }
}

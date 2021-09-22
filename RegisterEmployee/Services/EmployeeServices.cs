using RegisterEmployee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace RegisterEmployee.Services
{
    public class EmployeeServices
    {
            

        private SqlDataAdapter _adapter;
        private DataSet _ds;

        string strConString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=RegisterEmployee;Integrated Security=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IList<Employees> GetEmployeeList()
        {
            
            IList<Employees> getEmptyList = new List<Employees>();
            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "getEmptyList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        Employees obj = new Employees();
                        obj.Id = Convert.ToInt32(_ds.Tables[0].Rows[i].ItemArray[0]);
                        obj.Name = Convert.ToString(_ds.Tables[0].Rows[i]["Name"]);
                        obj.Surname = Convert.ToString(_ds.Tables[0].Rows[i]["Surname"]);
                        //obj.Patronymic = Convert.ToString(_ds.Tables[0].Rows[0]["Partonymic"]);
                        obj.Date = Convert.ToDateTime(_ds.Tables[0].Rows[i]["Date"]);
                        obj.CompanyName = Convert.ToString(_ds.Tables[0].Rows[i]["CompanyName"]);
                        getEmptyList.Add(obj);

                    }
                }
            }

            return (List<Employees>)getEmptyList;
        }

        public void InsertEmployee(Employees model)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddEmployee");
                cmd.Parameters.AddWithValue("@Surname", model.Surname);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                //cmd.Parameters.AddWithValue("@Patronymic", model.Patronymic);
                cmd.Parameters.AddWithValue("@Date", model.Date);
                cmd.Parameters.AddWithValue("@CompanyName", model.CompanyName);
                cmd.ExecuteNonQuery();

            }

        }

        public Employees GetEditById(int Id)
        {
            var model = new Employees();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmployeeById");
                cmd.Parameters.AddWithValue("@Id", Id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToInt32(_ds.Tables[0].Rows[0]["Id"]);
                    model.Name = Convert.ToString(_ds.Tables[0].Rows[0]["Name"]);
                    model.Surname = Convert.ToString(_ds.Tables[0].Rows[0]["Surname"]);
                    //model.Patronymic = Convert.ToString(_ds.Tables[0].Rows[0]["Partonymic"]);
                    model.Date = Convert.ToDateTime(_ds.Tables[0].Rows[0]["Date"]);
                    model.CompanyName = Convert.ToString(_ds.Tables[0].Rows[0]["CompanyName"]);
                }
            }

            return model;
        }

        public void UpdateEmployees(Employees model)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateEmployee");
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Surname", model.Surname);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                //cmd.Parameters.AddWithValue("@Patronymic", model.Patronymic);
                cmd.Parameters.AddWithValue("@Date", model.Date);
                cmd.Parameters.AddWithValue("@CompanyName", model.CompanyName);
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteEmployees(int Id)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteEmployee");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

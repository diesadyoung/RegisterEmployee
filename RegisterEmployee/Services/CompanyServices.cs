using RegisterEmployee.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RegisterEmployee.Services
{
    public class CompanyServices
    {
        private SqlDataAdapter _adapter;
        private DataSet _ds;

        string strConString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=RegisterEmployee;Integrated Security=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IList<Companies> GetCompanyList()
        {
            IList<Companies> GetCompaniesList = new List<Companies>();
            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Procedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetCompaniesList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        Companies obj = new Companies();
                        obj.Id = Convert.ToInt32(_ds.Tables[0].Rows[i].ItemArray[0]);
                        obj.CompanyName = Convert.ToString(_ds.Tables[0].Rows[i]["CompanyName"]);
                        obj.Opf = Convert.ToString(_ds.Tables[0].Rows[i]["Opf"]);
                        GetCompaniesList.Add(obj);
                    }
                }
            }
            return (List<Companies>)GetCompaniesList;
        }
        public void InsertCompany(Companies models)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Procedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddCompany");
                cmd.Parameters.AddWithValue("@Id", models.Id);
                cmd.Parameters.AddWithValue("@CompanyName", models.CompanyName);
                cmd.Parameters.AddWithValue("@Opf", models.Opf);
                cmd.ExecuteNonQuery();

            }

        }

        public Companies GetCompanyById(int Id)
        {
            var models = new Companies();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Procedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetCompanyById");
                cmd.Parameters.AddWithValue("@Id", Id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    models.Id = Convert.ToInt32(_ds.Tables[0].Rows[0]["Id"]);
                    models.CompanyName = Convert.ToString(_ds.Tables[0].Rows[0]["CompanyName"]);
                    models.Opf = Convert.ToString(_ds.Tables[0].Rows[0]["Opf"]);
                }
            }

            return models;
        }

        public void UpdateCompany(Companies models)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Procedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateCompany");
                cmd.Parameters.AddWithValue("@Id", models.Id);
                cmd.Parameters.AddWithValue("@CompanyName", models.CompanyName);
                cmd.Parameters.AddWithValue("@Opf", models.Opf);
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteCompany(int Id)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Procedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteCompany");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BanglaMvc.Models
{
    public class FacultyDetails
    {
        public int SerialNo { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Photograph { get; set; }
        public string Academic_Background { get; set; }
    }

    public class StudentDetails
    {
        public int ID { get; set; }
        public int Roll { get; set; }
        public string StudentName { get; set; }
        public int Mid_1 { get; set; }
        public int Mid_2 { get; set; }
        public int Final { get; set; }
        public int Total { get; set; }
    }

    public class Faculty
    {
        public int ID { get; set; }
        public string Department { get; set; }

        public static string Connection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString.ToString();
            }
        }

        public List<FacultyDetails> GetAllFaculty()
        {
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = Faculty.AddParameter("@ID", ID, System.Data.SqlDbType.Int, 10);
            List<FacultyDetails> dt = Faculty.SPExecute("sp_getFaculty", parameter);
            return dt;
        }
        public List<StudentDetails> GetAllStudents()
        {
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = Faculty.AddParameter("@ID", ID, System.Data.SqlDbType.Int, 10);
            List<StudentDetails> dt = Faculty.SPExecute1("GetStudentInformationByID", parameter);
            return dt;
        }

        public List<StudentDetails> AllStudents()
        {
            List<StudentDetails> dt = Faculty.SPExecute2("GetAllStudents");
            return dt;
        }

        public static SqlParameter AddParameter(string parameter, object value, SqlDbType type, int size)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameter;
            param.Value = value.ToString();
            param.SqlDbType = type;
            param.Size = size;
            param.Direction = ParameterDirection.Input;
            return param;
        }

        public static List<FacultyDetails> SPExecute(string ProcedureName, SqlParameter[] para)
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand scmd = new SqlCommand(ProcedureName, con);
            scmd.Parameters.AddRange(para);
            scmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(scmd);
            DataTable dt = new DataTable();

            try
            {
                dataAdapter.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                dataAdapter.Dispose();
                scmd.Dispose();
                scmd.Parameters.Clear();
                con.Dispose();
            }

            List<FacultyDetails> list = new List<FacultyDetails>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FacultyDetails userinfo = new FacultyDetails();
                userinfo.Name = dt.Rows[i]["Name"].ToString();
                userinfo.Designation = dt.Rows[i]["Designation"].ToString();
                userinfo.Photograph = dt.Rows[i]["Photograph"].ToString();
                userinfo.Academic_Background = dt.Rows[i]["Academic_Background"].ToString();
                list.Add(userinfo);
            }

            return list;
        }

        public static List<StudentDetails> SPExecute1(string ProcedureName, SqlParameter[] para)
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand scmd = new SqlCommand(ProcedureName, con);
            scmd.Parameters.AddRange(para);
            scmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(scmd);
            DataTable dt = new DataTable();

            try
            {
                dataAdapter.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                dataAdapter.Dispose();
                scmd.Dispose();
                scmd.Parameters.Clear();
                con.Dispose();
            }

            List<StudentDetails> list = new List<StudentDetails>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentDetails userinfo = new StudentDetails();
                userinfo.Roll = Convert.ToInt32(dt.Rows[i]["Roll"]);
                userinfo.StudentName = dt.Rows[i]["StudentName"].ToString();
                userinfo.Mid_1 = Convert.ToInt32(dt.Rows[i]["Mid_1"]);
                userinfo.Mid_2 = Convert.ToInt32(dt.Rows[i]["Mid_2"]);
                userinfo.Final = Convert.ToInt32(dt.Rows[i]["Final"]);
                userinfo.Total = Convert.ToInt32(dt.Rows[i]["Total"]);
                list.Add(userinfo);
            }

            return list;
        }

        public static List<StudentDetails> SPExecute2(string ProcedureName)
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand scmd = new SqlCommand(ProcedureName, con);
            scmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(scmd);
            DataTable dt = new DataTable();

            try
            {
                dataAdapter.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                dataAdapter.Dispose();
                scmd.Dispose();
                scmd.Parameters.Clear();
                con.Dispose();
            }

            List<StudentDetails> list = new List<StudentDetails>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentDetails userinfo = new StudentDetails();
                userinfo.Roll = Convert.ToInt32(dt.Rows[i]["Roll"]);
                userinfo.StudentName = dt.Rows[i]["StudentName"].ToString();
                userinfo.Mid_1 = Convert.ToInt32(dt.Rows[i]["Mid_1"]);
                userinfo.Mid_2 = Convert.ToInt32(dt.Rows[i]["Mid_2"]);
                userinfo.Final = Convert.ToInt32(dt.Rows[i]["Final"]);
                userinfo.Total = Convert.ToInt32(dt.Rows[i]["Total"]);
                list.Add(userinfo);
            }

            return list;
        }
    }
}
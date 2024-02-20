using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotNetTrainingBatch3.ConsoleApp1_1.Models;

namespace DotNetTrainingBatch3.ConsoleApp1_1.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {
            Console.WriteLine("Read");

            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "Testdb",
                UserID = "sa",
                Password = "sasa@123",
            };
           

            



            string query = @"SELECT [BlodId]
                            ,[BlodTitle]
                            ,[BlodAuthor]
                            ,[BlodContent]
                             FROM [dbo].[Tbl_blod]";

            using IDbConnection db = new SqlConnection(scb.ConnectionString);
            List<BlodModel>lst=db.Query<BlodModel>(query).ToList();


           

            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine("Title" + dr["BlodTitle"]);
            //    Console.WriteLine("Author" + dr["BlodAuthor"]);
            //    Console.WriteLine("Content" + dr["BlodTitle"]);
            //}

            foreach(BlodModel item in lst)
            {
                Console.WriteLine(item.BoldId);
                Console.WriteLine(item.BoldTitle);
                Console.WriteLine(item.BlodAuthor);
                Console.WriteLine(item.BlodContent);

            }
        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
            scb.DataSource = ".";
            scb.InitialCatalog = "Testdb";
            scb.UserID = "sa";
            scb.Password = "sasa@123";

            Console.WriteLine("ConnectionString =" + scb.ConnectionString);

            SqlConnection con = new SqlConnection(scb.ConnectionString);

            Console.WriteLine("Connection opening....");
            con.Open();
            Console.WriteLine("Connection open....");



            string query = @"SELECT [BlodId]
                            ,[BlodTitle]
                            ,[BlodAuthor]
                            ,[BlodContent]
                            FROM [dbo].[Tbl_blod] Where BlodId = @BlodId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BlodId", id);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);


            Console.WriteLine("Connection closing....");
            con.Close();
            Console.WriteLine("Connection close....");

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine("Title" + dr["BlodTitle"]);
            Console.WriteLine("Author" + dr["BlodAuthor"]);
            Console.WriteLine("Content" + dr["BlodTitle"]);
            
        }

        public void Create(string title,string author, string content)
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
            scb.DataSource = ".";
            scb.InitialCatalog = "Testdb";
            scb.UserID = "sa";
            scb.Password = "sasa@123";

            Console.WriteLine("ConnectionString =" + scb.ConnectionString);

            SqlConnection con = new SqlConnection(scb.ConnectionString);

            Console.WriteLine("Connection opening....");
            con.Open();
            Console.WriteLine("Connection open....");



            string query = @"INSERT INTO [dbo].[Tbl_blod]
           ([BlodTitle]
           ,[BlodAuthor]
           ,[BlodContent])
           VALUES
           (@BlodTitle,
		   @BlodAuthor,
		   @BlodContent)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BlodTitle", title);
            cmd.Parameters.AddWithValue("@BlodAuthor", author);
            cmd.Parameters.AddWithValue("@BlodContent", content);


           int result= cmd.ExecuteNonQuery();
           con.Close();

            string message = result > 0 ? "Saving Successful." : "saving failed";

            Console.WriteLine(message);
            
        }

        public void Update(int id,string title, string author, string content)
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
            scb.DataSource = ".";
            scb.InitialCatalog = "Testdb";
            scb.UserID = "sa";
            scb.Password = "sasa@123";

            Console.WriteLine("ConnectionString =" + scb.ConnectionString);

            SqlConnection con = new SqlConnection(scb.ConnectionString);

            Console.WriteLine("Connection opening....");
            con.Open();
            Console.WriteLine("Connection open....");



            string query = @"UPDATE [dbo].[Tbl_blod]
                           SET [BlodTitle] = @BlodTitle
                            ,[BlodAuthor] = @BlodAuthor
                            ,[BlodContent] = @BlodContent
                             WHERE BlodId= @BlodId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BlodId", id);
            cmd.Parameters.AddWithValue("@BlodTitle", title);
            cmd.Parameters.AddWithValue("@BlodAuthor", author);
            cmd.Parameters.AddWithValue("@BlodContent", content);


            int result = cmd.ExecuteNonQuery();
            con.Close();

            string message = result > 0 ? "Update Successful." : "Update failed";

            Console.WriteLine(message);

        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
            scb.DataSource = ".";
            scb.InitialCatalog = "Testdb";
            scb.UserID = "sa";
            scb.Password = "sasa@123";

            Console.WriteLine("ConnectionString =" + scb.ConnectionString);

            SqlConnection con = new SqlConnection(scb.ConnectionString);

            Console.WriteLine("Connection opening....");
            con.Open();
            Console.WriteLine("Connection open....");



            string query = @"DELETE From [dbo].[Tbl_blod]
                             WHERE BlodId= @BlodId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BlodId", id);
            


            int result = cmd.ExecuteNonQuery();
            con.Close();

            string message = result > 0 ? "Delete Successful." : "Delete failed";

            Console.WriteLine(message);

        }
    }
}

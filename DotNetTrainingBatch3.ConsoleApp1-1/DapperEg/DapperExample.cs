using DotNetTrainingBatch3.ConsoleApp1_1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DotNetTrainingBatch3.ConsoleApp1_1.DapperEg
{
    public class DapperExample
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
            List<BlodModel> lst = db.Query<BlodModel>(query).ToList();



            foreach (BlodModel item in lst)
            {
                Console.WriteLine(item.BoldId);
                Console.WriteLine(item.BoldTitle);
                Console.WriteLine(item.BlodAuthor);
                Console.WriteLine(item.BlodContent);

            }
        }

        public void Edit(int id)
        {

            Console.WriteLine("Edit");

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
                            FROM [dbo].[Tbl_blod] Where BlodId = @BlodId";

            using IDbConnection db = new SqlConnection(scb.ConnectionString);
            var item = db.Query<BlodModel>(query).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }

            Console.WriteLine(item.BoldId);
            Console.WriteLine(item.BoldTitle);
            Console.WriteLine(item.BlodAuthor);
            Console.WriteLine(item.BlodContent);


        }

        public void Create(string title, string author, string content)
        {

            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "Testdb",
                UserID = "sa",
                Password = "sasa@123",
            };

            string query = @"INSERT INTO [dbo].[Tbl_blod]
           ([BlodTitle]
           ,[BlodAuthor]
           ,[BlodContent])
           VALUES
           (@BlodTitle,
		   @BlodAuthor,
		   @BlodContent)";

            BlodModel bm = new BlodModel()
            {
                BlodAuthor = author,
                BlodContent = content,
                BoldTitle = title,
            };

            using IDbConnection db = new SqlConnection(scb.ConnectionString);
            int reult = db.Execute(query,bm );
           
            string message = reult > 0 ? "Saving Successful." : "saving failed";

            Console.WriteLine(message);

        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "Testdb",
                UserID = "sa",
                Password = "sasa@123",
            };

            string query = @"UPDATE [dbo].[Tbl_blod]
                           SET [BlodTitle] = @BlodTitle
                            ,[BlodAuthor] = @BlodAuthor
                            ,[BlodContent] = @BlodContent
                             WHERE BlodId= @BlodId";

            BlodModel bm = new BlodModel()
            {
                BlodAuthor = author,
                BlodContent=content,
                BoldId=id,
                BoldTitle=title,
            };

            using IDbConnection db = new SqlConnection(scb.ConnectionString);
            int result = db.Execute(query, bm);
            string message = result > 0 ? "Updating success" : "Updating fail";

            Console.WriteLine(message);

        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "Testdb",
                UserID = "sa",
                Password = "sasa@123",
            };
         
            string query = @"DELETE From [dbo].[Tbl_blod]
                             WHERE BlodId= @BlodId";

            BlodModel bm = new BlodModel()
            {
                BoldId = id,
            };

            using IDbConnection db = new SqlConnection(scb.ConnectionString);
            int result = db.Execute(query, bm);
                       
            string message = result > 0 ? "Delete Successful." : "Delete failed";

            Console.WriteLine(message);

        }

    }
}

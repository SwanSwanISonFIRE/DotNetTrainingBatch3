// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//f5=run

//ctrl+k,c disable
//ctrl+k,u enable
//Console.ReadLine();
//f9=break point

#region Read

SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
scb.DataSource = ".";
scb.InitialCatalog = "TestDb";
scb.UserID = "sa";
scb.Password = "sasa@123";
string query = "select * from tbl_blod";
SqlConnection sql = new SqlConnection(scb.ConnectionString);
sql.Open();
SqlCommand cmd = new SqlCommand(scb.ConnectionString);
SqlDataAdapter ad = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
ad.Fill(dt);

//dataset
//dataTable
//datarow
//datacolumn

sql.Close();

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlodId"]);
    Console.WriteLine(dr["BlodTitle"]);
    Console.WriteLine(dr["BlodAuthor"]);
    Console.WriteLine(dr["BlodContent"]);
}



#endregion

Console.ReadKey();

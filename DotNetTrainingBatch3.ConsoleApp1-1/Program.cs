// See https://aka.ms/new-console-template for more information



using DotNetTrainingBatch3.ConsoleApp1_1.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp1_1.DapperEg;
using DotNetTrainingBatch3.ConsoleApp1_1.HttpClientExamples;
using DotNetTrainingBatch3.ConsoleApp1_1.Models;
using DotNetTrainingBatch3.ConsoleApp1_1.RestClientExamples;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
//scb.DataSource = ".";
//scb.InitialCatalog = "Testdb";
//scb.UserID = "sa";
//scb.Password = "sasa@123";

//Console.WriteLine("ConnectionString =" + scb.ConnectionString);

//SqlConnection con = new SqlConnection(scb.ConnectionString);

//Console.WriteLine("Connection opening....");
//con.Open();
//Console.WriteLine("Connection open....");



//string query = @"SELECT [BlodId]
//      ,[BlodTitle]
//      ,[BlodAuthor]
//      ,[BlodContent]
//  FROM [dbo].[Tbl_blod]";
//SqlCommand cmd = new SqlCommand(query,con);
//SqlDataAdapter ad = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//ad.Fill(dt);


//Console.WriteLine("Connection closing....");
//con.Close();
//Console.WriteLine("Connection close....");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Title" + dr["BlodTitle"]);
//    Console.WriteLine("Author" + dr["BlodAuthor"]);
//    Console.WriteLine("Content" + dr["BlodTitle"]);
//}

//AdoDotNetExample ado = new AdoDotNetExample();
//ado.Read();

//ado.Edit(1);
//ado.Edit(11);

//ado.Create("test title", "test author", "test content");

//ado.Update(2, "test title 2", "test author 2", "test content 2");

//ado.Delete(2);

//DapperExample deg = new DapperExample();
//deg.Read();

//Console.WriteLine("pls wait for api");
//Console.ReadKey();

//HttpClientEg h = new HttpClientEg();
//await h.Run();

//BlodModel b = new BlodModel();
//b.BoldTitle = "Title";
//b.BlodAuthor = "Title";
//b.BlodContent = "Title";
//string json = JsonConvert.SerializeObject(b);
//Console.WriteLine(b);
//Console.WriteLine(json);
//Console.WriteLine(b.BoldTitle);
//Console.WriteLine(b.BlodAuthor);
//Console.WriteLine(b.BlodContent);

//BlodModel b2 = JsonConvert.DeserializeObject<BlodModel>(json);
//Console.WriteLine(b2.BoldTitle);
//Console.WriteLine(b2.BlodAuthor);
//Console.WriteLine(b2.BlodContent);

Console.WriteLine("pls wait for api");
Console.ReadKey();

//HttpEg2 h2 = new HttpEg2();
//await h2.Run();

RestClientEg r = new RestClientEg();
await r.Run();



Console.ReadKey();
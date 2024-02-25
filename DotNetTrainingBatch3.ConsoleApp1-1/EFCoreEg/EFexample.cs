using DotNetTrainingBatch3.ConsoleApp1_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp1_1.EFCoreEg
{
    public class EFexample
    {

        public void Read()
        {
            AppdbContext db = new AppdbContext();
            List<BlodModel> lst = db.blods.ToList();

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
            AppdbContext db = new AppdbContext();
            BlodModel item = db.blods.Where(item => item.BoldId == id).FirstOrDefault();
            if(item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine(item.BoldId);
            Console.WriteLine(item.BoldTitle);
            Console.WriteLine(item.BlodAuthor);
            Console.WriteLine(item.BlodContent);
        }

        public void Create (string title, string author, string content)
        {
            BlodModel bm = new BlodModel()
            {
                BlodAuthor=author,
                BoldTitle = title,
                BlodContent=content
            };
            AppdbContext db = new AppdbContext();
            db.blods.Add(bm);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Success" : "Save fail";
            Console.WriteLine(message);

        }

        public void Update(int id,string title, string author,string content)
        {
            AppdbContext db = new AppdbContext();
            BlodModel item = db.blods.Where(item => item.BoldId == id).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }

            item.BlodAuthor = author;
            item.BoldTitle = title;
            item.BlodContent = content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Update Success" : "Update fail";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            AppdbContext db = new AppdbContext();
            BlodModel item = db.blods.Where(item => item.BoldId == id).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }

            db.blods.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "delete Success" : "delete fail";
            Console.WriteLine(message);
        }

    }
}

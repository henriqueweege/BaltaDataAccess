using Blog.Infrastructure.Exceptions;
using Blog.Models;
using Blog.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Display.Helpers
{
    public class ObjectHelper<T> where T : BaseModel
    {
        public int Choose(List<T> objects, string entityName)
        {
            Console.Clear();
            var aOrAn = AOrAn(entityName);
            var objDict = new Dictionary<int, T>();

            Console.WriteLine($"Please, choose {aOrAn} {entityName} below.");

            for (var i = 0; i < objects.Count(); i++)
            {
                var number = i + 1;
                Console.WriteLine($"{number}- {objects[i].Name}");
                objDict.Add(number, objects[i]);
            }
            var objNumber = Console.ReadLine();

            if (int.TryParse(objNumber, out _))
            {
                var number = int.Parse(objNumber);

                if (number > objects.Count() || number <= 0)
                {
                    MessageHelper.InvalidInput(entityName);
                    return Choose(objects, entityName);
                }

                return objDict[int.Parse(objNumber)].Id;
            }
            else
            {
                MessageHelper.InvalidInput(entityName);
                return Choose(objects, entityName);
            }

            throw new NoObjectException();
        }



        private string AOrAn(string entityName)
        {
            var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
            var firstLetter = entityName.Substring(0, 1);
            if (vowels.Any(c => c.ToString() == firstLetter.ToLower()))
            {
                return "an";
            }

            return "a";
        }
    }
}

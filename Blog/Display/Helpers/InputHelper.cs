using Blog.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Display.Helpers
{
    public static class InputHelper
    {
        public static int Check(int? param)
        {
            if (param is null)
                throw new ArgumentException();
            return (int)param;
        }
        public static string Get(string paramName, string entityName)
        {
            Console.Clear();
            Console.WriteLine($"Please, enter the {paramName} of the new {entityName}:");
            var param = Console.ReadLine();

            if (!string.IsNullOrEmpty(param))
                return param;

            throw new ArgumentException();
        }
        public static string Check(string? param)
        {
            if (string.IsNullOrEmpty(param))
                throw new ArgumentException();

            if (int.TryParse(param, out _))
            {
                return param;
            }

            throw new NotANumberException();


        }
    }
}

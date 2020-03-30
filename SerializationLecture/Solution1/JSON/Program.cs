using System.IO;
using Classes;

using System;
using System.Runtime.Serialization.Formatters.Soap;

namespace JSON
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Class1 obj = new Class1();
            obj.test = obj;
            SoapFormatter serializer = new SoapFormatter();
            using (FileStream fs = new FileStream("obj.dat", FileMode.Create))
            {
                serializer.Serialize(fs, obj);
            }
        }
    }
}
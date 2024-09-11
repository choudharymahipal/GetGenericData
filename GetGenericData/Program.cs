using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetGenericData
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("\r\n--- Get the generic type that defines a constructed type.");

            // Create a Dictionary of Test objects, using strings for the
            // keys.   
            Test _test = new Test();
            _test.fname = "mahipal";
            _test.lname = "choudhary";

            Dictionary<string, Test> d = new Dictionary<string, Test>();

            // Get a Type object representing the constructed type.
            //
            Type constructed = d.GetType();
            //DisplayTypeInfo(constructed);

            Type generic = constructed.GetGenericTypeDefinition();
            //DisplayTypeInfo(generic);

            myMethod(_test);
        }

        public static void myMethod(Test data)
        {
            //Dictionary<string, string> myDict = new Dictionary<string, string>();
            Type t = data.GetType();
            foreach (PropertyInfo pi in t.GetProperties())
            {
                Console.WriteLine(pi.Name.ToString());
                Console.WriteLine(pi.GetValue(data, null)?.ToString());
                Console.WriteLine("------------");
                //myDict[pi.Name] = pi.GetValue(data, null)?.ToString();
            }
        }


        private static void DisplayTypeInfo(Type t)
        {
            Console.WriteLine("\r\n{0}", t);

            Console.WriteLine("\tIs this a generic type definition? {0}",
                t.IsGenericTypeDefinition);
            Console.WriteLine("\tIs it a generic type? {0}",
                t.IsGenericType);
            Type[] typeArguments = t.GetGenericArguments();

            Console.WriteLine("\tList type arguments ({0}):", typeArguments.Length);
            foreach (Type tParam in typeArguments)
            {
                Console.WriteLine("\t\t{0}", tParam);
            }
        }

        public class Test
        {
            public string fname { get; set; }
            public string lname { get; set; }
        }
    }
}

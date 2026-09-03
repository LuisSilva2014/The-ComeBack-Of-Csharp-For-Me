using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TheComeBackOfCsharpForLuis
{
    internal class MyFiles
    {
        public void Process()
        {
            string text = "Hello world";
            File.WriteAllText("myfile.txt", text);

            string readText = File.ReadAllText("myfile.txt");
            Console.WriteLine("===== Content from file ========= ");
            Console.WriteLine(readText);

        }
    }
}

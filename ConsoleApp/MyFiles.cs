using LuisPracticeCsharp2026;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace name_sorter
{
    internal class Program
    {

    }
    public class InterfaceImplate: IInterface
    {
        static void Main(string[] args)
        {

            InterfaceImplate obj = new InterfaceImplate();
            var nameList = new List<string>();
            var sortedNameList = new List<string>();
            if (args.Length > 0 && File.Exists(args[0]))
            {
                nameList = obj.ReadText(args[0]);
                sortedNameList = obj.Sorter(nameList);
                obj.WriteText(nameList);
                obj.NameDisplay(nameList);

            }
            else
            {
                Console.WriteLine("Please enter the right path!");
                Console.ReadKey();
            }
        }



        public List<string> ReadText(string route) {
            StreamReader sr = new StreamReader(route);
            var nameList=new List<string>();
            String line=sr.ReadLine();
            while(line!=null){
              nameList.Add(line);
                line=sr.ReadLine();
            }
            return nameList;
            
        }


        public List<string> Sorter(List<String> nameList)
        {

            nameList.Sort((x, y) =>
            {
                string sub1 = x.Substring(x.LastIndexOf(" ") + 1);
                string sub2 = y.Substring(y.LastIndexOf(" ") + 1);
                if (sub1 != sub2)
                {
                    return sub1.CompareTo(sub2);
                }
                else { 
                    return x.CompareTo(y);
                }
                
            });
            return nameList;
            //throw new NotImplementedException();
        }

        public void WriteText(List<String> nameList)
        {
            string path = "./sorted-names-list.txt";
            using (TextWriter writer=File.CreateText(path))
            { 
                for (int i=0;i< nameList.Count();i++) { writer.WriteLine(nameList[i]); };
            }
            //throw new NotImplementedException();
            }
        public void NameDisplay(List<string> nameList)
        {
            for (int i = 0; i < nameList.Count; i++)
            {
                Console.WriteLine(nameList[i]);
            }
            Console.ReadKey();
            //throw new NotImplementedException();
        }
    }

    }


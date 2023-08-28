using Microsoft.VisualStudio.TestTools.UnitTesting;
using Name_sorter;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        InterfaceImplate testobj = new InterfaceImplate();

        [TestMethod]
        public void TestReadText_Success()
        {
            string path = "./test-read.txt";
            using (TextWriter writer = File.CreateText(path))
            {
                writer.WriteLine("test text");

            }

            
            List<String> result=testobj.ReadText(path);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestSorter()
        {
            List<String> listBeforeSort=new List<String>() {
                "Hunter Uriah Mathew Clarke",
                "Beau Tristan Bentley",
                "Adonis Julius Archer",
                "Marin Alvarez"
                };
            List<String> listAfterSort = new List<String>() {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke"};
            List<String> result=testobj.Sorter(listBeforeSort);
            for (int i = 0; i < listAfterSort.Count; i++)
            {
                Assert.AreEqual(result[i], listAfterSort[i]);
            }
        }
        [TestMethod]
        public void TestWriteText()
        {
            List<String> testText=new List<String>() { "Aaa","Bbb","Ccc"};
            testobj.WriteText(testText);
            StreamReader sr = new StreamReader("./sorted-names-list.txt");
            var nameList = new List<string>();
            String line = sr.ReadLine();
            while (line != null)
            {
                nameList.Add(line);
                line = sr.ReadLine();
            }
            Assert.IsTrue(File.Exists("./sorted-names-list.txt"));

            for (int i = 0; i < nameList.Count; i++)
            {
                Assert.AreEqual(testText[i], nameList[i]);
            }

        }
    }
}

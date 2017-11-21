using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assets.Scripts.lib
{
    class UnityHelper
    {
        static string Logpre = "UnityHelper";
        static UnityHelper helpInstance = null;
        public void CreateDir(string path) {


        }

        public static UnityHelper GetInstance() {
            if (UnityHelper.helpInstance == null) {
                UnityHelper.helpInstance = new UnityHelper();
            }
            return UnityHelper.helpInstance;
        }

        public void CreateFile(string path, string filename, string info) {
            StreamWriter sw;
            string endpath = Path.Combine(path, filename);
            FileInfo f = new FileInfo(endpath);
            if (!f.Exists) {
                sw = f.CreateText();
            }
            else
            {
                sw = f.AppendText(); 
            }
            sw.Write(info);
            sw.Close();
            sw.Dispose();
        }

        public void DeleteFile(string path) {
            FileInfo f = new FileInfo(path);
            if (f.Exists){
                File.Delete(path);
            }
        }

        public ArrayList ReadFile(string path) {
            ArrayList array = new ArrayList();
            FileInfo f = new FileInfo(path);
            if (f.Exists)
            {
                StreamReader sr = f.OpenText();
                string line = sr.ReadLine();
                while (line != null) {
                    array.Add(line);
                    line = sr.ReadLine();
                }
            }
            else
            {
                Console.WriteLine(Logpre + "ReadFile: " + path + "not exists");
            }
            return array;
        }
    }
}

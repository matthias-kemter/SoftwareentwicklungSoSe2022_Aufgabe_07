using System;
using System.IO;
using System.Text;

namespace übung07
{   
   class Kommunikationskoordinator
   {    
      public string filename = "SmartPhoneData.csv";
   
      public void ReadData(string filename){

         string path = Path.GetTempFileName(filename);
         File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None);

         string line;
         //try{}

         StreamReader sr = new StreamReader(filename);
         line = sr.ReadLine();
         
        // while(){//aufrufen der Zeilen}

      }

      static void Main (string[] args){   
      
      }
   }
}

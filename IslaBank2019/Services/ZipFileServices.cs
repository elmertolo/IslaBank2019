using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using IslaBank2019.Model;
using System.Windows.Forms;


namespace IslaBank2019.Services
{
    class ZipFileServices
    {
       
        public void CreateZipFile(string _sourcePath, string _destinationPath)
        {

            ZipFile.CreateFromDirectory(_sourcePath, _destinationPath);
        }
        public void ExtractZipFile(string sourcePath, string destinationPath)
        {

            ZipFile.ExtractToDirectory(sourcePath, destinationPath);
        }

        public void ZipFileS(string _processby)
        {
          
            string sPath = Application.StartupPath +"\\Output";
            string dPath = "K:\\Zips\\isla\\Test\\AFT_" + DateTime.Now.ToString("MMddyyyy") + "_" + _processby + ".zip";
            DeleteZipfile();
            ZipFile.CreateFromDirectory(sPath,dPath);
             
         ///  CopyZipFile(_processby,);

           
      
        }

        public void DeleteZipfile()
        {

            DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
            FileInfo[] files = di.GetFiles("*.zip")
                     .Where(p => p.Extension == ".zip").ToArray();
            foreach (FileInfo file in files)
            {
                file.Attributes = FileAttributes.Normal;
                File.Delete(file.FullName);
            }
        }
        public void CopyZipFile(string _processby, frmMain main)
        {
            string dPath = Application.StartupPath + @"\AFT_" + main._batchfile + "_" + _processby + ".zip";
            string sPath = @"K:\Zips\isla\Test\AFT_" + main._batchfile + "_" + _processby + ".zip";
            File.Copy(sPath, dPath,true);
            //string dPath2 = "\\\\192.168.0.254\\PrinterFiles\\ISLA\\2019\\";
            //string sPath2 = "\\\\192.168.0.254\\captive\\Auto\\IslaBank\\Test\\";

        }
        public static void CopyPrinterFile(string _checkType, frmMain _mainForm)
        {
            string source =Application.StartupPath + "\\Output";
            string destination = @"\\192.168.0.254\PrinterFiles\ISLA\TEST\"+DateTime.Now.Year ;
            
           
                if (_checkType == "A")
            {
                File.Copy(source + "\\Regular Checks\\ISL" + _mainForm._batchfile.Substring(0,4) + "P." + DateTime.Now.ToString("yy") + "P", destination + "\\ISL" + _mainForm._batchfile.Substring(0,4) + "P." + DateTime.Now.ToString("yy") + "P", true);
            }
                if (_checkType == "B")
                {
                    File.Copy(source + "\\Regular Checks\\ISL" + _mainForm._batchfile.Substring(0, 4) + "C." + DateTime.Now.ToString("yy") + "P", destination + "\\ISL" + _mainForm._batchfile.Substring(0, 4) + "C." + DateTime.Now.ToString("yy") + "P", true);
                }
                else if (_checkType == "MC"  || _checkType == "MC_CONT")
            {
                File.Copy(source + "\\MC\\ISL" + _mainForm._batchfile + "P." + DateTime.Now.ToString("yy") + "P", destination + "\\ISL" + DateTime.Now.ToString("MMdd") + "P." + DateTime.Now.ToString("yy") + "P", true);
            }
                else if (_checkType == "SR")
            {
                File.Copy(source + "\\Self_Responding_Ticket\\ISL" + _mainForm._batchfile + "P." + DateTime.Now.ToString("yy") + "P", destination + "\\ISL" + DateTime.Now.ToString("MMdd") + "P." + DateTime.Now.ToString("yy") + "P", true);
            }
                else if (_checkType == "TD")
            {
                File.Copy(source + "\\Time_Deposit\\ISL" + _mainForm._batchfile + "P." + DateTime.Now.ToString("yy") + "P", destination + "\\ISL" + DateTime.Now.ToString("MMdd") + "P." + DateTime.Now.ToString("yy") + "P", true);
            }
            
        }
        public static void CopyPackingDBF(string _checkType, frmMain _mainForm)
        {
            string source = Application.StartupPath + "\\Output";
            string destination = @"\\192.168.0.254\Packing\ISLA\TEST\";
            {
                Directory.CreateDirectory(destination + _mainForm._batchfile);

            }

            string destination1 = @"\\192.168.0.254\Packing\ISLA\TEST\" + _mainForm._batchfile;


            if (_checkType == "A" || _checkType == "B")
                File.Copy(source + "\\Regular Checks\\Packing.dbf", destination1 + "\\Packing.dbf", true);

            else if (_checkType == "MC" || _checkType == "MC_CONT")
                File.Copy(source + "\\MC\\Packing.dbf", destination1 + "\\Packing.dbf", true);
        }
        
    }
}

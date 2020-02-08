using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IslaBank2019.Model;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace IslaBank2019.Services
{
   public class ProcessPackingText
    {
       string outputForlder = Application.StartupPath+ "\\Output";
       //string outputForlder = "\\\\192.168.0.254\\captive\\Auto\\IslaBank\\Test";
       public void PackingText(List<CheckModel> _checksModel, frmMain _mainForm)
       {

           StreamWriter file;
           DatabaseConnectionsServices db = new DatabaseConnectionsServices();
           db.GetAllData(_checksModel, _mainForm._batchfile);
           var listofcheck = _checksModel.Select(e => e.ChkType).ToList();

           foreach (string Scheck in listofcheck)
           {
               if (Scheck == "A")
               {

                   string packkingListPath = outputForlder +"\\Regular Checks\\PackingA.txt";
                   if (File.Exists(packkingListPath))
                       File.Delete(packkingListPath);
                   var checks = _checksModel.Where(a => a.ChkType == Scheck).Distinct().ToList();
                   file = File.CreateText(packkingListPath);
                   file.Close();

                   using (file = new StreamWriter(File.Open(packkingListPath, FileMode.Append)))
                   {
                       string output = ChecOutputServices.ConvertToPackingList(checks, "PERSONAL", _mainForm);

                       file.WriteLine(output);
                   }

               }
           }
           foreach (string Scheck in listofcheck)
           {
               if (Scheck == "B")
               {

                   string packkingListPath = outputForlder + "\\Regular Checks\\PackingB.txt";
                   if (File.Exists(packkingListPath))
                       File.Delete(packkingListPath);
                   var checks = _checksModel.Where(a => a.ChkType == Scheck).Distinct().ToList();
                   file = File.CreateText(packkingListPath);
                   file.Close();

                   using (file = new StreamWriter(File.Open(packkingListPath, FileMode.Append)))
                   {
                       string output = ChecOutputServices.ConvertToPackingList(checks, "COMMERCIAL", _mainForm);

                       file.WriteLine(output);
                   }

               }
           }
           foreach (string Scheck in listofcheck)
           {
               if (Scheck == "MC")
               {

                   string packkingListPath = outputForlder + "\\MC\\PackingM.txt";
                   if (File.Exists(packkingListPath))
                       File.Delete(packkingListPath);
                   var checks = _checksModel.Where(a => a.ChkType == Scheck).Distinct().ToList();
                   file = File.CreateText(packkingListPath);
                   file.Close();

                   using (file = new StreamWriter(File.Open(packkingListPath, FileMode.Append)))
                   {
                       string output = ChecOutputServices.ConvertToPackingList(checks, "MANAGER'S CHECK", _mainForm);

                       file.WriteLine(output);
                   }

               }
           }
           foreach (string Scheck in listofcheck)
           {
               if (Scheck == "MC_CONT")
               {

                   string packkingListPath = outputForlder + "\\MC\\PackingMC.txt";
                   if (File.Exists(packkingListPath))
                       File.Delete(packkingListPath);
                   var checks = _checksModel.Where(a => a.ChkType == Scheck).Distinct().ToList();
                   file = File.CreateText(packkingListPath);
                   file.Close();

                   using (file = new StreamWriter(File.Open(packkingListPath, FileMode.Append)))
                   {
                       string output = ChecOutputServices.ConvertToPackingList(checks, "MANAGER'S CHECK CONTINUES", _mainForm);

                       file.WriteLine(output);
                   }

               }
           }

           foreach (string Scheck in listofcheck)
           {
               if (Scheck == "SR")
               {

                   string packkingListPath = outputForlder + "\\Self_Responding_Ticket\\PackingS.txt";
                   if (File.Exists(packkingListPath))
                       File.Delete(packkingListPath);
                   var checks = _checksModel.Where(a => a.ChkType == Scheck).Distinct().ToList();
                   file = File.CreateText(packkingListPath);
                   file.Close();

                   using (file = new StreamWriter(File.Open(packkingListPath, FileMode.Append)))
                   {
                       string output = ChecOutputServices.ConvertToPackingList(checks, "SELF RESPONDING TICKET", _mainForm);

                       file.WriteLine(output);
                   }

               }
           }
           foreach (string Scheck in listofcheck)
           {
               if (Scheck == "TD")
               {

                   string packkingListPath = outputForlder + "\\Time_Deposit\\PackingT.txt";
                   if (File.Exists(packkingListPath))
                       File.Delete(packkingListPath);
                   var checks = _checksModel.Where(a => a.ChkType == Scheck).Distinct().ToList();
                   file = File.CreateText(packkingListPath);
                   file.Close();

                   using (file = new StreamWriter(File.Open(packkingListPath, FileMode.Append)))
                   {
                       string output = ChecOutputServices.ConvertToPackingList(checks, "TIME DEPOSIT", _mainForm);

                       file.WriteLine(output);
                   }

               }
           }
       }
       }
    }


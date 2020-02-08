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
using System.Data.OleDb;


namespace IslaBank2019.Services
{
    class CheckServices
    {
      
       // string outputForlder = "\\\\192.168.0.254\\captive\\Auto\\IslaBank\\Test";
     public void ProcessCheck(List<CheckModel> _checkm, frmMain _mainForm )
           {
            string doBlockPath;
            StreamWriter file;
            DatabaseConnectionsServices db = new DatabaseConnectionsServices();
          db.GetAllData(_checkm, _mainForm._batchfile);
            var chkList = _checkm.Select(e => e.ChkType).Distinct().ToList();
            foreach (string chk in chkList)
            {
                doBlockPath = Application.StartupPath + "\\Output\\Regular Checks\\BlockP.txt";

                if (chk == "A")
                {
                    if (File.Exists(doBlockPath))
                        File.Delete(doBlockPath);

                    file = File.CreateText(doBlockPath);
                    file.Close();

                    var chkA = _checkm.Where(e => e.ChkType == chk).ToList();

                    using (file = new StreamWriter(File.Open(doBlockPath, FileMode.Append)))
                    {
                        string output = ChecOutputServices.ConvertToBlockText(chkA, "PERSONAL", _mainForm._batchfile, _mainForm.deliveryDate,frmLogIn._userName, _mainForm.fileName);

                        file.WriteLine(output);
                   }

                }

            }
            foreach (string chk in chkList)
            {

                if (chk == "B")
                {

                    var chkB = _checkm.Where(e => e.ChkType == chk).ToList();
                    doBlockPath = Application.StartupPath + "\\Output\\Regular Checks\\BlockC.txt";
                    //    db.GetAllData(_checkModel, _mainForm._batchfile);
                    if (File.Exists(doBlockPath))
                        File.Delete(doBlockPath);

                    file = File.CreateText(doBlockPath);
                    file.Close();

                    using (file = new StreamWriter(File.Open(doBlockPath, FileMode.Append)))
                    {
                        string output = ChecOutputServices.ConvertToBlockText(chkB, "COMMERCIAL", _mainForm._batchfile, _mainForm.deliveryDate, frmLogIn._userName,_mainForm.fileName);

                        file.WriteLine(output);
                    }
                }

            }
            foreach (string chk in chkList)
            {
                if (chk == "MC")
                {

                    var chkB = _checkm.Where(e => e.ChkType == chk).ToList();
                    doBlockPath = Application.StartupPath + "\\Output\\MC\\BlockM.txt";
                    //db.GetAllData(_checkModel, _mainForm._batchfile);
                    if (File.Exists(doBlockPath))
                        File.Delete(doBlockPath);

                    file = File.CreateText(doBlockPath);
                    file.Close();

                    using (file = new StreamWriter(File.Open(doBlockPath, FileMode.Append)))
                    {
                        string output = ChecOutputServices.ConvertToBlockText(chkB, "MANAGER'S CHECK", _mainForm._batchfile, _mainForm.deliveryDate, frmLogIn._userName, _mainForm.fileName);

                        file.WriteLine(output);
                    }
                }

            }
            foreach (string chk in chkList)
            {
                if (chk == "MC_CONT")
                {

                    var chkB = _checkm.Where(e => e.ChkType == chk).ToList();
                    doBlockPath = Application.StartupPath + "\\Output\\MC\\BlockMC.txt";
                    //   db.GetAllData(_checkModel, _mainForm._batchfile);
                    if (File.Exists(doBlockPath))
                        File.Delete(doBlockPath);

                    file = File.CreateText(doBlockPath);
                    file.Close();

                    using (file = new StreamWriter(File.Open(doBlockPath, FileMode.Append)))
                    {
                        string output = ChecOutputServices.ConvertToBlockText(chkB, "MANAGER'S CHECK CONTINUES", _mainForm._batchfile, _mainForm.deliveryDate, frmLogIn._userName, _mainForm.fileName);

                        file.WriteLine(output);
                    }
                }
            }
            foreach (string chk in chkList)
            {
                if (chk == "SR")
                {
                    // db.GetAllData(_checkModel, _mainForm._batchfile);
                    var chkB = _checkm.Where(e => e.ChkType == chk).ToList();
                    doBlockPath = Application.StartupPath + "\\Output\\Self_Responding_Ticket\\BlockS.txt";

                    if (File.Exists(doBlockPath))
                        File.Delete(doBlockPath);

                    file = File.CreateText(doBlockPath);
                    file.Close();

                    using (file = new StreamWriter(File.Open(doBlockPath, FileMode.Append)))
                    {
                        string output = ChecOutputServices.ConvertToBlockText(chkB, "SELF RESPONDING TICKET", _mainForm._batchfile, _mainForm.deliveryDate, frmLogIn._userName, _mainForm.fileName);

                        file.WriteLine(output);
                    }
                }

            }
            foreach (string chk in chkList)
            {
                if (chk == "TD")
                {

                    var chkB = _checkm.Where(e => e.ChkType == chk).ToList();
                    doBlockPath = Application.StartupPath + "\\Output\\Time_Deposit\\BlockT.txt";
                    //  db.GetAllData(_checkModel, _mainForm._batchfile);
                    if (File.Exists(doBlockPath))
                        File.Delete(doBlockPath);

                    file = File.CreateText(doBlockPath);
                    file.Close();

                    using (file = new StreamWriter(File.Open(doBlockPath, FileMode.Append)))
                    {
                        string output = ChecOutputServices.ConvertToBlockText(chkB, "TIME DEPOSIT", _mainForm._batchfile, _mainForm.deliveryDate, frmLogIn._userName, _mainForm.fileName);

                        file.WriteLine(output);
                    }
                }

            }
       
            }

        public void SaveToPackingDBF(List<CheckModel> _checks, string _batchNumber, frmMain _mainForm)
        {
            string dbConnection;
            string tempCheckType = "";
            int blockNo = 0, blockCounter = 0;
            DatabaseConnectionsServices db = new DatabaseConnectionsServices();
            db.GetAllData(_checks, _mainForm._batchfile);
            
            var listofchecks = _checks.Select(e => e.ChkType).Distinct().ToList();

            foreach (string checktype in listofchecks)
            {

                if (checktype == "A" || checktype == "B")
                {
                    dbConnection = "Provider=VfpOleDB.1; Data Source=" + Application.StartupPath + "\\Output\\Regular Checks\\Packing.dbf" + "; Mode=ReadWrite;";

                    //Check if packing file exists
                    //if (!File.Exists(_filepath))
                    //{
                    OleDbConnection oConnect = new OleDbConnection(dbConnection);
                    OleDbCommand oCommand;
                    oConnect.Open();
                    oCommand = new OleDbCommand("DELETE FROM PACKING", oConnect);
                    oCommand.ExecuteNonQuery();
                    foreach (var check in _checks)
                    {
                        if (tempCheckType != check.ChkType)
                            blockNo = 1;

                        tempCheckType = check.ChkType;

                        if (blockCounter < 4)
                            blockCounter++;
                        else
                        {
                            blockCounter = 1;
                            blockNo++;
                        }

                        string sql = "INSERT INTO PACKING (BATCHNO, BLOCK, RT_NO, BRANCH, ACCT_NO, ACCT_NO_P, CHKTYPE, ACCT_NAME1, ACCT_NAME2," +
                         "NO_BKS, CK_NO_P, CK_NO_B, CK_NOE, CK_NO_E, DELIVERTO, M) VALUES('" + _batchNumber + "'," + blockNo.ToString() + ",'" + check.BRSTN + "','" + check.BranchName +
                         "','" + check.AccountNo + "','" + check.AccountNo + "','" + check.ChkType + "','" + check.Name1.Replace("'", "''") + "','" + check.Name2.Replace("'", "''") + "',1," +
                         check.StartSeries + ",'" + check.StartSeries + "'," + check.EndSeries + ",'" + check.EndSeries + "','R', '')";

                        oCommand = new OleDbCommand(sql, oConnect);

                        oCommand.ExecuteNonQuery();
                    }
                    oConnect.Close();
                }
            }
                foreach (string checktype in listofchecks)
            {

                if (checktype == "MC"  || checktype == "MC_CONT")
                {
                    dbConnection = "Provider=VfpOleDB.1; Data Source=" + Application.StartupPath + "\\Output\\MC\\Packing.dbf" + "; Mode=ReadWrite;";

                     //Check if packing file exists
                     //if (!File.Exists(_filepath))
                     //{
                     OleDbConnection oConnect = new OleDbConnection(dbConnection);
                     OleDbCommand oCommand;
                     oConnect.Open();
                     oCommand = new OleDbCommand("DELETE FROM PACKING", oConnect);
                     oCommand.ExecuteNonQuery();
                     foreach (var check in _checks)
                     {
                         if (tempCheckType != check.ChkType)
                             blockNo = 1;

                         tempCheckType = check.ChkType;

                         if (blockCounter < 4)
                             blockCounter++;
                         else
                         {
                             blockCounter = 1;
                             blockNo++;
                         }

                         string sql = "INSERT INTO PACKING (BATCHNO, BLOCK, RT_NO, BRANCH, ACCT_NO, ACCT_NO_P, CHKTYPE, ACCT_NAME1, ACCT_NAME2," +
                          "NO_BKS, CK_NO_P, CK_NO_B, CK_NOE, CK_NO_E, DELIVERTO, M) VALUES('" + _batchNumber + "'," + blockNo.ToString() + ",'" + check.BRSTN + "','" + check.BranchName +
                          "','" + check.AccountNo + "','" + check.AccountNo + "','" + check.ChkType + "','" + check.Name1.Replace("'", "''") + "','" + check.Name2.Replace("'", "''") + "',1," +
                          check.StartSeries + ",'" + check.StartSeries + "'," + check.EndSeries + ",'" + check.EndSeries + "','R', '')";

                         oCommand = new OleDbCommand(sql, oConnect);

                         oCommand.ExecuteNonQuery();
                     }
                     oConnect.Close();
                }

            }

                foreach (string checktype in listofchecks)
                {

                    if (checktype == "SR")
                    {
                        dbConnection = "Provider=VfpOleDB.1; Data Source=" + Application.StartupPath + "\\Output\\Self_Responding_Ticket\\Packing.dbf" + "; Mode=ReadWrite;";

                        //Check if packing file exists
                        //if (!File.Exists(_filepath))
                        //{
                        OleDbConnection oConnect = new OleDbConnection(dbConnection);
                        OleDbCommand oCommand;
                        oConnect.Open();
                        oCommand = new OleDbCommand("DELETE FROM PACKING", oConnect);
                        oCommand.ExecuteNonQuery();
                        foreach (var check in _checks)
                        {
                            if (tempCheckType != check.ChkType)
                                blockNo = 1;

                            tempCheckType = check.ChkType;

                            if (blockCounter < 4)
                                blockCounter++;
                            else
                            {
                                blockCounter = 1;
                                blockNo++;
                            }

                            string sql = "INSERT INTO PACKING (BATCHNO, BLOCK, RT_NO, BRANCH, ACCT_NO, ACCT_NO_P, CHKTYPE, ACCT_NAME1, ACCT_NAME2," +
                             "NO_BKS, CK_NO_P, CK_NO_B, CK_NOE, CK_NO_E, DELIVERTO, M) VALUES('" + _batchNumber + "'," + blockNo.ToString() + ",'" + check.BRSTN + "','" + check.BranchName +
                             "','" + check.AccountNo + "','" + check.AccountNo + "','" + check.ChkType + "','" + check.Name1.Replace("'", "''") + "','" + check.Name2.Replace("'", "''") + "',1," +
                             check.StartSeries + ",'" + check.StartSeries + "'," + check.EndSeries + ",'" + check.EndSeries + "','R', '')";

                            oCommand = new OleDbCommand(sql, oConnect);

                            oCommand.ExecuteNonQuery();
                        }
                        oConnect.Close();
                    }

                }

                foreach (string checktype in listofchecks)
                {

                    if (checktype == "TD")
                    {
                        dbConnection = "Provider=VfpOleDB.1; Data Source=" + Application.StartupPath + "\\Output\\Time_Deposit\\Packing.dbf" + "; Mode=ReadWrite;";

                        //Check if packing file exists
                        //if (!File.Exists(_filepath))
                        //{
                        OleDbConnection oConnect = new OleDbConnection(dbConnection);
                        OleDbCommand oCommand;
                        oConnect.Open();
                        oCommand = new OleDbCommand("DELETE FROM PACKING", oConnect);
                        oCommand.ExecuteNonQuery();
                        foreach (var check in _checks)
                        {
                            if (tempCheckType != check.ChkType)
                                blockNo = 1;

                            tempCheckType = check.ChkType;

                            if (blockCounter < 4)
                                blockCounter++;
                            else
                            {
                                blockCounter = 1;
                                blockNo++;
                            }

                            string sql = "INSERT INTO PACKING (BATCHNO, BLOCK, RT_NO, BRANCH, ACCT_NO, ACCT_NO_P, CHKTYPE, ACCT_NAME1, ACCT_NAME2," +
                             "NO_BKS, CK_NO_P, CK_NO_B, CK_NOE, CK_NO_E, DELIVERTO, M) VALUES('" + _batchNumber + "'," + blockNo.ToString() + ",'" + check.BRSTN + "','" + check.BranchName +
                             "','" + check.AccountNo + "','" + check.AccountNo + "','" + check.ChkType + "','" + check.Name1.Replace("'", "''") + "','" + check.Name2.Replace("'", "''") + "',1," +
                             check.StartSeries + ",'" + check.StartSeries + "'," + check.EndSeries + ",'" + check.EndSeries + "','R', '')";

                            oCommand = new OleDbCommand(sql, oConnect);

                            oCommand.ExecuteNonQuery();
                        }
                        oConnect.Close();
                    }

                }
            

        }
        public void SavePackingDBF(List<CheckModel> _list, frmMain _mainForm)
        {
            DatabaseConnectionsServices db = new DatabaseConnectionsServices();
            db.GetAllData(_list, _mainForm._batchfile);
      
        
        }

        public void PrinterFile(List<CheckModel> _checkModel, frmMain _mainForm)
        {

            DatabaseConnectionsServices db = new DatabaseConnectionsServices();
            db.GetAllData(_checkModel, _mainForm._batchfile);
            StreamWriter file;

            var listofchecks = _checkModel.Select(e => e.ChkType).Distinct().ToList();

            foreach (string checktype in listofchecks)
            {
                if (checktype == "A")
                {
                    string printerFilePathA = Application.StartupPath + "\\Output\\Regular Checks\\ISL" + _mainForm._batchfile.Substring(0, 4) + "P." +DateTime.Now.ToString("yy") + "P";
                    var check = _checkModel.Where(e => e.ChkType == checktype).ToList();
                    if (File.Exists(printerFilePathA))
                        File.Delete(printerFilePathA);

                    file = File.CreateText(printerFilePathA);
                    file.Close();

                    for (int a = 0; a < check.Count; a++)
                    {


                        using (file = new StreamWriter(File.Open(printerFilePathA, FileMode.Append)))
                        {
                            string output = ChecOutputServices.ConvertToPrinterFormat1(check[a].BRSTN, check[a].AccountNo, long.Parse(check[a].StartSeries), check[a].Qty, check[a].Name1, check[a].Name2, check[a].Address1, check[a].Address2, check[a].Address3, check[a].Address4, check[a].Address5, check[a].Address6, check[a].Address1, "A");

                            file.WriteLine(output);
                        }
                    }
                    ZipFileServices.CopyPrinterFile(checktype, _mainForm);
                    ZipFileServices.CopyPackingDBF(checktype, _mainForm);
                }

            }
            foreach (string checktype in listofchecks)
            {
                if (checktype == "B")
                {
                    string printerFilePath = Application.StartupPath + "\\Output\\Regular Checks\\ISL" + _mainForm._batchfile.Substring(0, 4) + "C." + DateTime.Now.ToString("yy") + "P";
                    var check = _checkModel.Where(e => e.ChkType == checktype).ToList();
                    if (File.Exists(printerFilePath))
                        File.Delete(printerFilePath);

                    file = File.CreateText(printerFilePath);
                    file.Close();
                    for (int a = 0; a < check.Count; a++)
                    {


                        using (file = new StreamWriter(File.Open(printerFilePath, FileMode.Append)))
                        {
                            string output = ChecOutputServices.ConvertToPrinterFormat1(check[a].BRSTN, check[a].AccountNo, long.Parse(check[a].StartSeries), check[a].Qty, check[a].Name1, check[a].Name2, check[a].Address1, check[a].Address2, check[a].Address3, check[a].Address4, check[a].Address5, check[a].Address6, check[a].Address1, "A");

                            file.WriteLine(output);
                        }
                    }
                    ZipFileServices.CopyPrinterFile(checktype, _mainForm);
                    ZipFileServices.CopyPackingDBF(checktype, _mainForm);
                }
            }
            foreach (string checktype in listofchecks)
            {

                if (checktype == "MC")
                {
                    string printerFilePath = Application.StartupPath + "\\Output\\MC\\MC" + _mainForm._batchfile.Substring(0,4) + "M." + DateTime.Now.ToString("yy") + "P";
                    var check = _checkModel.Where(e => e.ChkType == checktype).ToList();
                    if (File.Exists(printerFilePath))
                        File.Delete(printerFilePath);

                    file = File.CreateText(printerFilePath);
                    file.Close();
                    for (int a = 0; a < check.Count; a++)
                    {


                        using (file = new StreamWriter(File.Open(printerFilePath, FileMode.Append)))
                        {
                            string output = ChecOutputServices.ConvertToPrinterFormat1(check[a].BRSTN, check[a].AccountNo, long.Parse(check[a].StartSeries), check[a].Qty, check[a].Name1, check[a].Name2, check[a].Address1, check[a].Address2, check[a].Address3, check[a].Address4, check[a].Address5, check[a].Address6, check[a].Address1, "A");

                            file.WriteLine(output);
                        }
                    }
                    ZipFileServices.CopyPrinterFile(checktype, _mainForm);
                    ZipFileServices.CopyPackingDBF(checktype, _mainForm);
                }
               
            }
            foreach (string checktype in listofchecks)
            {

                if (checktype == "MC_CONT")
                {
                    string printerFilePath = Application.StartupPath + "\\Output\\MC\\MC" + _mainForm._batchfile.Substring(0, 4) + "MC." + DateTime.Now.ToString("yy") + "P";
                    var check = _checkModel.Where(e => e.ChkType == checktype).ToList();
                    if (File.Exists(printerFilePath))
                        File.Delete(printerFilePath);

                    file = File.CreateText(printerFilePath);
                    file.Close();
                    for (int a = 0; a < check.Count; a++)
                    {


                        using (file = new StreamWriter(File.Open(printerFilePath, FileMode.Append)))
                        {
                            string output = ChecOutputServices.ConvertToPrinterFormat1(check[a].BRSTN, check[a].AccountNo, long.Parse(check[a].StartSeries), check[a].Qty, check[a].Name1, check[a].Name2, check[a].Address1, check[a].Address2, check[a].Address3, check[a].Address4, check[a].Address5, check[a].Address6, check[a].Address1, "A");

                            file.WriteLine(output);
                        }
                    }
                    ZipFileServices.CopyPrinterFile(checktype, _mainForm);
                    ZipFileServices.CopyPackingDBF(checktype, _mainForm);
                }

            }
            foreach (string checktype in listofchecks)
            {

                if (checktype == "SR")
                {
                    string printerFilePath = Application.StartupPath + "\\Output\\Self_Responding_Ticket\\ISL" + _mainForm._batchfile.Substring(0, 4) + "S." + DateTime.Now.ToString("yy") + "P";
                    var check = _checkModel.Where(e => e.ChkType == checktype).ToList();
                    if (File.Exists(printerFilePath))
                        File.Delete(printerFilePath);

                    file = File.CreateText(printerFilePath);
                    file.Close();
                    for (int a = 0; a < check.Count; a++)
                    {


                        using (file = new StreamWriter(File.Open(printerFilePath, FileMode.Append)))
                        {
                            string output = ChecOutputServices.ConvertToPrinterFormat1(check[a].BRSTN, check[a].AccountNo, long.Parse(check[a].StartSeries), check[a].Qty, check[a].Name1, check[a].Name2, check[a].Address1, check[a].Address2, check[a].Address3, check[a].Address4, check[a].Address5, check[a].Address6, check[a].Address1, "A");

                            file.WriteLine(output);
                        }
                    }
                    ZipFileServices.CopyPrinterFile(checktype, _mainForm);
                    ZipFileServices.CopyPackingDBF(checktype, _mainForm);
                }
            }

            foreach (string checktype in listofchecks)
            {
                if (checktype == "TD")
                {
                    string printerFilePath = Application.StartupPath + "\\Output\\Time_Deposit\\ISL" + _mainForm._batchfile.Substring(0, 4) + "T." + DateTime.Now.ToString("yy") + "P";
                    var check = _checkModel.Where(e => e.ChkType == checktype).ToList();
                    if (File.Exists(printerFilePath))
                        File.Delete(printerFilePath);

                    file = File.CreateText(printerFilePath);
                    file.Close();
                    for (int a = 0; a < check.Count; a++)
                    {


                        using (file = new StreamWriter(File.Open(printerFilePath, FileMode.Append)))
                        {
                            string output = ChecOutputServices.ConvertToPrinterFormat1(check[a].BRSTN, check[a].AccountNo, long.Parse(check[a].StartSeries), check[a].Qty, check[a].Name1, check[a].Name2, check[a].Address1, check[a].Address2, check[a].Address3, check[a].Address4, check[a].Address5, check[a].Address6, check[a].Address1, "A");

                            file.WriteLine(output);
                        }
                    }
                    ZipFileServices.CopyPrinterFile(checktype, _mainForm);
                    ZipFileServices.CopyPackingDBF(checktype, _mainForm);
                }
               
            }
        }
        public void Insert4Outs(List<CheckModel> _listCheck, frmMain _mainform)
        {
            DatabaseConnectionsServices db = new DatabaseConnectionsServices();
            db.GetAllData(_listCheck, _mainform._batchfile);

            db.SaveToMDB(_listCheck, _mainform._batchfile);

        }
        public void DeletePrinterAndTextFile()
        {
            int counter = 0;
            string path = Application.StartupPath + "\\Output\\Regular Checks";
            for (counter = 0; counter < 5; counter++)
            {

                if (counter == 0)
                {
                    DeleteDataInFolder(path);
                }
                else if (counter == 1)
                {
                    path = Application.StartupPath + "\\Output\\MC";
                    DeleteDataInFolder(path);
                }
                else if (counter == 3)
                {
                    path = Application.StartupPath + "\\Output\\Self_Responding_Ticket";
                    DeleteDataInFolder(path);
                }
                else if (counter == 4)
                {
                    path = Application.StartupPath + "\\Output\\Time_Deposit";
                    DeleteDataInFolder(path);
                }
            }
        }
        public void DeleteDataInFolder(string path)
        {

            DirectoryInfo d2 = new DirectoryInfo(path);
            FileInfo[] files2 = d2.GetFiles("*.txt")
                     .Where(p => p.Extension == ".txt").ToArray();
            foreach (FileInfo file in files2)
            {
                file.Attributes = FileAttributes.Normal;
                File.Delete(file.FullName);
            }
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*." + DateTime.Now.ToString("yy") + "P")
                     .Where(p => p.Extension == "." + DateTime.Now.ToString("yy") + "P").ToArray();

            foreach (FileInfo file in files)
            {
                file.Attributes = FileAttributes.Normal;
                File.Delete(file.FullName);
            }
        }
    }
}

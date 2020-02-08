using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using IslaBank2019.Model;
using System.Globalization;
using System.Data.OleDb;
using ADOX;
using System.IO;
using System.Diagnostics;


namespace IslaBank2019.Services
{
    class DatabaseConnectionsServices
    {
       
        public MySqlConnection myConnect;
        private int serial = 1;
         public void DBConnect()
        {
            //try
            //{
                string DBConnection = "";

                if (Properties.Settings.Default.IfTest)
                {
                    DBConnection = "datasource=localhost;port=3306;username=root;password=corpcaptive; convert zero datetime=True;";
                    MessageBox.Show("Hello Test!!!" );
                }
                else
                {
                  //  DBConnection = "";
                    DBConnection = "datasource=192.168.0.254;port=3306;username=root;password=CorpCaptive; convert zero datetime=True;";
                   // MessageBox.Show("HELLO");

                }


                myConnect = new MySqlConnection(DBConnection);

                myConnect.Open();
              
            //}
            //catch(Exception Error)
            //{

            //    MessageBox.Show(Error.Message, "System Error");
            //}
         }// end of function

        public void DBClosed()
        {
            myConnect.Close();
        }// end of function

        public DataTable GetBranch(DataTable data) //loading the branches
        {
            string sql = "SELECT DISTINCT(BranchName) FROM captive_database.isla_ref Order by BranchName";
            DBConnect();
      
            MySqlDataAdapter cmd = new MySqlDataAdapter(sql, myConnect);

            //DataTable dataSet = new DataTable();
            cmd.Fill(data);

          

            return data;

        }//end of function
        public BranchesModel GetBranchesDetails(BranchesModel _refmodel, string _Brstn)
        {
            DBConnect();
            string sql = "SELECT BRSTN,Address1, Address2, Address3,Address4,Address5,Address6 FROM captive_database.isla_branches where BRSTN ='" + _Brstn + "'";

            MySqlCommand cmd = new MySqlCommand(sql, myConnect);

            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                _refmodel.BRSTN = myReader.GetString(0);
                _refmodel.Address1 = myReader.GetString(1);
                _refmodel.Address2 = myReader.GetString(2);
                _refmodel.Address3 = myReader.GetString(3);
                _refmodel.Address4 = myReader.GetString(4);
                _refmodel.Address5 = myReader.GetString(5);
                _refmodel.Address6 = myReader.GetString(6);
            }

            DBClosed();
            return _refmodel;

        }// end of function
        public DataTable GETChequeName(DataTable data)
        {
            string sql = "Select Distinct(ChequeName) from captive_database.isla_cheques";
            DBConnect();
            MySqlDataAdapter adp = new MySqlDataAdapter(sql,myConnect);
          //  DataTable dt = new DataTable();
            adp.Fill(data);
            
            
            return data;
        }// end of function

        public DataTable LoadDataToGridView(DataTable data)
        {
            string sql = "Select BRSTN, CheckType as ChequeType, ChequeTypeName as ChequeName, AccountNumber, Name1 as Name, Name2 as SecondaryName, BranchName as BranchName from captive_database.isla_temptable";
            DBConnect();
            MySqlDataAdapter adp = new MySqlDataAdapter(sql,myConnect);
            adp.Fill(data);
            return data;
        }// end of function


        public CheckModel SavedDatatoDatabase(CheckModel _check, string _batch)
        {

            string sql = "INSERT INTO captive_database.master_database_islabank_archive(Date,Time,DeliveryDate,ChkType,ChequeName,BRSTN,AccountNo,Name1,Name2,Address1,Address2,Address3,Address4,Address5,Address6,Batch,StartingSerial, EndingSerial)VALUES(" +
                        
                        "'" + DateTime.Now.ToString("yyyy-MM-dd") +"'," +
                        "'" +DateTime.Now.ToString("HH:mm:ss") +"'," +
                        "'" +_check.DeliveryDate.ToString("yyyy-MM-dd") + "'," +
                        "'" + _check.ChkType + "'," +
                        "'" + _check.ChkTypeName + "'," +
                        "'" + _check.BRSTN + "'," +
                        "'" + _check.AccountNo + "'," +
                        "'" + _check.Name1 + "'," +
                        "'" + _check.Name2 + "'," +
                        "'" + _check.BranchName + "'," +
                        "'" + _check.Address2 + "'," +
                        "'" + _check.Address3 + "'," +
                        "'" + _check.Address4 + "'," +
                        "'" + _check.Address5 + "'," +
                        "'" + _check.Address6 + "'," +
                        "'" + _batch + "'," +
                        "'" + _check.StartSeries + "'," +
                        "'" + _check.EndSeries + "')";

       

            DBConnect();
            MySqlCommand myCommand = new MySqlCommand(sql, myConnect);

            myCommand.ExecuteNonQuery();
            DBClosed();
            return _check;
        }// end of function
        public CheckModel SaveToSecondaryTable(CheckModel _check)
        {

            string sql = "INSERT INTO captive_database.isla_temptable (BRSTN,AccountNumber,CheckType,ChequeTypeName,Name1,Name2,Quantity,BranchName,StartingSerial,EndingSerial,Address1,Address2,Address3,Address4,Address5,Address6)VALUES(" +
                        "'" + _check.BRSTN + "'," +
                        "'" + _check.AccountNo + "'," +
                        "'" + _check.ChkType + "'," +
                        "'" + _check.ChkTypeName + "'," +
                        "'" + _check.Name1 + "'," +
                        "'" + _check.Name2 + "'," +
                        "'" + _check.Qty + "', " +
                        "'" + _check.BranchName+ "'," +
                        "'" + _check.StartSeries + "'," +
                        "'" + _check.EndSeries + "'," +
                        "'" + _check.Address1 + "'," +
                        "'" + _check.Address2 + "'," +
                        "'" + _check.Address3 + "'," +
                        "'" + _check.Address4 + "'," +
                        "'" + _check.Address5 + "'," +
                        "'" + _check.Address6 + "')";

            
            DBConnect();
            MySqlCommand myCommand = new MySqlCommand(sql, myConnect);

            myCommand.ExecuteNonQuery();
            DBClosed();
            return _check;
        }// end of function


        public RefModel GetLastNO( RefModel _refmodel ,string _checkType , string _Brstn)
        {
            DBConnect();
            string sql = "SELECT  * FROM captive_database.isla_ref where BRSTN ='"+_Brstn+"' and CheckType ='"+_checkType+"'";
          
            MySqlCommand cmd = new MySqlCommand(sql, myConnect);
           
             MySqlDataReader myReader = cmd.ExecuteReader();
         
           
            while(myReader.Read())
            {
                _refmodel.ID = int.Parse(myReader.GetString(0));
                _refmodel.Date = DateTime.Parse(myReader.GetString(1));
                _refmodel.BRSTN = myReader.GetString(2);
                _refmodel.CheckType = myReader.GetString(3);
                _refmodel.LastNo = myReader.GetInt64(4);
                _refmodel.BranchName = myReader.GetString(5);
                _refmodel.P_Before = int.Parse(myReader.GetString(6));
                _refmodel.C_Before = int.Parse(myReader.GetString(7));
            }

            DBClosed();
            return _refmodel;
            
        }// end of function

        public RefModel UpdateRef(RefModel _ref)
        {
            DBConnect();
            string sql = "Update captive_database.isla_ref SET LastNo = '"+ _ref.LastNo +"', Date = '"+_ref.Date.ToString("yyyy-MM-dd")+ "' where BRSTN = '"+_ref.BRSTN+"' and CheckType = '"+_ref.CheckType +"'";
            MySqlCommand cmd = new MySqlCommand(sql, myConnect);

            MySqlDataReader myReader = cmd.ExecuteReader();
            DBClosed();
            return _ref;
            
        }// end of function

    
        public List<CheckModel> GetAllData(List<CheckModel> check, string _batch)
        {
            DBConnect();
            string sql = "SELECT BRSTN,AccountNumber,CheckType,ChequeTypeName,Name1,Name2,Quantity,BranchName,StartingSerial,EndingSerial,Address1, Address2, Address3, Address4, Address5,Address6 FROM captive_database.isla_temptable ";           

            MySqlCommand cmd = new MySqlCommand(sql, myConnect);
       
            MySqlDataReader dr = cmd.ExecuteReader();
         
           // List<CheckModel> check = new List<CheckModel>();
           
                while (dr.Read())
                {
                    CheckModel model = new CheckModel
                    {
                        BRSTN = dr.GetString(0),
                        AccountNo = dr.GetString(1),
                        ChkType = dr.GetString(2),
                        ChkTypeName = dr.GetString(3),
                        Name1 = dr.GetString(4),
                        Name2 = dr.GetString(5),
                        Qty = int.Parse(dr.GetString(6)),
                        BranchName = dr.GetString(7),
                        StartSeries = dr.GetString(8),
                        EndSeries = dr.GetString(9),
                        Address1 = dr.GetString(10),
                        Address2 = dr.GetString(11),
                        Address3 = dr.GetString(12),
                        Address4 = dr.GetString(13),
                        Address5 = dr.GetString(14),
                        Address6 = dr.GetString(15)

                    };

                    check.Add(model);
                }
         
            DBClosed();
            return check;
            
        }// end of function

        public List<CheckModel> GetNameifExisting(List<CheckModel> check)
        {
            DBConnect();
            string sql = "Select BRSTN, ChkType, AccountNo,Name1,Name2,Address1,ChequeName from captive_database.master_database_islabank_archive";


            MySqlCommand cmd = new MySqlCommand(sql, myConnect);

            MySqlDataReader dr = cmd.ExecuteReader();

            // List<CheckModel> check = new List<CheckModel>();

            while (dr.Read())
            {
                CheckModel model = new CheckModel
                {
                    BRSTN = dr.GetString(0),
                    ChkType = dr.GetString(1),
                    AccountNo = dr.GetString(2),
                    Name1 = dr.GetString(3),
                    Name2 = dr.GetString(4),
                    Address1 = dr.GetString(5),
                    ChkTypeName = dr.GetString(6)
                   // BranchName = dr.GetString(5),
                    //Address2 = dr.GetString(6),
                 //   ChkTypeName = dr.GetString(6),
                    // BranchName = dr.GetString(8),
                   // StartSeries = dr.GetString(7),
                   // EndSeries = dr.GetString(8)
                };

                check.Add(model);
            }

            DBClosed();
            return check;
        }// end of function


        public void DeleteTempData()
        {
            string sql = "Delete from captive_database.isla_temptable";
            MySqlCommand cmd = new MySqlCommand(sql, myConnect);
            myConnect.Open();
            cmd.ExecuteNonQuery();
            myConnect.Close();
        }// end of function

        public void CreateTable(string _batch )
        {

            string DBPath;
            OleDbConnection conn;
            //OleDbDataAdapter adapter;
            //DataTable dtMain;
            DBPath = Application.StartupPath + "\\" + _batch + ".mdb";

            //// create DB via ADOX if not exists
            if (!File.Exists(DBPath))
            {
              

                ADOX.Catalog cat = new ADOX.Catalog();

                cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBPath);
                cat = null;

            }
       

            // connect to DB
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBPath);
              conn.Open();

            // create table "Table_1" if not exists
            // DO NOT USE SPACES IN TABLE AND COLUMNS NAMES TO PREVENT TROUBLES WITH SAVING, USE _
            // OLEDBCOMMANDBUILDER DON'T SUPPORT COLUMNS NAMES WITH SPACES
            try
            {
                using (OleDbCommand cmd = new OleDbCommand("CREATE TABLE [InputFile_Temp] ([BRSTN] TEXT, "+
                                                           " [AccountNumber] TEXT, [RT1to5] TEXT, [RT6to9] TEXT,[AccountNumberWithHyphen] TEXT,"+
                                                           "[Serial] TEXT, [Name1] TEXT, [Name2] TEXT  " +
                                                           ",[Address1] TEXT, [Address2] TEXT, [Address3] TEXT,[Address4] TEXT, [Address5] TEXT,"+
                                                           "[Address6] TEXT, [BankName] TEXT,[StartingSerial] TEXT,[EndingSerial] TEXT, [PcsPerBook] TEXT,[FileName] TEXT,[PageNumber] NUMBER, [DataNumber] TEXT);", conn))
                     {
                    cmd.ExecuteNonQuery();

                }
                using (OleDbCommand cmd = new OleDbCommand("CREATE TABLE [InputFile_1outs] ([BRSTN] TEXT, " +
                                                           " [AccountNumber] TEXT, [RT1to5] TEXT, [RT6to9] TEXT,[AccountNumberWithHyphen] TEXT," +
                                                           "[Serial] TEXT, [Name1] TEXT, [Name2] TEXT  " +
                                                           ",[Address1] TEXT, [Address2] TEXT, [Address3] TEXT,[Address4] TEXT, [Address5] TEXT," +
                                                           "[Address6] TEXT, [BankName] TEXT,[StartingSerial] TEXT,[EndingSerial] TEXT, [PcsPerBook] TEXT,[FileName] TEXT,[PageNumber] NUMBER, [DataNumber] TEXT);", conn))
                {
                    cmd.ExecuteNonQuery();

                }
                using (OleDbCommand cmd = new OleDbCommand("CREATE TABLE [InputFile_2outs] ([BRSTN] TEXT, " +
                                                           " [AccountNumber] TEXT, [RT1to5] TEXT, [RT6to9] TEXT,[AccountNumberWithHyphen] TEXT," +
                                                           "[Serial] TEXT, [Name1] TEXT, [Name2] TEXT  " +
                                                           ",[Address1] TEXT, [Address2] TEXT, [Address3] TEXT,[Address4] TEXT, [Address5] TEXT," +
                                                           "[Address6] TEXT, [BankName] TEXT,[StartingSerial] TEXT,[EndingSerial] TEXT, [PcsPerBook] TEXT,[FileName] TEXT,[PageNumber] NUMBER, [DataNumber] TEXT);", conn))
                {
                    cmd.ExecuteNonQuery();

                }
                using (OleDbCommand cmd = new OleDbCommand("CREATE TABLE [InputFile_3outs] ([BRSTN] TEXT, " +
                                                           " [AccountNumber] TEXT, [RT1to5] TEXT, [RT6to9] TEXT,[AccountNumberWithHyphen] TEXT," +
                                                           "[Serial] TEXT, [Name1] TEXT, [Name2] TEXT  " +
                                                           ",[Address1] TEXT, [Address2] TEXT, [Address3] TEXT,[Address4] TEXT, [Address5] TEXT," +
                                                           "[Address6] TEXT, [BankName] TEXT,[StartingSerial] TEXT,[EndingSerial] TEXT, [PcsPerBook] TEXT,[FileName] TEXT,[PageNumber] NUMBER, [DataNumber] TEXT);", conn))
                {
                    cmd.ExecuteNonQuery();

                }
                using (OleDbCommand cmd = new OleDbCommand("CREATE TABLE [InputFile_4outs] ([BRSTN] TEXT, " +
                                                           " [AccountNumber] TEXT, [RT1to5] TEXT, [RT6to9] TEXT,[AccountNumberWithHyphen] TEXT," +
                                                           "[Serial] TEXT, [Name1] TEXT, [Name2] TEXT  " +
                                                           ",[Address1] TEXT, [Address2] TEXT, [Address3] TEXT,[Address4] TEXT, [Address5] TEXT," +
                                                           "[Address6] TEXT, [BankName] TEXT,[StartingSerial] TEXT,[EndingSerial] TEXT, [PcsPerBook] TEXT,[FileName] TEXT,[PageNumber] NUMBER, [DataNumber] TEXT);", conn))
                {
                    cmd.ExecuteNonQuery();

                }

                conn.Close();
            }
            catch (Exception ex) { if (ex != null) ex = null; }

        }// end of function

        public List<CheckModel> SaveToMDB(List<CheckModel> _mdbCheck, string _filename)
        {
            int pageNumber = 1;
         //   int index = 0;
            OleDbConnection conn = new OleDbConnection();
           
            //      int checkCount = _mdbCheck.Count;
            //for (int k = 0; k < _mdbCheck.Count; k++)
            //{
            //double f = _mdbCheck.Count;
            //    double x =  Math.Ceiling(f/4) * 100 /100;
            int x = 0;
            OleDbCommand cmd;
            int counter = 3;
            int loopcount = 0;
            int DataNumber = 1;
            int OrigNumber = 1;
            //int LoopCount1 = 0;
            OneOut:
            while (loopcount < 50)
            {
                serial = int.Parse(_mdbCheck[x].StartSeries) + loopcount;
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\" + _filename + ".mdb";

                conn.Open();


                cmd = new OleDbCommand("INSERT into InputFile_1outs (BRSTN,AccountNumber, RT1to5," +
                             "RT6to9, AccountNumberWithHyphen, Serial, Name1, Name2, Address1," +
                             "Address2,Address3,Address4, Address5, Address6, BankName, StartingSerial," +
                             "EndingSerial, PcsPerBook, FileName, PageNumber, DataNumber) Values('" + _mdbCheck[x].BRSTN + "','" + _mdbCheck[x].AccountNo + "','" +
                             _mdbCheck[x].BRSTN.Substring(0, 5) + "','" + _mdbCheck[x].BRSTN.Substring(5, 4) + "','" + _mdbCheck[x].AccountNo.Substring(0, 4) + "-" + _mdbCheck[x].AccountNo.Substring(5, 4) + "-" + _mdbCheck[x].AccountNo.Substring(8, 1) +
                            "','" + serial + "','" + _mdbCheck[x].Name1 + "','" + _mdbCheck[x].Name2 + "','" + _mdbCheck[x].Address1 +
                            "','" + _mdbCheck[x].Address2 + "','" + _mdbCheck[x].Address3 + "','" + _mdbCheck[x].Address4 + "','" + _mdbCheck[x].Address5 +
                            "','" + _mdbCheck[x].Address6 + "','" + _mdbCheck[x].BranchName + "','" + _mdbCheck[x].StartSeries +
                            "','" + _mdbCheck[x].EndSeries + "',50,'" + _filename + "'," + pageNumber +",'" +DataNumber +"')", conn);


                cmd.ExecuteNonQuery();

                conn.Close();
                //TempStartingSerial = TempStartingSerial + 1;
                DataNumber += 1;
                loopcount++;
                //mdb_status_bar = mdb_status_bar + 1;
            }
            if (x < _mdbCheck.Count - 1)
            {
                x++;
                loopcount = 0;
                pageNumber++;
                goto OneOut;
            }
            //DataNumber = OrigNumber;
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\" + _filename + ".mdb");
            cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "DELETE FROM InputFile_Temp";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();


            string All_Column = "BRSTN,AccountNumber, RT1to5," +
                             "RT6to9, AccountNumberWithHyphen, Serial, Name1, Name2, Address1," +
                             "Address2,Address3,Address4, Address5, Address6, BankName, StartingSerial," +
                             "EndingSerial, PcsPerBook, FileName, PageNumber, DataNumber";
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\" + _filename + ".mdb");
            cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "INSERT INTO InputFile_Temp (" + All_Column + ") SELECT " + All_Column + " FROM InputFile_1outs";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();

//            DataNumber = OrigNumber;
            while (DataNumber % (50 * 4) != 0)
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\" + _filename + ".mdb");
                cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "INSERT INTO InputFile_Temp (DataNumber) VALUES ('" + DataNumber + 1 + "')";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                DataNumber = DataNumber + 1;

              
            }

            int LineNumber1 = 50 * 0;
            int LineNumber2 = 50 * 1;
            int LineNumber3 = 50 * 2;
            int LineNumber4 = 50 * 3;

        RepeatMe_4Outs:


            int LoopCount = 0;
            while (LoopCount < 50)
            {
                //Line Number 1
                LineNumber1 = LineNumber1 + 1;

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\" + _filename + ".mdb");
                cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "INSERT INTO InputFile_4Outs (" + All_Column + ") SELECT " + All_Column + " FROM InputFile_Temp WHERE DataNumber = '" + LineNumber1 + "'";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                //End Line Number 1




                //Line Number 2
                LineNumber2 = LineNumber2 + 1;

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\" + _filename + ".mdb");
                cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "INSERT INTO InputFile_4Outs (" + All_Column + ") SELECT " + All_Column + " FROM InputFile_Temp WHERE DataNumber = '" + LineNumber2 + "'";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();

                //End Line Number 2




                //Line Number 3
                LineNumber3 = LineNumber3 + 1;

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\" + _filename + ".mdb");
                cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "INSERT INTO InputFile_4Outs (" + All_Column + ") SELECT " + All_Column + " FROM InputFile_Temp WHERE DataNumber = '" + LineNumber3 + "'";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();

                //End Line Number 3

                 

                //Line Number 4
                LineNumber4 = LineNumber4 + 1;

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\" + _filename + ".mdb");
                cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "INSERT INTO InputFile_4Outs (" + All_Column + ") SELECT " + All_Column + " FROM InputFile_Temp WHERE DataNumber = '" + LineNumber4 + "'";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();

                //End Line Number 4


                LoopCount = LoopCount + 1;
            }

            if (LineNumber4 != DataNumber)
            {
                LineNumber1 = LineNumber1 + (50 * 3);
                LineNumber2 = LineNumber2 + (50 * 3);
                LineNumber3 = LineNumber3 + (50 * 3);
                LineNumber4 = LineNumber4 + (50 * 3);

                goto RepeatMe_4Outs;
            }

         //fourOuts:
           

         //    while (loopcount < 50)
         //    {

         //        while (x < 4)
         //        {
         //            serial = int.Parse(_mdbCheck[x].StartSeries) + loopcount;



         //                        cmd = new OleDbCommand("INSERT into InputFile_4outs (BRSTN,AccountNumber, RT1to5," +
         //                                     "RT6to9, AccountNumberWithHyphen, Serial, Name1, Name2, Address1," +
         //                                     "Address2,Address3,Address4, Address5, Address6, BankName, StartingSerial," +
         //                                     "EndingSerial, PcsPerBook, FileName, PageNumber) Values('" + _mdbCheck[x].BRSTN + "','" + _mdbCheck[x].AccountNo + "','" +
         //                                     _mdbCheck[x].BRSTN.Substring(0, 5) + "','" + _mdbCheck[x].BRSTN.Substring(5, 4) + "','" + _mdbCheck[x].AccountNo.Substring(0, 4) + "-" + _mdbCheck[x].AccountNo.Substring(5, 4) + "-" + _mdbCheck[x].AccountNo.Substring(8, 1) +
         //                                    "','" + serial + "','" + _mdbCheck[x].Name1 + "','" + _mdbCheck[x].Name2 + "','" + _mdbCheck[x].Address1 +
         //                                    "','" + _mdbCheck[x].Address2 + "','" + _mdbCheck[x].Address3 + "','" + _mdbCheck[x].Address4 + "','" + _mdbCheck[x].Address5 +
         //                                    "','" + _mdbCheck[x].Address6 + "','" + _mdbCheck[x].BranchName + "','" + _mdbCheck[x].StartSeries +
         //                                    "','" + _mdbCheck[x].EndSeries + "',50,'" + _filename + "'," + pageNumber + ")", conn);


         //            cmd.ExecuteNonQuery();

         //            x++;
         //        }

         //        if (counter == 3)
         //        {
         //            x = 0;
         //        }
         //        else
         //            x = x - 4;


         //        loopcount++;
         //        counter++;
               
         //    }

         //if (x != _mdbCheck.Count - 1)
         //{
         //    x++;
         //    loopcount = 0;
         //    goto fourOuts;

         //}  
            
                 
             
            //
         //if (counter < _mdbCheck.Count)
         //{
         
         //    counter++;
         //    x = 4;
         //    loopcount = 0;
         //    goto fourOuts;
         //}






            //if (x != _mdbCheck.Count - 1)
            //{

            //    goto fourOuts;
            //}
            //}

                    
            //    }// end for 50 outs


          
                //}

          
                return _mdbCheck;
        }// end of function

        private void InsertDataToMDB()
        {

        }

        public void DeleteMDB()
        {
            string path = Application.StartupPath + "\\MC.mdb";
          if(File.Exists(path))
              File.Delete(path);
        }// end of function

        public void MDBCreate()
        {
            string DBPath;
            DBPath = "C:\\Users\\CaptiveIT1\\Documents\\Temp\\MC.mdb";

            // create DB via ADOX if not exists
            if (!System.IO.File.Exists(DBPath))
            {

                //DeleteMDB();
                //if (System.IO.File.Exists(DBPath + "\\MC.mdb"))
                    //System.IO.File.Delete(DBPath + "\\MC.mdb");
                    ADOX.Catalog cat = new ADOX.Catalog();

                cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBPath );
                //cat = null;

            }
        } // end of function

        public List<CheckModel> GetBatchFile(List<CheckModel> check) //Checking if the batch is already exists
        {
            DBConnect();
            
            MySqlCommand myCommand = new MySqlCommand("SELECT Distinct( Batch) FROM captive_database.master_database_islabank_archive", myConnect);

            MySqlDataReader myReader = myCommand.ExecuteReader();

           // List<CheckModel> check = new List<CheckModel>();

            while (myReader.Read())
            {
                CheckModel refe = new CheckModel
                {
                    
                    Batchfile = myReader.GetString(0)
                };

                check.Add(refe);
            }

            DBClosed();

            return check;
        }
  
        public List<MySQLLocatorModel> GetMySQLLocations()
        {
            MySqlConnection connect = new MySqlConnection("datasource=192.168.0.254 ;port=3306;username=root;password=CorpCaptive");

            connect.Open();

            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM captive_database.mysqldump_location", connect);

            MySqlDataReader myReader = myCommand.ExecuteReader();

            List<MySQLLocatorModel> sqlLocator = new List<MySQLLocatorModel>();

            while (myReader.Read())
            {
                MySQLLocatorModel myLocator = new MySQLLocatorModel
                {
                    PrimaryKey = myReader.GetInt32(0),
                    Location = myReader.GetString(1)
                };

                sqlLocator.Add(myLocator);
            }

            connect.Close();

            return sqlLocator;
        }
        public void DumpMySQL()
        {
            string dbname = "isla_branches";
            string outputFolder = @"K:\Auto\IslaBank\Test\Output";
            Process proc = new Process();

            proc.StartInfo.FileName = "cmd.exe";

            proc.StartInfo.UseShellExecute = false;

            proc.StartInfo.WorkingDirectory = GetMySqlPath().ToUpper().Replace("MYSQLDUMP.EXE", "");

            proc.StartInfo.RedirectStandardInput = true;

            proc.StartInfo.RedirectStandardOutput = true;

            proc.Start();

            StreamWriter myStreamWriter = proc.StandardInput;

            string temp = "mysqldump.exe --user=root --password=CorpCaptive --host=192.168.0.254 captive_database " + dbname + " > " +
                outputFolder + "\\" + DateTime.Today.ToShortDateString().Replace("/", ".") + "-" + dbname + ".SQL";

            myStreamWriter.WriteLine(temp);

            dbname = "isla_ref";

            temp = "mysqldump.exe --user=root --password=password=CorpCaptive --host=192.168.0.254 captive_database " + dbname + " > " +
                 outputFolder + "\\" + DateTime.Today.ToShortDateString().Replace("/", ".") + "-" + dbname + ".SQL";

            myStreamWriter.WriteLine(temp);

            myStreamWriter.Close();

            proc.WaitForExit();

            proc.Close();
        }
        public string GetMySqlPath()
        {
            var mySQLocator = GetMySQLLocations();

            foreach (var loc in mySQLocator)
            {
                if (File.Exists(loc.Location))
                    return loc.Location;
            }

            return "";
        }
    } 
}

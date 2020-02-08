using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IslaBank2019.Services;
using IslaBank2019.Model;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;


namespace IslaBank2019
{
    public partial class frmMain : Form
    {
       //public Users user;
     public frmLogIn loginForm = new frmLogIn();
       DatabaseConnectionsServices dbconnection = new DatabaseConnectionsServices();
        CheckModel _checkModel = new CheckModel();
     //   List<CheckModel> check = new List<CheckModel>();  
       public string _Brstn;
       public string _ChkType;
       public string _batchfile = "";
       public string processBy = "";
        public int  qty ;
        public int bookperpcs = 0;
        public string fileName;
       public DateTime dateTime;
      public DateTime deliveryDate;
        RefModel refMode = new RefModel();
        public frmMain()
        {
            InitializeComponent();

            dateTime =  dateTimePicker1.MinDate = DateTime.Now; //Disable selection of backdated dates to prevent errors        

        }
        
        private void cmbChkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextChangeChequeName();
        }
        private void ChequeName()
        {
 
            DataTable dataSet = new DataTable();
            DatabaseConnectionsServices dbconnection = new DatabaseConnectionsServices();
            dbconnection.GETChequeName(dataSet);
            foreach (DataRow row in dataSet.Rows)
            {
                cmbChkType.Items.Add(row[0]);
            }
        }
        private void TextChangeChequeName() 
        {
            cmbChkType.Focus();
            if (cmbChkType.Text == "PERSONAL" || cmbChkType.Text == "MANAGER'S CHECK" || cmbChkType.Text == "MANAGER'S CHECK CONTINUES" || cmbChkType.Text == "SELF RESPONDING TICKET" || cmbChkType.Text == "TIME DEPOSIT")
            {
                lblPcsperbook.Text = "50 Pcs. / Bkt";
                bookperpcs = 50;
            }
            else if (cmbChkType.Text == "COMMERCIAL")
            {
                lblPcsperbook.Text = "100 Pcs. / Bkt";
                bookperpcs = 100;
            }
            if (cmbChkType.Text == "SELF RESPONDING TICKET" || cmbChkType.Text == "TIME DEPOSIT")
            {
                txtAccountNumber.Text = "00000000000";
                txtAccountName1.Enabled = false;
                txtAccountName2.Enabled = false;
                txtAccountNumber.Enabled = false;
                cmbBranch.Enabled = false;
                cmbBranch.Text = "BACOLOD BRANCH";

            }
            else
            {
                txtAccountNumber.Enabled = true;
                txtAccountName2.Enabled = true;
                txtAccountName1.Enabled = true;
                cmbBranch.Enabled = true;
                //cmbBranch.Text = "";
                //txtAccountNumber.Text = string.Empty;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           // DatabaseConnectionsServices dbconnection = new DatabaseConnectionsServices();
          //  dbconnection.CreateMDB("MC");
            Color color = System.Drawing.ColorTranslator.FromHtml("#2C6E62");
            //   Color result = Color.FromArgb(color.R, color.G, color.B);
            this.BackColor = color;
            cmbBranch.Text = "BACOLOD BRANCH";
            cmbChkType.Text = "PERSONAL";
            txtAccountNumber.MaxLength = 11;
            txtAccountName1.MaxLength = 50;
            txtAccountName2.MaxLength = 50;
          //  txtAccountName1.Text = frmLogIn._userName;
            lblUsername.Text = frmLogIn._userName;
            ChequeName();
            BranchLoad();
            CheckLoadData();
            
            //var databinding = new BindingSource();
            //databinding.DataSource =  CheckLoadData();
          
           // dvgDatalist.DataBindings = CheckLoadData();
         
        }
        private void CheckLoadData()
        {
            DataTable dt = new DataTable();
            DatabaseConnectionsServices dbconnection = new DatabaseConnectionsServices();
            dbconnection.LoadDataToGridView(dt);
            dvgDatalist.DataSource = dt;

        }
        
        private void BranchLoad() // loading all the branches in Combobox
        {
            DatabaseConnectionsServices connection = new DatabaseConnectionsServices();
            DataTable dataSet = new DataTable();
            connection.GetBranch(dataSet);
            foreach (DataRow row in dataSet.Rows)
            {
                cmbBranch.Items.Add(row[0]);
            }

        }// end of function

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseConnectionsServices dbconnection = new DatabaseConnectionsServices();
             if (deliveryDate == dateTime)
            {
                MessageBox.Show("Please set the delivery date!!!");
            }
             else
             {
            DialogResult result1 =  MessageBox.Show("", "Do you to saved this record?", MessageBoxButtons.YesNo);
            BranchesModel branch = new BranchesModel();
           
           
                if (result1.ToString() == "Yes")
                {


                    CheckBRSTNandChkType();
                    qty = int.Parse(txtOrQty.Text);

                    _checkModel.AccountNo = txtAccountNumber.Text;
                    _checkModel.Address1 = cmbBranch.Text;
                    _checkModel.ChkType = _ChkType;
                    if (_checkModel.ChkType == "MC")
                        _checkModel.ChkTypeName = "MANAGERS CHECK";
                    else if (_checkModel.ChkType == "MC_CONT")
                        _checkModel.ChkTypeName = "MANAGERS CHECK CONTINUES";
                    else
                        _checkModel.ChkTypeName = cmbChkType.Text;

                    _checkModel.Name1 = txtAccountName1.Text;
                    _checkModel.Name2 = txtAccountName2.Text;

                    _checkModel.BRSTN = _Brstn;

                    _checkModel.BranchName = cmbBranch.Text;
                    _checkModel.Address1 = cmbBranch.Text;
                    dbconnection.GetBranchesDetails(branch, _checkModel.BRSTN);
                    if (branch != null)
                    {

                        _checkModel.Address2 = branch.Address2.ToString();
                        _checkModel.Address3 = branch.Address3.ToString();
                        _checkModel.Address4 = branch.Address4.ToString();
                        _checkModel.Address5 = branch.Address5.ToString();
                        _checkModel.Address6 = branch.Address6.ToString();

                    }

                    _checkModel.Qty = qty;

                    deliveryDate = dateTimePicker1.Value;
                    _checkModel.DeliveryDate = deliveryDate;
                    if (_checkModel != null)
                    {
                        for (int i = 0; i < qty; i++)
                        {

                            dbconnection.GetLastNO(refMode, _checkModel.ChkType, _checkModel.BRSTN);


                            Int64 s = refMode.LastNo + 1;
                            string lastNo = refMode.LastNo.ToString();

                            int endRefno = int.Parse(lastNo);

                            _checkModel.StartSeries = s.ToString();

                            if (_checkModel.ChkType == "A" || _checkModel.ChkType == "MC" || _checkModel.ChkType == "MC_CONT" || _checkModel.ChkType == "SR" || _checkModel.ChkType == "TD")
                            {
                                endRefno = endRefno + bookperpcs;
                            }
                            else if (_checkModel.ChkType == "B")
                            {
                                endRefno = endRefno + bookperpcs;
                            }

                            _checkModel.EndSeries = endRefno.ToString();
                            refMode.Date = dateTime;
                            refMode.LastNo = endRefno;

                            dbconnection.SaveToSecondaryTable(_checkModel);
                           // dbconnection.UpdateRef(refMode);


                            string _brstn = _checkModel.BRSTN.ToString();
                            string _chktype = _checkModel.ChkType.ToString();



                        }

                        MessageBox.Show("Data has been Saved!");

                        dbconnection.UpdateRef(refMode);

                        CheckLoadData();

                    }



                 //   MessageBox.Show(_checkModel.DeliveryDate.ToString() + dateTime.ToString());
                    ClearAllInputText();
                }
                else
                    MessageBox.Show("Saving Cancelled!!!!");
            }
        }

        private void CheckBRSTNandChkType()
        {
            if (cmbChkType.Text == "PERSONAL")
                _ChkType = "A";
            else if (cmbChkType.Text == "COMMERCIAL")
                _ChkType = "B";
            else if (cmbChkType.Text == "MANAGER'S CHECK" || cmbChkType.Text == "MANAGERS CHECK")
                _ChkType = "MC";
            else if (cmbChkType.Text == "MANAGER'S CHECK CONTINUES" || cmbChkType.Text == "MANAGERS CHECK CONTINUES")
                _ChkType = "MC_CONT";
            else if (cmbChkType.Text == "SELF RESPONDING TICKET")
                _ChkType = "SR";
            else if (cmbChkType.Text == "TIME DEPOSIT")
                _ChkType = "TD";

            if (cmbBranch.Text == "BACOLOD BRANCH")
                _Brstn = "040950013";
             if (cmbBranch.Text == "ILOILO BRANCH")
                _Brstn = "080950015";
             if (cmbBranch.Text == "HEAD OFFICE - GLASS TOWER BRANCH")
                _Brstn = "010950014";
        }

        private void ClearAllInputText()
        {
            cmbBranch.Text = "";
            cmbChkType.Text = "";
            txtAccountName1.Text = "";
            txtAccountName2.Text = "";
            txtAccountNumber.Text = "";
            txtOrQty.Text = "";
            _ChkType = "";
            _Brstn = "";
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            DatabaseConnectionsServices dbconnection = new DatabaseConnectionsServices();
            _batchfile = DateTime.Today.ToString("MMddyyyy");
            fileName = "ISL" + _batchfile.Substring(0, 4) + "P";
         
           
                
                DialogResult result1 = MessageBox.Show("Are you sure to continue the process?", "", MessageBoxButtons.YesNo);

                if (result1.ToString() == "Yes")
                {
                isExist:
                    ChecOutputServices.InputBox("", "Batch Number :", ref _batchfile);
                   





                    List<CheckModel> bcheck = new List<CheckModel>();
                    // checking if the bacth file does exists! 
                    dbconnection.GetBatchFile(bcheck);
                    if (bcheck != null)
                    {
                        for (int b = 0; b < bcheck.Count; b++)
                        {

                            if (bcheck[b].Batchfile == _batchfile)
                            {


                                MessageBox.Show("Batch is already exists!!!!!");
                                goto isExist;
                            }

                        }

                        CheckProcess();
                    }
                    else
                    {
                        CheckProcess();

                    }
                }
                else
                    MessageBox.Show("Process Cancelled");
                //}
                //catch (Exception ee)
                //{
                //    MessageBox.Show(ee.Message);
                //}
            //}         
        }

        private void txtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void cmbChkType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtOrQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAccountName1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtAccountName1_TextChanged(object sender, EventArgs e)
        {
            txtAccountName1.CharacterCasing = CharacterCasing.Upper;
            //txtAccountName1.Text = txtAccountName1.Text.ToUpper();
        }

        private void txtAccountName2_TextChanged(object sender, EventArgs e)
        {
            txtAccountName2.CharacterCasing = CharacterCasing.Upper;
            //txtAccountName2.Text = txtAccountName2.Text.ToUpper();
        }

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {
            List<CheckModel> Acheck = new List<CheckModel>();
            DatabaseConnectionsServices dbconnection = new DatabaseConnectionsServices();
           // var listofchecksAccount = Acheck.Select(a => a.AccountNo).ToList();
            if (txtAccountNumber.Text.Length == 12)
            {
                dbconnection.GetNameifExisting(Acheck);
                
                for (int i = 0; i < Acheck.Count; i++)
                {
                    if (txtAccountNumber.Text == Acheck[i].AccountNo)
                    {
                        CheckBRSTNandChkType();
                        txtAccountName1.Text = Acheck[i].Name1.ToString();
                        txtAccountName2.Text = Acheck[i].Name2.ToString();
                        cmbBranch.Text = Acheck[i].Address1.ToString();
                        cmbChkType.Text = Acheck[i].ChkTypeName.ToString();

                    }
                }
                //foreach (string acc in listofchecks)
                //{
                //    var acc2 = check.Where(b => b.AccountNo == txtAccountNumber.Text).ToList();
                //    foreach (var chk in acc2)
                //    {

                //        txtAccountName1.Text = chk.Name1.ToString();
                //        txtAccountName2.Text = chk.Name2.ToString();
                //    }

                //}
            }       
        }
        private void CheckProcess()
        {

            CheckServices checks = new CheckServices();
            ProcessPackingText packing = new ProcessPackingText();
          //  checks.DeletePrinterAndTextFile();
           // checks.DeleteTextFile();
            List<CheckModel> pL = new List<CheckModel>();
            List<CheckModel> docheck = new List<CheckModel>();
            List<CheckModel> pcheck = new List<CheckModel>();
            List<CheckModel> dbfcheck = new List<CheckModel>();
            List<CheckModel> mdbcheck = new List<CheckModel>();
            List<CheckModel> zipchek = new List<CheckModel>();
            ZipFileServices z = new ZipFileServices();
            packing.PackingText(pL, this);
            checks.ProcessCheck(docheck, this);
            checks.PrinterFile(pcheck, this);
            checks.SaveToPackingDBF(dbfcheck, _batchfile, this);
            for (int i = 0; i < docheck.Count; i++)
            {

                if (docheck[i].ChkType == "MC" || docheck[i].ChkType == "MC_CONT")
                {
                    //dbconnection.MDBCreate();
                    dbconnection.DeleteMDB();
                    dbconnection.CreateTable(_batchfile);
                }   
                dbconnection.SavedDatatoDatabase(docheck[i], _batchfile);

            }
            if (_checkModel.ChkType == "MC" || _checkModel.ChkType == "MC_CONT")
            {
                checks.Insert4Outs(mdbcheck, this);
            }
           
            dbconnection.DumpMySQL();
            //   ZipFileServices.CopyPrinterFile(checktype, _mainForm);
            z.ZipFileS(frmLogIn._userName);
           
            //dbconnection.Backup();
            MessageBox.Show("Process Done!!!");
           
            dbconnection.DeleteTempData();
            Environment.Exit(0);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            deliveryDate = dateTimePicker1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

     
    }
}

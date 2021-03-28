using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMEI_CALCULATOR
{
    public partial class ImeiCal : MetroSet_UI.Forms.MetroSetForm
    {
        public ImeiCal()
        {
            InitializeComponent();
            this.MinimumSize = new Size(402, 255);//minsize
            this.MaximumSize = new Size(402, 255);//max size
        }

        

      
     
      

        private void ImeiCal_Load(object sender, EventArgs e)
        {
        

        }

       
       

        private void TxtImei_Click(object sender, EventArgs e)
        {
           
        }
       
    
        static int sumDig(int n)//https://github.com/CoderPARADOX?tab=repositories
        {
            int a = 0;
            while (n > 0)
            {
                a = a + n % 10;
                n = n / 10;
            }

            return a;
            //S. Thanks to Umut. H 
        }

        static int isValidIMEI(long n)
        {

            String s = n.ToString();
            int len = s.Length;

            int sum = 0;
            for (int i = len; i >= 1; i--)
            {
                int d = (int)(n % 10);

                if (i % 2 == 0)
                    d = 2 * d;

                sum += sumDig(d);
                n = n / 10;
            }
            if (sum % 10 == 0)
                return 0;
            else
                return (10 - (sum % 10));
        }

        private void TxtImei_TextChanged(object sender, EventArgs e)//https://github.com/CoderPARADOX?tab=repositories
        {
          LblTxtCount.Text ="IMEI Lenght : "+  TxtImei.Text.Length.ToString();
            try
            {

                
               
                if (TxtImei.Text != "" &&TxtImei.Text.Length == 14)
                {
                    long CalcImei = Convert.ToInt64(TxtImei.Text);
                    int LastNumb = isValidIMEI(CalcImei);
                    TxtImeiOut.Text = LastNumb.ToString();
                    LblWarn.Visible = false;
                  
                }
                else
                {
                    LblWarn.Visible = true;
                    LblWarn.Text = "Unable Character or empty!";
                }

            }
            catch (Exception)
            {
                LblWarn.Visible = true;
                LblWarn.Text = "Unable Character or empty!";
                TxtImeiOut.Text = "0";
               // MessageBox.Show("IMEI CANNOT BE EMPTY or letter", "[WARN]", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            if (TxtImei.Text == "")
            {
                TxtImeiOut.Text = "0";
            }
        }

        private void TxtImei_MouseDown(object sender, MouseEventArgs e)
        {
            TxtImei.Text = string.Empty;
        }
    }
}

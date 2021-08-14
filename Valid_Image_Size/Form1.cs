using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valid_Image_Size
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
        }

        private bool ValidImage(string filename)
        {
            try
            {
                Image img = Image.FromFile(filename);
                return true;
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //    Dim dlgImage As OpenFileDialog = New OpenFileDialog()

            OpenFileDialog dlgImage = new OpenFileDialog();
            dlgImage.Title = "Select images";
            dlgImage.Filter = "Images types (*.jpg;*.png;*.gif;*.bmp) | *.jpg;*.png;*.gif;*.bmp";
            dlgImage.FilterIndex = 1;
            dlgImage.RestoreDirectory = true;

            //Select OK after Browse ...

            if (dlgImage.ShowDialog() == DialogResult.OK)
            {
                // check it is a picture or not
                if (!ValidImage(dlgImage.FileName))
                {
                    MessageBox.Show("The file you selected is not an image file.", "Report Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                // Get file size.
                FileInfo info = new FileInfo(dlgImage.FileName);
                label1.Text = $"File Size : {Convert.ToDecimal(info.Length / 1024).ToString("#,##0.00")} KB.";

                var img = Image.FromFile(dlgImage.FileName);
                label2.Text = $"Width x Height : {Convert.ToDecimal(img.Width.ToString("#,##0"))} x {Convert.ToDecimal(img.Height.ToString("#,##0"))} Pixels...";

                picData.Image = Image.FromFile(dlgImage.FileName);
            }

            //    '/ Get file size.
            //    Dim info As New System.IO.FileInfo(dlgImage.FileName)
            //    Label1.Text = "File Size: " & Format(info.Length / 1024, "#,##0.00") & " KB."
            //    '/ Get the scale.
            //    Dim img = Image.FromFile(dlgImage.FileName)
            //    Label2.Text = "Width x Height : " & (Format(Val(img.Width.ToString), "#,##0") & " x " & Format(Val(img.Height.ToString), "#,##0")) & " Pixels."
            //    '/
            //    picData.Image = Image.FromFile(dlgImage.FileName)
            //End If
        }
    }
}
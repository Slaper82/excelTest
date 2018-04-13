using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReaderTest
{

    public partial class Main : Form
    {
        List<string> Headers;
        List<Emission> Emisions;
        Dictionary<string, int> HeaderDict;
        public string Path { get; set; }
        public Main()
        {
            InitializeComponent();
            Headers = new List<string>();
            Emisions = new List<Emission>();
            HeaderDict = new Dictionary<string, int>();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
          if (Path.Contains("xlsx"))
                {
                    ExcelReader exr = new ExcelReader(Path, "Arkusz1");

                    DataHandle dh = new DataHandle();
                    try
                    {
                        dh.Data = exr.GetData();

                        var d = dh.DataToCalculate(HeaderDict, Emisions);

                        dgvResult.DataSource = dh.Result(d);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Wystąpił problem z odczytem:{ex.Message}", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Podano ścieżkę do pliku z niewłaściwym formatem", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {

            DialogResult res = ofdChoose.ShowDialog();
            if (res == DialogResult.OK)
            {
                Path = ofdChoose.FileName;
                txtDest.Text = Path;
            }
        }
    }
}

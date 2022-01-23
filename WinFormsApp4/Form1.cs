using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        DataSet DS = new DataSet();
        public Form1()
        {
            InitializeComponent();
            CreateData();

        }

        private void CreateData()
        {
            string[,] data = new string[,] { { "RHOAMRI", "TARIQ" }, { "KASSEMI", "AYOUB" }, { "MELLOUL", "MOSSAAB" } };
            DataTable DT = new DataTable();
            DT.Columns.Add("nom", typeof(string));
            DT.Columns.Add("prenom", typeof(string));


            for (int i = 0; i < data.Length / 2; i++)
            {
                DataRow DR = DT.NewRow();
                DR["nom"] = data[i, 0];
                DR["prenom"] = data[i, 1];

                DT.Rows.Add(DR);
            }
            DS.Tables.Add(DT);
            dataGridView1.DataSource = DT;
            DataGridViewButtonColumn editbutton = new DataGridViewButtonColumn();
            editbutton.Name = "Edit";
            editbutton.HeaderText = "Edit";
            editbutton.Text = "Edit";
            editbutton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(2, editbutton);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {

                MessageBox.Show("You Clicked Row " + e.RowIndex.ToString());
                DataGridViewButtonCell btn = (DataGridViewButtonCell)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                btn.UseColumnTextForButtonValue = false;
                btn.Value = "Updated";
                            
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

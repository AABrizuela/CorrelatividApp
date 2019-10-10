using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorrelatividApp.Entidades;

namespace CorrelatividApp.Forms
{
    public partial class CorrelatividApp : Form
    {
        public StringBuilder strBld = new StringBuilder();
        public Curricula curricula = new Curricula(5);
        private Materia materia;

        public CorrelatividApp()
        {
            InitializeComponent();

            this.cmbCuatrimestre.Items.Add(ECuatrimestre.PrimerCuatrimestre);
            this.cmbCuatrimestre.Items.Add(ECuatrimestre.SegundoCuatrimestre);
            this.cmbCuatrimestre.Items.Add(ECuatrimestre.TercerCuatrimestre);
            this.cmbCuatrimestre.Items.Add(ECuatrimestre.CuartoCuatrimestre);
            this.cmbCuatrimestre.Items.Add(ECuatrimestre.QuintoCuatrimestre);
            this.cmbCuatrimestre.Items.Add(ECuatrimestre.SextoCuatrimestre);
            
            this.cmbCuatrimestre.SelectedItem = ECuatrimestre.PrimerCuatrimestre;

            this.rdbCursada1.Enabled = false;
            this.rdbCursada2.Enabled = false;
            this.rdbCursada3.Enabled = false;
            this.rdbCursada4.Enabled = false;
            this.rdbCursada5.Enabled = false;
            this.rdbAprobada1.Enabled = false;
            this.rdbAprobada2.Enabled = false;
            this.rdbAprobada3.Enabled = false;
            this.rdbAprobada4.Enabled = false;
            this.rdbAprobada5.Enabled = false;

            this.rdbCursada1.Checked = true;
            this.rdbCursada2.Checked = true;
            this.rdbCursada3.Checked = true;
            this.rdbCursada4.Checked = true;
            this.rdbCursada5.Checked = true;

            //Curricula curricula = new Curricula(5);

            strBld.AppendLine("Puede cursar:");
            lstMaterias.Items.Add(strBld);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkMateria1_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarRdb(chkMateria1, rdbCursada1, rdbAprobada1);
        }        

        private void chkMateria2_CheckedChanged(object sender, EventArgs e)
        {
            bool aux = HabilitarRdb(chkMateria2, rdbCursada2, rdbAprobada2);
            
            Materia spd = new Materia(chkMateria1.Text, "95-1122", rdbCursada2.Text);

            

            if (spd.estado == "Cursada" && aux == true)
            {
                /*strBld.AppendLine("Sistemas Operativos");                

                lstMaterias.Items.Add(strBld.ToString());*/

                curricula += spd;
                lstMaterias.Items.Add(curricula);
            }
            else
            {
                curricula -= spd;
                lstMaterias.Items.Clear();
                lstMaterias.Items.Add(curricula);
                /*int indexOf = lstMaterias.Items.IndexOf(strBld);                
                lstMaterias.Items.RemoveAt(indexOf);
                lstMaterias.Items.Clear();
                lstMaterias.Items.Add();*/
            }
        }

        private void chkMateria3_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarRdb(chkMateria3, rdbCursada3, rdbAprobada3);
        }

        private void chkMateria4_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarRdb(chkMateria4, rdbCursada4, rdbAprobada4);

        }

        private void chkMateria5_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarRdb(chkMateria5, rdbCursada5, rdbAprobada5);

        }

        #region Propiedades
        public Materia GetMateria { get => this.materia; }  
        #endregion

        #region Metodos
        /// <summary>
        /// Habilita los radioButtons correspondiende a cada materia cuando el checkBox correspondiente
        /// esta en el estado Checked
        /// </summary>
        /// <param name="checkBox"></param>
        /// <param name="radioButton1"></param>
        /// <param name="radioButton2"></param>
        /// <returns></returns>
        private bool HabilitarRdb(CheckBox checkBox, RadioButton radioButton1, RadioButton radioButton2)
        {
            if (checkBox.CheckState == CheckState.Checked)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                return true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                return false;
            }
        }
        #endregion
    }
}

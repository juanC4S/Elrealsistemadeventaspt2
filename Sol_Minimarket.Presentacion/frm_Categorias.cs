using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Negocio;

namespace Sol_Minimarket.Presentacion
{
    public partial class frm_Categorias : Form
    {
        public frm_Categorias()
        {
            InitializeComponent();
        }
        #region "Mis Métodos"
        private void Formarto_ca()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_CA";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "CATEGORIA";

        }
        private void Listado_ca(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource=N_Categorias.Listado_ca(cTexto);
                this.Formarto_ca();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void frm_Categorias_Load(object sender, EventArgs e)
        {
            this.Listado_ca("%");
        }
    }
}

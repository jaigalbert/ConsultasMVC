using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultasMVC.Controllers;

namespace ConsultasMVC.Views
{
    public partial class ProductView : Form
    {
        public ProductView()
        {
            InitializeComponent();
            ProductController control = new ProductController(this);            
        }

        private void gridBuscar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text=gridBuscar.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = gridBuscar.Rows[e.RowIndex].Cells[1].Value.ToString(); ;
            txtDescripcion.Text = gridBuscar.Rows[e.RowIndex].Cells[3].Value.ToString(); ;
            txtPrecio.Text = gridBuscar.Rows[e.RowIndex].Cells[2].Value.ToString();
            MessageBox.Show(txtNombre.Text+"\n\n\n Descripcion: "+txtDescripcion.Text+"\n\n\nPrecio: "+txtPrecio.Text+ "\n\n\n IVA: " + (Convert.ToDouble(txtPrecio.Text)*.16).ToString()+ "\n\n\n Total: " + (Convert.ToDouble(txtPrecio.Text)*1.16).ToString());
        }
    }
}

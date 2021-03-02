using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasMVC.Models.Dto;
using ConsultasMVC.Models.Dao;
using ConsultasMVC.Views;
using System.Globalization;
using System.Windows.Forms;

namespace ConsultasMVC.Controllers
{
    class ProductController
    {
        ProductView Vista;
        public ProductController(ProductView View) {
            Vista = View;
            Vista.Load += new EventHandler(ProductList);
            ClienteDao db = new ClienteDao();
            Vista.gridBuscar.DataSource = db.VerRegistros(Vista.txtBuscar.Text);
            Vista.btnBuscar.Click += new EventHandler(ProductList);
            //Vista.txtBuscar.TextChanged += new EventHandler(ProductList);
            Vista.btnInsertar.Click += new EventHandler(ProductInsert);
            Vista.btnActualizar.Click += new EventHandler(ProductUpdate);
            Vista.btnEliminar.Click += new EventHandler(ProductDelete);
        }
        public void ProductList(object sender,EventArgs e) {
            ClienteDao db = new ClienteDao();
            Vista.gridBuscar.DataSource =
                db.VerRegistros(Vista.txtBuscar.Text);
        }

        public void ProductInsert(object sender, EventArgs e)
        {
            ClienteDao db = new ClienteDao();
            db.Insert(Vista.txtNombre.Text, Vista.txtDescripcion.Text, Convert.ToDouble(Vista.txtPrecio.Text));
            MessageBox.Show("Se ha insertado un producto");
        }

        public void ProductUpdate(object sender, EventArgs e)
        {
            ClienteDao db = new ClienteDao();
            db.Update(Convert.ToInt32(Vista.txtID.Text),Vista.txtNombre.Text, Vista.txtDescripcion.Text, Convert.ToDouble(Vista.txtPrecio.Text));
            MessageBox.Show("Se ha actualizado un producto");
        }

        public void ProductDelete(object sender, EventArgs e)
        {
            ClienteDao db = new ClienteDao();
            db.Delete(Convert.ToInt32(Vista.txtID.Text));
            MessageBox.Show("Se ha eliminado un producto");
        }



    }
}

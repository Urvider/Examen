using Examen.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class frmInventario : Form
    {
        public int id = 0;
        public frmInventario()
        {
            InitializeComponent();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            ModificarProducto();
            TodosProductos();
            LimpiarCampos();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarProducto();
            TodosProductos();
            LimpiarCampos();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();
            TodosProductos();
            LimpiarCampos();
        }

        private void btRegresar_Click(object sender, EventArgs e)
        {
            frmPrincipal ob = new frmPrincipal();
            ob.Show();
            this.Hide();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value.ToString());
            txtNombre.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtMarca.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            txtPrecCompra.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
            txtPrecVenta.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            TodosProductos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtCantidad.Text = "";
            txtPrecCompra.Text = "";
            txtPrecVenta.Text = "";
        }
        private void TodosProductos()
        {
            using (var context = new AplicationDbContext())
            {
                var producto = context.Productos.ToList();
                dgvProductos.DataSource = producto;
            }
        }
        private void BuscarProducto()
        {
            using (var contex = new AplicationDbContext())
            {
                var producto = contex.Productos.Where(x => x.Nombre.Contains(txtBuscar.Text)).ToList();
                dgvProductos.DataSource = producto;
            }
        }
        private void RegistrarProducto()
        {
            using (var context = new AplicationDbContext())
            {
                var producto = new Productos();
                producto.Nombre = txtNombre.Text;
                producto.Marca = txtMarca.Text;
                producto.Cantidad = int.Parse(txtCantidad.Text);
                producto.PrecioCompra = double.Parse(txtPrecCompra.Text);
                producto.PrecioVenta = double.Parse(txtPrecVenta.Text);

                context.Productos.Add(producto);
                context.SaveChanges();
            }
        }
        private void ModificarProducto()
        {

            using (var context = new AplicationDbContext())
            {
                if (id != 0)
                {
                    var producto = context.Productos.First(x => x.Id == id);
                    if (producto != null)
                    {
                        producto.Nombre = txtNombre.Text;
                        producto.Marca = txtMarca.Text;
                        producto.Cantidad = int.Parse(txtCantidad.Text);
                        producto.PrecioCompra = double.Parse(txtPrecCompra.Text);
                        producto.PrecioVenta = double.Parse(txtPrecVenta.Text);
                        
                        context.SaveChanges();
                    }
                }
                
            }
        }
        private void EliminarProducto()
        {
            using (var context = new AplicationDbContext())
            {
                if (id != 0)
                {
                    var producto = context.Productos.First(x => x.Id == id);
                    if (producto != null)
                    {
                        context.Remove(producto);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}

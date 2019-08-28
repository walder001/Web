using BLL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.App
{
    public partial class ProductoWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoId.Text = "0";

        }
        void Limpiar()
        {
            ProductoId.Text = "0";
            ProveedorId.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            GananciaTextBox.Text = string.Empty;
            DescuentoTextBox.Text = string.Empty;


        }
        private Productos LLenaClase()
        {
            Productos productos = new Productos();
            productos.ProductoId = Convert.ToInt32(ProductoId.Text);
            productos.ProveedorId = Convert.ToInt32(ProveedorId.Text);
            productos.Descripcion = DescripcionTextBox.Text;
            productos.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            productos.Costo = Convert.ToInt32(CostoTextBox.Text);
            productos.Precio = Convert.ToInt32(PrecioTextBox.Text);
            productos.Ganancia = Convert.ToInt32(GananciaTextBox.Text);
            productos.DescuentoProducto = Convert.ToInt32(DescuentoTextBox.Text);



            return productos;
        }
        public bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(ProveedorId.Text) || string.IsNullOrWhiteSpace(DescripcionTextBox.Text) || string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }

            return paso;
        }
        public bool Existe()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
            Productos usuarios = repositorio.Buscar(Convert.ToInt32(ProductoId.Text));
            return (usuarios != null);
        }

        public void LLenaCampo(Productos productos)
        {
            ProductoId.Text = productos.ProductoId.ToString();
            ProveedorId.Text = productos.ProveedorId.ToString();
            DescripcionTextBox.Text = productos.Descripcion;
            CantidadTextBox.Text = productos.Cantidad.ToString();
            CostoTextBox.Text = productos.Costo.ToString();
            PrecioTextBox.Text = productos.Precio.ToString();
            GananciaTextBox.Text = productos.Ganancia.ToString();
            DescuentoTextBox.Text = productos.DescuentoProducto.ToString();

        }


        protected void Guardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
            bool paso = false;
            Productos productos = new Productos();

            productos = LLenaClase();

            if (productos.ProductoId == 0)
            {
                paso = repositorio.Guardar(productos);
            }
            else
            {
                if (!Existe())
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = repositorio.Modificar(productos);
                Limpiar();
            }
            if (paso)
            {
                Limpiar();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Error", true);
                return;
            }

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
            int idx;
            int.TryParse(ProductoId.Text, out idx);

            var productos = repositorio.Buscar(idx);
            if (productos != null)
            {
                if (repositorio.Eliminar(idx))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Exito()", true);
                    Limpiar();
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);


        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>(new Contexto());
            Productos productos = new Productos();
            int.TryParse(ProductoId.Text, out int idx);

            productos = Repositorio.Buscar(idx);
            if (productos != null)
                LLenaCampo(productos);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);

        }
    }
}
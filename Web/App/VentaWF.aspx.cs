using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.App
{
    public partial class VentaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       /*
        public List<VentasDetalle> Detalle;
        public Ventas v = new Ventas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Producto();
                Cliente();
                productos.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                productos.SelectedIndex = 0;
                ViewState["Ventas"] = new Ventas();
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            Grid.DataSource = ((Ventas)ViewState["Ventas"]).Detalle;
            Grid.DataBind();
        }


        private void Producto()
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            var listado = new List<Productos>();
            listado = db.GetList(p => true);
            productos.DataSource = listado;
            productos.DataValueField = "ProductoId";
            productos.DataTextField = "Producto";
            productos.DataBind();
        }
        private void Cliente()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            var listado = new List<Clientes>();
            listado = db.GetList(p => true);
            cliente.DataSource = listado;
            cliente.DataValueField = "ClienteId";
            cliente.DataTextField = "Nombres";
            cliente.DataBind();
        }
        private void LlenaCampo(Ventas venta)
        {
            id.Text = Convert.ToString(venta.VentaId);
            cliente.SelectedValue = venta.Cliente;
            modo.SelectedValue = venta.Modo;
            itbis.Text = Convert.ToString(venta.Itbis);
            subtotal.Text = Convert.ToString(venta.Subtotal);
            total.Text = Convert.ToString(venta.Total);
            Grid.DataSource = venta.Detalle;
            Grid.DataBind();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Ventas> Repositorio = new RepositorioBase<Ventas>();
            Ventas usuarios = Repositorio.Buscar(Convert.ToInt32(id.Text));
            return (usuarios != null);
        }
        private Ventas LlenaClase()
        {
            Ventas v = new Ventas();
            v = (Ventas)ViewState["Ventas"];
            int.TryParse(id.Text, out int idx);
            v.VentaId = idx;
            v.Cliente = cliente.SelectedValue;
            v.Modo = modo.SelectedValue;
            v.Itbis = Convert.ToDecimal(itbis.Text);
            v.Subtotal = Convert.ToDecimal(subtotal.Text);
            v.Total = Convert.ToDecimal(total.Text);
            return v;
        }
        private void Limpiar()
        {
            id.Text = "0";
            precio.Text = string.Empty;
            cantidad.Text = string.Empty;
            precio.Text = string.Empty;
            itbis.Text = string.Empty;
            subtotal.Text = string.Empty;
            total.Text = string.Empty;
            this.BindGrid();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            if (productos.SelectedValue == null || precio.Text == "" || cantidad.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                return;
            }
            else
            {
                Ventas v = new Ventas();

                decimal imp = Convert.ToDecimal(precio.Text) * 0.18m;
                v = (Ventas)ViewState["Ventas"];

                int d = Convert.ToInt32(productos.SelectedValue);

                foreach (var item in v.Detalle)
                {
                    if (d == item.ProductoId)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                        return;
                    }
                }

                if (Convert.ToInt32(cantidad.Text) > Convert.ToInt32(cantidadDisponibles.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }

                v.Detalle.Add(new VentasDetalle(Convert.ToInt32(productos.SelectedValue),
                     Convert.ToInt32(cantidad.Text),
                     Convert.ToDecimal(precio.Text),
                     imp * Convert.ToInt32(cantidad.Text)
                     ));

                ViewState["Detalle"] = v.Detalle;
                this.BindGrid();
                Calculos();
            }
        }

        protected void productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productos.SelectedIndex == 0)
                precio.Text = "";
            else
            {
                int id = Convert.ToInt32(productos.SelectedValue);
                RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
                List<Productos> ListProductos = repositorio.GetList(c => c.ProductoId == id);

                foreach (var item in ListProductos)
                {
                    precio.Text = item.Precio.ToString();
                    cantidadDisponibles.Text = item.Cantidad.ToString();
                }
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ventas> Repositorio = new RepositorioBase<Ventas>();
            Ventas usuarios = new Ventas();
            int.TryParse(id.Text, out int idx);

            usuarios = Repositorio.Buscar(idx);
            if (usuarios != null)
                LlenaCampo(usuarios);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ventas> Repositorio = new RepositorioBase<Ventas>();
            int idx;
            int.TryParse(id.Text, out idx);

            var usuario = Repositorio.Buscar(idx);
            if (usuario != null)
            {
                if (VentaBLL.Eliminar(idx))
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
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(id.Text) || string.IsNullOrWhiteSpace(cliente.Text) || string.IsNullOrWhiteSpace(modo.Text) || productos.SelectedIndex == 0 || Grid.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }
            return paso;
        }
        protected void guardarButton_Click(object sender, EventArgs e)
        {
            Ventas usuarios = new Ventas();

            bool paso = false;
            if (!Validar())
                return;

            usuarios = LlenaClase();
            int.TryParse(id.Text, out int idx);
            if (idx == 0)
            {

                paso = VentaBLL.Guardar(usuarios);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = VentaBLL.Modificar(usuarios);
                Limpiar();
            }

            if (paso)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Exito()", true);
                return;
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
        }
        public void Calculos()
        {
            decimal totals = 0;
            decimal sub = 0;
            decimal imp = 0;
            List<VentasDetalle> lista = (List<VentasDetalle>)ViewState["Detalle"];
            foreach (var item in lista)
            {
                totals += (item.Precio * item.Cantidad) + item.Impuesto;
                sub += item.Precio * item.Cantidad;
                imp += item.Impuesto;
            }

            subtotal.Text = sub.ToString();
            itbis.Text = imp.ToString();
            total.Text = totals.ToString();
        }

        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = e.RowIndex;
            Ventas v = new Ventas();
            v = (Ventas)ViewState["Ventas"];
            v.Detalle.RemoveAt(id);

            ViewState["Detalle"] = v.Detalle;
            this.BindGrid();
            Calculos();
        }

        protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int.TryParse(id.Text, out int idx);

            if (idx > 0)
                e.Row.Cells[0].Visible = false;
        }*/
    }
}
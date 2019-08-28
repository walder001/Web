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
    public partial class ProveedorWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorId.Text = "0";

        }
        void Limpiar()
        {
            ProveedorId.Text = "0";
            NombreProveedorTextBox.Text = string.Empty;
            RncTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            RepresentanteTextBox.Text = string.Empty;
            ExtencionTextBox.Text = string.Empty;

        }
        private Proveedores LLenaClase()
        {
            Proveedores proveedores = new Proveedores();
            proveedores.ProveedorId = Convert.ToInt32(ProveedorId.Text);
            proveedores.NombreProveedor = NombreProveedorTextBox.Text;
            proveedores.RNC = RncTextBox.Text;
            proveedores.TelefonoProveedor = TelefonoTextBox.Text;
            proveedores.NombreRepresentante = RepresentanteTextBox.Text;
            proveedores.ExtencionRepresentante = Convert.ToInt32(ExtencionTextBox.Text);

          
            return proveedores;
        }
        public bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(ProveedorId.Text) || string.IsNullOrWhiteSpace(RepresentanteTextBox.Text) || string.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }

            return paso;
        }
        public bool Existe()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            Proveedores proveedores = repositorio.Buscar(Convert.ToInt32(ProveedorId.Text));
            return (proveedores != null);
        }

        public void LLenaCampo(Proveedores proveedores)
        {
            ProveedorId.Text = proveedores.ProveedorId.ToString();
            NombreProveedorTextBox.Text = proveedores.NombreProveedor;
            RncTextBox.Text = proveedores.RNC;
            TelefonoTextBox.Text = proveedores.TelefonoProveedor;
            NombreProveedorTextBox.Text = proveedores.NombreRepresentante;
            ExtencionTextBox.Text = proveedores.ExtencionRepresentante.ToString();


        }


        protected void Guardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            bool paso = false;
            Proveedores proveedores = new Proveedores();

            proveedores = LLenaClase();

            if (proveedores.ProveedorId == 0)
            {
                paso = repositorio.Guardar(proveedores);
            }
            else
            {
                if (!Existe())
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = repositorio.Modificar(proveedores);
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
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            int idx;
            int.TryParse(ProveedorId.Text, out idx);

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
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>(new Contexto());
            Proveedores proveedores = new Proveedores();
            int.TryParse(ProveedorId.Text, out int idx);

            proveedores = Repositorio.Buscar(idx);
            if (proveedores != null)
                LLenaCampo(proveedores);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);

        }
    }
}
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
    public partial class ClienteWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteId.Text = "0";
        }
        void Limpiar()
        {
            ClienteId.Text = "0";
            NombresTextBox.Text = string.Empty;
            DropDownList1.Text = null;
            DireccionTextBox.Text = string.Empty;
            NumeroCedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            FechaNacimientoDateTime.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
            

        }
        private Clientes LLenaClase()
        {
            Clientes clientes = new Clientes();
            clientes.ClienteId = Convert.ToInt32(ClienteId.Text);
            clientes.Nombres = NombresTextBox.Text;
            clientes.Sexo = DropDownList1.Text;
            clientes.Direccion = DireccionTextBox.Text;
            clientes.NumeroCedula = NumeroCedulaTextBox.Text;
            clientes.Telefono = TelefonoTextBox.Text;
            clientes.FechaNacimiento = Convert.ToDateTime(FechaNacimientoDateTime.Text);
            clientes.Email = EmailTextBox.Text;
            clientes.Balance = Convert.ToInt32(BalanceTextBox.Text);
            return clientes;
        }
        public bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(ClienteId.Text) || string.IsNullOrWhiteSpace(NombresTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }

            return paso;
        }
        public bool Existe()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>(new Contexto());
            Clientes clientes = repositorio.Buscar(Convert.ToInt32(ClienteId.Text));
            return (clientes != null);
        }

        public void LLenaCampo(Clientes clientes)
        {
            ClienteId.Text = clientes.ClienteId.ToString();
            NombresTextBox.Text = clientes.Nombres;
            DropDownList1.Text = clientes.Sexo;
            DireccionTextBox.Text = clientes.Direccion;
            NumeroCedulaTextBox.Text = clientes.NumeroCedula;
            TelefonoTextBox.Text = clientes.Telefono;
            FechaNacimientoDateTime.Text = Convert.ToString(clientes.FechaNacimiento);
            EmailTextBox.Text = clientes.Email;
            BalanceTextBox.Text = clientes.Balance.ToString();


        }


        protected void Guardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>(new Contexto());
            bool paso = false;
            Clientes clientes = new Clientes();

            clientes = LLenaClase();

            if (clientes.ClienteId == 0)
            {
                paso = repositorio.Guardar(clientes);
            }
            else
            {
                if (!Existe())
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = repositorio.Modificar(clientes);
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
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>(new Contexto());
            int idx;
            int.TryParse(ClienteId.Text, out idx);

            var clientes = repositorio.Buscar(idx);
            if (clientes != null)
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
            RepositorioBase<Clientes> Repositorio = new RepositorioBase<Clientes>(new Contexto());
            Clientes clientes = new Clientes();
            int.TryParse(ClienteId.Text, out int idx);

            clientes = Repositorio.Buscar(idx);
            if (clientes != null)
                LLenaCampo(clientes);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);

        }

    }
}
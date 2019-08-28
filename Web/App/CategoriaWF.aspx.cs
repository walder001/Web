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
    public partial class CategoriaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void Limpiar()
        {
            CategoriaId.Text = "0";
            NombreTextBox.Text = string.Empty;
          

        }
        private Categorias LLenaClase()
        {
            Categorias categorias = new Categorias();
            categorias.CategoriaId = Convert.ToInt32(CategoriaId.Text);
            categorias.NomnbreCategoria = NombreTextBox.Text;
           
            return categorias;
        }
        public bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(CategoriaId.Text) || string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }

            return paso;
        }
        public bool Existe()
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            Categorias categorias = repositorio.Buscar(Convert.ToInt32(CategoriaId.Text));
            return (categorias != null);
        }

        public void LLenaCampo(Categorias categorias)
        {
            CategoriaId.Text = categorias.CategoriaId.ToString();
            NombreTextBox.Text = categorias.NomnbreCategoria;
            
        }


        protected void Guardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            bool paso = false;
            Categorias categorias = new Categorias();

            categorias = LLenaClase();

            if (categorias.CategoriaId == 0)
            {
                paso = repositorio.Guardar(categorias);
            }
            else
            {
                if (!Existe())
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = repositorio.Modificar(categorias);
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
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            int idx;
            int.TryParse(CategoriaId.Text, out idx);

            var categorias = repositorio.Buscar(idx);
            if (categorias != null)
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
            RepositorioBase<Categorias> Repositorio = new RepositorioBase<Categorias>(new Contexto());
            Categorias categorias = new Categorias();
            int.TryParse(CategoriaId.Text, out int idx);

            categorias = Repositorio.Buscar(idx);
            if (categorias != null)
                LLenaCampo(categorias);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);

        }

    }
}
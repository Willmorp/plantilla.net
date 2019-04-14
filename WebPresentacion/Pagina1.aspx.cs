using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebEntidad;
using WebNegocio;


namespace WebPresentacion
{
    public partial class Pagina11 : System.Web.UI.Page
    {
        //instanciar variables generales
        EmpleadoDao obj = new EmpleadoDao();
        void listado()
        {
            grid1.DataSource = obj.ListadoCli();
            grid1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listado();
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Empleado ep = new Empleado();
            ep.nombre = txtNombre.Text;
            ep.horas = double.Parse(txthoras.Text);
            ep.tarifa = double.Parse(txttarifas.Text);
            obj.addEmployed(ep);
            listado();
        }
    }
}
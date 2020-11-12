using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;

namespace BrewingCreators
{
    public partial class ListaVentas : Form
    {
        public ListaVentas()
        {
            InitializeComponent();
        }

        private void ListaVentas_Load(object sender, EventArgs e)
        {
            string query = "";

            BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();

            brewingCreator.GetSqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, brewingCreator.GetSqlConnection);
            
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(sqlDataReader);
            }
        }
    }
}

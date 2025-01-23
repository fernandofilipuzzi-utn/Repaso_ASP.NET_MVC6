using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text.Json;
using WinFormClientAPI.Models;

namespace WinFormClientAPI
{
    public partial class FormPrinicpal : Form
    {
        public FormPrinicpal()
        {
            InitializeComponent();
        }

        async private void btnListarTodos_Click(object sender, EventArgs e)
        {
            //simil con sqlclient
            //workstation id=Ejemplo01CRUDSimpleDB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplo01CRUDSimpleDB.mssql.somee.com;persist security info=False;initial catalog=Ejemplo01CRUDSimpleDB;TrustServerCertificate=True
            //Microsoft.Data.SqlClient
            //SqlConnection 
            //SqlCommand
            //SqlReader

            List<Persona> personas = new List<Persona>();

            string url = "http://localhost:5237/api/Personas";

            using var client = new HttpClient();

            var consulta = new HttpRequestMessage(HttpMethod.Get, url);

            var respuesta=await client.SendAsync(consulta);

            if (respuesta.IsSuccessStatusCode)
            {
                var json = await respuesta.Content.ReadAsStringAsync();
                personas=JsonSerializer.Deserialize<List<Persona>>(json);
            }

            dataGridView1.Rows.Clear(); 
            foreach (var p in personas)
            {
                dataGridView1.Rows.Add(new[] { p.dni.ToString(), p.nombre} );
            }
        }
    }
}

namespace ControlRegistroDeParticipantes
{
    public partial class frmParticipantes : Form
    {
        int num;
        int cJefe, cOperario, cAdministrativo, cPracticante;
        public frmParticipantes()
        {
            InitializeComponent();
            tHora.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Estas seguro de que quieres salir?","Participantes", MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void frmParticipantes_Load(object sender, EventArgs e)
        {
            num++;
            lblNumero.Text = num.ToString("D4");
            lblFecha.Text = DateTime.Now.ToString("d");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos
            DateTime fecha, hora;
            string participante, cargo;
            int numero;
            participante = txtParticipante.Text;
            numero = int.Parse(lblNumero.Text);
            fecha = DateTime.Parse(lblFecha.Text);
            hora = DateTime.Parse(lblHora.Text);
            cargo = cboCargo.Text;

            // Contabilizar el registro
            switch (cargo)
            {
                case "Jefe": cJefe++; break;
                case "Operario": cOperario++; break;
                case "Administrativo": cAdministrativo++; break;
                case "Practicante": cPracticante++; break;
            }

            //Imprimir el registro
            ListViewItem fila = new ListViewItem(numero.ToString());
            fila.SubItems.Add(participante);
            fila.SubItems.Add(cargo);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(hora.ToString("hh:mm:ss"));
            lvParticipantes.Items.Add(fila);

            //Imprimiendo Estadisticas
            lvEstadisticas.Items.Clear();
            string[] elementoFila = new string[2];
            ListViewItem row;

            //Añadimos la primera fila al lvEstadisticas
            elementoFila[0] = "Jefe";
            elementoFila[1] = cJefe.ToString();
            row = new ListViewItem(elementoFila);
            lvEstadisticas.Items.Add(row);

            //Añadimos elementos a la segunda fila al lvEstadisticas
            elementoFila[0] = "Operario";
            elementoFila[1] = cOperario.ToString();
            row = new ListViewItem(elementoFila);
            lvEstadisticas.Items.Add(row);

            //Añadimos elementos a la tercera fila al lvEstadisticas
            elementoFila[0] = "Administrativo";
            elementoFila[1] = cAdministrativo.ToString();
            row = new ListViewItem(elementoFila);
            lvEstadisticas.Items.Add(row);

            //Añadimos elementos a al tercera fila al lvEstadisticas
            elementoFila[0] = "Practicante";
            elementoFila[1] = cPracticante.ToString();
            row = new ListViewItem(elementoFila);
            lvEstadisticas.Items.Add(row);

            //Mostrando el nuevo numero del registro
            num++;
            lblNumero.Text = num.ToString("D4");

            //Limpiando los controles
            txtParticipante.Clear();
            cboCargo.SelectedIndex = -1;
            cboCargo.Text = "(Seleccione el cargo)";
            txtParticipante.Focus();
        }
    }
}
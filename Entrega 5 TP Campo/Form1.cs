using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Npgsql;

namespace Entrega_5_TP_Campo
{
    public partial class Form1 : Form
    {
        private Entrega5Context _entrega5Context;

        private Insumo insumo;
        private DateTime fechaEmision = DateTime.UtcNow;

        private DateTime fechaVencimiento = DateTime.UtcNow.AddDays(15);


        public Form1()
        {
            InitializeComponent();
            _entrega5Context = new Entrega5Context();
            Form1_Load(this, EventArgs.Empty);
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            textBox1.TextChanged += textBox1_TextChanged;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            textBox2.TextChanged += textBox2_TextChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += DataGridView1_RowsRemoved;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(816, 478);
            tabControl1.Size = new Size(776, 415);

            var mediosPago = _entrega5Context.TipoMedioPago.ToList();

            foreach (var medioPago in mediosPago)
            {
                comboBox1.Items.Add(medioPago.Nombre);
            }

            var condicionesVenta = _entrega5Context.TipoCondicionDeVenta.ToList();

            foreach (var condicionVenta in condicionesVenta)
            {
                comboBox2.Items.Add(condicionVenta.Nombre);
            }

            var ultimaFactura = _entrega5Context.Factura.OrderByDescending(f => f.Id).FirstOrDefault();
            if (ultimaFactura != null)
            {
                label16.Text = (ultimaFactura.NumeroComprobante + 1).ToString();
            }
            else
            {
                label16.Text = "1";
            }

            label17.Text = fechaEmision.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Accion"].Index && e.RowIndex >= 0)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Efectivo")
            {
                label18.Text = fechaVencimiento.AddDays(15).ToString();
            }
            if (comboBox1.Text == "Cuotas")
            {
                label18.Text = fechaVencimiento.AddDays(30).ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 && groupBox2.Visible == false)
            {
                Size = new Size(816, 478);
                tabControl1.Size = new Size(776, 415);
            }
            else if (tabControl1.SelectedIndex == 0 && groupBox2.Visible == true)
            {
                Size = new Size(816, 478 + groupBox2.Height);
                tabControl1.Size = new Size(776, 415 + groupBox2.Height);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Size = new Size(816, 587);
                tabControl1.Size = new Size(776, 524);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var afiliadoExiste = _entrega5Context.Afiliado.Include(x => x.TipoResponsableIVA).FirstOrDefault(x => x.Cuit == textBox1.Text);

            if (afiliadoExiste != null)
            {
                Height += groupBox2.Height;
                comboBox1.Top += groupBox2.Height;
                comboBox2.Top += groupBox2.Height;
                label3.Top += groupBox2.Height;
                button2.Top += groupBox2.Height;
                button3.Top += groupBox2.Height;
                tabControl1.Height += groupBox2.Height;
                label18.Top += groupBox2.Height;
                label19.Top += groupBox2.Height;
                label20.Top += groupBox2.Height;
                textBox1.Visible = false;
                button1.Visible = false;
                groupBox2.Visible = true;
                label11.Text = afiliadoExiste.Nombre;
                label12.Text = afiliadoExiste.Apellido;
                label13.Text = afiliadoExiste.Cuit;
                label14.Text = Convert.ToString(afiliadoExiste.NumeroAgremiado);
                label15.Text = afiliadoExiste.TipoResponsableIVA.Nombre;
            }
            else
            {
                MessageBox.Show("El afiliado no existe o ingreso mal su número de CUIT, recuerde que debe hacerlo sin colocar guiones ni espacios.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            textBox1.Visible = true;
            button1.Visible = true;
            comboBox1.Top -= groupBox2.Height;
            comboBox2.Top -= groupBox2.Height;
            label3.Top -= groupBox2.Height;
            button2.Top -= groupBox2.Height;
            button3.Top -= groupBox2.Height;
            tabControl1.Height -= groupBox2.Height;
            label18.Top -= groupBox2.Height;
            label19.Top -= groupBox2.Height;
            label20.Top -= groupBox2.Height;
            Height -= groupBox2.Height;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                Form2 confirmacion = new Form2();
                DialogResult respuesta = confirmacion.ShowDialog();

                if (respuesta == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = (tabControl1.SelectedIndex - 1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                listBox1.Items.Clear();
                listBox1.Visible = false;
            }
            else
            {
                string busqueda = textBox1.Text.Trim();
                List<Afiliado> afiliados = BuscarAfiliados(busqueda);
                listBox1.Items.Clear();
                foreach (Afiliado afiliado in afiliados)
                {
                    listBox1.Items.Add(afiliado.Apellido + " " + afiliado.Nombre + " " + "," + afiliado.Cuit);
                }
                listBox1.Visible = listBox1.Items.Count > 0;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string texto = listBox1.SelectedItem.ToString();
                string[] afiliado = texto.Split(",");
                textBox1.Text = afiliado[1];
                listBox1.Items.Clear();
                listBox1.Visible = false;
            }
        }

        private List<Afiliado> BuscarAfiliados(string busqueda)
        {
            List<Afiliado> afiliadosBuscados = _entrega5Context.Afiliado.Where(a => a.Nombre.Contains(busqueda) || a.Apellido.Contains(busqueda) || a.Cuit.Contains(busqueda)).ToList();
            return afiliadosBuscados;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                listBox2.Items.Clear();
                listBox2.Visible = false;
            }
            else
            {
                string busqueda = textBox2.Text.Trim();
                List<Insumo> insumos = BuscarInsumos(busqueda);
                listBox2.Items.Clear();
                foreach (Insumo insumo in insumos)
                {
                    listBox2.Items.Add(insumo.Codigo + " " + insumo.Nombre + " " + insumo.Marca.Nombre);
                }
                listBox2.Visible = listBox2.Items.Count > 0;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string texto = listBox2.SelectedItem.ToString();
                string[] insumoTexto = texto.Split(" ");
                int codigo = Convert.ToInt32(insumoTexto[0]);
                insumo = _entrega5Context.Insumo.Include(m => m.Marca).FirstOrDefault(i => i.Codigo == codigo);
                textBox2.Text = insumo.Nombre;
                listBox2.Items.Clear();
                listBox2.Visible = false;
            }
        }

        private List<Insumo> BuscarInsumos(string busqueda)
        {
            List<Insumo> insumosBuscados = _entrega5Context.Insumo.Include(m => m.Marca).Where(i => i.Nombre.Contains(busqueda) || i.Codigo.ToString().Contains(busqueda) || i.Marca.Nombre.Contains(busqueda)).ToList();

            return insumosBuscados;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (insumo != null && comboBox2.SelectedIndex != null && numericUpDown1.Value != null && numericUpDown1.Value > 0)
            {
                string nombre = insumo.Nombre;
                string descripcion = insumo.Descripcion;
                int cantidad = Convert.ToInt32(numericUpDown1.Value);
                int idListaPrecio = 0;
                if (comboBox2.SelectedItem != null)
                {
                    idListaPrecio = _entrega5Context.ListaPrecio.Include(lp => lp.TipoCondicionDeVenta).FirstOrDefault(lp => lp.TipoCondicionDeVenta.Nombre == comboBox2.SelectedItem.ToString()).Id;
                }
                else
                {
                    MessageBox.Show("Necesita seleccionar un tipo de condición de venta antes de agregar insumos a su factura.");
                    return;
                }
                float precioInsumo = _entrega5Context.Precio.Include(p => p.Insumo).Include(p => p.ListaPrecio).FirstOrDefault(p => p.ListaPrecioId == idListaPrecio && p.InsumoId == insumo.Id).Monto;
                if (dataGridView1.RowCount > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Nombre"].Value != null && row.Cells["Descripcion"].Value != null && row.Cells["Nombre"].Value.ToString() == nombre && row.Cells["Descripcion"].Value.ToString() == descripcion)
                        {
                            row.Cells["Cantidad"].Value = Convert.ToInt32(row.Cells["Cantidad"].Value) + cantidad;
                            calcular();
                            return;
                        }
                    }
                }
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1, nombre, descripcion, cantidad, precioInsumo, "Eliminar insumo");
                dataGridView1.Rows.Add(fila);
            }
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calcular();
        }
        private void DataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcular();
        }
        private void calcular()
        {
            Single total = 0;
            Single subtotal = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                subtotal = subtotal + (Convert.ToSingle(row.Cells["Precio"].Value) * Convert.ToSingle(row.Cells["Cantidad"].Value));
            }
            label21.Text = subtotal.ToString();
            total = subtotal * Convert.ToSingle(1.21);
            label22.Text = total.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Afiliado afiliado = _entrega5Context.Afiliado.FirstOrDefault(a => a.Cuit == textBox1.Text);
            TipoMedioPago tipoMedioPago = _entrega5Context.TipoMedioPago.FirstOrDefault(tmp => tmp.Nombre == comboBox1.Text);
            if (label16.Text != null && label17.Text != null && label18.Text != null && label21.Text != null && label22.Text != null && afiliado != null && tipoMedioPago != null)
            {
                Factura factura = new Factura();
                factura.NumeroComprobante = Convert.ToInt32(label16.Text);
                factura.FechaEmision = fechaEmision;
                factura.FechaVencimiento = fechaVencimiento;
                factura.SubTotal = Convert.ToSingle(label21.Text);
                factura.ImporteTotal = Convert.ToInt32(label22.Text);
                factura.TipoMedioPagoId = tipoMedioPago.Id;
                factura.AfiliadoId = afiliado.Id;
                _entrega5Context.Add(factura);
                _entrega5Context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Faltan completar datos para poder guardar la factura.");
            }
        }
    }
}
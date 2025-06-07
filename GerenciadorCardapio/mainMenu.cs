using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GerenciadorCardapio
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        decimal subtotal = 0, taxa = 0.1m, total = 0, custo = 0, troco = 0;
        string metodoPag = "";
        string inputAtual = "";

        private void AdicionarItem(string item, int quantidade, decimal preco)
        {
            decimal valorTotal = quantidade * preco;
            dataGridView1.Rows.Add(item, quantidade, valorTotal.ToString("C2"));
            subtotal += valorTotal;
            AtualizarValores();
        }

        private void AtualizarValores()
        {
            total = subtotal + (subtotal * taxa);
            label4.Text = subtotal.ToString("C2");
            label5.Text = (subtotal * taxa).ToString("C2");
            label6.Text = total.ToString("C2");
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtValor.Text += btn.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }




        private void button24_Click(object sender, EventArgs e)
        {

            if (!txtValor.Text.Contains("."))
            {
                txtValor.Text += ".";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            inputAtual = "";
            txtValor.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                string valorTexto = row.Cells[2].Value.ToString()
                    .Replace("R$", "")
                    .Replace("$", "")
                    .Trim()
                    .Replace(",", ".");

                decimal valorRemovido;
                if (decimal.TryParse(valorTexto, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out valorRemovido))
                {
                    // Atualiza subtotal
                    subtotal -= valorRemovido;
                    dataGridView1.Rows.Remove(row);

                    // Atualiza label de subtotal
                    label4.Text = subtotal.ToString("C2");

                    // Atualiza taxa
                    decimal taxa = 0;
                    decimal.TryParse(label5.Text.Replace("R$", "").Replace("$", "").Trim().Replace(",", "."),
                        System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out taxa);

                    // Atualiza total e custo
                    total = subtotal + taxa;
                    label6.Text = total.ToString("C2"); // Total
                    label8.Text = total.ToString("C2"); // Custo

                    // Valor fixo de pagamento: R$ 100,00
                    decimal valorPago = 100.00m;
                    decimal troco = valorPago - total;

                    // Atualiza troco (não deixa negativo)
                    label7.Text = troco >= 0 ? troco.ToString("C2") : "R$ 0,00";
                }
                else
                {
                    MessageBox.Show("Erro ao converter o valor do item.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um item para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void button17_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            decimal preco = Convert.ToDecimal(btn.Text.Replace("$", ""));
            AdicionarItem("Café", 1, preco);
            AtualizarCodigoBarras();

        }

        private void button16_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            decimal preco = Convert.ToDecimal(btn.Text.Replace("$", ""));
            AdicionarItem("Café c/leite", 1, preco);
            AtualizarCodigoBarras();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            decimal preco = Convert.ToDecimal(btn.Text.Replace("$", ""));
            AdicionarItem("Coca", 1, preco);
            AtualizarCodigoBarras();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            decimal preco = Convert.ToDecimal(btn.Text.Replace("$", ""));
            AdicionarItem("Coca 2l", 1, preco);
            AtualizarCodigoBarras();

        }

        private void button13_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            decimal preco = Convert.ToDecimal(btn.Text.Replace("$", ""));
            AdicionarItem("Guarana", 1, preco);
            AtualizarCodigoBarras();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            decimal preco = Convert.ToDecimal(btn.Text.Replace("$", ""));
            AdicionarItem("Pudim", 1, preco);
            AtualizarCodigoBarras();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            decimal preco = Convert.ToDecimal(btn.Text.Replace("$", ""));
            AdicionarItem("Bolo", 1, preco);
            AtualizarCodigoBarras();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            decimal preco = Convert.ToDecimal(btn.Text.Replace("$", ""));
            AdicionarItem("Torta", 1, preco);
            AtualizarCodigoBarras();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            AtualizarCodigoBarras();
        }

        private void AtualizarCodigoBarras()
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[0].Cells[1].Value != null)
            {
                lblCodigoBarras.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            }
            else
            {
                lblCodigoBarras.Text = "Sem dados";
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            decimal preco = Convert.ToDecimal(btn.Text.Replace("$", ""));
            AdicionarItem("Capuccino", 1, preco);
            AtualizarCodigoBarras();

        }

        

        private void button20_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            subtotal = total = custo = troco = 0;
            inputAtual = "";
            txtValor.Text = "";
            label4.Text = label5.Text = label6.Text = label7.Text = label8.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValor.Text, out custo))
            {
                troco = custo - total;
                label8.Text = custo.ToString("C2");

                if (troco >= 0)
                {
                    label7.Text = troco.ToString("C2");
                    MessageBox.Show("Pagamento realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Aqui você pode adicionar código para finalizar a venda, limpar campos etc.
                }
                else
                {
                    label7.Text = "insuficiente";
                    MessageBox.Show("O valor pago é insuficiente para cobrir o total.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, digite um valor válido para o pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            



        private void button22_Click(object sender, EventArgs e)
        {

            // Define o conteúdo da nota
            StringBuilder notaTexto = new StringBuilder();
            notaTexto.AppendLine("====== NOTA DE VENDA ======\n");
            notaTexto.AppendLine("Itens:");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string nomeItem = row.Cells[1].Value?.ToString();
                    string preco = row.Cells[2].Value?.ToString();
                    notaTexto.AppendLine($"- {nomeItem}  R$ {preco}");
                }
            }

            notaTexto.AppendLine("\n--------------------------");
            notaTexto.AppendLine($"Total: {total.ToString("C2")}");
            notaTexto.AppendLine($"Valor pago: {custo.ToString("C2")}");
            notaTexto.AppendLine($"Troco: {(troco >= 0 ? troco.ToString("C2") : "Insuficiente")}");
            notaTexto.AppendLine("\nObrigado pela compra!");

            // Converte o texto em imagem
            SalvarNotaComoImagem(notaTexto.ToString());
            SalvarNotaNoBanco(notaTexto.ToString(), total, custo, troco);

            MessageBox.Show(notaTexto.ToString(), "Nota de Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void SalvarNotaNoBanco(string itens, decimal total, decimal valorPago, decimal troco)
        {
            string conexao = "server=localhost;database=db_gestaoCardapio;uid=root;pwd=;";

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO NotasVenda (Itens, Total, ValorPago, Troco) VALUES (@itens, @total, @valorPago, @troco)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@itens", itens);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@valorPago", valorPago);
                        cmd.Parameters.AddWithValue("@troco", troco);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Nota salva no banco com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar no banco: " + ex.Message);
                }
            }
        }


        private void SalvarNotaComoImagem(string texto)
        {
            // Define fonte e dimensões da imagem
            Font fonte = new Font("Consolas", 14);
            int largura = 500;
            int altura = 600;

            using (Bitmap bmp = new Bitmap(largura, altura))
            using (Graphics g = Graphics.FromImage(bmp))
            using (SolidBrush brush = new SolidBrush(Color.Black))
            using (SolidBrush fundo = new SolidBrush(Color.White))
            {
                // Fundo branco
                g.FillRectangle(fundo, 0, 0, largura, altura);

                // Desenha o texto
                g.DrawString(texto, fonte, brush, new RectangleF(10, 10, largura - 20, altura - 20));

                // Salva como PNG
                string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "nota_venda.png");
                bmp.Save(caminho, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show("Nota salva como imagem na área de trabalho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

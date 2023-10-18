using System.Data;
using System.Data.SqlClient;
namespace loginform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Username Should not be empty");

            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Password should not be empty ");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8MDS7I11\\SQLEXPRESS;Initial Catalog=WindowsForms;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE username = @username AND password = @password", conn);
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();



                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login Sucess");
                    }
                    else
                    {
                        MessageBox.Show("User Name or Password Invalid!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
                finally
                {

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
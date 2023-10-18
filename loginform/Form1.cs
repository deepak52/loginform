using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Username should not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Password should not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string password = textBox2.Text;

                // Password validation rules (you can customize these rules):
                if (password.Length < 8)
                {
                    MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Regex.IsMatch(password, @"[A-Z]"))
                {
                    MessageBox.Show("Password must contain at least one uppercase letter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Regex.IsMatch(password, @"[a-z]"))
                {
                    MessageBox.Show("Password must contain at least one lowercase letter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Regex.IsMatch(password, @"[0-9]"))
                {
                    MessageBox.Show("Password must contain at least one digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8MDS7I11\\SQLEXPRESS;Initial Catalog=WindowsForms;Integrated Security=True");
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE username = @username AND password = @password", conn);
                        cmd.Parameters.AddWithValue("@username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@password", textBox2.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Login Success");
                        }
                        else
                        {
                            MessageBox.Show("Username or Password Invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
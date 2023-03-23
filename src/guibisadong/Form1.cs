namespace guibisadong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }



        private void button1_MouseEnter(object sender, EventArgs e)
        { // ubah background jadi image2
            button1.Image = Properties.Resources.choose1;


        }

        private void button1_MouseLeave(object sender, EventArgs e)
        { // ubah background semula
            button1.Image = Properties.Resources.choose;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        { // open filedialog txt
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Files|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetFileName(open.FileName);
            }
        }



        private void Filename(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        { // ubah warna background
            button2.Image = Properties.Resources.search1;

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.search;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.visual1;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.visual;
        }
    }
}
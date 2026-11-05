namespace lab10
{
    public partial class Form1 : Form
    {
        int formindex = 0; // хүү формын индексийг хадгалах хувьсагч
        public Form1()
        {
            InitializeComponent();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formindex = this.MdiChildren.Length;
            Form ChildForm = new Form(); //шинээр форм үүсгэх
            ChildForm.Name = "Child" + (formindex + 1).ToString(); //формын нэр зааж байна
            ChildForm.Text = "Child" + (formindex + 1).ToString(); //формын гарчиг зааж байна.
            ChildForm.MdiParent = this; //Эцэг цонхыг зааж байна.
            TextBox txtBox = new TextBox(); //текст бичих талбар үүсгэж байна
            txtBox.Dock = DockStyle.Fill; //форм дээр дүүргэж байна.
            txtBox.Multiline = true; // олон мөр текст бичих боломжтой болно.
            ChildForm.Controls.Add(txtBox); // хүү формын контролуудын массивт нэмж байна.
            ChildForm.Show(); // хүү формыг харагдуулж байна.


        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void vertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void hortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Form active = this.ActiveMdiChild; // одоо идэвхтэй байгаа child
            if (active == null)
            {
                MessageBox.Show("Хадгалах цонх алга байна.");
                return;
            }

            TextBox txtBox = active.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBox == null) return;

            string path = active.Tag as string; // өмнө нь хадгалсан/нээсэн файлын зам

            if (string.IsNullOrEmpty(path)) // анх удаа хадгалж байвал зам асууна
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Текст файл (*.txt)|*.txt|Бүх файл (*.*)|*.*";
                sfd.FileName = active.Text;
                if (sfd.ShowDialog() != DialogResult.OK) return;
                path = sfd.FileName;
            }

            System.IO.File.WriteAllText(path, txtBox.Text);
            active.Tag = path;                              // дараагийн удаа шууд хадгална
            active.Text = System.IO.Path.GetFileName(path); // гарчгийг файлын нэрээр солино
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form active = this.ActiveMdiChild; // одоо идэвхтэй байгаа child
            if (active == null)
            {
                MessageBox.Show("Хадгалах цонх алга байна.");
                return;
            }

            TextBox txtBox = active.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBox == null) return;

            string path = active.Tag as string; // өмнө нь хадгалсан/нээсэн файлын зам

            if (string.IsNullOrEmpty(path)) // анх удаа хадгалж байвал зам асууна
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Текст файл (*.txt)|*.txt|Бүх файл (*.*)|*.*";
                sfd.FileName = active.Text;
                if (sfd.ShowDialog() != DialogResult.OK) return;
                path = sfd.FileName;
            }

            System.IO.File.WriteAllText(path, txtBox.Text);
            active.Tag = path;                              // дараагийн удаа шууд хадгална
            active.Text = System.IO.Path.GetFileName(path); // гарчгийг файлын нэрээр солино
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form active = this.ActiveMdiChild;
            if (active == null) return;


            TextBox txtBox = active.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBox == null) return;

            txtBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form active = this.ActiveMdiChild;
            if (active == null) return;


            TextBox txtBox = active.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBox == null) return;

            txtBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form active = this.ActiveMdiChild;
            if (active == null) return;


            TextBox txtBox = active.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBox == null) return;

            txtBox.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form active = this.ActiveMdiChild;
            if (active == null) return;


            TextBox txtBox = active.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBox == null) return;

            txtBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оюутны нэр: О.Гэрэлбат\nОюутны код: M.IT24D033", "Программын тухай", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    }
    


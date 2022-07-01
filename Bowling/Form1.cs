namespace Bowling
{
    public partial class frmBowling : Form
    {
        public frmBowling()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] tab = { "9", "1", "9", "1", "9", "1", "9", "1", "9", "1", "9", "1", "9", "1", "9", "1", "9", "1", "9", "1", "9" };
            Player player = new Player("Hary Potter", tab);
            string wynik = player.GetScore;
        }
    }
}
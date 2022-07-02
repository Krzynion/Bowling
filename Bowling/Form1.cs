namespace Bowling
{
    public partial class frmBowling : Form
    {
        private List<Player> _players;
        public frmBowling()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki tekstowe(*.txt)|*.txt|Wszystkie pliki(*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var status = LoadDataFromFile(openFileDialog.FileName);
                if(status)
                    FillView(dataGridView1,_players);
                else
                    dataGridView1.Rows.Clear();
            }
            
        }

        private Boolean LoadDataFromFile(string FilePath)
        {
            _players = new List<Player>();
            if (!File.Exists(FilePath))
                return false;
            StreamReader sr = new StreamReader(FilePath);
            if (sr.EndOfStream)
            {
                sr.Close();
                return false;
            }
            while (!sr.EndOfStream)
            {
                String name = sr.ReadLine().Trim();
                String[] points = sr.ReadLine().Split(',');
                for (int x = 0; x < points.Length; x++)
                    points[x] = points[x].Trim();
                _players.Add(new Player(name, points));
            }
            sr.Close();
            return true;
        }

        private void FillView(DataGridView dataGrid, List<Player> players)
        {
            dataGrid.Rows.Clear();
            dataGrid.RowCount= players.Count;
            
            for(int playerNo=0;playerNo<players.Count;playerNo++)
            {
                var row=dataGrid.Rows[playerNo];
                row.Cells["Zawodnik"].Value = players[playerNo].GetName;
                row.Cells["Wynik"].Value = players[playerNo].GetScore;
                for (int i = 0; i < players[playerNo].GetRolls.Length; i++)
                    row.Cells[i + 2].Value = players[playerNo].GetRolls[i];
            }
            
            

        }
    }
}
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
                List<Frame> frames = new List<Frame>();
                int i = 0;
                for(int x=1;x<11;x++)
                {
                    Frame frame;
                    if(points[i] == "10")
                    {
                        frame = new("10", "X", true, false);
                        i++;
                    }
                    else
                    {
                        var spare = false;
                        if (int.Parse(points[i]) + int.Parse(points[i + 1]) == 10)
                            spare = true;
                        frame = new(points[i], points[i + 1], false, spare);
                        i += 2;
                    }
                    frames.Add(frame);
                }
                if (frames[9].Strike)
                {
                    Frame frame=new Frame(points[i], points[i+1],false,false);
                    frames.Add(frame);
                }
                if (frames[9].Spare)
                {
                    Frame frame = new Frame(points[i], String.Empty, false, false);
                    frames.Add(frame);
                }
                //-------Adding extra points (Strike, Spare)--------
                for (int x=0;x<10;x++)
                {
                    if(frames[x].Strike)
                    {
                        frames[x].FramePoints += frames[x + 1].FramePoints;
                        if (frames[x + 1].Strike)
                            frames[x].FramePoints += int.Parse(frames[x + 2].FirstRoll);
                    }
                    if(frames[x].Spare)
                        frames[x].FramePoints += int.Parse(frames[x + 1].FirstRoll);
                }
                //----------------------------------------------------------
                _players.Add(new Player(name, frames));
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
                row.Cells["Wynik"].Value = players[playerNo].Score();
                for (int i = 0; i < players[playerNo].GetFrames.Count; i++)
                {
                    row.Cells[(i*2) + 2].Value = players[playerNo].GetFrames[i].FirstRoll;
                    row.Cells[(i*2) + 3].Value = players[playerNo].GetFrames[i].SecoundRoll;
                }
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
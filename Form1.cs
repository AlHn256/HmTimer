//using Timer = System.Threading.Timer;

using System.Timers;

namespace TimerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SendMsg1 += ChangeTb;
            textBox2.Text = "517940";
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {

            //int num = 0;
            //// устанавливаем метод обратного вызова


            //TimerCallback tm = new TimerCallback(Count);
            //// создаем таймер
            //Timer timer = new Timer(tm, num, 0, 1000);


        }

        System.Timers.Timer NewTimer;

        int Nsec = 1;
        private void Form1_Load_1(object sender, EventArgs e)
        {
            NewTimer = new System.Timers.Timer();
            NewTimer.Interval = 1000 * Nsec;
            NewTimer.Elapsed += Timer_Elapsed;
            NewTimer.Start();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                int x = 0;
                int s = 0;
                Int32.TryParse(textBox1.Text, out s);
                Int32.TryParse(textBox2.Text, out x);

                x = x * Nsec / 3600;
                if (x != 0) s = s + x;
                else s = s + 1;
                textBox1.Text = $"{s}";
            }));
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("The form will now be closed.", "Time Elapsed");
            this.Close();
        }

        public void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                SendMsg1($"{x * i}");
                //textBox1.Text = $"{x * i}";
            }
        }

        public delegate void SendMessag(object value);
        public event SendMessag SendMsg1;
        private void ChangeTb(object value) => textBox1.Text = (string)value;

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text;
        }
    }
}

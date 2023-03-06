using System.Net.Http.Headers;

namespace ThreadForm2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button1_Click;
            button3.Click += button1_Click;
            

        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
        }
        Random rnd;
        Thread th1;
        Thread th2;
        Thread th3;

        private void button1_Click(object sender, EventArgs e)
        {
            th1 = new Thread(thread_task);
            th1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            th2 = new Thread(thread_task1);
            th2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            th3 = new Thread(thread_task2);
            th3.Start();
        }
        public void thread_task()
        {
            for (int i = 0; i < 100; i++)
            {
                
                this.CreateGraphics().DrawRectangle(
                                               new Pen(Brushes.Yellow,4),
                                                   new Rectangle(
                                                   rnd.Next(0,100),
                                                   rnd.Next(0,200),30,30));
                Thread.Sleep(100);
                                                   
            }
        }
        public void thread_task1()
        {
            for (int i = 0; i < 100; i++)
            {
                this.CreateGraphics().DrawRectangle(
                                               new Pen(Brushes.Blue, 4),
                                                   new Rectangle(
                                                   rnd.Next(0, this.Width),
                                                   rnd.Next(0, this.Height), 30, 30));
                Thread.Sleep(100);

            }
        }
        public void thread_task2()
        {
            for (int i = 0; i < 100; i++)
            {
                this.CreateGraphics().DrawRectangle(
                                               new Pen(Brushes.Red, 4),
                                                   new Rectangle(
                                                   rnd.Next(0, this.Width),
                                                   rnd.Next(0, this.Height), 30, 30));
                Thread.Sleep(100);

            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}

using Timer = System.Windows.Forms.Timer;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        // �����C���������s�ƶq�M�Ϥ��ƶq
        public static int totalImages = 6;
        public static int totalButtons = totalImages*2;

        // �����C�����w�g�t�令�\���Ϥ��ƶq
        private int matchedCount = 0;
        // �����C�������Ϥ�
        private List<Image> gameImages = new List<Image>();

        // �����C���������s
        private List<Button> buttons = new List<Button>();

        // �����ϥΪ��I������ӫ��s
        private  MatchingButton firstClickedButton = null;
        private  MatchingButton secondClickedButton = null;
        // �����ϥΪ��I�������s�ƶq
        private int clicksCount = 0;

        // �ŧi Timer ����
        private  Timer timer = new Timer();

        // �����C���}�l�ɶ�
        private DateTime startTime;
        
        //
        public Form1()
        {
            this.Text = "Image Matching Game";
            this.Size = new Size(640, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += Form1_Load;

            // ���J�C���Ϥ�, ��l�ƫ��s
            LoadGameImages();
            InitializeButtons();

            // �]�w timer �� Tick �ƥ󪺳B�z�禡
            timer.Tick += Timer_Tick;
        }
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            // �����C���}�l�ɶ�
            startTime = DateTime.Now; 
        }

        private void LoadGameImages()
        {
            // ��ʱN�Ϥ��[�J�� gameImages �C��
            gameImages.Add(Properties.Resources.Image1);
            gameImages.Add(Properties.Resources.Image2);
            gameImages.Add(Properties.Resources.Image3);
            gameImages.Add(Properties.Resources.Image4);
            gameImages.Add(Properties.Resources.Image5);
            gameImages.Add(Properties.Resources.Image6);
            // TODO �ھڻݭn�[�J��h�Ϥ�

            // �T�O gameImages �����������Ϥ��ѹC���ϥ�
            if (gameImages.Count < totalImages)
            {
                MessageBox.Show("�C���Ϥ������A�Х[�J��h�Ϥ��C");
                this.Close();
            }
           
        }

        // �����H�����Ϥ�����
        public static List<int> GenerateRandomImageIndexes()
        {
            List<int> CardIndexes = new List<int>();
            //
            Random random = new Random();
            //
            for (int i = 0; i < totalImages; i++)
            {
                CardIndexes.Add(i);
                CardIndexes.Add(i);
            }

            List<int> randomIndexes = new List<int>();

            while (CardIndexes.Count > 0)
            {
                int randomIndex = random.Next(CardIndexes.Count);
                randomIndexes.Add(CardIndexes[randomIndex]);
                CardIndexes.RemoveAt(randomIndex);
            }
            //
            return randomIndexes;
        }

        // ��l�ƹC���������s
        private void InitializeButtons()
        {
            // �����H�����Ϥ�����, �åB�ھڳo�ǯ��ިӪ�l�ƫ��s
            List<int> randomIndexes = GenerateRandomImageIndexes();
            // �ʺA�ͦ����s
            for (int i = 0; i < totalButtons; i++)
            {
                // ���o�Ϥ�����
                int cardIndex = randomIndexes[i];
                // TODO: �إ� MatchingButton ����, �]�w���s�������ݩ�(Tag, Location), �ƥ�B�z�禡
                Button button = new Button();
                button.Size = new Size(100, 100);
                //
                button.Tag = cardIndex;
                button.Location = new Point((i % 6) * 100 + 10, (i / 6) * 100 + 15);
                this.Controls.Add(button);
                button.Click += MatchingButton_Click;

                // �N���s�[�J�� buttons �C��
                buttons.Add(button);
                //
            }
        }

        // ���s�� Click �ƥ�B�z�禡
        private void MatchingButton_Click(object sender, EventArgs e)
        {
            // TODO - �קאּ MatchingButton ���P�_�覡
            Button btn = sender as Button;
            MessageBox.Show($"Button_CardID:{btn.Tag} Clicked");
        }

        // Timer �� Tick �ƥ�B�z�禡: �N[�Q�I����ӫ��s]���Ϥ�½�ର�I��
        private void Timer_Tick(object sender, EventArgs e)
        {
            // ���� timer
            timer.Stop();

            // TODO: �N[�Q�I����ӫ��s]���Ϥ�½�ର�I��


            // Reset firstClickedButton and secondClickedButton
            firstClickedButton = null;
            secondClickedButton = null;
            // Reset clicksCount
            clicksCount = 0;
        }

        // �C������
        private void GameCompleted()
        {
            // TODO �p��X�C�����������
            int elapsedSeconds = 0;
            MessageBox.Show("�C�������I�ϥά�ơG" + elapsedSeconds);
            this.Close();
        }
    }
}

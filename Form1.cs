namespace CatchButton
{
    public partial class Form1 : Form
    {
        // 점수 변수
        int score = 0;
        int missCount = 0; // 놓친 횟수 변수
        // 난수 생성기(연속 호출 시 같은 시드 문제 방지)
        private readonly Random rd = new Random();
        public Form1()
        {
            InitializeComponent();
            // 버튼 클릭 시 메시지박스 표시
            RunningButton.Click += RunningButton_Click;
        }

        private void RunningButton_MouseEnter(object sender, EventArgs e)
        {
            //RunningButton.Location = new Point(x_position, y_position);
            // 1. 난수 생성기 준비
            Random rd = new Random();

            // 2. 가용 영역 계산 (버튼이 폼 테두리에 걸리지 않게 보호)
            //ClientSize는 타이틀 바와 테두리를 제외한 실제 흰 도화지 영역임
            int maxX = this.ClientSize.Width;
            int maxY = this.ClientSize.Height;

            // 3. 랜덤 좌표 추출 (0 ~ 최대 가용치 사이)
            int nextX = rd.Next(0, maxX - 227);
            int nextY = rd.Next(0, maxY - 73);

            RunningButton.Location = new Point(nextX, nextY);

            score -= 10; // 점수 감소

            // 4. 위치 할당 (새로운 Point 객체 생성)
            RunningButton.Location = new Point(nextX, nextY);

            // 5. 시각적 피드백( 폼 제목 표시줄에 좌표와 점수출력)
            this.Text = $"버튼위치: ({nextX}, {nextY})  |  점수: {score}";

            missCount++; // 놓친 횟수 증가
            if (missCount >= 20)
            {
                MessageBox.Show("Game Over", "20번 놓쳤습니다.");
                RunningButton.Enabled = false; // 버튼 비활성화

                // 다음 게임 버튼
                DialogResult result = MessageBox.Show("다시 시작 할래요?", "다음 게임", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    score = 0;
                    missCount = 0;

                    RunningButton.Enabled = true;

                    RunningButton.Width = 227;
                    RunningButton.Height = 73;

                    RunningButton.Location = new Point(100, 100);

                    this.Text = $"버튼위치: ({nextX}, {nextY})  |  점수: {score}";
                }
            }

        }

        private void RunningButton_Click(object? sender, EventArgs e)
        {
            // 버튼을 잡았을 때 소리 재생 후 축하 메시지 표시
            System.Media.SystemSounds.Beep.Play();
            score += 100; // 점수 증가

            MessageBox.Show("축하합니다~!", "잡았습니다");

            // 버튼 크기 10% 감소
            RunningButton.Width = (int)(RunningButton.Width * 0.9);
            RunningButton.Height = (int)(RunningButton.Height * 0.9);
        }
    }
}

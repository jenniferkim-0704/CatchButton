namespace CatchButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            // Form1안에 버튼이 완전히 들어가도록 하기 위해 버튼의 크기만큼 빼줌
            int nextX = rd.Next(0, maxX-227);
            int nextY = rd.Next(0, maxY-73);

            // 4. 위치 할당 (새로운 Point 객체 생성)
            RunningButton.Location = new Point(nextX, nextY);

            // 5. 시각적피드백(폼제목표시줄에좌표출력)
            this.Text = $"버튼위치: ({nextX}, {nextY})";
        }
    }
}

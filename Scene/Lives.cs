using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace SyobonAction
{
    public class Lives : Scene
    {
        private int n残機;
        private int count;
        private Game game;

        public Lives(int n残機,int a,int b,int c,bool over)
        {
            this.n残機 = n残機;
            this.game = new Game(a, b, c, n残機, over);
        }

        public override void Draw()
        {
            DXDraw.SetColorBlack();
            DXDraw.DrawBox塗り潰し(0, 0, Program.W, Program.H);

            DX.SetFontSize(16);
            DX.SetFontThickness(4);

            DXDraw.DrawGraph(Res.n切り取り画像_[0, 0], 190, 190);
            DX.DrawString(230, 200, " × " + this.n残機, DX.GetColor(255, 255, 255));
        }

        public override void Update()
        {
            this.count++;
            if (this.count >= 30)
            {
                this.NextScene = this.game;
            }
        }
    }
}

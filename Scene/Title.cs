using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyobonAction
{
    public class Title : Scene
    {
        private int a = 1;
        private int b = 1;
        private bool over = false;

        public override void Draw()
        {
            DXDraw.SetColor(160, 180, 250);
            DXDraw.DrawBox塗り潰し(0, 0, Program.W, Program.H);

            DXDraw.DrawGraph(Res.nタイトル画像, 240 - 380 / 2, 60);

            DXDraw.DrawGraph(Res.n切り取り画像_[0, 4], 12 * 30, 10 * 29 - 12);
            DXDraw.DrawGraph(Res.n切り取り画像_[1, 4], 6 * 30, 12 * 29 - 12);

            //プレイヤー
            DXDraw.DrawGraph(Res.n切り取り画像_[0, 0], 2 * 30, 12 * 29 - 12 - 6);
            for (int t_ = 0; t_ <= 16; t_++)
            {
                DXDraw.DrawGraph(Res.n切り取り画像_[5, 1], 29 * t_, 13 * 29 - 12);
                DXDraw.DrawGraph(Res.n切り取り画像_[6, 1], 29 * t_, 14 * 29 - 12);
            }


            DXDraw.SetColor(0, 0, 0);
            DXDraw.DrawString("Enterキーを押せ!!", 240 - 8 * 20 / 2, 250);
        }

        public override void Update()
        {
            if (Key.GetKey(DX.KEY_INPUT_1)) { this.a = 1; this.b = 1; }
            if (Key.GetKey(DX.KEY_INPUT_2)) { this.a = 1; this.b = 2; }
            if (Key.GetKey(DX.KEY_INPUT_3)) { this.a = 1; this.b = 3; }
            if (Key.GetKey(DX.KEY_INPUT_4)) { this.a = 1; this.b = 4; }
            if (Key.GetKey(DX.KEY_INPUT_5)) { this.a = 2; this.b = 1; }
            if (Key.GetKey(DX.KEY_INPUT_6)) { this.a = 2; this.b = 2; }
            if (Key.GetKey(DX.KEY_INPUT_7)) { this.a = 2; this.b = 3; }
            if (Key.GetKey(DX.KEY_INPUT_8)) { this.a = 2; this.b = 4; }
            if (Key.GetKey(DX.KEY_INPUT_9)) { this.a = 3; this.b = 1; }
            if (Key.GetKey(DX.KEY_INPUT_0)) { this.over = true; }


            if (Key.GetKey(DX.KEY_INPUT_RETURN) ||
                Key.GetKey(DX.KEY_INPUT_Z) ||
                Key.GetKey(DX.KEY_INPUT_0))
            {
                //Game作成をしてLivesにわたす
                this.NextScene = new Lives(2, this.a, this.b, 0, this.over);
            }
        }
    }
}

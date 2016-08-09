using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace SyobonAction
{
    public class Ending : Scene
    {
        private List<Text> list = new List<Text>();
        private int count;

        public Ending()
        {
            this.list.Add(new Text("制作・プレイに関わった方々", 240 - 13 * 20 / 2, 460));
            this.list.Add(new Text("ステージ１　プレイ", 240 - 9 * 20 / 2, 540));
            this.list.Add(new Text("先輩　Ⅹ～Ｚ", 240 - 6 * 20 / 2, 590));
            this.list.Add(new Text("ステージ２　プレイ", 240 - 9 * 20 / 2, 650));
            this.list.Add(new Text("友人　willowlet ", 240 - 8 * 20 / 2, 700));
            this.list.Add(new Text("ステージ３　プレイ", 240 - 9 * 20 / 2, 760));
            this.list.Add(new Text("友人　willowlet ", 240 - 8 * 20 / 2, 810));
            this.list.Add(new Text("ステージ４　プレイ", 240 - 9 * 20 / 2, 870));
            this.list.Add(new Text("友人２　ann ", 240 - 6 * 20 / 2, 920));
            this.list.Add(new Text("ご協力", 240 - 3 * 20 / 2, 1000));
            this.list.Add(new Text("Ｔ先輩", 240 - 3 * 20 / 2, 1050));
            this.list.Add(new Text("Ｓ先輩", 240 - 3 * 20 / 2, 1100));
            this.list.Add(new Text("動画技術提供", 240 - 6 * 20 / 2, 1180));
            this.list.Add(new Text("Ｋ先輩", 240 - 3 * 20 / 2, 1230));
            this.list.Add(new Text("動画キャプチャ・編集・エンコード", 240 - 16 * 20 / 2, 1360));
            this.list.Add(new Text("willowlet ", 240 - 5 * 20 / 2, 1410));
            this.list.Add(new Text("プログラム・描画・ネタ・動画編集", 240 - 16 * 20 / 2, 1540));
            this.list.Add(new Text("ちく", 240 - 2 * 20 / 2, 1590));

            this.list.Add(new Text("プレイしていただき　ありがとうございました～", 240 - 22 * 20 / 2, 1800));
        }

        class Text
        {
            public string text;
            public int x,y;

            public Text(string text,int x,int y)
            {
                this.text = text;
                this.x = x;
                this.y = y;
            }
        }

        public override void Draw()
        {
            DXDraw.SetColor(255, 255, 255);

            foreach (Text t in this.list)
            {
                DXDraw.DrawString(t.text, t.x, t.y);
            }
        }

        public override void Update()
        {
            if (this.count == 0)
            {
                Program.bgmChange(Res.nオーディオ_[106]); DX.PlaySoundMem(Res.nオーディオ_[0], DX.DX_PLAYTYPE_LOOP);
            }
            if (Key.GetKey(DX.KEY_INPUT_1))
            {
                DX.DxLib_End();
            }
            foreach (Text t in this.list)
            {
                t.y -= 1;
                if (Key.GetKey(DX.KEY_INPUT_SPACE))
                {
                    t.y -= 3;
                }
            }

            if (this.list.Last().y == -2) {
                Program.bgmChange(Res.nオーディオ_[106]);
            }
            if (this.list.Last().y <= -4) {
                this.NextScene = new Title();
            }

            this.count++;
        }
    }
}

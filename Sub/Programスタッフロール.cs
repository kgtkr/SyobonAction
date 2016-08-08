using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        static int[] xxスタッフロール=new int[47];
        static void Drawスタッフロール()
        {
            DXDraw.SetColor(255, 255, 255);
            DXDraw.DrawString("制作・プレイに関わった方々", 240 - 13 * 20 / 2, xxスタッフロール[12-12] / 100);
            DXDraw.DrawString("ステージ１　プレイ", 240 - 9 * 20 / 2, xxスタッフロール[13-12] / 100);
            DXDraw.DrawString("先輩　Ⅹ～Ｚ", 240 - 6 * 20 / 2, xxスタッフロール[14-12] / 100);
            DXDraw.DrawString("ステージ２　プレイ", 240 - 9 * 20 / 2, xxスタッフロール[15-12] / 100);
            DXDraw.DrawString("友人　willowlet ", 240 - 8 * 20 / 2, xxスタッフロール[16-12] / 100);
            DXDraw.DrawString("ステージ３　プレイ", 240 - 9 * 20 / 2, xxスタッフロール[17-12] / 100);
            DXDraw.DrawString("友人　willowlet ", 240 - 8 * 20 / 2, xxスタッフロール[18-12] / 100);
            DXDraw.DrawString("ステージ４　プレイ", 240 - 9 * 20 / 2, xxスタッフロール[19-12] / 100);
            DXDraw.DrawString("友人２　ann ", 240 - 6 * 20 / 2, xxスタッフロール[20-12] / 100);
            DXDraw.DrawString("ご協力", 240 - 3 * 20 / 2, xxスタッフロール[21-12] / 100);
            DXDraw.DrawString("Ｔ先輩", 240 - 3 * 20 / 2, xxスタッフロール[22-12] / 100);
            DXDraw.DrawString("Ｓ先輩", 240 - 3 * 20 / 2, xxスタッフロール[23-12] / 100);
            DXDraw.DrawString("動画技術提供", 240 - 6 * 20 / 2, xxスタッフロール[24-12] / 100);
            DXDraw.DrawString("Ｋ先輩", 240 - 3 * 20 / 2, xxスタッフロール[25-12] / 100);
            DXDraw.DrawString("動画キャプチャ・編集・エンコード", 240 - 16 * 20 / 2, xxスタッフロール[26-12] / 100);
            DXDraw.DrawString("willowlet ", 240 - 5 * 20 / 2, xxスタッフロール[27-12] / 100);
            DXDraw.DrawString("プログラム・描画・ネタ・動画編集", 240 - 16 * 20 / 2, xxスタッフロール[28-12] / 100);
            DXDraw.DrawString("ちく", 240 - 2 * 20 / 2, xxスタッフロール[29-12] / 100);

            DXDraw.DrawString("プレイしていただき　ありがとうございました～", 240 - 22 * 20 / 2, xxスタッフロール[30-12] / 100);
        }

        static void Updateスタッフロール()
        {
            maintm++;

            xx_7 = 46;
            if (Key.GetKey(DX.KEY_INPUT_1))
            {
                DX.DxLib_End();
            }
            if (Key.GetKey(DX.KEY_INPUT_SPACE))
            {
                for (int t_ = 0; t_ <= xx_7; t_ += 1)
                {
                    xxスタッフロール[t_] -= 300;
                }
            }

            if (maintm <= 1)
            {
                maintm = 2; bgmChange(Res.nオーディオ_[106]); DX.PlaySoundMem(Res.nオーディオ_[0], DX.DX_PLAYTYPE_LOOP);
                for (int t_ = 0; t_ <= xx_7; t_ += 1) { xxスタッフロール[t_] = 980000; }
                xxスタッフロール[12-12] = 460;
                xxスタッフロール[13-12] = 540; xxスタッフロール[14-12] = 590;
                xxスタッフロール[15-12] = 650; xxスタッフロール[16-12] = 700;
                xxスタッフロール[17-12] = 760; xxスタッフロール[18-12] = 810;
                xxスタッフロール[19-12] = 870; xxスタッフロール[20-12] = 920;

                xxスタッフロール[21-12] = 1000; xxスタッフロール[22-12] = 1050; xxスタッフロール[23-12] = 1100;
                xxスタッフロール[24-12] = 1180; xxスタッフロール[25-12] = 1230;

                xxスタッフロール[26-12] = 1360; xxスタッフロール[27-12] = 1410;
                xxスタッフロール[28-12] = 1540; xxスタッフロール[29-12] = 1590;

                xxスタッフロール[30-12] = 1800;

                for (int t_ = 0; t_ <= xx_7; t_ += 1) { xxスタッフロール[t_] *= 100; }
            }

            for (int t_ = 0; t_ <= xx_7; t_ += 1) { xxスタッフロール[t_] -= 100; }//t

            if (xxスタッフロール[30-12] == -200) { bgmChange(Res.nオーディオ_[106]); }
            if (xxスタッフロール[30-12] <= -400) { e現在の画面 = E画面.Title; nokori = 2; maintm = 0; nスタッフロール = 0; }
        }
    }
}

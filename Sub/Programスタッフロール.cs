using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        static void Drawスタッフロール()
        {
            DXDraw.SetColor(255, 255, 255);
            DXDraw.DrawString("制作・プレイに関わった方々", 240 - 13 * 20 / 2, xx[12] / 100);
            DXDraw.DrawString("ステージ１　プレイ", 240 - 9 * 20 / 2, xx[13] / 100);
            DXDraw.DrawString("先輩　Ⅹ～Ｚ", 240 - 6 * 20 / 2, xx[14] / 100);
            DXDraw.DrawString("ステージ２　プレイ", 240 - 9 * 20 / 2, xx[15] / 100);
            DXDraw.DrawString("友人　willowlet ", 240 - 8 * 20 / 2, xx[16] / 100);
            DXDraw.DrawString("ステージ３　プレイ", 240 - 9 * 20 / 2, xx[17] / 100);
            DXDraw.DrawString("友人　willowlet ", 240 - 8 * 20 / 2, xx[18] / 100);
            DXDraw.DrawString("ステージ４　プレイ", 240 - 9 * 20 / 2, xx[19] / 100);
            DXDraw.DrawString("友人２　ann ", 240 - 6 * 20 / 2, xx[20] / 100);
            DXDraw.DrawString("ご協力", 240 - 3 * 20 / 2, xx[21] / 100);
            DXDraw.DrawString("Ｔ先輩", 240 - 3 * 20 / 2, xx[22] / 100);
            DXDraw.DrawString("Ｓ先輩", 240 - 3 * 20 / 2, xx[23] / 100);
            DXDraw.DrawString("動画技術提供", 240 - 6 * 20 / 2, xx[24] / 100);
            DXDraw.DrawString("Ｋ先輩", 240 - 3 * 20 / 2, xx[25] / 100);
            DXDraw.DrawString("動画キャプチャ・編集・エンコード", 240 - 16 * 20 / 2, xx[26] / 100);
            DXDraw.DrawString("willowlet ", 240 - 5 * 20 / 2, xx[27] / 100);
            DXDraw.DrawString("プログラム・描画・ネタ・動画編集", 240 - 16 * 20 / 2, xx[28] / 100);
            DXDraw.DrawString("ちく", 240 - 2 * 20 / 2, xx[29] / 100);

            DXDraw.DrawString("プレイしていただき　ありがとうございました～", 240 - 22 * 20 / 2, xx[30] / 100);
        }

        static void Updateスタッフロール()
        {
            maintm++;

            xx[7] = 46;
            if (Key.GetKey(DX.KEY_INPUT_1))
            {
                DX.DxLib_End();
            }
            if (Key.GetKey(DX.KEY_INPUT_SPACE))
            {
                for (int t_ = 0; t_ <= xx[7]; t_ += 1)
                {
                    xx[12 + t_] -= 300;
                }
            }

            if (maintm <= 1)
            {
                maintm = 2; bgmChange(Res.nオーディオ_[106]); DX.PlaySoundMem(Res.nオーディオ_[0], DX.DX_PLAYTYPE_LOOP); xx[10] = 0;
                for (int t_ = 0; t_ <= xx[7]; t_ += 1) { xx[12 + t_] = 980000; }
                xx[12] = 460;
                xx[13] = 540; xx[14] = 590;
                xx[15] = 650; xx[16] = 700;
                xx[17] = 760; xx[18] = 810;
                xx[19] = 870; xx[20] = 920;

                xx[21] = 1000; xx[22] = 1050; xx[23] = 1100;
                xx[24] = 1180; xx[25] = 1230;

                xx[26] = 1360; xx[27] = 1410;
                xx[28] = 1540; xx[29] = 1590;

                xx[30] = 1800;

                for (int t_ = 0; t_ <= xx[7]; t_ += 1) { xx[12 + t_] *= 100; }
            }

            xx[10] += 1;
            for (int t_ = 0; t_ <= xx[7]; t_ += 1) { xx[12 + t_] -= 100; }//t

            if (xx[30] == -200) { bgmChange(Res.nオーディオ_[106]); }
            if (xx[30] <= -400) { e現在の画面 = E画面.Title; nokori = 2; maintm = 0; nスタッフロール = 0; }
        }
    }
}

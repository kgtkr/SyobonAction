﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        static void Updateタイトル()
        {
            maintm++; xx_0 = 0;
            if (maintm <= 10) { maintm = 11; nステージa = 1; nステージb = 1; nステージc = 0; over = 0; }

            if (Key.GetKey(DX.KEY_INPUT_1)) { nステージa = 1; nステージb = 1; nステージc = 0; }
            if (Key.GetKey(DX.KEY_INPUT_2)) { nステージa = 1; nステージb = 2; nステージc = 0; }
            if (Key.GetKey(DX.KEY_INPUT_3)) { nステージa = 1; nステージb = 3; nステージc = 0; }
            if (Key.GetKey(DX.KEY_INPUT_4)) { nステージa = 1; nステージb = 4; nステージc = 0; }
            if (Key.GetKey(DX.KEY_INPUT_5)) { nステージa = 2; nステージb = 1; nステージc = 0; }
            if (Key.GetKey(DX.KEY_INPUT_6)) { nステージa = 2; nステージb = 2; nステージc = 0; }
            if (Key.GetKey(DX.KEY_INPUT_7)) { nステージa = 2; nステージb = 3; nステージc = 0; }
            if (Key.GetKey(DX.KEY_INPUT_8)) { nステージa = 2; nステージb = 4; nステージc = 0; }
            if (Key.GetKey(DX.KEY_INPUT_9)) { nステージa = 3; nステージb = 1; nステージc = 0; }
            if (Key.GetKey(DX.KEY_INPUT_0)) { xx_0 = 1; over = 1; }


            if (Key.GetKey(DX.KEY_INPUT_RETURN)) { xx_0 = 1; }
            if (Key.GetKey(DX.KEY_INPUT_Z)) { xx_0 = 1; }

            if (xx_0 == 1)
            {
                e現在の画面 = E画面.機数表示; b初期化 = false; maintm = 0;
                nプレイヤー.nokori = 2;

                n中間フラグ = 0;
            }
        }

        static void Drawタイトル()
        {
            DXDraw.SetColor(160, 180, 250);
            DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);

            DXDraw.DrawGraph(Res.nタイトル画像, 240 - 380 / 2, 60);

            DXDraw.DrawGraph(Res.n切り取り画像[0, 4], 12 * 30, 10 * 29 - 12);
            DXDraw.DrawGraph(Res.n切り取り画像[1, 4], 6 * 30, 12 * 29 - 12);

            //プレイヤー
            DXDraw.DrawGraph(Res.n切り取り画像[0, 0], 2 * 30, 12 * 29 - 12 - 6);
            for (int t_ = 0; t_ <= 16; t_++)
            {
                DXDraw.DrawGraph(Res.n切り取り画像[5, 1], 29 * t_, 13 * 29 - 12);
                DXDraw.DrawGraph(Res.n切り取り画像[6, 1], 29 * t_, 14 * 29 - 12);
            }


            DXDraw.SetColor(0, 0, 0);
            DXDraw.DrawString("Enterキーを押せ!!", 240 - 8 * 20 / 2, 250);
        }
    }
}

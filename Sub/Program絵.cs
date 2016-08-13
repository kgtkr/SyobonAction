using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        class C絵
        {
            public int a,
            b,
            nobia,
            nobib,
            c,
            d;
            public int e,
                f,
                tm;
            public int gtype;
        }

        //効果を持たないグラ
        static List<C絵> n絵 = new List<C絵>();


        static void Update絵()
        {
            //グラ
            foreach (C絵 ce in n絵.ToArray())
            {
                xx_0 = ce.a - fx; xx_1 = ce.b - fy;
                xx_2 = ce.nobia / 100; xx_3 = ce.nobib / 100;
                if (ce.tm >= 0) ce.tm--;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= n画面幅 && xx_1 + xx_3 * 100 >= -10 - 8000 && xx_3 <= n画面高さ && ce.tm >= 0)
                {
                    ce.a += ce.c; ce.b += ce.d;
                    ce.c += ce.e; ce.d += ce.f;

                }
                else {
                    n絵.Remove(ce);
                }

            }//emax
        }

        static void Draw絵()
        {
            //グラ
            foreach (C絵 ce in n絵.ToArray())
            {
                xx_0 = ce.a - fx; xx_1 = ce.b - fy;
                xx_2 = ce.nobia / 100; xx_3 = ce.nobib / 100;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= n画面幅 && xx_1 + xx_3 * 100 >= -10 - 8000 && xx_3 <= n画面高さ)
                {

                    //コイン
                    if (ce.gtype == 0)
                        DXDraw.DrawGraph(Res.n切り取り画像[0, 2], xx_0 / 100, xx_1 / 100);

                    //ブロックの破片
                    if (ce.gtype == 1)
                    {
                        if (nステージ色 == 1 || nステージ色 == 3 || nステージ色 == 5) DXDraw.SetColor(9 * 16, 6 * 16, 3 * 16);
                        if (nステージ色 == 2) DXDraw.SetColor(0, 120, 160);
                        if (nステージ色 == 4) DXDraw.SetColor(192, 192, 192);

                        DXDraw.DrawOval塗り潰し(xx_0 / 100, xx_1 / 100, 7, 7);
                        DXDraw.SetColor(0, 0, 0);
                        DXDraw.DrawOval塗り無し(xx_0 / 100, xx_1 / 100, 7, 7);
                    }

                    //リフトの破片
                    if (ce.gtype == 2 || ce.gtype == 3)
                    {
                        if (ce.gtype == 3) DXDraw.nミラー = 1;
                        DXDraw.DrawGraph(Res.n切り取り画像[0, 5], xx_0 / 100, xx_1 / 100);
                        DXDraw.nミラー = 0;
                    }

                    //ポール
                    if (ce.gtype == 4)
                    {
                        DXDraw.SetColorWhite();
                        DXDraw.DrawBox塗り潰し((xx_0) / 100 + 10, (xx_1) / 100, 10, xx_3);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((xx_0) / 100 + 10, (xx_1) / 100, 10, xx_3);
                        DXDraw.SetColor(250, 250, 0);
                        DXDraw.DrawOval塗り潰し((xx_0) / 100 + 15 - 1, (xx_1) / 100, 10, 10);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawOval塗り無し((xx_0) / 100 + 15 - 1, (xx_1) / 100, 10, 10);
                    }


                }
            }
        }

        //グラ作成
        static void eyobi(C絵 ce, int xa, int xb, int xc, int xd, int xe, int xf, int xnobia, int xnobib, int xgtype, int xtm)
        {

            ce.a = xa; ce.b = xb; ce.c = xc; ce.d = xd; ce.e = xe; ce.f = xf;
            ce.gtype = xgtype; ce.tm = xtm;
            ce.nobia = xnobia; ce.nobib = xnobib;

        }//eyobi
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        struct C絵
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
        const int n絵max = 201;
        static int n絵co;
        static C絵[] n絵 = new C絵[n絵max];


        static void Update絵()
        {
            //グラ
            for (int t_ = 0; t_ < n絵max; t_++)
            {
                xx_0 = n絵[t_].a - fx; xx_1 = n絵[t_].b - fy;
                xx_2 = n絵[t_].nobia / 100; xx_3 = n絵[t_].nobib / 100;
                if (n絵[t_].tm >= 0) n絵[t_].tm--;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= n画面幅 && xx_1 + xx_3 * 100 >= -10 - 8000 && xx_3 <= n画面高さ && n絵[t_].tm >= 0)
                {
                    n絵[t_].a += n絵[t_].c; n絵[t_].b += n絵[t_].d;
                    n絵[t_].c += n絵[t_].e; n絵[t_].d += n絵[t_].f;

                }
                else { n絵[t_].a = -9000000; }

            }//emax
        }

        static void Draw絵()
        {
            //グラ
            for (int t_ = 0; t_ < n絵max; t_++)
            {
                xx_0 = n絵[t_].a - fx; xx_1 = n絵[t_].b - fy;
                xx_2 = n絵[t_].nobia / 100; xx_3 = n絵[t_].nobib / 100;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= n画面幅 && xx_1 + xx_3 * 100 >= -10 - 8000 && xx_3 <= n画面高さ)
                {

                    //コイン
                    if (n絵[t_].gtype == 0)
                        DXDraw.DrawGraph(Res.n切り取り画像[0, 2], xx_0 / 100, xx_1 / 100);

                    //ブロックの破片
                    if (n絵[t_].gtype == 1)
                    {
                        if (nステージ色 == 1 || nステージ色 == 3 || nステージ色 == 5) DXDraw.SetColor(9 * 16, 6 * 16, 3 * 16);
                        if (nステージ色 == 2) DXDraw.SetColor(0, 120, 160);
                        if (nステージ色 == 4) DXDraw.SetColor(192, 192, 192);

                        DXDraw.DrawOval塗り潰し(xx_0 / 100, xx_1 / 100, 7, 7);
                        DXDraw.SetColor(0, 0, 0);
                        DXDraw.DrawOval塗り無し(xx_0 / 100, xx_1 / 100, 7, 7);
                    }

                    //リフトの破片
                    if (n絵[t_].gtype == 2 || n絵[t_].gtype == 3)
                    {
                        if (n絵[t_].gtype == 3) DXDraw.nミラー = 1;
                        DXDraw.DrawGraph(Res.n切り取り画像[0, 5], xx_0 / 100, xx_1 / 100);
                        DXDraw.nミラー = 0;
                    }

                    //ポール
                    if (n絵[t_].gtype == 4)
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
    }
}

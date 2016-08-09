using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        //効果を持たないグラ
        const int n絵max = 201;
        static int n絵co;
        static int[] n絵a = new int[n絵max],
            n絵b = new int[n絵max],
            n絵nobia = new int[n絵max],
            n絵nobib = new int[n絵max],
            n絵c = new int[n絵max],
            n絵d = new int[n絵max];
        static int[] n絵e = new int[n絵max],
            n絵f = new int[n絵max],
            n絵tm = new int[n絵max];
        static int[] n絵gtype = new int[n絵max];

        static void Update絵()
        {
            //グラ
            for (int t_ = 0; t_ < n絵max; t_++)
            {
                xx_0 = n絵a[t_] - fx; xx_1 = n絵b[t_] - fy;
                xx_2 = n絵nobia[t_] / 100; xx_3 = n絵nobib[t_] / 100;
                if (n絵tm[t_] >= 0) n絵tm[t_]--;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= n画面幅 && xx_1 + xx_3 * 100 >= -10 - 8000 && xx_3 <= n画面高さ && n絵tm[t_] >= 0)
                {
                    n絵a[t_] += n絵c[t_]; n絵b[t_] += n絵d[t_];
                    n絵c[t_] += n絵e[t_]; n絵d[t_] += n絵f[t_];

                }
                else { n絵a[t_] = -9000000; }

            }//emax
        }

        static void Draw絵()
        {
            //グラ
            for (int t_ = 0; t_ < n絵max; t_++)
            {
                xx_0 = n絵a[t_] - fx; xx_1 = n絵b[t_] - fy;
                xx_2 = n絵nobia[t_] / 100; xx_3 = n絵nobib[t_] / 100;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= n画面幅 && xx_1 + xx_3 * 100 >= -10 - 8000 && xx_3 <= n画面高さ)
                {

                    //コイン
                    if (n絵gtype[t_] == 0)
                        DXDraw.DrawGraph(Res.n切り取り画像_[0, 2], xx_0 / 100, xx_1 / 100);

                    //ブロックの破片
                    if (n絵gtype[t_] == 1)
                    {
                        if (nステージ色 == 1 || nステージ色 == 3 || nステージ色 == 5) DXDraw.SetColor(9 * 16, 6 * 16, 3 * 16);
                        if (nステージ色 == 2) DXDraw.SetColor(0, 120, 160);
                        if (nステージ色 == 4) DXDraw.SetColor(192, 192, 192);

                        DXDraw.DrawOval塗り潰し(xx_0 / 100, xx_1 / 100, 7, 7);
                        DXDraw.SetColor(0, 0, 0);
                        DXDraw.DrawOval塗り無し(xx_0 / 100, xx_1 / 100, 7, 7);
                    }

                    //リフトの破片
                    if (n絵gtype[t_] == 2 || n絵gtype[t_] == 3)
                    {
                        if (n絵gtype[t_] == 3) DXDraw.nミラー = 1;
                        DXDraw.DrawGraph(Res.n切り取り画像_[0, 5], xx_0 / 100, xx_1 / 100);
                        DXDraw.nミラー = 0;
                    }

                    //ポール
                    if (n絵gtype[t_] == 4)
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

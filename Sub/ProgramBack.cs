using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        struct C背景
        {
            public int a,
            b,
            c,
            d,
            type;
            public int g;
        }

        //背景
        const int n背景max = 41;
        static int n背景co;
        static C背景[] n背景 = new C背景[n背景max];

        static void DrawBack()
        {
            //背景
            for (int t_ = 0; t_ < n背景max; t_++)
            {
                xx_0 = n背景[t_].a - fx;
                xx_1 = n背景[t_].b - fy;
                xx_2 = 16000;
                xx_3 = 16000;

                if (xx_0 + xx_2 >= -10 && xx_0 <= n画面幅 && xx_1 + xx_3 >= -10 && xx_3 <= n画面高さ)
                {

                    if (n背景[t_].type != 3)
                    {
                        if ((n背景[t_].type == 1 || n背景[t_].type == 2) && nステージ色 == 5)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[n背景[t_].type + 30, 4], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像[n背景[t_].type, 4], xx_0 / 100, xx_1 / 100);
                        }
                    }
                    if (n背景[t_].type == 3)
                        DXDraw.DrawGraph(Res.n切り取り画像[n背景[t_].type, 4], xx_0 / 100 - 5, xx_1 / 100);

                    //51
                    if (n背景[t_].type == 100)
                    {
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "51", DX.GetColor(255, 255, 255));
                    }

                    if (n背景[t_].type == 101)
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "ゲームクリアー", DX.GetColor(255, 255, 255));
                    if (n背景[t_].type == 102)
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "プレイしてくれてありがとー", DX.GetColor(255, 255, 255));

                }
            }//t
        }
    }
}

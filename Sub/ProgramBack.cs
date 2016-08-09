﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        //背景
        const int n背景max = 41;
        static int n背景co;
        static int[] n背景a = new int[n背景max],
            n背景b = new int[n背景max],
            n背景c = new int[n背景max],
            n背景d = new int[n背景max],
            n背景type = new int[n背景max];
        static int[] n背景g = new int[n背景max],
            n背景x = new int[n背景max];

        static void DrawBack()
        {
            //背景
            for (int t_ = 0; t_ < n背景max; t_++)
            {
                xx_0 = n背景a[t_] - fx;
                xx_1 = n背景b[t_] - fy;
                xx_2 = 16000;
                xx_3 = 16000;

                if (xx_0 + xx_2 >= -10 && xx_0 <= W && xx_1 + xx_3 >= -10 && xx_3 <= H)
                {

                    if (n背景type[t_] != 3)
                    {
                        if ((n背景type[t_] == 1 || n背景type[t_] == 2) && nステージ色 == 5)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[n背景type[t_] + 30, 4], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像_[n背景type[t_], 4], xx_0 / 100, xx_1 / 100);
                        }
                    }
                    if (n背景type[t_] == 3)
                        DXDraw.DrawGraph(Res.n切り取り画像_[n背景type[t_], 4], xx_0 / 100 - 5, xx_1 / 100);

                    //51
                    if (n背景type[t_] == 100)
                    {
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "51", DX.GetColor(255, 255, 255));
                    }

                    if (n背景type[t_] == 101)
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "ゲームクリアー", DX.GetColor(255, 255, 255));
                    if (n背景type[t_] == 102)
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "プレイしてくれてありがとー", DX.GetColor(255, 255, 255));

                }
            }//t
        }
    }
}

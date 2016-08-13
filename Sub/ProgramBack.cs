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
        class C背景
        {
            public int a,
            b,
            c=1,
            d=1,
            type;
            public int g;
        }

        //背景
        static List<C背景> n背景 = new List<C背景>();

        static void DrawBack()
        {
            //背景
            foreach (C背景 cb in n背景.ToArray())
            {
                xx_0 = cb.a - fx;
                xx_1 = cb.b - fy;
                xx_2 = 16000;
                xx_3 = 16000;

                if (xx_0 + xx_2 >= -10 && xx_0 <= n画面幅 && xx_1 + xx_3 >= -10 && xx_3 <= n画面高さ)
                {

                    if (cb.type != 3)
                    {
                        if ((cb.type == 1 || cb.type == 2) && nステージ色 == 5)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[cb.type + 30, 4], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像[cb.type, 4], xx_0 / 100, xx_1 / 100);
                        }
                    }
                    if (cb.type == 3)
                        DXDraw.DrawGraph(Res.n切り取り画像[cb.type, 4], xx_0 / 100 - 5, xx_1 / 100);

                    //51
                    if (cb.type == 100)
                    {
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "51", DX.GetColor(255, 255, 255));
                    }

                    if (cb.type == 101)
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "ゲームクリアー", DX.GetColor(255, 255, 255));
                    if (cb.type == 102)
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "プレイしてくれてありがとー", DX.GetColor(255, 255, 255));

                }
            }//t
        }
    }
}

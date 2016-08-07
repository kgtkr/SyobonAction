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
        static void DrawBack()
        {
            //背景
            for (t_ = 0; t_ < n背景max; t_++)
            {
                xx[0] = n背景a[t_] - fx; xx[1] = n背景b[t_] - fy;
                xx[2] = n背景サイズW_[n背景type[t_]] * 100; xx[3] = n背景サイズH_[n背景type[t_]] * 100;
                xx[2] = 16000; xx[3] = 16000;

                if (xx[0] + xx[2] >= -10 && xx[0] <= n画面幅 && xx[1] + xx[3] >= -10 && xx[3] <= n画面高さ)
                {

                    if (n背景type[t_] != 3)
                    {
                        if ((n背景type[t_] == 1 || n背景type[t_] == 2) && nステージ色 == 5)
                        {
                            DXDraw.DrawGraph(n切り取り画像_[n背景type[t_] + 30, 4], xx[0] / 100, xx[1] / 100);
                        }
                        else {
                            DXDraw.DrawGraph(n切り取り画像_[n背景type[t_], 4], xx[0] / 100, xx[1] / 100);
                        }
                    }
                    if (n背景type[t_] == 3)
                        DXDraw.DrawGraph(n切り取り画像_[n背景type[t_], 4], xx[0] / 100 - 5, xx[1] / 100);

                    //51
                    if (n背景type[t_] == 100)
                    {
                        DX.DrawString(xx[0] / 100 + n全体のポイントa, xx[1] / 100 + n全体のポイントb, "51", DX.GetColor(255, 255, 255));
                    }

                    if (n背景type[t_] == 101)
                        DX.DrawString(xx[0] / 100 + n全体のポイントa, xx[1] / 100 + n全体のポイントb, "ゲームクリアー", DX.GetColor(255, 255, 255));
                    if (n背景type[t_] == 102)
                        DX.DrawString(xx[0] / 100 + n全体のポイントa, xx[1] / 100 + n全体のポイントb, "プレイしてくれてありがとー", DX.GetColor(255, 255, 255));

                }
            }//t
        }
    }
}

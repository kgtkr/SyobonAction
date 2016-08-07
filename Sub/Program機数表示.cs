using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        static void Draw機数表示()
        {
            DXDraw.SetColorBlack();
            DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);

            DX.SetFontSize(16);
            DX.SetFontThickness(4);

            DXDraw.DrawGraph(n切り取り画像_[0, 0], 190, 190);
            DX.DrawString(230, 200, " × " + nokori, DX.GetColor(255, 255, 255));
        }
    }
}

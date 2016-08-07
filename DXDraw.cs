using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace SyobonAction
{
    public static class DXDraw
    {
        
        public static uint n色;
        public static int nミラー;

        public static void SetColor(int red, int green, int blue)
        {
            n色 = DX.GetColor(red, green, blue);
        }

        public static void SetColorBlack() {
            n色 = DX.GetColor(0, 0, 0);
        }
        public static void SetColorWhite() {
            n色 = DX.GetColor(255, 255, 255);
        }

        //点
        public static void drawpixel(int a, int b) {
            DX.DrawPixel(a, b, n色);
        }
        //線
        public static void DrawLine(int a, int b, int c, int d) {
            DX.DrawLine(a, b, c, d, n色);
        }
        //四角形(塗り無し)
        public static void DrawBox塗り無し(int a, int b, int c, int d) {
            DX.DrawBox(a, b, a + c, b + d, n色, DX.FALSE);
        }
        //四角形(塗り有り)
        public static void DrawBox塗り潰し(int a, int b, int c, int d) {
            DX.DrawBox(a, b, a + c, b + d, n色, DX.TRUE);
        }
        //円(塗り無し)
        public static void DrawOval塗り無し(int a, int b, int c, int d) {
            DX.DrawOval(a, b, c, d, n色, DX.FALSE);
        }
        //円(塗り有り)
        public static void DrawOval塗り潰し(int a, int b, int c, int d) {
            DX.DrawOval(a, b, c, d, n色, DX.TRUE);
        }

        //画像表示
        public static void DrawGraph(int img, int x, int y)
        {
            if (nミラー == 0)
                DX.DrawGraph(x, y, img, DX.TRUE);
            if (nミラー == 1)
                DX.DrawTurnGraph(x, y, img, DX.TRUE);
        }
        public static void DrawGraph(int mx, int a, int b, int c, int d, int e, int f)
        {
            int m;
            m = DX.DerivationGraph(c, d, e, f, mx);
            if (nミラー == 0)
                DX.DrawGraph(a, b, m, DX.TRUE);
            if (nミラー == 1)
                DX.DrawTurnGraph(a, b, m, DX.TRUE);
        }

        //文字
        public static void DrawString(string x, int a, int b)
        {
            DX.DrawString(a, b, x, n色);

            Program.xx[2] = 4;


        }
    }
}

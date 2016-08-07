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
        public static void DrawPixel(int x, int y) {
            DX.DrawPixel(x, y, n色);
        }
        //線
        public static void DrawLine(int x1, int y1, int x2, int y2) {
            DX.DrawLine(x1, y1, x2, y2, n色);
        }
        //四角形(塗り無し)
        public static void DrawBox塗り無し(int x, int y, int w, int h) {
            DX.DrawBox(x, y, x + w, y + h, n色, DX.FALSE);
        }
        //四角形(塗り有り)
        public static void DrawBox塗り潰し(int x, int y, int w, int h) {
            DX.DrawBox(x, y, x + w, y + h, n色, DX.TRUE);
        }
        //円(塗り無し)
        public static void DrawOval塗り無し(int x, int y, int rx, int ry) {
            DX.DrawOval(x, y, rx, ry, n色, DX.FALSE);
        }
        //円(塗り有り)
        public static void DrawOval塗り潰し(int x, int y, int rx, int ry) {
            DX.DrawOval(x, y, rx, ry, n色, DX.TRUE);
        }

        //画像表示
        public static void DrawGraph(int img, int x, int y)
        {
            if (nミラー == 0)
                DX.DrawGraph(x, y, img, DX.TRUE);
            if (nミラー == 1)
                DX.DrawTurnGraph(x, y, img, DX.TRUE);
        }
        public static void DrawGraph(int img, int x, int y, int imgX, int imgY, int imgW, int imgH)
        {
            int m;
            m = DX.DerivationGraph(imgX, imgY, imgW, imgH, img);
            if (nミラー == 0)
                DX.DrawGraph(x, y, m, DX.TRUE);
            if (nミラー == 1)
                DX.DrawTurnGraph(x, y, m, DX.TRUE);
        }

        //文字
        public static void DrawString(string str, int x, int y)
        {
            DX.DrawString(x, y, str, n色);

            Program.xx[2] = 4;


        }
    }
}

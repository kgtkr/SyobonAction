using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyobonAction
{
    static partial class Program
    {
        static int ma;

        //String 使用

        //プログラム中
        //main-10
        //タイトル-100
        static E画面 e現在の画面 = E画面.Title;
        static int maintm = 0;

        enum E画面
        {
            Game=1,
            Title=100,
            Ending=2,
            機数表示=10,

        }

        //ステージ
        static int nステージ色 = 0;//1～5
        static int nステージa = 1, nステージb = 4, nステージc = 0;

        //トラップ表示(デパッグ)
        public const bool bトラップ表示 = false;

        //中間ゲート
        static int n中間フラグ = 0;

        //スタッフロール
        static int nスタッフロール = 0;


        //ステージ読み込みループ(いじらない)
        static bool stagepoint;
        //オーバーフローさせる
        static int over;

        //ステージスイッチ
        static bool bステージスイッチ = false;

        //初期化
        static bool b初期化;

        static int maScrollMax = 21000;//9000

        //スクロール範囲
        static int fx = 0, fy = 0, fzx, scrollX;
        //全体のポイント
        static int n全体のポイントa = 0, n全体のポイントb = 0;
        //強制スクロール
        static int n強制スクロール = 0;
        //画面サイズ(ファミコンサイズ×2)(256-224)
        public const int W = 48000, H = 42000;

        //ステージ
        static byte[,] stageDate = new byte[17, 2001];

        //画面黒
        static int blackTm = 1, blackX = 0;


        #region xx
        public static int xx_0;
        public static int xx_1;
        public static int xx_2;
        public static int xx_3;
        public static int xx_4;
        public static int xx_5;
        public static int xx_6;
        public static int xx_7;
        public static int xx_8;
        public static int xx_9;
        public static int xx_10;
        public static int xx_11;
        public static int xx_12;
        public static int xx_13;
        public static int xx_14;
        public static int xx_15;
        public static int xx_16;
        public static int xx_17;
        public static int xx_21;
        public static int xx_22;
        public static int xx_23;
        public static int xx_24;
        public static int xx_25;
        public static int xx_26;
        #endregion
    }
}
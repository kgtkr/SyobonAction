using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace SyobonAction
{
    static class Res
    {
        public struct Cサイズ
        {
            public int w, h;
        }

        //[x,y]とすると
        //x=プレイヤー:0、ブロック=1・5、アイテム=2、敵=3、背景=4、グラ=5
        public static int[,] n切り取り画像 = new int[161, 8];
        public static int nタイトル画像;
        #region オーディオ
        public static int n現在のBGM;
        public static int nオーディオ1;
        public static int nオーディオ3;
        public static int nオーディオ4;
        public static int nオーディオ5;
        public static int nオーディオ6;
        public static int nオーディオ7;
        public static int nオーディオ8;
        public static int nオーディオ9;
        public static int nオーディオ10;
        public static int nオーディオ11;
        public static int nオーディオ12;
        public static int nオーディオ13;
        public static int nオーディオ14;
        public static int nオーディオ15;
        public static int nオーディオ16;
        public static int nオーディオ17;
        public static int nオーディオ18;
        public static int nオーディオ100;
        public static int nオーディオ103;
        public static int nオーディオ104;
        public static int nオーディオ105;
        public static int nオーディオ106;
        #endregion

        public static Cサイズ[] n敵サイズ = new Cサイズ[160];
        public static Cサイズ[] n背景サイズ = new Cサイズ[41];
        /*
        public static int[] n敵サイズw = new int[160];
        public static int[] n敵サイズh = new int[160];
        public static int[] n背景サイズw = new int[41];
        public static int[] n背景サイズh = new int[41];*/

        public static void Init()
        {
            int[] n元画像_ = new int[51];
            
            //プレイヤー
            n元画像_[0] = DX.LoadGraph("res/player.png");
            //ブロック
            n元画像_[1] = DX.LoadGraph("res/brock.png");
            //アイテム
            n元画像_[2] = DX.LoadGraph("res/item.png");
            //敵
            n元画像_[3] = DX.LoadGraph("res/teki.png");
            //背景
            n元画像_[4] = DX.LoadGraph("res/haikei.png");
            //ブロック2
            n元画像_[5] = DX.LoadGraph("res/brock2.png");
            //おまけ
            n元画像_[6] = DX.LoadGraph("res/omake.png");
            //おまけ2
            n元画像_[7] = DX.LoadGraph("res/omake2.png");
            //タイトル
            nタイトル画像 = DX.LoadGraph("res/syobon3.PNG");


            //プレイヤー読み込み
            n切り取り画像[40, 0] = DX.DerivationGraph(0, 0, 30, 36, n元画像_[0]);
            n切り取り画像[0, 0] = DX.DerivationGraph(31 * 4, 0, 30, 36, n元画像_[0]);
            n切り取り画像[1, 0] = DX.DerivationGraph(31 * 1, 0, 30, 36, n元画像_[0]);
            n切り取り画像[2, 0] = DX.DerivationGraph(31 * 2, 0, 30, 36, n元画像_[0]);
            n切り取り画像[3, 0] = DX.DerivationGraph(31 * 3, 0, 30, 36, n元画像_[0]);
            n切り取り画像[41, 0] = DX.DerivationGraph(50, 0, 51, 73, n元画像_[6]);

            int x1_ = 1;
            //ブロック読み込み
            for (int i = 0; i <= 6; i++)
            {
                n切り取り画像[i, x1_] = DX.DerivationGraph(33 * i, 0, 30, 30, n元画像_[x1_]);
                n切り取り画像[i + 30, x1_] = DX.DerivationGraph(33 * i, 33, 30, 30, n元画像_[x1_]);
                n切り取り画像[i + 60, x1_] = DX.DerivationGraph(33 * i, 66, 30, 30, n元画像_[x1_]);
                n切り取り画像[i + 90, x1_] = DX.DerivationGraph(33 * i, 99, 30, 30, n元画像_[x1_]);
            }
            n切り取り画像[8, x1_] = DX.DerivationGraph(33 * 7, 0, 30, 30, n元画像_[x1_]);
            n切り取り画像[16, x1_] = DX.DerivationGraph(33 * 6, 0, 24, 27, n元画像_[2]);
            n切り取り画像[10, x1_] = DX.DerivationGraph(33 * 9, 0, 30, 30, n元画像_[x1_]);
            n切り取り画像[40, x1_] = DX.DerivationGraph(33 * 9, 33, 30, 30, n元画像_[x1_]);
            n切り取り画像[70, x1_] = DX.DerivationGraph(33 * 9, 66, 30, 30, n元画像_[x1_]);
            n切り取り画像[100, x1_] = DX.DerivationGraph(33 * 9, 99, 30, 30, n元画像_[x1_]);
            //ブロック読み込み2
            x1_ = 5;
            for (int i = 0; i <= 6; i++)
            {
                n切り取り画像[i, x1_] = DX.DerivationGraph(33 * i, 0, 30, 30, n元画像_[x1_]);
            }
            n切り取り画像[10, 5] = DX.DerivationGraph(33 * 1, 33, 30, 30, n元画像_[x1_]);
            n切り取り画像[11, 5] = DX.DerivationGraph(33 * 2, 33, 30, 30, n元画像_[x1_]);
            n切り取り画像[12, 5] = DX.DerivationGraph(33 * 0, 66, 30, 30, n元画像_[x1_]);
            n切り取り画像[13, 5] = DX.DerivationGraph(33 * 1, 66, 30, 30, n元画像_[x1_]);
            n切り取り画像[14, 5] = DX.DerivationGraph(33 * 2, 66, 30, 30, n元画像_[x1_]);

            //アイテム読み込み
            x1_ = 2;
            for (int i = 0; i <= 5; i++)
            {
                n切り取り画像[i, x1_] = DX.DerivationGraph(33 * i, 0, 30, 30, n元画像_[x1_]);
            }

            //敵キャラ読み込み
            x1_ = 3;
            n切り取り画像[0, x1_] = DX.DerivationGraph(33 * 0, 0, 30, 30, n元画像_[x1_]);
            n切り取り画像[1, x1_] = DX.DerivationGraph(33 * 1, 0, 30, 43, n元画像_[x1_]);
            n切り取り画像[2, x1_] = DX.DerivationGraph(33 * 2, 0, 30, 30, n元画像_[x1_]);
            n切り取り画像[3, x1_] = DX.DerivationGraph(33 * 3, 0, 30, 44, n元画像_[x1_]);
            n切り取り画像[4, x1_] = DX.DerivationGraph(33 * 4, 0, 33, 35, n元画像_[x1_]);
            n切り取り画像[5, x1_] = DX.DerivationGraph(0, 0, 37, 55, n元画像_[7]);
            n切り取り画像[6, x1_] = DX.DerivationGraph(38 * 2, 0, 36, 50, n元画像_[7]);
            n切り取り画像[150, x1_] = DX.DerivationGraph(38 * 2 + 37 * 2, 0, 36, 50, n元画像_[7]);
            n切り取り画像[7, x1_] = DX.DerivationGraph(33 * 6 + 1, 0, 32, 32, n元画像_[x1_]);
            n切り取り画像[8, x1_] = DX.DerivationGraph(38 * 2 + 37 * 3, 0, 37, 47, n元画像_[7]);
            n切り取り画像[151, x1_] = DX.DerivationGraph(38 * 3 + 37 * 3, 0, 37, 47, n元画像_[7]);
            n切り取り画像[9, x1_] = DX.DerivationGraph(33 * 7 + 1, 0, 26, 30, n元画像_[x1_]);
            n切り取り画像[10, x1_] = DX.DerivationGraph(214, 0, 46, 16, n元画像_[6]);

            //モララー
            n切り取り画像[30, x1_] = DX.DerivationGraph(0, 56, 30, 36, n元画像_[7]);
            n切り取り画像[155, x1_] = DX.DerivationGraph(31 * 3, 56, 30, 36, n元画像_[7]);
            n切り取り画像[31, x1_] = DX.DerivationGraph(50, 74, 49, 79, n元画像_[6]);


            n切り取り画像[80, x1_] = DX.DerivationGraph(151, 31, 70, 40, n元画像_[4]);
            n切り取り画像[81, x1_] = DX.DerivationGraph(151, 72, 70, 40, n元画像_[4]);
            n切り取り画像[130, x1_] = DX.DerivationGraph(151 + 71, 72, 70, 40, n元画像_[4]);
            n切り取り画像[82, x1_] = DX.DerivationGraph(33 * 1, 0, 30, 30, n元画像_[5]);
            n切り取り画像[83, x1_] = DX.DerivationGraph(0, 0, 49, 48, n元画像_[6]);
            n切り取り画像[84, x1_] = DX.DerivationGraph(33 * 5 + 1, 0, 30, 30, n元画像_[x1_]);
            n切り取り画像[86, x1_] = DX.DerivationGraph(102, 66, 49, 59, n元画像_[6]);
            n切り取り画像[152, x1_] = DX.DerivationGraph(152, 66, 49, 59, n元画像_[6]);

            n切り取り画像[90, x1_] = DX.DerivationGraph(102, 0, 64, 63, n元画像_[6]);

            n切り取り画像[100, x1_] = DX.DerivationGraph(33 * 1, 0, 30, 30, n元画像_[2]);
            n切り取り画像[101, x1_] = DX.DerivationGraph(33 * 7, 0, 30, 30, n元画像_[2]);
            n切り取り画像[102, x1_] = DX.DerivationGraph(33 * 3, 0, 30, 30, n元画像_[2]);

            n切り取り画像[105, x1_] = DX.DerivationGraph(33 * 5, 0, 30, 30, n元画像_[2]);
            n切り取り画像[110, x1_] = DX.DerivationGraph(33 * 4, 0, 30, 30, n元画像_[2]);


            //背景読み込み
            x1_ = 4;
            n切り取り画像[0, x1_] = DX.DerivationGraph(0, 0, 150, 90, n元画像_[x1_]);
            n切り取り画像[1, x1_] = DX.DerivationGraph(151, 0, 65, 29, n元画像_[x1_]);
            n切り取り画像[2, x1_] = DX.DerivationGraph(151, 31, 70, 40, n元画像_[x1_]);
            n切り取り画像[3, x1_] = DX.DerivationGraph(0, 91, 100, 90, n元画像_[x1_]);
            n切り取り画像[4, x1_] = DX.DerivationGraph(151, 113, 51, 29, n元画像_[x1_]);
            n切り取り画像[5, x1_] = DX.DerivationGraph(222, 0, 28, 60, n元画像_[x1_]);
            n切り取り画像[6, x1_] = DX.DerivationGraph(151, 143, 90, 40, n元画像_[x1_]);
            n切り取り画像[30, x1_] = DX.DerivationGraph(293, 0, 149, 90, n元画像_[x1_]);
            n切り取り画像[31, x1_] = DX.DerivationGraph(293, 92, 64, 29, n元画像_[x1_]);

            //中間フラグ
            n切り取り画像[20, x1_] = DX.DerivationGraph(40, 182, 40, 60, n元画像_[x1_]);


            //グラ
            x1_ = 5;
            n切り取り画像[0, x1_] = DX.DerivationGraph(167, 0, 45, 45, n元画像_[6]);


            //敵サイズ収得
            x1_ = 3;
            for (int i = 0; i <= 140; i++)
            {
                DX.GetGraphSize(n切り取り画像[i, x1_], out n敵サイズ[i].w, out n敵サイズ[i].h);
                n敵サイズ[i].w *= 100;
                n敵サイズ[i].h *= 100;
            }
            n敵サイズ[79].w = 120 * 100;
            n敵サイズ[79].h = 15 * 100;
            n敵サイズ[85].w = 25 * 100;
            n敵サイズ[85].h = 30 * 10 * 100;

            //背景サイズ収得
            x1_ = 4;
            for (int i = 0; i < 40; i++)
            {
                DX.GetGraphSize(n切り取り画像[i, x1_], out n背景サイズ[i].w, out n背景サイズ[i].h);
            }

            DX.SetCreateSoundDataType(DX.DX_SOUNDDATATYPE_MEMPRESS);
            nオーディオ100 = DX.LoadSoundMem("BGM/field.ogg");
            nオーディオ103 = DX.LoadSoundMem("BGM/dungeon.ogg");
            nオーディオ104 = DX.LoadSoundMem("BGM/star4.ogg");
            nオーディオ105 = DX.LoadSoundMem("BGM/castle.ogg");
            nオーディオ106 = DX.LoadSoundMem("BGM/puyo.ogg");

            DX.SetCreateSoundDataType(DX.DX_SOUNDDATATYPE_MEMNOPRESS);
            nオーディオ1 = DX.LoadSoundMem("SE/jump.wav");
            nオーディオ3 = DX.LoadSoundMem("SE/brockbreak.wav");
            nオーディオ4 = DX.LoadSoundMem("SE/coin.wav");
            nオーディオ5 = DX.LoadSoundMem("SE/humi.wav");
            nオーディオ6 = DX.LoadSoundMem("SE/koura.wav");
            nオーディオ7 = DX.LoadSoundMem("SE/dokan.wav");
            nオーディオ8 = DX.LoadSoundMem("SE/brockkinoko.wav");
            nオーディオ9 = DX.LoadSoundMem("SE/powerup.wav");
            nオーディオ10 = DX.LoadSoundMem("SE/kirra.wav");
            nオーディオ11 = DX.LoadSoundMem("SE/goal.wav");
            nオーディオ12 = DX.LoadSoundMem("SE/death.wav");
            nオーディオ13 = DX.LoadSoundMem("SE/Pswitch.wav");
            nオーディオ14 = DX.LoadSoundMem("SE/jumpBlock.wav");
            nオーディオ15 = DX.LoadSoundMem("SE/hintBlock.wav");
            nオーディオ16 = DX.LoadSoundMem("SE/4-clear.wav");
            nオーディオ17 = DX.LoadSoundMem("SE/allclear.wav");
            nオーディオ18 = DX.LoadSoundMem("SE/tekifire.wav");


            x1_ = 40;
            DX.ChangeVolumeSoundMem(255 * x1_ / 100, nオーディオ103);
        }
    }
}
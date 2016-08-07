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
         static int ma;
         static int t;
         static int tt;
         static int[,] n切り取り画像 = new int[161, 8];
         static int[] n元画像 = new int[51];
         static int x1;
         static int[] nオーディオ = new int[151];

         static int[] n敵サイズW = new int[160];
         static int[] n敵サイズH = new int[160];
         static int[] n背景サイズW = new int[41];
         static int[] n背景サイズH = new int[41];

         static void Load()
        {
            //プレイヤー
            n元画像[0] = DX.LoadGraph("res/player.png");
            //ブロック
            n元画像[1] = DX.LoadGraph("res/brock.png");
            //アイテム
            n元画像[2] = DX.LoadGraph("res/item.png");
            //敵
            n元画像[3] = DX.LoadGraph("res/teki.png");
            //背景
            n元画像[4] = DX.LoadGraph("res/haikei.png");
            //ブロック2
            n元画像[5] = DX.LoadGraph("res/brock2.png");
            //おまけ
            n元画像[6] = DX.LoadGraph("res/omake.png");
            //おまけ2
            n元画像[7] = DX.LoadGraph("res/omake2.png");
            //タイトル
            n元画像[30] = DX.LoadGraph("res/syobon3.PNG");


            //プレイヤー読み込み
            n切り取り画像[40,0] = DX.DerivationGraph(0, 0, 30, 36, n元画像[0]);
            n切り取り画像[0,0] = DX.DerivationGraph(31 * 4, 0, 30, 36, n元画像[0]);
            n切り取り画像[1,0] = DX.DerivationGraph(31 * 1, 0, 30, 36, n元画像[0]);
            n切り取り画像[2,0] = DX.DerivationGraph(31 * 2, 0, 30, 36, n元画像[0]);
            n切り取り画像[3,0] = DX.DerivationGraph(31 * 3, 0, 30, 36, n元画像[0]);
            n切り取り画像[41,0] = DX.DerivationGraph(50, 0, 51, 73, n元画像[6]);

            x1 = 1;
            //ブロック読み込み
            for (t = 0; t <= 6; t++)
            {
                n切り取り画像[t,x1] = DX.DerivationGraph(33 * t, 0, 30, 30, n元画像[x1]);
                n切り取り画像[t + 30,x1] = DX.DerivationGraph(33 * t, 33, 30, 30, n元画像[x1]);
                n切り取り画像[t + 60,x1] = DX.DerivationGraph(33 * t, 66, 30, 30, n元画像[x1]);
                n切り取り画像[t + 90,x1] = DX.DerivationGraph(33 * t, 99, 30, 30, n元画像[x1]);
            }
            n切り取り画像[8,x1] = DX.DerivationGraph(33 * 7, 0, 30, 30, n元画像[x1]);
            n切り取り画像[16,x1] = DX.DerivationGraph(33 * 6, 0, 24, 27, n元画像[2]);
            n切り取り画像[10,x1] = DX.DerivationGraph(33 * 9, 0, 30, 30, n元画像[x1]);
            n切り取り画像[40,x1] = DX.DerivationGraph(33 * 9, 33, 30, 30, n元画像[x1]);
            n切り取り画像[70,x1] = DX.DerivationGraph(33 * 9, 66, 30, 30, n元画像[x1]);
            n切り取り画像[100,x1] = DX.DerivationGraph(33 * 9, 99, 30, 30, n元画像[x1]);
            //ブロック読み込み2
            x1 = 5;
            for (t = 0; t <= 6; t++)
            {
                n切り取り画像[t,x1] = DX.DerivationGraph(33 * t, 0, 30, 30, n元画像[x1]);
            }
            n切り取り画像[10,5] = DX.DerivationGraph(33 * 1, 33, 30, 30, n元画像[x1]);
            n切り取り画像[11,5] = DX.DerivationGraph(33 * 2, 33, 30, 30, n元画像[x1]);
            n切り取り画像[12,5] = DX.DerivationGraph(33 * 0, 66, 30, 30, n元画像[x1]);
            n切り取り画像[13,5] = DX.DerivationGraph(33 * 1, 66, 30, 30, n元画像[x1]);
            n切り取り画像[14,5] = DX.DerivationGraph(33 * 2, 66, 30, 30, n元画像[x1]);

            //アイテム読み込み
            x1 = 2;
            for (t = 0; t <= 5; t++)
            {
                n切り取り画像[t,x1] = DX.DerivationGraph(33 * t, 0, 30, 30, n元画像[x1]);
            }

            //敵キャラ読み込み
            x1 = 3;
            n切り取り画像[0,x1] = DX.DerivationGraph(33 * 0, 0, 30, 30, n元画像[x1]);
            n切り取り画像[1,x1] = DX.DerivationGraph(33 * 1, 0, 30, 43, n元画像[x1]);
            n切り取り画像[2,x1] = DX.DerivationGraph(33 * 2, 0, 30, 30, n元画像[x1]);
            n切り取り画像[3,x1] = DX.DerivationGraph(33 * 3, 0, 30, 44, n元画像[x1]);
            n切り取り画像[4,x1] = DX.DerivationGraph(33 * 4, 0, 33, 35, n元画像[x1]);
            n切り取り画像[5,x1] = DX.DerivationGraph(0, 0, 37, 55, n元画像[7]);
            n切り取り画像[6,x1] = DX.DerivationGraph(38 * 2, 0, 36, 50, n元画像[7]);
            n切り取り画像[150,x1] = DX.DerivationGraph(38 * 2 + 37 * 2, 0, 36, 50, n元画像[7]);
            n切り取り画像[7,x1] = DX.DerivationGraph(33 * 6 + 1, 0, 32, 32, n元画像[x1]);
            n切り取り画像[8,x1] = DX.DerivationGraph(38 * 2 + 37 * 3, 0, 37, 47, n元画像[7]);
            n切り取り画像[151,x1] = DX.DerivationGraph(38 * 3 + 37 * 3, 0, 37, 47, n元画像[7]);
            n切り取り画像[9,x1] = DX.DerivationGraph(33 * 7 + 1, 0, 26, 30, n元画像[x1]);
            n切り取り画像[10,x1] = DX.DerivationGraph(214, 0, 46, 16, n元画像[6]);

            //モララー
            n切り取り画像[30,x1] = DX.DerivationGraph(0, 56, 30, 36, n元画像[7]);
            n切り取り画像[155,x1] = DX.DerivationGraph(31 * 3, 56, 30, 36, n元画像[7]);
            n切り取り画像[31,x1] = DX.DerivationGraph(50, 74, 49, 79, n元画像[6]);


            n切り取り画像[80,x1] = DX.DerivationGraph(151, 31, 70, 40, n元画像[4]);
            n切り取り画像[81,x1] = DX.DerivationGraph(151, 72, 70, 40, n元画像[4]);
            n切り取り画像[130,x1] = DX.DerivationGraph(151 + 71, 72, 70, 40, n元画像[4]);
            n切り取り画像[82,x1] = DX.DerivationGraph(33 * 1, 0, 30, 30, n元画像[5]);
            n切り取り画像[83,x1] = DX.DerivationGraph(0, 0, 49, 48, n元画像[6]);
            n切り取り画像[84,x1] = DX.DerivationGraph(33 * 5 + 1, 0, 30, 30, n元画像[x1]);
            n切り取り画像[86,x1] = DX.DerivationGraph(102, 66, 49, 59, n元画像[6]);
            n切り取り画像[152,x1] = DX.DerivationGraph(152, 66, 49, 59, n元画像[6]);

            n切り取り画像[90,x1] = DX.DerivationGraph(102, 0, 64, 63, n元画像[6]);

            n切り取り画像[100,x1] = DX.DerivationGraph(33 * 1, 0, 30, 30, n元画像[2]);
            n切り取り画像[101,x1] = DX.DerivationGraph(33 * 7, 0, 30, 30, n元画像[2]);
            n切り取り画像[102,x1] = DX.DerivationGraph(33 * 3, 0, 30, 30, n元画像[2]);

            //grap[104][x1] = DerivationGraph( 33*2, 0, 30, 30, mgrap[5]) ;
            n切り取り画像[105,x1] = DX.DerivationGraph(33 * 5, 0, 30, 30, n元画像[2]);
            n切り取り画像[110,x1] = DX.DerivationGraph(33 * 4, 0, 30, 30, n元画像[2]);


            //背景読み込み
            x1 = 4;
            n切り取り画像[0,x1] = DX.DerivationGraph(0, 0, 150, 90, n元画像[x1]);
            n切り取り画像[1,x1] = DX.DerivationGraph(151, 0, 65, 29, n元画像[x1]);
            n切り取り画像[2,x1] = DX.DerivationGraph(151, 31, 70, 40, n元画像[x1]);
            n切り取り画像[3,x1] = DX.DerivationGraph(0, 91, 100, 90, n元画像[x1]);
            n切り取り画像[4,x1] = DX.DerivationGraph(151, 113, 51, 29, n元画像[x1]);
            n切り取り画像[5,x1] = DX.DerivationGraph(222, 0, 28, 60, n元画像[x1]);
            n切り取り画像[6,x1] = DX.DerivationGraph(151, 143, 90, 40, n元画像[x1]);
            n切り取り画像[30,x1] = DX.DerivationGraph(293, 0, 149, 90, n元画像[x1]);
            n切り取り画像[31,x1] = DX.DerivationGraph(293, 92, 64, 29, n元画像[x1]);

            //中間フラグ
            n切り取り画像[20,x1] = DX.DerivationGraph(40, 182, 40, 60, n元画像[x1]);


            //グラ
            x1 = 5;
            n切り取り画像[0,x1] = DX.DerivationGraph(167, 0, 45, 45, n元画像[6]);









            //敵サイズ収得
            //int GrHandle=0;
            x1 = 3;
            for (t = 0; t <= 140; t++)
            {
                DX.GetGraphSize(n切り取り画像[t,x1], out n敵サイズW[t], out n敵サイズH[t]);
                n敵サイズW[t] *= 100;
                n敵サイズH[t] *= 100;
            }
            n敵サイズW[79] = 120 * 100;
            n敵サイズH[79] = 15 * 100;
            n敵サイズW[85] = 25 * 100;
            n敵サイズH[85] = 30 * 10 * 100;

            //背景サイズ収得
            x1 = 4;
            for (t = 0; t < 40; t++)
            {
                DX.GetGraphSize(n切り取り画像[t,x1],out n背景サイズW[t], out n背景サイズH[t]);
            }

            DX.SetCreateSoundDataType(DX.DX_SOUNDDATATYPE_MEMPRESS);
            nオーディオ[100] = DX.LoadSoundMem("BGM/field.ogg");
            nオーディオ[103] = DX.LoadSoundMem("BGM/dungeon.ogg");
            nオーディオ[104] = DX.LoadSoundMem("BGM/star4.ogg");
            nオーディオ[105] = DX.LoadSoundMem("BGM/castle.ogg");
            nオーディオ[106] = DX.LoadSoundMem("BGM/puyo.ogg");

            DX.SetCreateSoundDataType(DX.DX_SOUNDDATATYPE_MEMNOPRESS);
            nオーディオ[1] = DX.LoadSoundMem("SE/jump.wav");
            nオーディオ[3] = DX.LoadSoundMem("SE/brockbreak.wav");
            nオーディオ[4] = DX.LoadSoundMem("SE/coin.wav");
            nオーディオ[5] = DX.LoadSoundMem("SE/humi.wav");
            nオーディオ[6] = DX.LoadSoundMem("SE/koura.wav");
            nオーディオ[7] = DX.LoadSoundMem("SE/dokan.wav");
            nオーディオ[8] = DX.LoadSoundMem("SE/brockkinoko.wav");
            nオーディオ[9] = DX.LoadSoundMem("SE/powerup.wav");
            nオーディオ[10] = DX.LoadSoundMem("SE/kirra.wav");
            nオーディオ[11] = DX.LoadSoundMem("SE/goal.wav");
            nオーディオ[12] = DX.LoadSoundMem("SE/death.wav");
            nオーディオ[13] = DX.LoadSoundMem("SE/Pswitch.wav");
            nオーディオ[14] = DX.LoadSoundMem("SE/jumpBlock.wav");
            nオーディオ[15] = DX.LoadSoundMem("SE/hintBlock.wav");
            nオーディオ[16] = DX.LoadSoundMem("SE/4-clear.wav");
            nオーディオ[17] = DX.LoadSoundMem("SE/allclear.wav");
            nオーディオ[18] = DX.LoadSoundMem("SE/tekifire.wav");


            x1 = 40;
            DX.ChangeVolumeSoundMem(255 * x1 / 100, nオーディオ[103]);
        }
    }
}

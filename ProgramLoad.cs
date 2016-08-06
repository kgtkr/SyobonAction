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
         static int ma;
         static int t;
         static int tt;
         static int[,] grap = new int[161, 8];
         static int[] mgrap = new int[51];
         static int x1;
         static int[] oto = new int[151];

         static int[] anx = new int[160];
         static int[] any = new int[160];
         static int[] ne = new int[41];
         static int[] nf = new int[41];

         static void Load()
        {
            for (t = 0; t < 7; t++)
            {
                mgrap[t] = 0;
            }

            //プレイヤー
            mgrap[0] = DX.LoadGraph("res/player.png");
            //ブロック
            mgrap[1] = DX.LoadGraph("res/brock.png");
            //アイテム
            mgrap[2] = DX.LoadGraph("res/item.png");
            //敵
            mgrap[3] = DX.LoadGraph("res/teki.png");
            //背景
            mgrap[4] = DX.LoadGraph("res/haikei.png");
            //ブロック2
            mgrap[5] = DX.LoadGraph("res/brock2.png");
            //おまけ
            mgrap[6] = DX.LoadGraph("res/omake.png");
            //おまけ2
            mgrap[7] = DX.LoadGraph("res/omake2.png");
            //タイトル
            mgrap[30] = DX.LoadGraph("res/syobon3.PNG");


            //プレイヤー読み込み
            grap[40,0] = DX.DerivationGraph(0, 0, 30, 36, mgrap[0]);
            grap[0,0] = DX.DerivationGraph(31 * 4, 0, 30, 36, mgrap[0]);
            grap[1,0] = DX.DerivationGraph(31 * 1, 0, 30, 36, mgrap[0]);
            grap[2,0] = DX.DerivationGraph(31 * 2, 0, 30, 36, mgrap[0]);
            grap[3,0] = DX.DerivationGraph(31 * 3, 0, 30, 36, mgrap[0]);
            grap[41,0] = DX.DerivationGraph(50, 0, 51, 73, mgrap[6]);

            x1 = 1;
            //ブロック読み込み
            for (t = 0; t <= 6; t++)
            {
                grap[t,x1] = DX.DerivationGraph(33 * t, 0, 30, 30, mgrap[x1]);
                grap[t + 30,x1] = DX.DerivationGraph(33 * t, 33, 30, 30, mgrap[x1]);
                grap[t + 60,x1] = DX.DerivationGraph(33 * t, 66, 30, 30, mgrap[x1]);
                grap[t + 90,x1] = DX.DerivationGraph(33 * t, 99, 30, 30, mgrap[x1]);
            }
            grap[8,x1] = DX.DerivationGraph(33 * 7, 0, 30, 30, mgrap[x1]);
            grap[16,x1] = DX.DerivationGraph(33 * 6, 0, 24, 27, mgrap[2]);
            grap[10,x1] = DX.DerivationGraph(33 * 9, 0, 30, 30, mgrap[x1]);
            grap[40,x1] = DX.DerivationGraph(33 * 9, 33, 30, 30, mgrap[x1]);
            grap[70,x1] = DX.DerivationGraph(33 * 9, 66, 30, 30, mgrap[x1]);
            grap[100,x1] = DX.DerivationGraph(33 * 9, 99, 30, 30, mgrap[x1]);
            //ブロック読み込み2
            x1 = 5;
            for (t = 0; t <= 6; t++)
            {
                grap[t,x1] = DX.DerivationGraph(33 * t, 0, 30, 30, mgrap[x1]);
            }
            grap[10,5] = DX.DerivationGraph(33 * 1, 33, 30, 30, mgrap[x1]);
            grap[11,5] = DX.DerivationGraph(33 * 2, 33, 30, 30, mgrap[x1]);
            grap[12,5] = DX.DerivationGraph(33 * 0, 66, 30, 30, mgrap[x1]);
            grap[13,5] = DX.DerivationGraph(33 * 1, 66, 30, 30, mgrap[x1]);
            grap[14,5] = DX.DerivationGraph(33 * 2, 66, 30, 30, mgrap[x1]);

            //アイテム読み込み
            x1 = 2;
            for (t = 0; t <= 5; t++)
            {
                grap[t,x1] = DX.DerivationGraph(33 * t, 0, 30, 30, mgrap[x1]);
            }

            //敵キャラ読み込み
            x1 = 3;
            grap[0,x1] = DX.DerivationGraph(33 * 0, 0, 30, 30, mgrap[x1]);
            grap[1,x1] = DX.DerivationGraph(33 * 1, 0, 30, 43, mgrap[x1]);
            grap[2,x1] = DX.DerivationGraph(33 * 2, 0, 30, 30, mgrap[x1]);
            grap[3,x1] = DX.DerivationGraph(33 * 3, 0, 30, 44, mgrap[x1]);
            grap[4,x1] = DX.DerivationGraph(33 * 4, 0, 33, 35, mgrap[x1]);
            grap[5,x1] = DX.DerivationGraph(0, 0, 37, 55, mgrap[7]);
            grap[6,x1] = DX.DerivationGraph(38 * 2, 0, 36, 50, mgrap[7]);
            grap[150,x1] = DX.DerivationGraph(38 * 2 + 37 * 2, 0, 36, 50, mgrap[7]);
            grap[7,x1] = DX.DerivationGraph(33 * 6 + 1, 0, 32, 32, mgrap[x1]);
            grap[8,x1] = DX.DerivationGraph(38 * 2 + 37 * 3, 0, 37, 47, mgrap[7]);
            grap[151,x1] = DX.DerivationGraph(38 * 3 + 37 * 3, 0, 37, 47, mgrap[7]);
            grap[9,x1] = DX.DerivationGraph(33 * 7 + 1, 0, 26, 30, mgrap[x1]);
            grap[10,x1] = DX.DerivationGraph(214, 0, 46, 16, mgrap[6]);

            //モララー
            grap[30,x1] = DX.DerivationGraph(0, 56, 30, 36, mgrap[7]);
            grap[155,x1] = DX.DerivationGraph(31 * 3, 56, 30, 36, mgrap[7]);
            grap[31,x1] = DX.DerivationGraph(50, 74, 49, 79, mgrap[6]);


            grap[80,x1] = DX.DerivationGraph(151, 31, 70, 40, mgrap[4]);
            grap[81,x1] = DX.DerivationGraph(151, 72, 70, 40, mgrap[4]);
            grap[130,x1] = DX.DerivationGraph(151 + 71, 72, 70, 40, mgrap[4]);
            grap[82,x1] = DX.DerivationGraph(33 * 1, 0, 30, 30, mgrap[5]);
            grap[83,x1] = DX.DerivationGraph(0, 0, 49, 48, mgrap[6]);
            grap[84,x1] = DX.DerivationGraph(33 * 5 + 1, 0, 30, 30, mgrap[x1]);
            grap[86,x1] = DX.DerivationGraph(102, 66, 49, 59, mgrap[6]);
            grap[152,x1] = DX.DerivationGraph(152, 66, 49, 59, mgrap[6]);

            grap[90,x1] = DX.DerivationGraph(102, 0, 64, 63, mgrap[6]);

            grap[100,x1] = DX.DerivationGraph(33 * 1, 0, 30, 30, mgrap[2]);
            grap[101,x1] = DX.DerivationGraph(33 * 7, 0, 30, 30, mgrap[2]);
            grap[102,x1] = DX.DerivationGraph(33 * 3, 0, 30, 30, mgrap[2]);

            //grap[104][x1] = DerivationGraph( 33*2, 0, 30, 30, mgrap[5]) ;
            grap[105,x1] = DX.DerivationGraph(33 * 5, 0, 30, 30, mgrap[2]);
            grap[110,x1] = DX.DerivationGraph(33 * 4, 0, 30, 30, mgrap[2]);


            //背景読み込み
            x1 = 4;
            grap[0,x1] = DX.DerivationGraph(0, 0, 150, 90, mgrap[x1]);
            grap[1,x1] = DX.DerivationGraph(151, 0, 65, 29, mgrap[x1]);
            grap[2,x1] = DX.DerivationGraph(151, 31, 70, 40, mgrap[x1]);
            grap[3,x1] = DX.DerivationGraph(0, 91, 100, 90, mgrap[x1]);
            grap[4,x1] = DX.DerivationGraph(151, 113, 51, 29, mgrap[x1]);
            grap[5,x1] = DX.DerivationGraph(222, 0, 28, 60, mgrap[x1]);
            grap[6,x1] = DX.DerivationGraph(151, 143, 90, 40, mgrap[x1]);
            grap[30,x1] = DX.DerivationGraph(293, 0, 149, 90, mgrap[x1]);
            grap[31,x1] = DX.DerivationGraph(293, 92, 64, 29, mgrap[x1]);

            //中間フラグ
            grap[20,x1] = DX.DerivationGraph(40, 182, 40, 60, mgrap[x1]);


            //グラ
            x1 = 5;
            grap[0,x1] = DX.DerivationGraph(167, 0, 45, 45, mgrap[6]);









            //敵サイズ収得
            //int GrHandle=0;
            x1 = 3;
            for (t = 0; t <= 140; t++)
            {
                DX.GetGraphSize(grap[t,x1], out anx[t], out any[t]);
                anx[t] *= 100; any[t] *= 100;
            }
            anx[79] = 120 * 100; any[79] = 15 * 100;
            anx[85] = 25 * 100; any[85] = 30 * 10 * 100;

            //背景サイズ収得
            x1 = 4;
            for (t = 0; t < 40; t++)
            {
                DX.GetGraphSize(grap[t,x1],out ne[t], out nf[t]);
            }

            DX.SetCreateSoundDataType(DX.DX_SOUNDDATATYPE_MEMPRESS);
            oto[100] = DX.LoadSoundMem("BGM/field.ogg");
            oto[103] = DX.LoadSoundMem("BGM/dungeon.ogg");
            oto[104] = DX.LoadSoundMem("BGM/star4.ogg");
            oto[105] = DX.LoadSoundMem("BGM/castle.ogg");
            oto[106] = DX.LoadSoundMem("BGM/puyo.ogg");

            DX.SetCreateSoundDataType(DX.DX_SOUNDDATATYPE_MEMNOPRESS);
            oto[1] = DX.LoadSoundMem("SE/jump.wav");
            oto[3] = DX.LoadSoundMem("SE/brockbreak.wav");
            oto[4] = DX.LoadSoundMem("SE/coin.wav");
            oto[5] = DX.LoadSoundMem("SE/humi.wav");
            oto[6] = DX.LoadSoundMem("SE/koura.wav");
            oto[7] = DX.LoadSoundMem("SE/dokan.wav");
            oto[8] = DX.LoadSoundMem("SE/brockkinoko.wav");
            oto[9] = DX.LoadSoundMem("SE/powerup.wav");
            oto[10] = DX.LoadSoundMem("SE/kirra.wav");
            oto[11] = DX.LoadSoundMem("SE/goal.wav");
            oto[12] = DX.LoadSoundMem("SE/death.wav");
            oto[13] = DX.LoadSoundMem("SE/Pswitch.wav");
            oto[14] = DX.LoadSoundMem("SE/jumpBlock.wav");
            oto[15] = DX.LoadSoundMem("SE/hintBlock.wav");
            oto[16] = DX.LoadSoundMem("SE/4-clear.wav");
            oto[17] = DX.LoadSoundMem("SE/allclear.wav");
            oto[18] = DX.LoadSoundMem("SE/tekifire.wav");


            x1 = 40;
            DX.ChangeVolumeSoundMem(255 * x1 / 100, oto[103]);
        }
    }
}

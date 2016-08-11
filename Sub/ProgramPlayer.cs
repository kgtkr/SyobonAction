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
        class Cプレイヤー
        {
            //プレイヤー
            public int ainmsgtype;
            public int b, nobia, nobib, hp;
            public int c,
                d,
                 nokori = 2, actp, act;

            public int type,
                xtype,
                tm,
                zz;
            public int zimen,
                rzimen,
                kasok,
                muki,
                jumptm,
                keytm;
            public int mutekitm;
            public int[] actaon = new int[7];
        }

        static Cプレイヤー nプレイヤー = new Cプレイヤー();

        static void UpdatePlayer()
        {
            //プレイヤーの移動
            xx_0 = 0; nプレイヤー.actaon[2] = 0; nプレイヤー.actaon[3] = 0;
            if (nプレイヤー.keytm <= 0)
            {
                if (Key.GetKey(DX.KEY_INPUT_LEFT))
                {
                    nプレイヤー.actaon[0] = -1;
                    nプレイヤー.muki = 0;
                    nプレイヤー.actaon[4] = -1;
                }
                if (Key.GetKey(DX.KEY_INPUT_RIGHT))
                {
                    nプレイヤー.actaon[0] = 1;
                    nプレイヤー.muki = 1;
                    nプレイヤー.actaon[4] = 1;
                }
                if (Key.GetKey(DX.KEY_INPUT_DOWN))
                {
                    nプレイヤー.actaon[3] = 1;
                }
            }

            
            if (Key.GetKey(DX.KEY_INPUT_O))
            {
                if (nプレイヤー.hp >= 1)
                {
                    nプレイヤー.hp = 0;
                }
                if (nステージc >= 5)
                {
                    nステージc = 0;
                    stagepoint = false;
                }
            }


            if (nプレイヤー.keytm <= 0)
            {
                if (Key.GetKey(DX.KEY_INPUT_Z))
                {
                    if (nプレイヤー.actaon[1] == 10)
                    {
                        nプレイヤー.actaon[1] = 1;
                        xx_0 = 1;
                    }
                    nプレイヤー.actaon[2] = 1;
                }
            }

            if (Key.GetKey(DX.KEY_INPUT_Z))
            {
                if (nプレイヤー.jumptm == 8 && nプレイヤー.d >= -900)
                {
                    nプレイヤー.d = -1300;
                    //ダッシュ中
                    xx_22 = 200;
                    if (nプレイヤー.c >= xx_22 || nプレイヤー.c <= -xx_22)
                    {
                        nプレイヤー.d = -1400;
                    }

                    xx_22 = 600;
                    if (nプレイヤー.c >= xx_22 || nプレイヤー.c <= -xx_22)
                    {
                        nプレイヤー.d = -1500;
                    }
                }
                if (xx_0 == 0) nプレイヤー.actaon[1] = 10;
            }

            //加速による移動
            xx_0 = 40;
            xx_1 = 700;
            xx_8 = 500;
            xx_9 = 700;

            xx_12 = 1;
            xx_13 = 2;

            //すべり補正
            if (nプレイヤー.rzimen == 1)
            {
                xx_0 = 20;
                xx_12 = 9;
                xx_13 = 10;
            }


            //if (mzimen==0){xx_0-=15;}
            if (nプレイヤー.actaon[0] == -1)
            {
                if (!(nプレイヤー.zimen == 0 && nプレイヤー.c < -xx_8))
                {
                    if (nプレイヤー.c >= -xx_9)
                    {
                        nプレイヤー.c -= xx_0;
                        if (nプレイヤー.c < -xx_9)
                        {
                            nプレイヤー.c = -xx_9 - 1;
                        }
                    }

                    if (nプレイヤー.c < -xx_9)
                    {
                        nプレイヤー.c -= xx_0 / 10;
                    }
                }
                if (nプレイヤー.rzimen != 1)
                {
                    if (nプレイヤー.c > 100 && nプレイヤー.zimen == 0)
                    {
                        nプレイヤー.c -= xx_0 * 2 / 3;
                    }
                    if (nプレイヤー.c > 100 && nプレイヤー.zimen == 1)
                    {
                        nプレイヤー.c -= xx_0;
                        if (nプレイヤー.zimen == 1)
                        {
                            nプレイヤー.c -= xx_0 * 1 / 2;
                        }
                    }
                    nプレイヤー.actaon[0] = 3;
                    nプレイヤー.kasok += 1;
                }
            }

            if (nプレイヤー.actaon[0] == 1)
            {
                if (!(nプレイヤー.zimen == 0 && nプレイヤー.c > xx_8))
                {
                    if (nプレイヤー.c <= xx_9)
                    {
                        nプレイヤー.c += xx_0;
                        if (nプレイヤー.c > xx_9)
                        {
                            nプレイヤー.c = xx_9 + 1;
                        }
                    }
                    if (nプレイヤー.c > xx_9)
                    {
                        nプレイヤー.c += xx_0 / 10;
                    }
                }
                if (nプレイヤー.rzimen != 1)
                {
                    if (nプレイヤー.c < -100 && nプレイヤー.zimen == 0)
                    {
                        nプレイヤー.c += xx_0 * 2 / 3;
                    }
                    if (nプレイヤー.c < -100 && nプレイヤー.zimen == 1)
                    {
                        nプレイヤー.c += xx_0;
                        if (nプレイヤー.zimen == 1)
                        {
                            nプレイヤー.c += xx_0 * 1 / 2;
                        }
                    }
                    nプレイヤー.actaon[0] = 3;
                    nプレイヤー.kasok += 1;
                }
            }
            if (nプレイヤー.actaon[0] == 0 && nプレイヤー.kasok > 0)
            {
                nプレイヤー.kasok -= 2;
            }
            if (nプレイヤー.kasok > 8)
            {
                nプレイヤー.kasok = 8;
            }

            //すべり補正初期化
            if (nプレイヤー.zimen != 1)
            {
                nプレイヤー.rzimen = 0;
            }


            //ジャンプ
            if (nプレイヤー.jumptm >= 0)
            {
                nプレイヤー.jumptm--;
            }
            if (nプレイヤー.actaon[1] == 1 && nプレイヤー.zimen == 1)
            {
                nプレイヤー.b -= 400;
                nプレイヤー.d = -1200;
                nプレイヤー.jumptm = 10;

                v効果音再生(Res.nオーディオ1);

                nプレイヤー.zimen = 0;

            }
            if (nプレイヤー.actaon[1] <= 9)
            {
                nプレイヤー.actaon[1] = 0;
            }

            if (nプレイヤー.mutekitm >= -1)
            {
                nプレイヤー.mutekitm--;
            }

            //HPがなくなったとき
            if (nプレイヤー.hp <= 0 && nプレイヤー.hp >= -9)
            {
                nプレイヤー.keytm = 12;
                nプレイヤー.hp = -20;
                nプレイヤー.type = 200;
                nプレイヤー.tm = 0;
                v効果音再生(Res.nオーディオ12);
                DX.StopSoundMem(Res.n現在のBGM);
                DX.StopSoundMem(Res.nオーディオ11);
                DX.StopSoundMem(Res.nオーディオ16);
            }//mhp
            if (nプレイヤー.type == 200)
            {
                if (nプレイヤー.tm <= 11)
                {
                    nプレイヤー.c = 0;
                    nプレイヤー.d = 0;
                }
                if (nプレイヤー.tm == 12)
                {
                    nプレイヤー.d = -1200;
                }
                if (nプレイヤー.tm >= 12)
                {
                    nプレイヤー.c = 0;
                }
                if (nプレイヤー.tm >= 100)
                {
                    b初期化 = false;
                    e現在の画面 = E画面.機数表示;
                    nプレイヤー.tm = 0;
                    nプレイヤー.keytm = 0;
                    nプレイヤー.nokori--;
                }
            }


            //音符によるワープ
            if (nプレイヤー.type == 2)
            {
                nプレイヤー.tm++;

                nプレイヤー.keytm = 2;
                nプレイヤー.d = -1500;
                if (nプレイヤー.b <= -6000)
                {
                    blackX = 1;
                    blackTm = 20;
                    nステージc += 5;
                    DX.StopSoundMem(Res.n現在のBGM);
                    nプレイヤー.tm = 0;
                    nプレイヤー.type = 0;
                    nプレイヤー.keytm = -1;
                }
            }

            //ジャンプ台アウト
            if (nプレイヤー.type == 3)
            {
                nプレイヤー.d = -2400;
                if (nプレイヤー.b <= -6000)
                {
                    nプレイヤー.b = -80000000;
                    nプレイヤー.hp = 0;
                }
            }


            //mtypeによる特殊的な移動
            if (nプレイヤー.type >= 100)
            {
                nプレイヤー.tm++;

                //普通の土管
                if (nプレイヤー.type == 100)
                {
                    if (nプレイヤー.xtype == 0)
                    {
                        nプレイヤー.c = 0;
                        nプレイヤー.d = 0;
                        int t_ = 28;
                        if (nプレイヤー.tm <= 16)
                        {
                            nプレイヤー.b += 240;
                            nプレイヤー.zz = 100;
                        }
                        if (nプレイヤー.tm == 17)
                        {
                            nプレイヤー.b = -80000000;
                        }
                        if (nプレイヤー.tm == 23)
                        {
                            n地面[t_].a -= 100;
                        }
                        if (nプレイヤー.tm >= 44 && nプレイヤー.tm <= 60)
                        {
                            if (nプレイヤー.tm % 2 == 0) n地面[t_].a += 200;
                            if (nプレイヤー.tm % 2 == 1) n地面[t_].a -= 200;
                        }
                        if (nプレイヤー.tm >= 61 && nプレイヤー.tm <= 77)
                        {
                            if (nプレイヤー.tm % 2 == 0) n地面[t_].a += 400;
                            if (nプレイヤー.tm % 2 == 1) n地面[t_].a -= 400;
                        }
                        if (nプレイヤー.tm >= 78 && nプレイヤー.tm <= 78 + 16)
                        {
                            if (nプレイヤー.tm % 2 == 0) n地面[t_].a += 600;
                            if (nプレイヤー.tm % 2 == 1) n地面[t_].a -= 600;
                        }
                        if (nプレイヤー.tm >= 110)
                        {
                            n地面[t_].b -= nプレイヤー.zz;
                            nプレイヤー.zz += 80;
                            if (nプレイヤー.zz > 1600) nプレイヤー.zz = 1600;
                        }
                        if (nプレイヤー.tm == 160)
                        {
                            nプレイヤー.type = 0;
                            nプレイヤー.hp--;
                        }
                    }

                    //ふっとばし
                    else if (nプレイヤー.xtype == 10)
                    {
                        nプレイヤー.c = 0; nプレイヤー.d = 0;
                        if (nプレイヤー.tm <= 16)
                        {
                            ma += 240;
                        }
                        if (nプレイヤー.tm == 16) nプレイヤー.b -= 1100;
                        if (nプレイヤー.tm == 20) v効果音再生(Res.nオーディオ10);

                        if (nプレイヤー.tm >= 24)
                        {
                            ma -= 2000;
                            nプレイヤー.muki = 0;
                        }
                        if (nプレイヤー.tm >= 48)
                        {
                            nプレイヤー.type = 0;
                            nプレイヤー.hp--;
                        }

                    }
                    else {
                        nプレイヤー.c = 0; nプレイヤー.d = 0;
                        if (nプレイヤー.tm <= 16 && nプレイヤー.xtype != 3)
                        {
                            nプレイヤー.b += 240;
                        }
                        if (nプレイヤー.tm <= 16 && nプレイヤー.xtype == 3)
                        {
                            ma += 240;
                        }
                        if (nプレイヤー.tm == 19 && nプレイヤー.xtype == 2)
                        {
                            nプレイヤー.hp = 0;
                            nプレイヤー.type = 2000;
                            nプレイヤー.tm = 0;
                            nメッセージtm = 30;
                            nメッセージtype = 51;
                        }
                        if (nプレイヤー.tm == 19 && nプレイヤー.xtype == 5)
                        {
                            nプレイヤー.hp = 0;
                            nプレイヤー.type = 2000;
                            nプレイヤー.tm = 0;
                            nメッセージtm = 30;
                            nメッセージtype = 52;
                        }
                        if (nプレイヤー.tm == 20)
                        {
                            if (nプレイヤー.xtype == 6)
                            {
                                nステージc += 10;
                            }
                            else {
                                nステージc++;
                            }
                            nプレイヤー.b = -80000000;
                            nプレイヤー.xtype = 0;
                            blackX = 1;
                            blackTm = 20;
                            DX.StopSoundMem(Res.n現在のBGM);
                        }
                    }
                }


                if (nプレイヤー.type == 300)
                {
                    nプレイヤー.keytm = 3;
                    if (nプレイヤー.tm <= 1)
                    {
                        nプレイヤー.c = 0;
                        nプレイヤー.d = 0;
                    }
                    if (nプレイヤー.tm >= 2 && nプレイヤー.tm <= 42)
                    {
                        nプレイヤー.d = 600;
                        nプレイヤー.muki = 1;
                    }
                    if (nプレイヤー.tm > 43 && nプレイヤー.tm <= 108)
                    {
                        nプレイヤー.c = 300;
                    }
                    if (nプレイヤー.tm == 110)
                    {
                        nプレイヤー.b = -80000000;
                        nプレイヤー.c = 0;
                    }
                    if (nプレイヤー.tm == 250)
                    {
                        nステージb++; nステージc = 0;
                        b初期化 = false;
                        n中間フラグ = 0;
                        e現在の画面 = E画面.機数表示;
                        maintm = 0;
                    }
                }//mtype==300

                if (nプレイヤー.type == 301 || nプレイヤー.type == 302)
                {
                    nプレイヤー.keytm = 3;

                    if (nプレイヤー.tm <= 1)
                    {
                        nプレイヤー.c = 0;
                        nプレイヤー.d = 0;
                    }

                    if (nプレイヤー.tm >= 2 && (nプレイヤー.type == 301 && nプレイヤー.tm <= 102 || nプレイヤー.type == 302 && nプレイヤー.tm <= 60))
                    {
                        xx_5 = 500;
                        ma -= xx_5;
                        fx += xx_5;
                        fzx += xx_5;
                    }

                    if ((nプレイヤー.type == 301 || nプレイヤー.type == 302) && nプレイヤー.tm >= 2 && nプレイヤー.tm <= 100)
                    {
                        nプレイヤー.c = 250;
                        nプレイヤー.muki = 1;
                    }

                    if (nプレイヤー.tm == 200)
                    {
                        v効果音再生(Res.nオーディオ17);
                        if (nプレイヤー.type == 301)
                        {
                            n背景[n背景co].a = 117 * 29 * 100 - 1100;
                            n背景[n背景co].b = 4 * 29 * 100;
                            n背景[n背景co].type = 101;
                            n背景co++;
                            if (n背景co >= n背景max) n背景co = 0;

                            n背景[n背景co].a = 115 * 29 * 100 - 1100;
                            n背景[n背景co].b = 6 * 29 * 100;
                            n背景[n背景co].type = 102;
                            n背景co++;
                            if (n背景co >= n背景max) n背景co = 0;
                        }
                        else {
                            n背景[n背景co].a = 157 * 29 * 100 - 1100; n背景[n背景co].b = 4 * 29 * 100; n背景[n背景co].type = 101; n背景co++; if (n背景co >= n背景max) n背景co = 0;
                            n背景[n背景co].a = 155 * 29 * 100 - 1100; n背景[n背景co].b = 6 * 29 * 100; n背景[n背景co].type = 102; n背景co++; if (n背景co >= n背景max) n背景co = 0;
                        }
                    }
                    //スタッフロールへ

                    if (nプレイヤー.tm == 440)
                    {
                        if (nプレイヤー.type == 301)
                        {
                            nスタッフロール = 1;
                        }
                        else {
                            nステージa++;
                            nステージb = 1;
                            nステージc = 0;
                            b初期化 = false;
                            n中間フラグ = 0;
                            e現在の画面 = E画面.機数表示;
                            maintm = 0;
                        }
                    }
                }
            }

            //移動
            if (nプレイヤー.keytm >= 1)
            {
                nプレイヤー.keytm--;
            }
            ma += nプレイヤー.c;
            nプレイヤー.b += nプレイヤー.d;

            if (nプレイヤー.c < 0) nプレイヤー.actp += (-nプレイヤー.c);
            if (nプレイヤー.c >= 0) nプレイヤー.actp += nプレイヤー.c;

            if (nプレイヤー.type <= 9 || nプレイヤー.type == 200 || nプレイヤー.type == 300 || nプレイヤー.type == 301 || nプレイヤー.type == 302) nプレイヤー.d += 100;


            //走る際の最大値
            if (nプレイヤー.type == 0)
            {
                xx_0 = 800; xx_1 = 1600;
                if (nプレイヤー.c > xx_0 && nプレイヤー.c < xx_0 + 200) { nプレイヤー.c = xx_0; }
                if (nプレイヤー.c > xx_0 + 200) { nプレイヤー.c -= 200; }
                if (nプレイヤー.c < -xx_0 && nプレイヤー.c > -xx_0 - 200) { nプレイヤー.c = -xx_0; }
                if (nプレイヤー.c < -xx_0 - 200) { nプレイヤー.c += 200; }
                if (nプレイヤー.d > xx_1) { nプレイヤー.d = xx_1; }
            }

            //プレイヤー
            //地面の摩擦
            if (nプレイヤー.zimen == 1 && nプレイヤー.actaon[0] != 3)
            {
                if ((nプレイヤー.type <= 9) || nプレイヤー.type == 300 || nプレイヤー.type == 301 || nプレイヤー.type == 302)
                {
                    if (nプレイヤー.rzimen == 0)
                    {
                        xx_2 = 30; xx_1 = 60; xx_3 = 30;
                        if (nプレイヤー.c >= -xx_3 && nプレイヤー.c <= xx_3) { nプレイヤー.c = 0; }
                        if (nプレイヤー.c >= xx_2) { nプレイヤー.c -= xx_1; }
                        if (nプレイヤー.c <= -xx_2) { nプレイヤー.c += xx_1; }
                    }
                    if (nプレイヤー.rzimen == 1)
                    {
                        xx_2 = 5; xx_1 = 10; xx_3 = 5;
                        if (nプレイヤー.c >= -xx_3 && nプレイヤー.c <= xx_3) { nプレイヤー.c = 0; }
                        if (nプレイヤー.c >= xx_2) { nプレイヤー.c -= xx_1; }
                        if (nプレイヤー.c <= -xx_2) { nプレイヤー.c += xx_1; }
                    }
                }
            }

            //地面判定初期化
            nプレイヤー.zimen = 0;

            //場外
            if (nプレイヤー.type <= 9 && nプレイヤー.hp >= 1)
            {
                if (ma < 100) { ma = 100; nプレイヤー.c = 0; }
                if (ma + nプレイヤー.nobia > n画面幅) { ma = n画面幅 - nプレイヤー.nobia; nプレイヤー.c = 0; }
            }
            if (nプレイヤー.b >= 38000 && nプレイヤー.hp >= 0 && nステージ色 == 4) { nプレイヤー.hp = -2; nメッセージtm = 30; nメッセージtype = 55; }
            if (nプレイヤー.b >= 52000 && nプレイヤー.hp >= 0) { nプレイヤー.hp = -2; }
        }

        static void DrawPlayer()
        {
            DXDraw.SetColor(0, 0, 255);

            if (nプレイヤー.actp >= 2000) { nプレイヤー.actp -= 2000; if (nプレイヤー.act == 0) { nプレイヤー.act = 1; } else { nプレイヤー.act = 0; } }
            if (nプレイヤー.muki == 0) DXDraw.nミラー = 1;

            if (nプレイヤー.type != 200 && nプレイヤー.type != 1)
            {
                if (nプレイヤー.zimen == 1)
                {
                    // 読みこんだグラフィックを拡大描画
                    if (nプレイヤー.act == 0) DXDraw.DrawGraph(Res.n切り取り画像[0, 0], ma / 100, nプレイヤー.b / 100);
                    if (nプレイヤー.act == 1) DXDraw.DrawGraph(Res.n切り取り画像[1, 0], ma / 100, nプレイヤー.b / 100);
                }
                if (nプレイヤー.zimen == 0)
                {
                    DXDraw.DrawGraph(Res.n切り取り画像[2, 0], ma / 100, nプレイヤー.b / 100);
                }
            }
            //巨大化
            else if (nプレイヤー.type == 1)
            {
                DXDraw.DrawGraph(Res.n切り取り画像[41, 0], ma / 100, nプレイヤー.b / 100);
            }

            else if (nプレイヤー.type == 200)
            {
                DXDraw.DrawGraph(Res.n切り取り画像[3, 0], ma / 100, nプレイヤー.b / 100);
            }
        }
    }
}

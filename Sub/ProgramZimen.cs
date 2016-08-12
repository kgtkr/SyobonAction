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
        struct C地面
        {
            public int a,
            b,
            c,
            d,
            type,
            xtype,
            r;
            public int gtype;
        }

        //
        const int n地面max = 31;
        static int n地面co;
        static C地面[] n地面 = new C地面[n地面max];

        static void UpdateZimen()
        {
            //壁
            for (int t_ = 0; t_ < n地面max; t_++)
            {
                if (n地面[t_].a - fx + n地面[t_].c >= -12000 && n地面[t_].a - fx <= n画面幅)
                {
                    xx_0 = 200; xx_1 = 2400; xx_2 = 1000; xx_7 = 0;

                    xx_8 = n地面[t_].a - fx; xx_9 = n地面[t_].b - fy;
                    if ((n地面[t_].type <= 99 || n地面[t_].type == 200) && nプレイヤー.type < 10)
                    {

                        //おちるブロック
                        if (n地面[t_].type == 51)
                        {
                            if (ma + nプレイヤー.nobia > xx_8 + xx_0 + 3000 && ma < xx_8 + n地面[t_].c - xx_0 && nプレイヤー.b + nプレイヤー.nobib > xx_9 + 3000 && n地面[t_].gtype == 0)
                            {
                                if (n地面[t_].xtype == 0)
                                {
                                    n地面[t_].gtype = 1; n地面[t_].r = 0;
                                }
                            }
                            if (ma + nプレイヤー.nobia > xx_8 + xx_0 + 1000 && ma < xx_8 + n地面[t_].c - xx_0 && nプレイヤー.b + nプレイヤー.nobib > xx_9 + 3000 && n地面[t_].gtype == 0)
                            {
                                if ((n地面[t_].xtype == 10) && n地面[t_].gtype == 0)
                                {
                                    n地面[t_].gtype = 1; n地面[t_].r = 0;
                                }
                            }

                            if ((n地面[t_].xtype == 1) && n地面[27].b >= 25000 && n地面[27].a > ma + nプレイヤー.nobia && t_ != 27 && n地面[t_].gtype == 0)
                            {
                                n地面[t_].gtype = 1; n地面[t_].r = 0;
                            }
                            if (n地面[t_].xtype == 2 && n地面[28].b >= 48000 && t_ != 28 && n地面[t_].gtype == 0 && nプレイヤー.hp >= 1)
                            {
                                n地面[t_].gtype = 1; n地面[t_].r = 0;
                            }
                            if ((n地面[t_].xtype == 3 && nプレイヤー.b >= 30000 || n地面[t_].xtype == 4 && nプレイヤー.b >= 25000) && n地面[t_].gtype == 0 && nプレイヤー.hp >= 1 && ma + nプレイヤー.nobia > xx_8 + xx_0 + 3000 - 300 && ma < xx_8 + n地面[t_].c - xx_0)
                            {
                                n地面[t_].gtype = 1; n地面[t_].r = 0;
                                if (n地面[t_].xtype == 4) n地面[t_].r = 100;
                            }

                            if (n地面[t_].gtype == 1 && n地面[t_].b <= n画面高さ + 18000)
                            {
                                n地面[t_].r += 120; if (n地面[t_].r >= 1600) { n地面[t_].r = 1600; }
                                n地面[t_].b += n地面[t_].r;
                                if (ma + nプレイヤー.nobia > xx_8 + xx_0 && ma < xx_8 + n地面[t_].c - xx_0 && nプレイヤー.b + nプレイヤー.nobib > xx_9 && nプレイヤー.b < xx_9 + n地面[t_].d + xx_0)
                                {
                                    nプレイヤー.hp--; xx_7 = 1;
                                }
                            }
                        }

                        //おちるブロック2
                        if (n地面[t_].type == 52)
                        {
                            if (n地面[t_].gtype == 0 && ma + nプレイヤー.nobia > xx_8 + xx_0 + 2000 && ma < xx_8 + n地面[t_].c - xx_0 - 2500 && nプレイヤー.b + nプレイヤー.nobib > xx_9 - 3000)
                            {
                                n地面[t_].gtype = 1; n地面[t_].r = 0;
                            }
                            if (n地面[t_].gtype == 1)
                            {
                                n地面[t_].r += 120; if (n地面[t_].r >= 1600) { n地面[t_].r = 1600; }
                                n地面[t_].b += n地面[t_].r;
                            }
                        }



                        //通常地面
                        if (xx_7 == 0)
                        {
                            if (ma + nプレイヤー.nobia > xx_8 + xx_0 && ma < xx_8 + n地面[t_].c - xx_0 && nプレイヤー.b + nプレイヤー.nobib > xx_9 && nプレイヤー.b + nプレイヤー.nobib < xx_9 + xx_1 && nプレイヤー.d >= -100) { nプレイヤー.b = n地面[t_].b - fy - nプレイヤー.nobib + 100; nプレイヤー.d = 0; nプレイヤー.zimen = 1; }
                            if (ma + nプレイヤー.nobia > xx_8 - xx_0 && ma < xx_8 + xx_2 && nプレイヤー.b + nプレイヤー.nobib > xx_9 + xx_1 * 3 / 4 && nプレイヤー.b < xx_9 + n地面[t_].d - xx_2) { ma = xx_8 - xx_0 - nプレイヤー.nobia; nプレイヤー.c = 0; }
                            if (ma + nプレイヤー.nobia > xx_8 + n地面[t_].c - xx_0 && ma < xx_8 + n地面[t_].c + xx_0 && nプレイヤー.b + nプレイヤー.nobib > xx_9 + xx_1 * 3 / 4 && nプレイヤー.b < xx_9 + n地面[t_].d - xx_2) { ma = xx_8 + n地面[t_].c + xx_0; nプレイヤー.c = 0; }
                            if (ma + nプレイヤー.nobia > xx_8 + xx_0 * 2 && ma < xx_8 + n地面[t_].c - xx_0 * 2 && nプレイヤー.b > xx_9 + n地面[t_].d - xx_1 && nプレイヤー.b < xx_9 + n地面[t_].d + xx_0)
                            {
                                nプレイヤー.b = xx_9 + n地面[t_].d + xx_0; if (nプレイヤー.d < 0) { nプレイヤー.d = -nプレイヤー.d * 2 / 3; }
                            }
                        }//xx_7

                        //入る土管
                        if (n地面[t_].type == 50)
                        {
                            if (ma + nプレイヤー.nobia > xx_8 + 2800 && ma < xx_8 + n地面[t_].c - 3000 && nプレイヤー.b + nプレイヤー.nobib > xx_9 - 1000 && nプレイヤー.b + nプレイヤー.nobib < xx_9 + xx_1 + 3000 && nプレイヤー.zimen == 1 && nプレイヤー.actaon[3] == 1 && nプレイヤー.type == 0)
                            {
                                //飛び出し
                                if (n地面[t_].xtype == 0)
                                {
                                    nプレイヤー.type = 100; nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ7); nプレイヤー.xtype = 0;
                                }
                                //普通
                                if (n地面[t_].xtype == 1)
                                {
                                    nプレイヤー.type = 100; nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ7); nプレイヤー.xtype = 1;
                                }
                                //普通
                                if (n地面[t_].xtype == 2)
                                {
                                    nプレイヤー.type = 100; nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ7); nプレイヤー.xtype = 2;
                                }
                                if (n地面[t_].xtype == 5)
                                {
                                    nプレイヤー.type = 100; nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ7); nプレイヤー.xtype = 5;
                                }
                                // ループ
                                if (n地面[t_].xtype == 6)
                                {
                                    nプレイヤー.type = 100; nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ7); nプレイヤー.xtype = 6;
                                }
                            }
                        }//50

                        //入る土管(左から)
                        if (n地面[t_].type == 40)
                        {
                            if (ma + nプレイヤー.nobia > xx_8 - 300 && ma < xx_8 + n地面[t_].c - 1000 && nプレイヤー.b > xx_9 + 1000 && nプレイヤー.b + nプレイヤー.nobib < xx_9 + xx_1 + 4000 && nプレイヤー.zimen == 1 && nプレイヤー.actaon[4] == 1 && nプレイヤー.type == 0)
                            {//end();
                             //飛び出し
                                if (n地面[t_].xtype == 0)
                                {
                                    nプレイヤー.type = 500; nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ7);//mxtype=1;
                                    nプレイヤー.type = 100; nプレイヤー.xtype = 10;
                                }

                                if (n地面[t_].xtype == 2)
                                {
                                    nプレイヤー.xtype = 3;
                                    nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ7);//mxtype=1;
                                    nプレイヤー.type = 100;
                                }
                                // ループ
                                if (n地面[t_].xtype == 6)
                                {
                                    nプレイヤー.type = 3; nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ7); nプレイヤー.xtype = 6;
                                }
                            }
                        }//40




                    }//stype
                    else {
                        if (ma + nプレイヤー.nobia > xx_8 + xx_0 && ma < xx_8 + n地面[t_].c - xx_0 && nプレイヤー.b + nプレイヤー.nobib > xx_9 && nプレイヤー.b < xx_9 + n地面[t_].d + xx_0)
                        {
                            if (n地面[t_].type == 100)
                            {
                                if (n地面[t_].xtype == 0 || n地面[t_].xtype == 1 && nブロック[1].type != 3)
                                {
                                    v敵キャラアイテム作成(n地面[t_].a + 1000, 32000, 0, 0, 0, 3, 0); n地面[t_].a = -800000000; v効果音再生(Res.nオーディオ10);
                                }
                            }
                            if (n地面[t_].type == 101) { v敵キャラアイテム作成(n地面[t_].a + 6000, -4000, 0, 0, 0, 3, 1); n地面[t_].a = -800000000; v効果音再生(Res.nオーディオ10); }
                            if (n地面[t_].type == 102)
                            {
                                if (n地面[t_].xtype == 0)
                                {
                                    for (int t3 = 0; t3 <= 3; t3++) { v敵キャラアイテム作成(n地面[t_].a + t3 * 3000, -3000, 0, 0, 0, 0, 0); }
                                }
                                if (n地面[t_].xtype == 1 && nプレイヤー.b >= 16000) { v敵キャラアイテム作成(n地面[t_].a + 1500, 44000, 0, -2000, 0, 4, 0); }
                                else if (n地面[t_].xtype == 2) { v敵キャラアイテム作成(n地面[t_].a + 4500, 30000, 0, -1600, 0, 5, 0); v効果音再生(Res.nオーディオ10); n地面[t_].xtype = 3; n地面[t_].a -= 12000; }
                                else if (n地面[t_].xtype == 3) { n地面[t_].a += 12000; n地面[t_].xtype = 4; }
                                else if (n地面[t_].xtype == 4) { v敵キャラアイテム作成(n地面[t_].a + 4500, 30000, 0, -1600, 0, 5, 0); v効果音再生(Res.nオーディオ10); n地面[t_].xtype = 5; n地面[t_].xtype = 0; }

                                else if (n地面[t_].xtype == 7) { nプレイヤー.ainmsgtype = 1; }
                                else if (n地面[t_].xtype == 8) { v敵キャラアイテム作成(n地面[t_].a - 5000 - 3000 * 1, 26000, 0, -1600, 0, 5, 0); v効果音再生(Res.nオーディオ10); }
                                else if (n地面[t_].xtype == 9) { for (int t3 = 0; t3 <= 2; t3++) { v敵キャラアイテム作成(n地面[t_].a + t3 * 3000 + 3000, 48000, 0, -6000, 0, 3, 0); } }
                                if (n地面[t_].xtype == 10) { n地面[t_].a -= 5 * 30 * 100; n地面[t_].type = 101; }

                                if (n地面[t_].xtype == 12)
                                {
                                    for (int t3 = 1; t3 <= 3; t3++) { v敵キャラアイテム作成(n地面[t_].a + t3 * 3000 - 1000, 40000, 0, -2600, 0, 9, 0); }
                                }

                                //スクロール消し
                                if (n地面[t_].xtype == 20)
                                {
                                    scrollX = 0;
                                }

                                //クリア
                                if (n地面[t_].xtype == 30)
                                {
                                    n地面[t_].a = -80000000; nプレイヤー.d = 0;
                                    DX.StopSoundMem(Res.n現在のBGM); nプレイヤー.type = 302; nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ16);
                                }

                                if (n地面[t_].xtype != 3 && n地面[t_].xtype != 4 && n地面[t_].xtype != 10) { n地面[t_].a = -800000000; }
                            }

                            if (n地面[t_].type == 103)
                            {
                                if (n地面[t_].xtype == 0)
                                {
                                    n敵キャラ[n敵キャラco].msgtm = 10; n敵キャラ[n敵キャラco].msgtype = 50; v敵キャラアイテム作成(n地面[t_].a + 9000, n地面[t_].b + 2000, 0, 0, 0, 79, 0); n地面[t_].a = -800000000;
                                }

                                if (n地面[t_].xtype == 1 && nブロック[6].type <= 6)
                                {
                                    n敵キャラ[n敵キャラco].msgtm = 10; n敵キャラ[n敵キャラco].msgtype = 50; v敵キャラアイテム作成(n地面[t_].a - 12000, n地面[t_].b + 2000, 0, 0, 0, 79, 0); n地面[t_].a = -800000000;
                                    nブロック[9].xtype = 500;//ttype[9]=1;
                                }
                            }//103

                            if (n地面[t_].type == 104)
                            {
                                if (n地面[t_].xtype == 0)
                                {
                                    v敵キャラアイテム作成(n地面[t_].a + 12000, n地面[t_].b + 2000 + 3000, 0, 0, 0, 79, 0);
                                    v敵キャラアイテム作成(n地面[t_].a + 12000, n地面[t_].b + 2000 + 3000, 0, 0, 0, 79, 1);
                                    v敵キャラアイテム作成(n地面[t_].a + 12000, n地面[t_].b + 2000 + 3000, 0, 0, 0, 79, 2);
                                    v敵キャラアイテム作成(n地面[t_].a + 12000, n地面[t_].b + 2000 + 3000, 0, 0, 0, 79, 3);
                                    v敵キャラアイテム作成(n地面[t_].a + 12000, n地面[t_].b + 2000 + 3000, 0, 0, 0, 79, 4);
                                    n地面[t_].a = -800000000;
                                }
                            }

                            if (n地面[t_].type == 105 && nプレイヤー.zimen == 0 && nプレイヤー.d >= 0) { nブロック[1].a -= 1000; nブロック[2].a += 1000; n地面[t_].xtype++; if (n地面[t_].xtype >= 3) n地面[t_].a = -8000000; }


                            if (n地面[t_].type == 300 && nプレイヤー.type == 0 && nプレイヤー.b < xx_9 + n地面[t_].d + xx_0 - 3000 && nプレイヤー.hp >= 1) { DX.StopSoundMem(Res.n現在のBGM); nプレイヤー.type = 300; nプレイヤー.tm = 0; ma = n地面[t_].a - fx - 2000; v効果音再生(Res.nオーディオ11); }

                            //中間ゲート
                            if (n地面[t_].type == 500 && nプレイヤー.type == 0 && nプレイヤー.hp >= 1)
                            {
                                n中間フラグ += 1;
                                n地面[t_].a = -80000000;
                            }

                        }

                        if (n地面[t_].type == 180)
                        {
                            n地面[t_].r++;
                            if (n地面[t_].r >= n地面[t_].gtype)
                            {
                                n地面[t_].r = 0;
                                v敵キャラアイテム作成(n地面[t_].a, 30000, DX.GetRand(600) - 300, -1600 - DX.GetRand(900), 0, 84, 0);
                            }
                        }

                    }
                }
            }//壁
        }

        static void DrawZimen()
        {
            //地面(壁)//土管も
            for (int t_ = 0; t_ < n地面max; t_++)
            {
                if (n地面[t_].a - fx + n地面[t_].c >= -10 && n地面[t_].a - fx <= n画面幅 + 1100)
                {

                    if (n地面[t_].type == 0)
                    {
                        DXDraw.SetColor(40, 200, 40);
                        DXDraw.DrawBox塗り潰し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb, n地面[t_].c / 100, n地面[t_].d / 100);
                        DXDraw.DrawBox塗り無し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb, n地面[t_].c / 100, n地面[t_].d / 100);
                    }
                    //土管
                    if (n地面[t_].type == 1)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb, n地面[t_].c / 100, n地面[t_].d / 100);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb, n地面[t_].c / 100, n地面[t_].d / 100);
                    }
                    //土管(下)
                    if (n地面[t_].type == 2)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb + 1, n地面[t_].c / 100, n地面[t_].d / 100);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawLine((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb, (n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb + n地面[t_].d / 100);
                        DXDraw.DrawLine((n地面[t_].a - fx) / 100 + n全体のポイントa + n地面[t_].c / 100, (n地面[t_].b - fy) / 100 + n全体のポイントb, (n地面[t_].a - fx) / 100 + n全体のポイントa + n地面[t_].c / 100, (n地面[t_].b - fy) / 100 + n全体のポイントb + n地面[t_].d / 100);
                    }

                    //土管(横)
                    if (n地面[t_].type == 5)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb + 1, n地面[t_].c / 100, n地面[t_].d / 100);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawLine((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb, (n地面[t_].a - fx) / 100 + n全体のポイントa + n地面[t_].c / 100, (n地面[t_].b - fy) / 100 + n全体のポイントb);
                        DXDraw.DrawLine((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb + n地面[t_].d / 100, (n地面[t_].a - fx) / 100 + n全体のポイントa + n地面[t_].c / 100, (n地面[t_].b - fy) / 100 + n全体のポイントb + n地面[t_].d / 100);
                    }


                    //落ちてくるブロック
                    if (n地面[t_].type == 51)
                    {
                        if (n地面[t_].xtype == 0)
                        {
                            for (int t3 = 0; t3 <= n地面[t_].c / 3000; t3++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像[1, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + n全体のポイントb);
                            }
                        }
                        if (n地面[t_].xtype == 1 || n地面[t_].xtype == 2)
                        {
                            for (int t3 = 0; t3 <= n地面[t_].c / 3000; t3++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像[31, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + n全体のポイントb);
                            }
                        }
                        if (n地面[t_].xtype == 3 || n地面[t_].xtype == 4)
                        {
                            for (int t3 = 0; t3 <= n地面[t_].c / 3000; t3++)
                            {
                                for (int t2 = 0; t2 <= n地面[t_].d / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(Res.n切り取り画像[65, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + 29 * t2 + n全体のポイントb);
                                }
                            }
                        }

                        if (n地面[t_].xtype == 10)
                        {
                            for (int t3 = 0; t3 <= n地面[t_].c / 3000; t3++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像[65, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + n全体のポイントb);
                            }
                        }

                    }//51


                    //落ちるやつ
                    if (n地面[t_].type == 52)
                    {
                        int xx_29 = 0; if (nステージ色 == 2) { xx_29 = 30; }
                        if (nステージ色 == 4) { xx_29 = 60; }
                        if (nステージ色 == 5) { xx_29 = 90; }

                        for (int t3 = 0; t3 <= n地面[t_].c / 3000; t3++)
                        {
                            if (n地面[t_].xtype == 0)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像[5 + xx_29, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + n全体のポイントb);
                                if (nステージ色 != 4) { DXDraw.DrawGraph(Res.n切り取り画像[6 + xx_29, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + n全体のポイントb + 29); }
                                else { DXDraw.DrawGraph(Res.n切り取り画像[5 + xx_29, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + n全体のポイントb + 29); }
                            }
                            if (n地面[t_].xtype == 1)
                            {
                                for (int t2 = 0; t2 <= n地面[t_].d / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(Res.n切り取り画像[1 + xx_29, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + n全体のポイントb + 29 * t2);
                                }
                            }

                            if (n地面[t_].xtype == 2)
                            {
                                for (int t2 = 0; t2 <= n地面[t_].d / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(Res.n切り取り画像[5 + xx_29, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + n全体のポイントb + 29 * t2);
                                }
                            }

                        }
                    }


                    //ステージトラップ
                    if (bトラップ表示)
                    {
                        if (n地面[t_].type >= 100 && n地面[t_].type <= 299)
                        {
                            if (nステージ色 == 1 || nステージ色 == 3 || nステージ色 == 5) DXDraw.SetColorBlack();
                            if (nステージ色 == 2 || nステージ色 == 4) DXDraw.SetColorWhite();
                            DXDraw.DrawBox塗り無し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb, n地面[t_].c / 100, n地面[t_].d / 100);
                        }
                    }

                    //ゴール
                    if (n地面[t_].type == 300)
                    {
                        DXDraw.SetColorWhite();
                        DXDraw.DrawBox塗り潰し((n地面[t_].a - fx) / 100 + 10, (n地面[t_].b - fy) / 100, 10, n地面[t_].d / 100 - 8);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((n地面[t_].a - fx) / 100 + 10, (n地面[t_].b - fy) / 100, 10, n地面[t_].d / 100 - 8);
                        DXDraw.SetColor(250, 250, 0);
                        DXDraw.DrawOval塗り潰し((n地面[t_].a - fx) / 100 + 15 - 1, (n地面[t_].b - fy) / 100, 10, 10);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawOval塗り無し((n地面[t_].a - fx) / 100 + 15 - 1, (n地面[t_].b - fy) / 100, 10, 10);
                    }

                    //中間
                    if (n地面[t_].type == 500)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像[20, 4], (n地面[t_].a - fx) / 100, (n地面[t_].b - fy) / 100);
                    }
                }
            }//t


            //描画上書き(土管)
            for (int t_ = 0; t_ < n地面max; t_++)
            {
                if (n地面[t_].a - fx + n地面[t_].c >= -10 && n地面[t_].a - fx <= n画面幅 + 1100)
                {

                    //入る土管(右)
                    if (n地面[t_].type == 40)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb + 1, n地面[t_].c / 100, n地面[t_].d / 100);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb + 1, n地面[t_].c / 100, n地面[t_].d / 100);
                    }

                    //とぶ土管
                    if (n地面[t_].type == 50)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面[t_].a - fx) / 100 + n全体のポイントa + 5, (n地面[t_].b - fy) / 100 + n全体のポイントb + 30, 50, n地面[t_].d / 100 - 30);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawLine((n地面[t_].a - fx) / 100 + 5 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb + 30, (n地面[t_].a - fx) / 100 + n全体のポイントa + 5, (n地面[t_].b - fy) / 100 + n全体のポイントb + n地面[t_].d / 100);
                        DXDraw.DrawLine((n地面[t_].a - fx) / 100 + 5 + n全体のポイントa + 50, (n地面[t_].b - fy) / 100 + n全体のポイントb + 30, (n地面[t_].a - fx) / 100 + n全体のポイントa + 50 + 5, (n地面[t_].b - fy) / 100 + n全体のポイントb + n地面[t_].d / 100);

                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb + 1, 60, 30);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((n地面[t_].a - fx) / 100 + n全体のポイントa, (n地面[t_].b - fy) / 100 + n全体のポイントb + 1, 60, 30);
                    }

                    //地面(ブロック)
                    if (n地面[t_].type == 200)
                    {
                        for (int t3 = 0; t3 <= n地面[t_].c / 3000; t3++)
                        {
                            for (int t2 = 0; t2 <= n地面[t_].d / 3000; t2++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像[65, 1], (n地面[t_].a - fx) / 100 + n全体のポイントa + 29 * t3, (n地面[t_].b - fy) / 100 + 29 * t2 + n全体のポイントb);
                            }
                        }
                    }

                }
            }//t
        }
    }
}

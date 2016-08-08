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
        static void UpdateZimen()
        {
            //壁
            for (int t_ = 0; t_ < n地面max; t_++)
            {
                if (n地面a[t_] - fx + n地面c[t_] >= -12000 && n地面a[t_] - fx <= n画面幅)
                {
                    xx[0] = 200; xx[1] = 2400; xx[2] = 1000; xx[7] = 0;

                    xx[8] = n地面a[t_] - fx; xx[9] = n地面b[t_] - fy;
                    if ((n地面type[t_] <= 99 || n地面type[t_] == 200) && nプレイヤーtype < 10)
                    {

                        //おちるブロック
                        if (n地面type[t_] == 51)
                        {
                            if (ma + nプレイヤーnobia > xx[8] + xx[0] + 3000 && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] + 3000 && n地面gtype[t_] == 0)
                            {
                                if (n地面xtype[t_] == 0)
                                {
                                    n地面gtype[t_] = 1; n地面r[t_] = 0;
                                }
                            }
                            if (ma + nプレイヤーnobia > xx[8] + xx[0] + 1000 && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] + 3000 && n地面gtype[t_] == 0)
                            {
                                if ((n地面xtype[t_] == 10) && n地面gtype[t_] == 0)
                                {
                                    n地面gtype[t_] = 1; n地面r[t_] = 0;
                                }
                            }

                            if ((n地面xtype[t_] == 1) && n地面b[27] >= 25000 && n地面a[27] > ma + nプレイヤーnobia && t_ != 27 && n地面gtype[t_] == 0)
                            {
                                n地面gtype[t_] = 1; n地面r[t_] = 0;
                            }
                            if (n地面xtype[t_] == 2 && n地面b[28] >= 48000 && t_ != 28 && n地面gtype[t_] == 0 && nプレイヤーhp >= 1)
                            {
                                n地面gtype[t_] = 1; n地面r[t_] = 0;
                            }
                            if ((n地面xtype[t_] == 3 && nプレイヤーb >= 30000 || n地面xtype[t_] == 4 && nプレイヤーb >= 25000) && n地面gtype[t_] == 0 && nプレイヤーhp >= 1 && ma + nプレイヤーnobia > xx[8] + xx[0] + 3000 - 300 && ma < xx[8] + n地面c[t_] - xx[0])
                            {
                                n地面gtype[t_] = 1; n地面r[t_] = 0;
                                if (n地面xtype[t_] == 4) n地面r[t_] = 100;
                            }

                            if (n地面gtype[t_] == 1 && n地面b[t_] <= n画面高さ + 18000)
                            {
                                n地面r[t_] += 120; if (n地面r[t_] >= 1600) { n地面r[t_] = 1600; }
                                n地面b[t_] += n地面r[t_];
                                if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb < xx[9] + n地面d[t_] + xx[0])
                                {
                                    nプレイヤーhp--; xx[7] = 1;
                                }
                            }
                        }

                        //おちるブロック2
                        if (n地面type[t_] == 52)
                        {
                            if (n地面gtype[t_] == 0 && ma + nプレイヤーnobia > xx[8] + xx[0] + 2000 && ma < xx[8] + n地面c[t_] - xx[0] - 2500 && nプレイヤーb + nプレイヤーnobib > xx[9] - 3000)
                            {
                                n地面gtype[t_] = 1; n地面r[t_] = 0;
                            }
                            if (n地面gtype[t_] == 1)
                            {
                                n地面r[t_] += 120; if (n地面r[t_] >= 1600) { n地面r[t_] = 1600; }
                                n地面b[t_] += n地面r[t_];
                            }
                        }



                        //通常地面
                        if (xx[7] == 0)
                        {
                            if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] && nプレイヤーd >= -100) { nプレイヤーb = n地面b[t_] - fy - nプレイヤーnobib + 100; nプレイヤーd = 0; nプレイヤーzimen = 1; }
                            if (ma + nプレイヤーnobia > xx[8] - xx[0] && ma < xx[8] + xx[2] && nプレイヤーb + nプレイヤーnobib > xx[9] + xx[1] * 3 / 4 && nプレイヤーb < xx[9] + n地面d[t_] - xx[2]) { ma = xx[8] - xx[0] - nプレイヤーnobia; nプレイヤーc = 0; }
                            if (ma + nプレイヤーnobia > xx[8] + n地面c[t_] - xx[0] && ma < xx[8] + n地面c[t_] + xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] + xx[1] * 3 / 4 && nプレイヤーb < xx[9] + n地面d[t_] - xx[2]) { ma = xx[8] + n地面c[t_] + xx[0]; nプレイヤーc = 0; }
                            if (ma + nプレイヤーnobia > xx[8] + xx[0] * 2 && ma < xx[8] + n地面c[t_] - xx[0] * 2 && nプレイヤーb > xx[9] + n地面d[t_] - xx[1] && nプレイヤーb < xx[9] + n地面d[t_] + xx[0])
                            {
                                nプレイヤーb = xx[9] + n地面d[t_] + xx[0]; if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd * 2 / 3; }
                            }
                        }//xx[7]

                        //入る土管
                        if (n地面type[t_] == 50)
                        {
                            if (ma + nプレイヤーnobia > xx[8] + 2800 && ma < xx[8] + n地面c[t_] - 3000 && nプレイヤーb + nプレイヤーnobib > xx[9] - 1000 && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] + 3000 && nプレイヤーzimen == 1 && nプレイヤーactaon[3] == 1 && nプレイヤーtype == 0)
                            {
                                //飛び出し
                                if (n地面xtype[t_] == 0)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 0;
                                }
                                //普通
                                if (n地面xtype[t_] == 1)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 1;
                                }
                                //普通
                                if (n地面xtype[t_] == 2)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 2;
                                }
                                if (n地面xtype[t_] == 5)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 5;
                                }
                                // ループ
                                if (n地面xtype[t_] == 6)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 6;
                                }
                            }
                        }//50

                        //入る土管(左から)
                        if (n地面type[t_] == 40)
                        {
                            if (ma + nプレイヤーnobia > xx[8] - 300 && ma < xx[8] + n地面c[t_] - 1000 && nプレイヤーb > xx[9] + 1000 && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] + 4000 && nプレイヤーzimen == 1 && nプレイヤーactaon[4] == 1 && nプレイヤーtype == 0)
                            {//end();
                             //飛び出し
                                if (n地面xtype[t_] == 0)
                                {
                                    nプレイヤーtype = 500; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]);//mxtype=1;
                                    nプレイヤーtype = 100; nプレイヤーxtype = 10;
                                }

                                if (n地面xtype[t_] == 2)
                                {
                                    nプレイヤーxtype = 3;
                                    nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]);//mxtype=1;
                                    nプレイヤーtype = 100;
                                }
                                // ループ
                                if (n地面xtype[t_] == 6)
                                {
                                    nプレイヤーtype = 3; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 6;
                                }
                            }
                        }//40




                    }//stype
                    else {
                        if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb < xx[9] + n地面d[t_] + xx[0])
                        {
                            if (n地面type[t_] == 100)
                            {
                                if (n地面xtype[t_] == 0 || n地面xtype[t_] == 1 && nブロックtype[1] != 3)
                                {
                                    ayobi(n地面a[t_] + 1000, 32000, 0, 0, 0, 3, 0); n地面a[t_] = -800000000; v効果音再生(Res.nオーディオ_[10]);
                                }
                            }
                            if (n地面type[t_] == 101) { ayobi(n地面a[t_] + 6000, -4000, 0, 0, 0, 3, 1); n地面a[t_] = -800000000; v効果音再生(Res.nオーディオ_[10]); }
                            if (n地面type[t_] == 102)
                            {
                                if (n地面xtype[t_] == 0)
                                {
                                    for (int t3 = 0; t3 <= 3; t3++) { ayobi(n地面a[t_] + t3 * 3000, -3000, 0, 0, 0, 0, 0); }
                                }
                                if (n地面xtype[t_] == 1 && nプレイヤーb >= 16000) { ayobi(n地面a[t_] + 1500, 44000, 0, -2000, 0, 4, 0); }
                                else if (n地面xtype[t_] == 2) { ayobi(n地面a[t_] + 4500, 30000, 0, -1600, 0, 5, 0); v効果音再生(Res.nオーディオ_[10]); n地面xtype[t_] = 3; n地面a[t_] -= 12000; }
                                else if (n地面xtype[t_] == 3) { n地面a[t_] += 12000; n地面xtype[t_] = 4; }
                                else if (n地面xtype[t_] == 4) { ayobi(n地面a[t_] + 4500, 30000, 0, -1600, 0, 5, 0); v効果音再生(Res.nオーディオ_[10]); n地面xtype[t_] = 5; n地面xtype[t_] = 0; }

                                else if (n地面xtype[t_] == 7) { nプレイヤーainmsgtype = 1; }
                                else if (n地面xtype[t_] == 8) { ayobi(n地面a[t_] - 5000 - 3000 * 1, 26000, 0, -1600, 0, 5, 0); v効果音再生(Res.nオーディオ_[10]); }
                                else if (n地面xtype[t_] == 9) { for (int t3 = 0; t3 <= 2; t3++) { ayobi(n地面a[t_] + t3 * 3000 + 3000, 48000, 0, -6000, 0, 3, 0); } }
                                if (n地面xtype[t_] == 10) { n地面a[t_] -= 5 * 30 * 100; n地面type[t_] = 101; }

                                if (n地面xtype[t_] == 12)
                                {
                                    for (int t3 = 1; t3 <= 3; t3++) { ayobi(n地面a[t_] + t3 * 3000 - 1000, 40000, 0, -2600, 0, 9, 0); }
                                }

                                //スクロール消し
                                if (n地面xtype[t_] == 20)
                                {
                                    scrollX = 0;
                                }

                                //クリア
                                if (n地面xtype[t_] == 30)
                                {
                                    n地面a[t_] = -80000000; nプレイヤーd = 0;
                                    DX.StopSoundMem(Res.nオーディオ_[0]); nプレイヤーtype = 302; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[16]);
                                }

                                if (n地面xtype[t_] != 3 && n地面xtype[t_] != 4 && n地面xtype[t_] != 10) { n地面a[t_] = -800000000; }
                            }

                            if (n地面type[t_] == 103)
                            {
                                if (n地面xtype[t_] == 0)
                                {
                                    n敵キャラmsgtm[n敵キャラco] = 10; n敵キャラmsgtype[n敵キャラco] = 50; ayobi(n地面a[t_] + 9000, n地面b[t_] + 2000, 0, 0, 0, 79, 0); n地面a[t_] = -800000000;
                                }

                                if (n地面xtype[t_] == 1 && nブロックtype[6] <= 6)
                                {
                                    n敵キャラmsgtm[n敵キャラco] = 10; n敵キャラmsgtype[n敵キャラco] = 50; ayobi(n地面a[t_] - 12000, n地面b[t_] + 2000, 0, 0, 0, 79, 0); n地面a[t_] = -800000000;
                                    nブロックxtype[9] = 500;//ttype[9]=1;
                                }
                            }//103

                            if (n地面type[t_] == 104)
                            {
                                if (n地面xtype[t_] == 0)
                                {
                                    ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 0);
                                    ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 1);
                                    ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 2);
                                    ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 3);
                                    ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 4);
                                    n地面a[t_] = -800000000;
                                }
                            }

                            if (n地面type[t_] == 105 && nプレイヤーzimen == 0 && nプレイヤーd >= 0) { nブロックa[1] -= 1000; nブロックa[2] += 1000; n地面xtype[t_]++; if (n地面xtype[t_] >= 3) n地面a[t_] = -8000000; }


                            if (n地面type[t_] == 300 && nプレイヤーtype == 0 && nプレイヤーb < xx[9] + n地面d[t_] + xx[0] - 3000 && nプレイヤーhp >= 1) { DX.StopSoundMem(Res.nオーディオ_[0]); nプレイヤーtype = 300; nプレイヤーtm = 0; ma = n地面a[t_] - fx - 2000; v効果音再生(Res.nオーディオ_[11]); }

                            //中間ゲート
                            if (n地面type[t_] == 500 && nプレイヤーtype == 0 && nプレイヤーhp >= 1)
                            {
                                n中間フラグ += 1;
                                n地面a[t_] = -80000000;
                            }

                        }

                        if (n地面type[t_] == 180)
                        {
                            n地面r[t_]++;
                            if (n地面r[t_] >= n地面gtype[t_])
                            {
                                n地面r[t_] = 0;
                                ayobi(n地面a[t_], 30000, DX.GetRand(600) - 300, -1600 - DX.GetRand(900), 0, 84, 0);
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
                if (n地面a[t_] - fx + n地面c[t_] >= -10 && n地面a[t_] - fx <= n画面幅 + 1100)
                {

                    if (n地面type[t_] == 0)
                    {
                        DXDraw.SetColor(40, 200, 40);
                        DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                        DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                    }
                    //土管
                    if (n地面type[t_] == 1)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                    }
                    //土管(下)
                    if (n地面type[t_] == 2)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, n地面c[t_] / 100, n地面d[t_] / 100);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawLine((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, (n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);
                        DXDraw.DrawLine((n地面a[t_] - fx) / 100 + n全体のポイントa + n地面c[t_] / 100, (n地面b[t_] - fy) / 100 + n全体のポイントb, (n地面a[t_] - fx) / 100 + n全体のポイントa + n地面c[t_] / 100, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);
                    }

                    //土管(横)
                    if (n地面type[t_] == 5)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, n地面c[t_] / 100, n地面d[t_] / 100);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawLine((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, (n地面a[t_] - fx) / 100 + n全体のポイントa + n地面c[t_] / 100, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                        DXDraw.DrawLine((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100, (n地面a[t_] - fx) / 100 + n全体のポイントa + n地面c[t_] / 100, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);
                    }


                    //落ちてくるブロック
                    if (n地面type[t_] == 51)
                    {
                        if (n地面xtype[t_] == 0)
                        {
                            for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[1, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                            }
                        }
                        if (n地面xtype[t_] == 1 || n地面xtype[t_] == 2)
                        {
                            for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[31, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                            }
                        }
                        if (n地面xtype[t_] == 3 || n地面xtype[t_] == 4)
                        {
                            for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                for (int t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(Res.n切り取り画像_[65, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + 29 * t2 + n全体のポイントb);
                                }
                            }
                        }

                        if (n地面xtype[t_] == 10)
                        {
                            for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[65, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                            }
                        }

                    }//51


                    //落ちるやつ
                    if (n地面type[t_] == 52)
                    {
                        xx[29] = 0; if (nステージ色 == 2) { xx[29] = 30; }
                        if (nステージ色 == 4) { xx[29] = 60; }
                        if (nステージ色 == 5) { xx[29] = 90; }

                        for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                        {
                            if (n地面xtype[t_] == 0)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[5 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                                if (nステージ色 != 4) { DXDraw.DrawGraph(Res.n切り取り画像_[6 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29); }
                                else { DXDraw.DrawGraph(Res.n切り取り画像_[5 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29); }
                            }
                            if (n地面xtype[t_] == 1)
                            {
                                for (int t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(Res.n切り取り画像_[1 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29 * t2);
                                }
                            }

                            if (n地面xtype[t_] == 2)
                            {
                                for (int t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(Res.n切り取り画像_[5 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29 * t2);
                                }
                            }

                        }
                    }


                    //ステージトラップ
                    if (bトラップ表示)
                    {
                        if (n地面type[t_] >= 100 && n地面type[t_] <= 299)
                        {
                            if (nステージ色 == 1 || nステージ色 == 3 || nステージ色 == 5) DXDraw.SetColorBlack();
                            if (nステージ色 == 2 || nステージ色 == 4) DXDraw.SetColorWhite();
                            DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                        }
                    }

                    //ゴール
                    if (n地面type[t_] == 300)
                    {
                        DXDraw.SetColorWhite();
                        DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + 10, (n地面b[t_] - fy) / 100, 10, n地面d[t_] / 100 - 8);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + 10, (n地面b[t_] - fy) / 100, 10, n地面d[t_] / 100 - 8);
                        DXDraw.SetColor(250, 250, 0);
                        DXDraw.DrawOval塗り潰し((n地面a[t_] - fx) / 100 + 15 - 1, (n地面b[t_] - fy) / 100, 10, 10);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawOval塗り無し((n地面a[t_] - fx) / 100 + 15 - 1, (n地面b[t_] - fy) / 100, 10, 10);
                    }

                    //中間
                    if (n地面type[t_] == 500)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像_[20, 4], (n地面a[t_] - fx) / 100, (n地面b[t_] - fy) / 100);
                    }
                }
            }//t


            //描画上書き(土管)
            for (int t_ = 0; t_ < n地面max; t_++)
            {
                if (n地面a[t_] - fx + n地面c[t_] >= -10 && n地面a[t_] - fx <= n画面幅 + 1100)
                {

                    //入る土管(右)
                    if (n地面type[t_] == 40)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, n地面c[t_] / 100, n地面d[t_] / 100);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, n地面c[t_] / 100, n地面d[t_] / 100);
                    }

                    //とぶ土管
                    if (n地面type[t_] == 50)
                    {
                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa + 5, (n地面b[t_] - fy) / 100 + n全体のポイントb + 30, 50, n地面d[t_] / 100 - 30);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawLine((n地面a[t_] - fx) / 100 + 5 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 30, (n地面a[t_] - fx) / 100 + n全体のポイントa + 5, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);
                        DXDraw.DrawLine((n地面a[t_] - fx) / 100 + 5 + n全体のポイントa + 50, (n地面b[t_] - fy) / 100 + n全体のポイントb + 30, (n地面a[t_] - fx) / 100 + n全体のポイントa + 50 + 5, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);

                        DXDraw.SetColor(0, 230, 0);
                        DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, 60, 30);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, 60, 30);
                    }

                    //地面(ブロック)
                    if (n地面type[t_] == 200)
                    {
                        for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                        {
                            for (int t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[65, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + 29 * t2 + n全体のポイントb);
                            }
                        }
                    }

                }
            }//t
        }
    }
}

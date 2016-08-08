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
        static void Updateリフト()
        {
            //リフト
            for (int t_ = 0; t_ < nリフトmax; t_++)
            {
                xx[10] = nリフトa[t_]; xx[11] = nリフトb[t_]; xx[12] = nリフトc[t_]; xx[13] = nリフトd[t_];
                xx[8] = xx[10] - fx; xx[9] = xx[11] - fy;
                if (xx[8] + xx[12] >= -10 - 12000 && xx[8] <= n画面幅 + 12100)
                {
                    xx[0] = 500; xx[1] = 1200; xx[2] = 1000; xx[7] = 2000;
                    if (nプレイヤーd >= 100) { xx[1] = 900 + nプレイヤーd; }

                    if (nプレイヤーd > xx[1]) xx[1] = nプレイヤーd + 100;

                    nリフトb[t_] += nリフトe[t_];
                    nリフトe[t_] += nリフトf[t_];

                    //動き
                    switch (nリフトacttype[t_])
                    {

                        case 1:
                            if (nリフトon[t_] == 1) nリフトf[t_] = 60;
                            break;
                        case 2:
                            break;

                        case 3:
                        case 5:
                            if (nリフトmove[t_] == 0) { nリフトmuki[t_] = 0; }
                            else { nリフトmuki[t_] = 1; }
                            if (nリフトb[t_] - fy < -2100) { nリフトb[t_] = n画面高さ + fy + 2000; }
                            if (nリフトb[t_] - fy > n画面高さ + 2000) { nリフトb[t_] = -2100 + fy; }
                            break;

                        case 6:
                            if (nリフトon[t_] == 1) nリフトf[t_] = 40;
                            break;

                        case 7:
                            break;


                    }//sw

                    //乗ったとき
                    if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + xx[12] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] && nプレイヤーd >= -100)
                    {
                        nプレイヤーb = xx[9] - nプレイヤーnobib + 100;

                        if (nリフトtype[t_] == 1) { nリフトe[10] = 900; nリフトe[11] = 900; }

                        if (nリフトsp[t_] != 12)
                        {
                            nプレイヤーzimen = 1; nプレイヤーd = 0;
                        }
                        else {
                            //すべり
                            nプレイヤーd = -800;
                        }



                        //落下
                        if ((nリフトacttype[t_] == 1) && nリフトon[t_] == 0) nリフトon[t_] = 1;

                        if (nリフトacttype[t_] == 1 && nリフトon[t_] == 1 || nリフトacttype[t_] == 3 || nリフトacttype[t_] == 5)
                        {
                            nプレイヤーb += nリフトe[t_];
                        }

                        if (nリフトacttype[t_] == 7)
                        {
                            if (nプレイヤーactaon[2] != 1) { nプレイヤーd = -600; nプレイヤーb -= 810; }
                            if (nプレイヤーactaon[2] == 1) { nプレイヤーb -= 400; nプレイヤーd = -1400; nプレイヤーjumptm = 10; }
                        }


                        //特殊
                        if (nリフトsp[t_] == 1)
                        {
                            v効果音再生(Res.nオーディオ_[3]);
                            eyobi(nリフトa[t_] + 200, nリフトb[t_] - 1000, -240, -1400, 0, 160, 4500, 4500, 2, 120);
                            eyobi(nリフトa[t_] + 4500 - 200, nリフトb[t_] - 1000, 240, -1400, 0, 160, 4500, 4500, 3, 120);
                            nリフトa[t_] = -70000000;
                        }

                        if (nリフトsp[t_] == 2)
                        {
                            nプレイヤーc = -2400; nリフトmove[t_] += 1;
                            if (nリフトmove[t_] >= 100) { nプレイヤーhp = 0; nメッセージtype = 53; nメッセージtm = 30; nリフトmove[t_] = -5000; }
                        }

                        if (nリフトsp[t_] == 3)
                        {
                            nプレイヤーc = 2400; nリフトmove[t_] += 1;
                            if (nリフトmove[t_] >= 100) { nプレイヤーhp = 0; nメッセージtype = 53; nメッセージtm = 30; nリフトmove[t_] = -5000; }
                        }
                    }//判定内


                    //疲れ初期化
                    if ((nリフトsp[t_] == 2 || nリフトsp[t_] == 3) && nプレイヤーc != -2400 && nリフトmove[t_] > 0) { nリフトmove[t_]--; }

                    if (nリフトsp[t_] == 11)
                    {
                        if (ma + nプレイヤーnobia > xx[8] + xx[0] - 2000 && ma < xx[8] + xx[12] - xx[0]) { nリフトon[t_] = 1; }// && mb+mnobib>xx[9]-1000 && mb+mnobib<xx[9]+xx[1]+2000)
                        if (nリフトon[t_] == 1) { nリフトf[t_] = 60; nリフトb[t_] += nリフトe[t_]; }
                    }


                    //トゲ(下)
                    if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + xx[12] - xx[0] && nプレイヤーb > xx[9] - xx[1] / 2 && nプレイヤーb < xx[9] + xx[1] / 2)
                    {
                        if (nリフトtype[t_] == 2) { if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd; } nプレイヤーb += 110; if (nプレイヤーmutekitm <= 0) nプレイヤーhp -= 1; nプレイヤーmutekitm = 40; }
                    }
                    //落下
                    if (nリフトacttype[t_] == 6)
                    {
                        if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + xx[12] - xx[0]) { nリフトon[t_] = 1; }
                    }

                    if (nリフトacttype[t_] == 2 || nリフトacttype[t_] == 4)
                    {
                        if (nリフトmuki[t_] == 0) nリフトa[t_] -= nリフトsok[t_];
                        if (nリフトmuki[t_] == 1) nリフトa[t_] += nリフトsok[t_];
                    }
                    if (nリフトacttype[t_] == 3 || nリフトacttype[t_] == 5)
                    {
                        if (nリフトmuki[t_] == 0) nリフトb[t_] -= nリフトsok[t_];
                        if (nリフトmuki[t_] == 1) nリフトb[t_] += nリフトsok[t_];
                    }

                    //敵キャラ適用
                    for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                    {
                        if (n敵キャラzimentype[tt_] == 1)
                        {
                            if (n敵キャラa[tt_] + n敵キャラnobia[tt_] - fx > xx[8] + xx[0] && n敵キャラa[tt_] - fx < xx[8] + xx[12] - xx[0] && n敵キャラb[tt_] + n敵キャラnobib[tt_] > xx[11] - 100 && n敵キャラb[tt_] + n敵キャラnobib[tt_] < xx[11] + xx[1] + 500 && n敵キャラd[tt_] >= -100)
                            {
                                n敵キャラb[tt_] = xx[9] - n敵キャラnobib[tt_] + 100; n敵キャラd[tt_] = 0; n敵キャラxzimen[tt_] = 1;
                            }
                        }
                    }
                }
            }//リフト
        }

        static void Drawリフト()
        {
            //リフト
            for (int t_ = 0; t_ < nリフトmax; t_++)
            {
                xx[0] = nリフトa[t_] - fx; xx[1] = nリフトb[t_] - fy;
                if (xx[0] + nリフトc[t_] >= -10 && xx[1] <= n画面幅 + 12100 && nリフトc[t_] / 100 >= 1)
                {
                    xx[2] = 14; if (nリフトsp[t_] == 1) { xx[2] = 12; }

                    if (nリフトsp[t_] <= 9 || nリフトsp[t_] >= 20)
                    {
                        DXDraw.SetColor(220, 220, 0);
                        if (nリフトsp[t_] == 2 || nリフトsp[t_] == 3) { DXDraw.SetColor(0, 220, 0); }
                        if (nリフトsp[t_] == 21) { DXDraw.SetColor(180, 180, 180); }
                        DXDraw.DrawBox塗り潰し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, xx[2]);

                        DXDraw.SetColor(180, 180, 0);
                        if (nリフトsp[t_] == 2 || nリフトsp[t_] == 3) { DXDraw.SetColor(0, 180, 0); }
                        if (nリフトsp[t_] == 21) { DXDraw.SetColor(150, 150, 150); }
                        DXDraw.DrawBox塗り無し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, xx[2]);
                    }
                    else if (nリフトsp[t_] <= 14)
                    {
                        if (nリフトc[t_] >= 5000)
                        {
                            DXDraw.SetColor(0, 200, 0);
                            DXDraw.DrawBox塗り潰し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, 30);
                            DXDraw.SetColor(0, 160, 0);
                            DXDraw.DrawBox塗り無し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, 30);

                            DXDraw.SetColor(180, 120, 60);
                            DXDraw.DrawBox塗り潰し((nリフトa[t_] - fx) / 100 + 20, (nリフトb[t_] - fy) / 100 + 30, nリフトc[t_] / 100 - 40, 480);
                            DXDraw.SetColor(100, 80, 20);
                            DXDraw.DrawBox塗り無し((nリフトa[t_] - fx) / 100 + 20, (nリフトb[t_] - fy) / 100 + 30, nリフトc[t_] / 100 - 40, 480);

                        }
                    }
                    if (nリフトsp[t_] == 15)
                    {
                        for (t2 = 0; t2 <= 2; t2++)
                        {
                            xx[6] = 1 + 0; DXDraw.DrawGraph(Res.n切り取り画像_[xx[6], 1], (nリフトa[t_] - fx) / 100 + t2 * 29, (nリフトb[t_] - fy) / 100);
                        }
                    }//15
                }
            }//t
        }
    }
}
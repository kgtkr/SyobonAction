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
        static void UpdateEnemy()
        {
            //敵キャラの配置
            for (int t_ = 0; t_ < n敵出現max; t_++)
            {
                if (n敵出現a[t_] >= -80000)
                {

                    if (n敵出現tm[t_] >= 0) { n敵出現tm[t_] = n敵出現tm[t_] - 1; }

                    for (int tt_ = 0; tt_ <= 1; tt_++)
                    {
                        xx_0 = 0; xx_1 = 0;


                        if (n敵出現z[t_] == 0 && n敵出現tm[t_] < 0 && n敵出現a[t_] - fx >= n画面幅 + 2000 && n敵出現a[t_] - fx < n画面幅 + 2000 + nプレイヤーc && tt_ == 0) { xx_0 = 1; n敵キャラmuki[n敵キャラco] = 0; }// && mmuki==1
                        if (n敵出現z[t_] == 0 && n敵出現tm[t_] < 0 && n敵出現a[t_] - fx >= -400 - Res.n敵サイズW_[n敵出現type[t_]] + nプレイヤーc && n敵出現a[t_] - fx < -400 - Res.n敵サイズW_[n敵出現type[t_]] && tt_ == 1) { xx_0 = 1; xx_1 = 1; n敵キャラmuki[n敵キャラco] = 1; }// && mmuki==0
                        if (n敵出現z[t_] == 1 && n敵出現a[t_] - fx >= 0 - Res.n敵サイズW_[n敵出現type[t_]] && n敵出現a[t_] - fx <= n画面幅 + 4000 && n敵出現b[t_] - fy >= -9000 && n敵出現b[t_] - fy <= n画面高さ + 4000 && n敵出現tm[t_] < 0) { xx_0 = 1; n敵出現z[t_] = 0; }// && xza<=5000// && tyuukan!=1
                        if (xx_0 == 1)
                        {//400
                            n敵出現tm[t_] = 401; xx_0 = 0;
                            if (n敵出現type[t_] >= 10) { n敵出現tm[t_] = 9999999; }

                            //10
                            ayobi(n敵出現a[t_], n敵出現b[t_], 0, 0, 0, n敵出現type[t_], n敵出現xtype[t_]);

                        }

                    }//tt

                }
            }//t

            //敵キャラ
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {
                xx_0 = n敵キャラa[t_] - fx; xx_1 = n敵キャラb[t_] - fy;
                xx_2 = n敵キャラnobia[t_]; xx_3 = n敵キャラnobib[t_]; xx_14 = 12000 * 1;
                if (n敵キャラnotm[t_] >= 0) n敵キャラnotm[t_]--;
                if (xx_0 + xx_2 >= -xx_14 && xx_0 <= n画面幅 + xx_14 && xx_1 + xx_3 >= -10 - 9000 && xx_1 <= n画面高さ + 20000)
                {
                    n敵キャラacta[t_] = 0; n敵キャラactb[t_] = 0;

                    xx_10 = 0;

                    switch (n敵キャラtype[t_])
                    {
                        case 0:
                            xx_10 = 100;
                            break;

                        //こうらの敵
                        case 1:
                            xx_10 = 100;
                            break;

                        //こうら
                        case 2:
                            xx_10 = 0; xx_17 = 800;
                            if (n敵キャラxtype[t_] >= 1) xx_10 = xx_17;
                            //他の敵を倒す
                            if (n敵キャラxtype[t_] >= 1)
                            {
                                for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = n敵キャラa[tt_] - fx; xx_9 = n敵キャラb[tt_] - fy;
                                    if (t_ != tt_)
                                    {
                                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + n敵キャラnobia[tt_] - xx_0 * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_5 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                        {
                                            n敵キャラa[tt_] = -800000; v効果音再生(Res.nオーディオ_[6]);
                                        }
                                    }
                                }
                            }
                            break;

                        //あらまき
                        case 3:
                            n敵キャラzimentype[t_] = 0;//end();
                            if (n敵キャラxtype[t_] == 0)
                            {
                                n敵キャラb[t_] -= 800;
                            }
                            if (n敵キャラxtype[t_] == 1)
                                n敵キャラb[t_] += 1200;

                            //xx_10=100;
                            break;

                        //スーパージエン
                        case 4:
                            xx_10 = 120;
                            xx_0 = 250;
                            xx_8 = n敵キャラa[t_] - fx;
                            xx_9 = n敵キャラb[t_] - fy;
                            if (n敵キャラtm[t_] >= 0) n敵キャラtm[t_]--;
                            if (Math.Abs(ma + nプレイヤーnobia - xx_8 - xx_0 * 2) < 9000 &&
                                Math.Abs((ma < xx_8 - n敵キャラnobia[t_] + xx_0 * 2) ? 1 : 0) < 3000 &&
                                nプレイヤーd <= -600 && n敵キャラtm[t_] <= 0)
                            {
                                if (n敵キャラxtype[t_] == 1 && nプレイヤーzimen == 0 && n敵キャラxzimen[t_] == 1)
                                {
                                    n敵キャラd[t_] = -1600; n敵キャラtm[t_] = 40; n敵キャラb[t_] -= 1000;
                                }
                            }// 
                            break;

                        //クマー
                        case 5:
                            xx_10 = 160;
                            //azimentype[t]=2;
                            break;

                        //デフラグさん
                        case 6:
                            if (n敵キャラzimentype[t_] == 30) { n敵キャラd[t_] = -1600; n敵キャラb[t_] += n敵キャラd[t_]; }

                            xx_10 = 120;
                            if (n敵キャラtm[t_] >= 10)
                            {
                                n敵キャラtm[t_]++;
                                if (nプレイヤーhp >= 1)
                                {
                                    if (n敵キャラtm[t_] <= 19) { ma = xx_0; nプレイヤーb = xx_1 - 3000; nプレイヤーtype = 0; }
                                    xx_10 = 0;
                                    if (n敵キャラtm[t_] == 20) { nプレイヤーc = 700; nプレイヤーkeytm = 24; nプレイヤーd = -1200; nプレイヤーb = xx_1 - 1000 - 3000; n敵キャラmuki[t_] = 1; if (n敵キャラxtype[t_] == 1) { nプレイヤーc = 840; n敵キャラxtype[t_] = 0; } }
                                    if (n敵キャラtm[t_] == 40) { n敵キャラmuki[t_] = 0; n敵キャラtm[t_] = 0; }
                                }
                            }

                            //ポール捨て
                            if (n敵キャラxtype[t_] == 1)
                            {
                                for (int tt_ = 0; tt_ < n地面max; tt_++)
                                {
                                    if (n地面type[tt_] == 300)
                                    {
                                        if (n敵キャラa[t_] - fx >= -8000 && n敵キャラa[t_] >= n地面a[tt_] + 2000 && n敵キャラa[t_] <= n地面a[tt_] + 3600 && n敵キャラxzimen[t_] == 1) { n地面a[tt_] = -800000; n敵キャラtm[t_] = 100; }
                                    }
                                }

                                if (n敵キャラtm[t_] == 100)
                                {
                                    eyobi(n敵キャラa[t_] + 1200 - 1200, n敵キャラb[t_] + 3000 - 10 * 3000 - 1500, 0, 0, 0, 0, 1000, 10 * 3000 - 1200, 4, 20);
                                    if (nプレイヤーtype == 300) { nプレイヤーtype = 0; DX.StopSoundMem(Res.nオーディオ_[11]); bgmChange(Res.nオーディオ_[100]); DX.PlaySoundMem(Res.nオーディオ_[0], DX.DX_PLAYTYPE_LOOP); }
                                    for (int t1 = 0; t1 < n地面max; t1++) { if (n地面type[t1] == 104) n地面a[t1] = -80000000; }
                                }
                                if (n敵キャラtm[t_] == 120) { eyobi(n敵キャラa[t_] + 1200 - 1200, n敵キャラb[t_] + 3000 - 10 * 3000 - 1500, 600, -1200, 0, 160, 1000, 10 * 3000 - 1200, 4, 240); n敵キャラmuki[t_] = 1; }
                                if (n敵キャラtm[t_] == 140) { n敵キャラmuki[t_] = 0; n敵キャラtm[t_] = 0; }
                            }
                            if (n敵キャラtm[t_] >= 220) { n敵キャラtm[t_] = 0; n敵キャラmuki[t_] = 0; }

                            //他の敵を投げる
                            for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                            {
                                xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                xx_8 = n敵キャラa[tt_] - fx; xx_9 = n敵キャラb[tt_] - fy;
                                if (t_ != tt_ && n敵キャラtype[tt_] >= 100)
                                {
                                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + n敵キャラnobia[tt_] - xx_0 * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_5 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                    {
                                        //aa[tt]=-800000;
                                        n敵キャラmuki[tt_] = 1; n敵キャラa[tt_] = n敵キャラa[t_] + 300; n敵キャラb[tt_] = n敵キャラb[t_] - 3000; n敵キャラbrocktm[tt_] = 120;//aa[tt]=0;
                                        n敵キャラtm[t_] = 200; n敵キャラmuki[t_] = 1;
                                    }
                                }
                            }

                            break;

                        //ジエン大砲
                        case 7:
                            n敵キャラzimentype[t_] = 0;
                            xx_10 = 0; xx_11 = 400;
                            if (n敵キャラxtype[t_] == 0) xx_10 = xx_11;
                            if (n敵キャラxtype[t_] == 1) xx_10 = -xx_11;
                            if (n敵キャラxtype[t_] == 2) n敵キャラb[t_] -= xx_11;
                            if (n敵キャラxtype[t_] == 3) n敵キャラb[t_] += xx_11;
                            break;

                        //スーパーブーン
                        case 8:
                            n敵キャラzimentype[t_] = 0;
                            xx_22 = 20;
                            if (n敵キャラtm[t_] == 0) { n敵キャラf[t_] += xx_22; n敵キャラd[t_] += xx_22; }
                            if (n敵キャラtm[t_] == 1) { n敵キャラf[t_] -= xx_22; n敵キャラd[t_] -= xx_22; }
                            if (n敵キャラd[t_] > 300) n敵キャラd[t_] = 300;
                            if (n敵キャラd[t_] < -300) n敵キャラd[t_] = -300;
                            if (n敵キャラf[t_] >= 1200) n敵キャラtm[t_] = 1;
                            if (n敵キャラf[t_] < -0) n敵キャラtm[t_] = 0;
                            n敵キャラb[t_] += n敵キャラd[t_];
                            //atype[t]=151;
                            break;
                        //ノーマルブーン
                        case 151:
                            n敵キャラzimentype[t_] = 2;
                            break;

                        //ファイアー玉
                        case 9:
                            n敵キャラzimentype[t_] = 5;
                            n敵キャラb[t_] += n敵キャラd[t_]; n敵キャラd[t_] += 100;
                            if (n敵キャラb[t_] >= n画面高さ + 1000) { n敵キャラd[t_] = 900; }
                            if (n敵キャラb[t_] >= n画面高さ + 12000)
                            {
                                n敵キャラb[t_] = n画面高さ; n敵キャラd[t_] = -2600;
                            }
                            break;

                        //ファイアー
                        case 10:
                            n敵キャラzimentype[t_] = 0;
                            xx_10 = 0; xx_11 = 400;
                            if (n敵キャラxtype[t_] == 0) xx_10 = xx_11;
                            if (n敵キャラxtype[t_] == 1) xx_10 = -xx_11;
                            break;


                        //モララー
                        case 30:
                            n敵キャラtm[t_] += 1;
                            if (n敵キャラxtype[t_] == 0)
                            {
                                if (n敵キャラtm[t_] == 50 && nプレイヤーb >= 6000) { n敵キャラc[t_] = 300; n敵キャラd[t_] -= 1600; n敵キャラb[t_] -= 1000; }

                                for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = n敵キャラa[tt_] - fx; xx_9 = n敵キャラb[tt_] - fy;
                                    if (t_ != tt_ && n敵キャラtype[tt_] == 102)
                                    {
                                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + n敵キャラnobia[tt_] - xx_0 * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_5 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                        {
                                            n敵キャラa[tt_] = -800000; n敵キャラxtype[t_] = 1; n敵キャラd[t_] = -1600;
                                            n敵キャラmsgtm[t_] = 30; n敵キャラmsgtype[t_] = 25;
                                        }
                                    }
                                }
                            }
                            if (n敵キャラxtype[t_] == 1)
                            {
                                n敵キャラzimentype[t_] = 0;
                                n敵キャラb[t_] += n敵キャラd[t_]; n敵キャラd[t_] += 120;
                            }
                            break;

                        //レーザー
                        case 79:
                            n敵キャラzimentype[t_] = 0;
                            xx_10 = 1600;
                            if (n敵キャラxtype[t_] == 1) { xx_10 = 1200; n敵キャラb[t_] -= 200; }
                            if (n敵キャラxtype[t_] == 2) { xx_10 = 1200; n敵キャラb[t_] += 200; }
                            if (n敵キャラxtype[t_] == 3) { xx_10 = 900; n敵キャラb[t_] -= 600; }
                            if (n敵キャラxtype[t_] == 4) { xx_10 = 900; n敵キャラb[t_] += 600; }
                            break;

                        //雲の敵
                        case 80:
                            n敵キャラzimentype[t_] = 0;
                            //xx_10=100;
                            break;
                        case 81:
                            n敵キャラzimentype[t_] = 0;
                            break;
                        case 82:
                            n敵キャラzimentype[t_] = 0;
                            break;
                        case 83:
                            n敵キャラzimentype[t_] = 0;
                            break;

                        case 84:
                            n敵キャラzimentype[t_] = 2;
                            break;

                        case 85:
                            xx_23 = 400;
                            if (n敵キャラxtype[t_] == 0) { n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 1; }
                            if (nプレイヤーb >= 30000 && ma >= n敵キャラa[t_] - 3000 * 5 - fx && ma <= n敵キャラa[t_] - fx && n敵キャラxtype[t_] == 1) { n敵キャラxtype[t_] = 5; n敵キャラmuki[t_] = 0; }
                            if (nプレイヤーb >= 24000 && ma <= n敵キャラa[t_] + 3000 * 8 - fx && ma >= n敵キャラa[t_] - fx && n敵キャラxtype[t_] == 1) { n敵キャラxtype[t_] = 5; n敵キャラmuki[t_] = 1; }
                            if (n敵キャラxtype[t_] == 5) xx_10 = xx_23;
                            break;

                        case 86:
                            n敵キャラzimentype[t_] = 4;
                            xx_23 = 1000;
                            if (ma >= n敵キャラa[t_] - fx - nプレイヤーnobia - xx_26 && ma <= n敵キャラa[t_] - fx + n敵キャラnobia[t_] + xx_26) { n敵キャラtm[t_] = 1; }
                            if (n敵キャラtm[t_] == 1) { n敵キャラb[t_] += 1200; }
                            break;

                        //ファイアバー
                        case 87:
                            n敵キャラzimentype[t_] = 0;
                            if (n敵キャラa[t_] % 10 != 1) n敵キャラtm[t_] += 6;
                            else { n敵キャラtm[t_] -= 6; }
                            xx_25 = 2;
                            if (n敵キャラtm[t_] > 360 * xx_25) n敵キャラtm[t_] -= 360 * xx_25;
                            if (n敵キャラtm[t_] < 0) n敵キャラtm[t_] += 360 * xx_25;

                            for (int tt_ = 0; tt_ <= n敵キャラxtype[t_] % 100; tt_++)
                            {
                                xx_26 = 18;
                                double xd_4 = tt_ * xx_26 * Math.Cos(n敵キャラtm[t_] * Math.PI / 180 / 2); double xd_5 = tt_ * xx_26 * Math.Sin(n敵キャラtm[t_] * Math.PI / 180 / 2);

                                xx_4 = 1800; xx_5 = 800;
                                xx_8 = n敵キャラa[t_] - fx + (int)xd_4 * 100 - xx_4 / 2; xx_9 = n敵キャラb[t_] - fy + (int)xd_5 * 100 - xx_4 / 2;

                                if (ma + nプレイヤーnobia > xx_8 + xx_5 && ma < xx_8 + xx_4 - xx_5 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_5 && nプレイヤーb < xx_9 + xx_4 - xx_5)
                                {
                                    nプレイヤーhp -= 1;
                                    nメッセージtype = 51; nメッセージtm = 30;
                                }
                            }

                            break;

                        case 88:
                            n敵キャラzimentype[t_] = 0;
                            if (n敵キャラa[t_] % 10 != 1) n敵キャラtm[t_] += 6;
                            else { n敵キャラtm[t_] -= 6; }
                            xx_25 = 2;
                            if (n敵キャラtm[t_] > 360 * xx_25) n敵キャラtm[t_] -= 360 * xx_25;
                            if (n敵キャラtm[t_] < 0) n敵キャラtm[t_] += 360 * xx_25;

                            for (int tt_ = 0; tt_ <= n敵キャラxtype[t_] % 100; tt_++)
                            {
                                xx_26 = 18;
                                double xd_4 = -tt_ * xx_26 * Math.Cos(n敵キャラtm[t_] * Math.PI / 180 / 2);
                                double xd_5 = tt_ * xx_26 * Math.Sin(n敵キャラtm[t_] * Math.PI / 180 / 2);

                                xx_4 = 1800;
                                xx_5 = 800;
                                xx_8 = n敵キャラa[t_] - fx + (int)xd_4 * 100 - xx_4 / 2;
                                xx_9 = n敵キャラb[t_] - fy + (int)xd_5 * 100 - xx_4 / 2;

                                if (ma + nプレイヤーnobia > xx_8 + xx_5 && ma < xx_8 + xx_4 - xx_5 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_5 && nプレイヤーb < xx_9 + xx_4 - xx_5)
                                {
                                    nプレイヤーhp -= 1;
                                    nメッセージtype = 51; nメッセージtm = 30;
                                }
                            }

                            break;


                        case 90:
                            xx_10 = 160;
                            break;


                        //おいしいキノコ
                        case 100:
                            n敵キャラzimentype[t_] = 1;
                            xx_10 = 100;

                            //ほかの敵を巨大化
                            if (n敵キャラxtype[t_] == 2)
                            {
                                for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = n敵キャラa[tt_] - fx; xx_9 = n敵キャラb[tt_] - fy;
                                    if (t_ != tt_)
                                    {
                                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + n敵キャラnobia[tt_] - xx_0 * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_5 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 * 3 + xx_12)
                                        {
                                            if (n敵キャラtype[tt_] == 0 || n敵キャラtype[tt_] == 4)
                                            {
                                                n敵キャラtype[tt_] = 90;//ot(oto[6]);
                                                n敵キャラnobia[tt_] = 6400; n敵キャラnobib[tt_] = 6300; n敵キャラxtype[tt_] = 0;
                                                n敵キャラa[tt_] -= 1050; n敵キャラb[tt_] -= 1050;
                                                v効果音再生(Res.nオーディオ_[9]); n敵キャラa[t_] = -80000000;
                                            }
                                        }
                                    }
                                }
                            }

                            break;

                        //毒キノコ
                        case 102:
                            n敵キャラzimentype[t_] = 1;
                            xx_10 = 100;
                            if (n敵キャラxtype[t_] == 1) xx_10 = 200;
                            break;

                        //悪スター
                        case 110:
                            n敵キャラzimentype[t_] = 1;
                            xx_10 = 200;
                            if (n敵キャラxzimen[t_] == 1)
                            {
                                n敵キャラb[t_] -= 1200; n敵キャラd[t_] = -1400;
                            }
                            break;


                        case 200:
                            n敵キャラzimentype[t_] = 1;
                            xx_10 = 100;
                            break;


                    }//sw


                    if (n敵キャラbrocktm[t_] >= 1) xx_10 = 0;



                    if (n敵キャラmuki[t_] == 0) n敵キャラacta[t_] -= xx_10;
                    if (n敵キャラmuki[t_] == 1) n敵キャラacta[t_] += xx_10;

                    //最大値
                    xx_0 = 850; xx_1 = 1200;

                    if (n敵キャラd[t_] > xx_1 && n敵キャラzimentype[t_] != 5) { n敵キャラd[t_] = xx_1; }


                    //行動
                    n敵キャラa[t_] += n敵キャラacta[t_];//ab[t]+=aactb[t];

                    if ((n敵キャラzimentype[t_] >= 1 || n敵キャラzimentype[t_] == -1) && n敵キャラbrocktm[t_] <= 0)
                    {
                        //if (atype[t]==4)end();

                        //移動
                        n敵キャラa[t_] += n敵キャラc[t_];
                        if (n敵キャラzimentype[t_] >= 1 && n敵キャラzimentype[t_] <= 3) { n敵キャラb[t_] += n敵キャラd[t_]; n敵キャラd[t_] += 120; }//ad[t]+=180;


                        if (n敵キャラxzimen[t_] == 1)
                        {
                            xx_0 = 100;
                            if (n敵キャラc[t_] >= 200) { n敵キャラc[t_] -= xx_0; }
                            else if (n敵キャラc[t_] <= -200) { n敵キャラc[t_] += xx_0; }
                            else { n敵キャラc[t_] = 0; }
                        }

                        n敵キャラxzimen[t_] = 0;




                        //地面判定
                        if (n敵キャラzimentype[t_] != 2)
                        {
                            tekizimen(t_);
                        }


                    }//azimentype[t]>=1

                    //ブロックから出現するさい
                    if (n敵キャラbrocktm[t_] > 0)
                    {
                        n敵キャラbrocktm[t_]--;
                        if (n敵キャラbrocktm[t_] < 100) { n敵キャラb[t_] -= 180; }
                        if (n敵キャラbrocktm[t_] > 100) { }
                        if (n敵キャラbrocktm[t_] == 100) { n敵キャラb[t_] -= 800; n敵キャラd[t_] = -1200; n敵キャラc[t_] = 700; n敵キャラbrocktm[t_] = 0; }
                    }//abrocktm[t]>0

                    //プレイヤーからの判定
                    xx_0 = 250; xx_1 = 1600; xx_2 = 1000;
                    xx_4 = 500; xx_5 = -800;

                    xx_8 = n敵キャラa[t_] - fx; xx_9 = n敵キャラb[t_] - fy;
                    xx_12 = 0; if (nプレイヤーd >= 100) xx_12 = nプレイヤーd;
                    xx_25 = 0;

                    if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n敵キャラnobia[t_] - xx_0 * 2 && nプレイヤーb + nプレイヤーnobib > xx_9 - xx_5 && nプレイヤーb + nプレイヤーnobib < xx_9 + xx_1 + xx_12 && (nプレイヤーmutekitm <= 0 || nプレイヤーd >= 100) && n敵キャラbrocktm[t_] <= 0)
                    {
                        if (n敵キャラtype[t_] != 4 && n敵キャラtype[t_] != 9 && n敵キャラtype[t_] != 10 && (n敵キャラtype[t_] <= 78 || n敵キャラtype[t_] == 85) && nプレイヤーzimen != 1 && nプレイヤーtype != 200)
                        {

                            if (n敵キャラtype[t_] == 0)
                            {
                                if (n敵キャラxtype[t_] == 0)
                                    n敵キャラa[t_] = -900000;
                                if (n敵キャラxtype[t_] == 1)
                                {
                                    v効果音再生(Res.nオーディオ_[5]);
                                    nプレイヤーb = xx_9 - 900 - n敵キャラnobib[t_]; nプレイヤーd = -2100; xx_25 = 1; nプレイヤーactaon[2] = 0;
                                }
                            }

                            if (n敵キャラtype[t_] == 1)
                            {
                                n敵キャラtype[t_] = 2; n敵キャラnobib[t_] = 3000; n敵キャラxtype[t_] = 0;
                            }

                            //こうら
                            else if (n敵キャラtype[t_] == 2 && nプレイヤーd >= 0)
                            {
                                if (n敵キャラxtype[t_] == 1 || n敵キャラxtype[t_] == 2) { n敵キャラxtype[t_] = 0; }
                                else if (n敵キャラxtype[t_] == 0)
                                {
                                    if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n敵キャラnobia[t_] / 2 - xx_0 * 4)
                                    {
                                        n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 1;
                                    }
                                    else { n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 0; }
                                }
                            }
                            if (n敵キャラtype[t_] == 3)
                            {
                                xx_25 = 1;
                            }

                            if (n敵キャラtype[t_] == 6)
                            {
                                n敵キャラtm[t_] = 10; nプレイヤーd = 0; nプレイヤーactaon[2] = 0;
                            }

                            if (n敵キャラtype[t_] == 7)
                            {
                                n敵キャラa[t_] = -900000;
                            }

                            if (n敵キャラtype[t_] == 8)
                            {
                                n敵キャラtype[t_] = 151; n敵キャラd[t_] = 0;
                            }

                            if (n敵キャラtype[t_] != 85)
                            {
                                if (xx_25 == 0) { v効果音再生(Res.nオーディオ_[5]); nプレイヤーb = xx_9 - 1000 - n敵キャラnobib[t_]; nプレイヤーd = -1000; }
                            }
                            if (n敵キャラtype[t_] == 85)
                            {
                                if (xx_25 == 0) { v効果音再生(Res.nオーディオ_[5]); nプレイヤーb = xx_9 - 4000; nプレイヤーd = -1000; n敵キャラxtype[t_] = 5; }
                            }

                            if (nプレイヤーactaon[2] == 1) { nプレイヤーd = -1600; nプレイヤーactaon[2] = 0; }
                        }
                    }

                    xx_15 = -500;


                    //プレイヤーに触れた時
                    xx_16 = 0;
                    if (n敵キャラtype[t_] == 4 || n敵キャラtype[t_] == 9 || n敵キャラtype[t_] == 10) xx_16 = -3000;
                    if (n敵キャラtype[t_] == 82 || n敵キャラtype[t_] == 83 || n敵キャラtype[t_] == 84) xx_16 = -3200;
                    if (n敵キャラtype[t_] == 85) xx_16 = -n敵キャラnobib[t_] + 6000;
                    if (ma + nプレイヤーnobia > xx_8 + xx_4 && ma < xx_8 + n敵キャラnobia[t_] - xx_4 && nプレイヤーb < xx_9 + n敵キャラnobib[t_] + xx_15 && nプレイヤーb + nプレイヤーnobib > xx_9 + n敵キャラnobib[t_] - xx_0 + xx_16 && n敵キャラnotm[t_] <= 0 && n敵キャラbrocktm[t_] <= 0)
                    {
                        if (nプレイヤーmutekitm <= 0 && (n敵キャラtype[t_] <= 99 || n敵キャラtype[t_] >= 200))
                        {
                            if (nプレイヤーtype != 200)
                            {
                                //if (mmutekitm<=0)

                                //ダメージ
                                if ((n敵キャラtype[t_] != 2 || n敵キャラxtype[t_] != 0) && nプレイヤーhp >= 1)
                                {
                                    if (n敵キャラtype[t_] != 6)
                                    {
                                        nプレイヤーhp -= 1;
                                        //mmutekitm=40;
                                    }
                                }

                                if (n敵キャラtype[t_] == 6)
                                {
                                    n敵キャラtm[t_] = 10;
                                }


                                //せりふ
                                if (nプレイヤーhp == 0)
                                {

                                    if (n敵キャラtype[t_] == 0 || n敵キャラtype[t_] == 7)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = DX.GetRand(7) + 1 + 1000 + (nステージb - 1) * 10;
                                    }

                                    if (n敵キャラtype[t_] == 1)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = DX.GetRand(2) + 15;
                                    }

                                    if (n敵キャラtype[t_] == 2 && n敵キャラxtype[t_] >= 1 && nプレイヤーmutekitm <= 0)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = 18;
                                    }

                                    if (n敵キャラtype[t_] == 3)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = 20;
                                    }

                                    if (n敵キャラtype[t_] == 4)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = DX.GetRand(7) + 1 + 1000 + (nステージb - 1) * 10;
                                    }

                                    if (n敵キャラtype[t_] == 5)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = 21;
                                    }

                                    if (n敵キャラtype[t_] == 9 || n敵キャラtype[t_] == 10)
                                    {
                                        nメッセージtm = 30; nメッセージtype = 54;
                                    }



                                    if (n敵キャラtype[t_] == 31)
                                    {
                                        n敵キャラmsgtm[t_] = 30; n敵キャラmsgtype[t_] = 24;
                                    }


                                    if (n敵キャラtype[t_] == 80 || n敵キャラtype[t_] == 81)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = 30;
                                    }

                                    if (n敵キャラtype[t_] == 82)
                                    {
                                        n敵キャラmsgtm[t_] = 20; n敵キャラmsgtype[t_] = DX.GetRand(1) + 31;
                                        xx_24 = 900; n敵キャラtype[t_] = 83; n敵キャラa[t_] -= xx_24 + 100; n敵キャラb[t_] -= xx_24 - 100 * 0;
                                    }//82

                                    if (n敵キャラtype[t_] == 84)
                                    {
                                        nメッセージtm = 30; nメッセージtype = 50;
                                    }

                                    if (n敵キャラtype[t_] == 85)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = DX.GetRand(1) + 85;
                                    }


                                    //雲
                                    if (n敵キャラtype[t_] == 80)
                                    {
                                        n敵キャラtype[t_] = 81;
                                    }
                                }//mhp==0


                                //こうら
                                if (n敵キャラtype[t_] == 2)
                                {
                                    if (n敵キャラxtype[t_] == 0)
                                    {
                                        if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n敵キャラnobia[t_] / 2 - xx_0 * 4)
                                        {
                                            n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 1; n敵キャラa[t_] = ma + nプレイヤーnobia + fx + nプレイヤーc; nプレイヤーmutekitm = 5;
                                        }
                                        else {
                                            n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 0; n敵キャラa[t_] = ma - n敵キャラnobia[t_] + fx - nプレイヤーc; nプレイヤーmutekitm = 5;
                                        }
                                    }
                                    else { nプレイヤーhp -= 1; }//mmutekitm=40;}
                                }


                            }
                        }
                        //アイテム
                        if (n敵キャラtype[t_] >= 100 && n敵キャラtype[t_] <= 199)
                        {

                            if (n敵キャラtype[t_] == 100 && n敵キャラxtype[t_] == 0) { nメッセージtm = 30; nメッセージtype = 1; v効果音再生(Res.nオーディオ_[9]); }
                            if (n敵キャラtype[t_] == 100 && n敵キャラxtype[t_] == 1) { nメッセージtm = 30; nメッセージtype = 2; v効果音再生(Res.nオーディオ_[9]); }
                            if (n敵キャラtype[t_] == 100 && n敵キャラxtype[t_] == 2) { nプレイヤーnobia = 5200; nプレイヤーnobib = 7300; v効果音再生(Res.nオーディオ_[9]); ma -= 1100; nプレイヤーb -= 4000; nプレイヤーtype = 1; nプレイヤーhp = 50000000; }

                            if (n敵キャラtype[t_] == 101) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 11; }
                            if (n敵キャラtype[t_] == 102) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 10; }


                            //?ボール
                            if (n敵キャラtype[t_] == 105)
                            {
                                if (n敵キャラxtype[t_] == 0)
                                {
                                    v効果音再生(Res.nオーディオ_[4]); n地面gtype[26] = 6;
                                }
                                if (n敵キャラxtype[t_] == 1)
                                {
                                    nブロックxtype[7] = 80;
                                    v効果音再生(Res.nオーディオ_[4]);

                                    ayobi(n敵キャラa[t_] - 8 * 3000 - 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラa[t_] - 10 * 3000 + 1000, -1 * 3000, 0, 0, 0, 110, 0);

                                    ayobi(n敵キャラa[t_] + 4 * 3000 + 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラa[t_] + 5 * 3000 - 1000, -3 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラa[t_] + 6 * 3000 + 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラa[t_] + 7 * 3000 - 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラa[t_] + 8 * 3000 + 1000, -2 * 3000 - 1000, 0, 0, 0, 110, 0);
                                    nブロックb[0] += 3000 * 3;
                                }
                            }//105

                            if (n敵キャラtype[t_] == 110) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 3; }

                            n敵キャラa[t_] = -90000000;
                        }

                    }//(ma

                }
                else { n敵キャラa[t_] = -9000000; }

            }//t
        }

        static void DrawEnemy()
        {
            DXDraw.nミラー = 0;
            //敵キャラ
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {

                xx_0 = n敵キャラa[t_] - fx; xx_1 = n敵キャラb[t_] - fy;
                xx_2 = n敵キャラnobia[t_] / 100; xx_3 = n敵キャラnobib[t_] / 100; xx_14 = 3000; xx_16 = 0;
                if (xx_0 + xx_2 * 100 >= -10 - xx_14 && xx_1 <= n画面幅 + xx_14 && xx_1 + xx_3 * 100 >= -10 && xx_3 <= n画面高さ)
                {
                    if (n敵キャラmuki[t_] == 1) { DXDraw.nミラー = 1; }
                    if (n敵キャラtype[t_] == 3 && n敵キャラxtype[t_] == 1) { DX.DrawRotaGraph(xx_0 / 100 + 13, xx_1 / 100 + 15, 1.0f, Math.PI / 1, Res.n切り取り画像_[n敵キャラtype[t_], 3], DX.TRUE); xx_16 = 1; }
                    if (n敵キャラtype[t_] == 9 && n敵キャラd[t_] >= 1) { DX.DrawRotaGraph(xx_0 / 100 + 13, xx_1 / 100 + 15, 1.0f, Math.PI / 1, Res.n切り取り画像_[n敵キャラtype[t_], 3], DX.TRUE); xx_16 = 1; }
                    if (n敵キャラtype[t_] >= 100 && n敵キャラmuki[t_] == 1) DXDraw.nミラー = 0;

                    //メイン
                    if (n敵キャラtype[t_] < 200 && xx_16 == 0 && n敵キャラtype[t_] != 6 && n敵キャラtype[t_] != 79 && n敵キャラtype[t_] != 86 && n敵キャラtype[t_] != 30)
                    {
                        if (!((n敵キャラtype[t_] == 80 || n敵キャラtype[t_] == 81) && n敵キャラxtype[t_] == 1))
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[n敵キャラtype[t_], 3], xx_0 / 100, xx_1 / 100);
                        }
                    }


                    //デフラグさん
                    if (n敵キャラtype[t_] == 6)
                    {
                        if (n敵キャラtm[t_] >= 10 && n敵キャラtm[t_] <= 19 || n敵キャラtm[t_] >= 100 && n敵キャラtm[t_] <= 119 || n敵キャラtm[t_] >= 200)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[150, 3], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像_[6, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }

                    //モララー
                    if (n敵キャラtype[t_] == 30)
                    {
                        if (n敵キャラxtype[t_] == 0) DXDraw.DrawGraph(Res.n切り取り画像_[30, 3], xx_0 / 100, xx_1 / 100);
                        if (n敵キャラxtype[t_] == 1) DXDraw.DrawGraph(Res.n切り取り画像_[155, 3], xx_0 / 100, xx_1 / 100);
                    }



                    //ステルス雲
                    if ((n敵キャラtype[t_] == 81) && n敵キャラxtype[t_] == 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像_[130, 3], xx_0 / 100, xx_1 / 100);
                    }

                    if (n敵キャラtype[t_] == 79)
                    {
                        DXDraw.SetColor(250, 250, 0);
                        DXDraw.DrawBox塗り潰し(xx_0 / 100, xx_1 / 100, xx_2, xx_3);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し(xx_0 / 100, xx_1 / 100, xx_2, xx_3);
                    }

                    if (n敵キャラtype[t_] == 82)
                    {

                        if (n敵キャラxtype[t_] == 0)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 5 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (n敵キャラxtype[t_] == 1)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 4 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (n敵キャラxtype[t_] == 2)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[1, 5], xx_0 / 100, xx_1 / 100);
                        }

                    }
                    if (n敵キャラtype[t_] == 83)
                    {

                        if (n敵キャラxtype[t_] == 0)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 5 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100 + 10, xx_1 / 100 + 9);
                        }

                        if (n敵キャラxtype[t_] == 1)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 4 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100 + 10, xx_1 / 100 + 9);
                        }

                    }

                    //偽ポール
                    if (n敵キャラtype[t_] == 85)
                    {
                        DXDraw.SetColorWhite();
                        DXDraw.DrawBox塗り潰し((xx_0) / 100 + 10, (xx_1) / 100, 10, xx_3);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((xx_0) / 100 + 10, (xx_1) / 100, 10, xx_3);
                        DXDraw.SetColor(0, 250, 200);
                        DXDraw.DrawOval塗り潰し((xx_0) / 100 + 15 - 1, (xx_1) / 100, 10, 10);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawOval塗り無し((xx_0) / 100 + 15 - 1, (xx_1) / 100, 10, 10);

                    }//85


                    //ニャッスン
                    if (n敵キャラtype[t_] == 86)
                    {
                        if (ma >= n敵キャラa[t_] - fx - nプレイヤーnobia - 4000 && ma <= n敵キャラa[t_] - fx + n敵キャラnobia[t_] + 4000)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[152, 3], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像_[86, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }

                    if (n敵キャラtype[t_] == 200)
                        DXDraw.DrawGraph(Res.n切り取り画像_[0, 3], xx_0 / 100, xx_1 / 100);

                    DXDraw.nミラー = 0;
                }
            }
        }

        static void DrawEnemyファイアバー()
        {
            //ファイアバー
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {

                xx_0 = n敵キャラa[t_] - fx; xx_1 = n敵キャラb[t_] - fy;
                xx_14 = 12000; xx_16 = 0;
                if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88)
                {
                    if (xx_0 + xx_2 * 100 >= -10 - xx_14 && xx_1 <= n画面幅 + xx_14 && xx_1 + xx_3 * 100 >= -10 && xx_3 <= n画面高さ)
                    {

                        for (int tt_ = 0; tt_ <= n敵キャラxtype[t_] % 100; tt_++)
                        {
                            xx_26 = 18;
                            double xd_4 = tt_ * xx_26 * Math.Cos(n敵キャラtm[t_] * Math.PI / 180 / 2);
                            double xd_5 = tt_ * xx_26 * Math.Sin(n敵キャラtm[t_] * Math.PI / 180 / 2);
                            xx_24 = (int)xd_4;
                            xx_25 = (int)xd_5;
                            DXDraw.SetColor(230, 120, 0);
                            xx_23 = 8;
                            if (n敵キャラtype[t_] == 87)
                            {
                                DXDraw.DrawOval塗り潰し(xx_0 / 100 + xx_24, xx_1 / 100 + xx_25, xx_23, xx_23);
                                DXDraw.SetColor(0, 0, 0);
                                DXDraw.DrawOval塗り無し(xx_0 / 100 + xx_24, xx_1 / 100 + xx_25, xx_23, xx_23);
                            }
                            else {
                                DXDraw.DrawOval塗り潰し(xx_0 / 100 - xx_24, xx_1 / 100 + xx_25, xx_23, xx_23);
                                DXDraw.SetColor(0, 0, 0);
                                DXDraw.DrawOval塗り無し(xx_0 / 100 - xx_24, xx_1 / 100 + xx_25, xx_23, xx_23);
                            }
                        }
                    }
                }
            }
        }
    }
}

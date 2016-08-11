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
        struct C敵キャラ
        {
            public int a,
            b,
            nobia,
            nobib,
            c,
            d;
            public int e,
                f,
                brocktm;
            public int acta,
                actb,
                zimentype,
                xzimen;
            public int type,
                xtype,
                muki;
            public int notm;
            public int tm,
                _2tm;
            public int msgtm,
                msgtype;
        }

        //敵キャラ
        const int n敵キャラmax = 24;
        static int n敵キャラco;
        static C敵キャラ[] n敵キャラ = new C敵キャラ[n敵キャラmax];


        struct C敵出現
        {
            public int a,
            b,
            tm;
            public int type,
                xtype,
                z;
        }

        //敵出現
        const int n敵出現max = 81;
        static int n敵出現co;
        static C敵出現[] n敵出現 = new C敵出現[n敵出現max];

        static void UpdateEnemy()
        {
            //敵キャラの配置
            for (int t_ = 0; t_ < n敵出現max; t_++)
            {
                if (n敵出現[t_].a >= -80000)
                {

                    if (n敵出現[t_].tm >= 0)
                    {
                        n敵出現[t_].tm = n敵出現[t_].tm - 1;
                    }

                    for (int tt_ = 0; tt_ <= 1; tt_++)
                    {
                        xx_0 = 0; xx_1 = 0;


                        if (n敵出現[t_].z == 0 && n敵出現[t_].tm < 0 &&
                            n敵出現[t_].a - fx >= n画面幅 + 2000 &&
                            n敵出現[t_].a - fx < n画面幅 + 2000 + nプレイヤーc &&
                            tt_ == 0)
                        {
                            xx_0 = 1;
                            n敵キャラ[n敵キャラco].muki = 0;
                        }

                        if (n敵出現[t_].z == 0 &&
                            n敵出現[t_].tm < 0 &&
                            n敵出現[t_].a - fx >= -400 - Res.n敵サイズ[n敵出現[t_].type].w + nプレイヤーc &&
                            n敵出現[t_].a - fx < -400 - Res.n敵サイズ[n敵出現[t_].type].w
                            && tt_ == 1)
                        {
                            xx_0 = 1; xx_1 = 1;
                            n敵キャラ[n敵キャラco].muki = 1;
                        }

                        if (n敵出現[t_].z == 1 &&
                            n敵出現[t_].a - fx >= 0 - Res.n敵サイズ[n敵出現[t_].type].w &&
                            n敵出現[t_].a - fx <= n画面幅 + 4000 &&
                            n敵出現[t_].b - fy >= -9000 &&
                            n敵出現[t_].b - fy <= n画面高さ + 4000 &&
                            n敵出現[t_].tm < 0)
                        {
                            xx_0 = 1; n敵出現[t_].z = 0;
                        }
                        if (xx_0 == 1)
                        {//400
                            n敵出現[t_].tm = 401; xx_0 = 0;
                            if (n敵出現[t_].type >= 10)
                            {
                                n敵出現[t_].tm = 9999999;
                            }

                            //10
                            ayobi(n敵出現[t_].a, n敵出現[t_].b, 0, 0, 0, n敵出現[t_].type, n敵出現[t_].xtype);
                        }

                    }//tt
                }
            }//t

            //敵キャラ
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {
                xx_0 = n敵キャラ[t_].a - fx; xx_1 = n敵キャラ[t_].b - fy;
                xx_2 = n敵キャラ[t_].nobia; xx_3 = n敵キャラ[t_].nobib; xx_14 = 12000 * 1;
                if (n敵キャラ[t_].notm >= 0) n敵キャラ[t_].notm--;
                if (xx_0 + xx_2 >= -xx_14 && xx_0 <= n画面幅 + xx_14 && xx_1 + xx_3 >= -10 - 9000 && xx_1 <= n画面高さ + 20000)
                {
                    n敵キャラ[t_].acta = 0; n敵キャラ[t_].actb = 0;

                    xx_10 = 0;

                    switch (n敵キャラ[t_].type)
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
                            if (n敵キャラ[t_].xtype >= 1) xx_10 = xx_17;
                            //他の敵を倒す
                            if (n敵キャラ[t_].xtype >= 1)
                            {
                                for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = n敵キャラ[tt_].a - fx; xx_9 = n敵キャラ[tt_].b - fy;
                                    if (t_ != tt_)
                                    {
                                        if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + xx_0 * 2 && n敵キャラ[t_].a - fx < xx_8 + n敵キャラ[tt_].nobia - xx_0 * 2 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 + xx_5 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                        {
                                            n敵キャラ[tt_].a = -800000; v効果音再生(Res.nオーディオ6);
                                        }
                                    }
                                }
                            }
                            break;

                        //あらまき
                        case 3:
                            n敵キャラ[t_].zimentype = 0;//end();
                            if (n敵キャラ[t_].xtype == 0)
                            {
                                n敵キャラ[t_].b -= 800;
                            }
                            if (n敵キャラ[t_].xtype == 1)
                                n敵キャラ[t_].b += 1200;

                            //xx_10=100;
                            break;

                        //スーパージエン
                        case 4:
                            xx_10 = 120;
                            xx_0 = 250;
                            xx_8 = n敵キャラ[t_].a - fx;
                            xx_9 = n敵キャラ[t_].b - fy;
                            if (n敵キャラ[t_].tm >= 0) n敵キャラ[t_].tm--;
                            if (Math.Abs(ma + nプレイヤーnobia - xx_8 - xx_0 * 2) < 9000 &&
                                Math.Abs((ma < xx_8 - n敵キャラ[t_].nobia + xx_0 * 2) ? 1 : 0) < 3000 &&
                                nプレイヤーd <= -600 && n敵キャラ[t_].tm <= 0)
                            {
                                if (n敵キャラ[t_].xtype == 1 && nプレイヤーzimen == 0 && n敵キャラ[t_].xzimen == 1)
                                {
                                    n敵キャラ[t_].d = -1600; n敵キャラ[t_].tm = 40; n敵キャラ[t_].b -= 1000;
                                }
                            }// 
                            break;

                        //クマー
                        case 5:
                            xx_10 = 160;
                            break;

                        //デフラグさん
                        case 6:
                            if (n敵キャラ[t_].zimentype == 30) { n敵キャラ[t_].d = -1600; n敵キャラ[t_].b += n敵キャラ[t_].d; }

                            xx_10 = 120;
                            if (n敵キャラ[t_].tm >= 10)
                            {
                                n敵キャラ[t_].tm++;
                                if (nプレイヤーhp >= 1)
                                {
                                    if (n敵キャラ[t_].tm <= 19) { ma = xx_0; nプレイヤーb = xx_1 - 3000; nプレイヤーtype = 0; }
                                    xx_10 = 0;
                                    if (n敵キャラ[t_].tm == 20) { nプレイヤーc = 700; nプレイヤーkeytm = 24; nプレイヤーd = -1200; nプレイヤーb = xx_1 - 1000 - 3000; n敵キャラ[t_].muki = 1; if (n敵キャラ[t_].xtype == 1) { nプレイヤーc = 840; n敵キャラ[t_].xtype = 0; } }
                                    if (n敵キャラ[t_].tm == 40) { n敵キャラ[t_].muki = 0; n敵キャラ[t_].tm = 0; }
                                }
                            }

                            //ポール捨て
                            if (n敵キャラ[t_].xtype == 1)
                            {
                                for (int tt_ = 0; tt_ < n地面max; tt_++)
                                {
                                    if (n地面[tt_].type == 300)
                                    {
                                        if (n敵キャラ[t_].a - fx >= -8000 && n敵キャラ[t_].a >= n地面[tt_].a + 2000 && n敵キャラ[t_].a <= n地面[tt_].a + 3600 && n敵キャラ[t_].xzimen == 1) { n地面[tt_].a = -800000; n敵キャラ[t_].tm = 100; }
                                    }
                                }

                                if (n敵キャラ[t_].tm == 100)
                                {
                                    eyobi(n敵キャラ[t_].a + 1200 - 1200, n敵キャラ[t_].b + 3000 - 10 * 3000 - 1500, 0, 0, 0, 0, 1000, 10 * 3000 - 1200, 4, 20);
                                    if (nプレイヤーtype == 300) { nプレイヤーtype = 0; DX.StopSoundMem(Res.nオーディオ11); bgmChange(Res.nオーディオ100); DX.PlaySoundMem(Res.n現在のBGM, DX.DX_PLAYTYPE_LOOP); }
                                    for (int t1 = 0; t1 < n地面max; t1++) { if (n地面[t1].type == 104) n地面[t1].a = -80000000; }
                                }
                                if (n敵キャラ[t_].tm == 120) { eyobi(n敵キャラ[t_].a + 1200 - 1200, n敵キャラ[t_].b + 3000 - 10 * 3000 - 1500, 600, -1200, 0, 160, 1000, 10 * 3000 - 1200, 4, 240); n敵キャラ[t_].muki = 1; }
                                if (n敵キャラ[t_].tm == 140) { n敵キャラ[t_].muki = 0; n敵キャラ[t_].tm = 0; }
                            }
                            if (n敵キャラ[t_].tm >= 220) { n敵キャラ[t_].tm = 0; n敵キャラ[t_].muki = 0; }

                            //他の敵を投げる
                            for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                            {
                                xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                xx_8 = n敵キャラ[tt_].a - fx; xx_9 = n敵キャラ[tt_].b - fy;
                                if (t_ != tt_ && n敵キャラ[tt_].type >= 100)
                                {
                                    if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + xx_0 * 2 && n敵キャラ[t_].a - fx < xx_8 + n敵キャラ[tt_].nobia - xx_0 * 2 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 + xx_5 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                    {
                                        //aa[tt]=-800000;
                                        n敵キャラ[tt_].muki = 1; n敵キャラ[tt_].a = n敵キャラ[t_].a + 300; n敵キャラ[tt_].b = n敵キャラ[t_].b - 3000; n敵キャラ[tt_].brocktm = 120;//aa[tt]=0;
                                        n敵キャラ[t_].tm = 200; n敵キャラ[t_].muki = 1;
                                    }
                                }
                            }

                            break;

                        //ジエン大砲
                        case 7:
                            n敵キャラ[t_].zimentype = 0;
                            xx_10 = 0; xx_11 = 400;
                            if (n敵キャラ[t_].xtype == 0) xx_10 = xx_11;
                            if (n敵キャラ[t_].xtype == 1) xx_10 = -xx_11;
                            if (n敵キャラ[t_].xtype == 2) n敵キャラ[t_].b -= xx_11;
                            if (n敵キャラ[t_].xtype == 3) n敵キャラ[t_].b += xx_11;
                            break;

                        //スーパーブーン
                        case 8:
                            n敵キャラ[t_].zimentype = 0;
                            xx_22 = 20;
                            if (n敵キャラ[t_].tm == 0) { n敵キャラ[t_].f += xx_22; n敵キャラ[t_].d += xx_22; }
                            if (n敵キャラ[t_].tm == 1) { n敵キャラ[t_].f -= xx_22; n敵キャラ[t_].d -= xx_22; }
                            if (n敵キャラ[t_].d > 300) n敵キャラ[t_].d = 300;
                            if (n敵キャラ[t_].d < -300) n敵キャラ[t_].d = -300;
                            if (n敵キャラ[t_].f >= 1200) n敵キャラ[t_].tm = 1;
                            if (n敵キャラ[t_].f < -0) n敵キャラ[t_].tm = 0;
                            n敵キャラ[t_].b += n敵キャラ[t_].d;
                            //atype[t]=151;
                            break;
                        //ノーマルブーン
                        case 151:
                            n敵キャラ[t_].zimentype = 2;
                            break;

                        //ファイアー玉
                        case 9:
                            n敵キャラ[t_].zimentype = 5;
                            n敵キャラ[t_].b += n敵キャラ[t_].d; n敵キャラ[t_].d += 100;
                            if (n敵キャラ[t_].b >= n画面高さ + 1000) { n敵キャラ[t_].d = 900; }
                            if (n敵キャラ[t_].b >= n画面高さ + 12000)
                            {
                                n敵キャラ[t_].b = n画面高さ; n敵キャラ[t_].d = -2600;
                            }
                            break;

                        //ファイアー
                        case 10:
                            n敵キャラ[t_].zimentype = 0;
                            xx_10 = 0; xx_11 = 400;
                            if (n敵キャラ[t_].xtype == 0) xx_10 = xx_11;
                            if (n敵キャラ[t_].xtype == 1) xx_10 = -xx_11;
                            break;


                        //モララー
                        case 30:
                            n敵キャラ[t_].tm += 1;
                            if (n敵キャラ[t_].xtype == 0)
                            {
                                if (n敵キャラ[t_].tm == 50 && nプレイヤーb >= 6000) { n敵キャラ[t_].c = 300; n敵キャラ[t_].d -= 1600; n敵キャラ[t_].b -= 1000; }

                                for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = n敵キャラ[tt_].a - fx; xx_9 = n敵キャラ[tt_].b - fy;
                                    if (t_ != tt_ && n敵キャラ[tt_].type == 102)
                                    {
                                        if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + xx_0 * 2 && n敵キャラ[t_].a - fx < xx_8 + n敵キャラ[tt_].nobia - xx_0 * 2 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 + xx_5 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                        {
                                            n敵キャラ[tt_].a = -800000; n敵キャラ[t_].xtype = 1; n敵キャラ[t_].d = -1600;
                                            n敵キャラ[t_].msgtm = 30; n敵キャラ[t_].msgtype = 25;
                                        }
                                    }
                                }
                            }
                            if (n敵キャラ[t_].xtype == 1)
                            {
                                n敵キャラ[t_].zimentype = 0;
                                n敵キャラ[t_].b += n敵キャラ[t_].d; n敵キャラ[t_].d += 120;
                            }
                            break;

                        //レーザー
                        case 79:
                            n敵キャラ[t_].zimentype = 0;
                            xx_10 = 1600;
                            if (n敵キャラ[t_].xtype == 1) { xx_10 = 1200; n敵キャラ[t_].b -= 200; }
                            if (n敵キャラ[t_].xtype == 2) { xx_10 = 1200; n敵キャラ[t_].b += 200; }
                            if (n敵キャラ[t_].xtype == 3) { xx_10 = 900; n敵キャラ[t_].b -= 600; }
                            if (n敵キャラ[t_].xtype == 4) { xx_10 = 900; n敵キャラ[t_].b += 600; }
                            break;

                        //雲の敵
                        case 80:
                            n敵キャラ[t_].zimentype = 0;
                            //xx_10=100;
                            break;
                        case 81:
                            n敵キャラ[t_].zimentype = 0;
                            break;
                        case 82:
                            n敵キャラ[t_].zimentype = 0;
                            break;
                        case 83:
                            n敵キャラ[t_].zimentype = 0;
                            break;

                        case 84:
                            n敵キャラ[t_].zimentype = 2;
                            break;

                        case 85:
                            xx_23 = 400;
                            if (n敵キャラ[t_].xtype == 0) { n敵キャラ[t_].xtype = 1; n敵キャラ[t_].muki = 1; }
                            if (nプレイヤーb >= 30000 && ma >= n敵キャラ[t_].a - 3000 * 5 - fx && ma <= n敵キャラ[t_].a - fx && n敵キャラ[t_].xtype == 1) { n敵キャラ[t_].xtype = 5; n敵キャラ[t_].muki = 0; }
                            if (nプレイヤーb >= 24000 && ma <= n敵キャラ[t_].a + 3000 * 8 - fx && ma >= n敵キャラ[t_].a - fx && n敵キャラ[t_].xtype == 1) { n敵キャラ[t_].xtype = 5; n敵キャラ[t_].muki = 1; }
                            if (n敵キャラ[t_].xtype == 5) xx_10 = xx_23;
                            break;

                        case 86:
                            n敵キャラ[t_].zimentype = 4;
                            xx_23 = 1000;
                            if (ma >= n敵キャラ[t_].a - fx - nプレイヤーnobia - xx_26 && ma <= n敵キャラ[t_].a - fx + n敵キャラ[t_].nobia + xx_26) { n敵キャラ[t_].tm = 1; }
                            if (n敵キャラ[t_].tm == 1) { n敵キャラ[t_].b += 1200; }
                            break;

                        //ファイアバー
                        case 87:
                            n敵キャラ[t_].zimentype = 0;
                            if (n敵キャラ[t_].a % 10 != 1) n敵キャラ[t_].tm += 6;
                            else { n敵キャラ[t_].tm -= 6; }
                            xx_25 = 2;
                            if (n敵キャラ[t_].tm > 360 * xx_25) n敵キャラ[t_].tm -= 360 * xx_25;
                            if (n敵キャラ[t_].tm < 0) n敵キャラ[t_].tm += 360 * xx_25;

                            for (int tt_ = 0; tt_ <= n敵キャラ[t_].xtype % 100; tt_++)
                            {
                                xx_26 = 18;
                                double xd_4 = tt_ * xx_26 * Math.Cos(n敵キャラ[t_].tm * Math.PI / 180 / 2); double xd_5 = tt_ * xx_26 * Math.Sin(n敵キャラ[t_].tm * Math.PI / 180 / 2);

                                xx_4 = 1800; xx_5 = 800;
                                xx_8 = n敵キャラ[t_].a - fx + (int)xd_4 * 100 - xx_4 / 2; xx_9 = n敵キャラ[t_].b - fy + (int)xd_5 * 100 - xx_4 / 2;

                                if (ma + nプレイヤーnobia > xx_8 + xx_5 && ma < xx_8 + xx_4 - xx_5 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_5 && nプレイヤーb < xx_9 + xx_4 - xx_5)
                                {
                                    nプレイヤーhp -= 1;
                                    nメッセージtype = 51; nメッセージtm = 30;
                                }
                            }

                            break;

                        case 88:
                            n敵キャラ[t_].zimentype = 0;
                            if (n敵キャラ[t_].a % 10 != 1) n敵キャラ[t_].tm += 6;
                            else { n敵キャラ[t_].tm -= 6; }
                            xx_25 = 2;
                            if (n敵キャラ[t_].tm > 360 * xx_25) n敵キャラ[t_].tm -= 360 * xx_25;
                            if (n敵キャラ[t_].tm < 0) n敵キャラ[t_].tm += 360 * xx_25;

                            for (int tt_ = 0; tt_ <= n敵キャラ[t_].xtype % 100; tt_++)
                            {
                                xx_26 = 18;
                                double xd_4 = -tt_ * xx_26 * Math.Cos(n敵キャラ[t_].tm * Math.PI / 180 / 2);
                                double xd_5 = tt_ * xx_26 * Math.Sin(n敵キャラ[t_].tm * Math.PI / 180 / 2);

                                xx_4 = 1800;
                                xx_5 = 800;
                                xx_8 = n敵キャラ[t_].a - fx + (int)xd_4 * 100 - xx_4 / 2;
                                xx_9 = n敵キャラ[t_].b - fy + (int)xd_5 * 100 - xx_4 / 2;

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
                            n敵キャラ[t_].zimentype = 1;
                            xx_10 = 100;

                            //ほかの敵を巨大化
                            if (n敵キャラ[t_].xtype == 2)
                            {
                                for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = n敵キャラ[tt_].a - fx; xx_9 = n敵キャラ[tt_].b - fy;
                                    if (t_ != tt_)
                                    {
                                        if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + xx_0 * 2 && n敵キャラ[t_].a - fx < xx_8 + n敵キャラ[tt_].nobia - xx_0 * 2 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 + xx_5 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy < xx_9 + xx_1 * 3 + xx_12)
                                        {
                                            if (n敵キャラ[tt_].type == 0 || n敵キャラ[tt_].type == 4)
                                            {
                                                n敵キャラ[tt_].type = 90;//ot(oto[6]);
                                                n敵キャラ[tt_].nobia = 6400; n敵キャラ[tt_].nobib = 6300; n敵キャラ[tt_].xtype = 0;
                                                n敵キャラ[tt_].a -= 1050; n敵キャラ[tt_].b -= 1050;
                                                v効果音再生(Res.nオーディオ9); n敵キャラ[t_].a = -80000000;
                                            }
                                        }
                                    }
                                }
                            }

                            break;

                        //毒キノコ
                        case 102:
                            n敵キャラ[t_].zimentype = 1;
                            xx_10 = 100;
                            if (n敵キャラ[t_].xtype == 1) xx_10 = 200;
                            break;

                        //悪スター
                        case 110:
                            n敵キャラ[t_].zimentype = 1;
                            xx_10 = 200;
                            if (n敵キャラ[t_].xzimen == 1)
                            {
                                n敵キャラ[t_].b -= 1200; n敵キャラ[t_].d = -1400;
                            }
                            break;


                        case 200:
                            n敵キャラ[t_].zimentype = 1;
                            xx_10 = 100;
                            break;


                    }//sw


                    if (n敵キャラ[t_].brocktm >= 1) xx_10 = 0;



                    if (n敵キャラ[t_].muki == 0) n敵キャラ[t_].acta -= xx_10;
                    if (n敵キャラ[t_].muki == 1) n敵キャラ[t_].acta += xx_10;

                    //最大値
                    xx_0 = 850; xx_1 = 1200;

                    if (n敵キャラ[t_].d > xx_1 && n敵キャラ[t_].zimentype != 5) { n敵キャラ[t_].d = xx_1; }


                    //行動
                    n敵キャラ[t_].a += n敵キャラ[t_].acta;//ab[t]+=aactb[t];

                    if ((n敵キャラ[t_].zimentype >= 1 || n敵キャラ[t_].zimentype == -1) && n敵キャラ[t_].brocktm <= 0)
                    {
                        //if (atype[t]==4)end();

                        //移動
                        n敵キャラ[t_].a += n敵キャラ[t_].c;
                        if (n敵キャラ[t_].zimentype >= 1 && n敵キャラ[t_].zimentype <= 3) { n敵キャラ[t_].b += n敵キャラ[t_].d; n敵キャラ[t_].d += 120; }//ad[t]+=180;


                        if (n敵キャラ[t_].xzimen == 1)
                        {
                            xx_0 = 100;
                            if (n敵キャラ[t_].c >= 200) { n敵キャラ[t_].c -= xx_0; }
                            else if (n敵キャラ[t_].c <= -200) { n敵キャラ[t_].c += xx_0; }
                            else { n敵キャラ[t_].c = 0; }
                        }

                        n敵キャラ[t_].xzimen = 0;




                        //地面判定
                        if (n敵キャラ[t_].zimentype != 2)
                        {
                            tekizimen(t_);
                        }


                    }//azimentype[t]>=1

                    //ブロックから出現するさい
                    if (n敵キャラ[t_].brocktm > 0)
                    {
                        n敵キャラ[t_].brocktm--;
                        if (n敵キャラ[t_].brocktm < 100) { n敵キャラ[t_].b -= 180; }
                        if (n敵キャラ[t_].brocktm > 100) { }
                        if (n敵キャラ[t_].brocktm == 100) { n敵キャラ[t_].b -= 800; n敵キャラ[t_].d = -1200; n敵キャラ[t_].c = 700; n敵キャラ[t_].brocktm = 0; }
                    }//abrocktm[t]>0

                    //プレイヤーからの判定
                    xx_0 = 250; xx_1 = 1600; xx_2 = 1000;
                    xx_4 = 500; xx_5 = -800;

                    xx_8 = n敵キャラ[t_].a - fx; xx_9 = n敵キャラ[t_].b - fy;
                    xx_12 = 0; if (nプレイヤーd >= 100) xx_12 = nプレイヤーd;
                    xx_25 = 0;

                    if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n敵キャラ[t_].nobia - xx_0 * 2 && nプレイヤーb + nプレイヤーnobib > xx_9 - xx_5 && nプレイヤーb + nプレイヤーnobib < xx_9 + xx_1 + xx_12 && (nプレイヤーmutekitm <= 0 || nプレイヤーd >= 100) && n敵キャラ[t_].brocktm <= 0)
                    {
                        if (n敵キャラ[t_].type != 4 && n敵キャラ[t_].type != 9 && n敵キャラ[t_].type != 10 && (n敵キャラ[t_].type <= 78 || n敵キャラ[t_].type == 85) && nプレイヤーzimen != 1 && nプレイヤーtype != 200)
                        {

                            if (n敵キャラ[t_].type == 0)
                            {
                                if (n敵キャラ[t_].xtype == 0)
                                    n敵キャラ[t_].a = -900000;
                                if (n敵キャラ[t_].xtype == 1)
                                {
                                    v効果音再生(Res.nオーディオ5);
                                    nプレイヤーb = xx_9 - 900 - n敵キャラ[t_].nobib; nプレイヤーd = -2100; xx_25 = 1; nプレイヤーactaon[2] = 0;
                                }
                            }

                            if (n敵キャラ[t_].type == 1)
                            {
                                n敵キャラ[t_].type = 2; n敵キャラ[t_].nobib = 3000; n敵キャラ[t_].xtype = 0;
                            }

                            //こうら
                            else if (n敵キャラ[t_].type == 2 && nプレイヤーd >= 0)
                            {
                                if (n敵キャラ[t_].xtype == 1 || n敵キャラ[t_].xtype == 2) { n敵キャラ[t_].xtype = 0; }
                                else if (n敵キャラ[t_].xtype == 0)
                                {
                                    if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n敵キャラ[t_].nobia / 2 - xx_0 * 4)
                                    {
                                        n敵キャラ[t_].xtype = 1; n敵キャラ[t_].muki = 1;
                                    }
                                    else { n敵キャラ[t_].xtype = 1; n敵キャラ[t_].muki = 0; }
                                }
                            }
                            if (n敵キャラ[t_].type == 3)
                            {
                                xx_25 = 1;
                            }

                            if (n敵キャラ[t_].type == 6)
                            {
                                n敵キャラ[t_].tm = 10; nプレイヤーd = 0; nプレイヤーactaon[2] = 0;
                            }

                            if (n敵キャラ[t_].type == 7)
                            {
                                n敵キャラ[t_].a = -900000;
                            }

                            if (n敵キャラ[t_].type == 8)
                            {
                                n敵キャラ[t_].type = 151; n敵キャラ[t_].d = 0;
                            }

                            if (n敵キャラ[t_].type != 85)
                            {
                                if (xx_25 == 0) { v効果音再生(Res.nオーディオ5); nプレイヤーb = xx_9 - 1000 - n敵キャラ[t_].nobib; nプレイヤーd = -1000; }
                            }
                            if (n敵キャラ[t_].type == 85)
                            {
                                if (xx_25 == 0) { v効果音再生(Res.nオーディオ5); nプレイヤーb = xx_9 - 4000; nプレイヤーd = -1000; n敵キャラ[t_].xtype = 5; }
                            }

                            if (nプレイヤーactaon[2] == 1) { nプレイヤーd = -1600; nプレイヤーactaon[2] = 0; }
                        }
                    }

                    xx_15 = -500;


                    //プレイヤーに触れた時
                    xx_16 = 0;
                    if (n敵キャラ[t_].type == 4 || n敵キャラ[t_].type == 9 || n敵キャラ[t_].type == 10) xx_16 = -3000;
                    if (n敵キャラ[t_].type == 82 || n敵キャラ[t_].type == 83 || n敵キャラ[t_].type == 84) xx_16 = -3200;
                    if (n敵キャラ[t_].type == 85) xx_16 = -n敵キャラ[t_].nobib + 6000;
                    if (ma + nプレイヤーnobia > xx_8 + xx_4 && ma < xx_8 + n敵キャラ[t_].nobia - xx_4 && nプレイヤーb < xx_9 + n敵キャラ[t_].nobib + xx_15 && nプレイヤーb + nプレイヤーnobib > xx_9 + n敵キャラ[t_].nobib - xx_0 + xx_16 && n敵キャラ[t_].notm <= 0 && n敵キャラ[t_].brocktm <= 0)
                    {
                        if (nプレイヤーmutekitm <= 0 && (n敵キャラ[t_].type <= 99 || n敵キャラ[t_].type >= 200))
                        {
                            if (nプレイヤーtype != 200)
                            {

                                //ダメージ
                                if ((n敵キャラ[t_].type != 2 || n敵キャラ[t_].xtype != 0) && nプレイヤーhp >= 1)
                                {
                                    if (n敵キャラ[t_].type != 6)
                                    {
                                        nプレイヤーhp -= 1;
                                    }
                                }

                                if (n敵キャラ[t_].type == 6)
                                {
                                    n敵キャラ[t_].tm = 10;
                                }


                                //せりふ
                                if (nプレイヤーhp == 0)
                                {

                                    if (n敵キャラ[t_].type == 0 || n敵キャラ[t_].type == 7)
                                    {
                                        n敵キャラ[t_].msgtm = 60; n敵キャラ[t_].msgtype = DX.GetRand(7) + 1 + 1000 + (nステージb - 1) * 10;
                                    }

                                    if (n敵キャラ[t_].type == 1)
                                    {
                                        n敵キャラ[t_].msgtm = 60; n敵キャラ[t_].msgtype = DX.GetRand(2) + 15;
                                    }

                                    if (n敵キャラ[t_].type == 2 && n敵キャラ[t_].xtype >= 1 && nプレイヤーmutekitm <= 0)
                                    {
                                        n敵キャラ[t_].msgtm = 60; n敵キャラ[t_].msgtype = 18;
                                    }

                                    if (n敵キャラ[t_].type == 3)
                                    {
                                        n敵キャラ[t_].msgtm = 60; n敵キャラ[t_].msgtype = 20;
                                    }

                                    if (n敵キャラ[t_].type == 4)
                                    {
                                        n敵キャラ[t_].msgtm = 60; n敵キャラ[t_].msgtype = DX.GetRand(7) + 1 + 1000 + (nステージb - 1) * 10;
                                    }

                                    if (n敵キャラ[t_].type == 5)
                                    {
                                        n敵キャラ[t_].msgtm = 60; n敵キャラ[t_].msgtype = 21;
                                    }

                                    if (n敵キャラ[t_].type == 9 || n敵キャラ[t_].type == 10)
                                    {
                                        nメッセージtm = 30; nメッセージtype = 54;
                                    }



                                    if (n敵キャラ[t_].type == 31)
                                    {
                                        n敵キャラ[t_].msgtm = 30; n敵キャラ[t_].msgtype = 24;
                                    }


                                    if (n敵キャラ[t_].type == 80 || n敵キャラ[t_].type == 81)
                                    {
                                        n敵キャラ[t_].msgtm = 60; n敵キャラ[t_].msgtype = 30;
                                    }

                                    if (n敵キャラ[t_].type == 82)
                                    {
                                        n敵キャラ[t_].msgtm = 20; n敵キャラ[t_].msgtype = DX.GetRand(1) + 31;
                                        xx_24 = 900; n敵キャラ[t_].type = 83; n敵キャラ[t_].a -= xx_24 + 100; n敵キャラ[t_].b -= xx_24 - 100 * 0;
                                    }//82

                                    if (n敵キャラ[t_].type == 84)
                                    {
                                        nメッセージtm = 30; nメッセージtype = 50;
                                    }

                                    if (n敵キャラ[t_].type == 85)
                                    {
                                        n敵キャラ[t_].msgtm = 60; n敵キャラ[t_].msgtype = DX.GetRand(1) + 85;
                                    }


                                    //雲
                                    if (n敵キャラ[t_].type == 80)
                                    {
                                        n敵キャラ[t_].type = 81;
                                    }
                                }//mhp==0


                                //こうら
                                if (n敵キャラ[t_].type == 2)
                                {
                                    if (n敵キャラ[t_].xtype == 0)
                                    {
                                        if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n敵キャラ[t_].nobia / 2 - xx_0 * 4)
                                        {
                                            n敵キャラ[t_].xtype = 1; n敵キャラ[t_].muki = 1; n敵キャラ[t_].a = ma + nプレイヤーnobia + fx + nプレイヤーc; nプレイヤーmutekitm = 5;
                                        }
                                        else {
                                            n敵キャラ[t_].xtype = 1; n敵キャラ[t_].muki = 0; n敵キャラ[t_].a = ma - n敵キャラ[t_].nobia + fx - nプレイヤーc; nプレイヤーmutekitm = 5;
                                        }
                                    }
                                    else { nプレイヤーhp -= 1; }//mmutekitm=40;}
                                }


                            }
                        }
                        //アイテム
                        if (n敵キャラ[t_].type >= 100 && n敵キャラ[t_].type <= 199)
                        {

                            if (n敵キャラ[t_].type == 100 && n敵キャラ[t_].xtype == 0) { nメッセージtm = 30; nメッセージtype = 1; v効果音再生(Res.nオーディオ9); }
                            if (n敵キャラ[t_].type == 100 && n敵キャラ[t_].xtype == 1) { nメッセージtm = 30; nメッセージtype = 2; v効果音再生(Res.nオーディオ9); }
                            if (n敵キャラ[t_].type == 100 && n敵キャラ[t_].xtype == 2) { nプレイヤーnobia = 5200; nプレイヤーnobib = 7300; v効果音再生(Res.nオーディオ9); ma -= 1100; nプレイヤーb -= 4000; nプレイヤーtype = 1; nプレイヤーhp = 50000000; }

                            if (n敵キャラ[t_].type == 101) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 11; }
                            if (n敵キャラ[t_].type == 102) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 10; }


                            //?ボール
                            if (n敵キャラ[t_].type == 105)
                            {
                                if (n敵キャラ[t_].xtype == 0)
                                {
                                    v効果音再生(Res.nオーディオ4); n地面[26].gtype = 6;
                                }
                                if (n敵キャラ[t_].xtype == 1)
                                {
                                    nブロック[7].xtype = 80;
                                    v効果音再生(Res.nオーディオ4);

                                    ayobi(n敵キャラ[t_].a - 8 * 3000 - 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラ[t_].a - 10 * 3000 + 1000, -1 * 3000, 0, 0, 0, 110, 0);

                                    ayobi(n敵キャラ[t_].a + 4 * 3000 + 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラ[t_].a + 5 * 3000 - 1000, -3 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラ[t_].a + 6 * 3000 + 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラ[t_].a + 7 * 3000 - 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                    ayobi(n敵キャラ[t_].a + 8 * 3000 + 1000, -2 * 3000 - 1000, 0, 0, 0, 110, 0);
                                    nブロック[0].b += 3000 * 3;
                                }
                            }//105

                            if (n敵キャラ[t_].type == 110) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 3; }

                            n敵キャラ[t_].a = -90000000;
                        }

                    }//(ma

                }
                else { n敵キャラ[t_].a = -9000000; }

            }//t
        }

        static void DrawEnemy()
        {
            DXDraw.nミラー = 0;
            //敵キャラ
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {

                xx_0 = n敵キャラ[t_].a - fx; xx_1 = n敵キャラ[t_].b - fy;
                xx_2 = n敵キャラ[t_].nobia / 100; xx_3 = n敵キャラ[t_].nobib / 100; xx_14 = 3000; xx_16 = 0;
                if (xx_0 + xx_2 * 100 >= -10 - xx_14 && xx_1 <= n画面幅 + xx_14 && xx_1 + xx_3 * 100 >= -10 && xx_3 <= n画面高さ)
                {
                    if (n敵キャラ[t_].muki == 1) { DXDraw.nミラー = 1; }
                    if (n敵キャラ[t_].type == 3 && n敵キャラ[t_].xtype == 1) { DX.DrawRotaGraph(xx_0 / 100 + 13, xx_1 / 100 + 15, 1.0f, Math.PI / 1, Res.n切り取り画像[n敵キャラ[t_].type, 3], DX.TRUE); xx_16 = 1; }
                    if (n敵キャラ[t_].type == 9 && n敵キャラ[t_].d >= 1) { DX.DrawRotaGraph(xx_0 / 100 + 13, xx_1 / 100 + 15, 1.0f, Math.PI / 1, Res.n切り取り画像[n敵キャラ[t_].type, 3], DX.TRUE); xx_16 = 1; }
                    if (n敵キャラ[t_].type >= 100 && n敵キャラ[t_].muki == 1) DXDraw.nミラー = 0;

                    //メイン
                    if (n敵キャラ[t_].type < 200 && xx_16 == 0 && n敵キャラ[t_].type != 6 && n敵キャラ[t_].type != 79 && n敵キャラ[t_].type != 86 && n敵キャラ[t_].type != 30)
                    {
                        if (!((n敵キャラ[t_].type == 80 || n敵キャラ[t_].type == 81) && n敵キャラ[t_].xtype == 1))
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[n敵キャラ[t_].type, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }


                    //デフラグさん
                    if (n敵キャラ[t_].type == 6)
                    {
                        if (n敵キャラ[t_].tm >= 10 && n敵キャラ[t_].tm <= 19 || n敵キャラ[t_].tm >= 100 && n敵キャラ[t_].tm <= 119 || n敵キャラ[t_].tm >= 200)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[150, 3], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像[6, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }

                    //モララー
                    if (n敵キャラ[t_].type == 30)
                    {
                        if (n敵キャラ[t_].xtype == 0) DXDraw.DrawGraph(Res.n切り取り画像[30, 3], xx_0 / 100, xx_1 / 100);
                        if (n敵キャラ[t_].xtype == 1) DXDraw.DrawGraph(Res.n切り取り画像[155, 3], xx_0 / 100, xx_1 / 100);
                    }



                    //ステルス雲
                    if ((n敵キャラ[t_].type == 81) && n敵キャラ[t_].xtype == 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像[130, 3], xx_0 / 100, xx_1 / 100);
                    }

                    if (n敵キャラ[t_].type == 79)
                    {
                        DXDraw.SetColor(250, 250, 0);
                        DXDraw.DrawBox塗り潰し(xx_0 / 100, xx_1 / 100, xx_2, xx_3);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し(xx_0 / 100, xx_1 / 100, xx_2, xx_3);
                    }

                    if (n敵キャラ[t_].type == 82)
                    {

                        if (n敵キャラ[t_].xtype == 0)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 5 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (n敵キャラ[t_].xtype == 1)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 4 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (n敵キャラ[t_].xtype == 2)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[1, 5], xx_0 / 100, xx_1 / 100);
                        }

                    }
                    if (n敵キャラ[t_].type == 83)
                    {

                        if (n敵キャラ[t_].xtype == 0)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 5 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100 + 10, xx_1 / 100 + 9);
                        }

                        if (n敵キャラ[t_].xtype == 1)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 4 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100 + 10, xx_1 / 100 + 9);
                        }

                    }

                    //偽ポール
                    if (n敵キャラ[t_].type == 85)
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
                    if (n敵キャラ[t_].type == 86)
                    {
                        if (ma >= n敵キャラ[t_].a - fx - nプレイヤーnobia - 4000 && ma <= n敵キャラ[t_].a - fx + n敵キャラ[t_].nobia + 4000)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[152, 3], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像[86, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }

                    if (n敵キャラ[t_].type == 200)
                        DXDraw.DrawGraph(Res.n切り取り画像[0, 3], xx_0 / 100, xx_1 / 100);

                    DXDraw.nミラー = 0;
                }
            }
        }

        static void DrawEnemyファイアバー()
        {
            //ファイアバー
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {

                xx_0 = n敵キャラ[t_].a - fx; xx_1 = n敵キャラ[t_].b - fy;
                xx_14 = 12000; xx_16 = 0;
                if (n敵キャラ[t_].type == 87 || n敵キャラ[t_].type == 88)
                {
                    if (xx_0 + xx_2 * 100 >= -10 - xx_14 && xx_1 <= n画面幅 + xx_14 && xx_1 + xx_3 * 100 >= -10 && xx_3 <= n画面高さ)
                    {

                        for (int tt_ = 0; tt_ <= n敵キャラ[t_].xtype % 100; tt_++)
                        {
                            xx_26 = 18;
                            double xd_4 = tt_ * xx_26 * Math.Cos(n敵キャラ[t_].tm * Math.PI / 180 / 2);
                            double xd_5 = tt_ * xx_26 * Math.Sin(n敵キャラ[t_].tm * Math.PI / 180 / 2);
                            xx_24 = (int)xd_4;
                            xx_25 = (int)xd_5;
                            DXDraw.SetColor(230, 120, 0);
                            xx_23 = 8;
                            if (n敵キャラ[t_].type == 87)
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

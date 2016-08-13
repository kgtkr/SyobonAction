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
        class C敵キャラ
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
        static List<C敵キャラ> n敵キャラ = new List<C敵キャラ>();


        class C敵出現
        {
            public int a,
            b,
            tm;
            public int type,
                xtype,
                z = 1;
        }

        //敵出現
        static List<C敵出現> n敵出現 = new List<C敵出現>();

        static void UpdateEnemy()
        {
            //敵キャラの配置
            foreach(C敵出現 ct in n敵出現.ToArray())
            {
                if (ct.tm >= 0)
                {
                    ct.tm = ct.tm - 1;
                }

                for (int tt_ = 0; tt_ <= 1; tt_++)
                {
                    C敵キャラ cec = new C敵キャラ();
                    xx_0 = 0; xx_1 = 0;
                    if (ct.z == 0 && ct.tm < 0 &&
                        ct.a - fx >= n画面幅 + 2000 &&
                        ct.a - fx < n画面幅 + 2000 + nプレイヤー.c &&
                        tt_ == 0)
                    {

                        xx_0 = 1;
                        cec.muki = 0;
                    }

                    if (ct.z == 0 &&
                        ct.tm < 0 &&
                        ct.a - fx >= -400 - Res.n敵サイズ[ct.type].w + nプレイヤー.c &&
                        ct.a - fx < -400 - Res.n敵サイズ[ct.type].w
                        && tt_ == 1)
                    {
                        xx_0 = 1; xx_1 = 1;
                        cec.muki = 1;
                    }

                    if (ct.z == 1 &&
                        ct.a - fx >= 0 - Res.n敵サイズ[ct.type].w &&
                        ct.a - fx <= n画面幅 + 4000 &&
                        ct.b - fy >= -9000 &&
                        ct.b - fy <= n画面高さ + 4000 &&
                        ct.tm < 0)
                    {
                        xx_0 = 1;
                        ct.z = 0;
                    }
                    if (xx_0 == 1)
                    {//400
                        ct.tm = 401;
                        xx_0 = 0;
                        if (ct.type >= 10)
                        {
                            ct.tm = 9999999;
                        }

                        //10
                        v敵キャラアイテム作成(cec,ct.a, ct.b, 0, 0, 0, ct.type, ct.xtype);
                        n敵キャラ.Add(cec);
                    }

                }//tt
            }

            //敵キャラ
            foreach (C敵キャラ ec in n敵キャラ.ToArray())
            {
                xx_0 = ec.a - fx; xx_1 = ec.b - fy;
                xx_2 = ec.nobia; xx_3 = ec.nobib; xx_14 = 12000 * 1;
                if (ec.notm >= 0) ec.notm--;
                if (xx_0 + xx_2 >= -xx_14 && xx_0 <= n画面幅 + xx_14 && xx_1 + xx_3 >= -10 - 9000 && xx_1 <= n画面高さ + 20000)
                {
                    ec.acta = 0; ec.actb = 0;

                    xx_10 = 0;

                    switch (ec.type)
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
                            if (ec.xtype >= 1) xx_10 = xx_17;
                            //他の敵を倒す
                            if (ec.xtype >= 1)
                            {
                                foreach (C敵キャラ ec2 in n敵キャラ.ToArray())
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = ec2.a - fx; xx_9 = ec.b - fy;
                                    if (ec != ec2)
                                    {
                                        if (ec.a + ec.nobia - fx > xx_8 + xx_0 * 2 && ec.a - fx < xx_8 + ec.nobia - xx_0 * 2 && ec.b + ec.nobib - fy > xx_9 + xx_5 && ec.b + ec.nobib - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                        {
                                            n敵キャラ.Remove(ec2);
                                            v効果音再生(Res.nオーディオ6);
                                        }
                                    }
                                }
                            }
                            break;

                        //あらまき
                        case 3:
                            ec.zimentype = 0;//end();
                            if (ec.xtype == 0)
                            {
                                ec.b -= 800;
                            }
                            if (ec.xtype == 1)
                                ec.b += 1200;

                            //xx_10=100;
                            break;

                        //スーパージエン
                        case 4:
                            xx_10 = 120;
                            xx_0 = 250;
                            xx_8 = ec.a - fx;
                            xx_9 = ec.b - fy;
                            if (ec.tm >= 0) ec.tm--;
                            if (Math.Abs(ma + nプレイヤー.nobia - xx_8 - xx_0 * 2) < 9000 &&
                                Math.Abs((ma < xx_8 - ec.nobia + xx_0 * 2) ? 1 : 0) < 3000 &&
                                nプレイヤー.d <= -600 && ec.tm <= 0)
                            {
                                if (ec.xtype == 1 && nプレイヤー.zimen == 0 && ec.xzimen == 1)
                                {
                                    ec.d = -1600; ec.tm = 40; ec.b -= 1000;
                                }
                            }// 
                            break;

                        //クマー
                        case 5:
                            xx_10 = 160;
                            break;

                        //デフラグさん
                        case 6:
                            if (ec.zimentype == 30) { ec.d = -1600; ec.b += ec.d; }

                            xx_10 = 120;
                            if (ec.tm >= 10)
                            {
                                ec.tm++;
                                if (nプレイヤー.hp >= 1)
                                {
                                    if (ec.tm <= 19) { ma = xx_0; nプレイヤー.b = xx_1 - 3000; nプレイヤー.type = 0; }
                                    xx_10 = 0;
                                    if (ec.tm == 20) { nプレイヤー.c = 700; nプレイヤー.keytm = 24; nプレイヤー.d = -1200; nプレイヤー.b = xx_1 - 1000 - 3000; ec.muki = 1; if (ec.xtype == 1) { nプレイヤー.c = 840; ec.xtype = 0; } }
                                    if (ec.tm == 40) { ec.muki = 0; ec.tm = 0; }
                                }
                            }

                            //ポール捨て
                            if (ec.xtype == 1)
                            {
                                for (int tt_ = 0; tt_ < n地面max; tt_++)
                                {
                                    if (n地面[tt_].type == 300)
                                    {
                                        if (ec.a - fx >= -8000 && ec.a >= n地面[tt_].a + 2000 && ec.a <= n地面[tt_].a + 3600 && ec.xzimen == 1) { n地面[tt_].a = -800000; ec.tm = 100; }
                                    }
                                }

                                if (ec.tm == 100)
                                {
                                    var ce = new C絵();
                                    eyobi(ce,ec.a + 1200 - 1200, ec.b + 3000 - 10 * 3000 - 1500, 0, 0, 0, 0, 1000, 10 * 3000 - 1200, 4, 20);
                                    n絵.Add(ce);

                                    if (nプレイヤー.type == 300) { nプレイヤー.type = 0; DX.StopSoundMem(Res.nオーディオ11); bgmChange(Res.nオーディオ100); DX.PlaySoundMem(Res.n現在のBGM, DX.DX_PLAYTYPE_LOOP); }
                                    for (int t1 = 0; t1 < n地面max; t1++) { if (n地面[t1].type == 104) n地面[t1].a = -80000000; }
                                }
                                if (ec.tm == 120) {
                                    var ce = new C絵();
                                    eyobi(ce,ec.a + 1200 - 1200, ec.b + 3000 - 10 * 3000 - 1500, 600, -1200, 0, 160, 1000, 10 * 3000 - 1200, 4, 240);
                                    n絵.Add(ce);

                                    ec.muki = 1;
                                }
                                if (ec.tm == 140) { ec.muki = 0; ec.tm = 0; }
                            }
                            if (ec.tm >= 220) { ec.tm = 0; ec.muki = 0; }

                            //他の敵を投げる
                            foreach (C敵キャラ ec2 in n敵キャラ.ToArray())
                            {
                                xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                xx_8 = ec2.a - fx; xx_9 = ec2.b - fy;
                                if (ec != ec2 && ec2.type >= 100)
                                {
                                    if (ec.a + ec.nobia - fx > xx_8 + xx_0 * 2 && ec.a - fx < xx_8 + ec2.nobia - xx_0 * 2 && ec.b + ec.nobib - fy > xx_9 + xx_5 && ec.b + ec.nobib - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                    {
                                        ec2.muki = 1;
                                        ec2.a = ec.a + 300;
                                        ec2.b = ec.b - 3000;
                                        ec2.brocktm = 120;
                                        ec.tm = 200; ec.muki = 1;
                                    }
                                }
                            }

                            break;

                        //ジエン大砲
                        case 7:
                            ec.zimentype = 0;
                            xx_10 = 0; xx_11 = 400;
                            if (ec.xtype == 0) xx_10 = xx_11;
                            if (ec.xtype == 1) xx_10 = -xx_11;
                            if (ec.xtype == 2) ec.b -= xx_11;
                            if (ec.xtype == 3) ec.b += xx_11;
                            break;

                        //スーパーブーン
                        case 8:
                            ec.zimentype = 0;
                            xx_22 = 20;
                            if (ec.tm == 0) { ec.f += xx_22; ec.d += xx_22; }
                            if (ec.tm == 1) { ec.f -= xx_22; ec.d -= xx_22; }
                            if (ec.d > 300) ec.d = 300;
                            if (ec.d < -300) ec.d = -300;
                            if (ec.f >= 1200) ec.tm = 1;
                            if (ec.f < -0) ec.tm = 0;
                            ec.b += ec.d;
                            //atype[t]=151;
                            break;
                        //ノーマルブーン
                        case 151:
                            ec.zimentype = 2;
                            break;

                        //ファイアー玉
                        case 9:
                            ec.zimentype = 5;
                            ec.b += ec.d; ec.d += 100;
                            if (ec.b >= n画面高さ + 1000) { ec.d = 900; }
                            if (ec.b >= n画面高さ + 12000)
                            {
                                ec.b = n画面高さ; ec.d = -2600;
                            }
                            break;

                        //ファイアー
                        case 10:
                            ec.zimentype = 0;
                            xx_10 = 0; xx_11 = 400;
                            if (ec.xtype == 0) xx_10 = xx_11;
                            if (ec.xtype == 1) xx_10 = -xx_11;
                            break;


                        //モララー
                        case 30:
                            ec.tm += 1;
                            if (ec.xtype == 0)
                            {
                                if (ec.tm == 50 && nプレイヤー.b >= 6000) { ec.c = 300; ec.d -= 1600; ec.b -= 1000; }

                                foreach (C敵キャラ ec2 in n敵キャラ.ToArray())
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = ec2.a - fx; xx_9 = ec2.b - fy;
                                    if (ec != ec2 && ec2.type == 102)
                                    {
                                        if (ec.a + ec.nobia - fx > xx_8 + xx_0 * 2 && ec.a - fx < xx_8 + ec2.nobia - xx_0 * 2 && ec.b + ec.nobib - fy > xx_9 + xx_5 && ec.b + ec.nobib - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                        {
                                            ec2.a = -800000; ec.xtype = 1; ec.d = -1600;
                                            ec.msgtm = 30; ec.msgtype = 25;
                                        }
                                    }
                                }
                            }
                            if (ec.xtype == 1)
                            {
                                ec.zimentype = 0;
                                ec.b += ec.d; ec.d += 120;
                            }
                            break;

                        //レーザー
                        case 79:
                            ec.zimentype = 0;
                            xx_10 = 1600;
                            if (ec.xtype == 1) { xx_10 = 1200; ec.b -= 200; }
                            if (ec.xtype == 2) { xx_10 = 1200; ec.b += 200; }
                            if (ec.xtype == 3) { xx_10 = 900; ec.b -= 600; }
                            if (ec.xtype == 4) { xx_10 = 900; ec.b += 600; }
                            break;

                        //雲の敵
                        case 80:
                            ec.zimentype = 0;
                            //xx_10=100;
                            break;
                        case 81:
                            ec.zimentype = 0;
                            break;
                        case 82:
                            ec.zimentype = 0;
                            break;
                        case 83:
                            ec.zimentype = 0;
                            break;

                        case 84:
                            ec.zimentype = 2;
                            break;

                        case 85:
                            xx_23 = 400;
                            if (ec.xtype == 0) { ec.xtype = 1; ec.muki = 1; }
                            if (nプレイヤー.b >= 30000 && ma >= ec.a - 3000 * 5 - fx && ma <= ec.a - fx && ec.xtype == 1) { ec.xtype = 5; ec.muki = 0; }
                            if (nプレイヤー.b >= 24000 && ma <= ec.a + 3000 * 8 - fx && ma >= ec.a - fx && ec.xtype == 1) { ec.xtype = 5; ec.muki = 1; }
                            if (ec.xtype == 5) xx_10 = xx_23;
                            break;

                        case 86:
                            ec.zimentype = 4;
                            xx_23 = 1000;
                            if (ma >= ec.a - fx - nプレイヤー.nobia - xx_26 && ma <= ec.a - fx + ec.nobia + xx_26) { ec.tm = 1; }
                            if (ec.tm == 1) { ec.b += 1200; }
                            break;

                        //ファイアバー
                        case 87:
                            ec.zimentype = 0;
                            if (ec.a % 10 != 1) ec.tm += 6;
                            else { ec.tm -= 6; }
                            xx_25 = 2;
                            if (ec.tm > 360 * xx_25) ec.tm -= 360 * xx_25;
                            if (ec.tm < 0) ec.tm += 360 * xx_25;

                            for (int tt_ = 0; tt_ <= ec.xtype % 100; tt_++)
                            {
                                xx_26 = 18;
                                double xd_4 = tt_ * xx_26 * Math.Cos(ec.tm * Math.PI / 180 / 2); double xd_5 = tt_ * xx_26 * Math.Sin(ec.tm * Math.PI / 180 / 2);

                                xx_4 = 1800; xx_5 = 800;
                                xx_8 = ec.a - fx + (int)xd_4 * 100 - xx_4 / 2; xx_9 = ec.b - fy + (int)xd_5 * 100 - xx_4 / 2;

                                if (ma + nプレイヤー.nobia > xx_8 + xx_5 && ma < xx_8 + xx_4 - xx_5 && nプレイヤー.b + nプレイヤー.nobib > xx_9 + xx_5 && nプレイヤー.b < xx_9 + xx_4 - xx_5)
                                {
                                    nプレイヤー.hp -= 1;
                                    nメッセージtype = 51; nメッセージtm = 30;
                                }
                            }

                            break;

                        case 88:
                            ec.zimentype = 0;
                            if (ec.a % 10 != 1) ec.tm += 6;
                            else { ec.tm -= 6; }
                            xx_25 = 2;
                            if (ec.tm > 360 * xx_25) ec.tm -= 360 * xx_25;
                            if (ec.tm < 0) ec.tm += 360 * xx_25;

                            for (int tt_ = 0; tt_ <= ec.xtype % 100; tt_++)
                            {
                                xx_26 = 18;
                                double xd_4 = -tt_ * xx_26 * Math.Cos(ec.tm * Math.PI / 180 / 2);
                                double xd_5 = tt_ * xx_26 * Math.Sin(ec.tm * Math.PI / 180 / 2);

                                xx_4 = 1800;
                                xx_5 = 800;
                                xx_8 = ec.a - fx + (int)xd_4 * 100 - xx_4 / 2;
                                xx_9 = ec.b - fy + (int)xd_5 * 100 - xx_4 / 2;

                                if (ma + nプレイヤー.nobia > xx_8 + xx_5 && ma < xx_8 + xx_4 - xx_5 && nプレイヤー.b + nプレイヤー.nobib > xx_9 + xx_5 && nプレイヤー.b < xx_9 + xx_4 - xx_5)
                                {
                                    nプレイヤー.hp -= 1;
                                    nメッセージtype = 51; nメッセージtm = 30;
                                }
                            }

                            break;


                        case 90:
                            xx_10 = 160;
                            break;


                        //おいしいキノコ
                        case 100:
                            ec.zimentype = 1;
                            xx_10 = 100;

                            //ほかの敵を巨大化
                            if (ec.xtype == 2)
                            {
                                foreach (C敵キャラ ec2 in n敵キャラ.ToArray())
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = ec2.a - fx; xx_9 = ec2.b - fy;
                                    if (ec != ec2)
                                    {
                                        if (ec.a + ec.nobia - fx > xx_8 + xx_0 * 2 && ec.a - fx < xx_8 + ec2.nobia - xx_0 * 2 && ec.b + ec.nobib - fy > xx_9 + xx_5 && ec.b + ec.nobib - fy < xx_9 + xx_1 * 3 + xx_12)
                                        {
                                            if (ec2.type == 0 || ec2.type == 4)
                                            {
                                                ec2.type = 90;//ot(oto[6]);
                                                ec2.nobia = 6400;
                                                ec2.nobib = 6300;
                                                ec2.xtype = 0;
                                                ec2.a -= 1050;
                                                ec2.b -= 1050;
                                                v効果音再生(Res.nオーディオ9);
                                                n敵キャラ.Remove(ec);
                                            }
                                        }
                                    }
                                }
                            }

                            break;

                        //毒キノコ
                        case 102:
                            ec.zimentype = 1;
                            xx_10 = 100;
                            if (ec.xtype == 1) xx_10 = 200;
                            break;

                        //悪スター
                        case 110:
                            ec.zimentype = 1;
                            xx_10 = 200;
                            if (ec.xzimen == 1)
                            {
                                ec.b -= 1200; ec.d = -1400;
                            }
                            break;


                        case 200:
                            ec.zimentype = 1;
                            xx_10 = 100;
                            break;


                    }//sw


                    if (ec.brocktm >= 1) xx_10 = 0;



                    if (ec.muki == 0) ec.acta -= xx_10;
                    if (ec.muki == 1) ec.acta += xx_10;

                    //最大値
                    xx_0 = 850; xx_1 = 1200;

                    if (ec.d > xx_1 && ec.zimentype != 5) { ec.d = xx_1; }


                    //行動
                    ec.a += ec.acta;//ab[t]+=aactb[t];

                    if ((ec.zimentype >= 1 || ec.zimentype == -1) && ec.brocktm <= 0)
                    {
                        //if (atype[t]==4)end();

                        //移動
                        ec.a += ec.c;
                        if (ec.zimentype >= 1 && ec.zimentype <= 3) { ec.b += ec.d; ec.d += 120; }//ad[t]+=180;


                        if (ec.xzimen == 1)
                        {
                            xx_0 = 100;
                            if (ec.c >= 200) { ec.c -= xx_0; }
                            else if (ec.c <= -200) { ec.c += xx_0; }
                            else { ec.c = 0; }
                        }

                        ec.xzimen = 0;




                        //地面判定
                        if (ec.zimentype != 2)
                        {
                            tekizimen(ec);
                        }


                    }//azimentype[t]>=1

                    //ブロックから出現するさい
                    if (ec.brocktm > 0)
                    {
                        ec.brocktm--;
                        if (ec.brocktm < 100) { ec.b -= 180; }
                        if (ec.brocktm > 100) { }
                        if (ec.brocktm == 100) { ec.b -= 800; ec.d = -1200; ec.c = 700; ec.brocktm = 0; }
                    }//abrocktm[t]>0

                    //プレイヤーからの判定
                    xx_0 = 250; xx_1 = 1600; xx_2 = 1000;
                    xx_4 = 500; xx_5 = -800;

                    xx_8 = ec.a - fx; xx_9 = ec.b - fy;
                    xx_12 = 0; if (nプレイヤー.d >= 100) xx_12 = nプレイヤー.d;
                    xx_25 = 0;

                    if (ma + nプレイヤー.nobia > xx_8 + xx_0 * 2 && ma < xx_8 + ec.nobia - xx_0 * 2 && nプレイヤー.b + nプレイヤー.nobib > xx_9 - xx_5 && nプレイヤー.b + nプレイヤー.nobib < xx_9 + xx_1 + xx_12 && (nプレイヤー.mutekitm <= 0 || nプレイヤー.d >= 100) && ec.brocktm <= 0)
                    {
                        if (ec.type != 4 && ec.type != 9 && ec.type != 10 && (ec.type <= 78 || ec.type == 85) && nプレイヤー.zimen != 1 && nプレイヤー.type != 200)
                        {

                            if (ec.type == 0)
                            {
                                if (ec.xtype == 0)
                                    ec.a = -900000;
                                if (ec.xtype == 1)
                                {
                                    v効果音再生(Res.nオーディオ5);
                                    nプレイヤー.b = xx_9 - 900 - ec.nobib; nプレイヤー.d = -2100; xx_25 = 1; nプレイヤー.actaon[2] = 0;
                                }
                            }

                            if (ec.type == 1)
                            {
                                ec.type = 2; ec.nobib = 3000; ec.xtype = 0;
                            }

                            //こうら
                            else if (ec.type == 2 && nプレイヤー.d >= 0)
                            {
                                if (ec.xtype == 1 || ec.xtype == 2) { ec.xtype = 0; }
                                else if (ec.xtype == 0)
                                {
                                    if (ma + nプレイヤー.nobia > xx_8 + xx_0 * 2 && ma < xx_8 + ec.nobia / 2 - xx_0 * 4)
                                    {
                                        ec.xtype = 1; ec.muki = 1;
                                    }
                                    else { ec.xtype = 1; ec.muki = 0; }
                                }
                            }
                            if (ec.type == 3)
                            {
                                xx_25 = 1;
                            }

                            if (ec.type == 6)
                            {
                                ec.tm = 10; nプレイヤー.d = 0; nプレイヤー.actaon[2] = 0;
                            }

                            if (ec.type == 7)
                            {
                                ec.a = -900000;
                            }

                            if (ec.type == 8)
                            {
                                ec.type = 151; ec.d = 0;
                            }

                            if (ec.type != 85)
                            {
                                if (xx_25 == 0) { v効果音再生(Res.nオーディオ5); nプレイヤー.b = xx_9 - 1000 - ec.nobib; nプレイヤー.d = -1000; }
                            }
                            if (ec.type == 85)
                            {
                                if (xx_25 == 0) { v効果音再生(Res.nオーディオ5); nプレイヤー.b = xx_9 - 4000; nプレイヤー.d = -1000; ec.xtype = 5; }
                            }

                            if (nプレイヤー.actaon[2] == 1) { nプレイヤー.d = -1600; nプレイヤー.actaon[2] = 0; }
                        }
                    }

                    xx_15 = -500;


                    //プレイヤーに触れた時
                    xx_16 = 0;
                    if (ec.type == 4 || ec.type == 9 || ec.type == 10) xx_16 = -3000;
                    if (ec.type == 82 || ec.type == 83 || ec.type == 84) xx_16 = -3200;
                    if (ec.type == 85) xx_16 = -ec.nobib + 6000;
                    if (ma + nプレイヤー.nobia > xx_8 + xx_4 && ma < xx_8 + ec.nobia - xx_4 && nプレイヤー.b < xx_9 + ec.nobib + xx_15 && nプレイヤー.b + nプレイヤー.nobib > xx_9 + ec.nobib - xx_0 + xx_16 && ec.notm <= 0 && ec.brocktm <= 0)
                    {
                        if (nプレイヤー.mutekitm <= 0 && (ec.type <= 99 || ec.type >= 200))
                        {
                            if (nプレイヤー.type != 200)
                            {

                                //ダメージ
                                if ((ec.type != 2 || ec.xtype != 0) && nプレイヤー.hp >= 1)
                                {
                                    if (ec.type != 6)
                                    {
                                        nプレイヤー.hp -= 1;
                                    }
                                }

                                if (ec.type == 6)
                                {
                                    ec.tm = 10;
                                }


                                //せりふ
                                if (nプレイヤー.hp == 0)
                                {

                                    if (ec.type == 0 || ec.type == 7)
                                    {
                                        ec.msgtm = 60; ec.msgtype = DX.GetRand(7) + 1 + 1000 + (nステージb - 1) * 10;
                                    }

                                    if (ec.type == 1)
                                    {
                                        ec.msgtm = 60; ec.msgtype = DX.GetRand(2) + 15;
                                    }

                                    if (ec.type == 2 && ec.xtype >= 1 && nプレイヤー.mutekitm <= 0)
                                    {
                                        ec.msgtm = 60; ec.msgtype = 18;
                                    }

                                    if (ec.type == 3)
                                    {
                                        ec.msgtm = 60; ec.msgtype = 20;
                                    }

                                    if (ec.type == 4)
                                    {
                                        ec.msgtm = 60; ec.msgtype = DX.GetRand(7) + 1 + 1000 + (nステージb - 1) * 10;
                                    }

                                    if (ec.type == 5)
                                    {
                                        ec.msgtm = 60; ec.msgtype = 21;
                                    }

                                    if (ec.type == 9 || ec.type == 10)
                                    {
                                        nメッセージtm = 30; nメッセージtype = 54;
                                    }



                                    if (ec.type == 31)
                                    {
                                        ec.msgtm = 30; ec.msgtype = 24;
                                    }


                                    if (ec.type == 80 || ec.type == 81)
                                    {
                                        ec.msgtm = 60; ec.msgtype = 30;
                                    }

                                    if (ec.type == 82)
                                    {
                                        ec.msgtm = 20; ec.msgtype = DX.GetRand(1) + 31;
                                        xx_24 = 900; ec.type = 83; ec.a -= xx_24 + 100; ec.b -= xx_24 - 100 * 0;
                                    }//82

                                    if (ec.type == 84)
                                    {
                                        nメッセージtm = 30; nメッセージtype = 50;
                                    }

                                    if (ec.type == 85)
                                    {
                                        ec.msgtm = 60; ec.msgtype = DX.GetRand(1) + 85;
                                    }


                                    //雲
                                    if (ec.type == 80)
                                    {
                                        ec.type = 81;
                                    }
                                }//mhp==0


                                //こうら
                                if (ec.type == 2)
                                {
                                    if (ec.xtype == 0)
                                    {
                                        if (ma + nプレイヤー.nobia > xx_8 + xx_0 * 2 && ma < xx_8 + ec.nobia / 2 - xx_0 * 4)
                                        {
                                            ec.xtype = 1; ec.muki = 1; ec.a = ma + nプレイヤー.nobia + fx + nプレイヤー.c; nプレイヤー.mutekitm = 5;
                                        }
                                        else {
                                            ec.xtype = 1; ec.muki = 0; ec.a = ma - ec.nobia + fx - nプレイヤー.c; nプレイヤー.mutekitm = 5;
                                        }
                                    }
                                    else { nプレイヤー.hp -= 1; }//mmutekitm=40;}
                                }


                            }
                        }
                        //アイテム
                        if (ec.type >= 100 && ec.type <= 199)
                        {

                            if (ec.type == 100 && ec.xtype == 0) { nメッセージtm = 30; nメッセージtype = 1; v効果音再生(Res.nオーディオ9); }
                            if (ec.type == 100 && ec.xtype == 1) { nメッセージtm = 30; nメッセージtype = 2; v効果音再生(Res.nオーディオ9); }
                            if (ec.type == 100 && ec.xtype == 2) { nプレイヤー.nobia = 5200; nプレイヤー.nobib = 7300; v効果音再生(Res.nオーディオ9); ma -= 1100; nプレイヤー.b -= 4000; nプレイヤー.type = 1; nプレイヤー.hp = 50000000; }

                            if (ec.type == 101) { nプレイヤー.hp -= 1; nメッセージtm = 30; nメッセージtype = 11; }
                            if (ec.type == 102) { nプレイヤー.hp -= 1; nメッセージtm = 30; nメッセージtype = 10; }


                            //?ボール
                            if (ec.type == 105)
                            {
                                if (ec.xtype == 0)
                                {
                                    v効果音再生(Res.nオーディオ4); n地面[26].gtype = 6;
                                }
                                if (ec.xtype == 1)
                                {
                                    nブロック[7].xtype = 80;
                                    v効果音再生(Res.nオーディオ4);

                                    C敵キャラ ct;
                                    ct = new C敵キャラ();
                                    v敵キャラアイテム作成(ct,ec.a - 8 * 3000 - 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                    n敵キャラ.Add(ct);

                                    ct = new C敵キャラ();
                                    v敵キャラアイテム作成(ct,ec.a - 10 * 3000 + 1000, -1 * 3000, 0, 0, 0, 110, 0);
                                    n敵キャラ.Add(ct);


                                    ct = new C敵キャラ();
                                    v敵キャラアイテム作成(ct,ec.a + 4 * 3000 + 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                    n敵キャラ.Add(ct);

                                    ct = new C敵キャラ();
                                    v敵キャラアイテム作成(ct,ec.a + 5 * 3000 - 1000, -3 * 3000, 0, 0, 0, 110, 0);
                                    n敵キャラ.Add(ct);

                                    ct = new C敵キャラ();
                                    v敵キャラアイテム作成(ct,ec.a + 6 * 3000 + 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                    n敵キャラ.Add(ct);

                                    ct = new C敵キャラ();
                                    v敵キャラアイテム作成(ct,ec.a + 7 * 3000 - 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                    n敵キャラ.Add(ct);

                                    ct = new C敵キャラ();
                                    v敵キャラアイテム作成(ct,ec.a + 8 * 3000 + 1000, -2 * 3000 - 1000, 0, 0, 0, 110, 0);
                                    n敵キャラ.Add(ct);

                                    nブロック[0].b += 3000 * 3;
                                }
                            }//105

                            if (ec.type == 110) { nプレイヤー.hp -= 1; nメッセージtm = 30; nメッセージtype = 3; }

                            ec.a = -90000000;
                        }

                    }//(ma

                }
                else { ec.a = -9000000; }

            }//t
        }

        static void DrawEnemy()
        {
            DXDraw.nミラー = 0;
            //敵キャラ
            foreach (C敵キャラ ec in n敵キャラ.ToArray())
            {

                xx_0 = ec.a - fx; xx_1 = ec.b - fy;
                xx_2 = ec.nobia / 100; xx_3 = ec.nobib / 100; xx_14 = 3000; xx_16 = 0;
                if (xx_0 + xx_2 * 100 >= -10 - xx_14 && xx_1 <= n画面幅 + xx_14 && xx_1 + xx_3 * 100 >= -10 && xx_3 <= n画面高さ)
                {
                    if (ec.muki == 1) { DXDraw.nミラー = 1; }
                    if (ec.type == 3 && ec.xtype == 1) { DX.DrawRotaGraph(xx_0 / 100 + 13, xx_1 / 100 + 15, 1.0f, Math.PI / 1, Res.n切り取り画像[ec.type, 3], DX.TRUE); xx_16 = 1; }
                    if (ec.type == 9 && ec.d >= 1) { DX.DrawRotaGraph(xx_0 / 100 + 13, xx_1 / 100 + 15, 1.0f, Math.PI / 1, Res.n切り取り画像[ec.type, 3], DX.TRUE); xx_16 = 1; }
                    if (ec.type >= 100 && ec.muki == 1) DXDraw.nミラー = 0;

                    //メイン
                    if (ec.type < 200 && xx_16 == 0 && ec.type != 6 && ec.type != 79 && ec.type != 86 && ec.type != 30)
                    {
                        if (!((ec.type == 80 || ec.type == 81) && ec.xtype == 1))
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[ec.type, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }


                    //デフラグさん
                    if (ec.type == 6)
                    {
                        if (ec.tm >= 10 && ec.tm <= 19 || ec.tm >= 100 && ec.tm <= 119 || ec.tm >= 200)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[150, 3], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像[6, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }

                    //モララー
                    if (ec.type == 30)
                    {
                        if (ec.xtype == 0) DXDraw.DrawGraph(Res.n切り取り画像[30, 3], xx_0 / 100, xx_1 / 100);
                        if (ec.xtype == 1) DXDraw.DrawGraph(Res.n切り取り画像[155, 3], xx_0 / 100, xx_1 / 100);
                    }



                    //ステルス雲
                    if ((ec.type == 81) && ec.xtype == 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像[130, 3], xx_0 / 100, xx_1 / 100);
                    }

                    if (ec.type == 79)
                    {
                        DXDraw.SetColor(250, 250, 0);
                        DXDraw.DrawBox塗り潰し(xx_0 / 100, xx_1 / 100, xx_2, xx_3);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し(xx_0 / 100, xx_1 / 100, xx_2, xx_3);
                    }

                    if (ec.type == 82)
                    {

                        if (ec.xtype == 0)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 5 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (ec.xtype == 1)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 4 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (ec.xtype == 2)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[1, 5], xx_0 / 100, xx_1 / 100);
                        }

                    }
                    if (ec.type == 83)
                    {

                        if (ec.xtype == 0)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 5 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100 + 10, xx_1 / 100 + 9);
                        }

                        if (ec.xtype == 1)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 4 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100 + 10, xx_1 / 100 + 9);
                        }

                    }

                    //偽ポール
                    if (ec.type == 85)
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
                    if (ec.type == 86)
                    {
                        if (ma >= ec.a - fx - nプレイヤー.nobia - 4000 && ma <= ec.a - fx + ec.nobia + 4000)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像[152, 3], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像[86, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }

                    if (ec.type == 200)
                        DXDraw.DrawGraph(Res.n切り取り画像[0, 3], xx_0 / 100, xx_1 / 100);

                    DXDraw.nミラー = 0;
                }
            }
        }

        static void DrawEnemyファイアバー()
        {
            //ファイアバー
            foreach (C敵キャラ ec in n敵キャラ.ToArray())
            {

                xx_0 = ec.a - fx; xx_1 = ec.b - fy;
                xx_14 = 12000; xx_16 = 0;
                if (ec.type == 87 || ec.type == 88)
                {
                    if (xx_0 + xx_2 * 100 >= -10 - xx_14 && xx_1 <= n画面幅 + xx_14 && xx_1 + xx_3 * 100 >= -10 && xx_3 <= n画面高さ)
                    {

                        for (int tt_ = 0; tt_ <= ec.xtype % 100; tt_++)
                        {
                            xx_26 = 18;
                            double xd_4 = tt_ * xx_26 * Math.Cos(ec.tm * Math.PI / 180 / 2);
                            double xd_5 = tt_ * xx_26 * Math.Sin(ec.tm * Math.PI / 180 / 2);
                            xx_24 = (int)xd_4;
                            xx_25 = (int)xd_5;
                            DXDraw.SetColor(230, 120, 0);
                            xx_23 = 8;
                            if (ec.type == 87)
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

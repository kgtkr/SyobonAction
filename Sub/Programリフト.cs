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
        struct Cリフト
        {
            public int a,
            b,
            c,
            d,
            e,
            f;
            public int type,
                acttype,
                sp;
            public int muki,
                on,
                ee;
            public int sok,
                movep,
                move;
        }

        //リフト
        const int nリフトmax = 21;
        static int nリフトco;
        static Cリフト[] nリフト=new Cリフト[nリフトmax];
        

        static void Updateリフト()
        {
            //リフト
            for (int t_ = 0; t_ < nリフトmax; t_++)
            {
                xx_10 = nリフト[t_].a; xx_11 = nリフト[t_].b; xx_12 = nリフト[t_].c; xx_13 = nリフト[t_].d;
                xx_8 = xx_10 - fx; xx_9 = xx_11 - fy;
                if (xx_8 + xx_12 >= -10 - 12000 && xx_8 <= n画面幅 + 12100)
                {
                    xx_0 = 500; xx_1 = 1200; xx_2 = 1000; xx_7 = 2000;
                    if (nプレイヤー.d >= 100) { xx_1 = 900 + nプレイヤー.d; }

                    if (nプレイヤー.d > xx_1) xx_1 = nプレイヤー.d + 100;

                    nリフト[t_].b += nリフト[t_].e;
                    nリフト[t_].e += nリフト[t_].f;

                    //動き
                    switch (nリフト[t_].acttype)
                    {

                        case 1:
                            if (nリフト[t_].on == 1) nリフト[t_].f = 60;
                            break;
                        case 2:
                            break;

                        case 3:
                        case 5:
                            if (nリフト[t_].move == 0) { nリフト[t_].muki = 0; }
                            else { nリフト[t_].muki = 1; }
                            if (nリフト[t_].b - fy < -2100) { nリフト[t_].b = n画面高さ + fy + 2000; }
                            if (nリフト[t_].b - fy > n画面高さ + 2000) { nリフト[t_].b = -2100 + fy; }
                            break;

                        case 6:
                            if (nリフト[t_].on == 1) nリフト[t_].f = 40;
                            break;

                        case 7:
                            break;


                    }//sw

                    //乗ったとき
                    if (ma + nプレイヤー.nobia > xx_8 + xx_0 && ma < xx_8 + xx_12 - xx_0 && nプレイヤー.b + nプレイヤー.nobib > xx_9 && nプレイヤー.b + nプレイヤー.nobib < xx_9 + xx_1 && nプレイヤー.d >= -100)
                    {
                        nプレイヤー.b = xx_9 - nプレイヤー.nobib + 100;

                        if (nリフト[t_].type == 1) { nリフト[10].e = 900; nリフト[11].e = 900; }

                        if (nリフト[t_].sp != 12)
                        {
                            nプレイヤー.zimen = 1; nプレイヤー.d = 0;
                        }
                        else {
                            //すべり
                            nプレイヤー.d = -800;
                        }



                        //落下
                        if ((nリフト[t_].acttype == 1) && nリフト[t_].on == 0) nリフト[t_].on = 1;

                        if (nリフト[t_].acttype == 1 && nリフト[t_].on == 1 || nリフト[t_].acttype == 3 || nリフト[t_].acttype == 5)
                        {
                            nプレイヤー.b += nリフト[t_].e;
                        }

                        if (nリフト[t_].acttype == 7)
                        {
                            if (nプレイヤー.actaon[2] != 1) { nプレイヤー.d = -600; nプレイヤー.b -= 810; }
                            if (nプレイヤー.actaon[2] == 1) { nプレイヤー.b -= 400; nプレイヤー.d = -1400; nプレイヤー.jumptm = 10; }
                        }


                        //特殊
                        if (nリフト[t_].sp == 1)
                        {
                            v効果音再生(Res.nオーディオ3);
                            eyobi(nリフト[t_].a + 200, nリフト[t_].b - 1000, -240, -1400, 0, 160, 4500, 4500, 2, 120);
                            eyobi(nリフト[t_].a + 4500 - 200, nリフト[t_].b - 1000, 240, -1400, 0, 160, 4500, 4500, 3, 120);
                            nリフト[t_].a = -70000000;
                        }

                        if (nリフト[t_].sp == 2)
                        {
                            nプレイヤー.c = -2400; nリフト[t_].move += 1;
                            if (nリフト[t_].move >= 100) { nプレイヤー.hp = 0; nメッセージtype = 53; nメッセージtm = 30; nリフト[t_].move = -5000; }
                        }

                        if (nリフト[t_].sp == 3)
                        {
                            nプレイヤー.c = 2400; nリフト[t_].move += 1;
                            if (nリフト[t_].move >= 100) { nプレイヤー.hp = 0; nメッセージtype = 53; nメッセージtm = 30; nリフト[t_].move = -5000; }
                        }
                    }//判定内


                    //疲れ初期化
                    if ((nリフト[t_].sp == 2 || nリフト[t_].sp == 3) && nプレイヤー.c != -2400 && nリフト[t_].move > 0) { nリフト[t_].move--; }

                    if (nリフト[t_].sp == 11)
                    {
                        if (ma + nプレイヤー.nobia > xx_8 + xx_0 - 2000 && ma < xx_8 + xx_12 - xx_0) { nリフト[t_].on = 1; }// && mb+mnobib>xx_9-1000 && mb+mnobib<xx_9+xx_1+2000)
                        if (nリフト[t_].on == 1) { nリフト[t_].f = 60; nリフト[t_].b += nリフト[t_].e; }
                    }


                    //トゲ(下)
                    if (ma + nプレイヤー.nobia > xx_8 + xx_0 && ma < xx_8 + xx_12 - xx_0 && nプレイヤー.b > xx_9 - xx_1 / 2 && nプレイヤー.b < xx_9 + xx_1 / 2)
                    {
                        if (nリフト[t_].type == 2) { if (nプレイヤー.d < 0) { nプレイヤー.d = -nプレイヤー.d; } nプレイヤー.b += 110; if (nプレイヤー.mutekitm <= 0) nプレイヤー.hp -= 1; nプレイヤー.mutekitm = 40; }
                    }
                    //落下
                    if (nリフト[t_].acttype == 6)
                    {
                        if (ma + nプレイヤー.nobia > xx_8 + xx_0 && ma < xx_8 + xx_12 - xx_0) { nリフト[t_].on = 1; }
                    }

                    if (nリフト[t_].acttype == 2 || nリフト[t_].acttype == 4)
                    {
                        if (nリフト[t_].muki == 0) nリフト[t_].a -= nリフト[t_].sok;
                        if (nリフト[t_].muki == 1) nリフト[t_].a += nリフト[t_].sok;
                    }
                    if (nリフト[t_].acttype == 3 || nリフト[t_].acttype == 5)
                    {
                        if (nリフト[t_].muki == 0) nリフト[t_].b -= nリフト[t_].sok;
                        if (nリフト[t_].muki == 1) nリフト[t_].b += nリフト[t_].sok;
                    }

                    //敵キャラ適用
                    for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                    {
                        if (n敵キャラ[tt_].zimentype == 1)
                        {
                            if (n敵キャラ[tt_].a + n敵キャラ[tt_].nobia - fx > xx_8 + xx_0 && n敵キャラ[tt_].a - fx < xx_8 + xx_12 - xx_0 && n敵キャラ[tt_].b + n敵キャラ[tt_].nobib > xx_11 - 100 && n敵キャラ[tt_].b + n敵キャラ[tt_].nobib < xx_11 + xx_1 + 500 && n敵キャラ[tt_].d >= -100)
                            {
                                n敵キャラ[tt_].b = xx_9 - n敵キャラ[tt_].nobib + 100; n敵キャラ[tt_].d = 0; n敵キャラ[tt_].xzimen = 1;
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
                xx_0 = nリフト[t_].a - fx; xx_1 = nリフト[t_].b - fy;
                if (xx_0 + nリフト[t_].c >= -10 && xx_1 <= n画面幅 + 12100 && nリフト[t_].c / 100 >= 1)
                {
                    xx_2 = 14; if (nリフト[t_].sp == 1) { xx_2 = 12; }

                    if (nリフト[t_].sp <= 9 || nリフト[t_].sp >= 20)
                    {
                        DXDraw.SetColor(220, 220, 0);
                        if (nリフト[t_].sp == 2 || nリフト[t_].sp == 3) { DXDraw.SetColor(0, 220, 0); }
                        if (nリフト[t_].sp == 21) { DXDraw.SetColor(180, 180, 180); }
                        DXDraw.DrawBox塗り潰し((nリフト[t_].a - fx) / 100, (nリフト[t_].b - fy) / 100, nリフト[t_].c / 100, xx_2);

                        DXDraw.SetColor(180, 180, 0);
                        if (nリフト[t_].sp == 2 || nリフト[t_].sp == 3) { DXDraw.SetColor(0, 180, 0); }
                        if (nリフト[t_].sp == 21) { DXDraw.SetColor(150, 150, 150); }
                        DXDraw.DrawBox塗り無し((nリフト[t_].a - fx) / 100, (nリフト[t_].b - fy) / 100, nリフト[t_].c / 100, xx_2);
                    }
                    else if (nリフト[t_].sp <= 14)
                    {
                        if (nリフト[t_].c >= 5000)
                        {
                            DXDraw.SetColor(0, 200, 0);
                            DXDraw.DrawBox塗り潰し((nリフト[t_].a - fx) / 100, (nリフト[t_].b - fy) / 100, nリフト[t_].c / 100, 30);
                            DXDraw.SetColor(0, 160, 0);
                            DXDraw.DrawBox塗り無し((nリフト[t_].a - fx) / 100, (nリフト[t_].b - fy) / 100, nリフト[t_].c / 100, 30);

                            DXDraw.SetColor(180, 120, 60);
                            DXDraw.DrawBox塗り潰し((nリフト[t_].a - fx) / 100 + 20, (nリフト[t_].b - fy) / 100 + 30, nリフト[t_].c / 100 - 40, 480);
                            DXDraw.SetColor(100, 80, 20);
                            DXDraw.DrawBox塗り無し((nリフト[t_].a - fx) / 100 + 20, (nリフト[t_].b - fy) / 100 + 30, nリフト[t_].c / 100 - 40, 480);

                        }
                    }
                    if (nリフト[t_].sp == 15)
                    {
                        for (int t2 = 0; t2 <= 2; t2++)
                        {
                            xx_6 = 1 + 0; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], (nリフト[t_].a - fx) / 100 + t2 * 29, (nリフト[t_].b - fy) / 100);
                        }
                    }//15
                }
            }//t
        }
    }
}
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
        class Cリフト
        {
            public int a,
            b=1,
            c=1,
            d=1,
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
            public bool b落ちる;
        }

        //リフト
        static List<Cリフト> nリフト = new List<Cリフト>();
        

        static void Updateリフト()
        {
            //リフト
            foreach (Cリフト cl in nリフト.ToArray())
            {
                xx_10 = cl.a; xx_11 = cl.b; xx_12 = cl.c; xx_13 = cl.d;
                xx_8 = xx_10 - fx; xx_9 = xx_11 - fy;
                if (xx_8 + xx_12 >= -10 - 12000 && xx_8 <= n画面幅 + 12100)
                {
                    xx_0 = 500; xx_1 = 1200; xx_2 = 1000; xx_7 = 2000;
                    if (nプレイヤー.d >= 100) { xx_1 = 900 + nプレイヤー.d; }

                    if (nプレイヤー.d > xx_1) xx_1 = nプレイヤー.d + 100;

                    cl.b += cl.e;
                    cl.e += cl.f;

                    //動き
                    switch (cl.acttype)
                    {

                        case 1:
                            if (cl.on == 1) cl.f = 60;
                            break;
                        case 2:
                            break;

                        case 3:
                        case 5:
                            if (cl.move == 0) { cl.muki = 0; }
                            else { cl.muki = 1; }
                            if (cl.b - fy < -2100) { cl.b = n画面高さ + fy + 2000; }
                            if (cl.b - fy > n画面高さ + 2000) { cl.b = -2100 + fy; }
                            break;

                        case 6:
                            if (cl.on == 1) cl.f = 40;
                            break;

                        case 7:
                            break;


                    }//sw

                    //乗ったとき
                    if (ma + nプレイヤー.nobia > xx_8 + xx_0 && ma < xx_8 + xx_12 - xx_0 && nプレイヤー.b + nプレイヤー.nobib > xx_9 && nプレイヤー.b + nプレイヤー.nobib < xx_9 + xx_1 && nプレイヤー.d >= -100)
                    {
                        nプレイヤー.b = xx_9 - nプレイヤー.nobib + 100;

                        if (cl.type == 1) {
                            foreach (Cリフト cl2 in nリフト.ToArray())
                            {
                                if (cl2.b落ちる)
                                {
                                    cl2.e = 900;
                                }
                            }
                        }

                        if (cl.sp != 12)
                        {
                            nプレイヤー.zimen = 1; nプレイヤー.d = 0;
                        }
                        else {
                            //すべり
                            nプレイヤー.d = -800;
                        }



                        //落下
                        if ((cl.acttype == 1) && cl.on == 0) cl.on = 1;

                        if (cl.acttype == 1 && cl.on == 1 || cl.acttype == 3 || cl.acttype == 5)
                        {
                            nプレイヤー.b += cl.e;
                        }

                        if (cl.acttype == 7)
                        {
                            if (nプレイヤー.actaon[2] != 1) { nプレイヤー.d = -600; nプレイヤー.b -= 810; }
                            if (nプレイヤー.actaon[2] == 1) { nプレイヤー.b -= 400; nプレイヤー.d = -1400; nプレイヤー.jumptm = 10; }
                        }


                        //特殊
                        if (cl.sp == 1)
                        {
                            v効果音再生(Res.nオーディオ3);

                            C絵 ce;

                            ce = new C絵();
                            eyobi(ce,cl.a + 200, cl.b - 1000, -240, -1400, 0, 160, 4500, 4500, 2, 120);
                            n絵.Add(ce);

                            ce = new C絵();
                            eyobi(ce,cl.a + 4500 - 200, cl.b - 1000, 240, -1400, 0, 160, 4500, 4500, 3, 120);
                            n絵.Add(ce);

                            cl.a = -70000000;
                        }

                        if (cl.sp == 2)
                        {
                            nプレイヤー.c = -2400; cl.move += 1;
                            if (cl.move >= 100) { nプレイヤー.hp = 0; nメッセージtype = 53; nメッセージtm = 30; cl.move = -5000; }
                        }

                        if (cl.sp == 3)
                        {
                            nプレイヤー.c = 2400; cl.move += 1;
                            if (cl.move >= 100) { nプレイヤー.hp = 0; nメッセージtype = 53; nメッセージtm = 30; cl.move = -5000; }
                        }
                    }//判定内


                    //疲れ初期化
                    if ((cl.sp == 2 || cl.sp == 3) && nプレイヤー.c != -2400 && cl.move > 0) { cl.move--; }

                    if (cl.sp == 11)
                    {
                        if (ma + nプレイヤー.nobia > xx_8 + xx_0 - 2000 && ma < xx_8 + xx_12 - xx_0) { cl.on = 1; }// && mb+mnobib>xx_9-1000 && mb+mnobib<xx_9+xx_1+2000)
                        if (cl.on == 1) { cl.f = 60; cl.b += cl.e; }
                    }


                    //トゲ(下)
                    if (ma + nプレイヤー.nobia > xx_8 + xx_0 && ma < xx_8 + xx_12 - xx_0 && nプレイヤー.b > xx_9 - xx_1 / 2 && nプレイヤー.b < xx_9 + xx_1 / 2)
                    {
                        if (cl.type == 2) { if (nプレイヤー.d < 0) { nプレイヤー.d = -nプレイヤー.d; } nプレイヤー.b += 110; if (nプレイヤー.mutekitm <= 0) nプレイヤー.hp -= 1; nプレイヤー.mutekitm = 40; }
                    }
                    //落下
                    if (cl.acttype == 6)
                    {
                        if (ma + nプレイヤー.nobia > xx_8 + xx_0 && ma < xx_8 + xx_12 - xx_0) { cl.on = 1; }
                    }

                    if (cl.acttype == 2 || cl.acttype == 4)
                    {
                        if (cl.muki == 0) cl.a -= cl.sok;
                        if (cl.muki == 1) cl.a += cl.sok;
                    }
                    if (cl.acttype == 3 || cl.acttype == 5)
                    {
                        if (cl.muki == 0) cl.b -= cl.sok;
                        if (cl.muki == 1) cl.b += cl.sok;
                    }

                    //敵キャラ適用
                    foreach (C敵キャラ et in n敵キャラ.ToArray())
                    {
                        if (et.zimentype == 1)
                        {
                            if (et.a + et.nobia - fx > xx_8 + xx_0 && et.a - fx < xx_8 + xx_12 - xx_0 && et.b + et.nobib > xx_11 - 100 && et.b + et.nobib < xx_11 + xx_1 + 500 && et.d >= -100)
                            {
                                et.b = xx_9 - et.nobib + 100; et.d = 0; et.xzimen = 1;
                            }
                        }
                    }
                }
            }//リフト
        }

        static void Drawリフト()
        {
            //リフト
            foreach (Cリフト cl in nリフト.ToArray())
            {
                xx_0 = cl.a - fx; xx_1 = cl.b - fy;
                if (xx_0 + cl.c >= -10 && xx_1 <= n画面幅 + 12100 && cl.c / 100 >= 1)
                {
                    xx_2 = 14; if (cl.sp == 1) { xx_2 = 12; }

                    if (cl.sp <= 9 || cl.sp >= 20)
                    {
                        DXDraw.SetColor(220, 220, 0);
                        if (cl.sp == 2 || cl.sp == 3) { DXDraw.SetColor(0, 220, 0); }
                        if (cl.sp == 21) { DXDraw.SetColor(180, 180, 180); }
                        DXDraw.DrawBox塗り潰し((cl.a - fx) / 100, (cl.b - fy) / 100, cl.c / 100, xx_2);

                        DXDraw.SetColor(180, 180, 0);
                        if (cl.sp == 2 || cl.sp == 3) { DXDraw.SetColor(0, 180, 0); }
                        if (cl.sp == 21) { DXDraw.SetColor(150, 150, 150); }
                        DXDraw.DrawBox塗り無し((cl.a - fx) / 100, (cl.b - fy) / 100, cl.c / 100, xx_2);
                    }
                    else if (cl.sp <= 14)
                    {
                        if (cl.c >= 5000)
                        {
                            DXDraw.SetColor(0, 200, 0);
                            DXDraw.DrawBox塗り潰し((cl.a - fx) / 100, (cl.b - fy) / 100, cl.c / 100, 30);
                            DXDraw.SetColor(0, 160, 0);
                            DXDraw.DrawBox塗り無し((cl.a - fx) / 100, (cl.b - fy) / 100, cl.c / 100, 30);

                            DXDraw.SetColor(180, 120, 60);
                            DXDraw.DrawBox塗り潰し((cl.a - fx) / 100 + 20, (cl.b - fy) / 100 + 30, cl.c / 100 - 40, 480);
                            DXDraw.SetColor(100, 80, 20);
                            DXDraw.DrawBox塗り無し((cl.a - fx) / 100 + 20, (cl.b - fy) / 100 + 30, cl.c / 100 - 40, 480);

                        }
                    }
                    if (cl.sp == 15)
                    {
                        for (int t2 = 0; t2 <= 2; t2++)
                        {
                            xx_6 = 1 + 0; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], (cl.a - fx) / 100 + t2 * 29, (cl.b - fy) / 100);
                        }
                    }//15
                }
            }//t
        }
    }
}
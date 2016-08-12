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
        struct Cブロック
        {
            public int a,
            b,
            c,
            d,
            hp,
            type;
            public int item,
                xtype;
        }

        //ブロック
        const int nブロックmax = 641;
        static int nブロックco;
        static Cブロック[] nブロック = new Cブロック[nブロックmax];


        static void UpdateBlock()
        {
            //ブロック
            //1-れんが、コイン、無し、土台、7-隠し
            xx_15 = 0;
            for (int t_ = 0; t_ < nブロックmax; t_++)
            {
                xx_0 = 200; xx_1 = 3000; xx_2 = 1000; xx_3 = 3000;//xx_2=1000
                xx_8 = nブロック[t_].a - fx; xx_9 = nブロック[t_].b - fy;//xx_15=0;
                if (nブロック[t_].a - fx + xx_1 >= -10 - xx_3 && nブロック[t_].a - fx <= n画面幅 + 12000 + xx_3)
                {
                    if (nプレイヤー.type != 200 && nプレイヤー.type != 1 && nプレイヤー.type != 2)
                    {
                        if (nブロック[t_].type < 1000 && nブロック[t_].type != 800 && nブロック[t_].type != 140 && nブロック[t_].type != 141)
                        {
                            xx_16 = 0; xx_17 = 0;

                            //上
                            if (nブロック[t_].type != 7 && nブロック[t_].type != 110 && !(nブロック[t_].type == 114))
                            {
                                if (ma + nプレイヤー.nobia > xx_8 + xx_0 * 2 + 100 && ma < xx_8 + xx_1 - xx_0 * 2 - 100 && nプレイヤー.b + nプレイヤー.nobib > xx_9 && nプレイヤー.b + nプレイヤー.nobib < xx_9 + xx_1 && nプレイヤー.d >= -100)
                                {
                                    if (nブロック[t_].type != 115 && nブロック[t_].type != 400 && nブロック[t_].type != 117 && nブロック[t_].type != 118 && nブロック[t_].type != 120)
                                    {
                                        nプレイヤー.b = xx_9 - nプレイヤー.nobib + 100; nプレイヤー.d = 0; nプレイヤー.zimen = 1; xx_16 = 1;
                                    }
                                    else if (nブロック[t_].type == 115)
                                    {
                                        v効果音再生(Res.nオーディオ3);
                                        eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                        eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                        eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                        eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                        brockBreak(t_);
                                    }
                                    //Pスイッチ
                                    else if (nブロック[t_].type == 400)
                                    {
                                        nプレイヤー.d = 0; nブロック[t_].a = -8000000; v効果音再生(Res.nオーディオ13);
                                        for (int tt_ = 0; tt_ < nブロックmax; tt_++) { if (nブロック[tt_].type != 7) { nブロック[tt_].type = 800; } }
                                    }

                                    //音符+
                                    else if (nブロック[t_].type == 117)
                                    {
                                        v効果音再生(Res.nオーディオ14);
                                        nプレイヤー.d = -1500; nプレイヤー.type = 2; nプレイヤー.tm = 0;
                                        if (nブロック[t_].xtype >= 2 && nプレイヤー.type == 2) { nプレイヤー.type = 0; nプレイヤー.d = -1600; nブロック[t_].xtype = 3; }
                                        if (nブロック[t_].xtype == 0) nブロック[t_].xtype = 1;
                                    }

                                    //ジャンプ台
                                    else if (nブロック[t_].type == 120)
                                    {
                                        //txtype[t]=0;
                                        nプレイヤー.d = -2400; nプレイヤー.type = 3; nプレイヤー.tm = 0;
                                    }

                                }
                            }


                            //sstr=""+mjumptm;
                            //ブロック判定の入れ替え
                            xx_21 = 0; xx_22 = 1;//xx_12=0;
                            if (nプレイヤー.zimen == 1 || nプレイヤー.jumptm >= 10) { xx_21 = 3; xx_22 = 0; }
                            for (int t3 = 0; t3 <= 1; t3++)
                            {

                                //下
                                if (t3 == xx_21 && nプレイヤー.type != 100 && nブロック[t_].type != 117)
                                {// && xx_12==0){
                                    if (ma + nプレイヤー.nobia > xx_8 + xx_0 * 2 + 800 && ma < xx_8 + xx_1 - xx_0 * 2 - 800 && nプレイヤー.b > xx_9 - xx_0 * 2 && nプレイヤー.b < xx_9 + xx_1 - xx_0 * 2 && nプレイヤー.d <= 0)
                                    {
                                        xx_16 = 1; xx_17 = 1;
                                        nプレイヤー.b = xx_9 + xx_1 + xx_0; if (nプレイヤー.d < 0) { nプレイヤー.d = -nプレイヤー.d * 2 / 3; }//}
                                                                                                                          //壊れる
                                        if (nブロック[t_].type == 1 && nプレイヤー.zimen == 0)
                                        {
                                            v効果音再生(Res.nオーディオ3);
                                            eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                            eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                            eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                            eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                            brockBreak(t_);
                                        }
                                        //コイン
                                        if (nブロック[t_].type == 2 && nプレイヤー.zimen == 0)
                                        {
                                            v効果音再生(Res.nオーディオ4);
                                            eyobi(nブロック[t_].a + 10, nブロック[t_].b, 0, -800, 0, 40, 3000, 3000, 0, 16);
                                            nブロック[t_].type = 3;
                                        }
                                        //隠し
                                        if (nブロック[t_].type == 7)
                                        {
                                            v効果音再生(Res.nオーディオ4);
                                            eyobi(nブロック[t_].a + 10, nブロック[t_].b, 0, -800, 0, 40, 3000, 3000, 0, 16);
                                            nプレイヤー.b = xx_9 + xx_1 + xx_0; nブロック[t_].type = 3; if (nプレイヤー.d < 0) { nプレイヤー.d = -nプレイヤー.d * 2 / 3; }
                                        }
                                        // トゲ
                                        if (nブロック[t_].type == 10)
                                        {
                                            nメッセージtm = 30;
                                            nメッセージtype = 3;
                                            nプレイヤー.hp--;
                                        }
                                    }
                                }


                                //左右
                                if (t3 == xx_22 && xx_15 == 0)
                                {
                                    if (nブロック[t_].type != 7 && nブロック[t_].type != 110 && nブロック[t_].type != 117)
                                    {
                                        if (!(nブロック[t_].type == 114))
                                        {// && txtype[t]==1)){
                                            if (nブロック[t_].a >= -20000)
                                            {
                                                if (ma + nプレイヤー.nobia > xx_8 && ma < xx_8 + xx_2 && nプレイヤー.b + nプレイヤー.nobib > xx_9 + xx_1 / 2 - xx_0 && nプレイヤー.b < xx_9 + xx_2 && nプレイヤー.c >= 0)
                                                {
                                                    ma = xx_8 - nプレイヤー.nobia; nプレイヤー.c = 0; xx_16 = 1;
                                                }
                                                if (ma + nプレイヤー.nobia > xx_8 + xx_2 && ma < xx_8 + xx_1 && nプレイヤー.b + nプレイヤー.nobib > xx_9 + xx_1 / 2 - xx_0 && nプレイヤー.b < xx_9 + xx_2 && nプレイヤー.c <= 0)
                                                {
                                                    ma = xx_8 + xx_1; nプレイヤー.c = 0; xx_16 = 1;//end();
                                                }
                                            }
                                        }
                                    }
                                }

                            }//t3

                        }// && ttype[t]<50

                        if (nブロック[t_].type == 800)
                        {
                            if (nプレイヤー.b > xx_9 - xx_0 * 2 - 2000 && nプレイヤー.b < xx_9 + xx_1 - xx_0 * 2 + 2000 && ma + nプレイヤー.nobia > xx_8 - 400 && ma < xx_8 + xx_1)
                            {
                                nブロック[t_].a = -800000; v効果音再生(Res.nオーディオ4);
                            }
                        }

                        //剣とってクリア
                        if (nブロック[t_].type == 140)
                        {
                            if (nプレイヤー.b > xx_9 - xx_0 * 2 - 2000 && nプレイヤー.b < xx_9 + xx_1 - xx_0 * 2 + 2000 && ma + nプレイヤー.nobia > xx_8 - 400 && ma < xx_8 + xx_1)
                            {
                                nブロック[t_].a = -800000;//ot(oto[4]);
                                nリフト[20].acttype = 1; nリフト[20].on = 1;
                                DX.StopSoundMem(Res.n現在のBGM); nプレイヤー.type = 301; nプレイヤー.tm = 0; v効果音再生(Res.nオーディオ16);

                            }
                        }


                        //特殊的
                        if (nブロック[t_].type == 100)
                        {//xx_9+xx_1+3000<mb && // && mb>xx_9-xx_0*2
                            if (nプレイヤー.b > xx_9 - xx_0 * 2 - 2000 && nプレイヤー.b < xx_9 + xx_1 - xx_0 * 2 + 2000 && ma + nプレイヤー.nobia > xx_8 - 400 && ma < xx_8 + xx_1 && nプレイヤー.d <= 0)
                            {
                                if (nブロック[t_].xtype == 0) nブロック[t_].b = nプレイヤー.b + fy - 1200 - xx_1;
                            }

                            if (nブロック[t_].xtype == 1)
                            {
                                if (xx_17 == 1)
                                {
                                    if (ma + nプレイヤー.nobia > xx_8 - 400 && ma < xx_8 + xx_1 / 2 - 1500) { nブロック[t_].a += 3000; }
                                    else if (ma + nプレイヤー.nobia >= xx_8 + xx_1 / 2 - 1500 && ma < xx_8 + xx_1) { nブロック[t_].a -= 3000; }
                                }
                            }

                            if (xx_17 == 1 && nブロック[t_].xtype == 0)
                            {
                                v効果音再生(Res.nオーディオ4);
                                eyobi(nブロック[t_].a + 10, nブロック[t_].b, 0, -800, 0, 40, 3000, 3000, 0, 16);
                                nブロック[t_].type = 3;
                            }
                        }//100

                        //敵出現
                        if (nブロック[t_].type == 101)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ8);
                                nブロック[t_].type = 3;
                                var ec = new C敵キャラ();
                                ec.brocktm = 16;
                                if (nブロック[t_].xtype == 0) v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 0, 0);
                                if (nブロック[t_].xtype == 1) v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 4, 0);
                                if (nブロック[t_].xtype == 3) v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 101, 0);
                                if (nブロック[t_].xtype == 4)
                                {
                                    ec.brocktm = 20;
                                    v敵キャラアイテム作成(ec, nブロック[t_].a - 400, nブロック[t_].b - 1600, 0, 0, 0, 6, 0);
                                }
                                if (nブロック[t_].xtype == 10) v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 101, 0);
                                n敵キャラ.Add(ec);
                            }
                        }//101

                        //おいしいきのこ出現
                        if (nブロック[t_].type == 102)
                        {
                            if (xx_17 == 1)
                            {
                                var ec = new C敵キャラ();
                                v効果音再生(Res.nオーディオ8);
                                nブロック[t_].type = 3;
                                ec.brocktm = 16;
                                if (nブロック[t_].xtype == 0) v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 100, 0);
                                if (nブロック[t_].xtype == 2) v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 100, 2);
                                if (nブロック[t_].xtype == 3) v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 102, 1);
                                n敵キャラ.Add(ec);
                            }
                        }//102

                        //まずいきのこ出現
                        if (nブロック[t_].type == 103)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ8);
                                nブロック[t_].type = 3;
                                var ec = new C敵キャラ();
                                ec.brocktm = 16;
                                v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 100, 1);
                            }
                        }//103


                        //悪スター出し
                        if (nブロック[t_].type == 104)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ8);
                                nブロック[t_].type = 3;
                                var ec = new C敵キャラ();
                                ec.brocktm = 16;
                                v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 110, 0);
                                n敵キャラ.Add(ec);
                            }
                        }//104




                        //毒きのこ量産
                        if (nブロック[t_].type == 110)
                        {
                            if (xx_17 == 1)
                            {
                                nブロック[t_].type = 111; nブロック[t_].hp = 999;
                            }
                        }//110
                        if (nブロック[t_].type == 111 && nブロック[t_].a - fx >= 0)
                        {
                            nブロック[t_].hp++; if (nブロック[t_].hp >= 16)
                            {
                                nブロック[t_].hp = 0;
                                v効果音再生(Res.nオーディオ8);
                                var ec = new C敵キャラ();
                                ec.brocktm = 16;
                                v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 102, 1);
                                n敵キャラ.Add(ec);
                            }
                        }


                        //コイン量産
                        if (nブロック[t_].type == 112)
                        {
                            if (xx_17 == 1)
                            {
                                nブロック[t_].type = 113; nブロック[t_].hp = 999; nブロック[t_].item = 0;
                            }
                        }//110
                        if (nブロック[t_].type == 113 && nブロック[t_].a - fx >= 0)
                        {
                            if (nブロック[t_].item <= 19) nブロック[t_].hp++;
                            if (nブロック[t_].hp >= 3)
                            {
                                nブロック[t_].hp = 0; nブロック[t_].item++;
                                v効果音再生(Res.nオーディオ4);
                                eyobi(nブロック[t_].a + 10, nブロック[t_].b, 0, -800, 0, 40, 3000, 3000, 0, 16);
                                //ttype[t]=3;
                            }
                        }


                        //隠し毒きのこ
                        if (nブロック[t_].type == 114)
                        {
                            if (xx_17 == 1)
                            {
                                if (nブロック[t_].xtype == 0)
                                {
                                    v効果音再生(Res.nオーディオ8); nブロック[t_].type = 3;
                                    var ec = new C敵キャラ();
                                    ec.brocktm = 16;
                                    v敵キャラアイテム作成(ec, nブロック[t_].a, nブロック[t_].b, 0, 0, 0, 102, 1);
                                }
                                if (nブロック[t_].xtype == 2) { v効果音再生(Res.nオーディオ4); eyobi(nブロック[t_].a + 10, nブロック[t_].b, 0, -800, 0, 40, 3000, 3000, 0, 16); nブロック[t_].type = 115; nブロック[t_].xtype = 0; }
                                if (nブロック[t_].xtype == 10)
                                {
                                    if (bステージスイッチ)
                                    {
                                        nブロック[t_].type = 130;
                                        bステージスイッチ = false;
                                        v効果音再生(Res.nオーディオ13);
                                        nブロック[t_].xtype = 2;
                                        foreach (C敵キャラ et in n敵キャラ.ToArray())
                                            if (et.type == 87 || et.type == 88)
                                            {
                                                if (et.xtype == 105)
                                                {
                                                    et.xtype = 110;
                                                }
                                            }
                                    }
                                }
                                else {
                                    v効果音再生(Res.nオーディオ4);
                                    eyobi(nブロック[t_].a + 10, nブロック[t_].b, 0, -800, 0, 40, 3000, 3000, 0, 16);
                                    nブロック[t_].type = 3;
                                }
                            }

                        }
                    }//114


                    //もろいブロック
                    if (nブロック[t_].type == 115)
                    {

                    }//115


                    //Pスイッチ
                    if (nブロック[t_].type == 116)
                    {
                        if (xx_17 == 1)
                        {
                            v効果音再生(Res.nオーディオ8);
                            nブロック[t_].type = 3;
                            tyobi(nブロック[t_].a / 100, (nブロック[t_].b / 100) - 29, 400);
                        }
                    }//116


                    //ファイアバー強化
                    if (nブロック[t_].type == 124)
                    {
                        if (xx_17 == 1)
                        {
                            v効果音再生(Res.nオーディオ13);
                            foreach (C敵キャラ et in n敵キャラ.ToArray())
                            {
                                if (et.type == 87 || et.type == 88)
                                {
                                    if (et.xtype == 101)
                                    {
                                        et.xtype = 120;
                                    }
                                }
                            }
                            //TODO:↓いらなそうなので消した
                            //nブロック[t_].type = 3;
                        }
                    }

                    //ONスイッチ
                    if (nブロック[t_].type == 130)
                    {
                        if (xx_17 == 1)
                        {
                            if (nブロック[t_].xtype != 1)
                            {
                                bステージスイッチ = false; v効果音再生(Res.nオーディオ13);
                            }
                        }
                    }
                    else if (nブロック[t_].type == 131)
                    {
                        if (xx_17 == 1 && nブロック[t_].xtype != 2)
                        {
                            bステージスイッチ = true; v効果音再生(Res.nオーディオ13);
                            if (nブロック[t_].xtype == 1)
                            {
                                foreach (C敵キャラ et in n敵キャラ.ToArray())
                                {
                                    if (et.type == 87 || et.type == 88)
                                    {
                                        if (et.xtype == 105)
                                        {
                                            et.xtype = 110;
                                        }
                                    }
                                }
                                n敵出現[3].xtype = 105;
                            }
                        }
                    }

                    //ヒント
                    if (nブロック[t_].type == 300)
                    {
                        if (xx_17 == 1)
                        {
                            v効果音再生(Res.nオーディオ15);
                            if (nブロック[t_].xtype <= 100)
                            {
                                nメッセージブロックtype = 1; nメッセージブロックtm = 15; nメッセージブロックy = 300 + (nブロック[t_].xtype - 1); nメッセージブロック = (nブロック[t_].xtype);
                            }
                            if (nブロック[t_].xtype == 540)
                            {
                                nメッセージブロックtype = 1; nメッセージブロックtm = 15; nメッセージブロックy = 400; nメッセージブロック = 100; nブロック[t_].xtype = 541;
                            }
                        }
                    }//300


                    if (nブロック[t_].type == 301)
                    {
                        if (xx_17 == 1)
                        {
                            v効果音再生(Res.nオーディオ3);
                            eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120); eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                            brockBreak(t_);
                        }
                    }//300


                }
                else if (nプレイヤー.type == 1)
                {
                    if (ma + nプレイヤー.nobia > xx_8 && ma < xx_8 + xx_1 && nプレイヤー.b + nプレイヤー.nobib > xx_9 && nプレイヤー.b < xx_9 + xx_1)
                    {

                        v効果音再生(Res.nオーディオ3);
                        eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                        eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                        eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                        eyobi(nブロック[t_].a + 1200, nブロック[t_].b + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                        brockBreak(t_);

                    }
                }


                //ONOFF
                if (nブロック[t_].type == 130 && !bステージスイッチ) { nブロック[t_].type = 131; }
                if (nブロック[t_].type == 131 && bステージスイッチ) { nブロック[t_].type = 130; }

                //ヒント
                if (nブロック[t_].type == 300)
                {
                    if (nブロック[t_].xtype >= 500 && nブロック[t_].a >= -6000)
                    {// && ta[t]>=-6000){
                        if (nブロック[t_].xtype <= 539) nブロック[t_].xtype++;
                        if (nブロック[t_].xtype >= 540) { nブロック[t_].a -= 500; }
                    }
                }//300
            }//ブロック
        }

        static void DrawBlock()
        {
            //ブロック描画
            for (int t_ = 0; t_ < nブロックmax; t_++)
            {
                xx_0 = nブロック[t_].a - fx; xx_1 = nブロック[t_].b - fy;
                xx_2 = 32; xx_3 = xx_2;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= n画面幅)
                {

                    xx_9 = 0;
                    if (nステージ色 == 2) { xx_9 = 30; }
                    if (nステージ色 == 4) { xx_9 = 60; }
                    if (nステージ色 == 5) { xx_9 = 90; }

                    if (nブロック[t_].type < 100)
                    {
                        xx_6 = nブロック[t_].type + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100, xx_1 / 100);
                    }

                    if (nブロック[t_].xtype != 10)
                    {

                        if (nブロック[t_].type == 100 || nブロック[t_].type == 101 || nブロック[t_].type == 102 || nブロック[t_].type == 103 || nブロック[t_].type == 104 && nブロック[t_].xtype == 1 || nブロック[t_].type == 114 && nブロック[t_].xtype == 1 || nブロック[t_].type == 116)
                        {
                            xx_6 = 2 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (nブロック[t_].type == 112 || nブロック[t_].type == 104 && nブロック[t_].xtype == 0 || nブロック[t_].type == 115 && nブロック[t_].xtype == 1)
                        {
                            xx_6 = 1 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (nブロック[t_].type == 111 || nブロック[t_].type == 113 || nブロック[t_].type == 115 && nブロック[t_].xtype == 0 || nブロック[t_].type == 124)
                        {
                            xx_6 = 3 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                    }

                    if (nブロック[t_].type == 117 && nブロック[t_].xtype == 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像[4, 5], xx_0 / 100, xx_1 / 100);
                    }

                    if (nブロック[t_].type == 117 && nブロック[t_].xtype >= 3)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像[3, 5], xx_0 / 100, xx_1 / 100);
                    }

                    if (nブロック[t_].type == 115 && nブロック[t_].xtype == 3)
                    {
                        xx_6 = 1 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像[xx_6, 1], xx_0 / 100, xx_1 / 100);
                    }

                    //ジャンプ台
                    if (nブロック[t_].type == 120 && nブロック[t_].xtype != 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像[16, 1], xx_0 / 100 + 3, xx_1 / 100 + 2);
                    }

                    //ON-OFF
                    if (nブロック[t_].type == 130) DXDraw.DrawGraph(Res.n切り取り画像[10, 5], xx_0 / 100, xx_1 / 100);
                    if (nブロック[t_].type == 131) DXDraw.DrawGraph(Res.n切り取り画像[11, 5], xx_0 / 100, xx_1 / 100);

                    if (nブロック[t_].type == 140) DXDraw.DrawGraph(Res.n切り取り画像[12, 5], xx_0 / 100, xx_1 / 100);
                    if (nブロック[t_].type == 141) DXDraw.DrawGraph(Res.n切り取り画像[13, 5], xx_0 / 100, xx_1 / 100);
                    if (nブロック[t_].type == 142) DXDraw.DrawGraph(Res.n切り取り画像[14, 5], xx_0 / 100, xx_1 / 100);


                    if (nブロック[t_].type == 300 || nブロック[t_].type == 301)
                        DXDraw.DrawGraph(Res.n切り取り画像[1, 5], xx_0 / 100, xx_1 / 100);

                    //Pスイッチ
                    if (nブロック[t_].type == 400) { DXDraw.DrawGraph(Res.n切り取り画像[2, 5], xx_0 / 100, xx_1 / 100); }

                    //コイン
                    if (nブロック[t_].type == 800) { DXDraw.DrawGraph(Res.n切り取り画像[0, 2], xx_0 / 100 + 2, xx_1 / 100 + 1); }

                }
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        static void Stage()
        {
            //1-1
            if (nステージa == 1 && nステージb == 1 && nステージc == 0)
            {
                var stagedatex = MapList.stagedatex1;

                //追加情報
                tyobi(8 * 29, 9 * 29 - 12, 100);
                nブロック[nブロックco].xtype = 2;

                tyobi(13 * 29, 9 * 29 - 12, 102);
                nブロック[nブロックco].xtype = 0;

                tyobi(14 * 29, 5 * 29 - 12, 101);

                tyobi(35 * 29, 8 * 29 - 12, 110);

                tyobi(47 * 29, 9 * 29 - 12, 103);

                tyobi(59 * 29, 9 * 29 - 12, 112);

                tyobi(67 * 29, 9 * 29 - 12, 104);


                n地面co = 0;
                int t_ = n地面co;
                n地面[t_].a = 20 * 29 * 100 + 500;
                n地面[t_].b = -6000;
                n地面[t_].c = 5000;
                n地面[t_].d = 70000;
                n地面[t_].type = 100;
                n地面co++;
                
                t_ = n地面co;
                n地面[t_].a = 54 * 29 * 100 - 500;
                n地面[t_].b = -6000;
                n地面[t_].c = 7000;
                n地面[t_].d = 70000;
                n地面[t_].type = 101;
                n地面co++;

                t_ = n地面co;
                n地面[t_].a = 112 * 29 * 100 + 1000;
                n地面[t_].b = -6000;
                n地面[t_].c = 3000;
                n地面[t_].d = 70000;
                n地面[t_].type = 102;
                n地面co++;

                t_ = n地面co;
                n地面[t_].a = 117 * 29 * 100;
                n地面[t_].b = (2 * 29 - 12) * 100 - 1500;
                n地面[t_].c = 15000;
                n地面[t_].d = 3000;
                n地面[t_].type = 103;
                n地面co++;

                t_ = n地面co;
                n地面[t_].a = 125 * 29 * 100;
                n地面[t_].b = -6000;
                n地面[t_].c = 9000;
                n地面[t_].d = 70000;
                n地面[t_].type = 101;
                n地面co++;

                t_ = 28;
                n地面[t_].a = 29 * 29 * 100 + 500;
                n地面[t_].b = (9 * 29 - 12) * 100;
                n地面[t_].c = 6000;
                n地面[t_].d = 12000 - 200;
                n地面[t_].type = 50;
                n地面co++;

                t_ = n地面co;
                n地面[t_].a = 49 * 29 * 100;
                n地面[t_].b = (5 * 29 - 12) * 100;
                n地面[t_].c = 9000 - 1;
                n地面[t_].d = 3000;
                n地面[t_].type = 51;
                n地面[t_].gtype = 0;
                n地面co++;

                t_ = n地面co;
                n地面[t_].a = 72 * 29 * 100;
                n地面[t_].b = (13 * 29 - 12) * 100;
                n地面[t_].c = 3000 * 5 - 1;
                n地面[t_].d = 3000;
                n地面[t_].type = 52;
                n地面co++;

                C敵出現 ct;
                ct = new C敵出現();
                ct.a = 27 * 29 * 100;
                ct.b = (9 * 29 - 12) * 100;
                ct.type = 0;
                ct.xtype = 0;
                n敵出現.Add(ct);

                ct = new C敵出現();
                ct.a = 103 * 29 * 100;
                ct.b = (5 * 29 - 12 + 10) * 100;
                ct.type = 80;
                ct.xtype = 0;
                n敵出現.Add(ct);



                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = stagedatex[i,tt_];
                    }
                }

            }//sta1


            //1-2(地上)
            if (nステージa == 1 && nステージb == 2 && nステージc == 0)
            {

                //マリ　地上　入れ
                bgmChange(Res.nオーディオ100);

                scrollX = 0 * 100;

                var stagedatex = MapList.stagedatex2;



                nブロックco = 0;
                //ヒント1
                nブロック[nブロックco].xtype = 1; tyobi(4 * 29, 9 * 29 - 12, 300);

                //毒1
                tyobi(13 * 29, 8 * 29 - 12, 114);

                //t=28;
                n地面co = 0;
                int t_ = n地面co; n地面[t_].a = 14 * 29 * 100 + 500; n地面[t_].b = (9 * 29 - 12) * 100; n地面[t_].c = 6000; n地面[t_].d = 12000 - 200; n地面[t_].type = 50; n地面[t_].xtype = 1; n地面co++;
                t_ = n地面co; n地面[t_].a = 12 * 29 * 100; n地面[t_].b = (11 * 29 - 12) * 100; n地面[t_].c = 3000; n地面[t_].d = 6000 - 200; n地面[t_].type = 40; n地面[t_].xtype = 0; n地面co++;
                t_ = n地面co; n地面[t_].a = 14 * 29 * 100 + 1000; n地面[t_].b = -6000; n地面[t_].c = 5000; n地面[t_].d = 70000; n地面[t_].type = 100; n地面[t_].xtype = 1; n地面co++;
                //ブロックもどき


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = stagedatex[i,tt_];
                    }
                }

            }//sta2


            //1-2-1(地下)
            if (nステージa == 1 && nステージb == 2 && nステージc == 1)
            {

                //マリ　地下　入れ
                bgmChange(Res.nオーディオ103);

                scrollX = 4080 * 100;
                ma = 6000; nプレイヤー.b = 3000;
                nステージ色 = 2;


                var stagedatex = MapList.stagedatex3;



                nブロックco = 0;
                nブロック[nブロックco].xtype = 2; tyobi(7 * 29, 9 * 29 - 12, 102);

                tyobi(10 * 29, 9 * 29 - 12, 101);

                nブロック[nブロックco].xtype = 2;

                tyobi(49 * 29, 9 * 29 - 12, 114);

                for (int i = 0; i >= -7; i--)
                {

                    tyobi(53 * 29, i * 29 - 12, 1);
                }

                nブロック[nブロックco].xtype = 1; tyobi(80 * 29, 5 * 29 - 12, 104);
                nブロック[nブロックco].xtype = 2; tyobi(78 * 29, 5 * 29 - 12, 102);


                n地面co = 0;
                int t_ = n地面co; n地面[t_].a = 2 * 29 * 100; n地面[t_].b = (13 * 29 - 12) * 100; n地面[t_].c = 3000 * 1 - 1; n地面[t_].d = 3000; n地面[t_].type = 52; n地面co++;
                t_ = n地面co; n地面[t_].a = 24 * 29 * 100; n地面[t_].b = (13 * 29 - 12) * 100; n地面[t_].c = 3000 * 1 - 1; n地面[t_].d = 3000; n地面[t_].type = 52; n地面co++;
                t_ = n地面co; n地面[t_].a = 43 * 29 * 100 + 500; n地面[t_].b = -6000; n地面[t_].c = 3000; n地面[t_].d = 70000; n地面[t_].type = 102; n地面[t_].xtype = 1; n地面co++;
                t_ = n地面co; n地面[t_].a = 53 * 29 * 100 + 500; n地面[t_].b = -6000; n地面[t_].c = 3000; n地面[t_].d = 70000; n地面[t_].type = 102; n地面[t_].xtype = 2; n地面co++;
                t_ = n地面co; n地面[t_].a = 129 * 29 * 100; n地面[t_].b = (7 * 29 - 12) * 100; n地面[t_].c = 3000; n地面[t_].d = 6000 - 200; n地面[t_].type = 40; n地面[t_].xtype = 2; n地面co++;
                t_ = n地面co; n地面[t_].a = 154 * 29 * 100; n地面[t_].b = 3000; n地面[t_].c = 9000; n地面[t_].d = 3000; n地面[t_].type = 102; n地面[t_].xtype = 7; n地面co++;

                //ブロックもどき

                t_ = 27; n地面[t_].a = 69 * 29 * 100; n地面[t_].b = (1 * 29 - 12) * 100; n地面[t_].c = 9000 * 2 - 1; n地面[t_].d = 3000; n地面[t_].type = 51; n地面[t_].xtype = 0; n地面[t_].gtype  = 0; n地面co++;
                t_ = 28; n地面[t_].a = 66 * 29 * 100; n地面[t_].b = (1 * 29 - 12) * 100; n地面[t_].c = 9000 - 1; n地面[t_].d = 3000; n地面[t_].type = 51; n地面[t_].xtype = 1; n地面[t_].gtype  = 0; n地面co++;
                t_ = 29; n地面[t_].a = 66 * 29 * 100; n地面[t_].b = (-2 * 29 - 12) * 100; n地面[t_].c = 9000 * 3 - 1; n地面[t_].d = 3000; n地面[t_].type = 51; n地面[t_].xtype = 2; n地面[t_].gtype  = 0; n地面co++;

                //26 ファイアー土管
                t_ = 26; n地面[t_].a = 103 * 29 * 100 - 1500; n地面[t_].b = (9 * 29 - 12) * 100 - 2000; n地面[t_].c = 3000; n地面[t_].d = 3000; n地面[t_].type = 180; n地面[t_].xtype = 0; n地面[t_].r = 0; n地面[t_].gtype  = 48; n地面co++;
                t_ = n地面co; n地面[t_].a = 102 * 29 * 100; n地面[t_].b = (9 * 29 - 12) * 100; n地面[t_].c = 6000; n地面[t_].d = 12000 - 200; n地面[t_].type = 50; n地面[t_].xtype = 2; n地面co++;
                t_ = n地面co; n地面[t_].a = 123 * 29 * 100; n地面[t_].b = (9 * 29 - 12) * 100; n地面[t_].c = 3000 * 5 - 1; n地面[t_].d = 3000 * 5; n地面[t_].type = 52; n地面[t_].xtype = 1; n地面co++;

                t_ = n地面co; n地面[t_].a = 131 * 29 * 100; n地面[t_].b = (1 * 29 - 12) * 100; n地面[t_].c = 4700; n地面[t_].d = 3000 * 8 - 700; n地面[t_].type = 1; n地面[t_].xtype = 0; n地面co++;

                //オワタゾーン
                t_ = n地面co; n地面[t_].a = 143 * 29 * 100; n地面[t_].b = (9 * 29 - 12) * 100; n地面[t_].c = 6000; n地面[t_].d = 12000 - 200; n地面[t_].type = 50; n地面[t_].xtype = 5; n地面co++;
                t_ = n地面co; n地面[t_].a = 148 * 29 * 100; n地面[t_].b = (9 * 29 - 12) * 100; n地面[t_].c = 6000; n地面[t_].d = 12000 - 200; n地面[t_].type = 50; n地面[t_].xtype = 5; n地面co++;
                t_ = n地面co; n地面[t_].a = 153 * 29 * 100; n地面[t_].b = (9 * 29 - 12) * 100; n地面[t_].c = 6000; n地面[t_].d = 12000 - 200; n地面[t_].type = 50; n地面[t_].xtype = 5; n地面co++;



                C敵出現 ct;

                ct = new C敵出現();
                ct.a = 18 * 29 * 100;
                ct.b = (10 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);

                ct = new C敵出現();
                ct.a = 51 * 29 * 100 + 1000;
                ct.b = (2 * 29 - 12 + 10) * 100;
                ct.type = 80;
                ct.xtype = 1;
                n敵出現.Add(ct);

                //？ボール
                ct = new C敵出現();
                ct.a = 96 * 29 * 100 + 100;
                ct.b = (10 * 29 - 12) * 100;
                ct.type = 105;
                ct.xtype = 0;
                n敵出現.Add(ct);


                //リフト
                Cリフト cl;

                cl = new Cリフト();
                cl.a = 111 * 29 * 100;
                cl.b = (8 * 29 - 12) * 100;
                cl.c = 90 * 100;
                cl.type = 0;
                cl.acttype = 5;
                cl.e = -300;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 111 * 29 * 100;
                cl.b = (0 * 29 - 12) * 100;
                cl.c = 90 * 100;
                cl.type = 0;
                cl.acttype = 5;
                cl.e = -300;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 116 * 29 * 100;
                cl.b = (4 * 29 - 12) * 100;
                cl.c = 90 * 100;
                cl.type = 1;
                cl.acttype = 5;
                cl.e = 300;
                cl.b落ちる = true;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 116 * 29 * 100;
                cl.b = (12 * 29 - 12) * 100;
                cl.c = 90 * 100;
                cl.type = 1;
                cl.acttype = 5;
                cl.e = 300;
                cl.b落ちる = true;
                nリフト.Add(cl);



                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = stagedatex[i,tt_];
                    }
                }

            }//sta1-2-1

            //1-2(地上)
            if (nステージa == 1 && nステージb == 2 && nステージc == 2)
            {

                //マリ　地上　入れ
                bgmChange(Res.nオーディオ100);

                scrollX = 900 * 100;
                ma = 7500; nプレイヤー.b = 3000 * 9;

                var stagedatex = MapList.stagedatex4;

                int t_ = n地面co; n地面[t_].a = 5 * 29 * 100 + 500; n地面[t_].b = -6000; n地面[t_].c = 3000; n地面[t_].d = 70000; n地面[t_].type = 102; n地面[t_].xtype = 8; n地面co++;
                //空飛ぶ土管
                t_ = 28; n地面[t_].a = 44 * 29 * 100 + 500; n地面[t_].b = (10 * 29 - 12) * 100; n地面[t_].c = 6000; n地面[t_].d = 9000 - 200; n地面[t_].type = 50; n地面co++;

                //ポールもどき
                C敵出現 ct;

                ct = new C敵出現();
                ct.a = 19 * 29 * 100;
                ct.b = (2 * 29 - 12) * 100;
                ct.type = 85;
                ct.xtype = 0;
                n敵出現.Add(ct);

                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = stagedatex[i,tt_];
                    }
                }

            }//sta2



            //必要BGM+SE

            //1-3(地上)
            if (nステージa == 1 && nステージb == 3 && nステージc == 6) { nステージc = 0; }
            if (nステージa == 1 && nステージb == 3 && nステージc == 0)
            {
                int t_;

                bgmChange(Res.nオーディオ100);

                scrollX = 3900 * 100;
                //ma=3000;mb=3000;

                var stagedatex = MapList.stagedatex5;

                nブロックco = 0;

                tyobi(22 * 29, 3 * 29 - 12, 1);
                //毒1
                tyobi(54 * 29, 9 * 29 - 12, 116);
                //音符+
                tyobi(18 * 29, 14 * 29 - 12, 117);

                tyobi(19 * 29, 14 * 29 - 12, 117);

                tyobi(20 * 29, 14 * 29 - 12, 117);
                nブロック[nブロックco].xtype = 1; tyobi(61 * 29, 9 * 29 - 12, 101);//5

                tyobi(74 * 29, 9 * 29 - 12, 7);//6

                //ヒント2
                nブロック[nブロックco].xtype = 2; tyobi(28 * 29, 9 * 29 - 12, 300);//7
                                                                  //ファイア
                nブロック[nブロックco].xtype = 3; tyobi(7 * 29, 9 * 29 - 12, 101);
                //ヒント3
                nブロック[nブロックco].xtype = 4; tyobi(70 * 29, 8 * 29 - 12, 300);//9

                //もろいぶろっく×３
                nブロック[nブロックco].xtype = 1; tyobi(58 * 29, 13 * 29 - 12, 115);
                nブロック[nブロックco].xtype = 1; tyobi(59 * 29, 13 * 29 - 12, 115);
                nブロック[nブロックco].xtype = 1; tyobi(60 * 29, 13 * 29 - 12, 115);

                //ヒントブレイク
                nブロック[nブロックco].xtype = 0; tyobi(111 * 29, 6 * 29 - 12, 301);
                //ジャンプ
                nブロック[nブロックco].xtype = 0; tyobi(114 * 29, 9 * 29 - 12, 120);

                //ファイア
                C敵出現 ct;

                ct = new C敵出現();
                ct.a = 101 * 29 * 100;
                ct.b = (5 * 29 - 12) * 100;
                ct.type = 4;
                ct.xtype = 1;
                n敵出現.Add(ct);


                ct = new C敵出現();
                ct.a = 146 * 29 * 100;
                ct.b = (10 * 29 - 12) * 100;
                ct.type = 6;
                ct.xtype = 1;
                n敵出現.Add(ct);

                t_ = n地面co; n地面[t_].a = 9 * 29 * 100; n地面[t_].b = (13 * 29 - 12) * 100; n地面[t_].c = 9000 - 1; n地面[t_].d = 3000; n地面[t_].type = 52; n地面co++;

                //土管
                t_ = n地面co; n地面[t_].a = 65 * 29 * 100 + 500; n地面[t_].b = (10 * 29 - 12) * 100; n地面[t_].c = 6000; n地面[t_].d = 9000 - 200; n地面[t_].type = 50; n地面[t_].xtype = 1; n地面co++;

                //トラップ
                t_ = n地面co; n地面[t_].a = 74 * 29 * 100; n地面[t_].b = (8 * 29 - 12) * 100 - 1500; n地面[t_].c = 6000; n地面[t_].d = 3000; n地面[t_].type = 103; n地面[t_].xtype = 1; n地面co++;
                t_ = n地面co; n地面[t_].a = 96 * 29 * 100 - 3000; n地面[t_].b = -6000; n地面[t_].c = 9000; n地面[t_].d = 70000; n地面[t_].type = 102; n地面[t_].xtype = 10; n地面co++;
                //ポール砲
                t_ = n地面co; n地面[t_].a = 131 * 29 * 100 - 1500; n地面[t_].b = (1 * 29 - 12) * 100 - 3000; n地面[t_].c = 15000; n地面[t_].d = 14000; n地面[t_].type = 104; n地面co++;


                //？ボール
                ct = new C敵出現();
                ct.a = 10 * 29 * 100 + 100;
                ct.b = (11 * 29 - 12) * 100;
                ct.type = 105; ct.xtype = 1;
                n敵出現.Add(ct);

                //ブロックもどき
                ct = new C敵出現();
                ct.a = 43 * 29 * 100;
                ct.b = (11 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);

                //うめぇ
                ct = new C敵出現();
                ct.a = 1 * 29 * 100;
                ct.b = (2 * 29 - 12 + 10) * 100 - 1000;
                ct.type = 80;
                ct.xtype = 0;
                n敵出現.Add(ct);


                //リフト
                Cリフト cl;

                cl = new Cリフト();
                cl.a = 33 * 29 * 100;
                cl.b = (3 * 29 - 12) * 100;
                cl.c = 90 * 100;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 1;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 39 * 29 * 100 - 2000;
                cl.b = (6 * 29 - 12) * 100;
                cl.c = 90 * 100; cl.type = 0;
                cl.acttype = 1;
                cl.e = 0;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 45 * 29 * 100 + 1500;
                cl.b = (10 * 29 - 12) * 100;
                cl.c = 90 * 100; cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 2;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 95 * 29 * 100;
                cl.b = (7 * 29 - 12) * 100;
                cl.c = 180 * 100;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 10;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 104 * 29 * 100;
                cl.b = (9 * 29 - 12) * 100;
                cl.c = 90 * 100;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 12;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 117 * 29 * 100;
                cl.b = (3 * 29 - 12) * 100;
                cl.c = 90 * 100;
                cl.type = 0;
                cl.acttype = 1;
                cl.e = 0;
                cl.sp = 15;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 124 * 29 * 100;
                cl.b = (5 * 29 - 12) * 100;
                cl.c = 210 * 100;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 10;
                nリフト.Add(cl);



                if (stagepoint) { stagepoint = false; ma = 4500; nプレイヤー.b = -3000; n中間フラグ = 0; }


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = stagedatex[i,tt_];
                    }
                }

            }//sta3



            //1-3(地下)
            if (nステージa == 1 && nステージb == 3 && nステージc == 1)
            {

                //マリ　地上　入れ
                bgmChange(Res.nオーディオ103);

                scrollX = 0 * 100;
                ma = 6000; nプレイヤー.b = 6000;
                nステージ色 = 2;


                var stagedatex = MapList.stagedatex6;


                nブロックco = 0;

                nステージc = 0;


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }

            }//sta3



            //1-3(空中)
            if (nステージa == 1 && nステージb == 3 && nステージc == 5)
            {

                nステージ色 = 3;

                bgmChange(Res.nオーディオ104);

                scrollX = 0 * 100;
                ma = 3000; nプレイヤー.b = 33000;

                stagepoint = true;

                var stagedatex = MapList.stagedatex7;

                n地面co = 0;
                int t_ = n地面co; n地面[t_].a = 14 * 29 * 100 - 5; n地面[t_].b = (11 * 29 - 12) * 100; n地面[t_].c = 6000; n地面[t_].d = 15000 - 200; n地面[t_].type = 50; n地面[t_].xtype = 1; n地面co++;


                nブロック[nブロックco].xtype = 0; tyobi(12 * 29, 4 * 29 - 12, 112);
                //ヒント3
                nブロック[nブロックco].xtype = 3; tyobi(12 * 29, 8 * 29 - 12, 300);

                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = stagedatex[i,tt_];
                    }
                }

            }//sta5

            //1-4(地下)
            if (nステージa == 1 && nステージb == 4 && nステージc == 0)
            {

                //マリ　地上　入れ
                bgmChange(Res.nオーディオ105);

                scrollX = 4400 * 100;
                ma = 12000; nプレイヤー.b = 6000;
                nステージ色 = 4;


                var stagedatex = MapList.stagedatex8;

                n地面co = 0;//sco=140;
                int t_ = n地面co; n地面[t_].a = 35 * 29 * 100 - 1500 + 750; n地面[t_].b = (8 * 29 - 12) * 100 - 1500; n地面[t_].c = 1500; n地面[t_].d = 3000; n地面[t_].type = 105; n地面co++;
                t_ = n地面co; n地面[t_].a = 67 * 29 * 100; n地面[t_].b = (4 * 29 - 12) * 100; n地面[t_].c = 9000 - 1; n地面[t_].d = 3000 * 1 - 1; n地面[t_].type = 51; n地面[t_].xtype = 3; n地面[t_].gtype  = 0; n地面co++;
                t_ = n地面co; n地面[t_].a = 73 * 29 * 100; n地面[t_].b = (13 * 29 - 12) * 100; n地面[t_].c = 3000 * 1 - 1; n地面[t_].d = 3000; n地面[t_].type = 52; n地面co++;
                t_ = n地面co; n地面[t_].a = 123 * 29 * 100; n地面[t_].b = (1 * 29 - 12) * 100; n地面[t_].c = 30 * 6 * 100 - 1 + 0; n地面[t_].d = 3000 - 200; n地面[t_].type = 51; n地面[t_].xtype = 10; n地面co++;
                //スクロール消し
                t_ = n地面co; n地面[t_].a = 124 * 29 * 100 + 3000; n地面[t_].b = (2 * 29 - 12) * 100; n地面[t_].c = 3000 * 1 - 1; n地面[t_].d = 300000; n地面[t_].type = 102; n地面[t_].xtype = 20; n地面co++;
                t_ = n地面co; n地面[t_].a = 148 * 29 * 100 + 1000; n地面[t_].b = (-12 * 29 - 12) * 100; n地面[t_].c = 3000 * 1 - 1; n地面[t_].d = 300000; n地面[t_].type = 102; n地面[t_].xtype = 30; n地面co++;

                //3連星
                t_ = n地面co; n地面[t_].a = 100 * 29 * 100 + 1000; n地面[t_].b = -6000; n地面[t_].c = 3000; n地面[t_].d = 70000; n地面[t_].type = 102; n地面[t_].xtype = 12; n地面co++;

                //地面1
                t_ = n地面co; n地面[t_].a = 0 * 29 * 100 - 0; n地面[t_].b = 9 * 29 * 100 + 1700; n地面[t_].c = 3000 * 7 - 1; n地面[t_].d = 3000 * 5 - 1; n地面[t_].type = 200; n地面[t_].xtype = 0; n地面co++;
                t_ = n地面co; n地面[t_].a = 11 * 29 * 100; n地面[t_].b = -1 * 29 * 100 + 1700; n地面[t_].c = 3000 * 8 - 1; n地面[t_].d = 3000 * 4 - 1; n地面[t_].type = 200; n地面[t_].xtype = 0; n地面co++;


                C敵出現 ct;

                ct = new C敵出現();
                ct.a = 8 * 29 * 100 - 1400;
                ct.b = (2 * 29 - 12) * 100 + 500;
                ct.type = 86;
                ct.xtype = 0;
                n敵出現.Add(ct);

                ct = new C敵出現();
                ct.a = 42 * 29 * 100 - 1400;
                ct.b = (-2 * 29 - 12) * 100 + 500;
                ct.type = 86;
                ct.xtype = 0;
                n敵出現.Add(ct);

                ct = new C敵出現();
                ct.a = 29 * 29 * 100 + 1500;
                ct.b = (7 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 105;
                n敵出現.Add(ct);

                ct = new C敵出現();
                ct.a = 47 * 29 * 100 + 1500;
                ct.b = (9 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 110;
                n敵出現.Add(ct);

                ct = new C敵出現();
                ct.a = 70 * 29 * 100 + 1500;
                ct.b = (9 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 105;
                n敵出現.Add(ct);

                ct = new C敵出現();
                ct.a = 66 * 29 * 100 + 1501;
                ct.b = (4 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 101;
                n敵出現.Add(ct);

                ct = new C敵出現();
                ct.a = 85 * 29 * 100 + 1501;
                ct.b = (4 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 105;
                n敵出現.Add(ct);

                //ステルスうめぇ
                ct = new C敵出現();
                ct.a = 57 * 29 * 100;
                ct.b = (2 * 29 - 12 + 10) * 100 - 500;
                ct.type = 80;
                ct.xtype = 1;
                n敵出現.Add(ct);

                //ブロックもどき
                ct = new C敵出現();
                ct.a = 77 * 29 * 100;
                ct.b = (5 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 2;
                n敵出現.Add(ct);

                //ボス
                ct = new C敵出現();
                ct.a = 130 * 29 * 100;
                ct.b = (8 * 29 - 12) * 100;
                ct.type = 30;
                ct.xtype = 0;
                n敵出現.Add(ct);

                //クックル
                ct = new C敵出現();
                ct.a = 142 * 29 * 100;
                ct.b = (10 * 29 - 12) * 100;
                ct.type = 31;
                ct.xtype = 0;
                n敵出現.Add(ct);

                //マグマ
                C背景 cb;

                cb = new C背景();
                cb.a = 7 * 29 * 100 - 300;
                cb.b = 14 * 29 * 100 - 1200;
                cb.type = 6;
                n背景.Add(cb);

                cb = new C背景();
                cb.a = 41 * 29 * 100 - 300;
                cb.b = 14 * 29 * 100 - 1200;
                cb.type = 6;
                n背景.Add(cb);

                cb = new C背景();
                cb.a = 149 * 29 * 100 - 1100;
                cb.b = 10 * 29 * 100 - 600;
                cb.type = 100;
                n背景.Add(cb);


                nブロックco = 0;
                //ON-OFFブロック
                nブロック[nブロックco].xtype = 1; tyobi(29 * 29, 3 * 29 - 12, 130);
                //1-2
                tyobi(34 * 29, 9 * 29 - 12, 5);

                tyobi(35 * 29, 9 * 29 - 12, 5);
                //隠し
                tyobi(55 * 29 + 15, 6 * 29 - 12, 7);
                //隠しON-OFF
                nブロック[nブロックco].xtype = 10; tyobi(50 * 29, 9 * 29 - 12, 114);
                //ヒント3
                nブロック[nブロックco].xtype = 5; tyobi(1 * 29, 5 * 29 - 12, 300);
                //ファイア
                nブロック[nブロックco].xtype = 3;

                tyobi(86 * 29, 9 * 29 - 12, 101);
                //キノコなし　普通
                //音符
                nブロック[nブロックco].xtype = 2;

                tyobi(86 * 29, 6 * 29 - 12, 117);

                //もろいぶろっく×３
                for (int i = 0; i <= 2; i++)
                {
                    nブロック[nブロックco].xtype = 3; tyobi((79 + i) * 29, 13 * 29 - 12, 115);
                }

                //ジャンプ
                nブロック[nブロックco].xtype = 3; tyobi(105 * 29, 11 * 29 - 12, 120);
                //毒1
                nブロック[nブロックco].xtype = 3; tyobi(109 * 29, 7 * 29 - 12, 102);
                //デフラグ
                nブロック[nブロックco].xtype = 4; tyobi(111 * 29, 7 * 29 - 12, 101);
                //剣
                tyobi(132 * 29, 8 * 29 - 12 - 3, 140);

                tyobi(131 * 29, 9 * 29 - 12, 141);
                //メロン
                tyobi(161 * 29, 12 * 29 - 12, 142);
                //ファイアバー強化
                tyobi(66 * 29, 4 * 29 - 12, 124);


                //リフト
                Cリフト cl;

                cl = new Cリフト();
                cl.a = 93 * 29 * 100;
                cl.b = (10 * 29 - 12) * 100;
                cl.c = 60 * 100; cl.type = 0;
                cl.acttype = 1;
                cl.e = 0;
                nリフト.Add(cl);

                cl = new Cリフト();
                cl.a = 119 * 29 * 100 + 300;
                cl.b = (10 * 29 - 12) * 100;
                cl.c = 12 * 30 * 100 + 1000;
                cl.type = 0;
                cl.acttype = 0;
                cl.sp = 21;
                cl.e = 0;
                nリフト.Add(cl);


                nステージc = 0;


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }

            }//sta4

            if (nステージa == 2 && nステージb == 1 && nステージc == 0)
            {// 2-1
                ma = 5600;
                nプレイヤー.b = 32000;

                bgmChange(Res.nオーディオ100);
                nステージ色 = 1;
                scrollX = 2900 * (113 - 19);
                //
                var stagedatex = MapList.stagedatex9;
                //追加情報
                nブロックco = 0;
                //
                nブロック[nブロックco].xtype = 6;

                tyobi(1 * 29, 9 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(40 * 29, 9 * 29 - 12, 110);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 7;

                tyobi(79 * 29, 7 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 2;

                tyobi(83 * 29, 7 * 29 - 12, 102);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(83 * 29, 2 * 29 - 12, 114);
                nブロックco += 1;
                //
                for (int i = -1; i > -7; i -= 1)
                {

                    tyobi(85 * 29, i * 29 - 12, 4);
                    nブロックco += 1;
                }
                //
                n地面co = 0;
                n地面[n地面co].a = 30 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 12000 - 1;
                n地面[n地面co].d = 3000;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 51 * 29 * 100;
                n地面[n地面co].b = (4 * 29 - 12) * 100;
                n地面[n地面co].c = 9000 - 1;
                n地面[n地面co].d = 3000;
                n地面[n地面co].type = 51;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 84 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 9000 - 1;
                n地面[n地面co].d = 3000;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 105 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 15000 - 1;
                n地面[n地面co].d = 3000;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                C敵出現 ct;
                //
                ct = new C敵出現();
                ct.a = 6 * 29 * 100;
                ct.b = (3 * 29 - 12) * 100;
                ct.type = 80;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 13 * 29 * 100;
                ct.b = (6 * 29 - 12) * 100;
                ct.type = 4;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 23 * 29 * 100;
                ct.b = (7 * 29 - 12) * 100;
                ct.type = 80;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 25 * 29 * 100;
                ct.b = (7 * 29 - 12) * 100;
                ct.type = 80;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 27 * 29 * 100;
                ct.b = (7 * 29 - 12) * 100;
                ct.type = 80;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 88 * 29 * 100;
                ct.b = (12 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 2 && nステージc == 0)
            {//2-2(地上)

                bgmChange(Res.nオーディオ100);
                nステージ色 = 1;
                scrollX = 2900 * (19 - 19);
                //
                var stagedatex = MapList.stagedatex10;
                //
                n地面[n地面co].a = 14 * 29 * 100 + 200;
                n地面[n地面co].b = -6000;
                n地面[n地面co].c = 5000;
                n地面[n地面co].d = 70000;
                n地面[n地面co].type = 100;
                n地面co += 1;
                //
                n地面[n地面co].a = 12 * 29 * 100 + 1200;
                n地面[n地面co].b = -6000;
                n地面[n地面co].c = 7000;
                n地面[n地面co].d = 70000;
                n地面[n地面co].type = 101;
                n地面co += 1;
                //
                n地面[n地面co].a = 12 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 6000 - 1;
                n地面[n地面co].d = 3000;
                n地面[n地面co].type = 52;
                n地面[n地面co].gtype  = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 14 * 29 * 100;
                n地面[n地面co].b = (9 * 29 - 12) * 100;
                n地面[n地面co].c = 6000;
                n地面[n地面co].d = 12000 - 200;
                n地面[n地面co].type = 50;
                n地面[n地面co].xtype = 1;
                n地面co += 1;
                //
                tyobi(6 * 29, 9 * 29 - 12, 110);
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 2 && nステージc == 1)
            {//2-2(地下)

                bgmChange(Res.nオーディオ103);
                nステージ色 = 2;
                ma = 7500; nプレイヤー.b = 9000;
                scrollX = 2900 * (137 - 19);
                //
                var stagedatex = MapList.stagedatex11;
                //
                C敵出現 ct;
                //
                ct = new C敵出現();
                ct.a = 32 * 29 * 100 - 1400;
                ct.b = (-2 * 29 - 12) * 100 + 500;
                ct.type = 86;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = (31 * 29 - 12) * 100;
                ct.b = (7 * 29 - 12) * 100;
                ct.type = 7;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 38 * 29 * 100 + 1500;
                ct.b = (6 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 107;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 38 * 29 * 100 + 1500;
                ct.b = (6 * 29 - 12) * 100 + 1500;
                ct.type = 88;
                ct.xtype = 107;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 42 * 29 * 100 + 1500;
                ct.b = (6 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 107;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 42 * 29 * 100 + 1500;
                ct.b = (6 * 29 - 12) * 100 + 1500;
                ct.type = 88;
                ct.xtype = 107;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 46 * 29 * 100 + 1500;
                ct.b = (6 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 107;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 46 * 29 * 100 + 1500;
                ct.b = (6 * 29 - 12) * 100 + 1500;
                ct.type = 88;
                ct.xtype = 107;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 58 * 29 * 100;
                ct.b = (7 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 66 * 29 * 100;
                ct.b = (7 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 76 * 29 * 100 - 1400;
                ct.b = (-2 * 29 - 12) * 100 + 500;
                ct.type = 86;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                n地面co = 0;
                n地面[n地面co].a = 2 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 300000 - 6001;
                n地面[n地面co].d = 3000;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 3 * 29 * 100;
                n地面[n地面co].b = (7 * 29 - 12) * 100;
                n地面[n地面co].c = 3000;
                n地面[n地面co].d = 3000;
                n地面[n地面co].type = 105;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 107 * 29 * 100;
                n地面[n地面co].b = (9 * 29 - 12) * 100;
                n地面[n地面co].c = 9000 - 1;
                n地面[n地面co].d = 24000;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 1;
                n地面co += 1;
                //
                n地面[n地面co].a = 111 * 29 * 100;
                n地面[n地面co].b = (7 * 29 - 12) * 100;
                n地面[n地面co].c = 3000;
                n地面[n地面co].d = 6000 - 200;
                n地面[n地面co].type = 40;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 113 * 29 * 100 + 1100;
                n地面[n地面co].b = (0 * 29 - 12) * 100;
                n地面[n地面co].c = 4700;
                n地面[n地面co].d = 27000 - 1000;
                n地面[n地面co].type = 0;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 128 * 29 * 100;
                n地面[n地面co].b = (9 * 29 - 12) * 100;
                n地面[n地面co].c = 9000 - 1;
                n地面[n地面co].d = 24000;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 1;
                n地面co += 1;
                //
                n地面[n地面co].a = 131 * 29 * 100;
                n地面[n地面co].b = (9 * 29 - 12) * 100;
                n地面[n地面co].c = 3000;
                n地面[n地面co].d = 6000 - 200;
                n地面[n地面co].type = 40;
                n地面[n地面co].xtype = 2;
                n地面co += 1;
                //
                n地面[n地面co].a = 133 * 29 * 100 + 1100;
                n地面[n地面co].b = (0 * 29 - 12) * 100;
                n地面[n地面co].c = 4700;
                n地面[n地面co].d = 32000;
                n地面[n地面co].type = 0;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                nブロックco = 0;
                nブロック[nブロックco].xtype = 0;

                tyobi(0 * 29, 0 * 29 - 12, 4);
                nブロックco = 1;
                nブロック[nブロックco].xtype = 0;

                tyobi(2 * 29, 9 * 29 - 12, 4);
                nブロックco = 2;
                nブロック[nブロックco].xtype = 0;

                tyobi(3 * 29, 9 * 29 - 12, 4);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(5 * 29, 9 * 29 - 12, 115);
                nブロックco += 1;
                nブロック[nブロックco].xtype = 1;

                tyobi(6 * 29, 9 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(5 * 29, 10 * 29 - 12, 115);
                nブロックco += 1;
                nブロック[nブロックco].xtype = 1;

                tyobi(6 * 29, 10 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(5 * 29, 11 * 29 - 12, 115);
                nブロックco += 1;
                nブロック[nブロックco].xtype = 1;

                tyobi(6 * 29, 11 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(5 * 29, 12 * 29 - 12, 115);
                nブロックco += 1;
                nブロック[nブロックco].xtype = 1;

                tyobi(6 * 29, 12 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(70 * 29, 7 * 29 - 12, 115);
                nブロックco += 1;
                nブロック[nブロックco].xtype = 1;

                tyobi(71 * 29, 7 * 29 - 12, 115);
                nブロックco += 1;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 2 && nステージc == 2)
            {// 2-2 地上
             //
                bgmChange(Res.nオーディオ100);
                nステージ色 = 1;
                scrollX = 2900 * (36 - 19);
                ma = 7500;
                nプレイヤー.b = 3000 * 9;
                //
                var stagedatex = MapList.stagedatex12;
                //
                C敵出現 ct;
                //
                ct = new C敵出現();
                ct.a = 9 * 29 * 100;
                ct.b = (12 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 10 * 29 * 100;
                ct.b = (11 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 11 * 29 * 100;
                ct.b = (10 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 12 * 29 * 100;
                ct.b = (9 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 13 * 29 * 100;
                ct.b = (8 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 14 * 29 * 100;
                ct.b = (7 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 15 * 29 * 100;
                ct.b = (6 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 16 * 29 * 100;
                ct.b = (5 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 17 * 29 * 100;
                ct.b = (5 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 18 * 29 * 100;
                ct.b = (5 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 19 * 29 * 100;
                ct.b = (5 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 20 * 29 * 100;
                ct.b = (5 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }
            }
            //
            if (nステージa == 2 && nステージb == 3 && nステージc == 0)
            {// 2-3
                ma = 7500;
                nプレイヤー.b = 3000 * 8;

                bgmChange(Res.nオーディオ100);
                nステージ色 = 1;
                scrollX = 2900 * (126 - 19);
                //
                var stagedatex = MapList.stagedatex13;
                //
                nブロックco = 0;
                nブロック[nブロックco].xtype = 0;
                for (int i = -1; i > -7; i -= 1)
                {

                    tyobi(55 * 29, i * 29 - 12, 4);
                    nブロックco += 1;
                }
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(64 * 29, 12 * 29 - 12, 120);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(66 * 29, 3 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(67 * 29, 3 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(68 * 29, 3 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 8;

                tyobi(60 * 29, 6 * 29 - 12, 300);
                nブロックco += 1;
                //
                C敵出現 ct = new C敵出現();
                ct.a = (54 * 29 - 12) * 100;
                ct.b = (1 * 29 - 12) * 100;
                ct.type = 80;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                n地面co = 0;
                n敵出現[n地面co].a = (102 * 29 - 12) * 100;
                n敵出現[n地面co].b = (10 * 29 - 12) * 100;
                n敵出現[n地面co].type = 50;
                n敵出現[n地面co].xtype = 1;
                n地面co += 1;
                //
                Cリフト cl;
                //
                cl = new Cリフト();
                cl.a = 1 * 29 * 100;
                cl.b = (10 * 29 - 12) * 100;
                cl.c = 5 * 3000;
                cl.type = 0;
                cl.acttype = 1;
                cl.e = 0;
                cl.sp = 10;
                nリフト.Add(cl);
                //
                cl = new Cリフト();
                cl.a = 18 * 29 * 100;
                cl.b = (4 * 29 - 12) * 100;
                cl.c = 3 * 3000;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 10;
                nリフト.Add(cl);
                //
                cl = new Cリフト();
                cl.a = 35 * 29 * 100;
                cl.b = (4 * 29 - 12) * 100;
                cl.c = 5 * 3000;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 10;
                nリフト.Add(cl);
                //
                cl = new Cリフト();
                cl.a = 35 * 29 * 100;
                cl.b = (8 * 29 - 12) * 100;
                cl.c = 5 * 3000;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 10;
                nリフト.Add(cl);
                //
                cl = new Cリフト();
                cl.a = 94 * 29 * 100;
                cl.b = (6 * 29 - 12) * 100;
                cl.c = 3 * 3000;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 1;
                nリフト.Add(cl);
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }
            }
            //
            if (nステージa == 2 && nステージb == 4 && (nステージc == 0 || nステージc == 10 || nステージc == 12))
            {// 2-4(1番)
                if (nステージc == 0)
                {
                    ma = 7500;
                    nプレイヤー.b = 3000 * 4;
                }
                else {
                    ma = 19500;
                    nプレイヤー.b = 3000 * 11;
                    nステージc = 0;
                }

                bgmChange(Res.nオーディオ105);
                nステージ色 = 4;
                scrollX = 2900 * (40 - 19);
                //
                var stagedatex = MapList.stagedatex14;
                //
                nブロックco = 0;
                nブロック[nブロックco].xtype = 0;

                tyobi(0 * 29, -1 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(4 * 29, -1 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(1 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(6 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(7 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                C敵出現 ct;
                //
                ct = new C敵出現();
                ct.a = 2 * 29 * 100 - 1400;
                ct.b = (-2 * 29 - 12) * 100 + 500;
                ct.type = 86;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 20 * 29 * 100 + 1500;
                ct.b = (5 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 107;
                n敵出現.Add(ct);
                //
                n地面co = 0;
                n地面[n地面co].a = 17 * 29 * 100;
                n地面[n地面co].b = (9 * 29 - 12) * 100;
                n地面[n地面co].c = 21000 - 1;
                n地面[n地面co].d = 3000 - 1;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 2;
                n地面co += 1;
                //
                n地面[n地面co].a = 27 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 6000;
                n地面[n地面co].d = 6000;
                n地面[n地面co].type = 50;
                n地面[n地面co].xtype = 6;
                n地面co += 1;
                //
                n地面[n地面co].a = 34 * 29 * 100;
                n地面[n地面co].b = (5 * 29 - 12) * 100;
                n地面[n地面co].c = 6000;
                n地面[n地面co].d = 30000;
                n地面[n地面co].type = 50;
                n地面[n地面co].xtype = 1;
                n地面co += 1;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 4 && nステージc == 1)
            {// 2-4(2番)
                ma = 4500;
                nプレイヤー.b = 3000 * 11;

                bgmChange(Res.nオーディオ105);
                nステージ色 = 4;
                scrollX = 2900 * (21 - 19);
                //
                var stagedatex = MapList.stagedatex15;
                //
                nブロックco = 0;
                nブロック[nブロックco].xtype = 1;

                tyobi(12 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(13 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(14 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                n地面co = 0;
                n地面[n地面co].a = 6 * 29 * 100;
                n地面[n地面co].b = (6 * 29 - 12) * 100;
                n地面[n地面co].c = 18000 - 1;
                n地面[n地面co].d = 6000 - 1;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 12 * 29 * 100;
                n地面[n地面co].b = (8 * 29 - 12) * 100;
                n地面[n地面co].c = 9000 - 1;
                n地面[n地面co].d = 3000 - 1;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 2;
                n地面co += 1;
                //
                n地面[n地面co].a = 15 * 29 * 100;
                n地面[n地面co].b = (11 * 29 - 12) * 100;
                n地面[n地面co].c = 3000;
                n地面[n地面co].d = 6000;
                n地面[n地面co].type = 40;
                n地面[n地面co].xtype = 2;
                n地面co += 1;
                //
                n地面[n地面co].a = 17 * 29 * 100 + 1100;
                n地面[n地面co].b = (0 * 29 - 12) * 100;
                n地面[n地面co].c = 4700;
                n地面[n地面co].d = 38000;
                n地面[n地面co].type = 0;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 4 && nステージc == 2)
            {// 2-4(3番)
                ma = 4500;
                nプレイヤー.b = 3000 * 11;

                bgmChange(Res.nオーディオ105);
                nステージ色 = 4;
                scrollX = 2900 * (128 - 19);
                //
                var stagedatex = MapList.stagedatex16;
                //
                nブロックco = 0;
                nブロック[nブロックco].xtype = 0;

                tyobi(1 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(2 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 9;

                tyobi(3 * 29, 4 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(32 * 29, 9 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(76 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(108 * 29, 11 * 29 - 12, 141);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(109 * 29, 10 * 29 - 12 - 3, 140);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 0;

                tyobi(121 * 29, 10 * 29 - 12, 142);
                nブロックco += 1;
                //
                C敵出現 ct;
                //
                ct = new C敵出現();
                ct.a = 0 * 29 * 100 + 1500;
                ct.b = (8 * 29 - 12) * 100 + 1500;
                ct.type = 88;
                ct.xtype = 105;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 2 * 29 * 100;
                ct.b = (0 * 29 - 12) * 100;
                ct.type = 80;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 3 * 29 * 100 + 1500;
                ct.b = (8 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 105;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 6 * 29 * 100 + 1500;
                ct.b = (8 * 29 - 12) * 100 + 1500;
                ct.type = 88;
                ct.xtype = 107;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 9 * 29 * 100 + 1500;
                ct.b = (8 * 29 - 12) * 100 + 1500;
                ct.type = 88;
                ct.xtype = 107;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 25 * 29 * 100 - 1400;
                ct.b = (2 * 29 - 12) * 100 - 400;
                ct.type = 86;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 40 * 29 * 100;
                ct.b = (8 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 42 * 29 * 100;
                ct.b = (8 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 43 * 29 * 100 + 1500;
                ct.b = (6 * 29 - 12) * 100 + 1500;
                ct.type = 88;
                ct.xtype = 105;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 47 * 29 * 100 + 1500;
                ct.b = (6 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 105;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 57 * 29 * 100;
                ct.b = (7 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 77 * 29 * 100 - 1400;
                ct.b = (2 * 29 - 12) * 100 - 400;
                ct.type = 86;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 83 * 29 * 100 - 1400;
                ct.b = (2 * 29 - 12) * 100 - 400;
                ct.type = 86;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 88 * 29 * 100 + 1500;
                ct.b = (9 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 105;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 88 * 29 * 100 + 1500;
                ct.b = (9 * 29 - 12) * 100 + 1500;
                ct.type = 88;
                ct.xtype = 105;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 90 * 29 * 100;
                ct.b = (9 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 107 * 29 * 100;
                ct.b = (10 * 29 - 12) * 100;
                ct.type = 30;
                ct.xtype = 0;
                n敵出現.Add(ct);
                //
                n地面co = 0;
                n地面[n地面co].a = 13 * 29 * 100;
                n地面[n地面co].b = (8 * 29 - 12) * 100;
                n地面[n地面co].c = 33000 - 1;
                n地面[n地面co].d = 3000 - 1;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 2;
                n地面co += 1;
                //
                n地面[n地面co].a = 13 * 29 * 100;
                n地面[n地面co].b = (0 * 29 - 12) * 100;
                n地面[n地面co].c = 33000 - 1;
                n地面[n地面co].d = 3000 - 1;
                n地面[n地面co].type = 51;
                n地面[n地面co].xtype = 3;
                n地面co += 1;
                //
                n地面[n地面co].a = 10 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 6000;
                n地面[n地面co].d = 6000;
                n地面[n地面co].type = 50;
                n地面[n地面co].xtype = 6;
                n地面co += 1;
                //
                n地面[n地面co].a = 46 * 29 * 100;
                n地面[n地面co].b = (12 * 29 - 12) * 100;
                n地面[n地面co].c = 9000 - 1;
                n地面[n地面co].d = 3000 - 1;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 2;
                n地面co += 1;
                //
                n地面[n地面co].a = 58 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 6000;
                n地面[n地面co].d = 6000;
                n地面[n地面co].type = 50;
                n地面[n地面co].xtype = 6;
                n地面co += 1;
                //
                n地面[n地面co].a = 101 * 29 * 100 - 1500;
                n地面[n地面co].b = (10 * 29 - 12) * 100 - 3000;
                n地面[n地面co].c = 12000;
                n地面[n地面co].d = 12000;
                n地面[n地面co].type = 104;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 102 * 29 * 100 + 3000;
                n地面[n地面co].b = (2 * 29 - 12) * 100;
                n地面[n地面co].c = 3000 - 1;
                n地面[n地面co].d = 300000;
                n地面[n地面co].type = 102;
                n地面[n地面co].xtype = 20;
                n地面co += 1;
                //
                Cリフト cl;
                //
                cl = new Cリフト();
                cl.a = 74 * 29 * 100 - 1500;
                cl.b = (7 * 29 - 12) * 100;
                cl.c = 2 * 3000;
                cl.type = 0;
                cl.acttype = 1;
                cl.e = 0;
                cl.sp = 0;
                nリフト.Add(cl);
                //
                cl = new Cリフト();
                cl.a = 97 * 29 * 100;
                cl.b = (12 * 29 - 12) * 100;
                cl.c = 12 * 3000;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 21;
                nリフト.Add(cl);
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }
            }

            if (nステージa == 3 && nステージb == 1 && nステージc == 0)
            {// 3-1
                ma = 5600;
                nプレイヤー.b = 32000;

                bgmChange(Res.nオーディオ100);
                nステージ色 = 5;
                scrollX = 2900 * (112 - 19);
                var stagedatex = MapList.stagedatex17;
                //追加情報
                nブロックco = 0;
                //
                nブロック[nブロックco].xtype = 10;

                tyobi(2 * 29, 9 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(63 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロック[nブロックco].xtype = 1;

                tyobi(64 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                n地面co = 0;
                n地面[n地面co].a = 13 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 9000 - 1;
                n地面[n地面co].d = 3000;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                n地面[n地面co].a = 84 * 29 * 100;
                n地面[n地面co].b = (13 * 29 - 12) * 100;
                n地面[n地面co].c = 9000 - 1;
                n地面[n地面co].d = 3000;
                n地面[n地面co].type = 52;
                n地面[n地面co].xtype = 0;
                n地面co += 1;
                //
                C敵出現 ct;
                //
                ct = new C敵出現();
                ct.a = 108 * 29 * 100;
                ct.b = (6 * 29 - 12) * 100;
                ct.type = 6;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 33 * 29 * 100;
                ct.b = (10 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 36 * 29 * 100;
                ct.b = (0 * 29 - 12) * 100;
                ct.type = 80;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 78 * 29 * 100 + 1500;
                ct.b = (7 * 29 - 12) * 100 + 1500;
                ct.type = 88;
                ct.xtype = 105;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 80 * 29 * 100 + 1500;
                ct.b = (7 * 29 - 12) * 100 + 1500;
                ct.type = 87;
                ct.xtype = 105;
                n敵出現.Add(ct);
                //
                ct = new C敵出現();
                ct.a = 85 * 29 * 100;
                ct.b = (11 * 29 - 12) * 100;
                ct.type = 82;
                ct.xtype = 1;
                n敵出現.Add(ct);
                //
                var cl = new Cリフト();
                cl.a = 41 * 29 * 100;
                cl.b = (3 * 29 - 12) * 100;
                cl.c = 3 * 3000;
                cl.type = 0;
                cl.acttype = 0;
                cl.e = 0;
                cl.sp = 3;
                nリフト.Add(cl);
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = stagedatex[t_,tt_];
                    }
                }
            }
        }
    }
}

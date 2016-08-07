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
            if (sta == 1 && stb == 1 && stc == 0)
            {
                byte[][] stagedatex = stagedatex1;


                //追加情報
                tyobi(8 * 29, 9 * 29 - 12, 100);
                nブロックxtype[nブロックco] = 2;

                tyobi(13 * 29, 9 * 29 - 12, 102);
                nブロックxtype[nブロックco] = 0;

                tyobi(14 * 29, 5 * 29 - 12, 101);

                tyobi(35 * 29, 8 * 29 - 12, 110);

                tyobi(47 * 29, 9 * 29 - 12, 103);

                tyobi(59 * 29, 9 * 29 - 12, 112);

                tyobi(67 * 29, 9 * 29 - 12, 104);


                n地面co = 0;
                t_ = n地面co;
                n地面a[t_] = 20 * 29 * 100 + 500;
                n地面b[t_] = -6000;
                n地面c[t_] = 5000;
                n地面d[t_] = 70000;
                n地面type[t_] = 100;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 54 * 29 * 100 - 500;
                n地面b[t_] = -6000;
                n地面c[t_] = 7000;
                n地面d[t_] = 70000;
                n地面type[t_] = 101;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 112 * 29 * 100 + 1000;
                n地面b[t_] = -6000;
                n地面c[t_] = 3000;
                n地面d[t_] = 70000;
                n地面type[t_] = 102;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 117 * 29 * 100;
                n地面b[t_] = (2 * 29 - 12) * 100 - 1500;
                n地面c[t_] = 15000;
                n地面d[t_] = 3000;
                n地面type[t_] = 103;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 125 * 29 * 100;
                n地面b[t_] = -6000;
                n地面c[t_] = 9000;
                n地面d[t_] = 70000;
                n地面type[t_] = 101;
                n地面co++;

                t_ = 28;
                n地面a[t_] = 29 * 29 * 100 + 500;
                n地面b[t_] = (9 * 29 - 12) * 100;
                n地面c[t_] = 6000;
                n地面d[t_] = 12000 - 200;
                n地面type[t_] = 50;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 49 * 29 * 100;
                n地面b[t_] = (5 * 29 - 12) * 100;
                n地面c[t_] = 9000 - 1;
                n地面d[t_] = 3000;
                n地面type[t_] = 51;
                n地面gtype [t_] = 0;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 72 * 29 * 100;
                n地面b[t_] = (13 * 29 - 12) * 100;
                n地面c[t_] = 3000 * 5 - 1;
                n地面d[t_] = 3000;
                n地面type[t_] = 52;
                n地面co++;

                n敵出現co = 0;
                t_ = n敵出現co;
                n敵出現a[t_] = 27 * 29 * 100;
                n敵出現b[t_] = (9 * 29 - 12) * 100;
                n敵出現type[t_] = 0;
                n敵出現xtype[t_] = 0;
                n敵出現co++;

                t_ = n敵出現co;
                n敵出現a[t_] = 103 * 29 * 100;
                n敵出現b[t_] = (5 * 29 - 12 + 10) * 100;
                n敵出現type[t_] = 80;
                n敵出現xtype[t_] = 0;
                n敵出現co++;

                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }

            }//sta1


            //1-2(地上)
            if (sta == 1 && stb == 2 && stc == 0)
            {

                //マリ　地上　入れ
                bgmchange(nオーディオ_[100]);

                scrollx = 0 * 100;

                byte[][] stagedatex = stagedatex2;



                nブロックco = 0;
                //ヒント1
                nブロックxtype[nブロックco] = 1; tyobi(4 * 29, 9 * 29 - 12, 300);

                //毒1
                tyobi(13 * 29, 8 * 29 - 12, 114);

                //t=28;
                n地面co = 0;
                t_ = n地面co; n地面a[t_] = 14 * 29 * 100 + 500; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 1; n地面co++;
                t_ = n地面co; n地面a[t_] = 12 * 29 * 100; n地面b[t_] = (11 * 29 - 12) * 100; n地面c[t_] = 3000; n地面d[t_] = 6000 - 200; n地面type[t_] = 40; n地面xtype[t_] = 0; n地面co++;
                t_ = n地面co; n地面a[t_] = 14 * 29 * 100 + 1000; n地面b[t_] = -6000; n地面c[t_] = 5000; n地面d[t_] = 70000; n地面type[t_] = 100; n地面xtype[t_] = 1; n地面co++;

                //ブロックもどき


                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }

            }//sta2


            //1-2-1(地下)
            if (sta == 1 && stb == 2 && stc == 1)
            {

                //マリ　地下　入れ
                bgmchange(nオーディオ_[103]);

                scrollx = 4080 * 100;
                ma = 6000; nプレイヤーb = 3000;
                stagecolor = 2;


                byte[][] stagedatex = stagedatex3;



                nブロックco = 0;
                nブロックxtype[nブロックco] = 2; tyobi(7 * 29, 9 * 29 - 12, 102);

                tyobi(10 * 29, 9 * 29 - 12, 101);

                nブロックxtype[nブロックco] = 2;

                tyobi(49 * 29, 9 * 29 - 12, 114);

                for (t_ = 0; t_ >= -7; t_--)
                {

                    tyobi(53 * 29, t_ * 29 - 12, 1);
                }

                nブロックxtype[nブロックco] = 1; tyobi(80 * 29, 5 * 29 - 12, 104);
                nブロックxtype[nブロックco] = 2; tyobi(78 * 29, 5 * 29 - 12, 102);


                n地面co = 0;
                t_ = n地面co; n地面a[t_] = 2 * 29 * 100; n地面b[t_] = (13 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 3000; n地面type[t_] = 52; n地面co++;
                t_ = n地面co; n地面a[t_] = 24 * 29 * 100; n地面b[t_] = (13 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 3000; n地面type[t_] = 52; n地面co++;
                t_ = n地面co; n地面a[t_] = 43 * 29 * 100 + 500; n地面b[t_] = -6000; n地面c[t_] = 3000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 1; n地面co++;
                t_ = n地面co; n地面a[t_] = 53 * 29 * 100 + 500; n地面b[t_] = -6000; n地面c[t_] = 3000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 2; n地面co++;
                t_ = n地面co; n地面a[t_] = 129 * 29 * 100; n地面b[t_] = (7 * 29 - 12) * 100; n地面c[t_] = 3000; n地面d[t_] = 6000 - 200; n地面type[t_] = 40; n地面xtype[t_] = 2; n地面co++;
                t_ = n地面co; n地面a[t_] = 154 * 29 * 100; n地面b[t_] = 3000; n地面c[t_] = 9000; n地面d[t_] = 3000; n地面type[t_] = 102; n地面xtype[t_] = 7; n地面co++;

                //ブロックもどき

                t_ = 27; n地面a[t_] = 69 * 29 * 100; n地面b[t_] = (1 * 29 - 12) * 100; n地面c[t_] = 9000 * 2 - 1; n地面d[t_] = 3000; n地面type[t_] = 51; n地面xtype[t_] = 0; n地面gtype [t_] = 0; n地面co++;
                t_ = 28; n地面a[t_] = 66 * 29 * 100; n地面b[t_] = (1 * 29 - 12) * 100; n地面c[t_] = 9000 - 1; n地面d[t_] = 3000; n地面type[t_] = 51; n地面xtype[t_] = 1; n地面gtype [t_] = 0; n地面co++;
                t_ = 29; n地面a[t_] = 66 * 29 * 100; n地面b[t_] = (-2 * 29 - 12) * 100; n地面c[t_] = 9000 * 3 - 1; n地面d[t_] = 3000; n地面type[t_] = 51; n地面xtype[t_] = 2; n地面gtype [t_] = 0; n地面co++;

                //26 ファイアー土管
                t_ = 26; n地面a[t_] = 103 * 29 * 100 - 1500; n地面b[t_] = (9 * 29 - 12) * 100 - 2000; n地面c[t_] = 3000; n地面d[t_] = 3000; n地面type[t_] = 180; n地面xtype[t_] = 0; n地面r[t_] = 0; n地面gtype [t_] = 48; n地面co++;
                t_ = n地面co; n地面a[t_] = 102 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 2; n地面co++;
                t_ = n地面co; n地面a[t_] = 123 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 3000 * 5 - 1; n地面d[t_] = 3000 * 5; n地面type[t_] = 52; n地面xtype[t_] = 1; n地面co++;

                t_ = n地面co; n地面a[t_] = 131 * 29 * 100; n地面b[t_] = (1 * 29 - 12) * 100; n地面c[t_] = 4700; n地面d[t_] = 3000 * 8 - 700; n地面type[t_] = 1; n地面xtype[t_] = 0; n地面co++;

                //オワタゾーン
                t_ = n地面co; n地面a[t_] = 143 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 5; n地面co++;
                t_ = n地面co; n地面a[t_] = 148 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 5; n地面co++;
                t_ = n地面co; n地面a[t_] = 153 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 5; n地面co++;



                n敵出現co = 0;
                t_ = n敵出現co; n敵出現a[t_] = 18 * 29 * 100; n敵出現b[t_] = (10 * 29 - 12) * 100; n敵出現type[t_] = 82; n敵出現xtype[t_] = 1; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 51 * 29 * 100 + 1000; n敵出現b[t_] = (2 * 29 - 12 + 10) * 100; n敵出現type[t_] = 80; n敵出現xtype[t_] = 1; n敵出現co++;

                //？ボール
                t_ = n敵出現co; n敵出現a[t_] = 96 * 29 * 100 + 100; n敵出現b[t_] = (10 * 29 - 12) * 100; n敵出現type[t_] = 105; n敵出現xtype[t_] = 0; n敵出現co++;


                //リフト
                nリフトco = 0;
                t_ = nリフトco; nリフトa[t_] = 111 * 29 * 100; nリフトb[t_] = (8 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 5; nリフトe[t_] = -300; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 111 * 29 * 100; nリフトb[t_] = (0 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 5; nリフトe[t_] = -300; nリフトco++;
                t_ = 10; nリフトa[t_] = 116 * 29 * 100; nリフトb[t_] = (4 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 1; nリフトacttype[t_] = 5; nリフトe[t_] = 300; nリフトco++;
                t_ = 11; nリフトa[t_] = 116 * 29 * 100; nリフトb[t_] = (12 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 1; nリフトacttype[t_] = 5; nリフトe[t_] = 300; nリフトco++;



                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }

            }//sta1-2-1




            //1-2(地上)
            if (sta == 1 && stb == 2 && stc == 2)
            {

                //マリ　地上　入れ
                bgmchange(nオーディオ_[100]);

                scrollx = 900 * 100;
                ma = 7500; nプレイヤーb = 3000 * 9;

                byte[][] stagedatex = stagedatex4;

                t_ = n地面co; n地面a[t_] = 5 * 29 * 100 + 500; n地面b[t_] = -6000; n地面c[t_] = 3000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 8; n地面co++;
                //空飛ぶ土管
                t_ = 28; n地面a[t_] = 44 * 29 * 100 + 500; n地面b[t_] = (10 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 9000 - 200; n地面type[t_] = 50; n地面co++;

                //ポールもどき
                n敵出現co = 0;
                t_ = n敵出現co; n敵出現a[t_] = 19 * 29 * 100; n敵出現b[t_] = (2 * 29 - 12) * 100; n敵出現type[t_] = 85; n敵出現xtype[t_] = 0; n敵出現co++;


                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }

            }//sta2



            //必要BGM+SE

            //1-3(地上)
            if (sta == 1 && stb == 3 && stc == 6) { stc = 0; }
            if (sta == 1 && stb == 3 && stc == 0)
            {
                bgmchange(nオーディオ_[100]);

                scrollx = 3900 * 100;
                //ma=3000;mb=3000;

                byte[][] stagedatex = stagedatex5;

                nブロックco = 0;

                tyobi(22 * 29, 3 * 29 - 12, 1);
                //毒1
                tyobi(54 * 29, 9 * 29 - 12, 116);
                //音符+
                tyobi(18 * 29, 14 * 29 - 12, 117);

                tyobi(19 * 29, 14 * 29 - 12, 117);

                tyobi(20 * 29, 14 * 29 - 12, 117);
                nブロックxtype[nブロックco] = 1; tyobi(61 * 29, 9 * 29 - 12, 101);//5

                tyobi(74 * 29, 9 * 29 - 12, 7);//6

                //ヒント2
                nブロックxtype[nブロックco] = 2; tyobi(28 * 29, 9 * 29 - 12, 300);//7
                                                                  //ファイア
                nブロックxtype[nブロックco] = 3; tyobi(7 * 29, 9 * 29 - 12, 101);
                //ヒント3
                nブロックxtype[nブロックco] = 4; tyobi(70 * 29, 8 * 29 - 12, 300);//9

                //もろいぶろっく×３
                nブロックxtype[nブロックco] = 1; tyobi(58 * 29, 13 * 29 - 12, 115);
                nブロックxtype[nブロックco] = 1; tyobi(59 * 29, 13 * 29 - 12, 115);
                nブロックxtype[nブロックco] = 1; tyobi(60 * 29, 13 * 29 - 12, 115);

                //ヒントブレイク
                nブロックxtype[nブロックco] = 0; tyobi(111 * 29, 6 * 29 - 12, 301);
                //ジャンプ
                nブロックxtype[nブロックco] = 0; tyobi(114 * 29, 9 * 29 - 12, 120);

                //ファイア
                n敵出現co = 0;
                t_ = n敵出現co; n敵出現a[t_] = 101 * 29 * 100; n敵出現b[t_] = (5 * 29 - 12) * 100; n敵出現type[t_] = 4; n敵出現xtype[t_] = 1; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 146 * 29 * 100; n敵出現b[t_] = (10 * 29 - 12) * 100; n敵出現type[t_] = 6; n敵出現xtype[t_] = 1; n敵出現co++;

                t_ = n地面co; n地面a[t_] = 9 * 29 * 100; n地面b[t_] = (13 * 29 - 12) * 100; n地面c[t_] = 9000 - 1; n地面d[t_] = 3000; n地面type[t_] = 52; n地面co++;

                //土管
                t_ = n地面co; n地面a[t_] = 65 * 29 * 100 + 500; n地面b[t_] = (10 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 9000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 1; n地面co++;

                //トラップ
                t_ = n地面co; n地面a[t_] = 74 * 29 * 100; n地面b[t_] = (8 * 29 - 12) * 100 - 1500; n地面c[t_] = 6000; n地面d[t_] = 3000; n地面type[t_] = 103; n地面xtype[t_] = 1; n地面co++;
                t_ = n地面co; n地面a[t_] = 96 * 29 * 100 - 3000; n地面b[t_] = -6000; n地面c[t_] = 9000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 10; n地面co++;
                //ポール砲
                t_ = n地面co; n地面a[t_] = 131 * 29 * 100 - 1500; n地面b[t_] = (1 * 29 - 12) * 100 - 3000; n地面c[t_] = 15000; n地面d[t_] = 14000; n地面type[t_] = 104; n地面co++;


                //？ボール
                t_ = n敵出現co; n敵出現a[t_] = 10 * 29 * 100 + 100; n敵出現b[t_] = (11 * 29 - 12) * 100; n敵出現type[t_] = 105; n敵出現xtype[t_] = 1; n敵出現co++;
                //ブロックもどき
                t_ = n敵出現co; n敵出現a[t_] = 43 * 29 * 100; n敵出現b[t_] = (11 * 29 - 12) * 100; n敵出現type[t_] = 82; n敵出現xtype[t_] = 1; n敵出現co++;
                //うめぇ
                t_ = n敵出現co; n敵出現a[t_] = 1 * 29 * 100; n敵出現b[t_] = (2 * 29 - 12 + 10) * 100 - 1000; n敵出現type[t_] = 80; n敵出現xtype[t_] = 0; n敵出現co++;


                //リフト
                nリフトco = 0;
                t_ = nリフトco; nリフトa[t_] = 33 * 29 * 100; nリフトb[t_] = (3 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 1; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 39 * 29 * 100 - 2000; nリフトb[t_] = (6 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 1; nリフトe[t_] = 0; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 45 * 29 * 100 + 1500; nリフトb[t_] = (10 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 2; nリフトco++;

                t_ = nリフトco; nリフトa[t_] = 95 * 29 * 100; nリフトb[t_] = (7 * 29 - 12) * 100; nリフトc[t_] = 180 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 10; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 104 * 29 * 100; nリフトb[t_] = (9 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 12; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 117 * 29 * 100; nリフトb[t_] = (3 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 1; nリフトe[t_] = 0; nリフトsp[t_] = 15; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 124 * 29 * 100; nリフトb[t_] = (5 * 29 - 12) * 100; nリフトc[t_] = 210 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 10; nリフトco++;



                if (stagepoint == 1) { stagepoint = 0; ma = 4500; nプレイヤーb = -3000; tyuukan = 0; }


                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }

            }//sta3



            //1-3(地下)
            if (sta == 1 && stb == 3 && stc == 1)
            {

                //マリ　地上　入れ
                bgmchange(nオーディオ_[103]);

                scrollx = 0 * 100;
                ma = 6000; nプレイヤーb = 6000;
                stagecolor = 2;


                byte[][] stagedatex = stagedatex6;


                nブロックco = 0;

                stc = 0;


                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }

            }//sta3



            //1-3(空中)
            if (sta == 1 && stb == 3 && stc == 5)
            {

                stagecolor = 3;

                bgmchange(nオーディオ_[104]);

                scrollx = 0 * 100;
                ma = 3000; nプレイヤーb = 33000;

                stagepoint = 1;

                byte[][] stagedatex = stagedatex7;

                n地面co = 0;
                t_ = n地面co; n地面a[t_] = 14 * 29 * 100 - 5; n地面b[t_] = (11 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 15000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 1; n地面co++;


                nブロックxtype[nブロックco] = 0; tyobi(12 * 29, 4 * 29 - 12, 112);
                //ヒント3
                nブロックxtype[nブロックco] = 3; tyobi(12 * 29, 8 * 29 - 12, 300);
                //txtype[tco]=0;tyobi(13*29,4*29-12,110);


                //stc=0;

                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }

            }//sta5





            //1-4(地下)
            if (sta == 1 && stb == 4 && stc == 0)
            {

                //マリ　地上　入れ
                //StopSoundMem(oto[0]);
                bgmchange(nオーディオ_[105]);
                //PlaySoundMem(oto[0],DX_PLAYTYPE_LOOP) ;

                scrollx = 4400 * 100;
                ma = 12000; nプレイヤーb = 6000;
                stagecolor = 4;


                byte[][] stagedatex = stagedatex8;

                n地面co = 0;//sco=140;
                t_ = n地面co; n地面a[t_] = 35 * 29 * 100 - 1500 + 750; n地面b[t_] = (8 * 29 - 12) * 100 - 1500; n地面c[t_] = 1500; n地面d[t_] = 3000; n地面type[t_] = 105; n地面co++;
                t_ = n地面co; n地面a[t_] = 67 * 29 * 100; n地面b[t_] = (4 * 29 - 12) * 100; n地面c[t_] = 9000 - 1; n地面d[t_] = 3000 * 1 - 1; n地面type[t_] = 51; n地面xtype[t_] = 3; n地面gtype [t_] = 0; n地面co++;
                t_ = n地面co; n地面a[t_] = 73 * 29 * 100; n地面b[t_] = (13 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 3000; n地面type[t_] = 52; n地面co++;
                t_ = n地面co; n地面a[t_] = 123 * 29 * 100; n地面b[t_] = (1 * 29 - 12) * 100; n地面c[t_] = 30 * 6 * 100 - 1 + 0; n地面d[t_] = 3000 - 200; n地面type[t_] = 51; n地面xtype[t_] = 10; n地面co++;
                //スクロール消し
                t_ = n地面co; n地面a[t_] = 124 * 29 * 100 + 3000; n地面b[t_] = (2 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 300000; n地面type[t_] = 102; n地面xtype[t_] = 20; n地面co++;
                t_ = n地面co; n地面a[t_] = 148 * 29 * 100 + 1000; n地面b[t_] = (-12 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 300000; n地面type[t_] = 102; n地面xtype[t_] = 30; n地面co++;

                //3連星
                t_ = n地面co; n地面a[t_] = 100 * 29 * 100 + 1000; n地面b[t_] = -6000; n地面c[t_] = 3000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 12; n地面co++;

                //地面1
                t_ = n地面co; n地面a[t_] = 0 * 29 * 100 - 0; n地面b[t_] = 9 * 29 * 100 + 1700; n地面c[t_] = 3000 * 7 - 1; n地面d[t_] = 3000 * 5 - 1; n地面type[t_] = 200; n地面xtype[t_] = 0; n地面co++;
                t_ = n地面co; n地面a[t_] = 11 * 29 * 100; n地面b[t_] = -1 * 29 * 100 + 1700; n地面c[t_] = 3000 * 8 - 1; n地面d[t_] = 3000 * 4 - 1; n地面type[t_] = 200; n地面xtype[t_] = 0; n地面co++;


                n敵出現co = 0;
                t_ = n敵出現co; n敵出現a[t_] = 8 * 29 * 100 - 1400; n敵出現b[t_] = (2 * 29 - 12) * 100 + 500; n敵出現type[t_] = 86; n敵出現xtype[t_] = 0; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 42 * 29 * 100 - 1400; n敵出現b[t_] = (-2 * 29 - 12) * 100 + 500; n敵出現type[t_] = 86; n敵出現xtype[t_] = 0; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 29 * 29 * 100 + 1500; n敵出現b[t_] = (7 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 105; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 47 * 29 * 100 + 1500; n敵出現b[t_] = (9 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 110; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 70 * 29 * 100 + 1500; n敵出現b[t_] = (9 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 105; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 66 * 29 * 100 + 1501; n敵出現b[t_] = (4 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 101; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 85 * 29 * 100 + 1501; n敵出現b[t_] = (4 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 105; n敵出現co++;

                //ステルスうめぇ
                t_ = n敵出現co; n敵出現a[t_] = 57 * 29 * 100; n敵出現b[t_] = (2 * 29 - 12 + 10) * 100 - 500; n敵出現type[t_] = 80; n敵出現xtype[t_] = 1; n敵出現co++;
                //ブロックもどき
                t_ = n敵出現co; n敵出現a[t_] = 77 * 29 * 100; n敵出現b[t_] = (5 * 29 - 12) * 100; n敵出現type[t_] = 82; n敵出現xtype[t_] = 2; n敵出現co++;
                //ボス
                t_ = n敵出現co; n敵出現a[t_] = 130 * 29 * 100; n敵出現b[t_] = (8 * 29 - 12) * 100; n敵出現type[t_] = 30; n敵出現xtype[t_] = 0; n敵出現co++;
                //クックル
                t_ = n敵出現co; n敵出現a[t_] = 142 * 29 * 100; n敵出現b[t_] = (10 * 29 - 12) * 100; n敵出現type[t_] = 31; n敵出現xtype[t_] = 0; n敵出現co++;

                //マグマ
                n背景co = 0;
                n背景a[n背景co] = 7 * 29 * 100 - 300; n背景b[n背景co] = 14 * 29 * 100 - 1200; n背景type[n背景co] = 6; n背景co++; if (n背景co >= n背景max) n背景co = 0;
                n背景a[n背景co] = 41 * 29 * 100 - 300; n背景b[n背景co] = 14 * 29 * 100 - 1200; n背景type[n背景co] = 6; n背景co++; if (n背景co >= n背景max) n背景co = 0;
                n背景a[n背景co] = 149 * 29 * 100 - 1100; n背景b[n背景co] = 10 * 29 * 100 - 600; n背景type[n背景co] = 100; n背景co++; if (n背景co >= n背景max) n背景co = 0;

                nブロックco = 0;
                //ON-OFFブロック
                nブロックxtype[nブロックco] = 1; tyobi(29 * 29, 3 * 29 - 12, 130);
                //1-2
                tyobi(34 * 29, 9 * 29 - 12, 5);

                tyobi(35 * 29, 9 * 29 - 12, 5);
                //隠し
                tyobi(55 * 29 + 15, 6 * 29 - 12, 7);
                //tyobi(62*29,9*29-12,2);
                //隠しON-OFF
                nブロックxtype[nブロックco] = 10; tyobi(50 * 29, 9 * 29 - 12, 114);
                //ヒント3
                nブロックxtype[nブロックco] = 5; tyobi(1 * 29, 5 * 29 - 12, 300);
                //ファイア
                nブロックxtype[nブロックco] = 3;

                tyobi(86 * 29, 9 * 29 - 12, 101);
                //キノコなし　普通
                //txtype[tco]=2;tyobi(81*29,1*29-12,5);
                //音符
                nブロックxtype[nブロックco] = 2;

                tyobi(86 * 29, 6 * 29 - 12, 117);

                //もろいぶろっく×３
                for (t_ = 0; t_ <= 2; t_++)
                {
                    nブロックxtype[nブロックco] = 3; tyobi((79 + t_) * 29, 13 * 29 - 12, 115);
                }

                //ジャンプ
                nブロックxtype[nブロックco] = 3; tyobi(105 * 29, 11 * 29 - 12, 120);
                //毒1
                nブロックxtype[nブロックco] = 3; tyobi(109 * 29, 7 * 29 - 12, 102);
                //デフラグ
                nブロックxtype[nブロックco] = 4; tyobi(111 * 29, 7 * 29 - 12, 101);
                //剣
                tyobi(132 * 29, 8 * 29 - 12 - 3, 140);

                tyobi(131 * 29, 9 * 29 - 12, 141);
                //メロン
                tyobi(161 * 29, 12 * 29 - 12, 142);
                //ファイアバー強化
                tyobi(66 * 29, 4 * 29 - 12, 124);


                //リフト
                nリフトco = 0;
                t_ = nリフトco; nリフトa[t_] = 93 * 29 * 100; nリフトb[t_] = (10 * 29 - 12) * 100; nリフトc[t_] = 60 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 1; nリフトe[t_] = 0; nリフトco++;
                t_ = 20; nリフトa[t_] = 119 * 29 * 100 + 300; nリフトb[t_] = (10 * 29 - 12) * 100; nリフトc[t_] = 12 * 30 * 100 + 1000; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトsp[t_] = 21; nリフトe[t_] = 0; nリフトco++;


                stc = 0;


                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }

            }//sta4

            if (sta == 2 && stb == 1 && stc == 0)
            {// 2-1
                ma = 5600;
                nプレイヤーb = 32000;

                bgmchange(nオーディオ_[100]);
                stagecolor = 1;
                scrollx = 2900 * (113 - 19);
                //
                byte[][] stagedatex = stagedatex9;
                //追加情報
                nブロックco = 0;
                //
                nブロックxtype[nブロックco] = 6;

                tyobi(1 * 29, 9 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(40 * 29, 9 * 29 - 12, 110);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 7;

                tyobi(79 * 29, 7 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 2;

                tyobi(83 * 29, 7 * 29 - 12, 102);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

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
                n地面a[n地面co] = 30 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 12000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 51 * 29 * 100;
                n地面b[n地面co] = (4 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 51;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 84 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 105 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 15000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n敵出現co = 0;
                //
                n敵出現a[n敵出現co] = 6 * 29 * 100;
                n敵出現b[n敵出現co] = (3 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 13 * 29 * 100;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 4;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 23 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 25 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 27 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 88 * 29 * 100;
                n敵出現b[n敵出現co] = (12 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }
            }

            if (sta == 2 && stb == 2 && stc == 0)
            {//2-2(地上)

                bgmchange(nオーディオ_[100]);
                stagecolor = 1;
                scrollx = 2900 * (19 - 19);
                //
                byte[][] stagedatex = stagedatex10;
                //
                n地面a[n地面co] = 14 * 29 * 100 + 200;
                n地面b[n地面co] = -6000;
                n地面c[n地面co] = 5000;
                n地面d[n地面co] = 70000;
                n地面type[n地面co] = 100;
                n地面co += 1;
                //
                n地面a[n地面co] = 12 * 29 * 100 + 1200;
                n地面b[n地面co] = -6000;
                n地面c[n地面co] = 7000;
                n地面d[n地面co] = 70000;
                n地面type[n地面co] = 101;
                n地面co += 1;
                //
                n地面a[n地面co] = 12 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 6000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面gtype [n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 14 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 12000 - 200;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 1;
                n地面co += 1;
                //
                tyobi(6 * 29, 9 * 29 - 12, 110);
                //
                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }
            }

            if (sta == 2 && stb == 2 && stc == 1)
            {//2-2(地下)

                bgmchange(nオーディオ_[103]);
                stagecolor = 2;
                ma = 7500; nプレイヤーb = 9000;
                scrollx = 2900 * (137 - 19);
                //
                byte[][] stagedatex = stagedatex11;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 32 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (-2 * 29 - 12) * 100 + 500;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = (31 * 29 - 12) * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 7;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 38 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 38 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 42 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 42 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 46 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 46 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 58 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 66 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 76 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (-2 * 29 - 12) * 100 + 500;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 2 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 300000 - 6001;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 3 * 29 * 100;
                n地面b[n地面co] = (7 * 29 - 12) * 100;
                n地面c[n地面co] = 3000;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 105;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 107 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 24000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 1;
                n地面co += 1;
                //
                n地面a[n地面co] = 111 * 29 * 100;
                n地面b[n地面co] = (7 * 29 - 12) * 100;
                n地面c[n地面co] = 3000;
                n地面d[n地面co] = 6000 - 200;
                n地面type[n地面co] = 40;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 113 * 29 * 100 + 1100;
                n地面b[n地面co] = (0 * 29 - 12) * 100;
                n地面c[n地面co] = 4700;
                n地面d[n地面co] = 27000 - 1000;
                n地面type[n地面co] = 0;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 128 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 24000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 1;
                n地面co += 1;
                //
                n地面a[n地面co] = 131 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 3000;
                n地面d[n地面co] = 6000 - 200;
                n地面type[n地面co] = 40;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 133 * 29 * 100 + 1100;
                n地面b[n地面co] = (0 * 29 - 12) * 100;
                n地面c[n地面co] = 4700;
                n地面d[n地面co] = 32000;
                n地面type[n地面co] = 0;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 0;

                tyobi(0 * 29, 0 * 29 - 12, 4);
                nブロックco = 1;
                nブロックxtype[nブロックco] = 0;

                tyobi(2 * 29, 9 * 29 - 12, 4);
                nブロックco = 2;
                nブロックxtype[nブロックco] = 0;

                tyobi(3 * 29, 9 * 29 - 12, 4);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(5 * 29, 9 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(6 * 29, 9 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(5 * 29, 10 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(6 * 29, 10 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(5 * 29, 11 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(6 * 29, 11 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(5 * 29, 12 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(6 * 29, 12 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(70 * 29, 7 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(71 * 29, 7 * 29 - 12, 115);
                nブロックco += 1;
                //
                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }
            }

            if (sta == 2 && stb == 2 && stc == 2)
            {// 2-2 地上
             //
                bgmchange(nオーディオ_[100]);
                stagecolor = 1;
                scrollx = 2900 * (36 - 19);
                ma = 7500;
                nプレイヤーb = 3000 * 9;
                //
                byte[][] stagedatex = stagedatex12;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 9 * 29 * 100;
                n敵出現b[n敵出現co] = (12 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 10 * 29 * 100;
                n敵出現b[n敵出現co] = (11 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 11 * 29 * 100;
                n敵出現b[n敵出現co] = (10 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 12 * 29 * 100;
                n敵出現b[n敵出現co] = (9 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 13 * 29 * 100;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 14 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 15 * 29 * 100;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 16 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 17 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 18 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 19 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 20 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }
            }
            //
            if (sta == 2 && stb == 3 && stc == 0)
            {// 2-3
                ma = 7500;
                nプレイヤーb = 3000 * 8;

                bgmchange(nオーディオ_[100]);
                stagecolor = 1;
                scrollx = 2900 * (126 - 19);
                //
                byte[][] stagedatex = stagedatex13;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 0;
                for (int i = -1; i > -7; i -= 1)
                {

                    tyobi(55 * 29, i * 29 - 12, 4);
                    nブロックco += 1;
                }
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(64 * 29, 12 * 29 - 12, 120);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(66 * 29, 3 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(67 * 29, 3 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(68 * 29, 3 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 8;

                tyobi(60 * 29, 6 * 29 - 12, 300);
                nブロックco += 1;
                n敵出現co = 1;
                n敵出現a[n敵出現co] = (54 * 29 - 12) * 100;
                n敵出現b[n敵出現co] = (1 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n地面co = 0;
                n敵出現a[n地面co] = (102 * 29 - 12) * 100;
                n敵出現b[n地面co] = (10 * 29 - 12) * 100;
                n敵出現type[n地面co] = 50;
                n敵出現xtype[n地面co] = 1;
                n地面co += 1;
                //
                nリフトco = 0;
                nリフトa[nリフトco] = 1 * 29 * 100;
                nリフトb[nリフトco] = (10 * 29 - 12) * 100;
                nリフトc[nリフトco] = 5 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 1;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 10;
                nリフトco++;
                //
                nリフトa[nリフトco] = 18 * 29 * 100;
                nリフトb[nリフトco] = (4 * 29 - 12) * 100;
                nリフトc[nリフトco] = 3 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 10;
                nリフトco++;
                //
                nリフトa[nリフトco] = 35 * 29 * 100;
                nリフトb[nリフトco] = (4 * 29 - 12) * 100;
                nリフトc[nリフトco] = 5 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 10;
                nリフトco++;
                //
                nリフトa[nリフトco] = 35 * 29 * 100;
                nリフトb[nリフトco] = (8 * 29 - 12) * 100;
                nリフトc[nリフトco] = 5 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 10;
                nリフトco++;
                //
                nリフトa[nリフトco] = 94 * 29 * 100;
                nリフトb[nリフトco] = (6 * 29 - 12) * 100;
                nリフトc[nリフトco] = 3 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 1;
                nリフトco++;
                //
                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }
            }
            //
            if (sta == 2 && stb == 4 && (stc == 0 || stc == 10 || stc == 12))
            {// 2-4(1番)
                if (stc == 0)
                {
                    ma = 7500;
                    nプレイヤーb = 3000 * 4;
                }
                else {
                    ma = 19500;
                    nプレイヤーb = 3000 * 11;
                    stc = 0;
                }

                bgmchange(nオーディオ_[105]);
                stagecolor = 4;
                scrollx = 2900 * (40 - 19);
                //
                byte[][] stagedatex = stagedatex14;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 0;

                tyobi(0 * 29, -1 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(4 * 29, -1 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(1 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(6 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(7 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 2 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (-2 * 29 - 12) * 100 + 500;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 20 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 17 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 21000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 27 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 6000;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 6;
                n地面co += 1;
                //
                n地面a[n地面co] = 34 * 29 * 100;
                n地面b[n地面co] = (5 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 30000;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 1;
                n地面co += 1;
                //
                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }
            }

            if (sta == 2 && stb == 4 && stc == 1)
            {// 2-4(2番)
                ma = 4500;
                nプレイヤーb = 3000 * 11;

                bgmchange(nオーディオ_[105]);
                stagecolor = 4;
                scrollx = 2900 * (21 - 19);
                //
                byte[][] stagedatex = stagedatex15;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 1;

                tyobi(12 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(13 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(14 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 6 * 29 * 100;
                n地面b[n地面co] = (6 * 29 - 12) * 100;
                n地面c[n地面co] = 18000 - 1;
                n地面d[n地面co] = 6000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 12 * 29 * 100;
                n地面b[n地面co] = (8 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 15 * 29 * 100;
                n地面b[n地面co] = (11 * 29 - 12) * 100;
                n地面c[n地面co] = 3000;
                n地面d[n地面co] = 6000;
                n地面type[n地面co] = 40;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 17 * 29 * 100 + 1100;
                n地面b[n地面co] = (0 * 29 - 12) * 100;
                n地面c[n地面co] = 4700;
                n地面d[n地面co] = 38000;
                n地面type[n地面co] = 0;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }
            }

            if (sta == 2 && stb == 4 && stc == 2)
            {// 2-4(3番)
                ma = 4500;
                nプレイヤーb = 3000 * 11;

                bgmchange(nオーディオ_[105]);
                stagecolor = 4;
                scrollx = 2900 * (128 - 19);
                //
                byte[][] stagedatex = stagedatex16;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 0;

                tyobi(1 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(2 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 9;

                tyobi(3 * 29, 4 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(32 * 29, 9 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(76 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(108 * 29, 11 * 29 - 12, 141);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(109 * 29, 10 * 29 - 12 - 3, 140);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(121 * 29, 10 * 29 - 12, 142);
                nブロックco += 1;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 0 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 2 * 29 * 100;
                n敵出現b[n敵出現co] = (0 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 3 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 6 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 9 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 25 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (2 * 29 - 12) * 100 - 400;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 40 * 29 * 100;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 42 * 29 * 100;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 43 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 47 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 57 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 77 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (2 * 29 - 12) * 100 - 400;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 83 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (2 * 29 - 12) * 100 - 400;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 88 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (9 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 88 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (9 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 90 * 29 * 100;
                n敵出現b[n敵出現co] = (9 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 107 * 29 * 100;
                n敵出現b[n敵出現co] = (10 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 30;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 13 * 29 * 100;
                n地面b[n地面co] = (8 * 29 - 12) * 100;
                n地面c[n地面co] = 33000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 13 * 29 * 100;
                n地面b[n地面co] = (0 * 29 - 12) * 100;
                n地面c[n地面co] = 33000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 51;
                n地面xtype[n地面co] = 3;
                n地面co += 1;
                //
                n地面a[n地面co] = 10 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 6000;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 6;
                n地面co += 1;
                //
                n地面a[n地面co] = 46 * 29 * 100;
                n地面b[n地面co] = (12 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 58 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 6000;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 6;
                n地面co += 1;
                //
                n地面a[n地面co] = 101 * 29 * 100 - 1500;
                n地面b[n地面co] = (10 * 29 - 12) * 100 - 3000;
                n地面c[n地面co] = 12000;
                n地面d[n地面co] = 12000;
                n地面type[n地面co] = 104;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 102 * 29 * 100 + 3000;
                n地面b[n地面co] = (2 * 29 - 12) * 100;
                n地面c[n地面co] = 3000 - 1;
                n地面d[n地面co] = 300000;
                n地面type[n地面co] = 102;
                n地面xtype[n地面co] = 20;
                n地面co += 1;
                //
                nリフトco = 0;
                nリフトa[nリフトco] = 74 * 29 * 100 - 1500;
                nリフトb[nリフトco] = (7 * 29 - 12) * 100;
                nリフトc[nリフトco] = 2 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 1;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 0;
                nリフトco = 20;
                //
                nリフトa[nリフトco] = 97 * 29 * 100;
                nリフトb[nリフトco] = (12 * 29 - 12) * 100;
                nリフトc[nリフトco] = 12 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 21;
                nリフトco += 1;
                //
                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }
            }

            if (sta == 3 && stb == 1 && stc == 0)
            {// 3-1
                ma = 5600;
                nプレイヤーb = 32000;

                bgmchange(nオーディオ_[100]);
                stagecolor = 5;
                scrollx = 2900 * (112 - 19);
                byte[][] stagedatex = stagedatex17;
                //追加情報
                nブロックco = 0;
                //
                nブロックxtype[nブロックco] = 10;

                tyobi(2 * 29, 9 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(63 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(64 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 13 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 84 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 108 * 29 * 100;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 6;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 33 * 29 * 100;
                n敵出現b[n敵出現co] = (10 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 36 * 29 * 100;
                n敵出現b[n敵出現co] = (0 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 78 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 80 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 85 * 29 * 100;
                n敵出現b[n敵出現co] = (11 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                nリフトco = 0;
                nリフトa[nリフトco] = 41 * 29 * 100;
                nリフトb[nリフトco] = (3 * 29 - 12) * 100;
                nリフトc[nリフトco] = 3 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 3;
                nリフトco = 0;
                //
                for (tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stagedate[t_, tt_] = 0; stagedate[t_, tt_] = stagedatex[t_][tt_];
                    }
                }
            }
        }
    }
}

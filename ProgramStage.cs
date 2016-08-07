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
        static void Stage()
        {
            //1-1
            if (sta == 1 && stb == 1 && stc == 0)
            {
                byte[][] stagedatex = stagedatex1;


                //追加情報
                tyobi(8 * 29, 9 * 29 - 12, 100);
                txtype[tco] = 2;

                tyobi(13 * 29, 9 * 29 - 12, 102);
                txtype[tco] = 0;

                tyobi(14 * 29, 5 * 29 - 12, 101);

                tyobi(35 * 29, 8 * 29 - 12, 110);

                tyobi(47 * 29, 9 * 29 - 12, 103);

                tyobi(59 * 29, 9 * 29 - 12, 112);

                tyobi(67 * 29, 9 * 29 - 12, 104);


                sco = 0;
                t_ = sco;
                sa[t_] = 20 * 29 * 100 + 500;
                sb[t_] = -6000;
                sc[t_] = 5000;
                sd[t_] = 70000;
                stype[t_] = 100;
                sco++;

                t_ = sco;
                sa[t_] = 54 * 29 * 100 - 500;
                sb[t_] = -6000;
                sc[t_] = 7000;
                sd[t_] = 70000;
                stype[t_] = 101;
                sco++;

                t_ = sco;
                sa[t_] = 112 * 29 * 100 + 1000;
                sb[t_] = -6000;
                sc[t_] = 3000;
                sd[t_] = 70000;
                stype[t_] = 102;
                sco++;

                t_ = sco;
                sa[t_] = 117 * 29 * 100;
                sb[t_] = (2 * 29 - 12) * 100 - 1500;
                sc[t_] = 15000;
                sd[t_] = 3000;
                stype[t_] = 103;
                sco++;

                t_ = sco;
                sa[t_] = 125 * 29 * 100;
                sb[t_] = -6000;
                sc[t_] = 9000;
                sd[t_] = 70000;
                stype[t_] = 101;
                sco++;

                t_ = 28;
                sa[t_] = 29 * 29 * 100 + 500;
                sb[t_] = (9 * 29 - 12) * 100;
                sc[t_] = 6000;
                sd[t_] = 12000 - 200;
                stype[t_] = 50;
                sco++;

                t_ = sco;
                sa[t_] = 49 * 29 * 100;
                sb[t_] = (5 * 29 - 12) * 100;
                sc[t_] = 9000 - 1;
                sd[t_] = 3000;
                stype[t_] = 51;
                sgtype[t_] = 0;
                sco++;

                t_ = sco;
                sa[t_] = 72 * 29 * 100;
                sb[t_] = (13 * 29 - 12) * 100;
                sc[t_] = 3000 * 5 - 1;
                sd[t_] = 3000;
                stype[t_] = 52;
                sco++;

                bco = 0;
                t_ = bco;
                ba[t_] = 27 * 29 * 100;
                bb[t_] = (9 * 29 - 12) * 100;
                btype[t_] = 0;
                bxtype[t_] = 0;
                bco++;

                t_ = bco;
                ba[t_] = 103 * 29 * 100;
                bb[t_] = (5 * 29 - 12 + 10) * 100;
                btype[t_] = 80;
                bxtype[t_] = 0;
                bco++;

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



                tco = 0;
                //ヒント1
                txtype[tco] = 1; tyobi(4 * 29, 9 * 29 - 12, 300);

                //毒1
                tyobi(13 * 29, 8 * 29 - 12, 114);

                //t=28;
                sco = 0;
                t_ = sco; sa[t_] = 14 * 29 * 100 + 500; sb[t_] = (9 * 29 - 12) * 100; sc[t_] = 6000; sd[t_] = 12000 - 200; stype[t_] = 50; sxtype[t_] = 1; sco++;
                t_ = sco; sa[t_] = 12 * 29 * 100; sb[t_] = (11 * 29 - 12) * 100; sc[t_] = 3000; sd[t_] = 6000 - 200; stype[t_] = 40; sxtype[t_] = 0; sco++;
                t_ = sco; sa[t_] = 14 * 29 * 100 + 1000; sb[t_] = -6000; sc[t_] = 5000; sd[t_] = 70000; stype[t_] = 100; sxtype[t_] = 1; sco++;

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
                ma = 6000; mb = 3000;
                stagecolor = 2;


                byte[][] stagedatex = stagedatex3;



                tco = 0;
                txtype[tco] = 2; tyobi(7 * 29, 9 * 29 - 12, 102);

                tyobi(10 * 29, 9 * 29 - 12, 101);

                txtype[tco] = 2;

                tyobi(49 * 29, 9 * 29 - 12, 114);

                for (t_ = 0; t_ >= -7; t_--)
                {

                    tyobi(53 * 29, t_ * 29 - 12, 1);
                }

                txtype[tco] = 1; tyobi(80 * 29, 5 * 29 - 12, 104);
                txtype[tco] = 2; tyobi(78 * 29, 5 * 29 - 12, 102);


                sco = 0;
                t_ = sco; sa[t_] = 2 * 29 * 100; sb[t_] = (13 * 29 - 12) * 100; sc[t_] = 3000 * 1 - 1; sd[t_] = 3000; stype[t_] = 52; sco++;
                t_ = sco; sa[t_] = 24 * 29 * 100; sb[t_] = (13 * 29 - 12) * 100; sc[t_] = 3000 * 1 - 1; sd[t_] = 3000; stype[t_] = 52; sco++;
                t_ = sco; sa[t_] = 43 * 29 * 100 + 500; sb[t_] = -6000; sc[t_] = 3000; sd[t_] = 70000; stype[t_] = 102; sxtype[t_] = 1; sco++;
                t_ = sco; sa[t_] = 53 * 29 * 100 + 500; sb[t_] = -6000; sc[t_] = 3000; sd[t_] = 70000; stype[t_] = 102; sxtype[t_] = 2; sco++;
                t_ = sco; sa[t_] = 129 * 29 * 100; sb[t_] = (7 * 29 - 12) * 100; sc[t_] = 3000; sd[t_] = 6000 - 200; stype[t_] = 40; sxtype[t_] = 2; sco++;
                t_ = sco; sa[t_] = 154 * 29 * 100; sb[t_] = 3000; sc[t_] = 9000; sd[t_] = 3000; stype[t_] = 102; sxtype[t_] = 7; sco++;

                //ブロックもどき

                t_ = 27; sa[t_] = 69 * 29 * 100; sb[t_] = (1 * 29 - 12) * 100; sc[t_] = 9000 * 2 - 1; sd[t_] = 3000; stype[t_] = 51; sxtype[t_] = 0; sgtype[t_] = 0; sco++;
                t_ = 28; sa[t_] = 66 * 29 * 100; sb[t_] = (1 * 29 - 12) * 100; sc[t_] = 9000 - 1; sd[t_] = 3000; stype[t_] = 51; sxtype[t_] = 1; sgtype[t_] = 0; sco++;
                t_ = 29; sa[t_] = 66 * 29 * 100; sb[t_] = (-2 * 29 - 12) * 100; sc[t_] = 9000 * 3 - 1; sd[t_] = 3000; stype[t_] = 51; sxtype[t_] = 2; sgtype[t_] = 0; sco++;

                //26 ファイアー土管
                t_ = 26; sa[t_] = 103 * 29 * 100 - 1500; sb[t_] = (9 * 29 - 12) * 100 - 2000; sc[t_] = 3000; sd[t_] = 3000; stype[t_] = 180; sxtype[t_] = 0; sr[t_] = 0; sgtype[t_] = 48; sco++;
                t_ = sco; sa[t_] = 102 * 29 * 100; sb[t_] = (9 * 29 - 12) * 100; sc[t_] = 6000; sd[t_] = 12000 - 200; stype[t_] = 50; sxtype[t_] = 2; sco++;
                t_ = sco; sa[t_] = 123 * 29 * 100; sb[t_] = (9 * 29 - 12) * 100; sc[t_] = 3000 * 5 - 1; sd[t_] = 3000 * 5; stype[t_] = 52; sxtype[t_] = 1; sco++;

                t_ = sco; sa[t_] = 131 * 29 * 100; sb[t_] = (1 * 29 - 12) * 100; sc[t_] = 4700; sd[t_] = 3000 * 8 - 700; stype[t_] = 1; sxtype[t_] = 0; sco++;

                //オワタゾーン
                t_ = sco; sa[t_] = 143 * 29 * 100; sb[t_] = (9 * 29 - 12) * 100; sc[t_] = 6000; sd[t_] = 12000 - 200; stype[t_] = 50; sxtype[t_] = 5; sco++;
                t_ = sco; sa[t_] = 148 * 29 * 100; sb[t_] = (9 * 29 - 12) * 100; sc[t_] = 6000; sd[t_] = 12000 - 200; stype[t_] = 50; sxtype[t_] = 5; sco++;
                t_ = sco; sa[t_] = 153 * 29 * 100; sb[t_] = (9 * 29 - 12) * 100; sc[t_] = 6000; sd[t_] = 12000 - 200; stype[t_] = 50; sxtype[t_] = 5; sco++;



                bco = 0;
                t_ = bco; ba[t_] = 18 * 29 * 100; bb[t_] = (10 * 29 - 12) * 100; btype[t_] = 82; bxtype[t_] = 1; bco++;
                t_ = bco; ba[t_] = 51 * 29 * 100 + 1000; bb[t_] = (2 * 29 - 12 + 10) * 100; btype[t_] = 80; bxtype[t_] = 1; bco++;

                //？ボール
                t_ = bco; ba[t_] = 96 * 29 * 100 + 100; bb[t_] = (10 * 29 - 12) * 100; btype[t_] = 105; bxtype[t_] = 0; bco++;


                //リフト
                srco = 0;
                t_ = srco; sra[t_] = 111 * 29 * 100; srb[t_] = (8 * 29 - 12) * 100; src[t_] = 90 * 100; srtype[t_] = 0; sracttype[t_] = 5; sre[t_] = -300; srco++;
                t_ = srco; sra[t_] = 111 * 29 * 100; srb[t_] = (0 * 29 - 12) * 100; src[t_] = 90 * 100; srtype[t_] = 0; sracttype[t_] = 5; sre[t_] = -300; srco++;
                t_ = 10; sra[t_] = 116 * 29 * 100; srb[t_] = (4 * 29 - 12) * 100; src[t_] = 90 * 100; srtype[t_] = 1; sracttype[t_] = 5; sre[t_] = 300; srco++;
                t_ = 11; sra[t_] = 116 * 29 * 100; srb[t_] = (12 * 29 - 12) * 100; src[t_] = 90 * 100; srtype[t_] = 1; sracttype[t_] = 5; sre[t_] = 300; srco++;



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
                ma = 7500; mb = 3000 * 9;

                byte[][] stagedatex = stagedatex4;

                t_ = sco; sa[t_] = 5 * 29 * 100 + 500; sb[t_] = -6000; sc[t_] = 3000; sd[t_] = 70000; stype[t_] = 102; sxtype[t_] = 8; sco++;
                //空飛ぶ土管
                t_ = 28; sa[t_] = 44 * 29 * 100 + 500; sb[t_] = (10 * 29 - 12) * 100; sc[t_] = 6000; sd[t_] = 9000 - 200; stype[t_] = 50; sco++;

                //ポールもどき
                bco = 0;
                t_ = bco; ba[t_] = 19 * 29 * 100; bb[t_] = (2 * 29 - 12) * 100; btype[t_] = 85; bxtype[t_] = 0; bco++;


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

                tco = 0;

                tyobi(22 * 29, 3 * 29 - 12, 1);
                //毒1
                tyobi(54 * 29, 9 * 29 - 12, 116);
                //音符+
                tyobi(18 * 29, 14 * 29 - 12, 117);

                tyobi(19 * 29, 14 * 29 - 12, 117);

                tyobi(20 * 29, 14 * 29 - 12, 117);
                txtype[tco] = 1; tyobi(61 * 29, 9 * 29 - 12, 101);//5

                tyobi(74 * 29, 9 * 29 - 12, 7);//6

                //ヒント2
                txtype[tco] = 2; tyobi(28 * 29, 9 * 29 - 12, 300);//7
                                                                  //ファイア
                txtype[tco] = 3; tyobi(7 * 29, 9 * 29 - 12, 101);
                //ヒント3
                txtype[tco] = 4; tyobi(70 * 29, 8 * 29 - 12, 300);//9

                //もろいぶろっく×３
                txtype[tco] = 1; tyobi(58 * 29, 13 * 29 - 12, 115);
                txtype[tco] = 1; tyobi(59 * 29, 13 * 29 - 12, 115);
                txtype[tco] = 1; tyobi(60 * 29, 13 * 29 - 12, 115);

                //ヒントブレイク
                txtype[tco] = 0; tyobi(111 * 29, 6 * 29 - 12, 301);
                //ジャンプ
                txtype[tco] = 0; tyobi(114 * 29, 9 * 29 - 12, 120);

                //ファイア
                bco = 0;
                t_ = bco; ba[t_] = 101 * 29 * 100; bb[t_] = (5 * 29 - 12) * 100; btype[t_] = 4; bxtype[t_] = 1; bco++;
                t_ = bco; ba[t_] = 146 * 29 * 100; bb[t_] = (10 * 29 - 12) * 100; btype[t_] = 6; bxtype[t_] = 1; bco++;

                t_ = sco; sa[t_] = 9 * 29 * 100; sb[t_] = (13 * 29 - 12) * 100; sc[t_] = 9000 - 1; sd[t_] = 3000; stype[t_] = 52; sco++;

                //土管
                t_ = sco; sa[t_] = 65 * 29 * 100 + 500; sb[t_] = (10 * 29 - 12) * 100; sc[t_] = 6000; sd[t_] = 9000 - 200; stype[t_] = 50; sxtype[t_] = 1; sco++;

                //トラップ
                t_ = sco; sa[t_] = 74 * 29 * 100; sb[t_] = (8 * 29 - 12) * 100 - 1500; sc[t_] = 6000; sd[t_] = 3000; stype[t_] = 103; sxtype[t_] = 1; sco++;
                t_ = sco; sa[t_] = 96 * 29 * 100 - 3000; sb[t_] = -6000; sc[t_] = 9000; sd[t_] = 70000; stype[t_] = 102; sxtype[t_] = 10; sco++;
                //ポール砲
                t_ = sco; sa[t_] = 131 * 29 * 100 - 1500; sb[t_] = (1 * 29 - 12) * 100 - 3000; sc[t_] = 15000; sd[t_] = 14000; stype[t_] = 104; sco++;


                //？ボール
                t_ = bco; ba[t_] = 10 * 29 * 100 + 100; bb[t_] = (11 * 29 - 12) * 100; btype[t_] = 105; bxtype[t_] = 1; bco++;
                //ブロックもどき
                t_ = bco; ba[t_] = 43 * 29 * 100; bb[t_] = (11 * 29 - 12) * 100; btype[t_] = 82; bxtype[t_] = 1; bco++;
                //うめぇ
                t_ = bco; ba[t_] = 1 * 29 * 100; bb[t_] = (2 * 29 - 12 + 10) * 100 - 1000; btype[t_] = 80; bxtype[t_] = 0; bco++;


                //リフト
                srco = 0;
                t_ = srco; sra[t_] = 33 * 29 * 100; srb[t_] = (3 * 29 - 12) * 100; src[t_] = 90 * 100; srtype[t_] = 0; sracttype[t_] = 0; sre[t_] = 0; srsp[t_] = 1; srco++;
                t_ = srco; sra[t_] = 39 * 29 * 100 - 2000; srb[t_] = (6 * 29 - 12) * 100; src[t_] = 90 * 100; srtype[t_] = 0; sracttype[t_] = 1; sre[t_] = 0; srco++;
                t_ = srco; sra[t_] = 45 * 29 * 100 + 1500; srb[t_] = (10 * 29 - 12) * 100; src[t_] = 90 * 100; srtype[t_] = 0; sracttype[t_] = 0; sre[t_] = 0; srsp[t_] = 2; srco++;

                t_ = srco; sra[t_] = 95 * 29 * 100; srb[t_] = (7 * 29 - 12) * 100; src[t_] = 180 * 100; srtype[t_] = 0; sracttype[t_] = 0; sre[t_] = 0; srsp[t_] = 10; srco++;
                t_ = srco; sra[t_] = 104 * 29 * 100; srb[t_] = (9 * 29 - 12) * 100; src[t_] = 90 * 100; srtype[t_] = 0; sracttype[t_] = 0; sre[t_] = 0; srsp[t_] = 12; srco++;
                t_ = srco; sra[t_] = 117 * 29 * 100; srb[t_] = (3 * 29 - 12) * 100; src[t_] = 90 * 100; srtype[t_] = 0; sracttype[t_] = 1; sre[t_] = 0; srsp[t_] = 15; srco++;
                t_ = srco; sra[t_] = 124 * 29 * 100; srb[t_] = (5 * 29 - 12) * 100; src[t_] = 210 * 100; srtype[t_] = 0; sracttype[t_] = 0; sre[t_] = 0; srsp[t_] = 10; srco++;



                if (stagepoint == 1) { stagepoint = 0; ma = 4500; mb = -3000; tyuukan = 0; }


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
                ma = 6000; mb = 6000;
                stagecolor = 2;


                byte[][] stagedatex = stagedatex6;


                tco = 0;

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
                ma = 3000; mb = 33000;

                stagepoint = 1;

                byte[][] stagedatex = stagedatex7;

                sco = 0;
                t_ = sco; sa[t_] = 14 * 29 * 100 - 5; sb[t_] = (11 * 29 - 12) * 100; sc[t_] = 6000; sd[t_] = 15000 - 200; stype[t_] = 50; sxtype[t_] = 1; sco++;


                txtype[tco] = 0; tyobi(12 * 29, 4 * 29 - 12, 112);
                //ヒント3
                txtype[tco] = 3; tyobi(12 * 29, 8 * 29 - 12, 300);
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
                ma = 12000; mb = 6000;
                stagecolor = 4;


                byte[][] stagedatex = stagedatex8;

                sco = 0;//sco=140;
                t_ = sco; sa[t_] = 35 * 29 * 100 - 1500 + 750; sb[t_] = (8 * 29 - 12) * 100 - 1500; sc[t_] = 1500; sd[t_] = 3000; stype[t_] = 105; sco++;
                t_ = sco; sa[t_] = 67 * 29 * 100; sb[t_] = (4 * 29 - 12) * 100; sc[t_] = 9000 - 1; sd[t_] = 3000 * 1 - 1; stype[t_] = 51; sxtype[t_] = 3; sgtype[t_] = 0; sco++;
                t_ = sco; sa[t_] = 73 * 29 * 100; sb[t_] = (13 * 29 - 12) * 100; sc[t_] = 3000 * 1 - 1; sd[t_] = 3000; stype[t_] = 52; sco++;
                t_ = sco; sa[t_] = 123 * 29 * 100; sb[t_] = (1 * 29 - 12) * 100; sc[t_] = 30 * 6 * 100 - 1 + 0; sd[t_] = 3000 - 200; stype[t_] = 51; sxtype[t_] = 10; sco++;
                //スクロール消し
                t_ = sco; sa[t_] = 124 * 29 * 100 + 3000; sb[t_] = (2 * 29 - 12) * 100; sc[t_] = 3000 * 1 - 1; sd[t_] = 300000; stype[t_] = 102; sxtype[t_] = 20; sco++;
                t_ = sco; sa[t_] = 148 * 29 * 100 + 1000; sb[t_] = (-12 * 29 - 12) * 100; sc[t_] = 3000 * 1 - 1; sd[t_] = 300000; stype[t_] = 102; sxtype[t_] = 30; sco++;

                //3連星
                t_ = sco; sa[t_] = 100 * 29 * 100 + 1000; sb[t_] = -6000; sc[t_] = 3000; sd[t_] = 70000; stype[t_] = 102; sxtype[t_] = 12; sco++;

                //地面1
                t_ = sco; sa[t_] = 0 * 29 * 100 - 0; sb[t_] = 9 * 29 * 100 + 1700; sc[t_] = 3000 * 7 - 1; sd[t_] = 3000 * 5 - 1; stype[t_] = 200; sxtype[t_] = 0; sco++;
                t_ = sco; sa[t_] = 11 * 29 * 100; sb[t_] = -1 * 29 * 100 + 1700; sc[t_] = 3000 * 8 - 1; sd[t_] = 3000 * 4 - 1; stype[t_] = 200; sxtype[t_] = 0; sco++;


                bco = 0;
                t_ = bco; ba[t_] = 8 * 29 * 100 - 1400; bb[t_] = (2 * 29 - 12) * 100 + 500; btype[t_] = 86; bxtype[t_] = 0; bco++;
                t_ = bco; ba[t_] = 42 * 29 * 100 - 1400; bb[t_] = (-2 * 29 - 12) * 100 + 500; btype[t_] = 86; bxtype[t_] = 0; bco++;
                t_ = bco; ba[t_] = 29 * 29 * 100 + 1500; bb[t_] = (7 * 29 - 12) * 100 + 1500; btype[t_] = 87; bxtype[t_] = 105; bco++;
                t_ = bco; ba[t_] = 47 * 29 * 100 + 1500; bb[t_] = (9 * 29 - 12) * 100 + 1500; btype[t_] = 87; bxtype[t_] = 110; bco++;
                t_ = bco; ba[t_] = 70 * 29 * 100 + 1500; bb[t_] = (9 * 29 - 12) * 100 + 1500; btype[t_] = 87; bxtype[t_] = 105; bco++;
                t_ = bco; ba[t_] = 66 * 29 * 100 + 1501; bb[t_] = (4 * 29 - 12) * 100 + 1500; btype[t_] = 87; bxtype[t_] = 101; bco++;
                t_ = bco; ba[t_] = 85 * 29 * 100 + 1501; bb[t_] = (4 * 29 - 12) * 100 + 1500; btype[t_] = 87; bxtype[t_] = 105; bco++;

                //ステルスうめぇ
                t_ = bco; ba[t_] = 57 * 29 * 100; bb[t_] = (2 * 29 - 12 + 10) * 100 - 500; btype[t_] = 80; bxtype[t_] = 1; bco++;
                //ブロックもどき
                t_ = bco; ba[t_] = 77 * 29 * 100; bb[t_] = (5 * 29 - 12) * 100; btype[t_] = 82; bxtype[t_] = 2; bco++;
                //ボス
                t_ = bco; ba[t_] = 130 * 29 * 100; bb[t_] = (8 * 29 - 12) * 100; btype[t_] = 30; bxtype[t_] = 0; bco++;
                //クックル
                t_ = bco; ba[t_] = 142 * 29 * 100; bb[t_] = (10 * 29 - 12) * 100; btype[t_] = 31; bxtype[t_] = 0; bco++;

                //マグマ
                nco = 0;
                na[nco] = 7 * 29 * 100 - 300; nb[nco] = 14 * 29 * 100 - 1200; ntype[nco] = 6; nco++; if (nco >= nmax) nco = 0;
                na[nco] = 41 * 29 * 100 - 300; nb[nco] = 14 * 29 * 100 - 1200; ntype[nco] = 6; nco++; if (nco >= nmax) nco = 0;
                na[nco] = 149 * 29 * 100 - 1100; nb[nco] = 10 * 29 * 100 - 600; ntype[nco] = 100; nco++; if (nco >= nmax) nco = 0;

                tco = 0;
                //ON-OFFブロック
                txtype[tco] = 1; tyobi(29 * 29, 3 * 29 - 12, 130);
                //1-2
                tyobi(34 * 29, 9 * 29 - 12, 5);

                tyobi(35 * 29, 9 * 29 - 12, 5);
                //隠し
                tyobi(55 * 29 + 15, 6 * 29 - 12, 7);
                //tyobi(62*29,9*29-12,2);
                //隠しON-OFF
                txtype[tco] = 10; tyobi(50 * 29, 9 * 29 - 12, 114);
                //ヒント3
                txtype[tco] = 5; tyobi(1 * 29, 5 * 29 - 12, 300);
                //ファイア
                txtype[tco] = 3;

                tyobi(86 * 29, 9 * 29 - 12, 101);
                //キノコなし　普通
                //txtype[tco]=2;tyobi(81*29,1*29-12,5);
                //音符
                txtype[tco] = 2;

                tyobi(86 * 29, 6 * 29 - 12, 117);

                //もろいぶろっく×３
                for (t_ = 0; t_ <= 2; t_++)
                {
                    txtype[tco] = 3; tyobi((79 + t_) * 29, 13 * 29 - 12, 115);
                }

                //ジャンプ
                txtype[tco] = 3; tyobi(105 * 29, 11 * 29 - 12, 120);
                //毒1
                txtype[tco] = 3; tyobi(109 * 29, 7 * 29 - 12, 102);
                //デフラグ
                txtype[tco] = 4; tyobi(111 * 29, 7 * 29 - 12, 101);
                //剣
                tyobi(132 * 29, 8 * 29 - 12 - 3, 140);

                tyobi(131 * 29, 9 * 29 - 12, 141);
                //メロン
                tyobi(161 * 29, 12 * 29 - 12, 142);
                //ファイアバー強化
                tyobi(66 * 29, 4 * 29 - 12, 124);


                //リフト
                srco = 0;
                t_ = srco; sra[t_] = 93 * 29 * 100; srb[t_] = (10 * 29 - 12) * 100; src[t_] = 60 * 100; srtype[t_] = 0; sracttype[t_] = 1; sre[t_] = 0; srco++;
                t_ = 20; sra[t_] = 119 * 29 * 100 + 300; srb[t_] = (10 * 29 - 12) * 100; src[t_] = 12 * 30 * 100 + 1000; srtype[t_] = 0; sracttype[t_] = 0; srsp[t_] = 21; sre[t_] = 0; srco++;


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
                mb = 32000;

                bgmchange(nオーディオ_[100]);
                stagecolor = 1;
                scrollx = 2900 * (113 - 19);
                //
                byte[][] stagedatex = stagedatex9;
                //追加情報
                tco = 0;
                //
                txtype[tco] = 6;

                tyobi(1 * 29, 9 * 29 - 12, 300);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(40 * 29, 9 * 29 - 12, 110);
                tco += 1;
                //
                txtype[tco] = 7;

                tyobi(79 * 29, 7 * 29 - 12, 300);
                tco += 1;
                //
                txtype[tco] = 2;

                tyobi(83 * 29, 7 * 29 - 12, 102);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(83 * 29, 2 * 29 - 12, 114);
                tco += 1;
                //
                for (int i = -1; i > -7; i -= 1)
                {

                    tyobi(85 * 29, i * 29 - 12, 4);
                    tco += 1;
                }
                //
                sco = 0;
                sa[sco] = 30 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 12000 - 1;
                sd[sco] = 3000;
                stype[sco] = 52;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 51 * 29 * 100;
                sb[sco] = (4 * 29 - 12) * 100;
                sc[sco] = 9000 - 1;
                sd[sco] = 3000;
                stype[sco] = 51;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 84 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 9000 - 1;
                sd[sco] = 3000;
                stype[sco] = 52;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 105 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 15000 - 1;
                sd[sco] = 3000;
                stype[sco] = 52;
                sxtype[sco] = 0;
                sco += 1;
                //
                bco = 0;
                //
                ba[bco] = 6 * 29 * 100;
                bb[bco] = (3 * 29 - 12) * 100;
                btype[bco] = 80;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 13 * 29 * 100;
                bb[bco] = (6 * 29 - 12) * 100;
                btype[bco] = 4;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 23 * 29 * 100;
                bb[bco] = (7 * 29 - 12) * 100;
                btype[bco] = 80;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 25 * 29 * 100;
                bb[bco] = (7 * 29 - 12) * 100;
                btype[bco] = 80;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 27 * 29 * 100;
                bb[bco] = (7 * 29 - 12) * 100;
                btype[bco] = 80;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 88 * 29 * 100;
                bb[bco] = (12 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
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
                sa[sco] = 14 * 29 * 100 + 200;
                sb[sco] = -6000;
                sc[sco] = 5000;
                sd[sco] = 70000;
                stype[sco] = 100;
                sco += 1;
                //
                sa[sco] = 12 * 29 * 100 + 1200;
                sb[sco] = -6000;
                sc[sco] = 7000;
                sd[sco] = 70000;
                stype[sco] = 101;
                sco += 1;
                //
                sa[sco] = 12 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 6000 - 1;
                sd[sco] = 3000;
                stype[sco] = 52;
                sgtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 14 * 29 * 100;
                sb[sco] = (9 * 29 - 12) * 100;
                sc[sco] = 6000;
                sd[sco] = 12000 - 200;
                stype[sco] = 50;
                sxtype[sco] = 1;
                sco += 1;
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
                ma = 7500; mb = 9000;
                scrollx = 2900 * (137 - 19);
                //
                byte[][] stagedatex = stagedatex11;
                //
                bco = 0;
                ba[bco] = 32 * 29 * 100 - 1400;
                bb[bco] = (-2 * 29 - 12) * 100 + 500;
                btype[bco] = 86;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = (31 * 29 - 12) * 100;
                bb[bco] = (7 * 29 - 12) * 100;
                btype[bco] = 7;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 38 * 29 * 100 + 1500;
                bb[bco] = (6 * 29 - 12) * 100 + 1500;
                btype[bco] = 87;
                bxtype[bco] = 107;
                bco += 1;
                //
                ba[bco] = 38 * 29 * 100 + 1500;
                bb[bco] = (6 * 29 - 12) * 100 + 1500;
                btype[bco] = 88;
                bxtype[bco] = 107;
                bco += 1;
                //
                ba[bco] = 42 * 29 * 100 + 1500;
                bb[bco] = (6 * 29 - 12) * 100 + 1500;
                btype[bco] = 87;
                bxtype[bco] = 107;
                bco += 1;
                //
                ba[bco] = 42 * 29 * 100 + 1500;
                bb[bco] = (6 * 29 - 12) * 100 + 1500;
                btype[bco] = 88;
                bxtype[bco] = 107;
                bco += 1;
                //
                ba[bco] = 46 * 29 * 100 + 1500;
                bb[bco] = (6 * 29 - 12) * 100 + 1500;
                btype[bco] = 87;
                bxtype[bco] = 107;
                bco += 1;
                //
                ba[bco] = 46 * 29 * 100 + 1500;
                bb[bco] = (6 * 29 - 12) * 100 + 1500;
                btype[bco] = 88;
                bxtype[bco] = 107;
                bco += 1;
                //
                ba[bco] = 58 * 29 * 100;
                bb[bco] = (7 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 66 * 29 * 100;
                bb[bco] = (7 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 76 * 29 * 100 - 1400;
                bb[bco] = (-2 * 29 - 12) * 100 + 500;
                btype[bco] = 86;
                bxtype[bco] = 0;
                bco += 1;
                //
                sco = 0;
                sa[sco] = 2 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 300000 - 6001;
                sd[sco] = 3000;
                stype[sco] = 52;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 3 * 29 * 100;
                sb[sco] = (7 * 29 - 12) * 100;
                sc[sco] = 3000;
                sd[sco] = 3000;
                stype[sco] = 105;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 107 * 29 * 100;
                sb[sco] = (9 * 29 - 12) * 100;
                sc[sco] = 9000 - 1;
                sd[sco] = 24000;
                stype[sco] = 52;
                sxtype[sco] = 1;
                sco += 1;
                //
                sa[sco] = 111 * 29 * 100;
                sb[sco] = (7 * 29 - 12) * 100;
                sc[sco] = 3000;
                sd[sco] = 6000 - 200;
                stype[sco] = 40;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 113 * 29 * 100 + 1100;
                sb[sco] = (0 * 29 - 12) * 100;
                sc[sco] = 4700;
                sd[sco] = 27000 - 1000;
                stype[sco] = 0;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 128 * 29 * 100;
                sb[sco] = (9 * 29 - 12) * 100;
                sc[sco] = 9000 - 1;
                sd[sco] = 24000;
                stype[sco] = 52;
                sxtype[sco] = 1;
                sco += 1;
                //
                sa[sco] = 131 * 29 * 100;
                sb[sco] = (9 * 29 - 12) * 100;
                sc[sco] = 3000;
                sd[sco] = 6000 - 200;
                stype[sco] = 40;
                sxtype[sco] = 2;
                sco += 1;
                //
                sa[sco] = 133 * 29 * 100 + 1100;
                sb[sco] = (0 * 29 - 12) * 100;
                sc[sco] = 4700;
                sd[sco] = 32000;
                stype[sco] = 0;
                sxtype[sco] = 0;
                sco += 1;
                //
                tco = 0;
                txtype[tco] = 0;

                tyobi(0 * 29, 0 * 29 - 12, 4);
                tco = 1;
                txtype[tco] = 0;

                tyobi(2 * 29, 9 * 29 - 12, 4);
                tco = 2;
                txtype[tco] = 0;

                tyobi(3 * 29, 9 * 29 - 12, 4);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(5 * 29, 9 * 29 - 12, 115);
                tco += 1;
                txtype[tco] = 1;

                tyobi(6 * 29, 9 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(5 * 29, 10 * 29 - 12, 115);
                tco += 1;
                txtype[tco] = 1;

                tyobi(6 * 29, 10 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(5 * 29, 11 * 29 - 12, 115);
                tco += 1;
                txtype[tco] = 1;

                tyobi(6 * 29, 11 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(5 * 29, 12 * 29 - 12, 115);
                tco += 1;
                txtype[tco] = 1;

                tyobi(6 * 29, 12 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(70 * 29, 7 * 29 - 12, 115);
                tco += 1;
                txtype[tco] = 1;

                tyobi(71 * 29, 7 * 29 - 12, 115);
                tco += 1;
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
                mb = 3000 * 9;
                //
                byte[][] stagedatex = stagedatex12;
                //
                bco = 0;
                ba[bco] = 9 * 29 * 100;
                bb[bco] = (12 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 10 * 29 * 100;
                bb[bco] = (11 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 11 * 29 * 100;
                bb[bco] = (10 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 12 * 29 * 100;
                bb[bco] = (9 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 13 * 29 * 100;
                bb[bco] = (8 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 14 * 29 * 100;
                bb[bco] = (7 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 15 * 29 * 100;
                bb[bco] = (6 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 16 * 29 * 100;
                bb[bco] = (5 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 17 * 29 * 100;
                bb[bco] = (5 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 18 * 29 * 100;
                bb[bco] = (5 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 19 * 29 * 100;
                bb[bco] = (5 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 20 * 29 * 100;
                bb[bco] = (5 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
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
                mb = 3000 * 8;

                bgmchange(nオーディオ_[100]);
                stagecolor = 1;
                scrollx = 2900 * (126 - 19);
                //
                byte[][] stagedatex = stagedatex13;
                //
                tco = 0;
                txtype[tco] = 0;
                for (int i = -1; i > -7; i -= 1)
                {

                    tyobi(55 * 29, i * 29 - 12, 4);
                    tco += 1;
                }
                //
                txtype[tco] = 0;

                tyobi(64 * 29, 12 * 29 - 12, 120);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(66 * 29, 3 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(67 * 29, 3 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(68 * 29, 3 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 8;

                tyobi(60 * 29, 6 * 29 - 12, 300);
                tco += 1;
                bco = 1;
                ba[bco] = (54 * 29 - 12) * 100;
                bb[bco] = (1 * 29 - 12) * 100;
                btype[bco] = 80;
                bxtype[bco] = 0;
                bco += 1;
                //
                sco = 0;
                ba[sco] = (102 * 29 - 12) * 100;
                bb[sco] = (10 * 29 - 12) * 100;
                btype[sco] = 50;
                bxtype[sco] = 1;
                sco += 1;
                //
                srco = 0;
                sra[srco] = 1 * 29 * 100;
                srb[srco] = (10 * 29 - 12) * 100;
                src[srco] = 5 * 3000;
                srtype[srco] = 0;
                sracttype[srco] = 1;
                sre[srco] = 0;
                srsp[srco] = 10;
                srco++;
                //
                sra[srco] = 18 * 29 * 100;
                srb[srco] = (4 * 29 - 12) * 100;
                src[srco] = 3 * 3000;
                srtype[srco] = 0;
                sracttype[srco] = 0;
                sre[srco] = 0;
                srsp[srco] = 10;
                srco++;
                //
                sra[srco] = 35 * 29 * 100;
                srb[srco] = (4 * 29 - 12) * 100;
                src[srco] = 5 * 3000;
                srtype[srco] = 0;
                sracttype[srco] = 0;
                sre[srco] = 0;
                srsp[srco] = 10;
                srco++;
                //
                sra[srco] = 35 * 29 * 100;
                srb[srco] = (8 * 29 - 12) * 100;
                src[srco] = 5 * 3000;
                srtype[srco] = 0;
                sracttype[srco] = 0;
                sre[srco] = 0;
                srsp[srco] = 10;
                srco++;
                //
                sra[srco] = 94 * 29 * 100;
                srb[srco] = (6 * 29 - 12) * 100;
                src[srco] = 3 * 3000;
                srtype[srco] = 0;
                sracttype[srco] = 0;
                sre[srco] = 0;
                srsp[srco] = 1;
                srco++;
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
                    mb = 3000 * 4;
                }
                else {
                    ma = 19500;
                    mb = 3000 * 11;
                    stc = 0;
                }

                bgmchange(nオーディオ_[105]);
                stagecolor = 4;
                scrollx = 2900 * (40 - 19);
                //
                byte[][] stagedatex = stagedatex14;
                //
                tco = 0;
                txtype[tco] = 0;

                tyobi(0 * 29, -1 * 29 - 12, 5);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(4 * 29, -1 * 29 - 12, 5);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(1 * 29, 14 * 29 - 12, 5);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(6 * 29, 14 * 29 - 12, 5);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(7 * 29, 14 * 29 - 12, 5);
                tco += 1;
                //
                bco = 0;
                ba[bco] = 2 * 29 * 100 - 1400;
                bb[bco] = (-2 * 29 - 12) * 100 + 500;
                btype[bco] = 86;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 20 * 29 * 100 + 1500;
                bb[bco] = (5 * 29 - 12) * 100 + 1500;
                btype[bco] = 87;
                bxtype[bco] = 107;
                bco += 1;
                //
                sco = 0;
                sa[sco] = 17 * 29 * 100;
                sb[sco] = (9 * 29 - 12) * 100;
                sc[sco] = 21000 - 1;
                sd[sco] = 3000 - 1;
                stype[sco] = 52;
                sxtype[sco] = 2;
                sco += 1;
                //
                sa[sco] = 27 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 6000;
                sd[sco] = 6000;
                stype[sco] = 50;
                sxtype[sco] = 6;
                sco += 1;
                //
                sa[sco] = 34 * 29 * 100;
                sb[sco] = (5 * 29 - 12) * 100;
                sc[sco] = 6000;
                sd[sco] = 30000;
                stype[sco] = 50;
                sxtype[sco] = 1;
                sco += 1;
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
                mb = 3000 * 11;

                bgmchange(nオーディオ_[105]);
                stagecolor = 4;
                scrollx = 2900 * (21 - 19);
                //
                byte[][] stagedatex = stagedatex15;
                //
                tco = 0;
                txtype[tco] = 1;

                tyobi(12 * 29, 13 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(13 * 29, 13 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(14 * 29, 13 * 29 - 12, 115);
                tco += 1;
                //
                sco = 0;
                sa[sco] = 6 * 29 * 100;
                sb[sco] = (6 * 29 - 12) * 100;
                sc[sco] = 18000 - 1;
                sd[sco] = 6000 - 1;
                stype[sco] = 52;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 12 * 29 * 100;
                sb[sco] = (8 * 29 - 12) * 100;
                sc[sco] = 9000 - 1;
                sd[sco] = 3000 - 1;
                stype[sco] = 52;
                sxtype[sco] = 2;
                sco += 1;
                //
                sa[sco] = 15 * 29 * 100;
                sb[sco] = (11 * 29 - 12) * 100;
                sc[sco] = 3000;
                sd[sco] = 6000;
                stype[sco] = 40;
                sxtype[sco] = 2;
                sco += 1;
                //
                sa[sco] = 17 * 29 * 100 + 1100;
                sb[sco] = (0 * 29 - 12) * 100;
                sc[sco] = 4700;
                sd[sco] = 38000;
                stype[sco] = 0;
                sxtype[sco] = 0;
                sco += 1;
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
                mb = 3000 * 11;

                bgmchange(nオーディオ_[105]);
                stagecolor = 4;
                scrollx = 2900 * (128 - 19);
                //
                byte[][] stagedatex = stagedatex16;
                //
                tco = 0;
                txtype[tco] = 0;

                tyobi(1 * 29, 14 * 29 - 12, 5);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(2 * 29, 14 * 29 - 12, 5);
                tco += 1;
                //
                txtype[tco] = 9;

                tyobi(3 * 29, 4 * 29 - 12, 300);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(32 * 29, 9 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(76 * 29, 14 * 29 - 12, 5);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(108 * 29, 11 * 29 - 12, 141);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(109 * 29, 10 * 29 - 12 - 3, 140);
                tco += 1;
                //
                txtype[tco] = 0;

                tyobi(121 * 29, 10 * 29 - 12, 142);
                tco += 1;
                //
                bco = 0;
                ba[bco] = 0 * 29 * 100 + 1500;
                bb[bco] = (8 * 29 - 12) * 100 + 1500;
                btype[bco] = 88;
                bxtype[bco] = 105;
                bco += 1;
                //
                ba[bco] = 2 * 29 * 100;
                bb[bco] = (0 * 29 - 12) * 100;
                btype[bco] = 80;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 3 * 29 * 100 + 1500;
                bb[bco] = (8 * 29 - 12) * 100 + 1500;
                btype[bco] = 87;
                bxtype[bco] = 105;
                bco += 1;
                //
                ba[bco] = 6 * 29 * 100 + 1500;
                bb[bco] = (8 * 29 - 12) * 100 + 1500;
                btype[bco] = 88;
                bxtype[bco] = 107;
                bco += 1;
                //
                ba[bco] = 9 * 29 * 100 + 1500;
                bb[bco] = (8 * 29 - 12) * 100 + 1500;
                btype[bco] = 88;
                bxtype[bco] = 107;
                bco += 1;
                //
                ba[bco] = 25 * 29 * 100 - 1400;
                bb[bco] = (2 * 29 - 12) * 100 - 400;
                btype[bco] = 86;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 40 * 29 * 100;
                bb[bco] = (8 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 42 * 29 * 100;
                bb[bco] = (8 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 43 * 29 * 100 + 1500;
                bb[bco] = (6 * 29 - 12) * 100 + 1500;
                btype[bco] = 88;
                bxtype[bco] = 105;
                bco += 1;
                //
                ba[bco] = 47 * 29 * 100 + 1500;
                bb[bco] = (6 * 29 - 12) * 100 + 1500;
                btype[bco] = 87;
                bxtype[bco] = 105;
                bco += 1;
                //
                ba[bco] = 57 * 29 * 100;
                bb[bco] = (7 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 77 * 29 * 100 - 1400;
                bb[bco] = (2 * 29 - 12) * 100 - 400;
                btype[bco] = 86;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 83 * 29 * 100 - 1400;
                bb[bco] = (2 * 29 - 12) * 100 - 400;
                btype[bco] = 86;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 88 * 29 * 100 + 1500;
                bb[bco] = (9 * 29 - 12) * 100 + 1500;
                btype[bco] = 87;
                bxtype[bco] = 105;
                bco += 1;
                //
                ba[bco] = 88 * 29 * 100 + 1500;
                bb[bco] = (9 * 29 - 12) * 100 + 1500;
                btype[bco] = 88;
                bxtype[bco] = 105;
                bco += 1;
                //
                ba[bco] = 90 * 29 * 100;
                bb[bco] = (9 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 0;
                bco += 1;
                //
                ba[bco] = 107 * 29 * 100;
                bb[bco] = (10 * 29 - 12) * 100;
                btype[bco] = 30;
                bxtype[bco] = 0;
                bco += 1;
                //
                sco = 0;
                sa[sco] = 13 * 29 * 100;
                sb[sco] = (8 * 29 - 12) * 100;
                sc[sco] = 33000 - 1;
                sd[sco] = 3000 - 1;
                stype[sco] = 52;
                sxtype[sco] = 2;
                sco += 1;
                //
                sa[sco] = 13 * 29 * 100;
                sb[sco] = (0 * 29 - 12) * 100;
                sc[sco] = 33000 - 1;
                sd[sco] = 3000 - 1;
                stype[sco] = 51;
                sxtype[sco] = 3;
                sco += 1;
                //
                sa[sco] = 10 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 6000;
                sd[sco] = 6000;
                stype[sco] = 50;
                sxtype[sco] = 6;
                sco += 1;
                //
                sa[sco] = 46 * 29 * 100;
                sb[sco] = (12 * 29 - 12) * 100;
                sc[sco] = 9000 - 1;
                sd[sco] = 3000 - 1;
                stype[sco] = 52;
                sxtype[sco] = 2;
                sco += 1;
                //
                sa[sco] = 58 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 6000;
                sd[sco] = 6000;
                stype[sco] = 50;
                sxtype[sco] = 6;
                sco += 1;
                //
                sa[sco] = 101 * 29 * 100 - 1500;
                sb[sco] = (10 * 29 - 12) * 100 - 3000;
                sc[sco] = 12000;
                sd[sco] = 12000;
                stype[sco] = 104;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 102 * 29 * 100 + 3000;
                sb[sco] = (2 * 29 - 12) * 100;
                sc[sco] = 3000 - 1;
                sd[sco] = 300000;
                stype[sco] = 102;
                sxtype[sco] = 20;
                sco += 1;
                //
                srco = 0;
                sra[srco] = 74 * 29 * 100 - 1500;
                srb[srco] = (7 * 29 - 12) * 100;
                src[srco] = 2 * 3000;
                srtype[srco] = 0;
                sracttype[srco] = 1;
                sre[srco] = 0;
                srsp[srco] = 0;
                srco = 20;
                //
                sra[srco] = 97 * 29 * 100;
                srb[srco] = (12 * 29 - 12) * 100;
                src[srco] = 12 * 3000;
                srtype[srco] = 0;
                sracttype[srco] = 0;
                sre[srco] = 0;
                srsp[srco] = 21;
                srco += 1;
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
                mb = 32000;

                bgmchange(nオーディオ_[100]);
                stagecolor = 5;
                scrollx = 2900 * (112 - 19);
                byte[][] stagedatex = stagedatex17;
                //追加情報
                tco = 0;
                //
                txtype[tco] = 10;

                tyobi(2 * 29, 9 * 29 - 12, 300);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(63 * 29, 13 * 29 - 12, 115);
                tco += 1;
                //
                txtype[tco] = 1;

                tyobi(64 * 29, 13 * 29 - 12, 115);
                tco += 1;
                //
                sco = 0;
                sa[sco] = 13 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 9000 - 1;
                sd[sco] = 3000;
                stype[sco] = 52;
                sxtype[sco] = 0;
                sco += 1;
                //
                sa[sco] = 84 * 29 * 100;
                sb[sco] = (13 * 29 - 12) * 100;
                sc[sco] = 9000 - 1;
                sd[sco] = 3000;
                stype[sco] = 52;
                sxtype[sco] = 0;
                sco += 1;
                //
                bco = 0;
                ba[bco] = 108 * 29 * 100;
                bb[bco] = (6 * 29 - 12) * 100;
                btype[bco] = 6;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 33 * 29 * 100;
                bb[bco] = (10 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 36 * 29 * 100;
                bb[bco] = (0 * 29 - 12) * 100;
                btype[bco] = 80;
                bxtype[bco] = 1;
                bco += 1;
                //
                ba[bco] = 78 * 29 * 100 + 1500;
                bb[bco] = (7 * 29 - 12) * 100 + 1500;
                btype[bco] = 88;
                bxtype[bco] = 105;
                bco += 1;
                //
                ba[bco] = 80 * 29 * 100 + 1500;
                bb[bco] = (7 * 29 - 12) * 100 + 1500;
                btype[bco] = 87;
                bxtype[bco] = 105;
                bco += 1;
                //
                ba[bco] = 85 * 29 * 100;
                bb[bco] = (11 * 29 - 12) * 100;
                btype[bco] = 82;
                bxtype[bco] = 1;
                bco += 1;
                //
                srco = 0;
                sra[srco] = 41 * 29 * 100;
                srb[srco] = (3 * 29 - 12) * 100;
                src[srco] = 3 * 3000;
                srtype[srco] = 0;
                sracttype[srco] = 0;
                sre[srco] = 0;
                srsp[srco] = 3;
                srco = 0;
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

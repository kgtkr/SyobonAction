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
        static void stagecls()
        {
            for (t = 0; t < smax; t++) { sa[t] = -9000000; sb[t] = 1; sc[t] = 1; sd[t] = 1; sgtype[t] = 0; stype[t] = 0; sxtype[t] = 0; }
            for (t = 0; t < tmax; t++) { ta[t] = -9000000; tb[t] = 1; tc[t] = 1; td[t] = 1; titem[t] = 0; txtype[t] = 0; }
            for (t = 0; t < srmax; t++) { sra[t] = -9000000; srb[t] = 1; src[t] = 1; srd[t] = 1; sre[t] = 0; srf[t] = 0; srmuki[t] = 0; sron[t] = 0; sree[t] = 0; srsok[t] = 0; srmove[t] = 0; srmovep[t] = 0; srsp[t] = 0; }
            for (t = 0; t < amax; t++) { aa[t] = -9000000; ab[t] = 1; ac[t] = 0; ad[t] = 1; azimentype[t] = 0; atype[t] = 0; axtype[t] = 0; ae[t] = 0; af[t] = 0; atm[t] = 0; a2tm[t] = 0; abrocktm[t] = 0; amsgtm[t] = 0; }
            for (t = 0; t < bmax; t++) { ba[t] = -9000000; bb[t] = 1; bz[t] = 1; btm[t] = 0; bxtype[t] = 0; }
            for (t = 0; t < emax; t++) { ea[t] = -9000000; eb[t] = 1; ec[t] = 1; ed[t] = 1; egtype[t] = 0; }
            for (t = 0; t < nmax; t++) {
                na[t] = -9000000;
                nb[t] = 1;
                nc[t] = 1;
                nd[t] = 1;
                ne[t] = 1;
                nf[t] = 1;
                ng[t] = 0;
                ntype[t] = 0;
            }
            

            sco = 0; tco = 0; aco = 0; bco = 0; eco = 0; nco = 0;
            //haikeitouroku();
        }//stagecls()

        //ステージロード
        static void stage()
        {

            //fzx=6000*100;
            scrollx = 3600 * 100;




            stagep();




            for (tt = 0; tt <= 1000; tt++)
            {
                for (t = 0; t <= 16; t++)
                {
                    xx[10] = 0;
                    if (stagedate[t,tt] >= 1 && stagedate[t,tt] <= 255) xx[10] = (int)stagedate[t,tt];
                    xx[21] = tt * 29; xx[22] = t * 29 - 12; xx[23] = xx[10];
                    if (xx[10] >= 1 && xx[10] <= 19 && xx[10] != 9) { tyobi(tt * 29, t * 29 - 12, xx[10]); }
                    if (xx[10] >= 20 && xx[10] <= 29) { sra[srco] = xx[21] * 100; srb[srco] = xx[22] * 100; src[srco] = 3000; srtype[srco] = 0; srco++; if (srco >= srmax) srco = 0; }
                    if (xx[10] == 30) { sa[sco] = xx[21] * 100; sb[sco] = xx[22] * 100; sc[sco] = 3000; sd[sco] = 6000; stype[sco] = 500; sco++; if (sco >= smax) sco = 0; }
                    if (xx[10] == 40) { sa[sco] = xx[21] * 100; sb[sco] = xx[22] * 100; sc[sco] = 6000; sd[sco] = 3000; stype[sco] = 1; sco++; if (sco >= smax) sco = 0; }
                    if (xx[10] == 41) { sa[sco] = xx[21] * 100 + 500; sb[sco] = xx[22] * 100; sc[sco] = 5000; sd[sco] = 3000; stype[sco] = 2; sco++; if (sco >= smax) sco = 0; }

                    if (xx[10] == 43) { sa[sco] = xx[21] * 100; sb[sco] = xx[22] * 100 + 500; sc[sco] = 2900; sd[sco] = 5300; stype[sco] = 1; sco++; if (sco >= smax) sco = 0; }
                    if (xx[10] == 44) { sa[sco] = xx[21] * 100; sb[sco] = xx[22] * 100 + 700; sc[sco] = 3900; sd[sco] = 5000; stype[sco] = 5; sco++; if (sco >= smax) sco = 0; }

                    //これなぜかバグの原因ｗ
                    if (xx[10] >= 50 && xx[10] <= 79)
                    {
                        ba[bco] = xx[21] * 100; bb[bco] = xx[22] * 100; btype[bco] = xx[23] - 50; bco++; if (bco >= bmax) bco = 0;
                    }

                    if (xx[10] >= 80 && xx[10] <= 89) { na[nco] = xx[21] * 100; nb[nco] = xx[22] * 100; ntype[nco] = xx[23] - 80; nco++; if (nco >= nmax) nco = 0; }

                    //コイン
                    if (xx[10] == 9) { tyobi(tt * 29, t * 29 - 12, 800); }
                    if (xx[10] == 99) { sa[sco] = xx[21] * 100; sb[sco] = xx[22] * 100; sc[sco] = 3000; sd[sco] = (12 - t) * 3000; stype[sco] = 300; sco++; if (sco >= smax) sco = 0; }
                }
            }

            if (tyuukan >= 1)
            {
                xx[17] = 0;
                for (t = 0; t < smax; t++)
                {
                    if (stype[t] == 500 && tyuukan >= 1)
                    {
                        fx = sa[t] - fxmax / 2; fzx = fx;
                        ma = sa[t] - fx;
                        mb = sb[t] - fy;
                        tyuukan--; xx[17]++;

                        sa[t] = -80000000;
                    }
                }
                tyuukan += xx[17];
            }
            //tyobi(1,2,3);



        }//stage()

        static void stagep()
        {

            //fzx=6000*100;
            scrollx = 3600 * 100;

            //byte stagedate[16][801];
            //byte stagedate2[16][801];


            //1-レンガ,2-コイン,3-空,4-土台//5-6地面//7-隠し//

            //1-1
            if (sta == 1 && stb == 1 && stc == 0)
            {

                //new byte stagedate[16][801]={

                //                                                                                                                                                                                     中間                                                                                                                                                                                                                                                           
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
                t = sco; sa[t] = 20 * 29 * 100 + 500; sb[t] = -6000; sc[t] = 5000; sd[t] = 70000; stype[t] = 100; sco++;
                t = sco; sa[t] = 54 * 29 * 100 - 500; sb[t] = -6000; sc[t] = 7000; sd[t] = 70000; stype[t] = 101; sco++;
                t = sco; sa[t] = 112 * 29 * 100 + 1000; sb[t] = -6000; sc[t] = 3000; sd[t] = 70000; stype[t] = 102; sco++;
                t = sco; sa[t] = 117 * 29 * 100; sb[t] = (2 * 29 - 12) * 100 - 1500; sc[t] = 15000; sd[t] = 3000; stype[t] = 103; sco++;
                t = sco; sa[t] = 125 * 29 * 100; sb[t] = -6000; sc[t] = 9000; sd[t] = 70000; stype[t] = 101; sco++;
                //t=sco;sa[t]=77*29*100;sb[t]=(6*29-12)*100-1500;sc[t]=12000;sd[t]=3000;stype[t]=103;sco++;
                t = 28; sa[t] = 29 * 29 * 100 + 500; sb[t] = (9 * 29 - 12) * 100; sc[t] = 6000; sd[t] = 12000 - 200; stype[t] = 50; sco++;
                t = sco; sa[t] = 49 * 29 * 100; sb[t] = (5 * 29 - 12) * 100; sc[t] = 9000 - 1; sd[t] = 3000; stype[t] = 51; sgtype[t] = 0; sco++;
                t = sco; sa[t] = 72 * 29 * 100; sb[t] = (13 * 29 - 12) * 100; sc[t] = 3000 * 5 - 1; sd[t] = 3000; stype[t] = 52; sco++;

                bco = 0;
                t = bco; ba[t] = 27 * 29 * 100; bb[t] = (9 * 29 - 12) * 100; btype[t] = 0; bxtype[t] = 0; bco++;
                t = bco; ba[t] = 103 * 29 * 100; bb[t] = (5 * 29 - 12 + 10) * 100; btype[t] = 80; bxtype[t] = 0; bco++;
                //t=bco;ba[t]=13*29*100;bb[t]=(5*29-12)*100;btype[t]=81;bxtype[t]=0;bco++;

                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }

            }//sta1


            //1-2(地上)
            if (sta == 1 && stb == 2 && stc == 0)
            {

                //マリ　地上　入れ
                //StopSoundMem(oto[0]);
                bgmchange(oto[100]);
                //PlaySoundMem(oto[0],DX_PLAYTYPE_LOOP) ;

                scrollx = 0 * 100;
                //ma=3000;mb=3000;

                byte[][] stagedatex = stagedatex2;



                tco = 0;
                //ヒント1
                txtype[tco] = 1; tyobi(4 * 29, 9 * 29 - 12, 300);
                //tyobi(7*29,9*29-12,300);

                //毒1
                tyobi(13 * 29, 8 * 29 - 12, 114);

                //t=28;
                sco = 0;
                t = sco; sa[t] = 14 * 29 * 100 + 500; sb[t] = (9 * 29 - 12) * 100; sc[t] = 6000; sd[t] = 12000 - 200; stype[t] = 50; sxtype[t] = 1; sco++;
                t = sco; sa[t] = 12 * 29 * 100; sb[t] = (11 * 29 - 12) * 100; sc[t] = 3000; sd[t] = 6000 - 200; stype[t] = 40; sxtype[t] = 0; sco++;
                t = sco; sa[t] = 14 * 29 * 100 + 1000; sb[t] = -6000; sc[t] = 5000; sd[t] = 70000; stype[t] = 100; sxtype[t] = 1; sco++;

                //ブロックもどき
                //t=bco;ba[t]=7*29*100;bb[t]=(9*29-12)*100;btype[t]=82;bxtype[t]=0;bco++;


                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }

            }//sta2


            //1-2-1(地下)
            if (sta == 1 && stb == 2 && stc == 1)
            {

                //マリ　地下　入れ
                bgmchange(oto[103]);

                scrollx = 4080 * 100;
                ma = 6000; mb = 3000;
                stagecolor = 2;


                byte[][] stagedatex = stagedatex3;



                tco = 0;
                txtype[tco] = 2; tyobi(7 * 29, 9 * 29 - 12, 102);

                tyobi(10 * 29, 9 * 29 - 12, 101);

                txtype[tco] = 2;

                tyobi(49 * 29, 9 * 29 - 12, 114);

                for (t = 0; t >= -7; t--)
                {

                    tyobi(53 * 29, t * 29 - 12, 1);
                }

                txtype[tco] = 1; tyobi(80 * 29, 5 * 29 - 12, 104);
                txtype[tco] = 2; tyobi(78 * 29, 5 * 29 - 12, 102);



                //txtype[tco]=1;tyobi(11*29,9*29-12,114);//毒1

                sco = 0;
                t = sco; sa[t] = 2 * 29 * 100; sb[t] = (13 * 29 - 12) * 100; sc[t] = 3000 * 1 - 1; sd[t] = 3000; stype[t] = 52; sco++;
                //t=sco;sa[t]=19*29*100;sb[t]=(13*29-12)*100;sc[t]=3000*1-1;sd[t]=3000;stype[t]=52;sco++;
                t = sco; sa[t] = 24 * 29 * 100; sb[t] = (13 * 29 - 12) * 100; sc[t] = 3000 * 1 - 1; sd[t] = 3000; stype[t] = 52; sco++;
                t = sco; sa[t] = 43 * 29 * 100 + 500; sb[t] = -6000; sc[t] = 3000; sd[t] = 70000; stype[t] = 102; sxtype[t] = 1; sco++;
                t = sco; sa[t] = 53 * 29 * 100 + 500; sb[t] = -6000; sc[t] = 3000; sd[t] = 70000; stype[t] = 102; sxtype[t] = 2; sco++;
                t = sco; sa[t] = 129 * 29 * 100; sb[t] = (7 * 29 - 12) * 100; sc[t] = 3000; sd[t] = 6000 - 200; stype[t] = 40; sxtype[t] = 2; sco++;
                t = sco; sa[t] = 154 * 29 * 100; sb[t] = 3000; sc[t] = 9000; sd[t] = 3000; stype[t] = 102; sxtype[t] = 7; sco++;

                //ブロックもどき

                t = 27; sa[t] = 69 * 29 * 100; sb[t] = (1 * 29 - 12) * 100; sc[t] = 9000 * 2 - 1; sd[t] = 3000; stype[t] = 51; sxtype[t] = 0; sgtype[t] = 0; sco++;
                t = 28; sa[t] = 66 * 29 * 100; sb[t] = (1 * 29 - 12) * 100; sc[t] = 9000 - 1; sd[t] = 3000; stype[t] = 51; sxtype[t] = 1; sgtype[t] = 0; sco++;
                t = 29; sa[t] = 66 * 29 * 100; sb[t] = (-2 * 29 - 12) * 100; sc[t] = 9000 * 3 - 1; sd[t] = 3000; stype[t] = 51; sxtype[t] = 2; sgtype[t] = 0; sco++;

                //26 ファイアー土管
                t = 26; sa[t] = 103 * 29 * 100 - 1500; sb[t] = (9 * 29 - 12) * 100 - 2000; sc[t] = 3000; sd[t] = 3000; stype[t] = 180; sxtype[t] = 0; sr[t] = 0; sgtype[t] = 48; sco++;
                t = sco; sa[t] = 102 * 29 * 100; sb[t] = (9 * 29 - 12) * 100; sc[t] = 6000; sd[t] = 12000 - 200; stype[t] = 50; sxtype[t] = 2; sco++;
                t = sco; sa[t] = 123 * 29 * 100; sb[t] = (9 * 29 - 12) * 100; sc[t] = 3000 * 5 - 1; sd[t] = 3000 * 5; stype[t] = 52; sxtype[t] = 1; sco++;

                t = sco; sa[t] = 131 * 29 * 100; sb[t] = (1 * 29 - 12) * 100; sc[t] = 4700; sd[t] = 3000 * 8 - 700; stype[t] = 1; sxtype[t] = 0; sco++;

                //t=sco;sa[t]=44*29*100;sb[t]=-6000;sc[t]=9000;sd[t]=70000;stype[t]=102;sco++;

                //オワタゾーン
                t = sco; sa[t] = 143 * 29 * 100; sb[t] = (9 * 29 - 12) * 100; sc[t] = 6000; sd[t] = 12000 - 200; stype[t] = 50; sxtype[t] = 5; sco++;
                t = sco; sa[t] = 148 * 29 * 100; sb[t] = (9 * 29 - 12) * 100; sc[t] = 6000; sd[t] = 12000 - 200; stype[t] = 50; sxtype[t] = 5; sco++;
                t = sco; sa[t] = 153 * 29 * 100; sb[t] = (9 * 29 - 12) * 100; sc[t] = 6000; sd[t] = 12000 - 200; stype[t] = 50; sxtype[t] = 5; sco++;



                bco = 0;
                t = bco; ba[t] = 18 * 29 * 100; bb[t] = (10 * 29 - 12) * 100; btype[t] = 82; bxtype[t] = 1; bco++;
                //t=bco;ba[t]=52*29*100;bb[t]=(2*29-12)*100;btype[t]=82;bxtype[t]=1;bco++;
                t = bco; ba[t] = 51 * 29 * 100 + 1000; bb[t] = (2 * 29 - 12 + 10) * 100; btype[t] = 80; bxtype[t] = 1; bco++;

                //？ボール
                t = bco; ba[t] = 96 * 29 * 100 + 100; bb[t] = (10 * 29 - 12) * 100; btype[t] = 105; bxtype[t] = 0; bco++;


                //リフト
                srco = 0;
                t = srco; sra[t] = 111 * 29 * 100; srb[t] = (8 * 29 - 12) * 100; src[t] = 90 * 100; srtype[t] = 0; sracttype[t] = 5; sre[t] = -300; srco++;
                t = srco; sra[t] = 111 * 29 * 100; srb[t] = (0 * 29 - 12) * 100; src[t] = 90 * 100; srtype[t] = 0; sracttype[t] = 5; sre[t] = -300; srco++;
                t = 10; sra[t] = 116 * 29 * 100; srb[t] = (4 * 29 - 12) * 100; src[t] = 90 * 100; srtype[t] = 1; sracttype[t] = 5; sre[t] = 300; srco++;
                t = 11; sra[t] = 116 * 29 * 100; srb[t] = (12 * 29 - 12) * 100; src[t] = 90 * 100; srtype[t] = 1; sracttype[t] = 5; sre[t] = 300; srco++;


                //ヒント1
                //tyobi(4*29,9*29-12,300);
                //tyobi(7*29,9*29-12,300);

                //毒1
                //tyobi(13*29,8*29-12,114);

                //t=28;
                //sco=0;
                //t=sco;
                //sa[t]=14*29*100+500;sb[t]=(9*29-12)*100;sc[t]=6000;sd[t]=12000-200;stype[t]=50;sxtype[t]=1;sco++;


                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }
                //stagedatex[0][0];

            }//sta1-2-1




            //1-2(地上)
            if (sta == 1 && stb == 2 && stc == 2)
            {

                //マリ　地上　入れ
                //StopSoundMem(oto[0]);
                bgmchange(oto[100]);
                //PlaySoundMem(oto[0],DX_PLAYTYPE_LOOP) ;

                scrollx = 900 * 100;
                ma = 7500; mb = 3000 * 9;

                byte[][] stagedatex = stagedatex4;


                /*
                //毒1
                tyobi(13*29,8*29-12,114);

                //t=28;
                sco=0;
                t=sco;sa[t]=14*29*100+500;sb[t]=(9*29-12)*100;sc[t]=6000;sd[t]=12000-200;stype[t]=50;sxtype[t]=1;sco++;
                t=sco;sa[t]=12*29*100;sb[t]=(11*29-12)*100;sc[t]=3000;sd[t]=6000-200;stype[t]=40;sxtype[t]=0;sco++;
                t=sco;sa[t]=14*29*100+1000;sb[t]=-6000;sc[t]=5000;sd[t]=70000;stype[t]=100;sxtype[t]=1;sco++;
                */

                t = sco; sa[t] = 5 * 29 * 100 + 500; sb[t] = -6000; sc[t] = 3000; sd[t] = 70000; stype[t] = 102; sxtype[t] = 8; sco++;
                //空飛ぶ土管
                t = 28; sa[t] = 44 * 29 * 100 + 500; sb[t] = (10 * 29 - 12) * 100; sc[t] = 6000; sd[t] = 9000 - 200; stype[t] = 50; sco++;

                //ポールもどき
                bco = 0;
                t = bco; ba[t] = 19 * 29 * 100; bb[t] = (2 * 29 - 12) * 100; btype[t] = 85; bxtype[t] = 0; bco++;


                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }

            }//sta2



            //必要BGM+SE

            //1-3(地上)
            if (sta == 1 && stb == 3 && stc == 6) { stc = 0; }
            if (sta == 1 && stb == 3 && stc == 0)
            {

                //StopSoundMem(oto[0]);
                bgmchange(oto[100]);
                //PlaySoundMem(oto[0],DX_PLAYTYPE_LOOP) ;

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
                //tyobi(7*29,9*29-12,101);


                bco = 0;
                t = bco; ba[t] = 101 * 29 * 100; bb[t] = (5 * 29 - 12) * 100; btype[t] = 4; bxtype[t] = 1; bco++;
                t = bco; ba[t] = 146 * 29 * 100; bb[t] = (10 * 29 - 12) * 100; btype[t] = 6; bxtype[t] = 1; bco++;

                t = sco; sa[t] = 9 * 29 * 100; sb[t] = (13 * 29 - 12) * 100; sc[t] = 9000 - 1; sd[t] = 3000; stype[t] = 52; sco++;
                //t=sco;sa[t]=58*29*100;sb[t]=(13*29-12)*100;sc[t]=9000-1;sd[t]=3000;stype[t]=52;sco++;

                //土管
                t = sco; sa[t] = 65 * 29 * 100 + 500; sb[t] = (10 * 29 - 12) * 100; sc[t] = 6000; sd[t] = 9000 - 200; stype[t] = 50; sxtype[t] = 1; sco++;
                //t=28;sa[t]=65*29*100;sb[t]=(10*29-12)*100;sc[t]=6000;sd[t]=9000-200;stype[t]=50;sco++;

                //トラップ
                t = sco; sa[t] = 74 * 29 * 100; sb[t] = (8 * 29 - 12) * 100 - 1500; sc[t] = 6000; sd[t] = 3000; stype[t] = 103; sxtype[t] = 1; sco++;
                t = sco; sa[t] = 96 * 29 * 100 - 3000; sb[t] = -6000; sc[t] = 9000; sd[t] = 70000; stype[t] = 102; sxtype[t] = 10; sco++;
                //ポール砲
                t = sco; sa[t] = 131 * 29 * 100 - 1500; sb[t] = (1 * 29 - 12) * 100 - 3000; sc[t] = 15000; sd[t] = 14000; stype[t] = 104; sco++;


                //？ボール
                t = bco; ba[t] = 10 * 29 * 100 + 100; bb[t] = (11 * 29 - 12) * 100; btype[t] = 105; bxtype[t] = 1; bco++;
                //ブロックもどき
                t = bco; ba[t] = 43 * 29 * 100; bb[t] = (11 * 29 - 12) * 100; btype[t] = 82; bxtype[t] = 1; bco++;
                //t=bco;ba[t]=146*29*100;bb[t]=(12*29-12)*100;btype[t]=82;bxtype[t]=1;bco++;
                //うめぇ
                t = bco; ba[t] = 1 * 29 * 100; bb[t] = (2 * 29 - 12 + 10) * 100 - 1000; btype[t] = 80; bxtype[t] = 0; bco++;


                //リフト
                srco = 0;
                t = srco; sra[t] = 33 * 29 * 100; srb[t] = (3 * 29 - 12) * 100; src[t] = 90 * 100; srtype[t] = 0; sracttype[t] = 0; sre[t] = 0; srsp[t] = 1; srco++;
                t = srco; sra[t] = 39 * 29 * 100 - 2000; srb[t] = (6 * 29 - 12) * 100; src[t] = 90 * 100; srtype[t] = 0; sracttype[t] = 1; sre[t] = 0; srco++;
                t = srco; sra[t] = 45 * 29 * 100 + 1500; srb[t] = (10 * 29 - 12) * 100; src[t] = 90 * 100; srtype[t] = 0; sracttype[t] = 0; sre[t] = 0; srsp[t] = 2; srco++;

                t = srco; sra[t] = 95 * 29 * 100; srb[t] = (7 * 29 - 12) * 100; src[t] = 180 * 100; srtype[t] = 0; sracttype[t] = 0; sre[t] = 0; srsp[t] = 10; srco++;
                t = srco; sra[t] = 104 * 29 * 100; srb[t] = (9 * 29 - 12) * 100; src[t] = 90 * 100; srtype[t] = 0; sracttype[t] = 0; sre[t] = 0; srsp[t] = 12; srco++;
                t = srco; sra[t] = 117 * 29 * 100; srb[t] = (3 * 29 - 12) * 100; src[t] = 90 * 100; srtype[t] = 0; sracttype[t] = 1; sre[t] = 0; srsp[t] = 15; srco++;
                t = srco; sra[t] = 124 * 29 * 100; srb[t] = (5 * 29 - 12) * 100; src[t] = 210 * 100; srtype[t] = 0; sracttype[t] = 0; sre[t] = 0; srsp[t] = 10; srco++;



                if (stagepoint == 1) { stagepoint = 0; ma = 4500; mb = -3000; tyuukan = 0; }


                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }

            }//sta3



            //1-3(地下)
            if (sta == 1 && stb == 3 && stc == 1)
            {

                //マリ　地上　入れ
                //StopSoundMem(oto[0]);
                bgmchange(oto[103]);
                //PlaySoundMem(oto[0],DX_PLAYTYPE_LOOP) ;

                scrollx = 0 * 100;
                ma = 6000; mb = 6000;
                stagecolor = 2;


                byte[][] stagedatex = stagedatex6;


                tco = 0;
                //tyobi(15*29,12*29-12,111);

                stc = 0;


                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }

            }//sta3



            //1-3(空中)
            if (sta == 1 && stb == 3 && stc == 5)
            {

                stagecolor = 3;

                bgmchange(oto[104]);

                scrollx = 0 * 100;
                ma = 3000; mb = 33000;

                stagepoint = 1;

                byte[][] stagedatex = stagedatex7;

                sco = 0;
                t = sco; sa[t] = 14 * 29 * 100 - 5; sb[t] = (11 * 29 - 12) * 100; sc[t] = 6000; sd[t] = 15000 - 200; stype[t] = 50; sxtype[t] = 1; sco++;


                txtype[tco] = 0; tyobi(12 * 29, 4 * 29 - 12, 112);
                //ヒント3
                txtype[tco] = 3; tyobi(12 * 29, 8 * 29 - 12, 300);
                //txtype[tco]=0;tyobi(13*29,4*29-12,110);


                //stc=0;

                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }

            }//sta5





            //1-4(地下)
            if (sta == 1 && stb == 4 && stc == 0)
            {

                //マリ　地上　入れ
                //StopSoundMem(oto[0]);
                bgmchange(oto[105]);
                //PlaySoundMem(oto[0],DX_PLAYTYPE_LOOP) ;

                scrollx = 4400 * 100;
                ma = 12000; mb = 6000;
                stagecolor = 4;


                byte[][] stagedatex = stagedatex8;

                sco = 0;//sco=140;
                t = sco; sa[t] = 35 * 29 * 100 - 1500 + 750; sb[t] = (8 * 29 - 12) * 100 - 1500; sc[t] = 1500; sd[t] = 3000; stype[t] = 105; sco++;
                t = sco; sa[t] = 67 * 29 * 100; sb[t] = (4 * 29 - 12) * 100; sc[t] = 9000 - 1; sd[t] = 3000 * 1 - 1; stype[t] = 51; sxtype[t] = 3; sgtype[t] = 0; sco++;
                t = sco; sa[t] = 73 * 29 * 100; sb[t] = (13 * 29 - 12) * 100; sc[t] = 3000 * 1 - 1; sd[t] = 3000; stype[t] = 52; sco++;
                //t=sco;sa[t]=79*29*100;sb[t]=(13*29-12)*100;sc[t]=30*3*100-1;sd[t]=6000-200;stype[t]=51;sxtype[t]=4;sco++;
                //t=sco;sa[t]=83*29*100;sb[t]=(-2*29-12)*100;sc[t]=30*5*100-1;sd[t]=3000-200;stype[t]=51;sxtype[t]=4;sco++;
                t = sco; sa[t] = 123 * 29 * 100; sb[t] = (1 * 29 - 12) * 100; sc[t] = 30 * 6 * 100 - 1 + 0; sd[t] = 3000 - 200; stype[t] = 51; sxtype[t] = 10; sco++;
                //スクロール消し
                t = sco; sa[t] = 124 * 29 * 100 + 3000; sb[t] = (2 * 29 - 12) * 100; sc[t] = 3000 * 1 - 1; sd[t] = 300000; stype[t] = 102; sxtype[t] = 20; sco++;
                t = sco; sa[t] = 148 * 29 * 100 + 1000; sb[t] = (-12 * 29 - 12) * 100; sc[t] = 3000 * 1 - 1; sd[t] = 300000; stype[t] = 102; sxtype[t] = 30; sco++;

                //3連星
                t = sco; sa[t] = 100 * 29 * 100 + 1000; sb[t] = -6000; sc[t] = 3000; sd[t] = 70000; stype[t] = 102; sxtype[t] = 12; sco++;

                //地面1
                t = sco; sa[t] = 0 * 29 * 100 - 0; sb[t] = 9 * 29 * 100 + 1700; sc[t] = 3000 * 7 - 1; sd[t] = 3000 * 5 - 1; stype[t] = 200; sxtype[t] = 0; sco++;
                t = sco; sa[t] = 11 * 29 * 100; sb[t] = -1 * 29 * 100 + 1700; sc[t] = 3000 * 8 - 1; sd[t] = 3000 * 4 - 1; stype[t] = 200; sxtype[t] = 0; sco++;


                bco = 0;
                t = bco; ba[t] = 8 * 29 * 100 - 1400; bb[t] = (2 * 29 - 12) * 100 + 500; btype[t] = 86; bxtype[t] = 0; bco++;
                t = bco; ba[t] = 42 * 29 * 100 - 1400; bb[t] = (-2 * 29 - 12) * 100 + 500; btype[t] = 86; bxtype[t] = 0; bco++;
                t = bco; ba[t] = 29 * 29 * 100 + 1500; bb[t] = (7 * 29 - 12) * 100 + 1500; btype[t] = 87; bxtype[t] = 105; bco++;
                t = bco; ba[t] = 47 * 29 * 100 + 1500; bb[t] = (9 * 29 - 12) * 100 + 1500; btype[t] = 87; bxtype[t] = 110; bco++;
                t = bco; ba[t] = 70 * 29 * 100 + 1500; bb[t] = (9 * 29 - 12) * 100 + 1500; btype[t] = 87; bxtype[t] = 105; bco++;
                t = bco; ba[t] = 66 * 29 * 100 + 1501; bb[t] = (4 * 29 - 12) * 100 + 1500; btype[t] = 87; bxtype[t] = 101; bco++;
                t = bco; ba[t] = 85 * 29 * 100 + 1501; bb[t] = (4 * 29 - 12) * 100 + 1500; btype[t] = 87; bxtype[t] = 105; bco++;

                //ステルスうめぇ
                t = bco; ba[t] = 57 * 29 * 100; bb[t] = (2 * 29 - 12 + 10) * 100 - 500; btype[t] = 80; bxtype[t] = 1; bco++;
                //ブロックもどき
                t = bco; ba[t] = 77 * 29 * 100; bb[t] = (5 * 29 - 12) * 100; btype[t] = 82; bxtype[t] = 2; bco++;
                //ボス
                t = bco; ba[t] = 130 * 29 * 100; bb[t] = (8 * 29 - 12) * 100; btype[t] = 30; bxtype[t] = 0; bco++;
                //クックル
                t = bco; ba[t] = 142 * 29 * 100; bb[t] = (10 * 29 - 12) * 100; btype[t] = 31; bxtype[t] = 0; bco++;

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
                for (t = 0; t <= 2; t++)
                {
                    txtype[tco] = 3; tyobi((79 + t) * 29, 13 * 29 - 12, 115);
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
                t = srco; sra[t] = 93 * 29 * 100; srb[t] = (10 * 29 - 12) * 100; src[t] = 60 * 100; srtype[t] = 0; sracttype[t] = 1; sre[t] = 0; srco++;
                t = 20; sra[t] = 119 * 29 * 100 + 300; srb[t] = (10 * 29 - 12) * 100; src[t] = 12 * 30 * 100 + 1000; srtype[t] = 0; sracttype[t] = 0; srsp[t] = 21; sre[t] = 0; srco++;


                stc = 0;


                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }

            }//sta4

            if (sta == 2 && stb == 1 && stc == 0)
            {// 2-1
                ma = 5600;
                mb = 32000;

                bgmchange(oto[100]);
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
                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }
            }

            if (sta == 2 && stb == 2 && stc == 0)
            {//2-2(地上)

                bgmchange(oto[100]);
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
                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }
            }

            if (sta == 2 && stb == 2 && stc == 1)
            {//2-2(地下)

                bgmchange(oto[103]);
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
                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }
            }

            if (sta == 2 && stb == 2 && stc == 2)
            {// 2-2 地上
             //
                bgmchange(oto[100]);
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
                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }
            }
            //
            if (sta == 2 && stb == 3 && stc == 0)
            {// 2-3
                ma = 7500;
                mb = 3000 * 8;

                bgmchange(oto[100]);
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
                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
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

                bgmchange(oto[105]);
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
                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }
            }

            if (sta == 2 && stb == 4 && stc == 1)
            {// 2-4(2番)
                ma = 4500;
                mb = 3000 * 11;

                bgmchange(oto[105]);
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
                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }
            }

            if (sta == 2 && stb == 4 && stc == 2)
            {// 2-4(3番)
                ma = 4500;
                mb = 3000 * 11;

                bgmchange(oto[105]);
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
                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }
            }

            if (sta == 3 && stb == 1 && stc == 0)
            {// 3-1
                ma = 5600;
                mb = 32000;

                bgmchange(oto[100]);
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
                for (tt = 0; tt <= 1000; tt++)
                {
                    for (t = 0; t <= 16; t++)
                    {
                        stagedate[t,tt] = 0; stagedate[t,tt] = stagedatex[t][tt];
                    }
                }
            }

        }//stagep
    }
}

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
                n背景サイズW[t] = 1;
                n背景サイズH[t] = 1;
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

            //ステージ呼び出し
            Stage();

        }//stagep
    }
}

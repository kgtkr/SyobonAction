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
            for (t_ = 0; t_ < smax; t_++) { sa[t_] = -9000000; sb[t_] = 1; sc[t_] = 1; sd[t_] = 1; sgtype[t_] = 0; stype[t_] = 0; sxtype[t_] = 0; }
            for (t_ = 0; t_ < tmax; t_++) { ta[t_] = -9000000; tb[t_] = 1; tc[t_] = 1; td[t_] = 1; titem[t_] = 0; txtype[t_] = 0; }
            for (t_ = 0; t_ < srmax; t_++) { sra[t_] = -9000000; srb[t_] = 1; src[t_] = 1; srd[t_] = 1; sre[t_] = 0; srf[t_] = 0; srmuki[t_] = 0; sron[t_] = 0; sree[t_] = 0; srsok[t_] = 0; srmove[t_] = 0; srmovep[t_] = 0; srsp[t_] = 0; }
            for (t_ = 0; t_ < amax; t_++) { aa[t_] = -9000000; ab[t_] = 1; ac[t_] = 0; ad[t_] = 1; azimentype[t_] = 0; atype[t_] = 0; axtype[t_] = 0; ae[t_] = 0; af[t_] = 0; atm[t_] = 0; a2tm[t_] = 0; abrocktm[t_] = 0; amsgtm[t_] = 0; }
            for (t_ = 0; t_ < bmax; t_++) { ba[t_] = -9000000; bb[t_] = 1; bz[t_] = 1; btm[t_] = 0; bxtype[t_] = 0; }
            for (t_ = 0; t_ < emax; t_++) { ea[t_] = -9000000; eb[t_] = 1; ec[t_] = 1; ed[t_] = 1; egtype[t_] = 0; }
            for (t_ = 0; t_ < nmax; t_++) {
                na[t_] = -9000000;
                nb[t_] = 1;
                nc[t_] = 1;
                nd[t_] = 1;
                n背景サイズW_[t_] = 1;
                n背景サイズH_[t_] = 1;
                ng[t_] = 0;
                ntype[t_] = 0;
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




            for (tt_ = 0; tt_ <= 1000; tt_++)
            {
                for (t_ = 0; t_ <= 16; t_++)
                {
                    xx[10] = 0;
                    if (stagedate[t_,tt_] >= 1 && stagedate[t_,tt_] <= 255) xx[10] = (int)stagedate[t_,tt_];
                    xx[21] = tt_ * 29; xx[22] = t_ * 29 - 12; xx[23] = xx[10];
                    if (xx[10] >= 1 && xx[10] <= 19 && xx[10] != 9) { tyobi(tt_ * 29, t_ * 29 - 12, xx[10]); }
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
                    if (xx[10] == 9) { tyobi(tt_ * 29, t_ * 29 - 12, 800); }
                    if (xx[10] == 99) { sa[sco] = xx[21] * 100; sb[sco] = xx[22] * 100; sc[sco] = 3000; sd[sco] = (12 - t_) * 3000; stype[sco] = 300; sco++; if (sco >= smax) sco = 0; }
                }
            }

            if (tyuukan >= 1)
            {
                xx[17] = 0;
                for (t_ = 0; t_ < smax; t_++)
                {
                    if (stype[t_] == 500 && tyuukan >= 1)
                    {
                        fx = sa[t_] - n画面幅 / 2; fzx = fx;
                        ma = sa[t_] - fx;
                        mb = sb[t_] - fy;
                        tyuukan--; xx[17]++;

                        sa[t_] = -80000000;
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


            //1-レンガ,2-コイン,3-空,4-土台//5-6地面//7-隠し//

            //ステージ呼び出し
            Stage();

        }//stagep
    }
}

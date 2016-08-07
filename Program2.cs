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
            for (t_ = 0; t_ < n地面max; t_++) { n地面a[t_] = -9000000; n地面b[t_] = 1; n地面c[t_] = 1; n地面d[t_] = 1; n地面gtype [t_] = 0; n地面type[t_] = 0; n地面xtype[t_] = 0; }
            for (t_ = 0; t_ < nブロックmax; t_++) { nブロックa[t_] = -9000000; nブロックb[t_] = 1; nブロックc[t_] = 1; nブロックd[t_] = 1; nブロックitem[t_] = 0; nブロックxtype[t_] = 0; }
            for (t_ = 0; t_ < nリフトmax; t_++) { nリフトa[t_] = -9000000; nリフトb[t_] = 1; nリフトc[t_] = 1; nリフトd[t_] = 1; nリフトe[t_] = 0; nリフトf[t_] = 0; nリフトmuki[t_] = 0; nリフトon[t_] = 0; nリフトee[t_] = 0; nリフトsok[t_] = 0; nリフトmove[t_] = 0; nリフトmovep[t_] = 0; nリフトsp[t_] = 0; }
            for (t_ = 0; t_ < n敵キャラmax; t_++) { n敵キャラa[t_] = -9000000; n敵キャラb[t_] = 1; n敵キャラc[t_] = 0; n敵キャラd[t_] = 1; n敵キャラzimentype[t_] = 0; n敵キャラtype[t_] = 0; n敵キャラxtype[t_] = 0; n敵キャラe[t_] = 0; n敵キャラf[t_] = 0; n敵キャラtm[t_] = 0; n敵キャラ2tm[t_] = 0; n敵キャラbrocktm[t_] = 0; n敵キャラmsgtm[t_] = 0; }
            for (t_ = 0; t_ < n敵出現max; t_++) { n敵出現a[t_] = -9000000; n敵出現b[t_] = 1; n敵出現z[t_] = 1; n敵出現tm[t_] = 0; n敵出現xtype[t_] = 0; }
            for (t_ = 0; t_ < n絵max; t_++) { n絵a[t_] = -9000000; n絵b[t_] = 1; n絵c[t_] = 1; n絵d[t_] = 1; n絵gtype[t_] = 0; }
            for (t_ = 0; t_ < n背景max; t_++) {
                n背景a[t_] = -9000000;
                n背景b[t_] = 1;
                n背景c[t_] = 1;
                n背景d[t_] = 1;
                n背景サイズW_[t_] = 1;
                n背景サイズH_[t_] = 1;
                n背景g[t_] = 0;
                n背景type[t_] = 0;
            }
            

            n地面co = 0; nブロックco = 0; n敵キャラco = 0; n敵出現co = 0; n絵co = 0; n背景co = 0;
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
                    if (xx[10] >= 20 && xx[10] <= 29) { nリフトa[nリフトco] = xx[21] * 100; nリフトb[nリフトco] = xx[22] * 100; nリフトc[nリフトco] = 3000; nリフトtype[nリフトco] = 0; nリフトco++; if (nリフトco >= nリフトmax) nリフトco = 0; }
                    if (xx[10] == 30) { n地面a[n地面co] = xx[21] * 100; n地面b[n地面co] = xx[22] * 100; n地面c[n地面co] = 3000; n地面d[n地面co] = 6000; n地面type[n地面co] = 500; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx[10] == 40) { n地面a[n地面co] = xx[21] * 100; n地面b[n地面co] = xx[22] * 100; n地面c[n地面co] = 6000; n地面d[n地面co] = 3000; n地面type[n地面co] = 1; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx[10] == 41) { n地面a[n地面co] = xx[21] * 100 + 500; n地面b[n地面co] = xx[22] * 100; n地面c[n地面co] = 5000; n地面d[n地面co] = 3000; n地面type[n地面co] = 2; n地面co++; if (n地面co >= n地面max) n地面co = 0; }

                    if (xx[10] == 43) { n地面a[n地面co] = xx[21] * 100; n地面b[n地面co] = xx[22] * 100 + 500; n地面c[n地面co] = 2900; n地面d[n地面co] = 5300; n地面type[n地面co] = 1; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx[10] == 44) { n地面a[n地面co] = xx[21] * 100; n地面b[n地面co] = xx[22] * 100 + 700; n地面c[n地面co] = 3900; n地面d[n地面co] = 5000; n地面type[n地面co] = 5; n地面co++; if (n地面co >= n地面max) n地面co = 0; }

                    //これなぜかバグの原因ｗ
                    if (xx[10] >= 50 && xx[10] <= 79)
                    {
                        n敵出現a[n敵出現co] = xx[21] * 100; n敵出現b[n敵出現co] = xx[22] * 100; n敵出現type[n敵出現co] = xx[23] - 50; n敵出現co++; if (n敵出現co >= n敵出現max) n敵出現co = 0;
                    }

                    if (xx[10] >= 80 && xx[10] <= 89) { n背景a[n背景co] = xx[21] * 100; n背景b[n背景co] = xx[22] * 100; n背景type[n背景co] = xx[23] - 80; n背景co++; if (n背景co >= n背景max) n背景co = 0; }

                    //コイン
                    if (xx[10] == 9) { tyobi(tt_ * 29, t_ * 29 - 12, 800); }
                    if (xx[10] == 99) { n地面a[n地面co] = xx[21] * 100; n地面b[n地面co] = xx[22] * 100; n地面c[n地面co] = 3000; n地面d[n地面co] = (12 - t_) * 3000; n地面type[n地面co] = 300; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                }
            }

            if (tyuukan >= 1)
            {
                xx[17] = 0;
                for (t_ = 0; t_ < n地面max; t_++)
                {
                    if (n地面type[t_] == 500 && tyuukan >= 1)
                    {
                        fx = n地面a[t_] - n画面幅 / 2; fzx = fx;
                        ma = n地面a[t_] - fx;
                        nプレイヤーb = n地面b[t_] - fy;
                        tyuukan--; xx[17]++;

                        n地面a[t_] = -80000000;
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

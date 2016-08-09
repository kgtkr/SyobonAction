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
        //ブロック
        const int nブロックmax = 641;
        static int nブロックco;
        static int[] nブロックa = new int[nブロックmax],
            nブロックb = new int[nブロックmax],
            nブロックc = new int[nブロックmax],
            nブロックd = new int[nブロックmax],
            nブロックhp = new int[nブロックmax],
            nブロックtype = new int[nブロックmax];
        static int[] nブロックitem = new int[nブロックmax],
            nブロックxtype = new int[nブロックmax];

        static void UpdateBlock()
        {
            //ブロック
            //1-れんが、コイン、無し、土台、7-隠し
            xx_15 = 0;
            for (int t_ = 0; t_ < nブロックmax; t_++)
            {
                xx_0 = 200; xx_1 = 3000; xx_2 = 1000; xx_3 = 3000;//xx_2=1000
                xx_8 = nブロックa[t_] - fx; xx_9 = nブロックb[t_] - fy;//xx_15=0;
                if (nブロックa[t_] - fx + xx_1 >= -10 - xx_3 && nブロックa[t_] - fx <= n画面幅 + 12000 + xx_3)
                {
                    if (nプレイヤーtype != 200 && nプレイヤーtype != 1 && nプレイヤーtype != 2)
                    {
                        if (nブロックtype[t_] < 1000 && nブロックtype[t_] != 800 && nブロックtype[t_] != 140 && nブロックtype[t_] != 141)
                        {
                                xx_16 = 0; xx_17 = 0;

                                //上
                                if (nブロックtype[t_] != 7 && nブロックtype[t_] != 110 && !(nブロックtype[t_] == 114))
                                {
                                    if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 + 100 && ma < xx_8 + xx_1 - xx_0 * 2 - 100 && nプレイヤーb + nプレイヤーnobib > xx_9 && nプレイヤーb + nプレイヤーnobib < xx_9 + xx_1 && nプレイヤーd >= -100)
                                    {
                                        if (nブロックtype[t_] != 115 && nブロックtype[t_] != 400 && nブロックtype[t_] != 117 && nブロックtype[t_] != 118 && nブロックtype[t_] != 120)
                                        {
                                            nプレイヤーb = xx_9 - nプレイヤーnobib + 100; nプレイヤーd = 0; nプレイヤーzimen = 1; xx_16 = 1;
                                        }
                                        else if (nブロックtype[t_] == 115)
                                        {
                                            v効果音再生(Res.nオーディオ_[3]);
                                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                            brockBreak(t_);
                                        }
                                        //Pスイッチ
                                        else if (nブロックtype[t_] == 400)
                                        {
                                            nプレイヤーd = 0; nブロックa[t_] = -8000000; v効果音再生(Res.nオーディオ_[13]);
                                            for (int tt_ = 0; tt_ < nブロックmax; tt_++) { if (nブロックtype[tt_] != 7) { nブロックtype[tt_] = 800; } }
                                        }

                                        //音符+
                                        else if (nブロックtype[t_] == 117)
                                        {
                                            v効果音再生(Res.nオーディオ_[14]);
                                            nプレイヤーd = -1500; nプレイヤーtype = 2; nプレイヤーtm = 0;
                                            if (nブロックxtype[t_] >= 2 && nプレイヤーtype == 2) { nプレイヤーtype = 0; nプレイヤーd = -1600; nブロックxtype[t_] = 3; }
                                            if (nブロックxtype[t_] == 0) nブロックxtype[t_] = 1;
                                        }

                                        //ジャンプ台
                                        else if (nブロックtype[t_] == 120)
                                        {
                                            //txtype[t]=0;
                                            nプレイヤーd = -2400; nプレイヤーtype = 3; nプレイヤーtm = 0;
                                        }

                                    }
                                }


                            //sstr=""+mjumptm;
                            //ブロック判定の入れ替え
                                xx_21 = 0; xx_22 = 1;//xx_12=0;
                                if (nプレイヤーzimen == 1 || nプレイヤーjumptm >= 10) { xx_21 = 3; xx_22 = 0; }
                                for (int t3 = 0; t3 <= 1; t3++)
                                {

                                    //下
                                    if (t3 == xx_21 && nプレイヤーtype != 100 && nブロックtype[t_] != 117)
                                    {// && xx_12==0){
                                        if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 + 800 && ma < xx_8 + xx_1 - xx_0 * 2 - 800 && nプレイヤーb > xx_9 - xx_0 * 2 && nプレイヤーb < xx_9 + xx_1 - xx_0 * 2 && nプレイヤーd <= 0)
                                        {
                                            xx_16 = 1; xx_17 = 1;
                                            nプレイヤーb = xx_9 + xx_1 + xx_0; if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd * 2 / 3; }//}
                                                                                                                             //壊れる
                                            if (nブロックtype[t_] == 1 && nプレイヤーzimen == 0)
                                            {
                                                v効果音再生(Res.nオーディオ_[3]);
                                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                brockBreak(t_);
                                            }
                                            //コイン
                                            if (nブロックtype[t_] == 2 && nプレイヤーzimen == 0)
                                            {
                                                v効果音再生(Res.nオーディオ_[4]);
                                                eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                                nブロックtype[t_] = 3;
                                            }
                                            //隠し
                                            if (nブロックtype[t_] == 7)
                                            {
                                                v効果音再生(Res.nオーディオ_[4]);
                                                eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                                nプレイヤーb = xx_9 + xx_1 + xx_0; nブロックtype[t_] = 3; if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd * 2 / 3; }
                                            }
                                            // トゲ
                                            if (nブロックtype[t_] == 10)
                                            {
                                                nメッセージtm = 30;
                                                nメッセージtype = 3;
                                                nプレイヤーhp--;
                                            }
                                        }
                                    }


                                    //左右
                                    if (t3 == xx_22 && xx_15 == 0)
                                    {
                                        if (nブロックtype[t_] != 7 && nブロックtype[t_] != 110 && nブロックtype[t_] != 117)
                                        {
                                            if (!(nブロックtype[t_] == 114))
                                            {// && txtype[t]==1)){
                                                if (nブロックa[t_] >= -20000)
                                                {
                                                    if (ma + nプレイヤーnobia > xx_8 && ma < xx_8 + xx_2 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_1 / 2 - xx_0 && nプレイヤーb < xx_9 + xx_2 && nプレイヤーc >= 0)
                                                    {
                                                        ma = xx_8 - nプレイヤーnobia; nプレイヤーc = 0; xx_16 = 1;
                                                    }
                                                    if (ma + nプレイヤーnobia > xx_8 + xx_2 && ma < xx_8 + xx_1 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_1 / 2 - xx_0 && nプレイヤーb < xx_9 + xx_2 && nプレイヤーc <= 0)
                                                    {
                                                        ma = xx_8 + xx_1; nプレイヤーc = 0; xx_16 = 1;//end();
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }//t3

                        }// && ttype[t]<50

                        if (nブロックtype[t_] == 800)
                        {
                            if (nプレイヤーb > xx_9 - xx_0 * 2 - 2000 && nプレイヤーb < xx_9 + xx_1 - xx_0 * 2 + 2000 && ma + nプレイヤーnobia > xx_8 - 400 && ma < xx_8 + xx_1)
                            {
                                nブロックa[t_] = -800000; v効果音再生(Res.nオーディオ_[4]);
                            }
                        }

                        //剣とってクリア
                        if (nブロックtype[t_] == 140)
                        {
                            if (nプレイヤーb > xx_9 - xx_0 * 2 - 2000 && nプレイヤーb < xx_9 + xx_1 - xx_0 * 2 + 2000 && ma + nプレイヤーnobia > xx_8 - 400 && ma < xx_8 + xx_1)
                            {
                                nブロックa[t_] = -800000;//ot(oto[4]);
                                nリフトacttype[20] = 1; nリフトon[20] = 1;
                                DX.StopSoundMem(Res.nオーディオ_[0]); nプレイヤーtype = 301; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[16]);

                            }
                        }


                        //特殊的
                        if (nブロックtype[t_] == 100)
                        {//xx_9+xx_1+3000<mb && // && mb>xx_9-xx_0*2
                            if (nプレイヤーb > xx_9 - xx_0 * 2 - 2000 && nプレイヤーb < xx_9 + xx_1 - xx_0 * 2 + 2000 && ma + nプレイヤーnobia > xx_8 - 400 && ma < xx_8 + xx_1 && nプレイヤーd <= 0)
                            {
                                if (nブロックxtype[t_] == 0) nブロックb[t_] = nプレイヤーb + fy - 1200 - xx_1;
                            }

                            if (nブロックxtype[t_] == 1)
                            {
                                if (xx_17 == 1)
                                {
                                    if (ma + nプレイヤーnobia > xx_8 - 400 && ma < xx_8 + xx_1 / 2 - 1500) { nブロックa[t_] += 3000; }
                                    else if (ma + nプレイヤーnobia >= xx_8 + xx_1 / 2 - 1500 && ma < xx_8 + xx_1) { nブロックa[t_] -= 3000; }
                                }
                            }

                            if (xx_17 == 1 && nブロックxtype[t_] == 0)
                            {
                                v効果音再生(Res.nオーディオ_[4]);
                                eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                nブロックtype[t_] = 3;
                            }
                        }//100

                        //敵出現
                        if (nブロックtype[t_] == 101)
                        {//xx_9+xx_1+3000<mb && // && mb>xx_9-xx_0*2
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
                                nブロックtype[t_] = 3;
                                n敵キャラbrocktm[n敵キャラco] = 16;
                                if (nブロックxtype[t_] == 0) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 0, 0);
                                if (nブロックxtype[t_] == 1) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 4, 0);
                                if (nブロックxtype[t_] == 3) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 101, 0);
                                if (nブロックxtype[t_] == 4) { n敵キャラbrocktm[n敵キャラco] = 20; ayobi(nブロックa[t_] - 400, nブロックb[t_] - 1600, 0, 0, 0, 6, 0); }
                                if (nブロックxtype[t_] == 10) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 101, 0);
                            }
                        }//101

                        //おいしいきのこ出現
                        if (nブロックtype[t_] == 102)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
                                nブロックtype[t_] = 3; n敵キャラbrocktm[n敵キャラco] = 16;
                                if (nブロックxtype[t_] == 0) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 100, 0);
                                if (nブロックxtype[t_] == 2) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 100, 2);
                                if (nブロックxtype[t_] == 3) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 102, 1);
                            }
                        }//102

                        //まずいきのこ出現
                        if (nブロックtype[t_] == 103)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
                                nブロックtype[t_] = 3; n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 100, 1);
                            }
                        }//103


                        //悪スター出し
                        if (nブロックtype[t_] == 104)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
                                nブロックtype[t_] = 3; n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 110, 0);
                            }
                        }//104




                        //毒きのこ量産
                        if (nブロックtype[t_] == 110)
                        {
                            if (xx_17 == 1)
                            {
                                nブロックtype[t_] = 111; nブロックhp[t_] = 999;
                            }
                        }//110
                        if (nブロックtype[t_] == 111 && nブロックa[t_] - fx >= 0)
                        {
                            nブロックhp[t_]++; if (nブロックhp[t_] >= 16)
                            {
                                nブロックhp[t_] = 0;
                                v効果音再生(Res.nオーディオ_[8]);
                                n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 102, 1);
                            }
                        }


                        //コイン量産
                        if (nブロックtype[t_] == 112)
                        {
                            if (xx_17 == 1)
                            {
                                nブロックtype[t_] = 113; nブロックhp[t_] = 999; nブロックitem[t_] = 0;
                            }
                        }//110
                        if (nブロックtype[t_] == 113 && nブロックa[t_] - fx >= 0)
                        {
                            if (nブロックitem[t_] <= 19) nブロックhp[t_]++;
                            if (nブロックhp[t_] >= 3)
                            {
                                nブロックhp[t_] = 0; nブロックitem[t_]++;
                                v効果音再生(Res.nオーディオ_[4]);
                                eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                //ttype[t]=3;
                            }
                        }


                        //隠し毒きのこ
                        if (nブロックtype[t_] == 114)
                        {
                            if (xx_17 == 1)
                            {
                                if (nブロックxtype[t_] == 0)
                                {
                                    v効果音再生(Res.nオーディオ_[8]); nブロックtype[t_] = 3;
                                    n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 102, 1);
                                }
                                if (nブロックxtype[t_] == 2) { v効果音再生(Res.nオーディオ_[4]); eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16); nブロックtype[t_] = 115; nブロックxtype[t_] = 0; }
                                if (nブロックxtype[t_] == 10)
                                {
                                    if (bステージスイッチ) { nブロックtype[t_] = 130; bステージスイッチ = false; v効果音再生(Res.nオーディオ_[13]); nブロックxtype[t_] = 2; for (t_ = 0; t_ < n敵キャラmax; t_++) { if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88) { if (n敵キャラxtype[t_] == 105) { n敵キャラxtype[t_] = 110; } } } }
                                    else { v効果音再生(Res.nオーディオ_[4]); eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16); nブロックtype[t_] = 3; }
                                }

                            }
                        }//114


                        //もろいブロック
                        if (nブロックtype[t_] == 115)
                        {

                        }//115


                        //Pスイッチ
                        if (nブロックtype[t_] == 116)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
                                //ot(oto[13]);
                                nブロックtype[t_] = 3;//abrocktm[aco]=18;ayobi(ta[t],tb[t],0,0,0,104,1);
                                tyobi(nブロックa[t_] / 100, (nブロックb[t_] / 100) - 29, 400);
                            }
                        }//116


                        //ファイアバー強化
                        if (nブロックtype[t_] == 124)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[13]);
                                for (t_ = 0; t_ < n敵キャラmax; t_++) { if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88) { if (n敵キャラxtype[t_] == 101) { n敵キャラxtype[t_] = 120; } } }
                                nブロックtype[t_] = 3;
                            }
                        }

                        //ONスイッチ
                        if (nブロックtype[t_] == 130)
                        {
                            if (xx_17 == 1)
                            {
                                if (nブロックxtype[t_] != 1)
                                {
                                    bステージスイッチ = false; v効果音再生(Res.nオーディオ_[13]);
                                }
                            }
                        }
                        else if (nブロックtype[t_] == 131)
                        {
                            if (xx_17 == 1 && nブロックxtype[t_] != 2)
                            {
                                bステージスイッチ = true; v効果音再生(Res.nオーディオ_[13]);
                                if (nブロックxtype[t_] == 1)
                                {
                                    for (t_ = 0; t_ < n敵キャラmax; t_++) { if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88) { if (n敵キャラxtype[t_] == 105) { n敵キャラxtype[t_] = 110; } } }
                                    n敵出現xtype[3] = 105;
                                }
                            }
                        }

                        //ヒント
                        if (nブロックtype[t_] == 300)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[15]);
                                if (nブロックxtype[t_] <= 100)
                                {
                                    nメッセージブロックtype = 1; nメッセージブロックtm = 15; nメッセージブロックy = 300 + (nブロックxtype[t_] - 1); nメッセージブロック = (nブロックxtype[t_]);
                                }
                                if (nブロックxtype[t_] == 540)
                                {
                                    nメッセージブロックtype = 1; nメッセージブロックtm = 15; nメッセージブロックy = 400; nメッセージブロック = 100; nブロックxtype[t_] = 541;
                                }
                            }
                        }//300


                        if (nブロックtype[t_] == 301)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[3]);
                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120); eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                brockBreak(t_);
                            }
                        }//300


                    }
                    else if (nプレイヤーtype == 1)
                    {
                        if (ma + nプレイヤーnobia > xx_8 && ma < xx_8 + xx_1 && nプレイヤーb + nプレイヤーnobib > xx_9 && nプレイヤーb < xx_9 + xx_1)
                        {

                            v効果音再生(Res.nオーディオ_[3]);
                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                            brockBreak(t_);

                        }
                    }


                    //ONOFF
                    if (nブロックtype[t_] == 130 && !bステージスイッチ) { nブロックtype[t_] = 131; }
                    if (nブロックtype[t_] == 131 && bステージスイッチ) { nブロックtype[t_] = 130; }

                    //ヒント
                    if (nブロックtype[t_] == 300)
                    {
                        if (nブロックxtype[t_] >= 500 && nブロックa[t_] >= -6000)
                        {// && ta[t]>=-6000){
                            if (nブロックxtype[t_] <= 539) nブロックxtype[t_]++;
                            if (nブロックxtype[t_] >= 540) { nブロックa[t_] -= 500; }
                        }
                    }//300


                }
            }//ブロック
        }

        static void DrawBlock()
        {
            //ブロック描画
            for (int t_ = 0; t_ < nブロックmax; t_++)
            {
                xx_0 = nブロックa[t_] - fx; xx_1 = nブロックb[t_] - fy;
                xx_2 = 32; xx_3 = xx_2;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= n画面幅)
                {

                    xx_9 = 0;
                    if (nステージ色 == 2) { xx_9 = 30; }
                    if (nステージ色 == 4) { xx_9 = 60; }
                    if (nステージ色 == 5) { xx_9 = 90; }

                    if (nブロックtype[t_] < 100)
                    {
                        xx_6 = nブロックtype[t_] + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                    }

                    if (nブロックxtype[t_] != 10)
                    {

                        if (nブロックtype[t_] == 100 || nブロックtype[t_] == 101 || nブロックtype[t_] == 102 || nブロックtype[t_] == 103 || nブロックtype[t_] == 104 && nブロックxtype[t_] == 1 || nブロックtype[t_] == 114 && nブロックxtype[t_] == 1 || nブロックtype[t_] == 116)
                        {
                            xx_6 = 2 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (nブロックtype[t_] == 112 || nブロックtype[t_] == 104 && nブロックxtype[t_] == 0 || nブロックtype[t_] == 115 && nブロックxtype[t_] == 1)
                        {
                            xx_6 = 1 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (nブロックtype[t_] == 111 || nブロックtype[t_] == 113 || nブロックtype[t_] == 115 && nブロックxtype[t_] == 0 || nブロックtype[t_] == 124)
                        {
                            xx_6 = 3 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                    }

                    if (nブロックtype[t_] == 117 && nブロックxtype[t_] == 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像_[4, 5], xx_0 / 100, xx_1 / 100);
                    }

                    if (nブロックtype[t_] == 117 && nブロックxtype[t_] >= 3)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像_[3, 5], xx_0 / 100, xx_1 / 100);
                    }

                    if (nブロックtype[t_] == 115 && nブロックxtype[t_] == 3)
                    {
                        xx_6 = 1 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                    }

                    //ジャンプ台
                    if (nブロックtype[t_] == 120 && nブロックxtype[t_] != 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像_[16, 1], xx_0 / 100 + 3, xx_1 / 100 + 2);
                    }

                    //ON-OFF
                    if (nブロックtype[t_] == 130) DXDraw.DrawGraph(Res.n切り取り画像_[10, 5], xx_0 / 100, xx_1 / 100);
                    if (nブロックtype[t_] == 131) DXDraw.DrawGraph(Res.n切り取り画像_[11, 5], xx_0 / 100, xx_1 / 100);

                    if (nブロックtype[t_] == 140) DXDraw.DrawGraph(Res.n切り取り画像_[12, 5], xx_0 / 100, xx_1 / 100);
                    if (nブロックtype[t_] == 141) DXDraw.DrawGraph(Res.n切り取り画像_[13, 5], xx_0 / 100, xx_1 / 100);
                    if (nブロックtype[t_] == 142) DXDraw.DrawGraph(Res.n切り取り画像_[14, 5], xx_0 / 100, xx_1 / 100);


                    if (nブロックtype[t_] == 300 || nブロックtype[t_] == 301)
                        DXDraw.DrawGraph(Res.n切り取り画像_[1, 5], xx_0 / 100, xx_1 / 100);

                    //Pスイッチ
                    if (nブロックtype[t_] == 400) { DXDraw.DrawGraph(Res.n切り取り画像_[2, 5], xx_0 / 100, xx_1 / 100); }

                    //コイン
                    if (nブロックtype[t_] == 800) { DXDraw.DrawGraph(Res.n切り取り画像_[0, 2], xx_0 / 100 + 2, xx_1 / 100 + 1); }

                }
            }
        }
    }
}

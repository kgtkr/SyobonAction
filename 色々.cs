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

        //音楽再生
        static void v効果音再生(int x)
        {
            DX.PlaySoundMem(x, DX.DX_PLAYTYPE_BACK);
        }

        //BGM変更
        public static void bgmChange(int x)
        {
            DX.StopSoundMem(Res.nオーディオ_[0]);
            Res.nオーディオ_[0] = 0;
            Res.nオーディオ_[0] = x;
        }

        //ブロック出現

        static void tyobi(int x, int y, int type)
        {

            nブロックa[nブロックco] = x * 100; nブロックb[nブロックco] = y * 100; nブロックtype[nブロックco] = type;

            nブロックco++; if (nブロックco >= nブロックmax) nブロックco = 0;
        }//tyobi


        //ブロック破壊
        static void brockBreak(int t)
        {
            nブロックa[t] = -800000;
        }//brock


        //メッセージ
        static void ttmsg()
        {
            xx_1 = 6000 / 100;
            xx_2 = 4000 / 100;
            if (nメッセージブロックtype == 1 || nメッセージブロックtype == 2)
            {
                DXDraw.SetColorBlack();
                DXDraw.DrawBox塗り潰し(xx_1, xx_2, 360, nメッセージブロックy / 100);
                DXDraw.SetColorWhite();
                DXDraw.DrawBox塗り無し(xx_1, xx_2, 360, nメッセージブロックy / 100);
            }
            if (nメッセージブロックtype == 2)
            {
                //フォント
                setfont(20, 5);

                if (nメッセージブロック == 0)
                {
                    DXDraw.SetColorWhite();
                    //フォント
                    setfont(20, 5);
                    txmsg("テスト　hoge", 0);
                }

                if (nメッセージブロック == 1)
                {
                    DXDraw.SetColorWhite();
                    txmsg("", 0);
                    txmsg("ステージ 1 より", 0);
                    txmsg("特殊的なものが増えたので", 1);
                    txmsg("気をつけてくれよ～", 2);
                    txmsg("後、アイテムの一部を利用するかも…", 4);
                    txmsg("                       ちく より", 6);
                }

                if (nメッセージブロック == 2)
                {
                    txmsg("            ？が必要です ", 3);
                    txmsg("                         m9(^Д^)", 6);
                }


                if (nメッセージブロック == 3)
                {
                    txmsg("   別にコインに意味ないけどね ", 3);
                    txmsg("                      (・ω・ )ﾉｼ", 6);
                }

                if (nメッセージブロック == 4)
                {
                    txmsg("この先に隠しブロックがあります ", 2);
                    txmsg("注意してください !!", 4);
                }


                if (nメッセージブロック == 5)
                {
                    txmsg("", 0);
                    txmsg(" 前回よりも難易度を下げましたので", 1);
                    txmsg(" 気楽にプレイしてください    ", 3);
                    txmsg("                       ちく より", 6);
                }

                if (nメッセージブロック == 6)
                {
                    txmsg("", 0);
                    txmsg(" そこにいる敵のそばによると、      ", 1);
                    txmsg(" 自分と一緒にジャンプしてくれます。", 2);
                    txmsg("   可愛いですね。                  ", 3);
                }

                if (nメッセージブロック == 7)
                {
                    txmsg("", 0);
                    txmsg(" あの敵は連れて来れましたか?、     ", 1);
                    txmsg(" 連れて来れなかった貴方は、        ", 2);
                    txmsg(" そこの落とし穴から Let's dive!    ", 3);
                }

                if (nメッセージブロック == 8)
                {
                    txmsg("そんな容易に", 1);
                    txmsg("ヒントに頼るもんじゃないぜ", 2);
                    txmsg("ほら、さっさと次行きな!!", 3);
                }

                if (nメッセージブロック == 9)
                {
                    txmsg(" 正真正銘のファイナルステージ。    ", 1);
                    txmsg(" クリアすれば遂にエンディング!!    ", 2);
                    txmsg(" その土管から戻ってもいいんだぜ?   ", 3);
                }

                if (nメッセージブロック == 10)
                {
                    txmsg(" 床が凍ってるから、すっごい滑るよ。", 1);
                    txmsg(" ", 2);
                    txmsg(" 　                      ", 3);
                }

                if (nメッセージブロック == 100)
                {
                    txmsg("え？私ですか？ ", 0);
                    txmsg("いやぁ、ただの通りすがりの", 2);
                    txmsg("ヒントブロックですよ～", 3);
                    txmsg("決して怪しいブロックじゃないですよ", 5);
                    txmsg("                          (…チッ)", 6);
                }


                setfont(16, 4);
            }//2

            if (nメッセージブロックtype == 3)
            {
                xx_5 = (((15 - 1) * 1200 + 1500) / 100 - nメッセージブロックy / 100);
                if (xx_5 > 0)
                {
                    DXDraw.SetColorBlack();
                    DXDraw.DrawBox塗り潰し(xx_1, xx_2 + nメッセージブロックy / 100, 360, xx_5);
                    DXDraw.SetColorWhite();
                    DXDraw.DrawBox塗り無し(xx_1, xx_2 + nメッセージブロックy / 100, 360, xx_5);
                }
            }

        }//ttmsg

        static void txmsg(string x, int a)
        {
            int xx = 6;

            DXDraw.DrawString(x, 60 + xx, 40 + xx + a * 24);

        }//txmsg


        //フォント変更
        static void setfont(int x, int y)
        {
            DX.SetFontSize(x);
            DX.SetFontThickness(y);
        }



        //グラ作成
        static void eyobi(int xa, int xb, int xc, int xd, int xe, int xf, int xnobia, int xnobib, int xgtype, int xtm)
        {

            n絵a[n絵co] = xa; n絵b[n絵co] = xb; n絵c[n絵co] = xc; n絵d[n絵co] = xd; n絵e[n絵co] = xe; n絵f[n絵co] = xf;
            n絵gtype[n絵co] = xgtype; n絵tm[n絵co] = xtm;
            n絵nobia[n絵co] = xnobia; n絵nobib[n絵co] = xnobib;

            n絵co++;
            if (n絵co >= n絵max) n絵co = 0;

        }//eyobi


        //敵キャラ、アイテム作成
        static void ayobi(int xa, int xb, int xc, int xd, int xnotm, int xtype, int xxtype)
        {
            int rz = 0;
            for (int t1 = 0; t1 <= 1; t1++)
            {
                t1 = 2;
                if (n敵キャラa[n敵キャラco] >= -9000 && n敵キャラa[n敵キャラco] <= 30000) t1 = 0; rz++;

                if (rz <= n敵キャラmax)
                {
                    t1 = 3;

                    n敵キャラa[n敵キャラco] = xa;
                    n敵キャラb[n敵キャラco] = xb;
                    n敵キャラc[n敵キャラco] = xc;
                    n敵キャラd[n敵キャラco] = xd;
                    if (xxtype > 100) n敵キャラc[n敵キャラco] = xxtype;
                    n敵キャラtype[n敵キャラco] = xtype;
                    if (xxtype >= 0 && xxtype <= 99100) n敵キャラxtype[n敵キャラco] = xxtype;//ahp[aco]=iz[bxtype[t]];aytm[aco]=0;
                                                                                     //if (xxtype==1)end();
                    n敵キャラnotm[n敵キャラco] = xnotm;
                    if (n敵キャラa[n敵キャラco] - fx <= ma + nプレイヤーnobia / 2) n敵キャラmuki[n敵キャラco] = 1;
                    if (n敵キャラa[n敵キャラco] - fx > ma + nプレイヤーnobia / 2) n敵キャラmuki[n敵キャラco] = 0;
                    if (n敵キャラbrocktm[n敵キャラco] >= 1) n敵キャラmuki[n敵キャラco] = 1;
                    if (n敵キャラbrocktm[n敵キャラco] == 20) n敵キャラmuki[n敵キャラco] = 0;

                    n敵キャラnobia[n敵キャラco] = Res.n敵サイズW_[n敵キャラtype[n敵キャラco]]; n敵キャラnobib[n敵キャラco] = Res.n敵サイズH_[n敵キャラtype[n敵キャラco]];



                    //大砲音
                    if (xtype == 7 && DX.CheckSoundMem(Res.nオーディオ_[10]) == 0) { v効果音再生(Res.nオーディオ_[10]); }
                    //ファイア音
                    if (xtype == 10 && DX.CheckSoundMem(Res.nオーディオ_[18]) == 0) { v効果音再生(Res.nオーディオ_[18]); }


                    n敵キャラzimentype[n敵キャラco] = 1;

                    if (xtype == 87) { n敵キャラtm[n敵キャラco] = DX.GetRand(179) + (-90); }

                    n敵キャラco += 1; if (n敵キャラco >= n敵キャラmax - 1) { n敵キャラco = 0; }
                }//t1

            }//rz

        }//ayobi

        static void stagecls()
        {
            for (int t_ = 0; t_ < n地面max; t_++) { n地面a[t_] = -9000000; n地面b[t_] = 1; n地面c[t_] = 1; n地面d[t_] = 1; n地面gtype[t_] = 0; n地面type[t_] = 0; n地面xtype[t_] = 0; }
            for (int t_ = 0; t_ < nブロックmax; t_++) { nブロックa[t_] = -9000000; nブロックb[t_] = 1; nブロックc[t_] = 1; nブロックd[t_] = 1; nブロックitem[t_] = 0; nブロックxtype[t_] = 0; }
            for (int t_ = 0; t_ < nリフトmax; t_++) { nリフトa[t_] = -9000000; nリフトb[t_] = 1; nリフトc[t_] = 1; nリフトd[t_] = 1; nリフトe[t_] = 0; nリフトf[t_] = 0; nリフトmuki[t_] = 0; nリフトon[t_] = 0; nリフトee[t_] = 0; nリフトsok[t_] = 0; nリフトmove[t_] = 0; nリフトmovep[t_] = 0; nリフトsp[t_] = 0; }
            for (int t_ = 0; t_ < n敵キャラmax; t_++) { n敵キャラa[t_] = -9000000; n敵キャラb[t_] = 1; n敵キャラc[t_] = 0; n敵キャラd[t_] = 1; n敵キャラzimentype[t_] = 0; n敵キャラtype[t_] = 0; n敵キャラxtype[t_] = 0; n敵キャラe[t_] = 0; n敵キャラf[t_] = 0; n敵キャラtm[t_] = 0; n敵キャラ2tm[t_] = 0; n敵キャラbrocktm[t_] = 0; n敵キャラmsgtm[t_] = 0; }
            for (int t_ = 0; t_ < n敵出現max; t_++) { n敵出現a[t_] = -9000000; n敵出現b[t_] = 1; n敵出現z[t_] = 1; n敵出現tm[t_] = 0; n敵出現xtype[t_] = 0; }
            for (int t_ = 0; t_ < n絵max; t_++) { n絵a[t_] = -9000000; n絵b[t_] = 1; n絵c[t_] = 1; n絵d[t_] = 1; n絵gtype[t_] = 0; }
            for (int t_ = 0; t_ < n背景max; t_++)
            {
                n背景a[t_] = -9000000;
                n背景b[t_] = 1;
                n背景c[t_] = 1;
                n背景d[t_] = 1;
                Res.n背景サイズW_[t_] = 1;
                Res.n背景サイズH_[t_] = 1;
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
            scrollX = 3600 * 100;

            stagep();


            for (int tt_ = 0; tt_ <= 1000; tt_++)
            {
                for (int t_ = 0; t_ <= 16; t_++)
                {
                    xx_10 = 0;
                    if (stageDate[t_, tt_] >= 1 && stageDate[t_, tt_] <= 255) xx_10 = (int)stageDate[t_, tt_];
                    xx_21 = tt_ * 29; xx_22 = t_ * 29 - 12; xx_23 = xx_10;
                    if (xx_10 >= 1 && xx_10 <= 19 && xx_10 != 9) { tyobi(tt_ * 29, t_ * 29 - 12, xx_10); }
                    if (xx_10 >= 20 && xx_10 <= 29) { nリフトa[nリフトco] = xx_21 * 100; nリフトb[nリフトco] = xx_22 * 100; nリフトc[nリフトco] = 3000; nリフトtype[nリフトco] = 0; nリフトco++; if (nリフトco >= nリフトmax) nリフトco = 0; }
                    if (xx_10 == 30) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100; n地面c[n地面co] = 3000; n地面d[n地面co] = 6000; n地面type[n地面co] = 500; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx_10 == 40) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100; n地面c[n地面co] = 6000; n地面d[n地面co] = 3000; n地面type[n地面co] = 1; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx_10 == 41) { n地面a[n地面co] = xx_21 * 100 + 500; n地面b[n地面co] = xx_22 * 100; n地面c[n地面co] = 5000; n地面d[n地面co] = 3000; n地面type[n地面co] = 2; n地面co++; if (n地面co >= n地面max) n地面co = 0; }

                    if (xx_10 == 43) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100 + 500; n地面c[n地面co] = 2900; n地面d[n地面co] = 5300; n地面type[n地面co] = 1; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx_10 == 44) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100 + 700; n地面c[n地面co] = 3900; n地面d[n地面co] = 5000; n地面type[n地面co] = 5; n地面co++; if (n地面co >= n地面max) n地面co = 0; }

                    //これなぜかバグの原因ｗ
                    if (xx_10 >= 50 && xx_10 <= 79)
                    {
                        n敵出現a[n敵出現co] = xx_21 * 100; n敵出現b[n敵出現co] = xx_22 * 100; n敵出現type[n敵出現co] = xx_23 - 50; n敵出現co++; if (n敵出現co >= n敵出現max) n敵出現co = 0;
                    }

                    if (xx_10 >= 80 && xx_10 <= 89) { n背景a[n背景co] = xx_21 * 100; n背景b[n背景co] = xx_22 * 100; n背景type[n背景co] = xx_23 - 80; n背景co++; if (n背景co >= n背景max) n背景co = 0; }

                    //コイン
                    if (xx_10 == 9) { tyobi(tt_ * 29, t_ * 29 - 12, 800); }
                    if (xx_10 == 99) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100; n地面c[n地面co] = 3000; n地面d[n地面co] = (12 - t_) * 3000; n地面type[n地面co] = 300; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                }
            }

            if (n中間フラグ >= 1)
            {
                xx_17 = 0;
                for (int t_ = 0; t_ < n地面max; t_++)
                {
                    if (n地面type[t_] == 500 && n中間フラグ >= 1)
                    {
                        fx = n地面a[t_] - W / 2; fzx = fx;
                        ma = n地面a[t_] - fx;
                        nプレイヤーb = n地面b[t_] - fy;
                        n中間フラグ--; xx_17++;

                        n地面a[t_] = -80000000;
                    }
                }
                n中間フラグ += xx_17;
            }
            //tyobi(1,2,3);



        }//stage()

        static void stagep()
        {

            //fzx=6000*100;
            scrollX = 3600 * 100;


            //1-レンガ,2-コイン,3-空,4-土台//5-6地面//7-隠し//

            //ステージ呼び出し
            Stage();

        }//stagep

        static void tekizimen(int t_)
        {

            //壁
            for (int tt_ = 0; tt_ < n地面max; tt_++)
            {
                if (n地面a[tt_] - fx + n地面c[tt_] >= -12010 && n地面a[tt_] - fx <= W + 12100 && n地面type[tt_] <= 99)
                {
                    xx_0 = 200; xx_2 = 1000;
                    xx_1 = 2000;//anobia[t]

                    xx_8 = n地面a[tt_] - fx; xx_9 = n地面b[tt_] - fy;
                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 - xx_0 && n敵キャラa[t_] - fx < xx_8 + xx_2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_1 * 3 / 4 && n敵キャラb[t_] - fy < xx_9 + n地面d[tt_] - xx_2) { n敵キャラa[t_] = xx_8 - xx_0 - n敵キャラnobia[t_] + fx; n敵キャラmuki[t_] = 0; }
                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + n地面c[tt_] - xx_0 && n敵キャラa[t_] - fx < xx_8 + n地面c[tt_] + xx_0 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_1 * 3 / 4 && n敵キャラb[t_] - fy < xx_9 + n地面d[tt_] - xx_2) { n敵キャラa[t_] = xx_8 + n地面c[tt_] + xx_0 + fx; n敵キャラmuki[t_] = 1; }

                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 && n敵キャラa[t_] - fx < xx_8 + n地面c[tt_] - xx_0 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + n地面d[tt_] - xx_1 && n敵キャラd[t_] >= -100) { n敵キャラb[t_] = n地面b[tt_] - fy - n敵キャラnobib[t_] + 100 + fy; n敵キャラd[t_] = 0; n敵キャラxzimen[t_] = 1; }

                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 && n敵キャラa[t_] - fx < xx_8 + n地面c[tt_] - xx_0 && n敵キャラb[t_] - fy > xx_9 + n地面d[tt_] - xx_1 && n敵キャラb[t_] - fy < xx_9 + n地面d[tt_] + xx_0)
                    {
                        n敵キャラb[t_] = xx_9 + n地面d[tt_] + xx_0 + fy; if (n敵キャラd[t_] < 0) { n敵キャラd[t_] = -n敵キャラd[t_] * 2 / 3; }//axzimen[t]=1;
                    }

                }
            }

            //ブロック
            for (int tt_ = 0; tt_ < nブロックmax; tt_++)
            {
                xx_0 = 200; xx_1 = 3000; xx_2 = 1000;
                xx_8 = nブロックa[tt_] - fx; xx_9 = nブロックb[tt_] - fy;
                if (nブロックa[tt_] - fx + xx_1 >= -12010 && nブロックa[tt_] - fx <= W + 12000)
                {
                    if (n敵キャラtype[t_] != 86 && n敵キャラtype[t_] != 90 && nブロックtype[tt_] != 140)
                    {

                        //上
                        if (nブロックtype[tt_] != 7)
                        {
                            if (!(nブロックtype[tt_] == 117))
                            {
                                if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 && n敵キャラa[t_] - fx < xx_8 + xx_1 - xx_0 * 1 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 && n敵キャラd[t_] >= -100)
                                {
                                    n敵キャラb[t_] = xx_9 - n敵キャラnobib[t_] + 100 + fy; n敵キャラd[t_] = 0; n敵キャラxzimen[t_] = 1;
                                    //ジャンプ台
                                    if (nブロックtype[tt_] == 120) { n敵キャラd[t_] = -1600; n敵キャラzimentype[t_] = 30; }
                                }
                            }
                        }

                        //下
                        if (nブロックtype[tt_] != 117)
                        {
                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 && n敵キャラa[t_] - fx < xx_8 + xx_1 - xx_0 * 1 && n敵キャラb[t_] - fy > xx_9 + xx_1 - xx_1 && n敵キャラb[t_] - fy < xx_9 + xx_1 + xx_0)
                            {
                                n敵キャラb[t_] = xx_9 + xx_1 + xx_0 + fy; if (n敵キャラd[t_] < 0) { n敵キャラd[t_] = 0; }                                                             //}
                            }
                        }

                        //左右
                        int xx_27 = 0;
                        if ((n敵キャラtype[t_] >= 100 || (nブロックtype[tt_] != 7 || nブロックtype[tt_] == 7 && n敵キャラtype[t_] == 2)) && nブロックtype[tt_] != 117)
                        {
                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 && n敵キャラa[t_] - fx < xx_8 + xx_2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_1 / 2 - xx_0 && n敵キャラb[t_] - fy < xx_9 + xx_2) { n敵キャラa[t_] = xx_8 - n敵キャラnobia[t_] + fx; n敵キャラc[t_] = 0; n敵キャラmuki[t_] = 0; xx_27 = 1; }
                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_1 - xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + xx_1 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_1 / 2 - xx_0 && n敵キャラb[t_] - fy < xx_9 + xx_2) { n敵キャラa[t_] = xx_8 + xx_1 + fx; n敵キャラc[t_] = 0; n敵キャラmuki[t_] = 1; xx_27 = 1; }
                            //こうらブレイク
                            if (xx_27 == 1 && (nブロックtype[tt_] == 7 || nブロックtype[tt_] == 1) && n敵キャラtype[t_] == 2)
                            {
                                if (nブロックtype[tt_] == 7)
                                {
                                    v効果音再生(Res.nオーディオ_[4]); nブロックtype[tt_] = 3;
                                    eyobi(nブロックa[tt_] + 10, nブロックb[tt_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                }
                                else if (nブロックtype[tt_] == 1)
                                {
                                    v効果音再生(Res.nオーディオ_[3]);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    brockBreak(tt_);
                                }

                            }
                        }
                    }
                    if (n敵キャラtype[t_] == 86 || n敵キャラtype[t_] == 90)
                    {
                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 && n敵キャラa[t_] - fx < xx_8 + xx_1 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 && n敵キャラb[t_] - fy < xx_9 + xx_1)
                        {
                            v効果音再生(Res.nオーディオ_[3]);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                            brockBreak(tt_);

                        }
                    }//90
                }
                //剣とってクリア
                if (nブロックtype[tt_] == 140)
                {
                    if (n敵キャラb[t_] - fy > xx_9 - xx_0 * 2 - 2000 && n敵キャラb[t_] - fy < xx_9 + xx_1 - xx_0 * 2 + 2000 && n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 - 400 && n敵キャラa[t_] - fx < xx_8 + xx_1)
                    {
                        nブロックa[tt_] = -800000;
                        nリフトacttype[20] = 1; nリフトon[20] = 1;
                    }
                }
            }

        }
    }
}

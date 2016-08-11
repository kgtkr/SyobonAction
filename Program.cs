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
        static void Main(string[] args)
        {
            //applog無効
            DX.SetOutApplicationLogValidFlag(DX.FALSE);
            //画面サイズ設定
            DX.SetGraphMode(n画面幅 / 100, n画面高さ / 100, 16);
            //最大化の防止
            DX.ChangeWindowMode(DX.TRUE);
            //タイトルの変更
            DX.SetMainWindowText("しょぼんのアクション");
                        //アイコン
            DX.SetWindowIconHandle(Properties.Resources.icon.Handle);


            // ＤＸライブラリ初期化処理(エラーが起きたら直ちに終了)
            if (DX.DxLib_Init() == -1) return;

            //初期化
            Res.Init();
            Key.Init();

            //フォント
            DX.SetFontSize(16);
            DX.SetFontThickness(4);

            //ループ
            while (DX.ProcessMessage() == 0 && !Key.GetKey(DX.KEY_INPUT_ESCAPE))
            {
                long nタイマー測定 = DX.GetNowCount();

                Key.Update();

                //処理
                Mainprogram();
                //描画
                Draw();

                //30-fps
                xx_0 = 30;
                if (Key.GetKey(DX.KEY_INPUT_SPACE)) {
                    xx_0 = 60;
                }

                while (DX.GetNowCount() - nタイマー測定 < 1000 / xx_0) ;
            }

            //ＤＸライブラリ使用の終了処理
            DX.DxLib_End();
        }

        //音楽再生
        static void v効果音再生(int x)
        {
            DX.PlaySoundMem(x, DX.DX_PLAYTYPE_BACK);
        }

        //BGM変更
        static void bgmChange(int x)
        {
            DX.StopSoundMem(Res.n現在のBGM);
            Res.n現在のBGM = 0;
            Res.n現在のBGM = x;
        }

        //ブロック出現

        static void tyobi(int x, int y, int type)
        {

            nブロック[nブロックco].a = x * 100; nブロック[nブロックco].b = y * 100; nブロック[nブロックco].type = type;

            nブロックco++; if (nブロックco >= nブロックmax) nブロックco = 0;
        }//tyobi


        //ブロック破壊
        static void brockBreak(int t)
        {
            nブロック[t].a = -800000;
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

            n絵[n絵co].a = xa; n絵[n絵co].b = xb; n絵[n絵co].c = xc; n絵[n絵co].d = xd; n絵[n絵co].e = xe; n絵[n絵co].f = xf;
            n絵[n絵co].gtype = xgtype; n絵[n絵co].tm = xtm;
            n絵[n絵co].nobia = xnobia; n絵[n絵co].nobib = xnobib;

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
                if (n敵キャラ[n敵キャラco].a >= -9000 && n敵キャラ[n敵キャラco].a <= 30000) t1 = 0; rz++;

                if (rz <= n敵キャラmax)
                {
                    t1 = 3;

                    n敵キャラ[n敵キャラco].a = xa;
                    n敵キャラ[n敵キャラco].b = xb;
                    n敵キャラ[n敵キャラco].c = xc;
                    n敵キャラ[n敵キャラco].d = xd;
                    if (xxtype > 100) n敵キャラ[n敵キャラco].c = xxtype;
                    n敵キャラ[n敵キャラco].type = xtype;
                    if (xxtype >= 0 && xxtype <= 99100) n敵キャラ[n敵キャラco].xtype = xxtype;//ahp[aco]=iz[bxtype[t]];aytm[aco]=0;
                                                                             //if (xxtype==1)end();
                    n敵キャラ[n敵キャラco].notm = xnotm;
                    if (n敵キャラ[n敵キャラco].a - fx <= ma + nプレイヤーnobia / 2) n敵キャラ[n敵キャラco].muki = 1;
                    if (n敵キャラ[n敵キャラco].a - fx > ma + nプレイヤーnobia / 2) n敵キャラ[n敵キャラco].muki = 0;
                    if (n敵キャラ[n敵キャラco].brocktm >= 1) n敵キャラ[n敵キャラco].muki = 1;
                    if (n敵キャラ[n敵キャラco].brocktm == 20) n敵キャラ[n敵キャラco].muki = 0;

                    n敵キャラ[n敵キャラco].nobia = Res.n敵サイズ[n敵キャラ[n敵キャラco].type].w;
                    n敵キャラ[n敵キャラco].nobib = Res.n敵サイズ[n敵キャラ[n敵キャラco].type].h;



                    //大砲音
                    if (xtype == 7 && DX.CheckSoundMem(Res.nオーディオ10) == 0) { v効果音再生(Res.nオーディオ10); }
                    //ファイア音
                    if (xtype == 10 && DX.CheckSoundMem(Res.nオーディオ18) == 0) { v効果音再生(Res.nオーディオ18); }


                    n敵キャラ[n敵キャラco].zimentype = 1;

                    if (xtype == 87) { n敵キャラ[n敵キャラco].tm = DX.GetRand(179) + (-90); }

                    n敵キャラco += 1; if (n敵キャラco >= n敵キャラmax - 1) { n敵キャラco = 0; }
                }//t1

            }//rz

        }//ayobi

        static void stagecls()
        {
            for (int t_ = 0; t_ < n地面max; t_++) { n地面[t_].a = -9000000; n地面[t_].b = 1; n地面[t_].c = 1; n地面[t_].d = 1; n地面[t_].gtype = 0; n地面[t_].type = 0; n地面[t_].xtype = 0; }
            for (int t_ = 0; t_ < nブロックmax; t_++) { nブロック[t_].a = -9000000; nブロック[t_].b = 1; nブロック[t_].c = 1; nブロック[t_].d = 1; nブロック[t_].item = 0; nブロック[t_].xtype = 0; }
            for (int t_ = 0; t_ < nリフトmax; t_++) { nリフト[t_].a = -9000000; nリフト[t_].b = 1; nリフト[t_].c = 1; nリフト[t_].d = 1; nリフト[t_].e = 0; nリフト[t_].f = 0; nリフト[t_].muki = 0; nリフト[t_].on = 0; nリフト[t_].ee = 0; nリフト[t_].sok = 0; nリフト[t_].move = 0; nリフト[t_].movep = 0; nリフト[t_].sp = 0; }
            for (int t_ = 0; t_ < n敵キャラmax; t_++) { n敵キャラ[t_].a = -9000000; n敵キャラ[t_].b = 1; n敵キャラ[t_].c = 0; n敵キャラ[t_].d = 1; n敵キャラ[t_].zimentype = 0; n敵キャラ[t_].type = 0; n敵キャラ[t_].xtype = 0; n敵キャラ[t_].e = 0; n敵キャラ[t_].f = 0; n敵キャラ[t_].tm = 0; n敵キャラ[t_]._2tm = 0; n敵キャラ[t_].brocktm = 0; n敵キャラ[t_].msgtm = 0; }
            for (int t_ = 0; t_ < n敵出現max; t_++) { n敵出現[t_].a = -9000000; n敵出現[t_].b = 1; n敵出現[t_].z = 1; n敵出現[t_].tm = 0; n敵出現[t_].xtype = 0; }
            for (int t_ = 0; t_ < n絵max; t_++) { n絵[t_].a = -9000000; n絵[t_].b = 1; n絵[t_].c = 1; n絵[t_].d = 1; n絵[t_].gtype = 0; }
            for (int t_ = 0; t_ < n背景max; t_++)
            {
                n背景[t_].a = -9000000;
                n背景[t_].b = 1;
                n背景[t_].c = 1;
                n背景[t_].d = 1;
                Res.n背景サイズ[t_].w = 1;
                Res.n背景サイズ[t_].h = 1;
                n背景[t_].g = 0;
                n背景[t_].type = 0;
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
                    if (xx_10 >= 20 && xx_10 <= 29) { nリフト[nリフトco].a = xx_21 * 100; nリフト[nリフトco].b = xx_22 * 100; nリフト[nリフトco].c = 3000; nリフト[nリフトco].type = 0; nリフトco++; if (nリフトco >= nリフトmax) nリフトco = 0; }
                    if (xx_10 == 30) { n地面[n地面co].a = xx_21 * 100; n地面[n地面co].b = xx_22 * 100; n地面[n地面co].c = 3000; n地面[n地面co].d = 6000; n地面[n地面co].type = 500; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx_10 == 40) { n地面[n地面co].a = xx_21 * 100; n地面[n地面co].b = xx_22 * 100; n地面[n地面co].c = 6000; n地面[n地面co].d = 3000; n地面[n地面co].type = 1; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx_10 == 41) { n地面[n地面co].a = xx_21 * 100 + 500; n地面[n地面co].b = xx_22 * 100; n地面[n地面co].c = 5000; n地面[n地面co].d = 3000; n地面[n地面co].type = 2; n地面co++; if (n地面co >= n地面max) n地面co = 0; }

                    if (xx_10 == 43) { n地面[n地面co].a = xx_21 * 100; n地面[n地面co].b = xx_22 * 100 + 500; n地面[n地面co].c = 2900; n地面[n地面co].d = 5300; n地面[n地面co].type = 1; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx_10 == 44) { n地面[n地面co].a = xx_21 * 100; n地面[n地面co].b = xx_22 * 100 + 700; n地面[n地面co].c = 3900; n地面[n地面co].d = 5000; n地面[n地面co].type = 5; n地面co++; if (n地面co >= n地面max) n地面co = 0; }

                    //これなぜかバグの原因ｗ
                    if (xx_10 >= 50 && xx_10 <= 79)
                    {
                        n敵出現[n敵出現co].a = xx_21 * 100; n敵出現[n敵出現co].b = xx_22 * 100; n敵出現[n敵出現co].type = xx_23 - 50; n敵出現co++; if (n敵出現co >= n敵出現max) n敵出現co = 0;
                    }

                    if (xx_10 >= 80 && xx_10 <= 89) { n背景[n背景co].a = xx_21 * 100; n背景[n背景co].b = xx_22 * 100; n背景[n背景co].type = xx_23 - 80; n背景co++; if (n背景co >= n背景max) n背景co = 0; }

                    //コイン
                    if (xx_10 == 9) { tyobi(tt_ * 29, t_ * 29 - 12, 800); }
                    if (xx_10 == 99) { n地面[n地面co].a = xx_21 * 100; n地面[n地面co].b = xx_22 * 100; n地面[n地面co].c = 3000; n地面[n地面co].d = (12 - t_) * 3000; n地面[n地面co].type = 300; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                }
            }

            if (n中間フラグ >= 1)
            {
                xx_17 = 0;
                for (int t_ = 0; t_ < n地面max; t_++)
                {
                    if (n地面[t_].type == 500 && n中間フラグ >= 1)
                    {
                        fx = n地面[t_].a - n画面幅 / 2; fzx = fx;
                        ma = n地面[t_].a - fx;
                        nプレイヤーb = n地面[t_].b - fy;
                        n中間フラグ--; xx_17++;

                        n地面[t_].a = -80000000;
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
                if (n地面[tt_].a - fx + n地面[tt_].c >= -12010 && n地面[tt_].a - fx <= n画面幅 + 12100 && n地面[tt_].type <= 99)
                {
                    xx_0 = 200; xx_2 = 1000;
                    xx_1 = 2000;//anobia[t]

                    xx_8 = n地面[tt_].a - fx; xx_9 = n地面[tt_].b - fy;
                    if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 - xx_0 && n敵キャラ[t_].a - fx < xx_8 + xx_2 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 + xx_1 * 3 / 4 && n敵キャラ[t_].b - fy < xx_9 + n地面[tt_].d - xx_2) { n敵キャラ[t_].a = xx_8 - xx_0 - n敵キャラ[t_].nobia + fx; n敵キャラ[t_].muki = 0; }
                    if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + n地面[tt_].c - xx_0 && n敵キャラ[t_].a - fx < xx_8 + n地面[tt_].c + xx_0 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 + xx_1 * 3 / 4 && n敵キャラ[t_].b - fy < xx_9 + n地面[tt_].d - xx_2) { n敵キャラ[t_].a = xx_8 + n地面[tt_].c + xx_0 + fx; n敵キャラ[t_].muki = 1; }

                    if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + xx_0 && n敵キャラ[t_].a - fx < xx_8 + n地面[tt_].c - xx_0 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy < xx_9 + n地面[tt_].d - xx_1 && n敵キャラ[t_].d >= -100) { n敵キャラ[t_].b = n地面[tt_].b - fy - n敵キャラ[t_].nobib + 100 + fy; n敵キャラ[t_].d = 0; n敵キャラ[t_].xzimen = 1; }

                    if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + xx_0 && n敵キャラ[t_].a - fx < xx_8 + n地面[tt_].c - xx_0 && n敵キャラ[t_].b - fy > xx_9 + n地面[tt_].d - xx_1 && n敵キャラ[t_].b - fy < xx_9 + n地面[tt_].d + xx_0)
                    {
                        n敵キャラ[t_].b = xx_9 + n地面[tt_].d + xx_0 + fy; if (n敵キャラ[t_].d < 0) { n敵キャラ[t_].d = -n敵キャラ[t_].d * 2 / 3; }//axzimen[t]=1;
                    }

                }
            }

            //ブロック
            for (int tt_ = 0; tt_ < nブロックmax; tt_++)
            {
                xx_0 = 200; xx_1 = 3000; xx_2 = 1000;
                xx_8 = nブロック[tt_].a - fx; xx_9 = nブロック[tt_].b - fy;
                if (nブロック[tt_].a - fx + xx_1 >= -12010 && nブロック[tt_].a - fx <= n画面幅 + 12000)
                {
                    if (n敵キャラ[t_].type != 86 && n敵キャラ[t_].type != 90 && nブロック[tt_].type != 140)
                    {

                        //上
                        if (nブロック[tt_].type != 7)
                        {
                            if (!(nブロック[tt_].type == 117))
                            {
                                if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + xx_0 && n敵キャラ[t_].a - fx < xx_8 + xx_1 - xx_0 * 1 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy < xx_9 + xx_1 && n敵キャラ[t_].d >= -100)
                                {
                                    n敵キャラ[t_].b = xx_9 - n敵キャラ[t_].nobib + 100 + fy; n敵キャラ[t_].d = 0; n敵キャラ[t_].xzimen = 1;
                                    //ジャンプ台
                                    if (nブロック[tt_].type == 120) { n敵キャラ[t_].d = -1600; n敵キャラ[t_].zimentype = 30; }
                                }
                            }
                        }

                        //下
                        if (nブロック[tt_].type != 117)
                        {
                            if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + xx_0 && n敵キャラ[t_].a - fx < xx_8 + xx_1 - xx_0 * 1 && n敵キャラ[t_].b - fy > xx_9 + xx_1 - xx_1 && n敵キャラ[t_].b - fy < xx_9 + xx_1 + xx_0)
                            {
                                n敵キャラ[t_].b = xx_9 + xx_1 + xx_0 + fy; if (n敵キャラ[t_].d < 0) { n敵キャラ[t_].d = 0; }                                                             //}
                            }
                        }

                        //左右
                        int xx_27 = 0;
                        if ((n敵キャラ[t_].type >= 100 || (nブロック[tt_].type != 7 || nブロック[tt_].type == 7 && n敵キャラ[t_].type == 2)) && nブロック[tt_].type != 117)
                        {
                            if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 && n敵キャラ[t_].a - fx < xx_8 + xx_2 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 + xx_1 / 2 - xx_0 && n敵キャラ[t_].b - fy < xx_9 + xx_2) { n敵キャラ[t_].a = xx_8 - n敵キャラ[t_].nobia + fx; n敵キャラ[t_].c = 0; n敵キャラ[t_].muki = 0; xx_27 = 1; }
                            if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 + xx_1 - xx_0 * 2 && n敵キャラ[t_].a - fx < xx_8 + xx_1 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 + xx_1 / 2 - xx_0 && n敵キャラ[t_].b - fy < xx_9 + xx_2) { n敵キャラ[t_].a = xx_8 + xx_1 + fx; n敵キャラ[t_].c = 0; n敵キャラ[t_].muki = 1; xx_27 = 1; }
                            //こうらブレイク
                            if (xx_27 == 1 && (nブロック[tt_].type == 7 || nブロック[tt_].type == 1) && n敵キャラ[t_].type == 2)
                            {
                                if (nブロック[tt_].type == 7)
                                {
                                    v効果音再生(Res.nオーディオ4); nブロック[tt_].type = 3;
                                    eyobi(nブロック[tt_].a + 10, nブロック[tt_].b, 0, -800, 0, 40, 3000, 3000, 0, 16);
                                }
                                else if (nブロック[tt_].type == 1)
                                {
                                    v効果音再生(Res.nオーディオ3);
                                    eyobi(nブロック[tt_].a + 1200, nブロック[tt_].b + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロック[tt_].a + 1200, nブロック[tt_].b + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロック[tt_].a + 1200, nブロック[tt_].b + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロック[tt_].a + 1200, nブロック[tt_].b + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    brockBreak(tt_);
                                }

                            }
                        }
                    }
                    if (n敵キャラ[t_].type == 86 || n敵キャラ[t_].type == 90)
                    {
                        if (n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 && n敵キャラ[t_].a - fx < xx_8 + xx_1 && n敵キャラ[t_].b + n敵キャラ[t_].nobib - fy > xx_9 && n敵キャラ[t_].b - fy < xx_9 + xx_1)
                        {
                            v効果音再生(Res.nオーディオ3);
                            eyobi(nブロック[tt_].a + 1200, nブロック[tt_].b + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロック[tt_].a + 1200, nブロック[tt_].b + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロック[tt_].a + 1200, nブロック[tt_].b + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロック[tt_].a + 1200, nブロック[tt_].b + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                            brockBreak(tt_);

                        }
                    }//90
                }
                //剣とってクリア
                if (nブロック[tt_].type == 140)
                {
                    if (n敵キャラ[t_].b - fy > xx_9 - xx_0 * 2 - 2000 && n敵キャラ[t_].b - fy < xx_9 + xx_1 - xx_0 * 2 + 2000 && n敵キャラ[t_].a + n敵キャラ[t_].nobia - fx > xx_8 - 400 && n敵キャラ[t_].a - fx < xx_8 + xx_1)
                    {
                        nブロック[tt_].a = -800000;
                        nリフト[20].acttype = 1; nリフト[20].on = 1;
                    }
                }
            }

        }
    }
}
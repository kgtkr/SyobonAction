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
            //画面サイズ設定
            DX.SetGraphMode(n画面幅 / 100, n画面高さ / 100, 16);
            //最大化の防止
            DX.ChangeWindowMode(DX.TRUE);
            //タイトルの変更
            DX.SetMainWindowText("しょぼんのアクション");
            //applog無効
            DX.SetOutApplicationLogValidFlag(DX.FALSE);
            //アイコン
            DX.SetWindowIconHandle(Properties.Resources.icon.Handle);


            // ＤＸライブラリ初期化処理(エラーが起きたら直ちに終了)
            if (DX.DxLib_Init() == -1) return;

            //全ロード
            Load();
            Key.Init();

            //フォント
            DX.SetFontSize(16);
            DX.SetFontThickness(4);

            //ループ
            while (DX.ProcessMessage() == 0 && !Key.GetKey(DX.KEY_INPUT_ESCAPE))
            {
                Key.Update();

                maint = 0;
                //処理
                Mainprogram();

                //描画
                Draw();

                //30-fps
                xx[0] = 30;
                if (Key.GetKey(DX.KEY_INPUT_SPACE)) {
                    xx[0] = 60;
                }
                wait2(nタイマー測定, DX.GetNowCount(), 1000 / xx[0]);

                if (maint == 3) break;
            }

            //ＤＸライブラリ使用の終了処理
            DX.DxLib_End();
        }

        //タイマー測定
        static void wait2(long stime, long etime, int FLAME_TIME)
        {
            if (etime - stime < FLAME_TIME)
                DX.WaitTimer((int)(FLAME_TIME - (etime - stime)));
        }

        //音楽再生
        static void v効果音再生(int x)
        {
            DX.PlaySoundMem(x, DX.DX_PLAYTYPE_BACK);
        }

        //BGM変更
        static void bgmChange(int x)
        {
            DX.StopSoundMem(nオーディオ_[0]);
            nオーディオ_[0] = 0;
            nオーディオ_[0] = x;
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
            xx[1] = 6000 / 100; xx[2] = 4000 / 100;
            if (nメッセージブロックtype == 1 || nメッセージブロックtype == 2)
            {
                DXDraw.SetColorBlack();
                DXDraw.DrawBox塗り潰し(xx[1], xx[2], 360, nメッセージブロックy / 100);
                DXDraw.SetColorWhite();
                DXDraw.DrawBox塗り無し(xx[1], xx[2], 360, nメッセージブロックy / 100);
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
                xx[5] = (((15 - 1) * 1200 + 1500) / 100 - nメッセージブロックy / 100);
                if (xx[5] > 0)
                {
                    DXDraw.SetColorBlack();
                    DXDraw.DrawBox塗り潰し(xx[1], xx[2] + nメッセージブロックy / 100, 360, xx[5]);
                    DXDraw.SetColorWhite();
                    DXDraw.DrawBox塗り無し(xx[1], xx[2] + nメッセージブロックy / 100, 360, xx[5]);
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

            n絵co++; if (n絵co >= n絵max) n絵co = 0;

        }//eyobi


        //敵キャラ、アイテム作成
        static void ayobi(int xa, int xb, int xc, int xd, int xnotm, int xtype, int xxtype)
        {
            int rz = 0;
            for (t1 = 0; t1 <= 1; t1++)
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
                    //ae[aco]=0;af[aco]=0;
                    n敵キャラtype[n敵キャラco] = xtype;
                    if (xxtype >= 0 && xxtype <= 99100) n敵キャラxtype[n敵キャラco] = xxtype;//ahp[aco]=iz[bxtype[t]];aytm[aco]=0;
                                                                             //if (xxtype==1)end();
                    n敵キャラnotm[n敵キャラco] = xnotm;
                    if (n敵キャラa[n敵キャラco] - fx <= ma + nプレイヤーnobia / 2) n敵キャラmuki[n敵キャラco] = 1;
                    if (n敵キャラa[n敵キャラco] - fx > ma + nプレイヤーnobia / 2) n敵キャラmuki[n敵キャラco] = 0;
                    if (n敵キャラbrocktm[n敵キャラco] >= 1) n敵キャラmuki[n敵キャラco] = 1;
                    if (n敵キャラbrocktm[n敵キャラco] == 20) n敵キャラmuki[n敵キャラco] = 0;

                    n敵キャラnobia[n敵キャラco] = n敵サイズW_[n敵キャラtype[n敵キャラco]]; n敵キャラnobib[n敵キャラco] = n敵サイズH_[n敵キャラtype[n敵キャラco]];



                    //大砲音
                    if (xtype == 7 && DX.CheckSoundMem(nオーディオ_[10]) == 0) { v効果音再生(nオーディオ_[10]); }
                    //ファイア音
                    if (xtype == 10 && DX.CheckSoundMem(nオーディオ_[18]) == 0) { v効果音再生(nオーディオ_[18]); }


                    n敵キャラzimentype[n敵キャラco] = 1;

                    if (xtype == 87) { n敵キャラtm[n敵キャラco] = DX.GetRand(179) + (-90); }

                    n敵キャラco += 1; if (n敵キャラco >= n敵キャラmax - 1) { n敵キャラco = 0; }
                }//t1

            }//rz

        }//ayobi
    }
}
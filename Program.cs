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
            DX.SetGraphMode(fxmax / 100, fymax / 100, 16);
            //最大化の防止
            DX.ChangeWindowMode(DX.TRUE);
            //タイトルの変更
            DX.SetMainWindowText("しょぼんのアクション");
            //applog無効
            DX.SetOutApplicationLogValidFlag(DX.FALSE);


            // ＤＸライブラリ初期化処理(エラーが起きたら直ちに終了)
            if (DX.DxLib_Init() == -1) return;

            // 点を打つ
            //DrawPixel( 320 , 240 , 0xffff ) ;

            // キー入力待ち
            //WaitKey();


            //全ロード
            Load();

            //フォント
            DX.SetFontSize(16);
            DX.SetFontThickness(4);

            //ループ
            //for (maint=0;maint<=2;maint++){
            while (DX.ProcessMessage() == 0 && DX.CheckHitKey(DX.KEY_INPUT_ESCAPE) == 0)
            {
                maint = 0; Mainprogram();
                if (maint == 3) break;
            }



            //ＤＸライブラリ使用の終了処理
            DX.DxLib_End();
        }


        //スリープ
        static void wait(int interval)
        {
            DX.WaitTimer(interval);
        }

        //タイマー測定
        static void wait2(long stime, long etime, int FLAME_TIME)
        {
            if (etime - stime < FLAME_TIME)
                wait((int)(FLAME_TIME - (etime - stime)));
        }


        //乱数作成
        static int rand(int Rand)
        {
            return DX.GetRand(Rand);
        }

        //終了
        static void end()
        {
            //maint=3;
            DX.DxLib_End();
        }


        //画像関係
        //{
        //色かえ(指定)
        static void setcolor(int red, int green, int blue)
        {
            color = DX.GetColor(red, green, blue);
        }
        //色かえ(黒)(白)
        static void setc0() { color = DX.GetColor(0, 0, 0); }
        static void setc1() { color = DX.GetColor(255, 255, 255); }

        //点
        static void drawpixel(int a, int b) { DX.DrawPixel(a, b, color); }
        //線
        static void drawline(int a, int b, int c, int d) { DX.DrawLine(a, b, c, d, color); }
        //四角形(塗り無し)
        static void drawrect(int a, int b, int c, int d) { DX.DrawBox(a, b, a + c, b + d, color, DX.FALSE); }
        //四角形(塗り有り)
        static void fillrect(int a, int b, int c, int d) { DX.DrawBox(a, b, a + c, b + d, color, DX.TRUE); }
        //円(塗り無し)
        static void drawarc(int a, int b, int c, int d) { DX.DrawOval(a, b, c, d, color, DX.FALSE); }
        //円(塗り有り)
        static void fillarc(int a, int b, int c, int d) { DX.DrawOval(a, b, c, d, color, DX.TRUE); }

        //画像の読み込み
        static int loadimage(string x)
        {
            //mgrap[a]=LoadGraph(b);
            return DX.LoadGraph(x);
        }
        static int loadimage(int a, int x, int y, int r, int z)
        {
            return DX.DerivationGraph(x, y, r, z, a);
        }

        //画像表示
        static void drawimage(int mx, int a, int b)
        {
            if (mirror == 0)
                DX.DrawGraph(a, b, mx, DX.TRUE);
            if (mirror == 1)
                DX.DrawTurnGraph(a, b, mx, DX.TRUE);
        }
        static void drawimage(int mx, int a, int b, int c, int d, int e, int f)
        {
            int m;
            m = DX.DerivationGraph(c, d, e, f, mx);
            if (mirror == 0)
                DX.DrawGraph(a, b, m, DX.TRUE);
            if (mirror == 1)
                DX.DrawTurnGraph(a, b, m, DX.TRUE);
        }

        //反転
        static void setre() { }
        static void setre2() { }
        static void setno() { }

        //文字
        static void str(string x, int a, int b)
        {
            DX.DrawString(a, b, x, color);

            xx[2] = 4;


        }



        //文字ラベル変更
        static void setfont(int a)
        {
        }

        //音楽再生
        static void ot(int x)
        {
            DX.PlaySoundMem(x, DX.DX_PLAYTYPE_BACK);
        }




        //BGM変更
        static void bgmchange(int x)
        {
            DX.StopSoundMem(nオーディオ[0]);
            nオーディオ[0] = 0;
            nオーディオ[0] = x;
        }//bgmchange()




        //ブロック出現

        static void tyobi(int x, int y, int type)
        {

            ta[tco] = x * 100; tb[tco] = y * 100; ttype[tco] = type;

            tco++; if (tco >= tmax) tco = 0;
        }//tyobi


        //ブロック破壊
        static void brockbreak(int t)
        {
            if (titem[t] == 1)
            {
            }
            if (titem[t] >= 2 && titem[t] <= 7)
            {
            }

            ta[t] = -800000;
        }//brock


        //メッセージ
        static void ttmsg()
        {
            xx[1] = 6000 / 100; xx[2] = 4000 / 100;
            if (tmsgtype == 1 || tmsgtype == 2)
            {
                setc0();
                fillrect(xx[1], xx[2], 360, tmsgy / 100);
                setc1();
                drawrect(xx[1], xx[2], 360, tmsgy / 100);
            }
            if (tmsgtype == 2)
            {
                //フォント
                setfont(20, 5);

                if (tmsg == 0)
                {
                    setc1();
                    //フォント
                    setfont(20, 5);
                    txmsg("テスト　hoge", 0);
                }

                if (tmsg == 1)
                {
                    setc1();
                    txmsg("", 0);
                    txmsg("ステージ 1 より", 0);
                    txmsg("特殊的なものが増えたので", 1);
                    txmsg("気をつけてくれよ～", 2);
                    txmsg("後、アイテムの一部を利用するかも…", 4);
                    txmsg("                       ちく より", 6);
                }

                if (tmsg == 2)
                {
                    txmsg("            ？が必要です ", 3);
                    txmsg("                         m9(^Д^)", 6);
                }


                if (tmsg == 3)
                {
                    txmsg("   別にコインに意味ないけどね ", 3);
                    txmsg("                      (・ω・ )ﾉｼ", 6);
                }

                if (tmsg == 4)
                {
                    txmsg("この先に隠しブロックがあります ", 2);
                    txmsg("注意してください !!", 4);
                }


                if (tmsg == 5)
                {
                    txmsg("", 0);
                    txmsg(" 前回よりも難易度を下げましたので", 1);
                    txmsg(" 気楽にプレイしてください    ", 3);
                    txmsg("                       ちく より", 6);
                }

                if (tmsg == 6)
                {
                    txmsg("", 0);
                    txmsg(" そこにいる敵のそばによると、      ", 1);
                    txmsg(" 自分と一緒にジャンプしてくれます。", 2);
                    txmsg("   可愛いですね。                  ", 3);
                }

                if (tmsg == 7)
                {
                    txmsg("", 0);
                    txmsg(" あの敵は連れて来れましたか?、     ", 1);
                    txmsg(" 連れて来れなかった貴方は、        ", 2);
                    txmsg(" そこの落とし穴から Let's dive!    ", 3);
                }

                if (tmsg == 8)
                {
                    txmsg("そんな容易に", 1);
                    txmsg("ヒントに頼るもんじゃないぜ", 2);
                    txmsg("ほら、さっさと次行きな!!", 3);
                }

                if (tmsg == 9)
                {
                    txmsg(" 正真正銘のファイナルステージ。    ", 1);
                    txmsg(" クリアすれば遂にエンディング!!    ", 2);
                    txmsg(" その土管から戻ってもいいんだぜ?   ", 3);
                }

                if (tmsg == 10)
                {
                    txmsg(" 床が凍ってるから、すっごい滑るよ。", 1);
                    txmsg(" ", 2);
                    txmsg(" 　                      ", 3);
                }

                if (tmsg == 100)
                {
                    txmsg("え？私ですか？ ", 0);
                    txmsg("いやぁ、ただの通りすがりの", 2);
                    txmsg("ヒントブロックですよ～", 3);
                    txmsg("決して怪しいブロックじゃないですよ", 5);
                    txmsg("                          (…チッ)", 6);
                }


                setfont(16, 4);
            }//2

            if (tmsgtype == 3)
            {
                xx[5] = (((15 - 1) * 1200 + 1500) / 100 - tmsgy / 100);
                if (xx[5] > 0)
                {
                    setc0();
                    fillrect(xx[1], xx[2] + tmsgy / 100, 360, xx[5]);
                    setc1();
                    drawrect(xx[1], xx[2] + tmsgy / 100, 360, xx[5]);
                }
            }

        }//ttmsg

        static void txmsg(string x, int a)
        {
            int xx = 6;

            str(x, 60 + xx, 40 + xx + a * 24);

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

            ea[eco] = xa; eb[eco] = xb; ec[eco] = xc; ed[eco] = xd; ee[eco] = xe; ef[eco] = xf;
            egtype[eco] = xgtype; etm[eco] = xtm;
            enobia[eco] = xnobia; enobib[eco] = xnobib;

            eco++; if (eco >= emax) eco = 0;

        }//eyobi








        //敵キャラ、アイテム作成
        static void ayobi(int xa, int xb, int xc, int xd, int xnotm, int xtype, int xxtype)
        {
            int rz = 0;
            for (t1 = 0; t1 <= 1; t1++)
            {
                t1 = 2;
                if (aa[aco] >= -9000 && aa[aco] <= 30000) t1 = 0; rz++;

                if (rz <= amax)
                {
                    t1 = 3;

                    aa[aco] = xa;
                    ab[aco] = xb;
                    ac[aco] = xc;
                    ad[aco] = xd;
                    if (xxtype > 100) ac[aco] = xxtype;
                    //ae[aco]=0;af[aco]=0;
                    atype[aco] = xtype;
                    if (xxtype >= 0 && xxtype <= 99100) axtype[aco] = xxtype;//ahp[aco]=iz[bxtype[t]];aytm[aco]=0;
                                                                             //if (xxtype==1)end();
                    anotm[aco] = xnotm;
                    if (aa[aco] - fx <= ma + mnobia / 2) amuki[aco] = 1;
                    if (aa[aco] - fx > ma + mnobia / 2) amuki[aco] = 0;
                    if (abrocktm[aco] >= 1) amuki[aco] = 1;
                    if (abrocktm[aco] == 20) amuki[aco] = 0;

                    anobia[aco] = n敵サイズW[atype[aco]]; anobib[aco] = n敵サイズH[atype[aco]];



                    //大砲音
                    if (xtype == 7 && DX.CheckSoundMem(nオーディオ[10]) == 0) { ot(nオーディオ[10]); }
                    //ファイア音
                    if (xtype == 10 && DX.CheckSoundMem(nオーディオ[18]) == 0) { ot(nオーディオ[18]); }


                    azimentype[aco] = 1;

                    if (xtype == 87) { atm[aco] = rand(179) + (-90); }

                    aco += 1; if (aco >= amax - 1) { aco = 0; }
                }//t1

            }//rz

        }//ayobi
    }
}

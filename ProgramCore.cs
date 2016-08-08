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
        static void Draw()
        {
            //ダブルバッファリング
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);

            DX.ClearDrawScreen();

            DXDraw.SetColor(0, 0, 0);
            if (nステージ色 == 1) DXDraw.SetColor(160, 180, 250);
            if (nステージ色 == 2) DXDraw.SetColor(10, 10, 10);
            if (nステージ色 == 3) DXDraw.SetColor(160, 180, 250);
            if (nステージ色 == 4) DXDraw.SetColor(10, 10, 10);
            if (nステージ色 == 5)
            {
                DXDraw.SetColor(160, 180, 250);
                nプレイヤーrzimen = 1;
            }
            else {
                nプレイヤーrzimen = 0;
            }

            DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);


            if (e現在の画面 == E画面.Game && zxon >= 1)
            {
                DrawBack();

                Draw絵();

                Drawリフト();

                DrawPlayer();

                DrawEnemy();

                DrawBlock();

                DrawZimen();

                DrawEnemyファイアバー();

                DrawMsg();

                DrawMsgBlock();


                //メッセージ
                if (nプレイヤーainmsgtype >= 1)
                {
                    setfont(20, 4);
                    if (nプレイヤーainmsgtype == 1) { DX.DrawString(126, 100, "WELCOME TO OWATA ZONE", DX.GetColor(255, 255, 255)); }
                    if (nプレイヤーainmsgtype == 1) { for (t2 = 0; t2 <= 2; t2++) DX.DrawString(88 + t2 * 143, 210, "1", DX.GetColor(255, 255, 255)); }
                    setfont(20, 5);
                }


                //画面黒
                if (blackTm > 0)
                {
                    blackTm--;
                    DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);
                    if (blackTm == 0)
                    {
                        if (blackX == 1) { zxon = 0; }
                    }

                }
            }

            //スタッフロール
            if (e現在の画面 == E画面.Ending)
            {
                Drawスタッフロール();
            }

            //機数表示
            if (e現在の画面 == E画面.機数表示)
            {

                Draw機数表示();
            }


            //タイトル
            if (e現在の画面 == E画面.Title)
            {
                Drawタイトル();

            }

            DX.ScreenFlip();

        }

        static void Mainprogram()
        {
            nタイマー測定 = DX.GetNowCount();


            if (nスタッフロール == 1) e現在の画面 = E画面.Ending;

            if (e現在の画面 == E画面.Game && nメッセージブロックtype == 0)
            {
                if (zxon == 0)
                {
                    zxon = 1;
                    nプレイヤーainmsgtype = 0;

                    nステージ色 = 1;
                    ma = 5600;
                    nプレイヤーb = 32000;
                    nプレイヤーmuki = 1;
                    nプレイヤーhp = 1;

                    nプレイヤーc = 0;
                    nプレイヤーd = 0;

                    nプレイヤーnobia = 3000;
                    nプレイヤーnobib = 3600;

                    nプレイヤーtype = 0;

                    fx = 0; fy = 0;
                    fzx = 0;
                    nステージスイッチ = 0;

                    //チーターマン　入れ
                    bgmChange(Res.nオーディオ_[100]);

                    stagecls();

                    stage();

                    //ランダムにさせる
                    if (over == 1)
                    {
                        for (int t_ = 0; t_ < nブロックmax; t_++)
                        {
                            if (DX.GetRand(3) <= 1)
                            {
                                nブロックa[t_] = (DX.GetRand(500) - 1) * 29 * 100;
                                nブロックb[t_] = DX.GetRand(14) * 100 * 29 - 1200;
                                nブロックtype[t_] = DX.GetRand(142);
                                if (nブロックtype[t_] >= 9 && nブロックtype[t_] <= 99)
                                {
                                    nブロックtype[t_] = DX.GetRand(8);
                                }
                                nブロックxtype[t_] = DX.GetRand(4);
                            }
                        }
                        for (int t_ = 0; t_ < n敵出現max; t_++)
                        {
                            if (DX.GetRand(2) <= 1)
                            {
                                n敵出現a[t_] = (DX.GetRand(500) - 1) * 29 * 100;
                                n敵出現b[t_] = DX.GetRand(15) * 100 * 29 - 1200 - 3000;
                                if (DX.GetRand(6) == 0)
                                {
                                    n敵出現type[t_] = DX.GetRand(9);
                                }
                            }
                        }

                        {
                            nリフトco = 0;
                            int t_ = nリフトco;
                            nリフトa[t_] = ma + fx;
                            nリフトb[t_] = (13 * 29 - 12) * 100;
                            nリフトc[t_] = 30 * 100;
                            nリフトtype[t_] = 0;
                            nリフトacttype[t_] = 0;
                            nリフトe[t_] = 0;
                            nリフトsp[t_] = 0;
                            nリフトco++;
                        }
                        if (DX.GetRand(4) == 0) nステージ色 = DX.GetRand(5);
                    }



                    DX.StopSoundMem(Res.nオーディオ_[0]);


                    //メインBGM
                    DX.PlaySoundMem(Res.nオーディオ_[0], DX.DX_PLAYTYPE_LOOP);


                }//zxon

                //プレイヤー
                UpdatePlayer();

                //ブロック
                UpdateBlock();


                UpdateZimen();

                //キー入力初期化
                nプレイヤーactaon[0] = 0; nプレイヤーactaon[4] = 0;

                Updateリフト();

                Update絵();

                UpdateEnemy();

                //スクロール
                if (n強制スクロール != 1 && n強制スクロール != 2)
                {
                    xx[2] = maScrollMax; xx[3] = 0;
                    xx[1] = xx[2]; if (ma > xx[1] && fzx < scrollX) { xx[5] = ma - xx[1]; ma = xx[1]; fx += xx[5]; fzx += xx[5]; if (xx[1] <= 5000) xx[3] = 1; }
                }//kscroll

            }


            //スタッフロール
            if (e現在の画面 == E画面.Ending)
            {
                Updateスタッフロール();

            }//main==2

            if (e現在の画面 == E画面.機数表示)
            {
                maintm++;

                if (nクイック == 1) maintm += 2;
                if (maintm >= 30) {
                    maintm = 0;
                    e現在の画面 = E画面.Game;
                    zxon = 0;
                }
            }//if (main==10){

            //タイトル
            if (e現在の画面 == E画面.Title)
            {
                Updateタイトル();

            }//100
        }//Mainprogram()
    }
}
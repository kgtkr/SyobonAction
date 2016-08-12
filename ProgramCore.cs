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
                nプレイヤー.rzimen = 1;
            }
            else {
                nプレイヤー.rzimen = 0;
            }

            DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);


            if (e現在の画面 == E画面.Game && b初期化)
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
                if (nプレイヤー.ainmsgtype >= 1)
                {
                    setfont(20, 4);
                    if (nプレイヤー.ainmsgtype == 1) { DX.DrawString(126, 100, "WELCOME TO OWATA ZONE", DX.GetColor(255, 255, 255)); }
                    if (nプレイヤー.ainmsgtype == 1) { for (int t2 = 0; t2 <= 2; t2++) DX.DrawString(88 + t2 * 143, 210, "1", DX.GetColor(255, 255, 255)); }
                    setfont(20, 5);
                }


                //画面黒
                if (blackTm > 0)
                {
                    blackTm--;
                    DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);
                    if (blackTm == 0)
                    {
                        if (blackX == 1) { b初期化 = false; }
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
            if (nスタッフロール == 1) e現在の画面 = E画面.Ending;
            if (Key.GetKey(DX.KEY_INPUT_F1))
            {
                e現在の画面 = E画面.Title;
            }
            if (e現在の画面 == E画面.Game && nメッセージブロックtype == 0)
            {
                if (!b初期化)
                {
                    b初期化 = true;
                    nプレイヤー.ainmsgtype = 0;

                    nステージ色 = 1;
                    ma = 5600;
                    nプレイヤー.b = 32000;
                    nプレイヤー.muki = 1;
                    nプレイヤー.hp = 1;

                    nプレイヤー.c = 0;
                    nプレイヤー.d = 0;

                    nプレイヤー.nobia = 3000;
                    nプレイヤー.nobib = 3600;

                    nプレイヤー.type = 0;

                    fx = 0; fy = 0;
                    fzx = 0;
                    bステージスイッチ = false;

                    //チーターマン　入れ
                    bgmChange(Res.nオーディオ100);

                    stagecls();

                    stage();

                    //ランダムにさせる
                    if (over == 1)
                    {
                        for (int t_ = 0; t_ < nブロックmax; t_++)
                        {
                            if (DX.GetRand(3) <= 1)
                            {
                                nブロック[t_].a = (DX.GetRand(500) - 1) * 29 * 100;
                                nブロック[t_].b = DX.GetRand(14) * 100 * 29 - 1200;
                                nブロック[t_].type = DX.GetRand(142);
                                if (nブロック[t_].type >= 9 && nブロック[t_].type <= 99)
                                {
                                    nブロック[t_].type = DX.GetRand(8);
                                }
                                nブロック[t_].xtype = DX.GetRand(4);
                            }
                        }
                        foreach (C敵出現 ct in n敵出現.ToArray())
                        {
                            if (DX.GetRand(2) <= 1)
                            {
                                ct.a = (DX.GetRand(500) - 1) * 29 * 100;
                                ct.b = DX.GetRand(15) * 100 * 29 - 1200 - 3000;
                                if (DX.GetRand(6) == 0)
                                {
                                    ct.type = DX.GetRand(9);
                                }
                            }
                        }

                        {
                            nリフトco = 0;
                            int t_ = nリフトco;
                            nリフト[t_].a = ma + fx;
                            nリフト[t_].b = (13 * 29 - 12) * 100;
                            nリフト[t_].c = 30 * 100;
                            nリフト[t_].type = 0;
                            nリフト[t_].acttype = 0;
                            nリフト[t_].e = 0;
                            nリフト[t_].sp = 0;
                            nリフトco++;
                        }
                        if (DX.GetRand(4) == 0) nステージ色 = DX.GetRand(5);
                    }



                    DX.StopSoundMem(Res.n現在のBGM);


                    //メインBGM
                    DX.PlaySoundMem(Res.n現在のBGM, DX.DX_PLAYTYPE_LOOP);


                }//zxon

                //プレイヤー
                UpdatePlayer();

                //ブロック
                UpdateBlock();


                UpdateZimen();

                //キー入力初期化
                nプレイヤー.actaon[0] = 0; nプレイヤー.actaon[4] = 0;

                Updateリフト();

                Update絵();

                UpdateEnemy();

                //スクロール
                if (n強制スクロール != 1 && n強制スクロール != 2)
                {
                    xx_2 = maScrollMax; xx_3 = 0;
                    xx_1 = xx_2; if (ma > xx_1 && fzx < scrollX) { xx_5 = ma - xx_1; ma = xx_1; fx += xx_5; fzx += xx_5; if (xx_1 <= 5000) xx_3 = 1; }
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
                if (maintm >= 30) {
                    maintm = 0;
                    e現在の画面 = E画面.Game;
                    b初期化 = false;
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
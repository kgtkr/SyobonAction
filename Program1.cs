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
            } else {
                nプレイヤーrzimen = 0;
            }

            DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);


            if (main == 1 && zxon >= 1)
            {
                //背景
                for (t_ = 0; t_ < n背景max; t_++)
                {
                    xx[0] = n背景a[t_] - fx; xx[1] = n背景b[t_] - fy;
                    xx[2] = n背景サイズW_[n背景type[t_]] * 100; xx[3] = n背景サイズH_[n背景type[t_]] * 100;
                    xx[2] = 16000; xx[3] = 16000;

                    if (xx[0] + xx[2] >= -10 && xx[0] <= n画面幅 && xx[1] + xx[3] >= -10 && xx[3] <= n画面高さ)
                    {

                        if (n背景type[t_] != 3)
                        {
                            if ((n背景type[t_] == 1 || n背景type[t_] == 2) && nステージ色 == 5)
                            {
                                DXDraw.DrawGraph(n切り取り画像_[n背景type[t_] + 30, 4], xx[0] / 100, xx[1] / 100);
                            }
                            else {
                                DXDraw.DrawGraph(n切り取り画像_[n背景type[t_], 4], xx[0] / 100, xx[1] / 100);
                            }
                        }
                        if (n背景type[t_] == 3)
                            DXDraw.DrawGraph(n切り取り画像_[n背景type[t_], 4], xx[0] / 100 - 5, xx[1] / 100);

                        //51
                        if (n背景type[t_] == 100)
                        {
                            DX.DrawString(xx[0] / 100 + n全体のポイントa, xx[1] / 100 + n全体のポイントb, "51", DX.GetColor(255, 255, 255));
                        }

                        if (n背景type[t_] == 101)
                            DX.DrawString(xx[0] / 100 + n全体のポイントa, xx[1] / 100 + n全体のポイントb, "ゲームクリアー", DX.GetColor(255, 255, 255));
                        if (n背景type[t_] == 102)
                            DX.DrawString(xx[0] / 100 + n全体のポイントa, xx[1] / 100 + n全体のポイントb, "プレイしてくれてありがとー", DX.GetColor(255, 255, 255));

                    }
                }//t



                //グラ
                for (t_ = 0; t_ < n絵max; t_++)
                {
                    xx[0] = n絵a[t_] - fx; xx[1] = n絵b[t_] - fy;
                    xx[2] = n絵nobia[t_] / 100; xx[3] = n絵nobib[t_] / 100;
                    if (xx[0] + xx[2] * 100 >= -10 && xx[1] <= n画面幅 && xx[1] + xx[3] * 100 >= -10 - 8000 && xx[3] <= n画面高さ)
                    {

                        //コイン
                        if (n絵gtype[t_] == 0)
                            DXDraw.DrawGraph(n切り取り画像_[0, 2], xx[0] / 100, xx[1] / 100);

                        //ブロックの破片
                        if (n絵gtype[t_] == 1)
                        {
                            if (nステージ色 == 1 || nステージ色 == 3 || nステージ色 == 5) DXDraw.SetColor(9 * 16, 6 * 16, 3 * 16);
                            if (nステージ色 == 2) DXDraw.SetColor(0, 120, 160);
                            if (nステージ色 == 4) DXDraw.SetColor(192, 192, 192);

                            DXDraw.DrawOval塗り潰し(xx[0] / 100, xx[1] / 100, 7, 7);
                            DXDraw.SetColor(0, 0, 0);
                            DXDraw.DrawOval塗り無し(xx[0] / 100, xx[1] / 100, 7, 7);
                        }

                        //リフトの破片
                        if (n絵gtype[t_] == 2 || n絵gtype[t_] == 3)
                        {
                            if (n絵gtype[t_] == 3) DXDraw.nミラー = 1;
                            DXDraw.DrawGraph(n切り取り画像_[0, 5], xx[0] / 100, xx[1] / 100);
                            DXDraw.nミラー = 0;
                        }

                        //ポール
                        if (n絵gtype[t_] == 4)
                        {
                            DXDraw.SetColorWhite();
                            DXDraw.DrawBox塗り潰し((xx[0]) / 100 + 10, (xx[1]) / 100, 10, xx[3]);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawBox塗り無し((xx[0]) / 100 + 10, (xx[1]) / 100, 10, xx[3]);
                            DXDraw.SetColor(250, 250, 0);
                            DXDraw.DrawOval塗り潰し((xx[0]) / 100 + 15 - 1, (xx[1]) / 100, 10, 10);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawOval塗り無し((xx[0]) / 100 + 15 - 1, (xx[1]) / 100, 10, 10);
                        }


                    }
                }

                //リフト
                for (t_ = 0; t_ < nリフトmax; t_++)
                {
                    xx[0] = nリフトa[t_] - fx; xx[1] = nリフトb[t_] - fy;
                    if (xx[0] + nリフトc[t_] >= -10 && xx[1] <= n画面幅 + 12100 && nリフトc[t_] / 100 >= 1)
                    {
                        xx[2] = 14; if (nリフトsp[t_] == 1) { xx[2] = 12; }

                        if (nリフトsp[t_] <= 9 || nリフトsp[t_] >= 20)
                        {
                            DXDraw.SetColor(220, 220, 0);
                            if (nリフトsp[t_] == 2 || nリフトsp[t_] == 3) { DXDraw.SetColor(0, 220, 0); }
                            if (nリフトsp[t_] == 21) { DXDraw.SetColor(180, 180, 180); }
                            DXDraw.DrawBox塗り潰し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, xx[2]);

                            DXDraw.SetColor(180, 180, 0);
                            if (nリフトsp[t_] == 2 || nリフトsp[t_] == 3) { DXDraw.SetColor(0, 180, 0); }
                            if (nリフトsp[t_] == 21) { DXDraw.SetColor(150, 150, 150); }
                            DXDraw.DrawBox塗り無し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, xx[2]);
                        }
                        else if (nリフトsp[t_] <= 14)
                        {
                            if (nリフトc[t_] >= 5000)
                            {
                                DXDraw.SetColor(0, 200, 0);
                                DXDraw.DrawBox塗り潰し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, 30);
                                DXDraw.SetColor(0, 160, 0);
                                DXDraw.DrawBox塗り無し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, 30);

                                DXDraw.SetColor(180, 120, 60);
                                DXDraw.DrawBox塗り潰し((nリフトa[t_] - fx) / 100 + 20, (nリフトb[t_] - fy) / 100 + 30, nリフトc[t_] / 100 - 40, 480);
                                DXDraw.SetColor(100, 80, 20);
                                DXDraw.DrawBox塗り無し((nリフトa[t_] - fx) / 100 + 20, (nリフトb[t_] - fy) / 100 + 30, nリフトc[t_] / 100 - 40, 480);

                            }
                        }
                        if (nリフトsp[t_] == 15)
                        {
                            for (t2 = 0; t2 <= 2; t2++)
                            {
                                xx[6] = 1 + 0; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], (nリフトa[t_] - fx) / 100 + t2 * 29, (nリフトb[t_] - fy) / 100);
                            }
                        }//15
                    }
                }//t


                //プレイヤー描画
                DXDraw.SetColor(0, 0, 255);

                if (nプレイヤーactp >= 2000) { nプレイヤーactp -= 2000; if (nプレイヤーact == 0) { nプレイヤーact = 1; } else { nプレイヤーact = 0; } }
                if (nプレイヤーmuki == 0) DXDraw.nミラー = 1;

                if (nプレイヤーtype != 200 && nプレイヤーtype != 1)
                {
                    if (nプレイヤーzimen == 1)
                    {
                        // 読みこんだグラフィックを拡大描画
                        if (nプレイヤーact == 0) DXDraw.DrawGraph(n切り取り画像_[0, 0], ma / 100, nプレイヤーb / 100);
                        if (nプレイヤーact == 1) DXDraw.DrawGraph(n切り取り画像_[1, 0], ma / 100, nプレイヤーb / 100);
                    }
                    if (nプレイヤーzimen == 0)
                    {
                        DXDraw.DrawGraph(n切り取り画像_[2, 0], ma / 100, nプレイヤーb / 100);
                    }
                }
                //巨大化
                else if (nプレイヤーtype == 1)
                {
                    DXDraw.DrawGraph(n切り取り画像_[41, 0], ma / 100, nプレイヤーb / 100);
                }

                else if (nプレイヤーtype == 200)
                {
                    DXDraw.DrawGraph(n切り取り画像_[3, 0], ma / 100, nプレイヤーb / 100);
                }

                DXDraw.nミラー = 0;
                //敵キャラ
                for (t_ = 0; t_ < n敵キャラmax; t_++)
                {

                    xx[0] = n敵キャラa[t_] - fx; xx[1] = n敵キャラb[t_] - fy;
                    xx[2] = n敵キャラnobia[t_] / 100; xx[3] = n敵キャラnobib[t_] / 100; xx[14] = 3000; xx[16] = 0;
                    if (xx[0] + xx[2] * 100 >= -10 - xx[14] && xx[1] <= n画面幅 + xx[14] && xx[1] + xx[3] * 100 >= -10 && xx[3] <= n画面高さ)
                    {
                        if (n敵キャラmuki[t_] == 1) { DXDraw.nミラー = 1; }
                        if (n敵キャラtype[t_] == 3 && n敵キャラxtype[t_] == 1) { DX.DrawRotaGraph(xx[0] / 100 + 13, xx[1] / 100 + 15, 1.0f, Math.PI / 1, n切り取り画像_[n敵キャラtype[t_], 3], DX.TRUE); xx[16] = 1; }
                        if (n敵キャラtype[t_] == 9 && n敵キャラd[t_] >= 1) { DX.DrawRotaGraph(xx[0] / 100 + 13, xx[1] / 100 + 15, 1.0f, Math.PI / 1, n切り取り画像_[n敵キャラtype[t_], 3], DX.TRUE); xx[16] = 1; }
                        if (n敵キャラtype[t_] >= 100 && n敵キャラmuki[t_] == 1) DXDraw.nミラー = 0;

                        //メイン
                        if (n敵キャラtype[t_] < 200 && xx[16] == 0 && n敵キャラtype[t_] != 6 && n敵キャラtype[t_] != 79 && n敵キャラtype[t_] != 86 && n敵キャラtype[t_] != 30)
                        {
                            if (!((n敵キャラtype[t_] == 80 || n敵キャラtype[t_] == 81) && n敵キャラxtype[t_] == 1))
                            {
                                DXDraw.DrawGraph(n切り取り画像_[n敵キャラtype[t_], 3], xx[0] / 100, xx[1] / 100);
                            }
                        }


                        //デフラグさん
                        if (n敵キャラtype[t_] == 6)
                        {
                            if (n敵キャラtm[t_] >= 10 && n敵キャラtm[t_] <= 19 || n敵キャラtm[t_] >= 100 && n敵キャラtm[t_] <= 119 || n敵キャラtm[t_] >= 200)
                            {
                                DXDraw.DrawGraph(n切り取り画像_[150, 3], xx[0] / 100, xx[1] / 100);
                            }
                            else {
                                DXDraw.DrawGraph(n切り取り画像_[6, 3], xx[0] / 100, xx[1] / 100);
                            }
                        }

                        //モララー
                        if (n敵キャラtype[t_] == 30)
                        {
                            if (n敵キャラxtype[t_] == 0) DXDraw.DrawGraph(n切り取り画像_[30, 3], xx[0] / 100, xx[1] / 100);
                            if (n敵キャラxtype[t_] == 1) DXDraw.DrawGraph(n切り取り画像_[155, 3], xx[0] / 100, xx[1] / 100);
                        }



                        //ステルス雲
                        if ((n敵キャラtype[t_] == 81) && n敵キャラxtype[t_] == 1)
                        {
                            DXDraw.DrawGraph(n切り取り画像_[130, 3], xx[0] / 100, xx[1] / 100);
                        }

                        if (n敵キャラtype[t_] == 79)
                        {
                            DXDraw.SetColor(250, 250, 0);
                            DXDraw.DrawBox塗り潰し(xx[0] / 100, xx[1] / 100, xx[2], xx[3]);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawBox塗り無し(xx[0] / 100, xx[1] / 100, xx[2], xx[3]);
                        }

                        if (n敵キャラtype[t_] == 82)
                        {

                            if (n敵キャラxtype[t_] == 0)
                            {
                                xx[9] = 0; if (nステージ色 == 2) { xx[9] = 30; }
                                if (nステージ色 == 4) { xx[9] = 60; }
                                if (nステージ色 == 5) { xx[9] = 90; }
                                xx[6] = 5 + xx[9]; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                            if (n敵キャラxtype[t_] == 1)
                            {
                                xx[9] = 0; if (nステージ色 == 2) { xx[9] = 30; }
                                if (nステージ色 == 4) { xx[9] = 60; }
                                if (nステージ色 == 5) { xx[9] = 90; }
                                xx[6] = 4 + xx[9]; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                            if (n敵キャラxtype[t_] == 2)
                            {
                                DXDraw.DrawGraph(n切り取り画像_[1, 5], xx[0] / 100, xx[1] / 100);
                            }

                        }
                        if (n敵キャラtype[t_] == 83)
                        {

                            if (n敵キャラxtype[t_] == 0)
                            {
                                xx[9] = 0; if (nステージ色 == 2) { xx[9] = 30; }
                                if (nステージ色 == 4) { xx[9] = 60; }
                                if (nステージ色 == 5) { xx[9] = 90; }
                                xx[6] = 5 + xx[9]; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], xx[0] / 100 + 10, xx[1] / 100 + 9);
                            }

                            if (n敵キャラxtype[t_] == 1)
                            {
                                xx[9] = 0; if (nステージ色 == 2) { xx[9] = 30; }
                                if (nステージ色 == 4) { xx[9] = 60; }
                                if (nステージ色 == 5) { xx[9] = 90; }
                                xx[6] = 4 + xx[9]; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], xx[0] / 100 + 10, xx[1] / 100 + 9);
                            }

                        }

                        //偽ポール
                        if (n敵キャラtype[t_] == 85)
                        {
                            DXDraw.SetColorWhite();
                            DXDraw.DrawBox塗り潰し((xx[0]) / 100 + 10, (xx[1]) / 100, 10, xx[3]);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawBox塗り無し((xx[0]) / 100 + 10, (xx[1]) / 100, 10, xx[3]);
                            DXDraw.SetColor(0, 250, 200);
                            DXDraw.DrawOval塗り潰し((xx[0]) / 100 + 15 - 1, (xx[1]) / 100, 10, 10);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawOval塗り無し((xx[0]) / 100 + 15 - 1, (xx[1]) / 100, 10, 10);

                        }//85


                        //ニャッスン
                        if (n敵キャラtype[t_] == 86)
                        {
                            if (ma >= n敵キャラa[t_] - fx - nプレイヤーnobia - 4000 && ma <= n敵キャラa[t_] - fx + n敵キャラnobia[t_] + 4000)
                            {
                                DXDraw.DrawGraph(n切り取り画像_[152, 3], xx[0] / 100, xx[1] / 100);
                            }
                            else {
                                DXDraw.DrawGraph(n切り取り画像_[86, 3], xx[0] / 100, xx[1] / 100);
                            }
                        }




                        if (n敵キャラtype[t_] == 200)
                            DXDraw.DrawGraph(n切り取り画像_[0, 3], xx[0] / 100, xx[1] / 100);


                        DXDraw.nミラー = 0;

                    }
                }



                //ブロック描画
                for (t_ = 0; t_ < nブロックmax; t_++)
                {
                    xx[0] = nブロックa[t_] - fx; xx[1] = nブロックb[t_] - fy;
                    xx[2] = 32; xx[3] = xx[2];
                    if (xx[0] + xx[2] * 100 >= -10 && xx[1] <= n画面幅)
                    {

                        xx[9] = 0;
                        if (nステージ色 == 2) { xx[9] = 30; }
                        if (nステージ色 == 4) { xx[9] = 60; }
                        if (nステージ色 == 5) { xx[9] = 90; }

                        if (nブロックtype[t_] < 100)
                        {
                            xx[6] = nブロックtype[t_] + xx[9]; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                        }

                        if (nブロックxtype[t_] != 10)
                        {

                            if (nブロックtype[t_] == 100 || nブロックtype[t_] == 101 || nブロックtype[t_] == 102 || nブロックtype[t_] == 103 || nブロックtype[t_] == 104 && nブロックxtype[t_] == 1 || nブロックtype[t_] == 114 && nブロックxtype[t_] == 1 || nブロックtype[t_] == 116)
                            {
                                xx[6] = 2 + xx[9]; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                            if (nブロックtype[t_] == 112 || nブロックtype[t_] == 104 && nブロックxtype[t_] == 0 || nブロックtype[t_] == 115 && nブロックxtype[t_] == 1)
                            {
                                xx[6] = 1 + xx[9]; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                            if (nブロックtype[t_] == 111 || nブロックtype[t_] == 113 || nブロックtype[t_] == 115 && nブロックxtype[t_] == 0 || nブロックtype[t_] == 124)
                            {
                                xx[6] = 3 + xx[9]; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                        }

                        if (nブロックtype[t_] == 117 && nブロックxtype[t_] == 1)
                        {
                            DXDraw.DrawGraph(n切り取り画像_[4, 5], xx[0] / 100, xx[1] / 100);
                        }

                        if (nブロックtype[t_] == 117 && nブロックxtype[t_] >= 3)
                        {
                            DXDraw.DrawGraph(n切り取り画像_[3, 5], xx[0] / 100, xx[1] / 100);
                        }

                        if (nブロックtype[t_] == 115 && nブロックxtype[t_] == 3)
                        {
                            xx[6] = 1 + xx[9]; DXDraw.DrawGraph(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                        }

                        //ジャンプ台
                        if (nブロックtype[t_] == 120 && nブロックxtype[t_] != 1)
                        {
                            DXDraw.DrawGraph(n切り取り画像_[16, 1], xx[0] / 100 + 3, xx[1] / 100 + 2);
                        }

                        //ON-OFF
                        if (nブロックtype[t_] == 130) DXDraw.DrawGraph(n切り取り画像_[10, 5], xx[0] / 100, xx[1] / 100);
                        if (nブロックtype[t_] == 131) DXDraw.DrawGraph(n切り取り画像_[11, 5], xx[0] / 100, xx[1] / 100);

                        if (nブロックtype[t_] == 140) DXDraw.DrawGraph(n切り取り画像_[12, 5], xx[0] / 100, xx[1] / 100);
                        if (nブロックtype[t_] == 141) DXDraw.DrawGraph(n切り取り画像_[13, 5], xx[0] / 100, xx[1] / 100);
                        if (nブロックtype[t_] == 142) DXDraw.DrawGraph(n切り取り画像_[14, 5], xx[0] / 100, xx[1] / 100);


                        if (nブロックtype[t_] == 300 || nブロックtype[t_] == 301)
                            DXDraw.DrawGraph(n切り取り画像_[1, 5], xx[0] / 100, xx[1] / 100);

                        //Pスイッチ
                        if (nブロックtype[t_] == 400) { DXDraw.DrawGraph(n切り取り画像_[2, 5], xx[0] / 100, xx[1] / 100); }

                        //コイン
                        if (nブロックtype[t_] == 800) { DXDraw.DrawGraph(n切り取り画像_[0, 2], xx[0] / 100 + 2, xx[1] / 100 + 1); }

                    }
                }


                //地面(壁)//土管も
                for (t_ = 0; t_ < n地面max; t_++)
                {
                    if (n地面a[t_] - fx + n地面c[t_] >= -10 && n地面a[t_] - fx <= n画面幅 + 1100)
                    {

                        if (n地面type[t_] == 0)
                        {
                            DXDraw.SetColor(40, 200, 40);
                            DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                            DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                        }
                        //土管
                        if (n地面type[t_] == 1)
                        {
                            DXDraw.SetColor(0, 230, 0);
                            DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                        }
                        //土管(下)
                        if (n地面type[t_] == 2)
                        {
                            DXDraw.SetColor(0, 230, 0);
                            DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, n地面c[t_] / 100, n地面d[t_] / 100);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawLine((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, (n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);
                            DXDraw.DrawLine((n地面a[t_] - fx) / 100 + n全体のポイントa + n地面c[t_] / 100, (n地面b[t_] - fy) / 100 + n全体のポイントb, (n地面a[t_] - fx) / 100 + n全体のポイントa + n地面c[t_] / 100, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);
                        }

                        //土管(横)
                        if (n地面type[t_] == 5)
                        {
                            DXDraw.SetColor(0, 230, 0);
                            DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, n地面c[t_] / 100, n地面d[t_] / 100);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawLine((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, (n地面a[t_] - fx) / 100 + n全体のポイントa + n地面c[t_] / 100, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                            DXDraw.DrawLine((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100, (n地面a[t_] - fx) / 100 + n全体のポイントa + n地面c[t_] / 100, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);
                        }


                        //落ちてくるブロック
                        if (n地面type[t_] == 51)
                        {
                            if (n地面xtype[t_] == 0)
                            {
                                for (t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                                {
                                    DXDraw.DrawGraph(n切り取り画像_[1, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                                }
                            }
                            if (n地面xtype[t_] == 1 || n地面xtype[t_] == 2)
                            {
                                for (t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                                {
                                    DXDraw.DrawGraph(n切り取り画像_[31, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                                }
                            }
                            if (n地面xtype[t_] == 3 || n地面xtype[t_] == 4)
                            {
                                for (t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                                {
                                    for (t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                    {
                                        DXDraw.DrawGraph(n切り取り画像_[65, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + 29 * t2 + n全体のポイントb);
                                    }
                                }
                            }

                            if (n地面xtype[t_] == 10)
                            {
                                for (t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                                {
                                    DXDraw.DrawGraph(n切り取り画像_[65, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                                }
                            }

                        }//51


                        //落ちるやつ
                        if (n地面type[t_] == 52)
                        {
                            xx[29] = 0; if (nステージ色 == 2) { xx[29] = 30; }
                            if (nステージ色 == 4) { xx[29] = 60; }
                            if (nステージ色 == 5) { xx[29] = 90; }

                            for (t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                if (n地面xtype[t_] == 0)
                                {
                                    DXDraw.DrawGraph(n切り取り画像_[5 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                                    if (nステージ色 != 4) { DXDraw.DrawGraph(n切り取り画像_[6 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29); }
                                    else { DXDraw.DrawGraph(n切り取り画像_[5 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29); }
                                }
                                if (n地面xtype[t_] == 1)
                                {
                                    for (t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                    {
                                        DXDraw.DrawGraph(n切り取り画像_[1 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29 * t2);
                                    }
                                }

                                if (n地面xtype[t_] == 2)
                                {
                                    for (t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                    {
                                        DXDraw.DrawGraph(n切り取り画像_[5 + xx[29], 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29 * t2);
                                    }
                                }

                            }
                        }


                        //ステージトラップ
                        if (nトラップ表示 == 1)
                        {
                            if (n地面type[t_] >= 100 && n地面type[t_] <= 299)
                            {
                                if (nステージ色 == 1 || nステージ色 == 3 || nステージ色 == 5) DXDraw.SetColorBlack();
                                if (nステージ色 == 2 || nステージ色 == 4) DXDraw.SetColorWhite();
                                DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb, n地面c[t_] / 100, n地面d[t_] / 100);
                            }
                        }

                        //ゴール
                        if (n地面type[t_] == 300)
                        {
                            DXDraw.SetColorWhite();
                            DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + 10, (n地面b[t_] - fy) / 100, 10, n地面d[t_] / 100 - 8);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + 10, (n地面b[t_] - fy) / 100, 10, n地面d[t_] / 100 - 8);
                            DXDraw.SetColor(250, 250, 0);
                            DXDraw.DrawOval塗り潰し((n地面a[t_] - fx) / 100 + 15 - 1, (n地面b[t_] - fy) / 100, 10, 10);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawOval塗り無し((n地面a[t_] - fx) / 100 + 15 - 1, (n地面b[t_] - fy) / 100, 10, 10);
                        }

                        //中間
                        if (n地面type[t_] == 500)
                        {
                            DXDraw.DrawGraph(n切り取り画像_[20, 4], (n地面a[t_] - fx) / 100, (n地面b[t_] - fy) / 100);
                        }
                    }
                }//t


                //描画上書き(土管)
                for (t_ = 0; t_ < n地面max; t_++)
                {
                    if (n地面a[t_] - fx + n地面c[t_] >= -10 && n地面a[t_] - fx <= n画面幅 + 1100)
                    {

                        //入る土管(右)
                        if (n地面type[t_] == 40)
                        {
                            DXDraw.SetColor(0, 230, 0);
                            DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, n地面c[t_] / 100, n地面d[t_] / 100);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, n地面c[t_] / 100, n地面d[t_] / 100);
                        }

                        //とぶ土管
                        if (n地面type[t_] == 50)
                        {
                            DXDraw.SetColor(0, 230, 0);
                            DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa + 5, (n地面b[t_] - fy) / 100 + n全体のポイントb + 30, 50, n地面d[t_] / 100 - 30);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawLine((n地面a[t_] - fx) / 100 + 5 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 30, (n地面a[t_] - fx) / 100 + n全体のポイントa + 5, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);
                            DXDraw.DrawLine((n地面a[t_] - fx) / 100 + 5 + n全体のポイントa + 50, (n地面b[t_] - fy) / 100 + n全体のポイントb + 30, (n地面a[t_] - fx) / 100 + n全体のポイントa + 50 + 5, (n地面b[t_] - fy) / 100 + n全体のポイントb + n地面d[t_] / 100);

                            DXDraw.SetColor(0, 230, 0);
                            DXDraw.DrawBox塗り潰し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, 60, 30);
                            DXDraw.SetColorBlack();
                            DXDraw.DrawBox塗り無し((n地面a[t_] - fx) / 100 + n全体のポイントa, (n地面b[t_] - fy) / 100 + n全体のポイントb + 1, 60, 30);
                        }

                        //地面(ブロック)
                        if (n地面type[t_] == 200)
                        {
                            for (t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                for (t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(n切り取り画像_[65, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + 29 * t2 + n全体のポイントb);
                                }
                            }
                        }

                    }
                }//t





                //ファイアバー
                for (t_ = 0; t_ < n敵キャラmax; t_++)
                {

                    xx[0] = n敵キャラa[t_] - fx; xx[1] = n敵キャラb[t_] - fy;
                    //xx[2]=anobia[t]/100;xx[3]=anobib[t]/100;
                    xx[14] = 12000; xx[16] = 0;
                    if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88)
                    {
                        if (xx[0] + xx[2] * 100 >= -10 - xx[14] && xx[1] <= n画面幅 + xx[14] && xx[1] + xx[3] * 100 >= -10 && xx[3] <= n画面高さ)
                        {

                            for (tt_ = 0; tt_ <= n敵キャラxtype[t_] % 100; tt_++)
                            {
                                xx[26] = 18;
                                xd[4] = tt_ * xx[26] * Math.Cos(n敵キャラtm[t_] * Math.PI / 180 / 2);
                                xd[5] = tt_ * xx[26] * Math.Sin(n敵キャラtm[t_] * Math.PI / 180 / 2);
                                xx[24] = (int)xd[4];
                                xx[25] = (int)xd[5];
                                DXDraw.SetColor(230, 120, 0);
                                xx[23] = 8;
                                if (n敵キャラtype[t_] == 87)
                                {
                                    DXDraw.DrawOval塗り潰し(xx[0] / 100 + xx[24], xx[1] / 100 + xx[25], xx[23], xx[23]);
                                    DXDraw.SetColor(0, 0, 0);
                                    DXDraw.DrawOval塗り無し(xx[0] / 100 + xx[24], xx[1] / 100 + xx[25], xx[23], xx[23]);
                                }
                                else {
                                    DXDraw.DrawOval塗り潰し(xx[0] / 100 - xx[24], xx[1] / 100 + xx[25], xx[23], xx[23]);
                                    DXDraw.SetColor(0, 0, 0);
                                    DXDraw.DrawOval塗り無し(xx[0] / 100 - xx[24], xx[1] / 100 + xx[25], xx[23], xx[23]);
                                }
                            }

                        }
                    }
                }


                //プレイヤーのメッセージ
                DXDraw.SetColorBlack();
                if (nメッセージtm >= 1)
                {
                    nメッセージtm--;
                    xs[0] = "";

                    if (nメッセージtype == 1) xs[0] = "お、おいしい!!";
                    if (nメッセージtype == 2) xs[0] = "毒は無いが……";
                    if (nメッセージtype == 3) xs[0] = "刺さった!!";
                    if (nメッセージtype == 10) xs[0] = "食べるべきではなかった!!";
                    if (nメッセージtype == 11) xs[0] = "俺は燃える男だ!!";
                    if (nメッセージtype == 50) xs[0] = "体が……焼ける……";
                    if (nメッセージtype == 51) xs[0] = "たーまやー!!";
                    if (nメッセージtype == 52) xs[0] = "見事にオワタ";
                    if (nメッセージtype == 53) xs[0] = "足が、足がぁ!!";
                    if (nメッセージtype == 54) xs[0] = "流石は摂氏800度!!";
                    if (nメッセージtype == 55) xs[0] = "溶岩と合体したい……";

                    DXDraw.SetColorBlack();
                    DXDraw.DrawString(xs[0], (ma + nプレイヤーnobia + 300) / 100 - 1, nプレイヤーb / 100 - 1);
                    DXDraw.DrawString(xs[0], (ma + nプレイヤーnobia + 300) / 100 + 1, nプレイヤーb / 100 + 1);
                    DXDraw.SetColorWhite();
                    DXDraw.DrawString(xs[0], (ma + nプレイヤーnobia + 300) / 100, nプレイヤーb / 100);

                }//mmsgtm


                //敵キャラのメッセージ
                DXDraw.SetColorBlack();
                for (t_ = 0; t_ < n敵キャラmax; t_++)
                {
                    if (n敵キャラmsgtm[t_] >= 1)
                    {
                        n敵キャラmsgtm[t_]--;

                        xs[0] = "";

                        if (n敵キャラmsgtype[t_] == 1001) xs[0] = "ヤッフー!!";
                        if (n敵キャラmsgtype[t_] == 1002) xs[0] = "え?俺勝っちゃったの?";
                        if (n敵キャラmsgtype[t_] == 1003) xs[0] = "貴様の死に場所はここだ!";
                        if (n敵キャラmsgtype[t_] == 1004) xs[0] = "二度と会う事もないだろう";
                        if (n敵キャラmsgtype[t_] == 1005) xs[0] = "俺、最強!!";
                        if (n敵キャラmsgtype[t_] == 1006) xs[0] = "一昨日来やがれ!!";
                        if (n敵キャラmsgtype[t_] == 1007) xs[0] = "漢に後退の二文字は無い!!";
                        if (n敵キャラmsgtype[t_] == 1008) xs[0] = "ハッハァ!!";

                        if (n敵キャラmsgtype[t_] == 1011) xs[0] = "ヤッフー!!";
                        if (n敵キャラmsgtype[t_] == 1012) xs[0] = "え?俺勝っちゃったの?";
                        if (n敵キャラmsgtype[t_] == 1013) xs[0] = "貴様の死に場所はここだ!";
                        if (n敵キャラmsgtype[t_] == 1014) xs[0] = "身の程知らずが……";
                        if (n敵キャラmsgtype[t_] == 1015) xs[0] = "油断が死を招く";
                        if (n敵キャラmsgtype[t_] == 1016) xs[0] = "おめでたい奴だ";
                        if (n敵キャラmsgtype[t_] == 1017) xs[0] = "屑が!!";
                        if (n敵キャラmsgtype[t_] == 1018) xs[0] = "無謀な……";

                        if (n敵キャラmsgtype[t_] == 1021) xs[0] = "ヤッフー!!";
                        if (n敵キャラmsgtype[t_] == 1022) xs[0] = "え?俺勝っちゃったの?";
                        if (n敵キャラmsgtype[t_] == 1023) xs[0] = "二度と会う事もないだろう";
                        if (n敵キャラmsgtype[t_] == 1024) xs[0] = "身の程知らずが……";
                        if (n敵キャラmsgtype[t_] == 1025) xs[0] = "僕は……負けない!!";
                        if (n敵キャラmsgtype[t_] == 1026) xs[0] = "貴様に見切れる筋は無い";
                        if (n敵キャラmsgtype[t_] == 1027) xs[0] = "今死ね、すぐ死ね、骨まで砕けろ!!";
                        if (n敵キャラmsgtype[t_] == 1028) xs[0] = "任務完了!!";

                        if (n敵キャラmsgtype[t_] == 1031) xs[0] = "ヤッフー!!";
                        if (n敵キャラmsgtype[t_] == 1032) xs[0] = "え?俺勝っちゃったの?";
                        if (n敵キャラmsgtype[t_] == 1033) xs[0] = "貴様の死に場所はここだ!";
                        if (n敵キャラmsgtype[t_] == 1034) xs[0] = "身の程知らずが……";
                        if (n敵キャラmsgtype[t_] == 1035) xs[0] = "油断が死を招く";
                        if (n敵キャラmsgtype[t_] == 1036) xs[0] = "おめでたい奴だ";
                        if (n敵キャラmsgtype[t_] == 1037) xs[0] = "屑が!!";
                        if (n敵キャラmsgtype[t_] == 1038) xs[0] = "無謀な……";

                        if (n敵キャラmsgtype[t_] == 15) xs[0] = "鉄壁!!よって、無敵!!";
                        if (n敵キャラmsgtype[t_] == 16) xs[0] = "丸腰で勝てるとでも?";
                        if (n敵キャラmsgtype[t_] == 17) xs[0] = "パリイ!!";
                        if (n敵キャラmsgtype[t_] == 18) xs[0] = "自業自得だ";
                        if (n敵キャラmsgtype[t_] == 20) xs[0] = "Zzz";
                        if (n敵キャラmsgtype[t_] == 21) xs[0] = "ク、クマー";
                        if (n敵キャラmsgtype[t_] == 24) xs[0] = "?";
                        if (n敵キャラmsgtype[t_] == 25) xs[0] = "食べるべきではなかった!!";
                        if (n敵キャラmsgtype[t_] == 30) xs[0] = "うめぇ!!";
                        if (n敵キャラmsgtype[t_] == 31) xs[0] = "ブロックを侮ったな?";
                        if (n敵キャラmsgtype[t_] == 32) xs[0] = "シャキーン";

                        if (n敵キャラmsgtype[t_] == 50) xs[0] = "波動砲!!";
                        if (n敵キャラmsgtype[t_] == 85) xs[0] = "裏切られたとでも思ったか?";
                        if (n敵キャラmsgtype[t_] == 86) xs[0] = "ポールアターック!!";



                        //if (stagecolor<=1 || stagecolor==3)setc0();
                        //if (stagecolor==2)setc1();

                        if (n敵キャラmsgtype[t_] != 31)
                        {
                            xx[5] = (n敵キャラa[t_] + n敵キャラnobia[t_] + 300 - fx) / 100; xx[6] = (n敵キャラb[t_] - fy) / 100;
                        }
                        else {
                            xx[5] = (n敵キャラa[t_] + n敵キャラnobia[t_] + 300 - fx) / 100; xx[6] = (n敵キャラb[t_] - fy - 800) / 100;
                        }

                        DX.ChangeFontType(DX.DX_FONTTYPE_EDGE);
                        DXDraw.SetColorWhite();
                        DXDraw.DrawString(xs[0], xx[5], xx[6]);
                        DX.ChangeFontType(DX.DX_FONTTYPE_NORMAL);


                    }//amsgtm
                }//amax



                //メッセージブロック
                if (nメッセージブロックtm > 0)
                {
                    ttmsg();
                    if (nメッセージブロックtype == 1)
                    {
                        xx[0] = 1200;
                        nメッセージブロックy += xx[0];
                        if (nメッセージブロックtm == 1) { nメッセージブロックtm = 80000000; nメッセージブロックtype = 2; }
                    }//1

                    else if (nメッセージブロックtype == 2)
                    {
                        nメッセージブロックy = 0; nメッセージブロックtype = 3; nメッセージブロックtm = 15 + 1;
                    }

                    else if (nメッセージブロックtype == 3)
                    {
                        xx[0] = 1200;
                        nメッセージブロックy += xx[0];
                        if (nメッセージブロックtm == 15) DX.WaitKey();
                        if (nメッセージブロックtm == 1) { nメッセージブロックtm = 0; nメッセージブロックtype = 0; nメッセージブロックy = 0; }
                    }//1

                    nメッセージブロックtm--;
                }//tmsgtm


                //メッセージ
                if (nプレイヤーainmsgtype >= 1)
                {
                    setfont(20, 4);
                    if (nプレイヤーainmsgtype == 1) { DX.DrawString(126, 100, "WELCOME TO OWATA ZONE", DX.GetColor(255, 255, 255)); }
                    if (nプレイヤーainmsgtype == 1) { for (t2 = 0; t2 <= 2; t2++) DX.DrawString(88 + t2 * 143, 210, "1", DX.GetColor(255, 255, 255)); }
                    setfont(20, 5);
                }//mainmsgtype>=1


                //画面黒
                if (blackTm > 0)
                {
                    blackTm--;
                    DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);
                    if (blackTm == 0)
                    {
                        if (blackX == 1) { zxon = 0; }
                    }

                }//blacktm


            }//if (main==1){


            if (main == 2)
            {

                DXDraw.SetColor(255, 255, 255);
                DXDraw.DrawString("制作・プレイに関わった方々", 240 - 13 * 20 / 2, xx[12] / 100);
                DXDraw.DrawString("ステージ１　プレイ", 240 - 9 * 20 / 2, xx[13] / 100);
                DXDraw.DrawString("先輩　Ⅹ～Ｚ", 240 - 6 * 20 / 2, xx[14] / 100);
                DXDraw.DrawString("ステージ２　プレイ", 240 - 9 * 20 / 2, xx[15] / 100);
                DXDraw.DrawString("友人　willowlet ", 240 - 8 * 20 / 2, xx[16] / 100);
                DXDraw.DrawString("ステージ３　プレイ", 240 - 9 * 20 / 2, xx[17] / 100);
                DXDraw.DrawString("友人　willowlet ", 240 - 8 * 20 / 2, xx[18] / 100);
                DXDraw.DrawString("ステージ４　プレイ", 240 - 9 * 20 / 2, xx[19] / 100);
                DXDraw.DrawString("友人２　ann ", 240 - 6 * 20 / 2, xx[20] / 100);
                DXDraw.DrawString("ご協力", 240 - 3 * 20 / 2, xx[21] / 100);
                DXDraw.DrawString("Ｔ先輩", 240 - 3 * 20 / 2, xx[22] / 100);
                DXDraw.DrawString("Ｓ先輩", 240 - 3 * 20 / 2, xx[23] / 100);
                DXDraw.DrawString("動画技術提供", 240 - 6 * 20 / 2, xx[24] / 100);
                DXDraw.DrawString("Ｋ先輩", 240 - 3 * 20 / 2, xx[25] / 100);
                DXDraw.DrawString("動画キャプチャ・編集・エンコード", 240 - 16 * 20 / 2, xx[26] / 100);
                DXDraw.DrawString("willowlet ", 240 - 5 * 20 / 2, xx[27] / 100);
                DXDraw.DrawString("プログラム・描画・ネタ・動画編集", 240 - 16 * 20 / 2, xx[28] / 100);
                DXDraw.DrawString("ちく", 240 - 2 * 20 / 2, xx[29] / 100);

                DXDraw.DrawString("プレイしていただき　ありがとうございました～", 240 - 22 * 20 / 2, xx[30] / 100);
            }



            if (main == 10)
            {

                DXDraw.SetColorBlack();
                DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);

                DX.SetFontSize(16);
                DX.SetFontThickness(4);

                DXDraw.DrawGraph(n切り取り画像_[0, 0], 190, 190);
                DX.DrawString(230, 200, " × " + nokori, DX.GetColor(255, 255, 255));


            }


            //タイトル
            if (main == 100)
            {

                DXDraw.SetColor(160, 180, 250);
                DXDraw.DrawBox塗り潰し(0, 0, n画面幅, n画面高さ);

                DXDraw.DrawGraph(n元画像_[30], 240 - 380 / 2, 60);

                DXDraw.DrawGraph(n切り取り画像_[0, 4], 12 * 30, 10 * 29 - 12);
                DXDraw.DrawGraph(n切り取り画像_[1, 4], 6 * 30, 12 * 29 - 12);

                //プレイヤー
                DXDraw.DrawGraph(n切り取り画像_[0, 0], 2 * 30, 12 * 29 - 12 - 6);
                for (t_ = 0; t_ <= 16; t_++)
                {
                    DXDraw.DrawGraph(n切り取り画像_[5, 1], 29 * t_, 13 * 29 - 12);
                    DXDraw.DrawGraph(n切り取り画像_[6, 1], 29 * t_, 14 * 29 - 12);
                }


                DXDraw.SetColor(0, 0, 0);
                DXDraw.DrawString("Enterキーを押せ!!", 240 - 8 * 20 / 2, 250);

            }//if (main==100){




            DX.ScreenFlip();

        }//rpaint()

        static void Mainprogram()
        {
            nタイマー測定 = DX.GetNowCount();


            if (nスタッフロール == 1) main = 2;


            //キー
            key = DX.GetJoypadInputState(DX.DX_INPUT_KEY_PAD1);


            if (main == 1 && nメッセージブロックtype == 0)
            {


                if (zxon == 0)
                {
                    zxon = 1;
                    nプレイヤーainmsgtype = 0;

                    nステージ色 = 1;
                    ma = 5600; nプレイヤーb = 32000; nプレイヤーmuki = 1; nプレイヤーhp = 1;
                    nプレイヤーc = 0; nプレイヤーd = 0;
                    nプレイヤーnobia = 3000; nプレイヤーnobib = 3600;

                    nプレイヤーtype = 0;
                    //if (stc==1)end();

                    fx = 0; fy = 0;
                    fzx = 0;
                    nステージスイッチ = 0;




                    //チーターマン　入れ
                    bgmchange(nオーディオ_[100]);

                    stagecls();

                    stage();


                    //ランダムにさせる
                    if (over == 1)
                    {
                        for (t_ = 0; t_ < nブロックmax; t_++) { if (rand(3) <= 1) { nブロックa[t_] = (rand(500) - 1) * 29 * 100; nブロックb[t_] = rand(14) * 100 * 29 - 1200; nブロックtype[t_] = rand(142); if (nブロックtype[t_] >= 9 && nブロックtype[t_] <= 99) { nブロックtype[t_] = rand(8); } nブロックxtype[t_] = rand(4); } }
                        for (t_ = 0; t_ < n敵出現max; t_++) { if (rand(2) <= 1) { n敵出現a[t_] = (rand(500) - 1) * 29 * 100; n敵出現b[t_] = rand(15) * 100 * 29 - 1200 - 3000; if (rand(6) == 0) { n敵出現type[t_] = rand(9); } } }

                        nリフトco = 0;
                        t_ = nリフトco; nリフトa[t_] = ma + fx; nリフトb[t_] = (13 * 29 - 12) * 100; nリフトc[t_] = 30 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 0; nリフトco++;

                        if (rand(4) == 0) nステージ色 = rand(5);
                    }



                    DX.StopSoundMem(nオーディオ_[0]);


                    //メインBGM
                    DX.PlaySoundMem(nオーディオ_[0], DX.DX_PLAYTYPE_LOOP);


                }//zxon


                //プレイヤーの移動
                xx[0] = 0; nプレイヤーactaon[2] = 0; nプレイヤーactaon[3] = 0;
                if (nプレイヤーkeytm <= 0)
                {
                    if ((key & DX.PAD_INPUT_LEFT) != DX.FALSE && keyTm <= 0) { nプレイヤーactaon[0] = -1; nプレイヤーmuki = 0; nプレイヤーactaon[4] = -1; }
                    if ((key & DX.PAD_INPUT_RIGHT) != DX.FALSE && keyTm <= 0) { nプレイヤーactaon[0] = 1; nプレイヤーmuki = 1; nプレイヤーactaon[4] = 1; }
                    if ((key & DX.PAD_INPUT_DOWN) != DX.FALSE) { nプレイヤーactaon[3] = 1; }
                }

                if (DX.CheckHitKey(DX.KEY_INPUT_F1) == 1) { main = 100; }
                if (DX.CheckHitKey(DX.KEY_INPUT_O) == 1) { if (nプレイヤーhp >= 1) nプレイヤーhp = 0; if (nステージc >= 5) { nステージc = 0; stagepoint = 0; } }


                if (nプレイヤーkeytm <= 0)
                {
                    if ((key & DX.PAD_INPUT_UP) == DX.TRUE || DX.CheckHitKey(DX.KEY_INPUT_Z) == 1)
                    {//end();
                        if (nプレイヤーactaon[1] == 10) { nプレイヤーactaon[1] = 1; xx[0] = 1; }
                        nプレイヤーactaon[2] = 1;
                    }
                }

                if ((key & DX.PAD_INPUT_UP) == DX.TRUE || DX.CheckHitKey(DX.KEY_INPUT_Z) == 1)
                {
                    if (nプレイヤーjumptm == 8 && nプレイヤーd >= -900)
                    {
                        nプレイヤーd = -1300;
                        //ダッシュ中
                        xx[22] = 200; if (nプレイヤーc >= xx[22] || nプレイヤーc <= -xx[22]) { nプレイヤーd = -1400; }
                        xx[22] = 600; if (nプレイヤーc >= xx[22] || nプレイヤーc <= -xx[22]) { nプレイヤーd = -1500; }
                    }
                    // && xx[0]==0 && md<=-10

                    //if (mjumptm==7 && md>=-900){}
                    if (xx[0] == 0) nプレイヤーactaon[1] = 10;
                }





                //加速による移動
                xx[0] = 40; xx[1] = 700; xx[8] = 500; xx[9] = 700;
                xx[12] = 1; xx[13] = 2;

                //すべり補正
                if (nプレイヤーrzimen == 1) { xx[0] = 20; xx[12] = 9; xx[13] = 10; }


                //if (mzimen==0){xx[0]-=15;}
                if (nプレイヤーactaon[0] == -1)
                {
                    if (!(nプレイヤーzimen == 0 && nプレイヤーc < -xx[8]))
                    {
                        if (nプレイヤーc >= -xx[9]) { nプレイヤーc -= xx[0]; if (nプレイヤーc < -xx[9]) { nプレイヤーc = -xx[9] - 1; } }
                        if (nプレイヤーc < -xx[9] && nプレイヤーatktm <= 0) nプレイヤーc -= xx[0] / 10;
                    }
                    if (nプレイヤーrzimen != 1)
                    {
                        if (nプレイヤーc > 100 && nプレイヤーzimen == 0) { nプレイヤーc -= xx[0] * 2 / 3; }
                        if (nプレイヤーc > 100 && nプレイヤーzimen == 1) { nプレイヤーc -= xx[0]; if (nプレイヤーzimen == 1) { nプレイヤーc -= xx[0] * 1 / 2; } }
                        nプレイヤーactaon[0] = 3;
                        nプレイヤーkasok += 1;
                    }
                }

                if (nプレイヤーactaon[0] == 1)
                {
                    if (!(nプレイヤーzimen == 0 && nプレイヤーc > xx[8]))
                    {
                        if (nプレイヤーc <= xx[9]) { nプレイヤーc += xx[0]; if (nプレイヤーc > xx[9]) { nプレイヤーc = xx[9] + 1; } }
                        if (nプレイヤーc > xx[9] && nプレイヤーatktm <= 0) nプレイヤーc += xx[0] / 10;
                    }
                    if (nプレイヤーrzimen != 1)
                    {
                        if (nプレイヤーc < -100 && nプレイヤーzimen == 0) { nプレイヤーc += xx[0] * 2 / 3; }
                        if (nプレイヤーc < -100 && nプレイヤーzimen == 1) { nプレイヤーc += xx[0]; if (nプレイヤーzimen == 1) { nプレイヤーc += xx[0] * 1 / 2; } }
                        nプレイヤーactaon[0] = 3; nプレイヤーkasok += 1;
                    }
                }
                if (nプレイヤーactaon[0] == 0 && nプレイヤーkasok > 0) { nプレイヤーkasok -= 2; }
                if (nプレイヤーkasok > 8) { nプレイヤーkasok = 8; }

                //すべり補正初期化
                if (nプレイヤーzimen != 1) nプレイヤーrzimen = 0;


                //ジャンプ
                if (nプレイヤーjumptm >= 0) nプレイヤーjumptm--;
                if (nプレイヤーactaon[1] == 1 && nプレイヤーzimen == 1)
                {
                    nプレイヤーb -= 400; nプレイヤーd = -1200; nプレイヤーjumptm = 10;

                    ot(nオーディオ_[1]);

                    nプレイヤーzimen = 0;

                }
                if (nプレイヤーactaon[1] <= 9) nプレイヤーactaon[1] = 0;


                if (nプレイヤーmutekitm >= -1) nプレイヤーmutekitm--;


                //HPがなくなったとき
                if (nプレイヤーhp <= 0 && nプレイヤーhp >= -9)
                {
                    nプレイヤーkeytm = 12; nプレイヤーhp = -20; nプレイヤーtype = 200; nプレイヤーtm = 0; ot(nオーディオ_[12]); DX.StopSoundMem(nオーディオ_[0]); DX.StopSoundMem(nオーディオ_[11]); DX.StopSoundMem(nオーディオ_[16]);
                }//mhp
                if (nプレイヤーtype == 200)
                {
                    if (nプレイヤーtm <= 11) { nプレイヤーc = 0; nプレイヤーd = 0; }
                    if (nプレイヤーtm == 12) { nプレイヤーd = -1200; }
                    if (nプレイヤーtm >= 12) { nプレイヤーc = 0; }
                    if (nプレイヤーtm >= 100 || nクイック == 1) { zxon = 0; main = 10; nプレイヤーtm = 0; nプレイヤーkeytm = 0; nokori--; if (nクイック == 1) nプレイヤーtype = 0; }//mtm>=100
                }//mtype==200




                //音符によるワープ
                if (nプレイヤーtype == 2)
                {
                    nプレイヤーtm++;

                    nプレイヤーkeytm = 2;
                    nプレイヤーd = -1500;
                    if (nプレイヤーb <= -6000) { blackX = 1; blackTm = 20; nステージc += 5; DX.StopSoundMem(nオーディオ_[0]); nプレイヤーtm = 0; nプレイヤーtype = 0; nプレイヤーkeytm = -1; }
                }//2

                //ジャンプ台アウト
                if (nプレイヤーtype == 3)
                {
                    nプレイヤーd = -2400;
                    if (nプレイヤーb <= -6000) { nプレイヤーb = -80000000; nプレイヤーhp = 0; }
                }


                //mtypeによる特殊的な移動
                if (nプレイヤーtype >= 100)
                {
                    nプレイヤーtm++;

                    //普通の土管
                    if (nプレイヤーtype == 100)
                    {
                        if (nプレイヤーxtype == 0)
                        {
                            nプレイヤーc = 0; nプレイヤーd = 0; t_ = 28;
                            if (nプレイヤーtm <= 16) { nプレイヤーb += 240; nプレイヤーzz = 100; }
                            if (nプレイヤーtm == 17) { nプレイヤーb = -80000000; }
                            if (nプレイヤーtm == 23) { n地面a[t_] -= 100; }
                            if (nプレイヤーtm >= 44 && nプレイヤーtm <= 60)
                            {
                                if (nプレイヤーtm % 2 == 0) n地面a[t_] += 200;
                                if (nプレイヤーtm % 2 == 1) n地面a[t_] -= 200;
                            }
                            if (nプレイヤーtm >= 61 && nプレイヤーtm <= 77)
                            {
                                if (nプレイヤーtm % 2 == 0) n地面a[t_] += 400;
                                if (nプレイヤーtm % 2 == 1) n地面a[t_] -= 400;
                            }
                            if (nプレイヤーtm >= 78 && nプレイヤーtm <= 78 + 16)
                            {
                                if (nプレイヤーtm % 2 == 0) n地面a[t_] += 600;
                                if (nプレイヤーtm % 2 == 1) n地面a[t_] -= 600;
                            }
                            if (nプレイヤーtm >= 110) { n地面b[t_] -= nプレイヤーzz; nプレイヤーzz += 80; if (nプレイヤーzz > 1600) nプレイヤーzz = 1600; }
                            if (nプレイヤーtm == 160) { nプレイヤーtype = 0; nプレイヤーhp--; }

                        }

                        //ふっとばし
                        else if (nプレイヤーxtype == 10)
                        {
                            nプレイヤーc = 0; nプレイヤーd = 0;
                            if (nプレイヤーtm <= 16) { ma += 240; }//mzz=100;}
                            if (nプレイヤーtm == 16) nプレイヤーb -= 1100;
                            if (nプレイヤーtm == 20) ot(nオーディオ_[10]);

                            if (nプレイヤーtm >= 24) { ma -= 2000; nプレイヤーmuki = 0; }
                            if (nプレイヤーtm >= 48) { nプレイヤーtype = 0; nプレイヤーhp--; }

                        }
                        else {
                            nプレイヤーc = 0; nプレイヤーd = 0;
                            if (nプレイヤーtm <= 16 && nプレイヤーxtype != 3) { nプレイヤーb += 240; }//mzz=100;}
                            if (nプレイヤーtm <= 16 && nプレイヤーxtype == 3) { ma += 240; }
                            if (nプレイヤーtm == 19 && nプレイヤーxtype == 2) { nプレイヤーhp = 0; nプレイヤーtype = 2000; nプレイヤーtm = 0; nメッセージtm = 30; nメッセージtype = 51; }
                            if (nプレイヤーtm == 19 && nプレイヤーxtype == 5) { nプレイヤーhp = 0; nプレイヤーtype = 2000; nプレイヤーtm = 0; nメッセージtm = 30; nメッセージtype = 52; }
                            if (nプレイヤーtm == 20)
                            {
                                if (nプレイヤーxtype == 6)
                                {
                                    nステージc += 10;
                                }
                                else {
                                    nステージc++;
                                }
                                nプレイヤーb = -80000000;
                                nプレイヤーxtype = 0;
                                blackX = 1;
                                blackTm = 20;
                                DX.StopSoundMem(nオーディオ_[0]);
                            }
                        }
                    }//00


                    if (nプレイヤーtype == 300)
                    {
                        nプレイヤーkeytm = 3;
                        if (nプレイヤーtm <= 1) { nプレイヤーc = 0; nプレイヤーd = 0; }
                        if (nプレイヤーtm >= 2 && nプレイヤーtm <= 42) { nプレイヤーd = 600; nプレイヤーmuki = 1; }
                        if (nプレイヤーtm > 43 && nプレイヤーtm <= 108) { nプレイヤーc = 300; }
                        if (nプレイヤーtm == 110) { nプレイヤーb = -80000000; nプレイヤーc = 0; }
                        if (nプレイヤーtm == 250)
                        {
                            nステージb++; nステージc = 0; zxon = 0; n中間ゲート = 0; main = 10; maintm = 0;
                        }
                    }//mtype==300

                    if (nプレイヤーtype == 301 || nプレイヤーtype == 302)
                    {
                        nプレイヤーkeytm = 3;

                        if (nプレイヤーtm <= 1) { nプレイヤーc = 0; nプレイヤーd = 0; }

                        if (nプレイヤーtm >= 2 && (nプレイヤーtype == 301 && nプレイヤーtm <= 102 || nプレイヤーtype == 302 && nプレイヤーtm <= 60))
                        {
                            xx[5] = 500;
                            ma -= xx[5]; fx += xx[5]; fzx += xx[5];
                        }

                        if ((nプレイヤーtype == 301 || nプレイヤーtype == 302) && nプレイヤーtm >= 2 && nプレイヤーtm <= 100)
                        {
                            nプレイヤーc = 250; nプレイヤーmuki = 1;
                        }

                        if (nプレイヤーtm == 200)
                        {
                            ot(nオーディオ_[17]);
                            if (nプレイヤーtype == 301)
                            {
                                n背景a[n背景co] = 117 * 29 * 100 - 1100; n背景b[n背景co] = 4 * 29 * 100; n背景type[n背景co] = 101; n背景co++; if (n背景co >= n背景max) n背景co = 0;
                                n背景a[n背景co] = 115 * 29 * 100 - 1100; n背景b[n背景co] = 6 * 29 * 100; n背景type[n背景co] = 102; n背景co++; if (n背景co >= n背景max) n背景co = 0;
                            }
                            else {
                                n背景a[n背景co] = 157 * 29 * 100 - 1100; n背景b[n背景co] = 4 * 29 * 100; n背景type[n背景co] = 101; n背景co++; if (n背景co >= n背景max) n背景co = 0;
                                n背景a[n背景co] = 155 * 29 * 100 - 1100; n背景b[n背景co] = 6 * 29 * 100; n背景type[n背景co] = 102; n背景co++; if (n背景co >= n背景max) n背景co = 0;
                            }
                        }
                        //スタッフロールへ

                        if (nプレイヤーtm == 440)
                        {
                            if (nプレイヤーtype == 301)
                            {
                                nスタッフロール = 1;
                            }
                            else {
                                nステージa++; nステージb = 1; nステージc = 0; zxon = 0; n中間ゲート = 0; main = 10; maintm = 0;
                            }
                        }
                    }//mtype==301

                }//mtype>=100




                //移動
                if (nプレイヤーkeytm >= 1) { nプレイヤーkeytm--; }//mc=0;}
                ma += nプレイヤーc; nプレイヤーb += nプレイヤーd;
                if (nプレイヤーc < 0) nプレイヤーactp += (-nプレイヤーc);
                if (nプレイヤーc >= 0) nプレイヤーactp += nプレイヤーc;

                if (nプレイヤーtype <= 9 || nプレイヤーtype == 200 || nプレイヤーtype == 300 || nプレイヤーtype == 301 || nプレイヤーtype == 302) nプレイヤーd += 100;


                //走る際の最大値
                if (nプレイヤーtype == 0)
                {
                    xx[0] = 800; xx[1] = 1600;
                    if (nプレイヤーc > xx[0] && nプレイヤーc < xx[0] + 200) { nプレイヤーc = xx[0]; }
                    if (nプレイヤーc > xx[0] + 200) { nプレイヤーc -= 200; }
                    if (nプレイヤーc < -xx[0] && nプレイヤーc > -xx[0] - 200) { nプレイヤーc = -xx[0]; }
                    if (nプレイヤーc < -xx[0] - 200) { nプレイヤーc += 200; }
                    if (nプレイヤーd > xx[1]) { nプレイヤーd = xx[1]; }
                }

                //プレイヤー
                //地面の摩擦
                if (nプレイヤーzimen == 1 && nプレイヤーactaon[0] != 3)
                {
                    if ((nプレイヤーtype <= 9) || nプレイヤーtype == 300 || nプレイヤーtype == 301 || nプレイヤーtype == 302)
                    {
                        if (nプレイヤーrzimen == 0)
                        {
                            xx[2] = 30; xx[1] = 60; xx[3] = 30;
                            if (nプレイヤーc >= -xx[3] && nプレイヤーc <= xx[3]) { nプレイヤーc = 0; }
                            if (nプレイヤーc >= xx[2]) { nプレイヤーc -= xx[1]; }
                            if (nプレイヤーc <= -xx[2]) { nプレイヤーc += xx[1]; }
                        }
                        if (nプレイヤーrzimen == 1)
                        {
                            xx[2] = 5; xx[1] = 10; xx[3] = 5;
                            if (nプレイヤーc >= -xx[3] && nプレイヤーc <= xx[3]) { nプレイヤーc = 0; }
                            if (nプレイヤーc >= xx[2]) { nプレイヤーc -= xx[1]; }
                            if (nプレイヤーc <= -xx[2]) { nプレイヤーc += xx[1]; }
                        }
                    }
                }


                //地面判定初期化
                nプレイヤーzimen = 0;

                //場外
                if (nプレイヤーtype <= 9 && nプレイヤーhp >= 1)
                {
                    if (ma < 100) { ma = 100; nプレイヤーc = 0; }
                    if (ma + nプレイヤーnobia > n画面幅) { ma = n画面幅 - nプレイヤーnobia; nプレイヤーc = 0; }
                }
                if (nプレイヤーb >= 38000 && nプレイヤーhp >= 0 && nステージ色 == 4) { nプレイヤーhp = -2; nメッセージtm = 30; nメッセージtype = 55; }
                if (nプレイヤーb >= 52000 && nプレイヤーhp >= 0) { nプレイヤーhp = -2; }






                //ブロック
                //1-れんが、コイン、無し、土台、7-隠し

                xx[15] = 0;
                for (t_ = 0; t_ < nブロックmax; t_++)
                {
                    xx[0] = 200; xx[1] = 3000; xx[2] = 1000; xx[3] = 3000;//xx[2]=1000
                    xx[8] = nブロックa[t_] - fx; xx[9] = nブロックb[t_] - fy;//xx[15]=0;
                    if (nブロックa[t_] - fx + xx[1] >= -10 - xx[3] && nブロックa[t_] - fx <= n画面幅 + 12000 + xx[3])
                    {
                        if (nプレイヤーtype != 200 && nプレイヤーtype != 1 && nプレイヤーtype != 2)
                        {
                            if (nブロックtype[t_] < 1000 && nブロックtype[t_] != 800 && nブロックtype[t_] != 140 && nブロックtype[t_] != 141)
                            {// && ttype[t]!=5){

                                //if (!(mztm>=1 && mztype==1 && actaon[3]==1)){
                                if (!(nプレイヤーztype == 1))
                                {
                                    xx[16] = 0; xx[17] = 0;

                                    //上
                                    if (nブロックtype[t_] != 7 && nブロックtype[t_] != 110 && !(nブロックtype[t_] == 114))
                                    {
                                        if (ma + nプレイヤーnobia > xx[8] + xx[0] * 2 + 100 && ma < xx[8] + xx[1] - xx[0] * 2 - 100 && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] && nプレイヤーd >= -100)
                                        {
                                            if (nブロックtype[t_] != 115 && nブロックtype[t_] != 400 && nブロックtype[t_] != 117 && nブロックtype[t_] != 118 && nブロックtype[t_] != 120)
                                            {
                                                nプレイヤーb = xx[9] - nプレイヤーnobib + 100; nプレイヤーd = 0; nプレイヤーzimen = 1; xx[16] = 1;
                                            }
                                            else if (nブロックtype[t_] == 115)
                                            {
                                                ot(nオーディオ_[3]);
                                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                brockbreak(t_);
                                            }
                                            //Pスイッチ
                                            else if (nブロックtype[t_] == 400)
                                            {
                                                nプレイヤーd = 0; nブロックa[t_] = -8000000; ot(nオーディオ_[13]);
                                                for (tt_ = 0; tt_ < nブロックmax; tt_++) { if (nブロックtype[tt_] != 7) { nブロックtype[tt_] = 800; } }
                                            }

                                            //音符+
                                            else if (nブロックtype[t_] == 117)
                                            {
                                                ot(nオーディオ_[14]);
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
                                }//!


                                //sstr=""+mjumptm;
                                //ブロック判定の入れ替え
                                if (!(nプレイヤーztm >= 1 && nプレイヤーztype == 1))
                                {
                                    xx[21] = 0; xx[22] = 1;//xx[12]=0;
                                    if (nプレイヤーzimen == 1 || nプレイヤーjumptm >= 10) { xx[21] = 3; xx[22] = 0; }
                                    for (t3 = 0; t3 <= 1; t3++)
                                    {

                                        //下
                                        if (t3 == xx[21] && nプレイヤーtype != 100 && nブロックtype[t_] != 117)
                                        {// && xx[12]==0){
                                            if (ma + nプレイヤーnobia > xx[8] + xx[0] * 2 + 800 && ma < xx[8] + xx[1] - xx[0] * 2 - 800 && nプレイヤーb > xx[9] - xx[0] * 2 && nプレイヤーb < xx[9] + xx[1] - xx[0] * 2 && nプレイヤーd <= 0)
                                            {
                                                xx[16] = 1; xx[17] = 1;
                                                nプレイヤーb = xx[9] + xx[1] + xx[0]; if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd * 2 / 3; }//}
                                                                                                             //壊れる
                                                if (nブロックtype[t_] == 1 && nプレイヤーzimen == 0)
                                                {
                                                    ot(nオーディオ_[3]);
                                                    eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                    eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                    eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                    eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                    brockbreak(t_);
                                                }
                                                //コイン
                                                if (nブロックtype[t_] == 2 && nプレイヤーzimen == 0)
                                                {
                                                    ot(nオーディオ_[4]);
                                                    eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                                    nブロックtype[t_] = 3;
                                                }
                                                //隠し
                                                if (nブロックtype[t_] == 7)
                                                {
                                                    ot(nオーディオ_[4]);
                                                    eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                                    nプレイヤーb = xx[9] + xx[1] + xx[0]; nブロックtype[t_] = 3; if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd * 2 / 3; }
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
                                        if (t3 == xx[22] && xx[15] == 0)
                                        {
                                            if (nブロックtype[t_] != 7 && nブロックtype[t_] != 110 && nブロックtype[t_] != 117)
                                            {
                                                if (!(nブロックtype[t_] == 114))
                                                {// && txtype[t]==1)){
                                                    if (nブロックa[t_] >= -20000)
                                                    {
                                                        if (ma + nプレイヤーnobia > xx[8] && ma < xx[8] + xx[2] && nプレイヤーb + nプレイヤーnobib > xx[9] + xx[1] / 2 - xx[0] && nプレイヤーb < xx[9] + xx[2] && nプレイヤーc >= 0)
                                                        {
                                                            ma = xx[8] - nプレイヤーnobia; nプレイヤーc = 0; xx[16] = 1;
                                                        }
                                                        if (ma + nプレイヤーnobia > xx[8] + xx[2] && ma < xx[8] + xx[1] && nプレイヤーb + nプレイヤーnobib > xx[9] + xx[1] / 2 - xx[0] && nプレイヤーb < xx[9] + xx[2] && nプレイヤーc <= 0)
                                                        {
                                                            ma = xx[8] + xx[1]; nプレイヤーc = 0; xx[16] = 1;//end();
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }//t3
                                }//!

                            }// && ttype[t]<50

                            if (nブロックtype[t_] == 800)
                            {
                                if (nプレイヤーb > xx[9] - xx[0] * 2 - 2000 && nプレイヤーb < xx[9] + xx[1] - xx[0] * 2 + 2000 && ma + nプレイヤーnobia > xx[8] - 400 && ma < xx[8] + xx[1])
                                {
                                    nブロックa[t_] = -800000; ot(nオーディオ_[4]);
                                }
                            }

                            //剣とってクリア
                            if (nブロックtype[t_] == 140)
                            {
                                if (nプレイヤーb > xx[9] - xx[0] * 2 - 2000 && nプレイヤーb < xx[9] + xx[1] - xx[0] * 2 + 2000 && ma + nプレイヤーnobia > xx[8] - 400 && ma < xx[8] + xx[1])
                                {
                                    nブロックa[t_] = -800000;//ot(oto[4]);
                                    nリフトacttype[20] = 1; nリフトon[20] = 1;
                                    DX.StopSoundMem(nオーディオ_[0]); nプレイヤーtype = 301; nプレイヤーtm = 0; ot(nオーディオ_[16]);

                                }
                            }


                            //特殊的
                            if (nブロックtype[t_] == 100)
                            {//xx[9]+xx[1]+3000<mb && // && mb>xx[9]-xx[0]*2
                                if (nプレイヤーb > xx[9] - xx[0] * 2 - 2000 && nプレイヤーb < xx[9] + xx[1] - xx[0] * 2 + 2000 && ma + nプレイヤーnobia > xx[8] - 400 && ma < xx[8] + xx[1] && nプレイヤーd <= 0)
                                {
                                    if (nブロックxtype[t_] == 0) nブロックb[t_] = nプレイヤーb + fy - 1200 - xx[1];
                                }

                                if (nブロックxtype[t_] == 1)
                                {
                                    if (xx[17] == 1)
                                    {
                                        if (ma + nプレイヤーnobia > xx[8] - 400 && ma < xx[8] + xx[1] / 2 - 1500) { nブロックa[t_] += 3000; }
                                        else if (ma + nプレイヤーnobia >= xx[8] + xx[1] / 2 - 1500 && ma < xx[8] + xx[1]) { nブロックa[t_] -= 3000; }
                                    }
                                }

                                if (xx[17] == 1 && nブロックxtype[t_] == 0)
                                {
                                    ot(nオーディオ_[4]);
                                    eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                    nブロックtype[t_] = 3;
                                }
                            }//100

                            //敵出現
                            if (nブロックtype[t_] == 101)
                            {//xx[9]+xx[1]+3000<mb && // && mb>xx[9]-xx[0]*2
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
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
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
                                    nブロックtype[t_] = 3; n敵キャラbrocktm[n敵キャラco] = 16;
                                    if (nブロックxtype[t_] == 0) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 100, 0);
                                    if (nブロックxtype[t_] == 2) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 100, 2);
                                    if (nブロックxtype[t_] == 3) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 102, 1);
                                }
                            }//102

                            //まずいきのこ出現
                            if (nブロックtype[t_] == 103)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
                                    nブロックtype[t_] = 3; n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 100, 1);
                                }
                            }//103


                            //悪スター出し
                            if (nブロックtype[t_] == 104)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
                                    nブロックtype[t_] = 3; n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 110, 0);
                                }
                            }//104




                            //毒きのこ量産
                            if (nブロックtype[t_] == 110)
                            {
                                if (xx[17] == 1)
                                {
                                    nブロックtype[t_] = 111; nブロックhp[t_] = 999;
                                }
                            }//110
                            if (nブロックtype[t_] == 111 && nブロックa[t_] - fx >= 0)
                            {
                                nブロックhp[t_]++; if (nブロックhp[t_] >= 16)
                                {
                                    nブロックhp[t_] = 0;
                                    ot(nオーディオ_[8]);
                                    n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 102, 1);
                                }
                            }


                            //コイン量産
                            if (nブロックtype[t_] == 112)
                            {
                                if (xx[17] == 1)
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
                                    ot(nオーディオ_[4]);
                                    eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                    //ttype[t]=3;
                                }
                            }


                            //隠し毒きのこ
                            if (nブロックtype[t_] == 114)
                            {
                                if (xx[17] == 1)
                                {
                                    if (nブロックxtype[t_] == 0)
                                    {
                                        ot(nオーディオ_[8]); nブロックtype[t_] = 3;
                                        n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 102, 1);
                                    }
                                    if (nブロックxtype[t_] == 2) { ot(nオーディオ_[4]); eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16); nブロックtype[t_] = 115; nブロックxtype[t_] = 0; }
                                    if (nブロックxtype[t_] == 10)
                                    {
                                        if (nステージスイッチ == 1) { nブロックtype[t_] = 130; nステージスイッチ = 0; ot(nオーディオ_[13]); nブロックxtype[t_] = 2; for (t_ = 0; t_ < n敵キャラmax; t_++) { if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88) { if (n敵キャラxtype[t_] == 105) { n敵キャラxtype[t_] = 110; } } } }
                                        else { ot(nオーディオ_[4]); eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16); nブロックtype[t_] = 3; }
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
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
                                    //ot(oto[13]);
                                    nブロックtype[t_] = 3;//abrocktm[aco]=18;ayobi(ta[t],tb[t],0,0,0,104,1);
                                    tyobi(nブロックa[t_] / 100, (nブロックb[t_] / 100) - 29, 400);
                                }
                            }//116


                            //ファイアバー強化
                            if (nブロックtype[t_] == 124)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[13]);
                                    for (t_ = 0; t_ < n敵キャラmax; t_++) { if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88) { if (n敵キャラxtype[t_] == 101) { n敵キャラxtype[t_] = 120; } } }
                                    nブロックtype[t_] = 3;
                                }
                            }

                            //ONスイッチ
                            if (nブロックtype[t_] == 130)
                            {
                                if (xx[17] == 1)
                                {
                                    if (nブロックxtype[t_] != 1)
                                    {
                                        nステージスイッチ = 0; ot(nオーディオ_[13]);
                                    }
                                }
                            }
                            else if (nブロックtype[t_] == 131)
                            {
                                if (xx[17] == 1 && nブロックxtype[t_] != 2)
                                {
                                    nステージスイッチ = 1; ot(nオーディオ_[13]);
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
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[15]);
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
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[3]);
                                    eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120); eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    brockbreak(t_);
                                }
                            }//300


                        }
                        else if (nプレイヤーtype == 1)
                        {
                            if (ma + nプレイヤーnobia > xx[8] && ma < xx[8] + xx[1] && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb < xx[9] + xx[1])
                            {

                                ot(nオーディオ_[3]);
                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                brockbreak(t_);

                            }
                        }


                        //ONOFF
                        if (nブロックtype[t_] == 130 && nステージスイッチ == 0) { nブロックtype[t_] = 131; }
                        if (nブロックtype[t_] == 131 && nステージスイッチ == 1) { nブロックtype[t_] = 130; }

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







                //壁
                for (t_ = 0; t_ < n地面max; t_++)
                {
                    if (n地面a[t_] - fx + n地面c[t_] >= -12000 && n地面a[t_] - fx <= n画面幅)
                    {
                        xx[0] = 200; xx[1] = 2400; xx[2] = 1000; xx[7] = 0;

                        xx[8] = n地面a[t_] - fx; xx[9] = n地面b[t_] - fy;
                        if ((n地面type[t_] <= 99 || n地面type[t_] == 200) && nプレイヤーtype < 10)
                        {

                            //おちるブロック
                            if (n地面type[t_] == 51)
                            {
                                if (ma + nプレイヤーnobia > xx[8] + xx[0] + 3000 && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] + 3000 && n地面gtype [t_] == 0)
                                {
                                    if (n地面xtype[t_] == 0)
                                    {
                                        n地面gtype [t_] = 1; n地面r[t_] = 0;
                                    }
                                }
                                if (ma + nプレイヤーnobia > xx[8] + xx[0] + 1000 && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] + 3000 && n地面gtype [t_] == 0)
                                {
                                    if ((n地面xtype[t_] == 10) && n地面gtype [t_] == 0)
                                    {
                                        n地面gtype [t_] = 1; n地面r[t_] = 0;
                                    }
                                }

                                if ((n地面xtype[t_] == 1) && n地面b[27] >= 25000 && n地面a[27] > ma + nプレイヤーnobia && t_ != 27 && n地面gtype [t_] == 0)
                                {
                                    n地面gtype [t_] = 1; n地面r[t_] = 0;
                                }
                                if (n地面xtype[t_] == 2 && n地面b[28] >= 48000 && t_ != 28 && n地面gtype [t_] == 0 && nプレイヤーhp >= 1)
                                {
                                    n地面gtype [t_] = 1; n地面r[t_] = 0;
                                }
                                if ((n地面xtype[t_] == 3 && nプレイヤーb >= 30000 || n地面xtype[t_] == 4 && nプレイヤーb >= 25000) && n地面gtype [t_] == 0 && nプレイヤーhp >= 1 && ma + nプレイヤーnobia > xx[8] + xx[0] + 3000 - 300 && ma < xx[8] + n地面c[t_] - xx[0])
                                {
                                    n地面gtype [t_] = 1; n地面r[t_] = 0;
                                    if (n地面xtype[t_] == 4) n地面r[t_] = 100;
                                }

                                if (n地面gtype [t_] == 1 && n地面b[t_] <= n画面高さ + 18000)
                                {
                                    n地面r[t_] += 120; if (n地面r[t_] >= 1600) { n地面r[t_] = 1600; }
                                    n地面b[t_] += n地面r[t_];
                                    if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb < xx[9] + n地面d[t_] + xx[0])
                                    {
                                        nプレイヤーhp--; xx[7] = 1;
                                    }
                                }
                            }

                            //おちるブロック2
                            if (n地面type[t_] == 52)
                            {
                                if (n地面gtype [t_] == 0 && ma + nプレイヤーnobia > xx[8] + xx[0] + 2000 && ma < xx[8] + n地面c[t_] - xx[0] - 2500 && nプレイヤーb + nプレイヤーnobib > xx[9] - 3000)
                                {
                                    n地面gtype [t_] = 1; n地面r[t_] = 0;
                                }
                                if (n地面gtype [t_] == 1)
                                {
                                    n地面r[t_] += 120; if (n地面r[t_] >= 1600) { n地面r[t_] = 1600; }
                                    n地面b[t_] += n地面r[t_];
                                }
                            }



                            //通常地面
                            if (xx[7] == 0)
                            {
                                if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] && nプレイヤーd >= -100) { nプレイヤーb = n地面b[t_] - fy - nプレイヤーnobib + 100; nプレイヤーd = 0; nプレイヤーzimen = 1; }
                                if (ma + nプレイヤーnobia > xx[8] - xx[0] && ma < xx[8] + xx[2] && nプレイヤーb + nプレイヤーnobib > xx[9] + xx[1] * 3 / 4 && nプレイヤーb < xx[9] + n地面d[t_] - xx[2]) { ma = xx[8] - xx[0] - nプレイヤーnobia; nプレイヤーc = 0; }
                                if (ma + nプレイヤーnobia > xx[8] + n地面c[t_] - xx[0] && ma < xx[8] + n地面c[t_] + xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] + xx[1] * 3 / 4 && nプレイヤーb < xx[9] + n地面d[t_] - xx[2]) { ma = xx[8] + n地面c[t_] + xx[0]; nプレイヤーc = 0; }
                                if (ma + nプレイヤーnobia > xx[8] + xx[0] * 2 && ma < xx[8] + n地面c[t_] - xx[0] * 2 && nプレイヤーb > xx[9] + n地面d[t_] - xx[1] && nプレイヤーb < xx[9] + n地面d[t_] + xx[0])
                                {
                                    nプレイヤーb = xx[9] + n地面d[t_] + xx[0]; if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd * 2 / 3; }
                                }
                            }//xx[7]

                            //入る土管
                            if (n地面type[t_] == 50)
                            {
                                if (ma + nプレイヤーnobia > xx[8] + 2800 && ma < xx[8] + n地面c[t_] - 3000 && nプレイヤーb + nプレイヤーnobib > xx[9] - 1000 && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] + 3000 && nプレイヤーzimen == 1 && nプレイヤーactaon[3] == 1 && nプレイヤーtype == 0)
                                {
                                    //飛び出し
                                    if (n地面xtype[t_] == 0)
                                    {
                                        nプレイヤーtype = 100; nプレイヤーtm = 0; ot(nオーディオ_[7]); nプレイヤーxtype = 0;
                                    }
                                    //普通
                                    if (n地面xtype[t_] == 1)
                                    {
                                        nプレイヤーtype = 100; nプレイヤーtm = 0; ot(nオーディオ_[7]); nプレイヤーxtype = 1;
                                    }
                                    //普通
                                    if (n地面xtype[t_] == 2)
                                    {
                                        nプレイヤーtype = 100; nプレイヤーtm = 0; ot(nオーディオ_[7]); nプレイヤーxtype = 2;
                                    }
                                    if (n地面xtype[t_] == 5)
                                    {
                                        nプレイヤーtype = 100; nプレイヤーtm = 0; ot(nオーディオ_[7]); nプレイヤーxtype = 5;
                                    }
                                    // ループ
                                    if (n地面xtype[t_] == 6)
                                    {
                                        nプレイヤーtype = 100; nプレイヤーtm = 0; ot(nオーディオ_[7]); nプレイヤーxtype = 6;
                                    }
                                }
                            }//50

                            //入る土管(左から)
                            if (n地面type[t_] == 40)
                            {
                                if (ma + nプレイヤーnobia > xx[8] - 300 && ma < xx[8] + n地面c[t_] - 1000 && nプレイヤーb > xx[9] + 1000 && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] + 4000 && nプレイヤーzimen == 1 && nプレイヤーactaon[4] == 1 && nプレイヤーtype == 0)
                                {//end();
                                 //飛び出し
                                    if (n地面xtype[t_] == 0)
                                    {
                                        nプレイヤーtype = 500; nプレイヤーtm = 0; ot(nオーディオ_[7]);//mxtype=1;
                                        nプレイヤーtype = 100; nプレイヤーxtype = 10;
                                    }

                                    if (n地面xtype[t_] == 2)
                                    {
                                        nプレイヤーxtype = 3;
                                        nプレイヤーtm = 0; ot(nオーディオ_[7]);//mxtype=1;
                                        nプレイヤーtype = 100;
                                    }
                                    // ループ
                                    if (n地面xtype[t_] == 6)
                                    {
                                        nプレイヤーtype = 3; nプレイヤーtm = 0; ot(nオーディオ_[7]); nプレイヤーxtype = 6;
                                    }
                                }
                            }//40




                        }//stype
                        else {
                            if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + n地面c[t_] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb < xx[9] + n地面d[t_] + xx[0])
                            {
                                if (n地面type[t_] == 100)
                                {
                                    if (n地面xtype[t_] == 0 || n地面xtype[t_] == 1 && nブロックtype[1] != 3)
                                    {
                                        ayobi(n地面a[t_] + 1000, 32000, 0, 0, 0, 3, 0); n地面a[t_] = -800000000; ot(nオーディオ_[10]);
                                    }
                                }
                                if (n地面type[t_] == 101) { ayobi(n地面a[t_] + 6000, -4000, 0, 0, 0, 3, 1); n地面a[t_] = -800000000; ot(nオーディオ_[10]); }
                                if (n地面type[t_] == 102)
                                {
                                    if (n地面xtype[t_] == 0)
                                    {
                                        for (t3 = 0; t3 <= 3; t3++) { ayobi(n地面a[t_] + t3 * 3000, -3000, 0, 0, 0, 0, 0); }
                                    }
                                    if (n地面xtype[t_] == 1 && nプレイヤーb >= 16000) { ayobi(n地面a[t_] + 1500, 44000, 0, -2000, 0, 4, 0); }
                                    else if (n地面xtype[t_] == 2) { ayobi(n地面a[t_] + 4500, 30000, 0, -1600, 0, 5, 0); ot(nオーディオ_[10]); n地面xtype[t_] = 3; n地面a[t_] -= 12000; }
                                    else if (n地面xtype[t_] == 3) { n地面a[t_] += 12000; n地面xtype[t_] = 4; }
                                    else if (n地面xtype[t_] == 4) { ayobi(n地面a[t_] + 4500, 30000, 0, -1600, 0, 5, 0); ot(nオーディオ_[10]); n地面xtype[t_] = 5; n地面xtype[t_] = 0; }

                                    else if (n地面xtype[t_] == 7) { nプレイヤーainmsgtype = 1; }
                                    else if (n地面xtype[t_] == 8) { ayobi(n地面a[t_] - 5000 - 3000 * 1, 26000, 0, -1600, 0, 5, 0); ot(nオーディオ_[10]); }
                                    else if (n地面xtype[t_] == 9) { for (t3 = 0; t3 <= 2; t3++) { ayobi(n地面a[t_] + t3 * 3000 + 3000, 48000, 0, -6000, 0, 3, 0); } }
                                    if (n地面xtype[t_] == 10) { n地面a[t_] -= 5 * 30 * 100; n地面type[t_] = 101; }

                                    if (n地面xtype[t_] == 12)
                                    {
                                        for (t3 = 1; t3 <= 3; t3++) { ayobi(n地面a[t_] + t3 * 3000 - 1000, 40000, 0, -2600, 0, 9, 0); }
                                    }

                                    //スクロール消し
                                    if (n地面xtype[t_] == 20)
                                    {
                                        scrollX = 0;
                                    }

                                    //クリア
                                    if (n地面xtype[t_] == 30)
                                    {
                                        n地面a[t_] = -80000000; nプレイヤーd = 0;
                                        DX.StopSoundMem(nオーディオ_[0]); nプレイヤーtype = 302; nプレイヤーtm = 0; ot(nオーディオ_[16]);
                                    }

                                    if (n地面xtype[t_] != 3 && n地面xtype[t_] != 4 && n地面xtype[t_] != 10) { n地面a[t_] = -800000000; }
                                }

                                if (n地面type[t_] == 103)
                                {
                                    if (n地面xtype[t_] == 0)
                                    {
                                        n敵キャラmsgtm[n敵キャラco] = 10; n敵キャラmsgtype[n敵キャラco] = 50; ayobi(n地面a[t_] + 9000, n地面b[t_] + 2000, 0, 0, 0, 79, 0); n地面a[t_] = -800000000;
                                    }

                                    if (n地面xtype[t_] == 1 && nブロックtype[6] <= 6)
                                    {
                                        n敵キャラmsgtm[n敵キャラco] = 10; n敵キャラmsgtype[n敵キャラco] = 50; ayobi(n地面a[t_] - 12000, n地面b[t_] + 2000, 0, 0, 0, 79, 0); n地面a[t_] = -800000000;
                                        nブロックxtype[9] = 500;//ttype[9]=1;
                                    }
                                }//103

                                if (n地面type[t_] == 104)
                                {
                                    if (n地面xtype[t_] == 0)
                                    {
                                        ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 0);
                                        ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 1);
                                        ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 2);
                                        ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 3);
                                        ayobi(n地面a[t_] + 12000, n地面b[t_] + 2000 + 3000, 0, 0, 0, 79, 4);
                                        n地面a[t_] = -800000000;
                                    }
                                }

                                if (n地面type[t_] == 105 && nプレイヤーzimen == 0 && nプレイヤーd >= 0) { nブロックa[1] -= 1000; nブロックa[2] += 1000; n地面xtype[t_]++; if (n地面xtype[t_] >= 3) n地面a[t_] = -8000000; }


                                if (n地面type[t_] == 300 && nプレイヤーtype == 0 && nプレイヤーb < xx[9] + n地面d[t_] + xx[0] - 3000 && nプレイヤーhp >= 1) { DX.StopSoundMem(nオーディオ_[0]); nプレイヤーtype = 300; nプレイヤーtm = 0; ma = n地面a[t_] - fx - 2000; ot(nオーディオ_[11]); }

                                //中間ゲート
                                if (n地面type[t_] == 500 && nプレイヤーtype == 0 && nプレイヤーhp >= 1)
                                {
                                    n中間ゲート += 1;
                                    n地面a[t_] = -80000000;
                                }

                            }

                            if (n地面type[t_] == 180)
                            {
                                n地面r[t_]++;
                                if (n地面r[t_] >= n地面gtype [t_])
                                {
                                    n地面r[t_] = 0;
                                    ayobi(n地面a[t_], 30000, rand(600) - 300, -1600 - rand(900), 0, 84, 0);
                                }
                            }

                        }
                    }
                }//壁

                //キー入力初期化
                nプレイヤーactaon[0] = 0; nプレイヤーactaon[4] = 0;

                //リフト
                for (t_ = 0; t_ < nリフトmax; t_++)
                {
                    xx[10] = nリフトa[t_]; xx[11] = nリフトb[t_]; xx[12] = nリフトc[t_]; xx[13] = nリフトd[t_];
                    xx[8] = xx[10] - fx; xx[9] = xx[11] - fy;
                    if (xx[8] + xx[12] >= -10 - 12000 && xx[8] <= n画面幅 + 12100)
                    {
                        xx[0] = 500; xx[1] = 1200; xx[2] = 1000; xx[7] = 2000;
                        if (nプレイヤーd >= 100) { xx[1] = 900 + nプレイヤーd; }

                        if (nプレイヤーd > xx[1]) xx[1] = nプレイヤーd + 100;

                        nリフトb[t_] += nリフトe[t_];
                        nリフトe[t_] += nリフトf[t_];

                        //動き
                        switch (nリフトacttype[t_])
                        {

                            case 1:
                                if (nリフトon[t_] == 1) nリフトf[t_] = 60;
                                break;
                            case 2:
                                break;

                            case 3:
                            case 5:
                                if (nリフトmove[t_] == 0) { nリフトmuki[t_] = 0; }
                                else { nリフトmuki[t_] = 1; }
                                if (nリフトb[t_] - fy < -2100) { nリフトb[t_] = n画面高さ + fy + scrollY + 2000; }
                                if (nリフトb[t_] - fy > n画面高さ + scrollY + 2000) { nリフトb[t_] = -2100 + fy; }
                                break;

                            case 6:
                                if (nリフトon[t_] == 1) nリフトf[t_] = 40;
                                break;

                            case 7:
                                break;


                        }//sw

                        //乗ったとき
                        if (!(nプレイヤーztm >= 1 && nプレイヤーztype == 1 && nプレイヤーactaon[3] == 1) && nプレイヤーhp >= 1)
                        {
                            if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + xx[12] - xx[0] && nプレイヤーb + nプレイヤーnobib > xx[9] && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] && nプレイヤーd >= -100)
                            {
                                nプレイヤーb = xx[9] - nプレイヤーnobib + 100;

                                if (nリフトtype[t_] == 1) { nリフトe[10] = 900; nリフトe[11] = 900; }

                                if (nリフトsp[t_] != 12)
                                {
                                    nプレイヤーzimen = 1; nプレイヤーd = 0;
                                }
                                else {
                                    //すべり
                                    nプレイヤーd = -800;
                                }



                                //落下
                                if ((nリフトacttype[t_] == 1) && nリフトon[t_] == 0) nリフトon[t_] = 1;

                                if (nリフトacttype[t_] == 1 && nリフトon[t_] == 1 || nリフトacttype[t_] == 3 || nリフトacttype[t_] == 5)
                                {
                                    nプレイヤーb += nリフトe[t_];
                                }

                                if (nリフトacttype[t_] == 7)
                                {
                                    if (nプレイヤーactaon[2] != 1) { nプレイヤーd = -600; nプレイヤーb -= 810; }
                                    if (nプレイヤーactaon[2] == 1) { nプレイヤーb -= 400; nプレイヤーd = -1400; nプレイヤーjumptm = 10; }
                                }


                                //特殊
                                if (nリフトsp[t_] == 1)
                                {
                                    ot(nオーディオ_[3]);
                                    eyobi(nリフトa[t_] + 200, nリフトb[t_] - 1000, -240, -1400, 0, 160, 4500, 4500, 2, 120);
                                    eyobi(nリフトa[t_] + 4500 - 200, nリフトb[t_] - 1000, 240, -1400, 0, 160, 4500, 4500, 3, 120);
                                    nリフトa[t_] = -70000000;
                                }





                                if (nリフトsp[t_] == 2)
                                {
                                    nプレイヤーc = -2400; nリフトmove[t_] += 1;
                                    if (nリフトmove[t_] >= 100) { nプレイヤーhp = 0; nメッセージtype = 53; nメッセージtm = 30; nリフトmove[t_] = -5000; }
                                }

                                if (nリフトsp[t_] == 3)
                                {
                                    nプレイヤーc = 2400; nリフトmove[t_] += 1;
                                    if (nリフトmove[t_] >= 100) { nプレイヤーhp = 0; nメッセージtype = 53; nメッセージtm = 30; nリフトmove[t_] = -5000; }
                                }
                            }//判定内


                            //疲れ初期化
                            if ((nリフトsp[t_] == 2 || nリフトsp[t_] == 3) && nプレイヤーc != -2400 && nリフトmove[t_] > 0) { nリフトmove[t_]--; }

                            if (nリフトsp[t_] == 11)
                            {
                                if (ma + nプレイヤーnobia > xx[8] + xx[0] - 2000 && ma < xx[8] + xx[12] - xx[0]) { nリフトon[t_] = 1; }// && mb+mnobib>xx[9]-1000 && mb+mnobib<xx[9]+xx[1]+2000)
                                if (nリフトon[t_] == 1) { nリフトf[t_] = 60; nリフトb[t_] += nリフトe[t_]; }
                            }


                            //トゲ(下)
                            if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + xx[12] - xx[0] && nプレイヤーb > xx[9] - xx[1] / 2 && nプレイヤーb < xx[9] + xx[1] / 2)
                            {
                                if (nリフトtype[t_] == 2) { if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd; } nプレイヤーb += 110; if (nプレイヤーmutekitm <= 0) nプレイヤーhp -= 1; if (nプレイヤーmutekion != 1) nプレイヤーmutekitm = 40; }
                            }
                            //落下
                            if (nリフトacttype[t_] == 6)
                            {
                                if (ma + nプレイヤーnobia > xx[8] + xx[0] && ma < xx[8] + xx[12] - xx[0]) { nリフトon[t_] = 1; }
                            }

                        }//!

                        if (nリフトacttype[t_] == 2 || nリフトacttype[t_] == 4)
                        {
                            if (nリフトmuki[t_] == 0) nリフトa[t_] -= nリフトsok[t_];
                            if (nリフトmuki[t_] == 1) nリフトa[t_] += nリフトsok[t_];
                        }
                        if (nリフトacttype[t_] == 3 || nリフトacttype[t_] == 5)
                        {
                            if (nリフトmuki[t_] == 0) nリフトb[t_] -= nリフトsok[t_];
                            if (nリフトmuki[t_] == 1) nリフトb[t_] += nリフトsok[t_];
                        }

                        //敵キャラ適用
                        for (tt_ = 0; tt_ < n敵キャラmax; tt_++)
                        {
                            if (n敵キャラzimentype[tt_] == 1)
                            {
                                if (n敵キャラa[tt_] + n敵キャラnobia[tt_] - fx > xx[8] + xx[0] && n敵キャラa[tt_] - fx < xx[8] + xx[12] - xx[0] && n敵キャラb[tt_] + n敵キャラnobib[tt_] > xx[11] - 100 && n敵キャラb[tt_] + n敵キャラnobib[tt_] < xx[11] + xx[1] + 500 && n敵キャラd[tt_] >= -100)
                                {
                                    n敵キャラb[tt_] = xx[9] - n敵キャラnobib[tt_] + 100; n敵キャラd[tt_] = 0; n敵キャラxzimen[tt_] = 1;
                                }
                            }
                        }
                    }
                }//リフト

                //グラ
                for (t_ = 0; t_ < n絵max; t_++)
                {
                    xx[0] = n絵a[t_] - fx; xx[1] = n絵b[t_] - fy;
                    xx[2] = n絵nobia[t_] / 100; xx[3] = n絵nobib[t_] / 100;
                    if (n絵tm[t_] >= 0) n絵tm[t_]--;
                    if (xx[0] + xx[2] * 100 >= -10 && xx[1] <= n画面幅 && xx[1] + xx[3] * 100 >= -10 - 8000 && xx[3] <= n画面高さ && n絵tm[t_] >= 0)
                    {
                        n絵a[t_] += n絵c[t_]; n絵b[t_] += n絵d[t_];
                        n絵c[t_] += n絵e[t_]; n絵d[t_] += n絵f[t_];

                    }
                    else { n絵a[t_] = -9000000; }

                }//emax

                //敵キャラの配置
                for (t_ = 0; t_ < n敵出現max; t_++)
                {
                    if (n敵出現a[t_] >= -80000)
                    {

                        if (n敵出現tm[t_] >= 0) { n敵出現tm[t_] = n敵出現tm[t_] - 1; }

                        for (tt_ = 0; tt_ <= 1; tt_++)
                        {
                            xx[0] = 0; xx[1] = 0;


                            if (n敵出現z[t_] == 0 && n敵出現tm[t_] < 0 && n敵出現a[t_] - fx >= n画面幅 + 2000 && n敵出現a[t_] - fx < n画面幅 + 2000 + nプレイヤーc && tt_ == 0) { xx[0] = 1; n敵キャラmuki[n敵キャラco] = 0; }// && mmuki==1
                            if (n敵出現z[t_] == 0 && n敵出現tm[t_] < 0 && n敵出現a[t_] - fx >= -400 - n敵サイズW_[n敵出現type[t_]] + nプレイヤーc && n敵出現a[t_] - fx < -400 - n敵サイズW_[n敵出現type[t_]] && tt_ == 1) { xx[0] = 1; xx[1] = 1; n敵キャラmuki[n敵キャラco] = 1; }// && mmuki==0
                            if (n敵出現z[t_] == 1 && n敵出現a[t_] - fx >= 0 - n敵サイズW_[n敵出現type[t_]] && n敵出現a[t_] - fx <= n画面幅 + 4000 && n敵出現b[t_] - fy >= -9000 && n敵出現b[t_] - fy <= n画面高さ + 4000 && n敵出現tm[t_] < 0) { xx[0] = 1; n敵出現z[t_] = 0; }// && xza<=5000// && tyuukan!=1
                            if (xx[0] == 1)
                            {//400
                                n敵出現tm[t_] = 401; xx[0] = 0;
                                if (n敵出現type[t_] >= 10) { n敵出現tm[t_] = 9999999; }

                                //10
                                ayobi(n敵出現a[t_], n敵出現b[t_], 0, 0, 0, n敵出現type[t_], n敵出現xtype[t_]);

                            }

                        }//tt

                    }
                }//t

                //敵キャラ
                for (t_ = 0; t_ < n敵キャラmax; t_++)
                {
                    xx[0] = n敵キャラa[t_] - fx; xx[1] = n敵キャラb[t_] - fy;
                    xx[2] = n敵キャラnobia[t_]; xx[3] = n敵キャラnobib[t_]; xx[14] = 12000 * 1;
                    if (n敵キャラnotm[t_] >= 0) n敵キャラnotm[t_]--;
                    if (xx[0] + xx[2] >= -xx[14] && xx[0] <= n画面幅 + xx[14] && xx[1] + xx[3] >= -10 - 9000 && xx[1] <= n画面高さ + 20000)
                    {
                        n敵キャラacta[t_] = 0; n敵キャラactb[t_] = 0;

                        xx[10] = 0;

                        switch (n敵キャラtype[t_])
                        {
                            case 0:
                                xx[10] = 100;
                                break;

                            //こうらの敵
                            case 1:
                                xx[10] = 100;
                                break;

                            //こうら
                            case 2:
                                xx[10] = 0; xx[17] = 800;
                                if (n敵キャラxtype[t_] >= 1) xx[10] = xx[17];
                                //他の敵を倒す
                                if (n敵キャラxtype[t_] >= 1)
                                {
                                    for (tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                    {
                                        xx[0] = 250; xx[5] = -800; xx[12] = 0; xx[1] = 1600;
                                        xx[8] = n敵キャラa[tt_] - fx; xx[9] = n敵キャラb[tt_] - fy;
                                        if (t_ != tt_)
                                        {
                                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + xx[0] * 2 && n敵キャラa[t_] - fx < xx[8] + n敵キャラnobia[tt_] - xx[0] * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] + xx[5] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx[9] + xx[1] * 3 + xx[12] + 1500)
                                            {
                                                n敵キャラa[tt_] = -800000; ot(nオーディオ_[6]);
                                            }
                                        }
                                    }
                                }
                                break;

                            //あらまき
                            case 3:
                                n敵キャラzimentype[t_] = 0;//end();
                                if (n敵キャラxtype[t_] == 0)
                                {
                                    n敵キャラb[t_] -= 800;
                                }
                                if (n敵キャラxtype[t_] == 1)
                                    n敵キャラb[t_] += 1200;

                                //xx[10]=100;
                                break;

                            //スーパージエン
                            case 4:
                                xx[10] = 120;
                                xx[0] = 250;
                                xx[8] = n敵キャラa[t_] - fx;
                                xx[9] = n敵キャラb[t_] - fy;
                                if (n敵キャラtm[t_] >= 0) n敵キャラtm[t_]--;
                                if (Math.Abs(ma + nプレイヤーnobia - xx[8] - xx[0] * 2) < 9000 &&
                                    Math.Abs((ma < xx[8] - n敵キャラnobia[t_] + xx[0] * 2) ? 1 : 0) < 3000 &&
                                    nプレイヤーd <= -600 && n敵キャラtm[t_] <= 0)
                                {
                                    if (n敵キャラxtype[t_] == 1 && nプレイヤーzimen == 0 && n敵キャラxzimen[t_] == 1)
                                    {
                                        n敵キャラd[t_] = -1600; n敵キャラtm[t_] = 40; n敵キャラb[t_] -= 1000;
                                    }
                                }// 
                                break;

                            //クマー
                            case 5:
                                xx[10] = 160;
                                //azimentype[t]=2;
                                break;

                            //デフラグさん
                            case 6:
                                if (n敵キャラzimentype[t_] == 30) { n敵キャラd[t_] = -1600; n敵キャラb[t_] += n敵キャラd[t_]; }

                                xx[10] = 120;
                                if (n敵キャラtm[t_] >= 10)
                                {
                                    n敵キャラtm[t_]++;
                                    if (nプレイヤーhp >= 1)
                                    {
                                        if (n敵キャラtm[t_] <= 19) { ma = xx[0]; nプレイヤーb = xx[1] - 3000; nプレイヤーtype = 0; }
                                        xx[10] = 0;
                                        if (n敵キャラtm[t_] == 20) { nプレイヤーc = 700; nプレイヤーkeytm = 24; nプレイヤーd = -1200; nプレイヤーb = xx[1] - 1000 - 3000; n敵キャラmuki[t_] = 1; if (n敵キャラxtype[t_] == 1) { nプレイヤーc = 840; n敵キャラxtype[t_] = 0; } }
                                        if (n敵キャラtm[t_] == 40) { n敵キャラmuki[t_] = 0; n敵キャラtm[t_] = 0; }
                                    }
                                }

                                //ポール捨て
                                if (n敵キャラxtype[t_] == 1)
                                {
                                    for (tt_ = 0; tt_ < n地面max; tt_++)
                                    {
                                        if (n地面type[tt_] == 300)
                                        {
                                            if (n敵キャラa[t_] - fx >= -8000 && n敵キャラa[t_] >= n地面a[tt_] + 2000 && n敵キャラa[t_] <= n地面a[tt_] + 3600 && n敵キャラxzimen[t_] == 1) { n地面a[tt_] = -800000; n敵キャラtm[t_] = 100; }
                                        }
                                    }

                                    if (n敵キャラtm[t_] == 100)
                                    {
                                        eyobi(n敵キャラa[t_] + 1200 - 1200, n敵キャラb[t_] + 3000 - 10 * 3000 - 1500, 0, 0, 0, 0, 1000, 10 * 3000 - 1200, 4, 20);
                                        if (nプレイヤーtype == 300) { nプレイヤーtype = 0; DX.StopSoundMem(nオーディオ_[11]); bgmchange(nオーディオ_[100]); DX.PlaySoundMem(nオーディオ_[0], DX.DX_PLAYTYPE_LOOP); }
                                        for (t1 = 0; t1 < n地面max; t1++) { if (n地面type[t1] == 104) n地面a[t1] = -80000000; }
                                    }
                                    if (n敵キャラtm[t_] == 120) { eyobi(n敵キャラa[t_] + 1200 - 1200, n敵キャラb[t_] + 3000 - 10 * 3000 - 1500, 600, -1200, 0, 160, 1000, 10 * 3000 - 1200, 4, 240); n敵キャラmuki[t_] = 1; }
                                    if (n敵キャラtm[t_] == 140) { n敵キャラmuki[t_] = 0; n敵キャラtm[t_] = 0; }
                                }
                                if (n敵キャラtm[t_] >= 220) { n敵キャラtm[t_] = 0; n敵キャラmuki[t_] = 0; }

                                //他の敵を投げる
                                for (tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx[0] = 250; xx[5] = -800; xx[12] = 0; xx[1] = 1600;
                                    xx[8] = n敵キャラa[tt_] - fx; xx[9] = n敵キャラb[tt_] - fy;
                                    if (t_ != tt_ && n敵キャラtype[tt_] >= 100)
                                    {
                                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + xx[0] * 2 && n敵キャラa[t_] - fx < xx[8] + n敵キャラnobia[tt_] - xx[0] * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] + xx[5] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx[9] + xx[1] * 3 + xx[12] + 1500)
                                        {
                                            //aa[tt]=-800000;
                                            n敵キャラmuki[tt_] = 1; n敵キャラa[tt_] = n敵キャラa[t_] + 300; n敵キャラb[tt_] = n敵キャラb[t_] - 3000; n敵キャラbrocktm[tt_] = 120;//aa[tt]=0;
                                            n敵キャラtm[t_] = 200; n敵キャラmuki[t_] = 1;
                                        }
                                    }
                                }

                                break;

                            //ジエン大砲
                            case 7:
                                n敵キャラzimentype[t_] = 0;
                                xx[10] = 0; xx[11] = 400;
                                if (n敵キャラxtype[t_] == 0) xx[10] = xx[11];
                                if (n敵キャラxtype[t_] == 1) xx[10] = -xx[11];
                                if (n敵キャラxtype[t_] == 2) n敵キャラb[t_] -= xx[11];
                                if (n敵キャラxtype[t_] == 3) n敵キャラb[t_] += xx[11];
                                break;

                            //スーパーブーン
                            case 8:
                                n敵キャラzimentype[t_] = 0;
                                xx[22] = 20;
                                if (n敵キャラtm[t_] == 0) { n敵キャラf[t_] += xx[22]; n敵キャラd[t_] += xx[22]; }
                                if (n敵キャラtm[t_] == 1) { n敵キャラf[t_] -= xx[22]; n敵キャラd[t_] -= xx[22]; }
                                if (n敵キャラd[t_] > 300) n敵キャラd[t_] = 300;
                                if (n敵キャラd[t_] < -300) n敵キャラd[t_] = -300;
                                if (n敵キャラf[t_] >= 1200) n敵キャラtm[t_] = 1;
                                if (n敵キャラf[t_] < -0) n敵キャラtm[t_] = 0;
                                n敵キャラb[t_] += n敵キャラd[t_];
                                //atype[t]=151;
                                break;
                            //ノーマルブーン
                            case 151:
                                n敵キャラzimentype[t_] = 2;
                                break;

                            //ファイアー玉
                            case 9:
                                n敵キャラzimentype[t_] = 5;
                                n敵キャラb[t_] += n敵キャラd[t_]; n敵キャラd[t_] += 100;
                                if (n敵キャラb[t_] >= n画面高さ + 1000) { n敵キャラd[t_] = 900; }
                                if (n敵キャラb[t_] >= n画面高さ + 12000)
                                {
                                    n敵キャラb[t_] = n画面高さ; n敵キャラd[t_] = -2600;
                                }
                                break;

                            //ファイアー
                            case 10:
                                n敵キャラzimentype[t_] = 0;
                                xx[10] = 0; xx[11] = 400;
                                if (n敵キャラxtype[t_] == 0) xx[10] = xx[11];
                                if (n敵キャラxtype[t_] == 1) xx[10] = -xx[11];
                                break;


                            //モララー
                            case 30:
                                n敵キャラtm[t_] += 1;
                                if (n敵キャラxtype[t_] == 0)
                                {
                                    if (n敵キャラtm[t_] == 50 && nプレイヤーb >= 6000) { n敵キャラc[t_] = 300; n敵キャラd[t_] -= 1600; n敵キャラb[t_] -= 1000; }

                                    for (tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                    {
                                        xx[0] = 250; xx[5] = -800; xx[12] = 0; xx[1] = 1600;
                                        xx[8] = n敵キャラa[tt_] - fx; xx[9] = n敵キャラb[tt_] - fy;
                                        if (t_ != tt_ && n敵キャラtype[tt_] == 102)
                                        {
                                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + xx[0] * 2 && n敵キャラa[t_] - fx < xx[8] + n敵キャラnobia[tt_] - xx[0] * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] + xx[5] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx[9] + xx[1] * 3 + xx[12] + 1500)
                                            {
                                                n敵キャラa[tt_] = -800000; n敵キャラxtype[t_] = 1; n敵キャラd[t_] = -1600;
                                                n敵キャラmsgtm[t_] = 30; n敵キャラmsgtype[t_] = 25;
                                            }
                                        }
                                    }
                                }
                                if (n敵キャラxtype[t_] == 1)
                                {
                                    n敵キャラzimentype[t_] = 0;
                                    n敵キャラb[t_] += n敵キャラd[t_]; n敵キャラd[t_] += 120;
                                }
                                break;

                            //レーザー
                            case 79:
                                n敵キャラzimentype[t_] = 0;
                                xx[10] = 1600;
                                if (n敵キャラxtype[t_] == 1) { xx[10] = 1200; n敵キャラb[t_] -= 200; }
                                if (n敵キャラxtype[t_] == 2) { xx[10] = 1200; n敵キャラb[t_] += 200; }
                                if (n敵キャラxtype[t_] == 3) { xx[10] = 900; n敵キャラb[t_] -= 600; }
                                if (n敵キャラxtype[t_] == 4) { xx[10] = 900; n敵キャラb[t_] += 600; }
                                break;

                            //雲の敵
                            case 80:
                                n敵キャラzimentype[t_] = 0;
                                //xx[10]=100;
                                break;
                            case 81:
                                n敵キャラzimentype[t_] = 0;
                                break;
                            case 82:
                                n敵キャラzimentype[t_] = 0;
                                break;
                            case 83:
                                n敵キャラzimentype[t_] = 0;
                                break;

                            case 84:
                                n敵キャラzimentype[t_] = 2;
                                break;

                            case 85:
                                xx[23] = 400;
                                if (n敵キャラxtype[t_] == 0) { n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 1; }
                                if (nプレイヤーb >= 30000 && ma >= n敵キャラa[t_] - 3000 * 5 - fx && ma <= n敵キャラa[t_] - fx && n敵キャラxtype[t_] == 1) { n敵キャラxtype[t_] = 5; n敵キャラmuki[t_] = 0; }
                                if (nプレイヤーb >= 24000 && ma <= n敵キャラa[t_] + 3000 * 8 - fx && ma >= n敵キャラa[t_] - fx && n敵キャラxtype[t_] == 1) { n敵キャラxtype[t_] = 5; n敵キャラmuki[t_] = 1; }
                                if (n敵キャラxtype[t_] == 5) xx[10] = xx[23];
                                break;

                            case 86:
                                n敵キャラzimentype[t_] = 4;
                                xx[23] = 1000;
                                if (ma >= n敵キャラa[t_] - fx - nプレイヤーnobia - xx[26] && ma <= n敵キャラa[t_] - fx + n敵キャラnobia[t_] + xx[26]) { n敵キャラtm[t_] = 1; }
                                if (n敵キャラtm[t_] == 1) { n敵キャラb[t_] += 1200; }
                                break;

                            //ファイアバー
                            case 87:
                                n敵キャラzimentype[t_] = 0;
                                if (n敵キャラa[t_] % 10 != 1) n敵キャラtm[t_] += 6;
                                else { n敵キャラtm[t_] -= 6; }
                                xx[25] = 2;
                                if (n敵キャラtm[t_] > 360 * xx[25]) n敵キャラtm[t_] -= 360 * xx[25];
                                if (n敵キャラtm[t_] < 0) n敵キャラtm[t_] += 360 * xx[25];

                                for (tt_ = 0; tt_ <= n敵キャラxtype[t_] % 100; tt_++)
                                {
                                    xx[26] = 18;
                                    xd[4] = tt_ * xx[26] * Math.Cos(n敵キャラtm[t_] * Math.PI / 180 / 2); xd[5] = tt_ * xx[26] * Math.Sin(n敵キャラtm[t_] * Math.PI / 180 / 2);

                                    xx[4] = 1800; xx[5] = 800;
                                    xx[8] = n敵キャラa[t_] - fx + (int)xd[4] * 100 - xx[4] / 2; xx[9] = n敵キャラb[t_] - fy + (int)xd[5] * 100 - xx[4] / 2;

                                    if (ma + nプレイヤーnobia > xx[8] + xx[5] && ma < xx[8] + xx[4] - xx[5] && nプレイヤーb + nプレイヤーnobib > xx[9] + xx[5] && nプレイヤーb < xx[9] + xx[4] - xx[5])
                                    {
                                        nプレイヤーhp -= 1;
                                        nメッセージtype = 51; nメッセージtm = 30;
                                    }
                                }

                                break;

                            case 88:
                                n敵キャラzimentype[t_] = 0;
                                if (n敵キャラa[t_] % 10 != 1) n敵キャラtm[t_] += 6;
                                else { n敵キャラtm[t_] -= 6; }
                                xx[25] = 2;
                                if (n敵キャラtm[t_] > 360 * xx[25]) n敵キャラtm[t_] -= 360 * xx[25];
                                if (n敵キャラtm[t_] < 0) n敵キャラtm[t_] += 360 * xx[25];

                                for (tt_ = 0; tt_ <= n敵キャラxtype[t_] % 100; tt_++)
                                {
                                    xx[26] = 18;
                                    xd[4] = -tt_ * xx[26] * Math.Cos(n敵キャラtm[t_] * Math.PI / 180 / 2);
                                    xd[5] = tt_ * xx[26] * Math.Sin(n敵キャラtm[t_] * Math.PI / 180 / 2);

                                    xx[4] = 1800;
                                    xx[5] = 800;
                                    xx[8] = n敵キャラa[t_] - fx + (int)xd[4] * 100 - xx[4] / 2;
                                    xx[9] = n敵キャラb[t_] - fy + (int)xd[5] * 100 - xx[4] / 2;

                                    if (ma + nプレイヤーnobia > xx[8] + xx[5] && ma < xx[8] + xx[4] - xx[5] && nプレイヤーb + nプレイヤーnobib > xx[9] + xx[5] && nプレイヤーb < xx[9] + xx[4] - xx[5])
                                    {
                                        nプレイヤーhp -= 1;
                                        nメッセージtype = 51; nメッセージtm = 30;
                                    }
                                }

                                break;


                            case 90:
                                xx[10] = 160;
                                //azimentype[t]=0;
                                break;


                            //おいしいキノコ
                            case 100:
                                n敵キャラzimentype[t_] = 1;
                                xx[10] = 100;

                                //ほかの敵を巨大化
                                if (n敵キャラxtype[t_] == 2)
                                {
                                    for (tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                    {
                                        xx[0] = 250; xx[5] = -800; xx[12] = 0; xx[1] = 1600;
                                        xx[8] = n敵キャラa[tt_] - fx; xx[9] = n敵キャラb[tt_] - fy;
                                        if (t_ != tt_)
                                        {
                                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + xx[0] * 2 && n敵キャラa[t_] - fx < xx[8] + n敵キャラnobia[tt_] - xx[0] * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] + xx[5] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx[9] + xx[1] * 3 + xx[12])
                                            {
                                                if (n敵キャラtype[tt_] == 0 || n敵キャラtype[tt_] == 4)
                                                {
                                                    n敵キャラtype[tt_] = 90;//ot(oto[6]);
                                                    n敵キャラnobia[tt_] = 6400; n敵キャラnobib[tt_] = 6300; n敵キャラxtype[tt_] = 0;
                                                    n敵キャラa[tt_] -= 1050; n敵キャラb[tt_] -= 1050;
                                                    ot(nオーディオ_[9]); n敵キャラa[t_] = -80000000;
                                                }
                                            }
                                        }
                                    }
                                }

                                break;

                            //毒キノコ
                            case 102:
                                n敵キャラzimentype[t_] = 1;
                                xx[10] = 100;
                                if (n敵キャラxtype[t_] == 1) xx[10] = 200;
                                break;

                            //悪スター
                            case 110:
                                n敵キャラzimentype[t_] = 1;
                                xx[10] = 200;
                                if (n敵キャラxzimen[t_] == 1)
                                {
                                    n敵キャラb[t_] -= 1200; n敵キャラd[t_] = -1400;
                                }
                                break;


                            case 200:
                                n敵キャラzimentype[t_] = 1;
                                xx[10] = 100;
                                break;


                        }//sw


                        if (n敵キャラbrocktm[t_] >= 1) xx[10] = 0;



                        if (n敵キャラmuki[t_] == 0) n敵キャラacta[t_] -= xx[10];
                        if (n敵キャラmuki[t_] == 1) n敵キャラacta[t_] += xx[10];

                        //最大値
                        xx[0] = 850; xx[1] = 1200;

                        if (n敵キャラd[t_] > xx[1] && n敵キャラzimentype[t_] != 5) { n敵キャラd[t_] = xx[1]; }


                        //行動
                        n敵キャラa[t_] += n敵キャラacta[t_];//ab[t]+=aactb[t];

                        if ((n敵キャラzimentype[t_] >= 1 || n敵キャラzimentype[t_] == -1) && n敵キャラbrocktm[t_] <= 0)
                        {
                            //if (atype[t]==4)end();

                            //移動
                            n敵キャラa[t_] += n敵キャラc[t_];
                            if (n敵キャラzimentype[t_] >= 1 && n敵キャラzimentype[t_] <= 3) { n敵キャラb[t_] += n敵キャラd[t_]; n敵キャラd[t_] += 120; }//ad[t]+=180;


                            if (n敵キャラxzimen[t_] == 1)
                            {
                                xx[0] = 100;
                                if (n敵キャラc[t_] >= 200) { n敵キャラc[t_] -= xx[0]; }
                                else if (n敵キャラc[t_] <= -200) { n敵キャラc[t_] += xx[0]; }
                                else { n敵キャラc[t_] = 0; }
                            }

                            n敵キャラxzimen[t_] = 0;




                            //地面判定
                            if (n敵キャラzimentype[t_] != 2)
                            {
                                tekizimen();
                            }


                        }//azimentype[t]>=1

                        //ブロックから出現するさい
                        if (n敵キャラbrocktm[t_] > 0)
                        {
                            n敵キャラbrocktm[t_]--;
                            if (n敵キャラbrocktm[t_] < 100) { n敵キャラb[t_] -= 180; }
                            if (n敵キャラbrocktm[t_] > 100) { }
                            if (n敵キャラbrocktm[t_] == 100) { n敵キャラb[t_] -= 800; n敵キャラd[t_] = -1200; n敵キャラc[t_] = 700; n敵キャラbrocktm[t_] = 0; }
                        }//abrocktm[t]>0

                        //プレイヤーからの判定
                        xx[0] = 250; xx[1] = 1600; xx[2] = 1000;
                        xx[4] = 500; xx[5] = -800;

                        xx[8] = n敵キャラa[t_] - fx; xx[9] = n敵キャラb[t_] - fy;
                        xx[12] = 0; if (nプレイヤーd >= 100) xx[12] = nプレイヤーd;
                        xx[25] = 0;

                        if (ma + nプレイヤーnobia > xx[8] + xx[0] * 2 && ma < xx[8] + n敵キャラnobia[t_] - xx[0] * 2 && nプレイヤーb + nプレイヤーnobib > xx[9] - xx[5] && nプレイヤーb + nプレイヤーnobib < xx[9] + xx[1] + xx[12] && (nプレイヤーmutekitm <= 0 || nプレイヤーd >= 100) && n敵キャラbrocktm[t_] <= 0)
                        {
                            if (n敵キャラtype[t_] != 4 && n敵キャラtype[t_] != 9 && n敵キャラtype[t_] != 10 && (n敵キャラtype[t_] <= 78 || n敵キャラtype[t_] == 85) && nプレイヤーzimen != 1 && nプレイヤーtype != 200)
                            {

                                if (n敵キャラtype[t_] == 0)
                                {
                                    if (n敵キャラxtype[t_] == 0)
                                        n敵キャラa[t_] = -900000;
                                    if (n敵キャラxtype[t_] == 1)
                                    {
                                        ot(nオーディオ_[5]);
                                        nプレイヤーb = xx[9] - 900 - n敵キャラnobib[t_]; nプレイヤーd = -2100; xx[25] = 1; nプレイヤーactaon[2] = 0;
                                    }
                                }

                                if (n敵キャラtype[t_] == 1)
                                {
                                    n敵キャラtype[t_] = 2; n敵キャラnobib[t_] = 3000; n敵キャラxtype[t_] = 0;
                                }

                                //こうら
                                else if (n敵キャラtype[t_] == 2 && nプレイヤーd >= 0)
                                {
                                    if (n敵キャラxtype[t_] == 1 || n敵キャラxtype[t_] == 2) { n敵キャラxtype[t_] = 0; }
                                    else if (n敵キャラxtype[t_] == 0)
                                    {
                                        if (ma + nプレイヤーnobia > xx[8] + xx[0] * 2 && ma < xx[8] + n敵キャラnobia[t_] / 2 - xx[0] * 4)
                                        {
                                            n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 1;
                                        }
                                        else { n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 0; }
                                    }
                                }
                                if (n敵キャラtype[t_] == 3)
                                {
                                    xx[25] = 1;
                                }

                                if (n敵キャラtype[t_] == 6)
                                {
                                    n敵キャラtm[t_] = 10; nプレイヤーd = 0; nプレイヤーactaon[2] = 0;
                                }

                                if (n敵キャラtype[t_] == 7)
                                {
                                    n敵キャラa[t_] = -900000;
                                }

                                if (n敵キャラtype[t_] == 8)
                                {
                                    n敵キャラtype[t_] = 151; n敵キャラd[t_] = 0;
                                }

                                if (n敵キャラtype[t_] != 85)
                                {
                                    if (xx[25] == 0) { ot(nオーディオ_[5]); nプレイヤーb = xx[9] - 1000 - n敵キャラnobib[t_]; nプレイヤーd = -1000; }
                                }
                                if (n敵キャラtype[t_] == 85)
                                {
                                    if (xx[25] == 0) { ot(nオーディオ_[5]); nプレイヤーb = xx[9] - 4000; nプレイヤーd = -1000; n敵キャラxtype[t_] = 5; }
                                }

                                if (nプレイヤーactaon[2] == 1) { nプレイヤーd = -1600; nプレイヤーactaon[2] = 0; }
                            }
                        }

                        xx[15] = -500;


                        //プレイヤーに触れた時
                        xx[16] = 0;
                        if (n敵キャラtype[t_] == 4 || n敵キャラtype[t_] == 9 || n敵キャラtype[t_] == 10) xx[16] = -3000;
                        if (n敵キャラtype[t_] == 82 || n敵キャラtype[t_] == 83 || n敵キャラtype[t_] == 84) xx[16] = -3200;
                        if (n敵キャラtype[t_] == 85) xx[16] = -n敵キャラnobib[t_] + 6000;
                        if (ma + nプレイヤーnobia > xx[8] + xx[4] && ma < xx[8] + n敵キャラnobia[t_] - xx[4] && nプレイヤーb < xx[9] + n敵キャラnobib[t_] + xx[15] && nプレイヤーb + nプレイヤーnobib > xx[9] + n敵キャラnobib[t_] - xx[0] + xx[16] && n敵キャラnotm[t_] <= 0 && n敵キャラbrocktm[t_] <= 0)
                        {
                            if (nプレイヤーmutekion == 1) { n敵キャラa[t_] = -9000000; }
                            if (nプレイヤーmutekitm <= 0 && (n敵キャラtype[t_] <= 99 || n敵キャラtype[t_] >= 200))
                            {
                                if (nプレイヤーmutekion != 1 && nプレイヤーtype != 200)
                                {
                                    //if (mmutekitm<=0)

                                    //ダメージ
                                    if ((n敵キャラtype[t_] != 2 || n敵キャラxtype[t_] != 0) && nプレイヤーhp >= 1)
                                    {
                                        if (n敵キャラtype[t_] != 6)
                                        {
                                            nプレイヤーhp -= 1;
                                            //mmutekitm=40;
                                        }
                                    }

                                    if (n敵キャラtype[t_] == 6)
                                    {
                                        n敵キャラtm[t_] = 10;
                                    }


                                    //せりふ
                                    if (nプレイヤーhp == 0)
                                    {

                                        if (n敵キャラtype[t_] == 0 || n敵キャラtype[t_] == 7)
                                        {
                                            n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = rand(7) + 1 + 1000 + (nステージb - 1) * 10;
                                        }

                                        if (n敵キャラtype[t_] == 1)
                                        {
                                            n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = rand(2) + 15;
                                        }

                                        if (n敵キャラtype[t_] == 2 && n敵キャラxtype[t_] >= 1 && nプレイヤーmutekitm <= 0)
                                        {
                                            n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = 18;
                                        }

                                        if (n敵キャラtype[t_] == 3)
                                        {
                                            n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = 20;
                                        }

                                        if (n敵キャラtype[t_] == 4)
                                        {
                                            n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = rand(7) + 1 + 1000 + (nステージb - 1) * 10;
                                        }

                                        if (n敵キャラtype[t_] == 5)
                                        {
                                            n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = 21;
                                        }

                                        if (n敵キャラtype[t_] == 9 || n敵キャラtype[t_] == 10)
                                        {
                                            nメッセージtm = 30; nメッセージtype = 54;
                                        }



                                        if (n敵キャラtype[t_] == 31)
                                        {
                                            n敵キャラmsgtm[t_] = 30; n敵キャラmsgtype[t_] = 24;
                                        }


                                        if (n敵キャラtype[t_] == 80 || n敵キャラtype[t_] == 81)
                                        {
                                            n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = 30;
                                        }

                                        if (n敵キャラtype[t_] == 82)
                                        {
                                            n敵キャラmsgtm[t_] = 20; n敵キャラmsgtype[t_] = rand(1) + 31;
                                            xx[24] = 900; n敵キャラtype[t_] = 83; n敵キャラa[t_] -= xx[24] + 100; n敵キャラb[t_] -= xx[24] - 100 * 0;
                                        }//82

                                        if (n敵キャラtype[t_] == 84)
                                        {
                                            nメッセージtm = 30; nメッセージtype = 50;
                                        }

                                        if (n敵キャラtype[t_] == 85)
                                        {
                                            n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = rand(1) + 85;
                                        }


                                        //雲
                                        if (n敵キャラtype[t_] == 80)
                                        {
                                            n敵キャラtype[t_] = 81;
                                        }
                                    }//mhp==0


                                    //こうら
                                    if (n敵キャラtype[t_] == 2)
                                    {
                                        if (n敵キャラxtype[t_] == 0)
                                        {
                                            if (ma + nプレイヤーnobia > xx[8] + xx[0] * 2 && ma < xx[8] + n敵キャラnobia[t_] / 2 - xx[0] * 4)
                                            {
                                                n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 1; n敵キャラa[t_] = ma + nプレイヤーnobia + fx + nプレイヤーc; nプレイヤーmutekitm = 5;
                                            }
                                            else {
                                                n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 0; n敵キャラa[t_] = ma - n敵キャラnobia[t_] + fx - nプレイヤーc; nプレイヤーmutekitm = 5;
                                            }
                                        }
                                        else { nプレイヤーhp -= 1; }//mmutekitm=40;}
                                    }


                                }
                            }
                            //アイテム
                            if (n敵キャラtype[t_] >= 100 && n敵キャラtype[t_] <= 199)
                            {

                                if (n敵キャラtype[t_] == 100 && n敵キャラxtype[t_] == 0) { nメッセージtm = 30; nメッセージtype = 1; ot(nオーディオ_[9]); }
                                if (n敵キャラtype[t_] == 100 && n敵キャラxtype[t_] == 1) { nメッセージtm = 30; nメッセージtype = 2; ot(nオーディオ_[9]); }
                                if (n敵キャラtype[t_] == 100 && n敵キャラxtype[t_] == 2) { nプレイヤーnobia = 5200; nプレイヤーnobib = 7300; ot(nオーディオ_[9]); ma -= 1100; nプレイヤーb -= 4000; nプレイヤーtype = 1; nプレイヤーhp = 50000000; }

                                if (n敵キャラtype[t_] == 101) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 11; }
                                if (n敵キャラtype[t_] == 102) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 10; }


                                //?ボール
                                if (n敵キャラtype[t_] == 105)
                                {
                                    if (n敵キャラxtype[t_] == 0)
                                    {
                                        ot(nオーディオ_[4]); n地面gtype [26] = 6;
                                    }
                                    if (n敵キャラxtype[t_] == 1)
                                    {
                                        nブロックxtype[7] = 80;
                                        ot(nオーディオ_[4]);

                                        ayobi(n敵キャラa[t_] - 8 * 3000 - 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(n敵キャラa[t_] - 10 * 3000 + 1000, -1 * 3000, 0, 0, 0, 110, 0);

                                        ayobi(n敵キャラa[t_] + 4 * 3000 + 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(n敵キャラa[t_] + 5 * 3000 - 1000, -3 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(n敵キャラa[t_] + 6 * 3000 + 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(n敵キャラa[t_] + 7 * 3000 - 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(n敵キャラa[t_] + 8 * 3000 + 1000, -2 * 3000 - 1000, 0, 0, 0, 110, 0);
                                        nブロックb[0] += 3000 * 3;
                                    }
                                }//105

                                if (n敵キャラtype[t_] == 110) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 3; }

                                n敵キャラa[t_] = -90000000;
                            }

                        }//(ma

                    }
                    else { n敵キャラa[t_] = -9000000; }

                }//t

                //スクロール
                if (n強制スクロール != 1 && n強制スクロール != 2)
                {
                    xx[2] = maScrollMax; xx[3] = 0;
                    xx[1] = xx[2]; if (ma > xx[1] && fzx < scrollX) { xx[5] = ma - xx[1]; ma = xx[1]; fx += xx[5]; fzx += xx[5]; if (xx[1] <= 5000) xx[3] = 1; }
                }//kscroll

            }


            //スタッフロール
            if (main == 2)
            {
                maintm++;

                xx[7] = 46;
                if (DX.CheckHitKey(DX.KEY_INPUT_1) == 1) { end(); }
                if (DX.CheckHitKey(DX.KEY_INPUT_SPACE) == 1) { for (t_ = 0; t_ <= xx[7]; t_ += 1) { xx[12 + t_] -= 300; } }

                if (maintm <= 1)
                {
                    maintm = 2; bgmchange(nオーディオ_[106]); DX.PlaySoundMem(nオーディオ_[0], DX.DX_PLAYTYPE_LOOP); xx[10] = 0;
                    for (t_ = 0; t_ <= xx[7]; t_ += 1) { xx[12 + t_] = 980000; }
                    //for (t=0;t<=xx[7];t+=2){xx[12+t]=46000;}
                    xx[12] = 460;
                    xx[13] = 540; xx[14] = 590;
                    xx[15] = 650; xx[16] = 700;
                    xx[17] = 760; xx[18] = 810;
                    xx[19] = 870; xx[20] = 920;

                    xx[21] = 1000; xx[22] = 1050; xx[23] = 1100;
                    xx[24] = 1180; xx[25] = 1230;

                    xx[26] = 1360; xx[27] = 1410;
                    xx[28] = 1540; xx[29] = 1590;

                    xx[30] = 1800;

                    for (t_ = 0; t_ <= xx[7]; t_ += 1) { xx[12 + t_] *= 100; }
                }

                xx[10] += 1;
                for (t_ = 0; t_ <= xx[7]; t_ += 1) { xx[12 + t_] -= 100; }//t

                if (xx[30] == -200) { bgmchange(nオーディオ_[106]); }
                if (xx[30] <= -400) { main = 100; nokori = 2; maintm = 0; nスタッフロール = 0; }

            }//main==2

            if (main == 10)
            {
                maintm++;

                if (nクイック == 1) maintm += 2;
                if (maintm >= 30) { maintm = 0; main = 1; zxon = 0; }
            }//if (main==10){

            //タイトル
            if (main == 100)
            {
                maintm++; xx[0] = 0;
                if (maintm <= 10) { maintm = 11; nステージa = 1; nステージb = 1; nステージc = 0; over = 0; }

                if (DX.CheckHitKey(DX.KEY_INPUT_1) == 1) { nステージa = 1; nステージb = 1; nステージc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_2) == 1) { nステージa = 1; nステージb = 2; nステージc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_3) == 1) { nステージa = 1; nステージb = 3; nステージc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_4) == 1) { nステージa = 1; nステージb = 4; nステージc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_5) == 1) { nステージa = 2; nステージb = 1; nステージc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_6) == 1) { nステージa = 2; nステージb = 2; nステージc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_7) == 1) { nステージa = 2; nステージb = 3; nステージc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_8) == 1) { nステージa = 2; nステージb = 4; nステージc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_9) == 1) { nステージa = 3; nステージb = 1; nステージc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_0) == 1) { xx[0] = 1; over = 1; }


                if (DX.CheckHitKey(DX.KEY_INPUT_RETURN) == 1) { xx[0] = 1; }
                if (DX.CheckHitKey(DX.KEY_INPUT_Z) == 1) { xx[0] = 1; }

                if (xx[0] == 1)
                {
                    main = 10; zxon = 0; maintm = 0;
                    nokori = 2;

                    nクイック = 0; nトラップ表示 = 0; n中間ゲート = 0;
                }

            }//100
        }//Mainprogram()

        static void tekizimen()
        {

            //壁
            for (tt_ = 0; tt_ < n地面max; tt_++)
            {
                if (n地面a[tt_] - fx + n地面c[tt_] >= -12010 && n地面a[tt_] - fx <= n画面幅 + 12100 && n地面type[tt_] <= 99)
                {
                    xx[0] = 200; xx[2] = 1000;
                    xx[1] = 2000;//anobia[t]

                    xx[8] = n地面a[tt_] - fx; xx[9] = n地面b[tt_] - fy;
                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] - xx[0] && n敵キャラa[t_] - fx < xx[8] + xx[2] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] + xx[1] * 3 / 4 && n敵キャラb[t_] - fy < xx[9] + n地面d[tt_] - xx[2]) { n敵キャラa[t_] = xx[8] - xx[0] - n敵キャラnobia[t_] + fx; n敵キャラmuki[t_] = 0; }
                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + n地面c[tt_] - xx[0] && n敵キャラa[t_] - fx < xx[8] + n地面c[tt_] + xx[0] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] + xx[1] * 3 / 4 && n敵キャラb[t_] - fy < xx[9] + n地面d[tt_] - xx[2]) { n敵キャラa[t_] = xx[8] + n地面c[tt_] + xx[0] + fx; n敵キャラmuki[t_] = 1; }

                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + xx[0] && n敵キャラa[t_] - fx < xx[8] + n地面c[tt_] - xx[0] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx[9] + n地面d[tt_] - xx[1] && n敵キャラd[t_] >= -100) { n敵キャラb[t_] = n地面b[tt_] - fy - n敵キャラnobib[t_] + 100 + fy; n敵キャラd[t_] = 0; n敵キャラxzimen[t_] = 1; }

                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + xx[0] && n敵キャラa[t_] - fx < xx[8] + n地面c[tt_] - xx[0] && n敵キャラb[t_] - fy > xx[9] + n地面d[tt_] - xx[1] && n敵キャラb[t_] - fy < xx[9] + n地面d[tt_] + xx[0])
                    {
                        n敵キャラb[t_] = xx[9] + n地面d[tt_] + xx[0] + fy; if (n敵キャラd[t_] < 0) { n敵キャラd[t_] = -n敵キャラd[t_] * 2 / 3; }//axzimen[t]=1;
                    }

                }
            }

            //ブロック
            for (tt_ = 0; tt_ < nブロックmax; tt_++)
            {
                xx[0] = 200; xx[1] = 3000; xx[2] = 1000;
                xx[8] = nブロックa[tt_] - fx; xx[9] = nブロックb[tt_] - fy;
                if (nブロックa[tt_] - fx + xx[1] >= -12010 && nブロックa[tt_] - fx <= n画面幅 + 12000)
                {
                    if (n敵キャラtype[t_] != 86 && n敵キャラtype[t_] != 90 && nブロックtype[tt_] != 140)
                    {

                        //上
                        if (nブロックtype[tt_] != 7)
                        {
                            //if (ttype[tt]==117 && txtype[t]==1){ad[t]=-1500;}
                            if (!(nブロックtype[tt_] == 117))
                            {
                                //if (!(ttype[tt]==120 && txtype[t]==0)){
                                if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + xx[0] && n敵キャラa[t_] - fx < xx[8] + xx[1] - xx[0] * 1 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx[9] + xx[1] && n敵キャラd[t_] >= -100)
                                {
                                    n敵キャラb[t_] = xx[9] - n敵キャラnobib[t_] + 100 + fy; n敵キャラd[t_] = 0; n敵キャラxzimen[t_] = 1;
                                    //ジャンプ台
                                    if (nブロックtype[tt_] == 120) { n敵キャラd[t_] = -1600; n敵キャラzimentype[t_] = 30; }
                                    //}

                                }
                            }
                        }

                        //下
                        if (nブロックtype[tt_] != 117)
                        {
                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + xx[0] && n敵キャラa[t_] - fx < xx[8] + xx[1] - xx[0] * 1 && n敵キャラb[t_] - fy > xx[9] + xx[1] - xx[1] && n敵キャラb[t_] - fy < xx[9] + xx[1] + xx[0])
                            {
                                n敵キャラb[t_] = xx[9] + xx[1] + xx[0] + fy; if (n敵キャラd[t_] < 0) { n敵キャラd[t_] = 0; }                                                             //}
                            }
                        }

                        //左右
                        xx[27] = 0;
                        if ((n敵キャラtype[t_] >= 100 || (nブロックtype[tt_] != 7 || nブロックtype[tt_] == 7 && n敵キャラtype[t_] == 2)) && nブロックtype[tt_] != 117)
                        {
                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] && n敵キャラa[t_] - fx < xx[8] + xx[2] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] + xx[1] / 2 - xx[0] && n敵キャラb[t_] - fy < xx[9] + xx[2]) { n敵キャラa[t_] = xx[8] - n敵キャラnobia[t_] + fx; n敵キャラc[t_] = 0; n敵キャラmuki[t_] = 0; xx[27] = 1; }
                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] + xx[1] - xx[0] * 2 && n敵キャラa[t_] - fx < xx[8] + xx[1] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] + xx[1] / 2 - xx[0] && n敵キャラb[t_] - fy < xx[9] + xx[2]) { n敵キャラa[t_] = xx[8] + xx[1] + fx; n敵キャラc[t_] = 0; n敵キャラmuki[t_] = 1; xx[27] = 1; }
                            //こうらブレイク
                            if (xx[27] == 1 && (nブロックtype[tt_] == 7 || nブロックtype[tt_] == 1) && n敵キャラtype[t_] == 2)
                            {
                                if (nブロックtype[tt_] == 7)
                                {
                                    ot(nオーディオ_[4]); nブロックtype[tt_] = 3;
                                    eyobi(nブロックa[tt_] + 10, nブロックb[tt_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                }
                                else if (nブロックtype[tt_] == 1)
                                {
                                    ot(nオーディオ_[3]);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    brockbreak(tt_);
                                }

                            }
                        }
                    }
                    if (n敵キャラtype[t_] == 86 || n敵キャラtype[t_] == 90)
                    {
                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] && n敵キャラa[t_] - fx < xx[8] + xx[1] && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx[9] && n敵キャラb[t_] - fy < xx[9] + xx[1])
                        {
                            ot(nオーディオ_[3]);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                            brockbreak(tt_);

                        }
                    }//90
                }
                //剣とってクリア
                if (nブロックtype[tt_] == 140)
                {
                    if (n敵キャラb[t_] - fy > xx[9] - xx[0] * 2 - 2000 && n敵キャラb[t_] - fy < xx[9] + xx[1] - xx[0] * 2 + 2000 && n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx[8] - 400 && n敵キャラa[t_] - fx < xx[8] + xx[1])
                    {
                        nブロックa[tt_] = -800000;//ot(oto[4]);
                        nリフトacttype[20] = 1; nリフトon[20] = 1;
                    }
                }
            }//tt

        }//tekizimen
    }
}
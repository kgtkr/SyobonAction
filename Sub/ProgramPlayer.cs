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
        static void UpdatePlayer()
        {
            //プレイヤーの移動
            xx[0] = 0; nプレイヤーactaon[2] = 0; nプレイヤーactaon[3] = 0;
            if (nプレイヤーkeytm <= 0)
            {
                if (Key.GetKey(DX.KEY_INPUT_LEFT) && keyTm <= 0)
                {
                    nプレイヤーactaon[0] = -1;
                    nプレイヤーmuki = 0;
                    nプレイヤーactaon[4] = -1;
                }
                if (Key.GetKey(DX.KEY_INPUT_RIGHT) && keyTm <= 0)
                {
                    nプレイヤーactaon[0] = 1;
                    nプレイヤーmuki = 1;
                    nプレイヤーactaon[4] = 1;
                }
                if (Key.GetKey(DX.KEY_INPUT_DOWN))
                {
                    nプレイヤーactaon[3] = 1;
                }
            }

            if (Key.GetKey(DX.KEY_INPUT_F1))
            {
                e現在の画面 = E画面.Title;
            }
            if (Key.GetKey(DX.KEY_INPUT_O))
            {
                if (nプレイヤーhp >= 1)
                {
                    nプレイヤーhp = 0;
                }
                if (nステージc >= 5)
                {
                    nステージc = 0;
                    stagepoint = 0;
                }
            }


            if (nプレイヤーkeytm <= 0)
            {
                if (Key.GetKey(DX.KEY_INPUT_Z))
                {
                    if (nプレイヤーactaon[1] == 10)
                    {
                        nプレイヤーactaon[1] = 1;
                        xx[0] = 1;
                    }
                    nプレイヤーactaon[2] = 1;
                }
            }

            if (Key.GetKey(DX.KEY_INPUT_Z))
            {
                if (nプレイヤーjumptm == 8 && nプレイヤーd >= -900)
                {
                    nプレイヤーd = -1300;
                    //ダッシュ中
                    xx[22] = 200;
                    if (nプレイヤーc >= xx[22] || nプレイヤーc <= -xx[22])
                    {
                        nプレイヤーd = -1400;
                    }

                    xx[22] = 600;
                    if (nプレイヤーc >= xx[22] || nプレイヤーc <= -xx[22])
                    {
                        nプレイヤーd = -1500;
                    }
                }
                if (xx[0] == 0) nプレイヤーactaon[1] = 10;
            }

            //加速による移動
            xx[0] = 40;
            xx[1] = 700;
            xx[8] = 500;
            xx[9] = 700;

            xx[12] = 1;
            xx[13] = 2;

            //すべり補正
            if (nプレイヤーrzimen == 1)
            {
                xx[0] = 20;
                xx[12] = 9;
                xx[13] = 10;
            }


            //if (mzimen==0){xx[0]-=15;}
            if (nプレイヤーactaon[0] == -1)
            {
                if (!(nプレイヤーzimen == 0 && nプレイヤーc < -xx[8]))
                {
                    if (nプレイヤーc >= -xx[9])
                    {
                        nプレイヤーc -= xx[0];
                        if (nプレイヤーc < -xx[9])
                        {
                            nプレイヤーc = -xx[9] - 1;
                        }
                    }

                    if (nプレイヤーc < -xx[9] && nプレイヤーatktm <= 0)
                    {
                        nプレイヤーc -= xx[0] / 10;
                    }
                }
                if (nプレイヤーrzimen != 1)
                {
                    if (nプレイヤーc > 100 && nプレイヤーzimen == 0)
                    {
                        nプレイヤーc -= xx[0] * 2 / 3;
                    }
                    if (nプレイヤーc > 100 && nプレイヤーzimen == 1)
                    {
                        nプレイヤーc -= xx[0];
                        if (nプレイヤーzimen == 1)
                        {
                            nプレイヤーc -= xx[0] * 1 / 2;
                        }
                    }
                    nプレイヤーactaon[0] = 3;
                    nプレイヤーkasok += 1;
                }
            }

            if (nプレイヤーactaon[0] == 1)
            {
                if (!(nプレイヤーzimen == 0 && nプレイヤーc > xx[8]))
                {
                    if (nプレイヤーc <= xx[9])
                    {
                        nプレイヤーc += xx[0];
                        if (nプレイヤーc > xx[9])
                        {
                            nプレイヤーc = xx[9] + 1;
                        }
                    }
                    if (nプレイヤーc > xx[9] && nプレイヤーatktm <= 0)
                    {
                        nプレイヤーc += xx[0] / 10;
                    }
                }
                if (nプレイヤーrzimen != 1)
                {
                    if (nプレイヤーc < -100 && nプレイヤーzimen == 0)
                    {
                        nプレイヤーc += xx[0] * 2 / 3;
                    }
                    if (nプレイヤーc < -100 && nプレイヤーzimen == 1)
                    {
                        nプレイヤーc += xx[0];
                        if (nプレイヤーzimen == 1)
                        {
                            nプレイヤーc += xx[0] * 1 / 2;
                        }
                    }
                    nプレイヤーactaon[0] = 3;
                    nプレイヤーkasok += 1;
                }
            }
            if (nプレイヤーactaon[0] == 0 && nプレイヤーkasok > 0)
            {
                nプレイヤーkasok -= 2;
            }
            if (nプレイヤーkasok > 8)
            {
                nプレイヤーkasok = 8;
            }

            //すべり補正初期化
            if (nプレイヤーzimen != 1)
            {
                nプレイヤーrzimen = 0;
            }


            //ジャンプ
            if (nプレイヤーjumptm >= 0)
            {
                nプレイヤーjumptm--;
            }
            if (nプレイヤーactaon[1] == 1 && nプレイヤーzimen == 1)
            {
                nプレイヤーb -= 400;
                nプレイヤーd = -1200;
                nプレイヤーjumptm = 10;

                v効果音再生(nオーディオ_[1]);

                nプレイヤーzimen = 0;

            }
            if (nプレイヤーactaon[1] <= 9)
            {
                nプレイヤーactaon[1] = 0;
            }

            if (nプレイヤーmutekitm >= -1)
            {
                nプレイヤーmutekitm--;
            }

            //HPがなくなったとき
            if (nプレイヤーhp <= 0 && nプレイヤーhp >= -9)
            {
                nプレイヤーkeytm = 12;
                nプレイヤーhp = -20;
                nプレイヤーtype = 200;
                nプレイヤーtm = 0;
                v効果音再生(nオーディオ_[12]);
                DX.StopSoundMem(nオーディオ_[0]);
                DX.StopSoundMem(nオーディオ_[11]);
                DX.StopSoundMem(nオーディオ_[16]);
            }//mhp
            if (nプレイヤーtype == 200)
            {
                if (nプレイヤーtm <= 11)
                {
                    nプレイヤーc = 0;
                    nプレイヤーd = 0;
                }
                if (nプレイヤーtm == 12)
                {
                    nプレイヤーd = -1200;
                }
                if (nプレイヤーtm >= 12)
                {
                    nプレイヤーc = 0;
                }
                if (nプレイヤーtm >= 100 || nクイック == 1)
                {
                    zxon = 0;
                    e現在の画面 = E画面.機数表示;
                    nプレイヤーtm = 0;
                    nプレイヤーkeytm = 0;
                    nokori--;
                    if (nクイック == 1) nプレイヤーtype = 0;
                }
            }


            //音符によるワープ
            if (nプレイヤーtype == 2)
            {
                nプレイヤーtm++;

                nプレイヤーkeytm = 2;
                nプレイヤーd = -1500;
                if (nプレイヤーb <= -6000)
                {
                    blackX = 1;
                    blackTm = 20;
                    nステージc += 5;
                    DX.StopSoundMem(nオーディオ_[0]);
                    nプレイヤーtm = 0;
                    nプレイヤーtype = 0;
                    nプレイヤーkeytm = -1;
                }
            }

            //ジャンプ台アウト
            if (nプレイヤーtype == 3)
            {
                nプレイヤーd = -2400;
                if (nプレイヤーb <= -6000)
                {
                    nプレイヤーb = -80000000;
                    nプレイヤーhp = 0;
                }
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
                        nプレイヤーc = 0;
                        nプレイヤーd = 0;
                        t_ = 28;
                        if (nプレイヤーtm <= 16)
                        {
                            nプレイヤーb += 240;
                            nプレイヤーzz = 100;
                        }
                        if (nプレイヤーtm == 17)
                        {
                            nプレイヤーb = -80000000;
                        }
                        if (nプレイヤーtm == 23)
                        {
                            n地面a[t_] -= 100;
                        }
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
                        if (nプレイヤーtm >= 110)
                        {
                            n地面b[t_] -= nプレイヤーzz;
                            nプレイヤーzz += 80;
                            if (nプレイヤーzz > 1600) nプレイヤーzz = 1600;
                        }
                        if (nプレイヤーtm == 160)
                        {
                            nプレイヤーtype = 0;
                            nプレイヤーhp--;
                        }
                    }

                    //ふっとばし
                    else if (nプレイヤーxtype == 10)
                    {
                        nプレイヤーc = 0; nプレイヤーd = 0;
                        if (nプレイヤーtm <= 16)
                        {
                            ma += 240;
                        }
                        if (nプレイヤーtm == 16) nプレイヤーb -= 1100;
                        if (nプレイヤーtm == 20) v効果音再生(nオーディオ_[10]);

                        if (nプレイヤーtm >= 24)
                        {
                            ma -= 2000;
                            nプレイヤーmuki = 0;
                        }
                        if (nプレイヤーtm >= 48)
                        {
                            nプレイヤーtype = 0;
                            nプレイヤーhp--;
                        }

                    }
                    else {
                        nプレイヤーc = 0; nプレイヤーd = 0;
                        if (nプレイヤーtm <= 16 && nプレイヤーxtype != 3)
                        {
                            nプレイヤーb += 240;
                        }
                        if (nプレイヤーtm <= 16 && nプレイヤーxtype == 3)
                        {
                            ma += 240;
                        }
                        if (nプレイヤーtm == 19 && nプレイヤーxtype == 2)
                        {
                            nプレイヤーhp = 0;
                            nプレイヤーtype = 2000;
                            nプレイヤーtm = 0;
                            nメッセージtm = 30;
                            nメッセージtype = 51;
                        }
                        if (nプレイヤーtm == 19 && nプレイヤーxtype == 5)
                        {
                            nプレイヤーhp = 0;
                            nプレイヤーtype = 2000;
                            nプレイヤーtm = 0;
                            nメッセージtm = 30;
                            nメッセージtype = 52;
                        }
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
                }


                if (nプレイヤーtype == 300)
                {
                    nプレイヤーkeytm = 3;
                    if (nプレイヤーtm <= 1)
                    {
                        nプレイヤーc = 0;
                        nプレイヤーd = 0;
                    }
                    if (nプレイヤーtm >= 2 && nプレイヤーtm <= 42)
                    {
                        nプレイヤーd = 600;
                        nプレイヤーmuki = 1;
                    }
                    if (nプレイヤーtm > 43 && nプレイヤーtm <= 108)
                    {
                        nプレイヤーc = 300;
                    }
                    if (nプレイヤーtm == 110)
                    {
                        nプレイヤーb = -80000000;
                        nプレイヤーc = 0;
                    }
                    if (nプレイヤーtm == 250)
                    {
                        nステージb++; nステージc = 0;
                        zxon = 0;
                        n中間ゲート = 0;
                        e現在の画面 = E画面.機数表示;
                        maintm = 0;
                    }
                }//mtype==300

                if (nプレイヤーtype == 301 || nプレイヤーtype == 302)
                {
                    nプレイヤーkeytm = 3;

                    if (nプレイヤーtm <= 1)
                    {
                        nプレイヤーc = 0;
                        nプレイヤーd = 0;
                    }

                    if (nプレイヤーtm >= 2 && (nプレイヤーtype == 301 && nプレイヤーtm <= 102 || nプレイヤーtype == 302 && nプレイヤーtm <= 60))
                    {
                        xx[5] = 500;
                        ma -= xx[5];
                        fx += xx[5];
                        fzx += xx[5];
                    }

                    if ((nプレイヤーtype == 301 || nプレイヤーtype == 302) && nプレイヤーtm >= 2 && nプレイヤーtm <= 100)
                    {
                        nプレイヤーc = 250;
                        nプレイヤーmuki = 1;
                    }

                    if (nプレイヤーtm == 200)
                    {
                        v効果音再生(nオーディオ_[17]);
                        if (nプレイヤーtype == 301)
                        {
                            n背景a[n背景co] = 117 * 29 * 100 - 1100;
                            n背景b[n背景co] = 4 * 29 * 100;
                            n背景type[n背景co] = 101;
                            n背景co++;
                            if (n背景co >= n背景max) n背景co = 0;

                            n背景a[n背景co] = 115 * 29 * 100 - 1100;
                            n背景b[n背景co] = 6 * 29 * 100;
                            n背景type[n背景co] = 102;
                            n背景co++;
                            if (n背景co >= n背景max) n背景co = 0;
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
                            nステージa++;
                            nステージb = 1;
                            nステージc = 0;
                            zxon = 0;
                            n中間ゲート = 0;
                            e現在の画面 = E画面.機数表示;
                            maintm = 0;
                        }
                    }
                }
            }

            //移動
            if (nプレイヤーkeytm >= 1)
            {
                nプレイヤーkeytm--;
            }
            ma += nプレイヤーc;
            nプレイヤーb += nプレイヤーd;

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
        }

        static void DrawPlayer()
        {
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
        }
    }
}

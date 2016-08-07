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

            setcolor(0, 0, 0);
            if (stagecolor == 1) setcolor(160, 180, 250);
            if (stagecolor == 2) setcolor(10, 10, 10);
            if (stagecolor == 3) setcolor(160, 180, 250);
            if (stagecolor == 4) setcolor(10, 10, 10);
            if (stagecolor == 5)
            {
                setcolor(160, 180, 250);
                mrzimen = 1;
            } else {
                mrzimen = 0;
            }

            fillrect(0, 0, n画面幅, n画面高さ);


            if (main == 1 && zxon >= 1)
            {
                //背景
                for (t_ = 0; t_ < nmax; t_++)
                {
                    xx[0] = na[t_] - fx; xx[1] = nb[t_] - fy;
                    xx[2] = n背景サイズW_[ntype[t_]] * 100; xx[3] = n背景サイズH_[ntype[t_]] * 100;
                    xx[2] = 16000; xx[3] = 16000;

                    if (xx[0] + xx[2] >= -10 && xx[0] <= n画面幅 && xx[1] + xx[3] >= -10 && xx[3] <= n画面高さ)
                    {

                        if (ntype[t_] != 3)
                        {
                            if ((ntype[t_] == 1 || ntype[t_] == 2) && stagecolor == 5)
                            {
                                drawimage(n切り取り画像_[ntype[t_] + 30, 4], xx[0] / 100, xx[1] / 100);
                            }
                            else {
                                drawimage(n切り取り画像_[ntype[t_], 4], xx[0] / 100, xx[1] / 100);
                            }
                        }
                        if (ntype[t_] == 3)
                            drawimage(n切り取り画像_[ntype[t_], 4], xx[0] / 100 - 5, xx[1] / 100);

                        //51
                        if (ntype[t_] == 100)
                        {
                            DX.DrawString(xx[0] / 100 + fma, xx[1] / 100 + fmb, "51", DX.GetColor(255, 255, 255));
                        }

                        if (ntype[t_] == 101)
                            DX.DrawString(xx[0] / 100 + fma, xx[1] / 100 + fmb, "ゲームクリアー", DX.GetColor(255, 255, 255));
                        if (ntype[t_] == 102)
                            DX.DrawString(xx[0] / 100 + fma, xx[1] / 100 + fmb, "プレイしてくれてありがとー", DX.GetColor(255, 255, 255));

                    }
                }//t



                //グラ
                for (t_ = 0; t_ < emax; t_++)
                {
                    xx[0] = ea[t_] - fx; xx[1] = eb[t_] - fy;
                    xx[2] = enobia[t_] / 100; xx[3] = enobib[t_] / 100;
                    if (xx[0] + xx[2] * 100 >= -10 && xx[1] <= n画面幅 && xx[1] + xx[3] * 100 >= -10 - 8000 && xx[3] <= n画面高さ)
                    {

                        //コイン
                        if (egtype[t_] == 0)
                            drawimage(n切り取り画像_[0, 2], xx[0] / 100, xx[1] / 100);

                        //ブロックの破片
                        if (egtype[t_] == 1)
                        {
                            if (stagecolor == 1 || stagecolor == 3 || stagecolor == 5) setcolor(9 * 16, 6 * 16, 3 * 16);
                            if (stagecolor == 2) setcolor(0, 120, 160);
                            if (stagecolor == 4) setcolor(192, 192, 192);

                            fillarc(xx[0] / 100, xx[1] / 100, 7, 7);
                            setcolor(0, 0, 0);
                            drawarc(xx[0] / 100, xx[1] / 100, 7, 7);
                        }

                        //リフトの破片
                        if (egtype[t_] == 2 || egtype[t_] == 3)
                        {
                            if (egtype[t_] == 3) mirror = 1;
                            drawimage(n切り取り画像_[0, 5], xx[0] / 100, xx[1] / 100);
                            mirror = 0;
                        }

                        //ポール
                        if (egtype[t_] == 4)
                        {
                            setc1();
                            fillrect((xx[0]) / 100 + 10, (xx[1]) / 100, 10, xx[3]);
                            setc0();
                            drawrect((xx[0]) / 100 + 10, (xx[1]) / 100, 10, xx[3]);
                            setcolor(250, 250, 0);
                            fillarc((xx[0]) / 100 + 15 - 1, (xx[1]) / 100, 10, 10);
                            setc0();
                            drawarc((xx[0]) / 100 + 15 - 1, (xx[1]) / 100, 10, 10);
                        }


                    }
                }

                //リフト
                for (t_ = 0; t_ < srmax; t_++)
                {
                    xx[0] = sra[t_] - fx; xx[1] = srb[t_] - fy;
                    if (xx[0] + src[t_] >= -10 && xx[1] <= n画面幅 + 12100 && src[t_] / 100 >= 1)
                    {
                        xx[2] = 14; if (srsp[t_] == 1) { xx[2] = 12; }

                        if (srsp[t_] <= 9 || srsp[t_] >= 20)
                        {
                            setcolor(220, 220, 0);
                            if (srsp[t_] == 2 || srsp[t_] == 3) { setcolor(0, 220, 0); }
                            if (srsp[t_] == 21) { setcolor(180, 180, 180); }
                            fillrect((sra[t_] - fx) / 100, (srb[t_] - fy) / 100, src[t_] / 100, xx[2]);

                            setcolor(180, 180, 0);
                            if (srsp[t_] == 2 || srsp[t_] == 3) { setcolor(0, 180, 0); }
                            if (srsp[t_] == 21) { setcolor(150, 150, 150); }
                            drawrect((sra[t_] - fx) / 100, (srb[t_] - fy) / 100, src[t_] / 100, xx[2]);
                        }
                        else if (srsp[t_] <= 14)
                        {
                            if (src[t_] >= 5000)
                            {
                                setcolor(0, 200, 0);
                                fillrect((sra[t_] - fx) / 100, (srb[t_] - fy) / 100, src[t_] / 100, 30);
                                setcolor(0, 160, 0);
                                drawrect((sra[t_] - fx) / 100, (srb[t_] - fy) / 100, src[t_] / 100, 30);

                                setcolor(180, 120, 60);
                                fillrect((sra[t_] - fx) / 100 + 20, (srb[t_] - fy) / 100 + 30, src[t_] / 100 - 40, 480);
                                setcolor(100, 80, 20);
                                drawrect((sra[t_] - fx) / 100 + 20, (srb[t_] - fy) / 100 + 30, src[t_] / 100 - 40, 480);

                            }
                        }
                        if (srsp[t_] == 15)
                        {
                            for (t2 = 0; t2 <= 2; t2++)
                            {
                                xx[6] = 1 + 0; drawimage(n切り取り画像_[xx[6], 1], (sra[t_] - fx) / 100 + t2 * 29, (srb[t_] - fy) / 100);
                            }
                        }//15
                    }
                }//t


                //プレイヤー描画
                setcolor(0, 0, 255);
                //mirror=1;

                if (mactp >= 2000) { mactp -= 2000; if (mact == 0) { mact = 1; } else { mact = 0; } }
                if (mmuki == 0) mirror = 1;

                if (mtype != 200 && mtype != 1)
                {
                    if (mzimen == 1)
                    {
                        // 読みこんだグラフィックを拡大描画
                        if (mact == 0) drawimage(n切り取り画像_[0, 0], ma / 100, mb / 100);
                        if (mact == 1) drawimage(n切り取り画像_[1, 0], ma / 100, mb / 100);
                    }
                    if (mzimen == 0)
                    {
                        drawimage(n切り取り画像_[2, 0], ma / 100, mb / 100);
                    }
                }
                //巨大化
                else if (mtype == 1)
                {
                    drawimage(n切り取り画像_[41, 0], ma / 100, mb / 100);
                }

                else if (mtype == 200)
                {
                    drawimage(n切り取り画像_[3, 0], ma / 100, mb / 100);
                }

                mirror = 0;
                //敵キャラ
                for (t_ = 0; t_ < amax; t_++)
                {

                    xx[0] = aa[t_] - fx; xx[1] = ab[t_] - fy;
                    xx[2] = anobia[t_] / 100; xx[3] = anobib[t_] / 100; xx[14] = 3000; xx[16] = 0;
                    if (xx[0] + xx[2] * 100 >= -10 - xx[14] && xx[1] <= n画面幅 + xx[14] && xx[1] + xx[3] * 100 >= -10 && xx[3] <= n画面高さ)
                    {
                        if (amuki[t_] == 1) { mirror = 1; }
                        if (atype[t_] == 3 && axtype[t_] == 1) { DX.DrawRotaGraph(xx[0] / 100 + 13, xx[1] / 100 + 15, 1.0f, pai / 1, n切り取り画像_[atype[t_], 3], DX.TRUE); xx[16] = 1; }
                        if (atype[t_] == 9 && ad[t_] >= 1) { DX.DrawRotaGraph(xx[0] / 100 + 13, xx[1] / 100 + 15, 1.0f, pai / 1, n切り取り画像_[atype[t_], 3], DX.TRUE); xx[16] = 1; }
                        if (atype[t_] >= 100 && amuki[t_] == 1) mirror = 0;

                        //メイン
                        if (atype[t_] < 200 && xx[16] == 0 && atype[t_] != 6 && atype[t_] != 79 && atype[t_] != 86 && atype[t_] != 30)
                        {
                            if (!((atype[t_] == 80 || atype[t_] == 81) && axtype[t_] == 1))
                            {
                                drawimage(n切り取り画像_[atype[t_], 3], xx[0] / 100, xx[1] / 100);
                            }
                        }


                        //デフラグさん
                        if (atype[t_] == 6)
                        {
                            if (atm[t_] >= 10 && atm[t_] <= 19 || atm[t_] >= 100 && atm[t_] <= 119 || atm[t_] >= 200)
                            {
                                drawimage(n切り取り画像_[150, 3], xx[0] / 100, xx[1] / 100);
                            }
                            else {
                                drawimage(n切り取り画像_[6, 3], xx[0] / 100, xx[1] / 100);
                            }
                        }

                        //モララー
                        if (atype[t_] == 30)
                        {
                            if (axtype[t_] == 0) drawimage(n切り取り画像_[30, 3], xx[0] / 100, xx[1] / 100);
                            if (axtype[t_] == 1) drawimage(n切り取り画像_[155, 3], xx[0] / 100, xx[1] / 100);
                        }



                        //ステルス雲
                        if ((atype[t_] == 81) && axtype[t_] == 1)
                        {
                            drawimage(n切り取り画像_[130, 3], xx[0] / 100, xx[1] / 100);
                        }

                        if (atype[t_] == 79)
                        {
                            setcolor(250, 250, 0);
                            fillrect(xx[0] / 100, xx[1] / 100, xx[2], xx[3]);
                            setc0();
                            drawrect(xx[0] / 100, xx[1] / 100, xx[2], xx[3]);
                        }

                        if (atype[t_] == 82)
                        {

                            if (axtype[t_] == 0)
                            {
                                xx[9] = 0; if (stagecolor == 2) { xx[9] = 30; }
                                if (stagecolor == 4) { xx[9] = 60; }
                                if (stagecolor == 5) { xx[9] = 90; }
                                xx[6] = 5 + xx[9]; drawimage(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                            if (axtype[t_] == 1)
                            {
                                xx[9] = 0; if (stagecolor == 2) { xx[9] = 30; }
                                if (stagecolor == 4) { xx[9] = 60; }
                                if (stagecolor == 5) { xx[9] = 90; }
                                xx[6] = 4 + xx[9]; drawimage(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                            if (axtype[t_] == 2)
                            {
                                drawimage(n切り取り画像_[1, 5], xx[0] / 100, xx[1] / 100);
                            }

                        }
                        if (atype[t_] == 83)
                        {

                            if (axtype[t_] == 0)
                            {
                                xx[9] = 0; if (stagecolor == 2) { xx[9] = 30; }
                                if (stagecolor == 4) { xx[9] = 60; }
                                if (stagecolor == 5) { xx[9] = 90; }
                                xx[6] = 5 + xx[9]; drawimage(n切り取り画像_[xx[6], 1], xx[0] / 100 + 10, xx[1] / 100 + 9);
                            }

                            if (axtype[t_] == 1)
                            {
                                xx[9] = 0; if (stagecolor == 2) { xx[9] = 30; }
                                if (stagecolor == 4) { xx[9] = 60; }
                                if (stagecolor == 5) { xx[9] = 90; }
                                xx[6] = 4 + xx[9]; drawimage(n切り取り画像_[xx[6], 1], xx[0] / 100 + 10, xx[1] / 100 + 9);
                            }

                        }

                        //偽ポール
                        if (atype[t_] == 85)
                        {
                            setc1();
                            fillrect((xx[0]) / 100 + 10, (xx[1]) / 100, 10, xx[3]);
                            setc0();
                            drawrect((xx[0]) / 100 + 10, (xx[1]) / 100, 10, xx[3]);
                            setcolor(0, 250, 200);
                            fillarc((xx[0]) / 100 + 15 - 1, (xx[1]) / 100, 10, 10);
                            setc0();
                            drawarc((xx[0]) / 100 + 15 - 1, (xx[1]) / 100, 10, 10);

                        }//85


                        //ニャッスン
                        if (atype[t_] == 86)
                        {
                            if (ma >= aa[t_] - fx - mnobia - 4000 && ma <= aa[t_] - fx + anobia[t_] + 4000)
                            {
                                drawimage(n切り取り画像_[152, 3], xx[0] / 100, xx[1] / 100);
                            }
                            else {
                                drawimage(n切り取り画像_[86, 3], xx[0] / 100, xx[1] / 100);
                            }
                        }




                        if (atype[t_] == 200)
                            drawimage(n切り取り画像_[0, 3], xx[0] / 100, xx[1] / 100);


                        mirror = 0;

                    }
                }



                //ブロック描画
                for (t_ = 0; t_ < tmax; t_++)
                {
                    xx[0] = ta[t_] - fx; xx[1] = tb[t_] - fy;
                    xx[2] = 32; xx[3] = xx[2];
                    if (xx[0] + xx[2] * 100 >= -10 && xx[1] <= n画面幅)
                    {

                        xx[9] = 0;
                        if (stagecolor == 2) { xx[9] = 30; }
                        if (stagecolor == 4) { xx[9] = 60; }
                        if (stagecolor == 5) { xx[9] = 90; }

                        if (ttype[t_] < 100)
                        {
                            xx[6] = ttype[t_] + xx[9]; drawimage(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                        }

                        if (txtype[t_] != 10)
                        {

                            if (ttype[t_] == 100 || ttype[t_] == 101 || ttype[t_] == 102 || ttype[t_] == 103 || ttype[t_] == 104 && txtype[t_] == 1 || ttype[t_] == 114 && txtype[t_] == 1 || ttype[t_] == 116)
                            {
                                xx[6] = 2 + xx[9]; drawimage(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                            if (ttype[t_] == 112 || ttype[t_] == 104 && txtype[t_] == 0 || ttype[t_] == 115 && txtype[t_] == 1)
                            {
                                xx[6] = 1 + xx[9]; drawimage(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                            if (ttype[t_] == 111 || ttype[t_] == 113 || ttype[t_] == 115 && txtype[t_] == 0 || ttype[t_] == 124)
                            {
                                xx[6] = 3 + xx[9]; drawimage(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                            }

                        }

                        if (ttype[t_] == 117 && txtype[t_] == 1)
                        {
                            drawimage(n切り取り画像_[4, 5], xx[0] / 100, xx[1] / 100);
                        }

                        if (ttype[t_] == 117 && txtype[t_] >= 3)
                        {
                            drawimage(n切り取り画像_[3, 5], xx[0] / 100, xx[1] / 100);
                        }

                        if (ttype[t_] == 115 && txtype[t_] == 3)
                        {
                            xx[6] = 1 + xx[9]; drawimage(n切り取り画像_[xx[6], 1], xx[0] / 100, xx[1] / 100);
                        }

                        //ジャンプ台
                        if (ttype[t_] == 120 && txtype[t_] != 1)
                        {
                            drawimage(n切り取り画像_[16, 1], xx[0] / 100 + 3, xx[1] / 100 + 2);
                        }

                        //ON-OFF
                        if (ttype[t_] == 130) drawimage(n切り取り画像_[10, 5], xx[0] / 100, xx[1] / 100);
                        if (ttype[t_] == 131) drawimage(n切り取り画像_[11, 5], xx[0] / 100, xx[1] / 100);

                        if (ttype[t_] == 140) drawimage(n切り取り画像_[12, 5], xx[0] / 100, xx[1] / 100);
                        if (ttype[t_] == 141) drawimage(n切り取り画像_[13, 5], xx[0] / 100, xx[1] / 100);
                        if (ttype[t_] == 142) drawimage(n切り取り画像_[14, 5], xx[0] / 100, xx[1] / 100);


                        if (ttype[t_] == 300 || ttype[t_] == 301)
                            drawimage(n切り取り画像_[1, 5], xx[0] / 100, xx[1] / 100);

                        //Pスイッチ
                        if (ttype[t_] == 400) { drawimage(n切り取り画像_[2, 5], xx[0] / 100, xx[1] / 100); }

                        //コイン
                        if (ttype[t_] == 800) { drawimage(n切り取り画像_[0, 2], xx[0] / 100 + 2, xx[1] / 100 + 1); }

                    }
                }


                //地面(壁)//土管も
                for (t_ = 0; t_ < smax; t_++)
                {
                    if (sa[t_] - fx + sc[t_] >= -10 && sa[t_] - fx <= n画面幅 + 1100)
                    {

                        if (stype[t_] == 0)
                        {
                            setcolor(40, 200, 40);
                            fillrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb, sc[t_] / 100, sd[t_] / 100);
                            drawrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb, sc[t_] / 100, sd[t_] / 100);
                        }
                        //土管
                        if (stype[t_] == 1)
                        {
                            setcolor(0, 230, 0);
                            fillrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb, sc[t_] / 100, sd[t_] / 100);
                            setc0();
                            drawrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb, sc[t_] / 100, sd[t_] / 100);
                        }
                        //土管(下)
                        if (stype[t_] == 2)
                        {
                            setcolor(0, 230, 0);
                            fillrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb + 1, sc[t_] / 100, sd[t_] / 100);
                            setc0();
                            drawline((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb, (sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb + sd[t_] / 100);
                            drawline((sa[t_] - fx) / 100 + fma + sc[t_] / 100, (sb[t_] - fy) / 100 + fmb, (sa[t_] - fx) / 100 + fma + sc[t_] / 100, (sb[t_] - fy) / 100 + fmb + sd[t_] / 100);
                        }

                        //土管(横)
                        if (stype[t_] == 5)
                        {
                            setcolor(0, 230, 0);
                            fillrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb + 1, sc[t_] / 100, sd[t_] / 100);
                            setc0();
                            drawline((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb, (sa[t_] - fx) / 100 + fma + sc[t_] / 100, (sb[t_] - fy) / 100 + fmb);
                            drawline((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb + sd[t_] / 100, (sa[t_] - fx) / 100 + fma + sc[t_] / 100, (sb[t_] - fy) / 100 + fmb + sd[t_] / 100);
                        }


                        //落ちてくるブロック
                        if (stype[t_] == 51)
                        {
                            if (sxtype[t_] == 0)
                            {
                                for (t3 = 0; t3 <= sc[t_] / 3000; t3++)
                                {
                                    drawimage(n切り取り画像_[1, 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + fmb);
                                }
                            }
                            if (sxtype[t_] == 1 || sxtype[t_] == 2)
                            {
                                for (t3 = 0; t3 <= sc[t_] / 3000; t3++)
                                {
                                    drawimage(n切り取り画像_[31, 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + fmb);
                                }
                            }
                            if (sxtype[t_] == 3 || sxtype[t_] == 4)
                            {
                                for (t3 = 0; t3 <= sc[t_] / 3000; t3++)
                                {
                                    for (t2 = 0; t2 <= sd[t_] / 3000; t2++)
                                    {
                                        drawimage(n切り取り画像_[65, 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + 29 * t2 + fmb);
                                    }
                                }
                            }

                            if (sxtype[t_] == 10)
                            {
                                for (t3 = 0; t3 <= sc[t_] / 3000; t3++)
                                {
                                    drawimage(n切り取り画像_[65, 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + fmb);
                                }
                            }

                        }//51


                        //落ちるやつ
                        if (stype[t_] == 52)
                        {
                            xx[29] = 0; if (stagecolor == 2) { xx[29] = 30; }
                            if (stagecolor == 4) { xx[29] = 60; }
                            if (stagecolor == 5) { xx[29] = 90; }

                            for (t3 = 0; t3 <= sc[t_] / 3000; t3++)
                            {
                                if (sxtype[t_] == 0)
                                {
                                    drawimage(n切り取り画像_[5 + xx[29], 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + fmb);
                                    if (stagecolor != 4) { drawimage(n切り取り画像_[6 + xx[29], 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + fmb + 29); }
                                    else { drawimage(n切り取り画像_[5 + xx[29], 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + fmb + 29); }
                                }
                                if (sxtype[t_] == 1)
                                {
                                    for (t2 = 0; t2 <= sd[t_] / 3000; t2++)
                                    {
                                        drawimage(n切り取り画像_[1 + xx[29], 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + fmb + 29 * t2);
                                    }
                                }

                                if (sxtype[t_] == 2)
                                {
                                    for (t2 = 0; t2 <= sd[t_] / 3000; t2++)
                                    {
                                        drawimage(n切り取り画像_[5 + xx[29], 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + fmb + 29 * t2);
                                    }
                                }

                            }
                        }


                        //ステージトラップ
                        if (trap == 1)
                        {
                            if (stype[t_] >= 100 && stype[t_] <= 299)
                            {
                                if (stagecolor == 1 || stagecolor == 3 || stagecolor == 5) setc0();
                                if (stagecolor == 2 || stagecolor == 4) setc1();
                                drawrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb, sc[t_] / 100, sd[t_] / 100);
                            }
                        }

                        //ゴール
                        if (stype[t_] == 300)
                        {
                            setc1();
                            fillrect((sa[t_] - fx) / 100 + 10, (sb[t_] - fy) / 100, 10, sd[t_] / 100 - 8);
                            setc0();
                            drawrect((sa[t_] - fx) / 100 + 10, (sb[t_] - fy) / 100, 10, sd[t_] / 100 - 8);
                            setcolor(250, 250, 0);
                            fillarc((sa[t_] - fx) / 100 + 15 - 1, (sb[t_] - fy) / 100, 10, 10);
                            setc0();
                            drawarc((sa[t_] - fx) / 100 + 15 - 1, (sb[t_] - fy) / 100, 10, 10);
                        }

                        //中間
                        if (stype[t_] == 500)
                        {
                            drawimage(n切り取り画像_[20, 4], (sa[t_] - fx) / 100, (sb[t_] - fy) / 100);
                        }
                    }
                }//t


                //描画上書き(土管)
                for (t_ = 0; t_ < smax; t_++)
                {
                    if (sa[t_] - fx + sc[t_] >= -10 && sa[t_] - fx <= n画面幅 + 1100)
                    {

                        //入る土管(右)
                        if (stype[t_] == 40)
                        {
                            setcolor(0, 230, 0);
                            fillrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb + 1, sc[t_] / 100, sd[t_] / 100);
                            setc0();
                            drawrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb + 1, sc[t_] / 100, sd[t_] / 100);
                        }

                        //とぶ土管
                        if (stype[t_] == 50)
                        {
                            setcolor(0, 230, 0);
                            fillrect((sa[t_] - fx) / 100 + fma + 5, (sb[t_] - fy) / 100 + fmb + 30, 50, sd[t_] / 100 - 30);
                            setc0();
                            drawline((sa[t_] - fx) / 100 + 5 + fma, (sb[t_] - fy) / 100 + fmb + 30, (sa[t_] - fx) / 100 + fma + 5, (sb[t_] - fy) / 100 + fmb + sd[t_] / 100);
                            drawline((sa[t_] - fx) / 100 + 5 + fma + 50, (sb[t_] - fy) / 100 + fmb + 30, (sa[t_] - fx) / 100 + fma + 50 + 5, (sb[t_] - fy) / 100 + fmb + sd[t_] / 100);

                            setcolor(0, 230, 0);
                            fillrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb + 1, 60, 30);
                            setc0();
                            drawrect((sa[t_] - fx) / 100 + fma, (sb[t_] - fy) / 100 + fmb + 1, 60, 30);
                        }

                        //地面(ブロック)
                        if (stype[t_] == 200)
                        {
                            for (t3 = 0; t3 <= sc[t_] / 3000; t3++)
                            {
                                for (t2 = 0; t2 <= sd[t_] / 3000; t2++)
                                {
                                    drawimage(n切り取り画像_[65, 1], (sa[t_] - fx) / 100 + fma + 29 * t3, (sb[t_] - fy) / 100 + 29 * t2 + fmb);
                                }
                            }
                        }

                    }
                }//t





                //ファイアバー
                for (t_ = 0; t_ < amax; t_++)
                {

                    xx[0] = aa[t_] - fx; xx[1] = ab[t_] - fy;
                    //xx[2]=anobia[t]/100;xx[3]=anobib[t]/100;
                    xx[14] = 12000; xx[16] = 0;
                    if (atype[t_] == 87 || atype[t_] == 88)
                    {
                        if (xx[0] + xx[2] * 100 >= -10 - xx[14] && xx[1] <= n画面幅 + xx[14] && xx[1] + xx[3] * 100 >= -10 && xx[3] <= n画面高さ)
                        {

                            for (tt_ = 0; tt_ <= axtype[t_] % 100; tt_++)
                            {
                                xx[26] = 18;
                                xd[4] = tt_ * xx[26] * Math.Cos(atm[t_] * pai / 180 / 2);
                                xd[5] = tt_ * xx[26] * Math.Sin(atm[t_] * pai / 180 / 2);
                                xx[24] = (int)xd[4];
                                xx[25] = (int)xd[5];
                                setcolor(230, 120, 0);
                                xx[23] = 8;
                                if (atype[t_] == 87)
                                {
                                    fillarc(xx[0] / 100 + xx[24], xx[1] / 100 + xx[25], xx[23], xx[23]);
                                    setcolor(0, 0, 0);
                                    drawarc(xx[0] / 100 + xx[24], xx[1] / 100 + xx[25], xx[23], xx[23]);
                                }
                                else {
                                    fillarc(xx[0] / 100 - xx[24], xx[1] / 100 + xx[25], xx[23], xx[23]);
                                    setcolor(0, 0, 0);
                                    drawarc(xx[0] / 100 - xx[24], xx[1] / 100 + xx[25], xx[23], xx[23]);
                                }
                            }

                        }
                    }
                }


                //プレイヤーのメッセージ
                setc0();
                if (mmsgtm >= 1)
                {
                    mmsgtm--;
                    xs[0] = "";

                    if (mmsgtype == 1) xs[0] = "お、おいしい!!";
                    if (mmsgtype == 2) xs[0] = "毒は無いが……";
                    if (mmsgtype == 3) xs[0] = "刺さった!!";
                    if (mmsgtype == 10) xs[0] = "食べるべきではなかった!!";
                    if (mmsgtype == 11) xs[0] = "俺は燃える男だ!!";
                    if (mmsgtype == 50) xs[0] = "体が……焼ける……";
                    if (mmsgtype == 51) xs[0] = "たーまやー!!";
                    if (mmsgtype == 52) xs[0] = "見事にオワタ";
                    if (mmsgtype == 53) xs[0] = "足が、足がぁ!!";
                    if (mmsgtype == 54) xs[0] = "流石は摂氏800度!!";
                    if (mmsgtype == 55) xs[0] = "溶岩と合体したい……";

                    setc0();
                    str(xs[0], (ma + mnobia + 300) / 100 - 1, mb / 100 - 1);
                    str(xs[0], (ma + mnobia + 300) / 100 + 1, mb / 100 + 1);
                    setc1();
                    str(xs[0], (ma + mnobia + 300) / 100, mb / 100);

                }//mmsgtm


                //敵キャラのメッセージ
                setc0();
                for (t_ = 0; t_ < amax; t_++)
                {
                    if (amsgtm[t_] >= 1)
                    {
                        amsgtm[t_]--;

                        xs[0] = "";

                        if (amsgtype[t_] == 1001) xs[0] = "ヤッフー!!";
                        if (amsgtype[t_] == 1002) xs[0] = "え?俺勝っちゃったの?";
                        if (amsgtype[t_] == 1003) xs[0] = "貴様の死に場所はここだ!";
                        if (amsgtype[t_] == 1004) xs[0] = "二度と会う事もないだろう";
                        if (amsgtype[t_] == 1005) xs[0] = "俺、最強!!";
                        if (amsgtype[t_] == 1006) xs[0] = "一昨日来やがれ!!";
                        if (amsgtype[t_] == 1007) xs[0] = "漢に後退の二文字は無い!!";
                        if (amsgtype[t_] == 1008) xs[0] = "ハッハァ!!";

                        if (amsgtype[t_] == 1011) xs[0] = "ヤッフー!!";
                        if (amsgtype[t_] == 1012) xs[0] = "え?俺勝っちゃったの?";
                        if (amsgtype[t_] == 1013) xs[0] = "貴様の死に場所はここだ!";
                        if (amsgtype[t_] == 1014) xs[0] = "身の程知らずが……";
                        if (amsgtype[t_] == 1015) xs[0] = "油断が死を招く";
                        if (amsgtype[t_] == 1016) xs[0] = "おめでたい奴だ";
                        if (amsgtype[t_] == 1017) xs[0] = "屑が!!";
                        if (amsgtype[t_] == 1018) xs[0] = "無謀な……";

                        if (amsgtype[t_] == 1021) xs[0] = "ヤッフー!!";
                        if (amsgtype[t_] == 1022) xs[0] = "え?俺勝っちゃったの?";
                        if (amsgtype[t_] == 1023) xs[0] = "二度と会う事もないだろう";
                        if (amsgtype[t_] == 1024) xs[0] = "身の程知らずが……";
                        if (amsgtype[t_] == 1025) xs[0] = "僕は……負けない!!";
                        if (amsgtype[t_] == 1026) xs[0] = "貴様に見切れる筋は無い";
                        if (amsgtype[t_] == 1027) xs[0] = "今死ね、すぐ死ね、骨まで砕けろ!!";
                        if (amsgtype[t_] == 1028) xs[0] = "任務完了!!";

                        if (amsgtype[t_] == 1031) xs[0] = "ヤッフー!!";
                        if (amsgtype[t_] == 1032) xs[0] = "え?俺勝っちゃったの?";
                        if (amsgtype[t_] == 1033) xs[0] = "貴様の死に場所はここだ!";
                        if (amsgtype[t_] == 1034) xs[0] = "身の程知らずが……";
                        if (amsgtype[t_] == 1035) xs[0] = "油断が死を招く";
                        if (amsgtype[t_] == 1036) xs[0] = "おめでたい奴だ";
                        if (amsgtype[t_] == 1037) xs[0] = "屑が!!";
                        if (amsgtype[t_] == 1038) xs[0] = "無謀な……";

                        if (amsgtype[t_] == 15) xs[0] = "鉄壁!!よって、無敵!!";
                        if (amsgtype[t_] == 16) xs[0] = "丸腰で勝てるとでも?";
                        if (amsgtype[t_] == 17) xs[0] = "パリイ!!";
                        if (amsgtype[t_] == 18) xs[0] = "自業自得だ";
                        if (amsgtype[t_] == 20) xs[0] = "Zzz";
                        if (amsgtype[t_] == 21) xs[0] = "ク、クマー";
                        if (amsgtype[t_] == 24) xs[0] = "?";
                        if (amsgtype[t_] == 25) xs[0] = "食べるべきではなかった!!";
                        if (amsgtype[t_] == 30) xs[0] = "うめぇ!!";
                        if (amsgtype[t_] == 31) xs[0] = "ブロックを侮ったな?";
                        if (amsgtype[t_] == 32) xs[0] = "シャキーン";

                        if (amsgtype[t_] == 50) xs[0] = "波動砲!!";
                        if (amsgtype[t_] == 85) xs[0] = "裏切られたとでも思ったか?";
                        if (amsgtype[t_] == 86) xs[0] = "ポールアターック!!";



                        //if (stagecolor<=1 || stagecolor==3)setc0();
                        //if (stagecolor==2)setc1();

                        if (amsgtype[t_] != 31)
                        {
                            //str(xs[0],(aa[t]+anobia[t]+300-fx)/100,(ab[t]-fy)/100);
                            xx[5] = (aa[t_] + anobia[t_] + 300 - fx) / 100; xx[6] = (ab[t_] - fy) / 100;
                        }
                        else {
                            xx[5] = (aa[t_] + anobia[t_] + 300 - fx) / 100; xx[6] = (ab[t_] - fy - 800) / 100;
                        }

                        //setc0();
                        //str(xs[0],xx[5]-1,xx[6]-1);str(xs[0],xx[5]+1,xx[6]+1);
                        DX.ChangeFontType(DX.DX_FONTTYPE_EDGE);
                        setc1();
                        str(xs[0], xx[5], xx[6]);
                        DX.ChangeFontType(DX.DX_FONTTYPE_NORMAL);


                    }//amsgtm
                }//amax



                //メッセージブロック
                if (tmsgtm > 0)
                {
                    ttmsg();
                    if (tmsgtype == 1)
                    {
                        xx[0] = 1200;
                        tmsgy += xx[0];
                        if (tmsgtm == 1) { tmsgtm = 80000000; tmsgtype = 2; }
                    }//1

                    else if (tmsgtype == 2)
                    {
                        tmsgy = 0; tmsgtype = 3; tmsgtm = 15 + 1;
                    }

                    else if (tmsgtype == 3)
                    {
                        xx[0] = 1200;
                        tmsgy += xx[0];
                        if (tmsgtm == 15) DX.WaitKey();
                        if (tmsgtm == 1) { tmsgtm = 0; tmsgtype = 0; tmsgy = 0; }
                    }//1

                    tmsgtm--;
                }//tmsgtm


                //メッセージ
                if (mainmsgtype >= 1)
                {
                    setfont(20, 4);
                    if (mainmsgtype == 1) { DX.DrawString(126, 100, "WELCOME TO OWATA ZONE", DX.GetColor(255, 255, 255)); }
                    if (mainmsgtype == 1) { for (t2 = 0; t2 <= 2; t2++) DX.DrawString(88 + t2 * 143, 210, "1", DX.GetColor(255, 255, 255)); }
                    setfont(20, 5);
                }//mainmsgtype>=1


                //画面黒
                if (blacktm > 0)
                {
                    blacktm--;
                    fillrect(0, 0, n画面幅, n画面高さ);
                    if (blacktm == 0)
                    {
                        if (blackx == 1) { zxon = 0; }
                    }

                }//blacktm


            }//if (main==1){


            if (main == 2)
            {

                setcolor(255, 255, 255);
                str("制作・プレイに関わった方々", 240 - 13 * 20 / 2, xx[12] / 100);
                str("ステージ１　プレイ", 240 - 9 * 20 / 2, xx[13] / 100);
                str("先輩　Ⅹ～Ｚ", 240 - 6 * 20 / 2, xx[14] / 100);
                str("ステージ２　プレイ", 240 - 9 * 20 / 2, xx[15] / 100);
                str("友人　willowlet ", 240 - 8 * 20 / 2, xx[16] / 100);
                str("ステージ３　プレイ", 240 - 9 * 20 / 2, xx[17] / 100);
                str("友人　willowlet ", 240 - 8 * 20 / 2, xx[18] / 100);
                str("ステージ４　プレイ", 240 - 9 * 20 / 2, xx[19] / 100);
                str("友人２　ann ", 240 - 6 * 20 / 2, xx[20] / 100);
                str("ご協力", 240 - 3 * 20 / 2, xx[21] / 100);
                str("Ｔ先輩", 240 - 3 * 20 / 2, xx[22] / 100);
                str("Ｓ先輩", 240 - 3 * 20 / 2, xx[23] / 100);
                str("動画技術提供", 240 - 6 * 20 / 2, xx[24] / 100);
                str("Ｋ先輩", 240 - 3 * 20 / 2, xx[25] / 100);
                str("動画キャプチャ・編集・エンコード", 240 - 16 * 20 / 2, xx[26] / 100);
                str("willowlet ", 240 - 5 * 20 / 2, xx[27] / 100);
                str("プログラム・描画・ネタ・動画編集", 240 - 16 * 20 / 2, xx[28] / 100);
                str("ちく", 240 - 2 * 20 / 2, xx[29] / 100);

                str("プレイしていただき　ありがとうございました～", 240 - 22 * 20 / 2, xx[30] / 100);
            }



            if (main == 10)
            {

                setc0();
                fillrect(0, 0, n画面幅, n画面高さ);

                DX.SetFontSize(16);
                DX.SetFontThickness(4);

                drawimage(n切り取り画像_[0, 0], 190, 190);
                DX.DrawString(230, 200, " × " + nokori, DX.GetColor(255, 255, 255));


            }


            //タイトル
            if (main == 100)
            {

                setcolor(160, 180, 250);
                fillrect(0, 0, n画面幅, n画面高さ);

                drawimage(n元画像_[30], 240 - 380 / 2, 60);

                drawimage(n切り取り画像_[0, 4], 12 * 30, 10 * 29 - 12);
                drawimage(n切り取り画像_[1, 4], 6 * 30, 12 * 29 - 12);

                //プレイヤー
                drawimage(n切り取り画像_[0, 0], 2 * 30, 12 * 29 - 12 - 6);
                for (t_ = 0; t_ <= 16; t_++)
                {
                    drawimage(n切り取り画像_[5, 1], 29 * t_, 13 * 29 - 12);
                    drawimage(n切り取り画像_[6, 1], 29 * t_, 14 * 29 - 12);
                }


                setcolor(0, 0, 0);
                str("Enterキーを押せ!!", 240 - 8 * 20 / 2, 250);

            }//if (main==100){




            DX.ScreenFlip();

        }//rpaint()

        static void Mainprogram()
        {
            stime = DX.GetNowCount();


            if (ending == 1) main = 2;


            //キー
            key = DX.GetJoypadInputState(DX.DX_INPUT_KEY_PAD1);


            if (main == 1 && tmsgtype == 0)
            {


                if (zxon == 0)
                {
                    zxon = 1;
                    mainmsgtype = 0;

                    stagecolor = 1;
                    ma = 5600; mb = 32000; mmuki = 1; mhp = 1;
                    mc = 0; md = 0;
                    mnobia = 3000; mnobib = 3600;

                    mtype = 0;
                    //if (stc==1)end();

                    fx = 0; fy = 0;
                    fzx = 0;
                    stageonoff = 0;




                    //チーターマン　入れ
                    bgmchange(nオーディオ_[100]);

                    stagecls();

                    stage();


                    //ランダムにさせる
                    if (over == 1)
                    {
                        for (t_ = 0; t_ < tmax; t_++) { if (rand(3) <= 1) { ta[t_] = (rand(500) - 1) * 29 * 100; tb[t_] = rand(14) * 100 * 29 - 1200; ttype[t_] = rand(142); if (ttype[t_] >= 9 && ttype[t_] <= 99) { ttype[t_] = rand(8); } txtype[t_] = rand(4); } }
                        for (t_ = 0; t_ < bmax; t_++) { if (rand(2) <= 1) { ba[t_] = (rand(500) - 1) * 29 * 100; bb[t_] = rand(15) * 100 * 29 - 1200 - 3000; if (rand(6) == 0) { btype[t_] = rand(9); } } }

                        srco = 0;
                        t_ = srco; sra[t_] = ma + fx; srb[t_] = (13 * 29 - 12) * 100; src[t_] = 30 * 100; srtype[t_] = 0; sracttype[t_] = 0; sre[t_] = 0; srsp[t_] = 0; srco++;

                        if (rand(4) == 0) stagecolor = rand(5);
                    }



                    DX.StopSoundMem(nオーディオ_[0]);


                    //メインBGM
                    DX.PlaySoundMem(nオーディオ_[0], DX.DX_PLAYTYPE_LOOP);


                }//zxon


                //プレイヤーの移動
                xx[0] = 0; actaon[2] = 0; actaon[3] = 0;
                if (mkeytm <= 0)
                {
                    if ((key & DX.PAD_INPUT_LEFT) != DX.FALSE && keytm <= 0) { actaon[0] = -1; mmuki = 0; actaon[4] = -1; }
                    if ((key & DX.PAD_INPUT_RIGHT) != DX.FALSE && keytm <= 0) { actaon[0] = 1; mmuki = 1; actaon[4] = 1; }
                    if ((key & DX.PAD_INPUT_DOWN) != DX.FALSE) { actaon[3] = 1; }
                }

                if (DX.CheckHitKey(DX.KEY_INPUT_F1) == 1) { main = 100; }
                if (DX.CheckHitKey(DX.KEY_INPUT_O) == 1) { if (mhp >= 1) mhp = 0; if (stc >= 5) { stc = 0; stagepoint = 0; } }


                if (mkeytm <= 0)
                {
                    if ((key & DX.PAD_INPUT_UP) == DX.TRUE || DX.CheckHitKey(DX.KEY_INPUT_Z) == 1)
                    {//end();
                        if (actaon[1] == 10) { actaon[1] = 1; xx[0] = 1; }
                        actaon[2] = 1;
                    }
                }

                if ((key & DX.PAD_INPUT_UP) == DX.TRUE || DX.CheckHitKey(DX.KEY_INPUT_Z) == 1)
                {
                    if (mjumptm == 8 && md >= -900)
                    {
                        md = -1300;
                        //ダッシュ中
                        xx[22] = 200; if (mc >= xx[22] || mc <= -xx[22]) { md = -1400; }
                        xx[22] = 600; if (mc >= xx[22] || mc <= -xx[22]) { md = -1500; }
                    }
                    // && xx[0]==0 && md<=-10

                    //if (mjumptm==7 && md>=-900){}
                    if (xx[0] == 0) actaon[1] = 10;
                }





                //加速による移動
                xx[0] = 40; xx[1] = 700; xx[8] = 500; xx[9] = 700;
                xx[12] = 1; xx[13] = 2;

                //すべり補正
                if (mrzimen == 1) { xx[0] = 20; xx[12] = 9; xx[13] = 10; }


                //if (mzimen==0){xx[0]-=15;}
                if (actaon[0] == -1)
                {
                    if (!(mzimen == 0 && mc < -xx[8]))
                    {
                        if (mc >= -xx[9]) { mc -= xx[0]; if (mc < -xx[9]) { mc = -xx[9] - 1; } }
                        if (mc < -xx[9] && atktm <= 0) mc -= xx[0] / 10;
                    }
                    if (mrzimen != 1)
                    {
                        if (mc > 100 && mzimen == 0) { mc -= xx[0] * 2 / 3; }
                        if (mc > 100 && mzimen == 1) { mc -= xx[0]; if (mzimen == 1) { mc -= xx[0] * 1 / 2; } }
                        actaon[0] = 3;
                        mkasok += 1;
                    }
                }

                if (actaon[0] == 1)
                {
                    if (!(mzimen == 0 && mc > xx[8]))
                    {
                        if (mc <= xx[9]) { mc += xx[0]; if (mc > xx[9]) { mc = xx[9] + 1; } }
                        if (mc > xx[9] && atktm <= 0) mc += xx[0] / 10;
                    }
                    if (mrzimen != 1)
                    {
                        if (mc < -100 && mzimen == 0) { mc += xx[0] * 2 / 3; }
                        if (mc < -100 && mzimen == 1) { mc += xx[0]; if (mzimen == 1) { mc += xx[0] * 1 / 2; } }
                        actaon[0] = 3; mkasok += 1;
                    }
                }
                if (actaon[0] == 0 && mkasok > 0) { mkasok -= 2; }
                if (mkasok > 8) { mkasok = 8; }

                //すべり補正初期化
                if (mzimen != 1) mrzimen = 0;


                //ジャンプ
                if (mjumptm >= 0) mjumptm--;
                if (actaon[1] == 1 && mzimen == 1)
                {
                    mb -= 400; md = -1200; mjumptm = 10;

                    ot(nオーディオ_[1]);

                    mzimen = 0;

                }
                if (actaon[1] <= 9) actaon[1] = 0;


                if (mmutekitm >= -1) mmutekitm--;


                //HPがなくなったとき
                if (mhp <= 0 && mhp >= -9)
                {
                    mkeytm = 12; mhp = -20; mtype = 200; mtm = 0; ot(nオーディオ_[12]); DX.StopSoundMem(nオーディオ_[0]); DX.StopSoundMem(nオーディオ_[11]); DX.StopSoundMem(nオーディオ_[16]);
                }//mhp
                if (mtype == 200)
                {
                    if (mtm <= 11) { mc = 0; md = 0; }
                    if (mtm == 12) { md = -1200; }
                    if (mtm >= 12) { mc = 0; }
                    if (mtm >= 100 || fast == 1) { zxon = 0; main = 10; mtm = 0; mkeytm = 0; nokori--; if (fast == 1) mtype = 0; }//mtm>=100
                }//mtype==200




                //音符によるワープ
                if (mtype == 2)
                {
                    mtm++;

                    mkeytm = 2;
                    md = -1500;
                    if (mb <= -6000) { blackx = 1; blacktm = 20; stc += 5; DX.StopSoundMem(nオーディオ_[0]); mtm = 0; mtype = 0; mkeytm = -1; }
                }//2

                //ジャンプ台アウト
                if (mtype == 3)
                {
                    md = -2400;
                    if (mb <= -6000) { mb = -80000000; mhp = 0; }
                }


                //mtypeによる特殊的な移動
                if (mtype >= 100)
                {
                    mtm++;

                    //普通の土管
                    if (mtype == 100)
                    {
                        if (mxtype == 0)
                        {
                            mc = 0; md = 0; t_ = 28;
                            if (mtm <= 16) { mb += 240; mzz = 100; }
                            if (mtm == 17) { mb = -80000000; }
                            if (mtm == 23) { sa[t_] -= 100; }
                            if (mtm >= 44 && mtm <= 60)
                            {
                                if (mtm % 2 == 0) sa[t_] += 200;
                                if (mtm % 2 == 1) sa[t_] -= 200;
                            }
                            if (mtm >= 61 && mtm <= 77)
                            {
                                if (mtm % 2 == 0) sa[t_] += 400;
                                if (mtm % 2 == 1) sa[t_] -= 400;
                            }
                            if (mtm >= 78 && mtm <= 78 + 16)
                            {
                                if (mtm % 2 == 0) sa[t_] += 600;
                                if (mtm % 2 == 1) sa[t_] -= 600;
                            }
                            if (mtm >= 110) { sb[t_] -= mzz; mzz += 80; if (mzz > 1600) mzz = 1600; }
                            if (mtm == 160) { mtype = 0; mhp--; }

                        }

                        //ふっとばし
                        else if (mxtype == 10)
                        {
                            mc = 0; md = 0;
                            if (mtm <= 16) { ma += 240; }//mzz=100;}
                            if (mtm == 16) mb -= 1100;
                            if (mtm == 20) ot(nオーディオ_[10]);

                            if (mtm >= 24) { ma -= 2000; mmuki = 0; }
                            if (mtm >= 48) { mtype = 0; mhp--; }

                        }
                        else {
                            mc = 0; md = 0;
                            if (mtm <= 16 && mxtype != 3) { mb += 240; }//mzz=100;}
                            if (mtm <= 16 && mxtype == 3) { ma += 240; }
                            if (mtm == 19 && mxtype == 2) { mhp = 0; mtype = 2000; mtm = 0; mmsgtm = 30; mmsgtype = 51; }
                            if (mtm == 19 && mxtype == 5) { mhp = 0; mtype = 2000; mtm = 0; mmsgtm = 30; mmsgtype = 52; }
                            if (mtm == 20)
                            {
                                if (mxtype == 6)
                                {
                                    stc += 10;
                                }
                                else {
                                    stc++;
                                }
                                mb = -80000000;
                                mxtype = 0;
                                blackx = 1;
                                blacktm = 20;
                                DX.StopSoundMem(nオーディオ_[0]);
                            }
                        }
                    }//00


                    if (mtype == 300)
                    {
                        mkeytm = 3;
                        if (mtm <= 1) { mc = 0; md = 0; }
                        if (mtm >= 2 && mtm <= 42) { md = 600; mmuki = 1; }
                        if (mtm > 43 && mtm <= 108) { mc = 300; }
                        if (mtm == 110) { mb = -80000000; mc = 0; }
                        if (mtm == 250)
                        {
                            stb++; stc = 0; zxon = 0; tyuukan = 0; main = 10; maintm = 0;
                        }
                    }//mtype==300

                    if (mtype == 301 || mtype == 302)
                    {
                        mkeytm = 3;

                        if (mtm <= 1) { mc = 0; md = 0; }

                        if (mtm >= 2 && (mtype == 301 && mtm <= 102 || mtype == 302 && mtm <= 60))
                        {
                            xx[5] = 500;
                            ma -= xx[5]; fx += xx[5]; fzx += xx[5];
                        }

                        if ((mtype == 301 || mtype == 302) && mtm >= 2 && mtm <= 100)
                        {
                            mc = 250; mmuki = 1;
                        }

                        if (mtm == 200)
                        {
                            ot(nオーディオ_[17]);
                            if (mtype == 301)
                            {
                                na[nco] = 117 * 29 * 100 - 1100; nb[nco] = 4 * 29 * 100; ntype[nco] = 101; nco++; if (nco >= nmax) nco = 0;
                                na[nco] = 115 * 29 * 100 - 1100; nb[nco] = 6 * 29 * 100; ntype[nco] = 102; nco++; if (nco >= nmax) nco = 0;
                            }
                            else {
                                na[nco] = 157 * 29 * 100 - 1100; nb[nco] = 4 * 29 * 100; ntype[nco] = 101; nco++; if (nco >= nmax) nco = 0;
                                na[nco] = 155 * 29 * 100 - 1100; nb[nco] = 6 * 29 * 100; ntype[nco] = 102; nco++; if (nco >= nmax) nco = 0;
                            }
                        }
                        //スタッフロールへ

                        if (mtm == 440)
                        {
                            if (mtype == 301)
                            {
                                ending = 1;
                            }
                            else {
                                sta++; stb = 1; stc = 0; zxon = 0; tyuukan = 0; main = 10; maintm = 0;
                            }
                        }
                    }//mtype==301

                }//mtype>=100




                //移動
                if (mkeytm >= 1) { mkeytm--; }//mc=0;}
                ma += mc; mb += md;
                if (mc < 0) mactp += (-mc);
                if (mc >= 0) mactp += mc;

                if (mtype <= 9 || mtype == 200 || mtype == 300 || mtype == 301 || mtype == 302) md += 100;


                //走る際の最大値
                if (mtype == 0)
                {
                    xx[0] = 800; xx[1] = 1600;
                    if (mc > xx[0] && mc < xx[0] + 200) { mc = xx[0]; }
                    if (mc > xx[0] + 200) { mc -= 200; }
                    if (mc < -xx[0] && mc > -xx[0] - 200) { mc = -xx[0]; }
                    if (mc < -xx[0] - 200) { mc += 200; }
                    if (md > xx[1]) { md = xx[1]; }
                }

                //プレイヤー
                //地面の摩擦
                if (mzimen == 1 && actaon[0] != 3)
                {
                    if ((mtype <= 9) || mtype == 300 || mtype == 301 || mtype == 302)
                    {
                        if (mrzimen == 0)
                        {
                            xx[2] = 30; xx[1] = 60; xx[3] = 30;
                            if (mc >= -xx[3] && mc <= xx[3]) { mc = 0; }
                            if (mc >= xx[2]) { mc -= xx[1]; }
                            if (mc <= -xx[2]) { mc += xx[1]; }
                        }
                        if (mrzimen == 1)
                        {
                            xx[2] = 5; xx[1] = 10; xx[3] = 5;
                            if (mc >= -xx[3] && mc <= xx[3]) { mc = 0; }
                            if (mc >= xx[2]) { mc -= xx[1]; }
                            if (mc <= -xx[2]) { mc += xx[1]; }
                        }
                    }
                }


                //地面判定初期化
                mzimen = 0;

                //場外
                if (mtype <= 9 && mhp >= 1)
                {
                    if (ma < 100) { ma = 100; mc = 0; }
                    if (ma + mnobia > n画面幅) { ma = n画面幅 - mnobia; mc = 0; }
                }
                if (mb >= 38000 && mhp >= 0 && stagecolor == 4) { mhp = -2; mmsgtm = 30; mmsgtype = 55; }
                if (mb >= 52000 && mhp >= 0) { mhp = -2; }






                //ブロック
                //1-れんが、コイン、無し、土台、7-隠し

                xx[15] = 0;
                for (t_ = 0; t_ < tmax; t_++)
                {
                    xx[0] = 200; xx[1] = 3000; xx[2] = 1000; xx[3] = 3000;//xx[2]=1000
                    xx[8] = ta[t_] - fx; xx[9] = tb[t_] - fy;//xx[15]=0;
                    if (ta[t_] - fx + xx[1] >= -10 - xx[3] && ta[t_] - fx <= n画面幅 + 12000 + xx[3])
                    {
                        if (mtype != 200 && mtype != 1 && mtype != 2)
                        {
                            if (ttype[t_] < 1000 && ttype[t_] != 800 && ttype[t_] != 140 && ttype[t_] != 141)
                            {// && ttype[t]!=5){

                                //if (!(mztm>=1 && mztype==1 && actaon[3]==1)){
                                if (!(mztype == 1))
                                {
                                    xx[16] = 0; xx[17] = 0;

                                    //上
                                    if (ttype[t_] != 7 && ttype[t_] != 110 && !(ttype[t_] == 114))
                                    {
                                        if (ma + mnobia > xx[8] + xx[0] * 2 + 100 && ma < xx[8] + xx[1] - xx[0] * 2 - 100 && mb + mnobib > xx[9] && mb + mnobib < xx[9] + xx[1] && md >= -100)
                                        {
                                            if (ttype[t_] != 115 && ttype[t_] != 400 && ttype[t_] != 117 && ttype[t_] != 118 && ttype[t_] != 120)
                                            {
                                                mb = xx[9] - mnobib + 100; md = 0; mzimen = 1; xx[16] = 1;
                                            }
                                            else if (ttype[t_] == 115)
                                            {
                                                ot(nオーディオ_[3]);
                                                eyobi(ta[t_] + 1200, tb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                eyobi(ta[t_] + 1200, tb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                eyobi(ta[t_] + 1200, tb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                eyobi(ta[t_] + 1200, tb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                brockbreak(t_);
                                            }
                                            //Pスイッチ
                                            else if (ttype[t_] == 400)
                                            {
                                                md = 0; ta[t_] = -8000000; ot(nオーディオ_[13]);
                                                for (tt_ = 0; tt_ < tmax; tt_++) { if (ttype[tt_] != 7) { ttype[tt_] = 800; } }
                                            }

                                            //音符+
                                            else if (ttype[t_] == 117)
                                            {
                                                ot(nオーディオ_[14]);
                                                md = -1500; mtype = 2; mtm = 0;
                                                if (txtype[t_] >= 2 && mtype == 2) { mtype = 0; md = -1600; txtype[t_] = 3; }
                                                if (txtype[t_] == 0) txtype[t_] = 1;
                                            }

                                            //ジャンプ台
                                            else if (ttype[t_] == 120)
                                            {
                                                //txtype[t]=0;
                                                md = -2400; mtype = 3; mtm = 0;
                                            }

                                        }
                                    }
                                }//!


                                //sstr=""+mjumptm;
                                //ブロック判定の入れ替え
                                if (!(mztm >= 1 && mztype == 1))
                                {
                                    xx[21] = 0; xx[22] = 1;//xx[12]=0;
                                    if (mzimen == 1 || mjumptm >= 10) { xx[21] = 3; xx[22] = 0; }
                                    for (t3 = 0; t3 <= 1; t3++)
                                    {

                                        //下
                                        if (t3 == xx[21] && mtype != 100 && ttype[t_] != 117)
                                        {// && xx[12]==0){
                                            if (ma + mnobia > xx[8] + xx[0] * 2 + 800 && ma < xx[8] + xx[1] - xx[0] * 2 - 800 && mb > xx[9] - xx[0] * 2 && mb < xx[9] + xx[1] - xx[0] * 2 && md <= 0)
                                            {
                                                xx[16] = 1; xx[17] = 1;
                                                mb = xx[9] + xx[1] + xx[0]; if (md < 0) { md = -md * 2 / 3; }//}
                                                                                                             //壊れる
                                                if (ttype[t_] == 1 && mzimen == 0)
                                                {
                                                    ot(nオーディオ_[3]);
                                                    eyobi(ta[t_] + 1200, tb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                    eyobi(ta[t_] + 1200, tb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                                    eyobi(ta[t_] + 1200, tb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                    eyobi(ta[t_] + 1200, tb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                                    brockbreak(t_);
                                                }
                                                //コイン
                                                if (ttype[t_] == 2 && mzimen == 0)
                                                {
                                                    ot(nオーディオ_[4]);
                                                    eyobi(ta[t_] + 10, tb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                                    ttype[t_] = 3;
                                                }
                                                //隠し
                                                if (ttype[t_] == 7)
                                                {
                                                    ot(nオーディオ_[4]);
                                                    eyobi(ta[t_] + 10, tb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                                    mb = xx[9] + xx[1] + xx[0]; ttype[t_] = 3; if (md < 0) { md = -md * 2 / 3; }
                                                }
                                                // トゲ
                                                if (ttype[t_] == 10)
                                                {
                                                    mmsgtm = 30;
                                                    mmsgtype = 3;
                                                    mhp--;
                                                }
                                            }
                                        }


                                        //左右
                                        if (t3 == xx[22] && xx[15] == 0)
                                        {
                                            if (ttype[t_] != 7 && ttype[t_] != 110 && ttype[t_] != 117)
                                            {
                                                if (!(ttype[t_] == 114))
                                                {// && txtype[t]==1)){
                                                    if (ta[t_] >= -20000)
                                                    {
                                                        if (ma + mnobia > xx[8] && ma < xx[8] + xx[2] && mb + mnobib > xx[9] + xx[1] / 2 - xx[0] && mb < xx[9] + xx[2] && mc >= 0)
                                                        {
                                                            ma = xx[8] - mnobia; mc = 0; xx[16] = 1;
                                                        }
                                                        if (ma + mnobia > xx[8] + xx[2] && ma < xx[8] + xx[1] && mb + mnobib > xx[9] + xx[1] / 2 - xx[0] && mb < xx[9] + xx[2] && mc <= 0)
                                                        {
                                                            ma = xx[8] + xx[1]; mc = 0; xx[16] = 1;//end();
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }//t3
                                }//!

                            }// && ttype[t]<50

                            if (ttype[t_] == 800)
                            {
                                if (mb > xx[9] - xx[0] * 2 - 2000 && mb < xx[9] + xx[1] - xx[0] * 2 + 2000 && ma + mnobia > xx[8] - 400 && ma < xx[8] + xx[1])
                                {
                                    ta[t_] = -800000; ot(nオーディオ_[4]);
                                }
                            }

                            //剣とってクリア
                            if (ttype[t_] == 140)
                            {
                                if (mb > xx[9] - xx[0] * 2 - 2000 && mb < xx[9] + xx[1] - xx[0] * 2 + 2000 && ma + mnobia > xx[8] - 400 && ma < xx[8] + xx[1])
                                {
                                    ta[t_] = -800000;//ot(oto[4]);
                                    sracttype[20] = 1; sron[20] = 1;
                                    DX.StopSoundMem(nオーディオ_[0]); mtype = 301; mtm = 0; ot(nオーディオ_[16]);

                                }
                            }


                            //特殊的
                            if (ttype[t_] == 100)
                            {//xx[9]+xx[1]+3000<mb && // && mb>xx[9]-xx[0]*2
                                if (mb > xx[9] - xx[0] * 2 - 2000 && mb < xx[9] + xx[1] - xx[0] * 2 + 2000 && ma + mnobia > xx[8] - 400 && ma < xx[8] + xx[1] && md <= 0)
                                {
                                    if (txtype[t_] == 0) tb[t_] = mb + fy - 1200 - xx[1];
                                }

                                if (txtype[t_] == 1)
                                {
                                    if (xx[17] == 1)
                                    {
                                        if (ma + mnobia > xx[8] - 400 && ma < xx[8] + xx[1] / 2 - 1500) { ta[t_] += 3000; }
                                        else if (ma + mnobia >= xx[8] + xx[1] / 2 - 1500 && ma < xx[8] + xx[1]) { ta[t_] -= 3000; }
                                    }
                                }

                                if (xx[17] == 1 && txtype[t_] == 0)
                                {
                                    ot(nオーディオ_[4]);
                                    eyobi(ta[t_] + 10, tb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                    ttype[t_] = 3;
                                }
                            }//100

                            //敵出現
                            if (ttype[t_] == 101)
                            {//xx[9]+xx[1]+3000<mb && // && mb>xx[9]-xx[0]*2
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
                                    ttype[t_] = 3;
                                    abrocktm[aco] = 16;
                                    if (txtype[t_] == 0) ayobi(ta[t_], tb[t_], 0, 0, 0, 0, 0);
                                    if (txtype[t_] == 1) ayobi(ta[t_], tb[t_], 0, 0, 0, 4, 0);
                                    if (txtype[t_] == 3) ayobi(ta[t_], tb[t_], 0, 0, 0, 101, 0);
                                    if (txtype[t_] == 4) { abrocktm[aco] = 20; ayobi(ta[t_] - 400, tb[t_] - 1600, 0, 0, 0, 6, 0); }
                                    if (txtype[t_] == 10) ayobi(ta[t_], tb[t_], 0, 0, 0, 101, 0);
                                }
                            }//101

                            //おいしいきのこ出現
                            if (ttype[t_] == 102)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
                                    ttype[t_] = 3; abrocktm[aco] = 16;
                                    if (txtype[t_] == 0) ayobi(ta[t_], tb[t_], 0, 0, 0, 100, 0);
                                    if (txtype[t_] == 2) ayobi(ta[t_], tb[t_], 0, 0, 0, 100, 2);
                                    if (txtype[t_] == 3) ayobi(ta[t_], tb[t_], 0, 0, 0, 102, 1);
                                }
                            }//102

                            //まずいきのこ出現
                            if (ttype[t_] == 103)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
                                    ttype[t_] = 3; abrocktm[aco] = 16; ayobi(ta[t_], tb[t_], 0, 0, 0, 100, 1);
                                }
                            }//103


                            //悪スター出し
                            if (ttype[t_] == 104)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
                                    ttype[t_] = 3; abrocktm[aco] = 16; ayobi(ta[t_], tb[t_], 0, 0, 0, 110, 0);
                                }
                            }//104




                            //毒きのこ量産
                            if (ttype[t_] == 110)
                            {
                                if (xx[17] == 1)
                                {
                                    ttype[t_] = 111; thp[t_] = 999;
                                }
                            }//110
                            if (ttype[t_] == 111 && ta[t_] - fx >= 0)
                            {
                                thp[t_]++; if (thp[t_] >= 16)
                                {
                                    thp[t_] = 0;
                                    ot(nオーディオ_[8]);
                                    abrocktm[aco] = 16; ayobi(ta[t_], tb[t_], 0, 0, 0, 102, 1);
                                }
                            }


                            //コイン量産
                            if (ttype[t_] == 112)
                            {
                                if (xx[17] == 1)
                                {
                                    ttype[t_] = 113; thp[t_] = 999; titem[t_] = 0;
                                }
                            }//110
                            if (ttype[t_] == 113 && ta[t_] - fx >= 0)
                            {
                                if (titem[t_] <= 19) thp[t_]++;
                                if (thp[t_] >= 3)
                                {
                                    thp[t_] = 0; titem[t_]++;
                                    ot(nオーディオ_[4]);
                                    eyobi(ta[t_] + 10, tb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                    //ttype[t]=3;
                                }
                            }


                            //隠し毒きのこ
                            if (ttype[t_] == 114)
                            {
                                if (xx[17] == 1)
                                {
                                    if (txtype[t_] == 0)
                                    {
                                        ot(nオーディオ_[8]); ttype[t_] = 3;
                                        abrocktm[aco] = 16; ayobi(ta[t_], tb[t_], 0, 0, 0, 102, 1);
                                    }
                                    if (txtype[t_] == 2) { ot(nオーディオ_[4]); eyobi(ta[t_] + 10, tb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16); ttype[t_] = 115; txtype[t_] = 0; }
                                    if (txtype[t_] == 10)
                                    {
                                        if (stageonoff == 1) { ttype[t_] = 130; stageonoff = 0; ot(nオーディオ_[13]); txtype[t_] = 2; for (t_ = 0; t_ < amax; t_++) { if (atype[t_] == 87 || atype[t_] == 88) { if (axtype[t_] == 105) { axtype[t_] = 110; } } } }
                                        else { ot(nオーディオ_[4]); eyobi(ta[t_] + 10, tb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16); ttype[t_] = 3; }
                                    }

                                }
                            }//114


                            //もろいブロック
                            if (ttype[t_] == 115)
                            {

                            }//115


                            //Pスイッチ
                            if (ttype[t_] == 116)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[8]);
                                    //ot(oto[13]);
                                    ttype[t_] = 3;//abrocktm[aco]=18;ayobi(ta[t],tb[t],0,0,0,104,1);
                                    tyobi(ta[t_] / 100, (tb[t_] / 100) - 29, 400);
                                }
                            }//116


                            //ファイアバー強化
                            if (ttype[t_] == 124)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[13]);
                                    for (t_ = 0; t_ < amax; t_++) { if (atype[t_] == 87 || atype[t_] == 88) { if (axtype[t_] == 101) { axtype[t_] = 120; } } }
                                    ttype[t_] = 3;
                                }
                            }

                            //ONスイッチ
                            if (ttype[t_] == 130)
                            {
                                if (xx[17] == 1)
                                {
                                    if (txtype[t_] != 1)
                                    {
                                        stageonoff = 0; ot(nオーディオ_[13]);
                                    }
                                }
                            }
                            else if (ttype[t_] == 131)
                            {
                                if (xx[17] == 1 && txtype[t_] != 2)
                                {
                                    stageonoff = 1; ot(nオーディオ_[13]);
                                    if (txtype[t_] == 1)
                                    {
                                        for (t_ = 0; t_ < amax; t_++) { if (atype[t_] == 87 || atype[t_] == 88) { if (axtype[t_] == 105) { axtype[t_] = 110; } } }
                                        bxtype[3] = 105;
                                    }
                                }
                            }

                            //ヒント
                            if (ttype[t_] == 300)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[15]);
                                    if (txtype[t_] <= 100)
                                    {
                                        tmsgtype = 1; tmsgtm = 15; tmsgy = 300 + (txtype[t_] - 1); tmsg = (txtype[t_]);
                                    }
                                    if (txtype[t_] == 540)
                                    {
                                        tmsgtype = 1; tmsgtm = 15; tmsgy = 400; tmsg = 100; txtype[t_] = 541;
                                    }
                                }
                            }//300


                            if (ttype[t_] == 301)
                            {
                                if (xx[17] == 1)
                                {
                                    ot(nオーディオ_[3]);
                                    eyobi(ta[t_] + 1200, tb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(ta[t_] + 1200, tb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(ta[t_] + 1200, tb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120); eyobi(ta[t_] + 1200, tb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    brockbreak(t_);
                                }
                            }//300


                        }
                        else if (mtype == 1)
                        {
                            if (ma + mnobia > xx[8] && ma < xx[8] + xx[1] && mb + mnobib > xx[9] && mb < xx[9] + xx[1])
                            {

                                ot(nオーディオ_[3]);
                                eyobi(ta[t_] + 1200, tb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                eyobi(ta[t_] + 1200, tb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                eyobi(ta[t_] + 1200, tb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                eyobi(ta[t_] + 1200, tb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                brockbreak(t_);

                            }
                        }


                        //ONOFF
                        if (ttype[t_] == 130 && stageonoff == 0) { ttype[t_] = 131; }
                        if (ttype[t_] == 131 && stageonoff == 1) { ttype[t_] = 130; }

                        //ヒント
                        if (ttype[t_] == 300)
                        {
                            if (txtype[t_] >= 500 && ta[t_] >= -6000)
                            {// && ta[t]>=-6000){
                                if (txtype[t_] <= 539) txtype[t_]++;
                                if (txtype[t_] >= 540) { ta[t_] -= 500; }
                            }
                        }//300


                    }
                }//ブロック







                //壁
                for (t_ = 0; t_ < smax; t_++)
                {
                    if (sa[t_] - fx + sc[t_] >= -12000 && sa[t_] - fx <= n画面幅)
                    {
                        xx[0] = 200; xx[1] = 2400; xx[2] = 1000; xx[7] = 0;

                        xx[8] = sa[t_] - fx; xx[9] = sb[t_] - fy;
                        if ((stype[t_] <= 99 || stype[t_] == 200) && mtype < 10)
                        {

                            //おちるブロック
                            if (stype[t_] == 51)
                            {
                                if (ma + mnobia > xx[8] + xx[0] + 3000 && ma < xx[8] + sc[t_] - xx[0] && mb + mnobib > xx[9] + 3000 && sgtype[t_] == 0)
                                {
                                    if (sxtype[t_] == 0)
                                    {
                                        sgtype[t_] = 1; sr[t_] = 0;
                                    }
                                }
                                if (ma + mnobia > xx[8] + xx[0] + 1000 && ma < xx[8] + sc[t_] - xx[0] && mb + mnobib > xx[9] + 3000 && sgtype[t_] == 0)
                                {
                                    if ((sxtype[t_] == 10) && sgtype[t_] == 0)
                                    {
                                        sgtype[t_] = 1; sr[t_] = 0;
                                    }
                                }

                                if ((sxtype[t_] == 1) && sb[27] >= 25000 && sa[27] > ma + mnobia && t_ != 27 && sgtype[t_] == 0)
                                {
                                    sgtype[t_] = 1; sr[t_] = 0;
                                }
                                if (sxtype[t_] == 2 && sb[28] >= 48000 && t_ != 28 && sgtype[t_] == 0 && mhp >= 1)
                                {
                                    sgtype[t_] = 1; sr[t_] = 0;
                                }
                                if ((sxtype[t_] == 3 && mb >= 30000 || sxtype[t_] == 4 && mb >= 25000) && sgtype[t_] == 0 && mhp >= 1 && ma + mnobia > xx[8] + xx[0] + 3000 - 300 && ma < xx[8] + sc[t_] - xx[0])
                                {
                                    sgtype[t_] = 1; sr[t_] = 0;
                                    if (sxtype[t_] == 4) sr[t_] = 100;
                                }

                                if (sgtype[t_] == 1 && sb[t_] <= n画面高さ + 18000)
                                {
                                    sr[t_] += 120; if (sr[t_] >= 1600) { sr[t_] = 1600; }
                                    sb[t_] += sr[t_];
                                    if (ma + mnobia > xx[8] + xx[0] && ma < xx[8] + sc[t_] - xx[0] && mb + mnobib > xx[9] && mb < xx[9] + sd[t_] + xx[0])
                                    {
                                        mhp--; xx[7] = 1;
                                    }
                                }
                            }

                            //おちるブロック2
                            if (stype[t_] == 52)
                            {
                                if (sgtype[t_] == 0 && ma + mnobia > xx[8] + xx[0] + 2000 && ma < xx[8] + sc[t_] - xx[0] - 2500 && mb + mnobib > xx[9] - 3000)
                                {
                                    sgtype[t_] = 1; sr[t_] = 0;
                                }
                                if (sgtype[t_] == 1)
                                {
                                    sr[t_] += 120; if (sr[t_] >= 1600) { sr[t_] = 1600; }
                                    sb[t_] += sr[t_];
                                }
                            }



                            //通常地面
                            if (xx[7] == 0)
                            {
                                if (ma + mnobia > xx[8] + xx[0] && ma < xx[8] + sc[t_] - xx[0] && mb + mnobib > xx[9] && mb + mnobib < xx[9] + xx[1] && md >= -100) { mb = sb[t_] - fy - mnobib + 100; md = 0; mzimen = 1; }
                                if (ma + mnobia > xx[8] - xx[0] && ma < xx[8] + xx[2] && mb + mnobib > xx[9] + xx[1] * 3 / 4 && mb < xx[9] + sd[t_] - xx[2]) { ma = xx[8] - xx[0] - mnobia; mc = 0; }
                                if (ma + mnobia > xx[8] + sc[t_] - xx[0] && ma < xx[8] + sc[t_] + xx[0] && mb + mnobib > xx[9] + xx[1] * 3 / 4 && mb < xx[9] + sd[t_] - xx[2]) { ma = xx[8] + sc[t_] + xx[0]; mc = 0; }
                                if (ma + mnobia > xx[8] + xx[0] * 2 && ma < xx[8] + sc[t_] - xx[0] * 2 && mb > xx[9] + sd[t_] - xx[1] && mb < xx[9] + sd[t_] + xx[0])
                                {
                                    mb = xx[9] + sd[t_] + xx[0]; if (md < 0) { md = -md * 2 / 3; }
                                }
                            }//xx[7]

                            //入る土管
                            if (stype[t_] == 50)
                            {
                                if (ma + mnobia > xx[8] + 2800 && ma < xx[8] + sc[t_] - 3000 && mb + mnobib > xx[9] - 1000 && mb + mnobib < xx[9] + xx[1] + 3000 && mzimen == 1 && actaon[3] == 1 && mtype == 0)
                                {
                                    //飛び出し
                                    if (sxtype[t_] == 0)
                                    {
                                        mtype = 100; mtm = 0; ot(nオーディオ_[7]); mxtype = 0;
                                    }
                                    //普通
                                    if (sxtype[t_] == 1)
                                    {
                                        mtype = 100; mtm = 0; ot(nオーディオ_[7]); mxtype = 1;
                                    }
                                    //普通
                                    if (sxtype[t_] == 2)
                                    {
                                        mtype = 100; mtm = 0; ot(nオーディオ_[7]); mxtype = 2;
                                    }
                                    if (sxtype[t_] == 5)
                                    {
                                        mtype = 100; mtm = 0; ot(nオーディオ_[7]); mxtype = 5;
                                    }
                                    // ループ
                                    if (sxtype[t_] == 6)
                                    {
                                        mtype = 100; mtm = 0; ot(nオーディオ_[7]); mxtype = 6;
                                    }
                                }
                            }//50

                            //入る土管(左から)
                            if (stype[t_] == 40)
                            {
                                if (ma + mnobia > xx[8] - 300 && ma < xx[8] + sc[t_] - 1000 && mb > xx[9] + 1000 && mb + mnobib < xx[9] + xx[1] + 4000 && mzimen == 1 && actaon[4] == 1 && mtype == 0)
                                {//end();
                                 //飛び出し
                                    if (sxtype[t_] == 0)
                                    {
                                        mtype = 500; mtm = 0; ot(nオーディオ_[7]);//mxtype=1;
                                        mtype = 100; mxtype = 10;
                                    }

                                    if (sxtype[t_] == 2)
                                    {
                                        mxtype = 3;
                                        mtm = 0; ot(nオーディオ_[7]);//mxtype=1;
                                        mtype = 100;
                                    }
                                    // ループ
                                    if (sxtype[t_] == 6)
                                    {
                                        mtype = 3; mtm = 0; ot(nオーディオ_[7]); mxtype = 6;
                                    }
                                }
                            }//40




                        }//stype
                        else {
                            if (ma + mnobia > xx[8] + xx[0] && ma < xx[8] + sc[t_] - xx[0] && mb + mnobib > xx[9] && mb < xx[9] + sd[t_] + xx[0])
                            {
                                if (stype[t_] == 100)
                                {
                                    if (sxtype[t_] == 0 || sxtype[t_] == 1 && ttype[1] != 3)
                                    {
                                        ayobi(sa[t_] + 1000, 32000, 0, 0, 0, 3, 0); sa[t_] = -800000000; ot(nオーディオ_[10]);
                                    }
                                }
                                if (stype[t_] == 101) { ayobi(sa[t_] + 6000, -4000, 0, 0, 0, 3, 1); sa[t_] = -800000000; ot(nオーディオ_[10]); }
                                if (stype[t_] == 102)
                                {
                                    if (sxtype[t_] == 0)
                                    {
                                        for (t3 = 0; t3 <= 3; t3++) { ayobi(sa[t_] + t3 * 3000, -3000, 0, 0, 0, 0, 0); }
                                    }
                                    if (sxtype[t_] == 1 && mb >= 16000) { ayobi(sa[t_] + 1500, 44000, 0, -2000, 0, 4, 0); }
                                    else if (sxtype[t_] == 2) { ayobi(sa[t_] + 4500, 30000, 0, -1600, 0, 5, 0); ot(nオーディオ_[10]); sxtype[t_] = 3; sa[t_] -= 12000; }
                                    else if (sxtype[t_] == 3) { sa[t_] += 12000; sxtype[t_] = 4; }
                                    else if (sxtype[t_] == 4) { ayobi(sa[t_] + 4500, 30000, 0, -1600, 0, 5, 0); ot(nオーディオ_[10]); sxtype[t_] = 5; sxtype[t_] = 0; }

                                    else if (sxtype[t_] == 7) { mainmsgtype = 1; }
                                    else if (sxtype[t_] == 8) { ayobi(sa[t_] - 5000 - 3000 * 1, 26000, 0, -1600, 0, 5, 0); ot(nオーディオ_[10]); }
                                    else if (sxtype[t_] == 9) { for (t3 = 0; t3 <= 2; t3++) { ayobi(sa[t_] + t3 * 3000 + 3000, 48000, 0, -6000, 0, 3, 0); } }
                                    if (sxtype[t_] == 10) { sa[t_] -= 5 * 30 * 100; stype[t_] = 101; }

                                    if (sxtype[t_] == 12)
                                    {
                                        for (t3 = 1; t3 <= 3; t3++) { ayobi(sa[t_] + t3 * 3000 - 1000, 40000, 0, -2600, 0, 9, 0); }
                                    }

                                    //スクロール消し
                                    if (sxtype[t_] == 20)
                                    {
                                        scrollx = 0;
                                    }

                                    //クリア
                                    if (sxtype[t_] == 30)
                                    {
                                        sa[t_] = -80000000; md = 0;
                                        DX.StopSoundMem(nオーディオ_[0]); mtype = 302; mtm = 0; ot(nオーディオ_[16]);
                                    }

                                    if (sxtype[t_] != 3 && sxtype[t_] != 4 && sxtype[t_] != 10) { sa[t_] = -800000000; }
                                }

                                if (stype[t_] == 103)
                                {
                                    if (sxtype[t_] == 0)
                                    {
                                        amsgtm[aco] = 10; amsgtype[aco] = 50; ayobi(sa[t_] + 9000, sb[t_] + 2000, 0, 0, 0, 79, 0); sa[t_] = -800000000;
                                    }

                                    if (sxtype[t_] == 1 && ttype[6] <= 6)
                                    {
                                        amsgtm[aco] = 10; amsgtype[aco] = 50; ayobi(sa[t_] - 12000, sb[t_] + 2000, 0, 0, 0, 79, 0); sa[t_] = -800000000;
                                        txtype[9] = 500;//ttype[9]=1;
                                    }
                                }//103

                                if (stype[t_] == 104)
                                {
                                    if (sxtype[t_] == 0)
                                    {
                                        ayobi(sa[t_] + 12000, sb[t_] + 2000 + 3000, 0, 0, 0, 79, 0);
                                        ayobi(sa[t_] + 12000, sb[t_] + 2000 + 3000, 0, 0, 0, 79, 1);
                                        ayobi(sa[t_] + 12000, sb[t_] + 2000 + 3000, 0, 0, 0, 79, 2);
                                        ayobi(sa[t_] + 12000, sb[t_] + 2000 + 3000, 0, 0, 0, 79, 3);
                                        ayobi(sa[t_] + 12000, sb[t_] + 2000 + 3000, 0, 0, 0, 79, 4);
                                        sa[t_] = -800000000;
                                    }
                                }

                                if (stype[t_] == 105 && mzimen == 0 && md >= 0) { ta[1] -= 1000; ta[2] += 1000; sxtype[t_]++; if (sxtype[t_] >= 3) sa[t_] = -8000000; }


                                if (stype[t_] == 300 && mtype == 0 && mb < xx[9] + sd[t_] + xx[0] - 3000 && mhp >= 1) { DX.StopSoundMem(nオーディオ_[0]); mtype = 300; mtm = 0; ma = sa[t_] - fx - 2000; ot(nオーディオ_[11]); }

                                //中間ゲート
                                if (stype[t_] == 500 && mtype == 0 && mhp >= 1)
                                {
                                    tyuukan += 1;
                                    sa[t_] = -80000000;
                                }

                            }

                            if (stype[t_] == 180)
                            {
                                sr[t_]++;
                                if (sr[t_] >= sgtype[t_])
                                {
                                    sr[t_] = 0;
                                    ayobi(sa[t_], 30000, rand(600) - 300, -1600 - rand(900), 0, 84, 0);
                                }
                            }

                        }
                    }
                }//壁

                //キー入力初期化
                actaon[0] = 0; actaon[4] = 0;

                //リフト
                for (t_ = 0; t_ < srmax; t_++)
                {
                    xx[10] = sra[t_]; xx[11] = srb[t_]; xx[12] = src[t_]; xx[13] = srd[t_];
                    xx[8] = xx[10] - fx; xx[9] = xx[11] - fy;
                    if (xx[8] + xx[12] >= -10 - 12000 && xx[8] <= n画面幅 + 12100)
                    {
                        xx[0] = 500; xx[1] = 1200; xx[2] = 1000; xx[7] = 2000;
                        if (md >= 100) { xx[1] = 900 + md; }

                        if (md > xx[1]) xx[1] = md + 100;

                        srb[t_] += sre[t_];
                        sre[t_] += srf[t_];

                        //動き
                        switch (sracttype[t_])
                        {

                            case 1:
                                if (sron[t_] == 1) srf[t_] = 60;
                                break;
                            case 2:
                                break;

                            case 3:
                            case 5:
                                if (srmove[t_] == 0) { srmuki[t_] = 0; }
                                else { srmuki[t_] = 1; }
                                if (srb[t_] - fy < -2100) { srb[t_] = n画面高さ + fy + scrolly + 2000; }
                                if (srb[t_] - fy > n画面高さ + scrolly + 2000) { srb[t_] = -2100 + fy; }
                                break;

                            case 6:
                                if (sron[t_] == 1) srf[t_] = 40;
                                break;

                            case 7:
                                break;


                        }//sw

                        //乗ったとき
                        if (!(mztm >= 1 && mztype == 1 && actaon[3] == 1) && mhp >= 1)
                        {
                            if (ma + mnobia > xx[8] + xx[0] && ma < xx[8] + xx[12] - xx[0] && mb + mnobib > xx[9] && mb + mnobib < xx[9] + xx[1] && md >= -100)
                            {
                                mb = xx[9] - mnobib + 100;

                                if (srtype[t_] == 1) { sre[10] = 900; sre[11] = 900; }

                                if (srsp[t_] != 12)
                                {
                                    mzimen = 1; md = 0;
                                }
                                else {
                                    //すべり
                                    md = -800;
                                }



                                //落下
                                if ((sracttype[t_] == 1) && sron[t_] == 0) sron[t_] = 1;

                                if (sracttype[t_] == 1 && sron[t_] == 1 || sracttype[t_] == 3 || sracttype[t_] == 5)
                                {
                                    mb += sre[t_];
                                }

                                if (sracttype[t_] == 7)
                                {
                                    if (actaon[2] != 1) { md = -600; mb -= 810; }
                                    if (actaon[2] == 1) { mb -= 400; md = -1400; mjumptm = 10; }
                                }


                                //特殊
                                if (srsp[t_] == 1)
                                {
                                    ot(nオーディオ_[3]);
                                    eyobi(sra[t_] + 200, srb[t_] - 1000, -240, -1400, 0, 160, 4500, 4500, 2, 120);
                                    eyobi(sra[t_] + 4500 - 200, srb[t_] - 1000, 240, -1400, 0, 160, 4500, 4500, 3, 120);
                                    sra[t_] = -70000000;
                                }





                                if (srsp[t_] == 2)
                                {
                                    mc = -2400; srmove[t_] += 1;
                                    if (srmove[t_] >= 100) { mhp = 0; mmsgtype = 53; mmsgtm = 30; srmove[t_] = -5000; }
                                }

                                if (srsp[t_] == 3)
                                {
                                    mc = 2400; srmove[t_] += 1;
                                    if (srmove[t_] >= 100) { mhp = 0; mmsgtype = 53; mmsgtm = 30; srmove[t_] = -5000; }
                                }
                            }//判定内


                            //疲れ初期化
                            if ((srsp[t_] == 2 || srsp[t_] == 3) && mc != -2400 && srmove[t_] > 0) { srmove[t_]--; }

                            if (srsp[t_] == 11)
                            {
                                if (ma + mnobia > xx[8] + xx[0] - 2000 && ma < xx[8] + xx[12] - xx[0]) { sron[t_] = 1; }// && mb+mnobib>xx[9]-1000 && mb+mnobib<xx[9]+xx[1]+2000)
                                if (sron[t_] == 1) { srf[t_] = 60; srb[t_] += sre[t_]; }
                            }


                            //トゲ(下)
                            if (ma + mnobia > xx[8] + xx[0] && ma < xx[8] + xx[12] - xx[0] && mb > xx[9] - xx[1] / 2 && mb < xx[9] + xx[1] / 2)
                            {
                                if (srtype[t_] == 2) { if (md < 0) { md = -md; } mb += 110; if (mmutekitm <= 0) mhp -= 1; if (mmutekion != 1) mmutekitm = 40; }
                            }
                            //落下
                            if (sracttype[t_] == 6)
                            {
                                if (ma + mnobia > xx[8] + xx[0] && ma < xx[8] + xx[12] - xx[0]) { sron[t_] = 1; }
                            }

                        }//!

                        if (sracttype[t_] == 2 || sracttype[t_] == 4)
                        {
                            if (srmuki[t_] == 0) sra[t_] -= srsok[t_];
                            if (srmuki[t_] == 1) sra[t_] += srsok[t_];
                        }
                        if (sracttype[t_] == 3 || sracttype[t_] == 5)
                        {
                            if (srmuki[t_] == 0) srb[t_] -= srsok[t_];
                            if (srmuki[t_] == 1) srb[t_] += srsok[t_];
                        }

                        //敵キャラ適用
                        for (tt_ = 0; tt_ < amax; tt_++)
                        {
                            if (azimentype[tt_] == 1)
                            {
                                if (aa[tt_] + anobia[tt_] - fx > xx[8] + xx[0] && aa[tt_] - fx < xx[8] + xx[12] - xx[0] && ab[tt_] + anobib[tt_] > xx[11] - 100 && ab[tt_] + anobib[tt_] < xx[11] + xx[1] + 500 && ad[tt_] >= -100)
                                {
                                    ab[tt_] = xx[9] - anobib[tt_] + 100; ad[tt_] = 0; axzimen[tt_] = 1;
                                }
                            }
                        }
                    }
                }//リフト

                //グラ
                for (t_ = 0; t_ < emax; t_++)
                {
                    xx[0] = ea[t_] - fx; xx[1] = eb[t_] - fy;
                    xx[2] = enobia[t_] / 100; xx[3] = enobib[t_] / 100;
                    if (etm[t_] >= 0) etm[t_]--;
                    if (xx[0] + xx[2] * 100 >= -10 && xx[1] <= n画面幅 && xx[1] + xx[3] * 100 >= -10 - 8000 && xx[3] <= n画面高さ && etm[t_] >= 0)
                    {
                        ea[t_] += ec[t_]; eb[t_] += ed[t_];
                        ec[t_] += ee[t_]; ed[t_] += ef[t_];

                    }
                    else { ea[t_] = -9000000; }

                }//emax

                //敵キャラの配置
                for (t_ = 0; t_ < bmax; t_++)
                {
                    if (ba[t_] >= -80000)
                    {

                        if (btm[t_] >= 0) { btm[t_] = btm[t_] - 1; }

                        for (tt_ = 0; tt_ <= 1; tt_++)
                        {
                            xx[0] = 0; xx[1] = 0;


                            if (bz[t_] == 0 && btm[t_] < 0 && ba[t_] - fx >= n画面幅 + 2000 && ba[t_] - fx < n画面幅 + 2000 + mc && tt_ == 0) { xx[0] = 1; amuki[aco] = 0; }// && mmuki==1
                            if (bz[t_] == 0 && btm[t_] < 0 && ba[t_] - fx >= -400 - n敵サイズW_[btype[t_]] + mc && ba[t_] - fx < -400 - n敵サイズW_[btype[t_]] && tt_ == 1) { xx[0] = 1; xx[1] = 1; amuki[aco] = 1; }// && mmuki==0
                            if (bz[t_] == 1 && ba[t_] - fx >= 0 - n敵サイズW_[btype[t_]] && ba[t_] - fx <= n画面幅 + 4000 && bb[t_] - fy >= -9000 && bb[t_] - fy <= n画面高さ + 4000 && btm[t_] < 0) { xx[0] = 1; bz[t_] = 0; }// && xza<=5000// && tyuukan!=1
                            if (xx[0] == 1)
                            {//400
                                btm[t_] = 401; xx[0] = 0;
                                if (btype[t_] >= 10) { btm[t_] = 9999999; }

                                //10
                                ayobi(ba[t_], bb[t_], 0, 0, 0, btype[t_], bxtype[t_]);

                            }

                        }//tt

                    }
                }//t

                //敵キャラ
                for (t_ = 0; t_ < amax; t_++)
                {
                    xx[0] = aa[t_] - fx; xx[1] = ab[t_] - fy;
                    xx[2] = anobia[t_]; xx[3] = anobib[t_]; xx[14] = 12000 * 1;
                    if (anotm[t_] >= 0) anotm[t_]--;
                    if (xx[0] + xx[2] >= -xx[14] && xx[0] <= n画面幅 + xx[14] && xx[1] + xx[3] >= -10 - 9000 && xx[1] <= n画面高さ + 20000)
                    {
                        aacta[t_] = 0; aactb[t_] = 0;

                        xx[10] = 0;

                        switch (atype[t_])
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
                                if (axtype[t_] >= 1) xx[10] = xx[17];
                                //他の敵を倒す
                                if (axtype[t_] >= 1)
                                {
                                    for (tt_ = 0; tt_ < amax; tt_++)
                                    {
                                        xx[0] = 250; xx[5] = -800; xx[12] = 0; xx[1] = 1600;
                                        xx[8] = aa[tt_] - fx; xx[9] = ab[tt_] - fy;
                                        if (t_ != tt_)
                                        {
                                            if (aa[t_] + anobia[t_] - fx > xx[8] + xx[0] * 2 && aa[t_] - fx < xx[8] + anobia[tt_] - xx[0] * 2 && ab[t_] + anobib[t_] - fy > xx[9] + xx[5] && ab[t_] + anobib[t_] - fy < xx[9] + xx[1] * 3 + xx[12] + 1500)
                                            {
                                                aa[tt_] = -800000; ot(nオーディオ_[6]);
                                            }
                                        }
                                    }
                                }
                                break;

                            //あらまき
                            case 3:
                                azimentype[t_] = 0;//end();
                                if (axtype[t_] == 0)
                                {
                                    ab[t_] -= 800;
                                }
                                if (axtype[t_] == 1)
                                    ab[t_] += 1200;

                                //xx[10]=100;
                                break;

                            //スーパージエン
                            case 4:
                                xx[10] = 120;
                                xx[0] = 250;
                                xx[8] = aa[t_] - fx;
                                xx[9] = ab[t_] - fy;
                                if (atm[t_] >= 0) atm[t_]--;
                                if (Math.Abs(ma + mnobia - xx[8] - xx[0] * 2) < 9000 &&
                                    Math.Abs((ma < xx[8] - anobia[t_] + xx[0] * 2) ? 1 : 0) < 3000 &&
                                    md <= -600 && atm[t_] <= 0)
                                {
                                    if (axtype[t_] == 1 && mzimen == 0 && axzimen[t_] == 1)
                                    {
                                        ad[t_] = -1600; atm[t_] = 40; ab[t_] -= 1000;
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
                                if (azimentype[t_] == 30) { ad[t_] = -1600; ab[t_] += ad[t_]; }

                                xx[10] = 120;
                                if (atm[t_] >= 10)
                                {
                                    atm[t_]++;
                                    if (mhp >= 1)
                                    {
                                        if (atm[t_] <= 19) { ma = xx[0]; mb = xx[1] - 3000; mtype = 0; }
                                        xx[10] = 0;
                                        if (atm[t_] == 20) { mc = 700; mkeytm = 24; md = -1200; mb = xx[1] - 1000 - 3000; amuki[t_] = 1; if (axtype[t_] == 1) { mc = 840; axtype[t_] = 0; } }
                                        if (atm[t_] == 40) { amuki[t_] = 0; atm[t_] = 0; }
                                    }
                                }

                                //ポール捨て
                                if (axtype[t_] == 1)
                                {
                                    for (tt_ = 0; tt_ < smax; tt_++)
                                    {
                                        if (stype[tt_] == 300)
                                        {
                                            if (aa[t_] - fx >= -8000 && aa[t_] >= sa[tt_] + 2000 && aa[t_] <= sa[tt_] + 3600 && axzimen[t_] == 1) { sa[tt_] = -800000; atm[t_] = 100; }
                                        }
                                    }

                                    if (atm[t_] == 100)
                                    {
                                        eyobi(aa[t_] + 1200 - 1200, ab[t_] + 3000 - 10 * 3000 - 1500, 0, 0, 0, 0, 1000, 10 * 3000 - 1200, 4, 20);
                                        if (mtype == 300) { mtype = 0; DX.StopSoundMem(nオーディオ_[11]); bgmchange(nオーディオ_[100]); DX.PlaySoundMem(nオーディオ_[0], DX.DX_PLAYTYPE_LOOP); }
                                        for (t1 = 0; t1 < smax; t1++) { if (stype[t1] == 104) sa[t1] = -80000000; }
                                    }
                                    if (atm[t_] == 120) { eyobi(aa[t_] + 1200 - 1200, ab[t_] + 3000 - 10 * 3000 - 1500, 600, -1200, 0, 160, 1000, 10 * 3000 - 1200, 4, 240); amuki[t_] = 1; }
                                    if (atm[t_] == 140) { amuki[t_] = 0; atm[t_] = 0; }
                                }
                                if (atm[t_] >= 220) { atm[t_] = 0; amuki[t_] = 0; }

                                //他の敵を投げる
                                for (tt_ = 0; tt_ < amax; tt_++)
                                {
                                    xx[0] = 250; xx[5] = -800; xx[12] = 0; xx[1] = 1600;
                                    xx[8] = aa[tt_] - fx; xx[9] = ab[tt_] - fy;
                                    if (t_ != tt_ && atype[tt_] >= 100)
                                    {
                                        if (aa[t_] + anobia[t_] - fx > xx[8] + xx[0] * 2 && aa[t_] - fx < xx[8] + anobia[tt_] - xx[0] * 2 && ab[t_] + anobib[t_] - fy > xx[9] + xx[5] && ab[t_] + anobib[t_] - fy < xx[9] + xx[1] * 3 + xx[12] + 1500)
                                        {
                                            //aa[tt]=-800000;
                                            amuki[tt_] = 1; aa[tt_] = aa[t_] + 300; ab[tt_] = ab[t_] - 3000; abrocktm[tt_] = 120;//aa[tt]=0;
                                            atm[t_] = 200; amuki[t_] = 1;
                                        }
                                    }
                                }

                                break;

                            //ジエン大砲
                            case 7:
                                azimentype[t_] = 0;
                                xx[10] = 0; xx[11] = 400;
                                if (axtype[t_] == 0) xx[10] = xx[11];
                                if (axtype[t_] == 1) xx[10] = -xx[11];
                                if (axtype[t_] == 2) ab[t_] -= xx[11];
                                if (axtype[t_] == 3) ab[t_] += xx[11];
                                break;

                            //スーパーブーン
                            case 8:
                                azimentype[t_] = 0;
                                xx[22] = 20;
                                if (atm[t_] == 0) { af[t_] += xx[22]; ad[t_] += xx[22]; }
                                if (atm[t_] == 1) { af[t_] -= xx[22]; ad[t_] -= xx[22]; }
                                if (ad[t_] > 300) ad[t_] = 300;
                                if (ad[t_] < -300) ad[t_] = -300;
                                if (af[t_] >= 1200) atm[t_] = 1;
                                if (af[t_] < -0) atm[t_] = 0;
                                ab[t_] += ad[t_];
                                //atype[t]=151;
                                break;
                            //ノーマルブーン
                            case 151:
                                azimentype[t_] = 2;
                                break;

                            //ファイアー玉
                            case 9:
                                azimentype[t_] = 5;
                                ab[t_] += ad[t_]; ad[t_] += 100;
                                if (ab[t_] >= n画面高さ + 1000) { ad[t_] = 900; }
                                if (ab[t_] >= n画面高さ + 12000)
                                {
                                    ab[t_] = n画面高さ; ad[t_] = -2600;
                                }
                                break;

                            //ファイアー
                            case 10:
                                azimentype[t_] = 0;
                                xx[10] = 0; xx[11] = 400;
                                if (axtype[t_] == 0) xx[10] = xx[11];
                                if (axtype[t_] == 1) xx[10] = -xx[11];
                                break;


                            //モララー
                            case 30:
                                atm[t_] += 1;
                                if (axtype[t_] == 0)
                                {
                                    if (atm[t_] == 50 && mb >= 6000) { ac[t_] = 300; ad[t_] -= 1600; ab[t_] -= 1000; }

                                    for (tt_ = 0; tt_ < amax; tt_++)
                                    {
                                        xx[0] = 250; xx[5] = -800; xx[12] = 0; xx[1] = 1600;
                                        xx[8] = aa[tt_] - fx; xx[9] = ab[tt_] - fy;
                                        if (t_ != tt_ && atype[tt_] == 102)
                                        {
                                            if (aa[t_] + anobia[t_] - fx > xx[8] + xx[0] * 2 && aa[t_] - fx < xx[8] + anobia[tt_] - xx[0] * 2 && ab[t_] + anobib[t_] - fy > xx[9] + xx[5] && ab[t_] + anobib[t_] - fy < xx[9] + xx[1] * 3 + xx[12] + 1500)
                                            {
                                                aa[tt_] = -800000; axtype[t_] = 1; ad[t_] = -1600;
                                                amsgtm[t_] = 30; amsgtype[t_] = 25;
                                            }
                                        }
                                    }
                                }
                                if (axtype[t_] == 1)
                                {
                                    azimentype[t_] = 0;
                                    ab[t_] += ad[t_]; ad[t_] += 120;
                                }
                                break;

                            //レーザー
                            case 79:
                                azimentype[t_] = 0;
                                xx[10] = 1600;
                                if (axtype[t_] == 1) { xx[10] = 1200; ab[t_] -= 200; }
                                if (axtype[t_] == 2) { xx[10] = 1200; ab[t_] += 200; }
                                if (axtype[t_] == 3) { xx[10] = 900; ab[t_] -= 600; }
                                if (axtype[t_] == 4) { xx[10] = 900; ab[t_] += 600; }
                                break;

                            //雲の敵
                            case 80:
                                azimentype[t_] = 0;
                                //xx[10]=100;
                                break;
                            case 81:
                                azimentype[t_] = 0;
                                break;
                            case 82:
                                azimentype[t_] = 0;
                                break;
                            case 83:
                                azimentype[t_] = 0;
                                break;

                            case 84:
                                azimentype[t_] = 2;
                                break;

                            case 85:
                                xx[23] = 400;
                                if (axtype[t_] == 0) { axtype[t_] = 1; amuki[t_] = 1; }
                                if (mb >= 30000 && ma >= aa[t_] - 3000 * 5 - fx && ma <= aa[t_] - fx && axtype[t_] == 1) { axtype[t_] = 5; amuki[t_] = 0; }
                                if (mb >= 24000 && ma <= aa[t_] + 3000 * 8 - fx && ma >= aa[t_] - fx && axtype[t_] == 1) { axtype[t_] = 5; amuki[t_] = 1; }
                                if (axtype[t_] == 5) xx[10] = xx[23];
                                break;

                            case 86:
                                azimentype[t_] = 4;
                                xx[23] = 1000;
                                if (ma >= aa[t_] - fx - mnobia - xx[26] && ma <= aa[t_] - fx + anobia[t_] + xx[26]) { atm[t_] = 1; }
                                if (atm[t_] == 1) { ab[t_] += 1200; }
                                break;

                            //ファイアバー
                            case 87:
                                azimentype[t_] = 0;
                                if (aa[t_] % 10 != 1) atm[t_] += 6;
                                else { atm[t_] -= 6; }
                                xx[25] = 2;
                                if (atm[t_] > 360 * xx[25]) atm[t_] -= 360 * xx[25];
                                if (atm[t_] < 0) atm[t_] += 360 * xx[25];

                                for (tt_ = 0; tt_ <= axtype[t_] % 100; tt_++)
                                {
                                    xx[26] = 18;
                                    xd[4] = tt_ * xx[26] * Math.Cos(atm[t_] * pai / 180 / 2); xd[5] = tt_ * xx[26] * Math.Sin(atm[t_] * pai / 180 / 2);

                                    xx[4] = 1800; xx[5] = 800;
                                    xx[8] = aa[t_] - fx + (int)xd[4] * 100 - xx[4] / 2; xx[9] = ab[t_] - fy + (int)xd[5] * 100 - xx[4] / 2;

                                    if (ma + mnobia > xx[8] + xx[5] && ma < xx[8] + xx[4] - xx[5] && mb + mnobib > xx[9] + xx[5] && mb < xx[9] + xx[4] - xx[5])
                                    {
                                        mhp -= 1;
                                        mmsgtype = 51; mmsgtm = 30;
                                    }
                                }

                                break;

                            case 88:
                                azimentype[t_] = 0;
                                if (aa[t_] % 10 != 1) atm[t_] += 6;
                                else { atm[t_] -= 6; }
                                xx[25] = 2;
                                if (atm[t_] > 360 * xx[25]) atm[t_] -= 360 * xx[25];
                                if (atm[t_] < 0) atm[t_] += 360 * xx[25];

                                for (tt_ = 0; tt_ <= axtype[t_] % 100; tt_++)
                                {
                                    xx[26] = 18;
                                    xd[4] = -tt_ * xx[26] * Math.Cos(atm[t_] * pai / 180 / 2);
                                    xd[5] = tt_ * xx[26] * Math.Sin(atm[t_] * pai / 180 / 2);

                                    xx[4] = 1800;
                                    xx[5] = 800;
                                    xx[8] = aa[t_] - fx + (int)xd[4] * 100 - xx[4] / 2;
                                    xx[9] = ab[t_] - fy + (int)xd[5] * 100 - xx[4] / 2;

                                    if (ma + mnobia > xx[8] + xx[5] && ma < xx[8] + xx[4] - xx[5] && mb + mnobib > xx[9] + xx[5] && mb < xx[9] + xx[4] - xx[5])
                                    {
                                        mhp -= 1;
                                        mmsgtype = 51; mmsgtm = 30;
                                    }
                                }

                                break;


                            case 90:
                                xx[10] = 160;
                                //azimentype[t]=0;
                                break;


                            //おいしいキノコ
                            case 100:
                                azimentype[t_] = 1;
                                xx[10] = 100;

                                //ほかの敵を巨大化
                                if (axtype[t_] == 2)
                                {
                                    for (tt_ = 0; tt_ < amax; tt_++)
                                    {
                                        xx[0] = 250; xx[5] = -800; xx[12] = 0; xx[1] = 1600;
                                        xx[8] = aa[tt_] - fx; xx[9] = ab[tt_] - fy;
                                        if (t_ != tt_)
                                        {
                                            if (aa[t_] + anobia[t_] - fx > xx[8] + xx[0] * 2 && aa[t_] - fx < xx[8] + anobia[tt_] - xx[0] * 2 && ab[t_] + anobib[t_] - fy > xx[9] + xx[5] && ab[t_] + anobib[t_] - fy < xx[9] + xx[1] * 3 + xx[12])
                                            {
                                                if (atype[tt_] == 0 || atype[tt_] == 4)
                                                {
                                                    atype[tt_] = 90;//ot(oto[6]);
                                                    anobia[tt_] = 6400; anobib[tt_] = 6300; axtype[tt_] = 0;
                                                    aa[tt_] -= 1050; ab[tt_] -= 1050;
                                                    ot(nオーディオ_[9]); aa[t_] = -80000000;
                                                }
                                            }
                                        }
                                    }
                                }

                                break;

                            //毒キノコ
                            case 102:
                                azimentype[t_] = 1;
                                xx[10] = 100;
                                if (axtype[t_] == 1) xx[10] = 200;
                                break;

                            //悪スター
                            case 110:
                                azimentype[t_] = 1;
                                xx[10] = 200;
                                if (axzimen[t_] == 1)
                                {
                                    ab[t_] -= 1200; ad[t_] = -1400;
                                }
                                break;


                            case 200:
                                azimentype[t_] = 1;
                                xx[10] = 100;
                                break;


                        }//sw


                        if (abrocktm[t_] >= 1) xx[10] = 0;



                        if (amuki[t_] == 0) aacta[t_] -= xx[10];
                        if (amuki[t_] == 1) aacta[t_] += xx[10];

                        //最大値
                        xx[0] = 850; xx[1] = 1200;

                        if (ad[t_] > xx[1] && azimentype[t_] != 5) { ad[t_] = xx[1]; }


                        //行動
                        aa[t_] += aacta[t_];//ab[t]+=aactb[t];

                        if ((azimentype[t_] >= 1 || azimentype[t_] == -1) && abrocktm[t_] <= 0)
                        {
                            //if (atype[t]==4)end();

                            //移動
                            aa[t_] += ac[t_];
                            if (azimentype[t_] >= 1 && azimentype[t_] <= 3) { ab[t_] += ad[t_]; ad[t_] += 120; }//ad[t]+=180;


                            if (axzimen[t_] == 1)
                            {
                                xx[0] = 100;
                                if (ac[t_] >= 200) { ac[t_] -= xx[0]; }
                                else if (ac[t_] <= -200) { ac[t_] += xx[0]; }
                                else { ac[t_] = 0; }
                            }

                            axzimen[t_] = 0;




                            //地面判定
                            if (azimentype[t_] != 2)
                            {
                                tekizimen();
                            }


                        }//azimentype[t]>=1

                        //ブロックから出現するさい
                        if (abrocktm[t_] > 0)
                        {
                            abrocktm[t_]--;
                            if (abrocktm[t_] < 100) { ab[t_] -= 180; }
                            if (abrocktm[t_] > 100) { }
                            if (abrocktm[t_] == 100) { ab[t_] -= 800; ad[t_] = -1200; ac[t_] = 700; abrocktm[t_] = 0; }
                        }//abrocktm[t]>0

                        //プレイヤーからの判定
                        xx[0] = 250; xx[1] = 1600; xx[2] = 1000;
                        xx[4] = 500; xx[5] = -800;

                        xx[8] = aa[t_] - fx; xx[9] = ab[t_] - fy;
                        xx[12] = 0; if (md >= 100) xx[12] = md;
                        xx[25] = 0;

                        if (ma + mnobia > xx[8] + xx[0] * 2 && ma < xx[8] + anobia[t_] - xx[0] * 2 && mb + mnobib > xx[9] - xx[5] && mb + mnobib < xx[9] + xx[1] + xx[12] && (mmutekitm <= 0 || md >= 100) && abrocktm[t_] <= 0)
                        {
                            if (atype[t_] != 4 && atype[t_] != 9 && atype[t_] != 10 && (atype[t_] <= 78 || atype[t_] == 85) && mzimen != 1 && mtype != 200)
                            {

                                if (atype[t_] == 0)
                                {
                                    if (axtype[t_] == 0)
                                        aa[t_] = -900000;
                                    if (axtype[t_] == 1)
                                    {
                                        ot(nオーディオ_[5]);
                                        mb = xx[9] - 900 - anobib[t_]; md = -2100; xx[25] = 1; actaon[2] = 0;
                                    }
                                }

                                if (atype[t_] == 1)
                                {
                                    atype[t_] = 2; anobib[t_] = 3000; axtype[t_] = 0;
                                }

                                //こうら
                                else if (atype[t_] == 2 && md >= 0)
                                {
                                    if (axtype[t_] == 1 || axtype[t_] == 2) { axtype[t_] = 0; }
                                    else if (axtype[t_] == 0)
                                    {
                                        if (ma + mnobia > xx[8] + xx[0] * 2 && ma < xx[8] + anobia[t_] / 2 - xx[0] * 4)
                                        {
                                            axtype[t_] = 1; amuki[t_] = 1;
                                        }
                                        else { axtype[t_] = 1; amuki[t_] = 0; }
                                    }
                                }
                                if (atype[t_] == 3)
                                {
                                    xx[25] = 1;
                                }

                                if (atype[t_] == 6)
                                {
                                    atm[t_] = 10; md = 0; actaon[2] = 0;
                                }

                                if (atype[t_] == 7)
                                {
                                    aa[t_] = -900000;
                                }

                                if (atype[t_] == 8)
                                {
                                    atype[t_] = 151; ad[t_] = 0;
                                }

                                if (atype[t_] != 85)
                                {
                                    if (xx[25] == 0) { ot(nオーディオ_[5]); mb = xx[9] - 1000 - anobib[t_]; md = -1000; }
                                }
                                if (atype[t_] == 85)
                                {
                                    if (xx[25] == 0) { ot(nオーディオ_[5]); mb = xx[9] - 4000; md = -1000; axtype[t_] = 5; }
                                }

                                if (actaon[2] == 1) { md = -1600; actaon[2] = 0; }
                            }
                        }

                        xx[15] = -500;


                        //プレイヤーに触れた時
                        xx[16] = 0;
                        if (atype[t_] == 4 || atype[t_] == 9 || atype[t_] == 10) xx[16] = -3000;
                        if (atype[t_] == 82 || atype[t_] == 83 || atype[t_] == 84) xx[16] = -3200;
                        if (atype[t_] == 85) xx[16] = -anobib[t_] + 6000;
                        if (ma + mnobia > xx[8] + xx[4] && ma < xx[8] + anobia[t_] - xx[4] && mb < xx[9] + anobib[t_] + xx[15] && mb + mnobib > xx[9] + anobib[t_] - xx[0] + xx[16] && anotm[t_] <= 0 && abrocktm[t_] <= 0)
                        {
                            if (mmutekion == 1) { aa[t_] = -9000000; }
                            if (mmutekitm <= 0 && (atype[t_] <= 99 || atype[t_] >= 200))
                            {
                                if (mmutekion != 1 && mtype != 200)
                                {
                                    //if (mmutekitm<=0)

                                    //ダメージ
                                    if ((atype[t_] != 2 || axtype[t_] != 0) && mhp >= 1)
                                    {
                                        if (atype[t_] != 6)
                                        {
                                            mhp -= 1;
                                            //mmutekitm=40;
                                        }
                                    }

                                    if (atype[t_] == 6)
                                    {
                                        atm[t_] = 10;
                                    }


                                    //せりふ
                                    if (mhp == 0)
                                    {

                                        if (atype[t_] == 0 || atype[t_] == 7)
                                        {
                                            amsgtm[t_] = 60; amsgtype[t_] = rand(7) + 1 + 1000 + (stb - 1) * 10;
                                        }

                                        if (atype[t_] == 1)
                                        {
                                            amsgtm[t_] = 60; amsgtype[t_] = rand(2) + 15;
                                        }

                                        if (atype[t_] == 2 && axtype[t_] >= 1 && mmutekitm <= 0)
                                        {
                                            amsgtm[t_] = 60; amsgtype[t_] = 18;
                                        }

                                        if (atype[t_] == 3)
                                        {
                                            amsgtm[t_] = 60; amsgtype[t_] = 20;
                                        }

                                        if (atype[t_] == 4)
                                        {
                                            amsgtm[t_] = 60; amsgtype[t_] = rand(7) + 1 + 1000 + (stb - 1) * 10;
                                        }

                                        if (atype[t_] == 5)
                                        {
                                            amsgtm[t_] = 60; amsgtype[t_] = 21;
                                        }

                                        if (atype[t_] == 9 || atype[t_] == 10)
                                        {
                                            mmsgtm = 30; mmsgtype = 54;
                                        }



                                        if (atype[t_] == 31)
                                        {
                                            amsgtm[t_] = 30; amsgtype[t_] = 24;
                                        }


                                        if (atype[t_] == 80 || atype[t_] == 81)
                                        {
                                            amsgtm[t_] = 60; amsgtype[t_] = 30;
                                        }

                                        if (atype[t_] == 82)
                                        {
                                            amsgtm[t_] = 20; amsgtype[t_] = rand(1) + 31;
                                            xx[24] = 900; atype[t_] = 83; aa[t_] -= xx[24] + 100; ab[t_] -= xx[24] - 100 * 0;
                                        }//82

                                        if (atype[t_] == 84)
                                        {
                                            mmsgtm = 30; mmsgtype = 50;
                                        }

                                        if (atype[t_] == 85)
                                        {
                                            amsgtm[t_] = 60; amsgtype[t_] = rand(1) + 85;
                                        }


                                        //雲
                                        if (atype[t_] == 80)
                                        {
                                            atype[t_] = 81;
                                        }
                                    }//mhp==0


                                    //こうら
                                    if (atype[t_] == 2)
                                    {
                                        if (axtype[t_] == 0)
                                        {
                                            if (ma + mnobia > xx[8] + xx[0] * 2 && ma < xx[8] + anobia[t_] / 2 - xx[0] * 4)
                                            {
                                                axtype[t_] = 1; amuki[t_] = 1; aa[t_] = ma + mnobia + fx + mc; mmutekitm = 5;
                                            }
                                            else {
                                                axtype[t_] = 1; amuki[t_] = 0; aa[t_] = ma - anobia[t_] + fx - mc; mmutekitm = 5;
                                            }
                                        }
                                        else { mhp -= 1; }//mmutekitm=40;}
                                    }


                                }
                            }
                            //アイテム
                            if (atype[t_] >= 100 && atype[t_] <= 199)
                            {

                                if (atype[t_] == 100 && axtype[t_] == 0) { mmsgtm = 30; mmsgtype = 1; ot(nオーディオ_[9]); }
                                if (atype[t_] == 100 && axtype[t_] == 1) { mmsgtm = 30; mmsgtype = 2; ot(nオーディオ_[9]); }
                                if (atype[t_] == 100 && axtype[t_] == 2) { mnobia = 5200; mnobib = 7300; ot(nオーディオ_[9]); ma -= 1100; mb -= 4000; mtype = 1; mhp = 50000000; }

                                if (atype[t_] == 101) { mhp -= 1; mmsgtm = 30; mmsgtype = 11; }
                                if (atype[t_] == 102) { mhp -= 1; mmsgtm = 30; mmsgtype = 10; }


                                //?ボール
                                if (atype[t_] == 105)
                                {
                                    if (axtype[t_] == 0)
                                    {
                                        ot(nオーディオ_[4]); sgtype[26] = 6;
                                    }
                                    if (axtype[t_] == 1)
                                    {
                                        txtype[7] = 80;
                                        ot(nオーディオ_[4]);

                                        ayobi(aa[t_] - 8 * 3000 - 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(aa[t_] - 10 * 3000 + 1000, -1 * 3000, 0, 0, 0, 110, 0);

                                        ayobi(aa[t_] + 4 * 3000 + 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(aa[t_] + 5 * 3000 - 1000, -3 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(aa[t_] + 6 * 3000 + 1000, -4 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(aa[t_] + 7 * 3000 - 1000, -2 * 3000, 0, 0, 0, 110, 0);
                                        ayobi(aa[t_] + 8 * 3000 + 1000, -2 * 3000 - 1000, 0, 0, 0, 110, 0);
                                        tb[0] += 3000 * 3;
                                    }
                                }//105

                                if (atype[t_] == 110) { mhp -= 1; mmsgtm = 30; mmsgtype = 3; }

                                aa[t_] = -90000000;
                            }

                        }//(ma

                    }
                    else { aa[t_] = -9000000; }

                }//t

                //スクロール
                if (kscroll != 1 && kscroll != 2)
                {
                    xx[2] = mascrollmax; xx[3] = 0;
                    xx[1] = xx[2]; if (ma > xx[1] && fzx < scrollx) { xx[5] = ma - xx[1]; ma = xx[1]; fx += xx[5]; fzx += xx[5]; if (xx[1] <= 5000) xx[3] = 1; }
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
                if (xx[30] <= -400) { main = 100; nokori = 2; maintm = 0; ending = 0; }

            }//main==2

            if (main == 10)
            {
                maintm++;

                if (fast == 1) maintm += 2;
                if (maintm >= 30) { maintm = 0; main = 1; zxon = 0; }
            }//if (main==10){

            //タイトル
            if (main == 100)
            {
                maintm++; xx[0] = 0;
                if (maintm <= 10) { maintm = 11; sta = 1; stb = 1; stc = 0; over = 0; }

                if (DX.CheckHitKey(DX.KEY_INPUT_1) == 1) { sta = 1; stb = 1; stc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_2) == 1) { sta = 1; stb = 2; stc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_3) == 1) { sta = 1; stb = 3; stc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_4) == 1) { sta = 1; stb = 4; stc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_5) == 1) { sta = 2; stb = 1; stc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_6) == 1) { sta = 2; stb = 2; stc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_7) == 1) { sta = 2; stb = 3; stc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_8) == 1) { sta = 2; stb = 4; stc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_9) == 1) { sta = 3; stb = 1; stc = 0; }
                if (DX.CheckHitKey(DX.KEY_INPUT_0) == 1) { xx[0] = 1; over = 1; }


                if (DX.CheckHitKey(DX.KEY_INPUT_RETURN) == 1) { xx[0] = 1; }
                if (DX.CheckHitKey(DX.KEY_INPUT_Z) == 1) { xx[0] = 1; }

                if (xx[0] == 1)
                {
                    main = 10; zxon = 0; maintm = 0;
                    nokori = 2;

                    fast = 0; trap = 0; tyuukan = 0;
                }

            }//100
        }//Mainprogram()

        static void tekizimen()
        {

            //壁
            for (tt_ = 0; tt_ < smax; tt_++)
            {
                if (sa[tt_] - fx + sc[tt_] >= -12010 && sa[tt_] - fx <= n画面幅 + 12100 && stype[tt_] <= 99)
                {
                    xx[0] = 200; xx[2] = 1000;
                    xx[1] = 2000;//anobia[t]

                    xx[8] = sa[tt_] - fx; xx[9] = sb[tt_] - fy;
                    if (aa[t_] + anobia[t_] - fx > xx[8] - xx[0] && aa[t_] - fx < xx[8] + xx[2] && ab[t_] + anobib[t_] - fy > xx[9] + xx[1] * 3 / 4 && ab[t_] - fy < xx[9] + sd[tt_] - xx[2]) { aa[t_] = xx[8] - xx[0] - anobia[t_] + fx; amuki[t_] = 0; }
                    if (aa[t_] + anobia[t_] - fx > xx[8] + sc[tt_] - xx[0] && aa[t_] - fx < xx[8] + sc[tt_] + xx[0] && ab[t_] + anobib[t_] - fy > xx[9] + xx[1] * 3 / 4 && ab[t_] - fy < xx[9] + sd[tt_] - xx[2]) { aa[t_] = xx[8] + sc[tt_] + xx[0] + fx; amuki[t_] = 1; }

                    if (aa[t_] + anobia[t_] - fx > xx[8] + xx[0] && aa[t_] - fx < xx[8] + sc[tt_] - xx[0] && ab[t_] + anobib[t_] - fy > xx[9] && ab[t_] + anobib[t_] - fy < xx[9] + sd[tt_] - xx[1] && ad[t_] >= -100) { ab[t_] = sb[tt_] - fy - anobib[t_] + 100 + fy; ad[t_] = 0; axzimen[t_] = 1; }

                    if (aa[t_] + anobia[t_] - fx > xx[8] + xx[0] && aa[t_] - fx < xx[8] + sc[tt_] - xx[0] && ab[t_] - fy > xx[9] + sd[tt_] - xx[1] && ab[t_] - fy < xx[9] + sd[tt_] + xx[0])
                    {
                        ab[t_] = xx[9] + sd[tt_] + xx[0] + fy; if (ad[t_] < 0) { ad[t_] = -ad[t_] * 2 / 3; }//axzimen[t]=1;
                    }

                }
            }

            //ブロック
            for (tt_ = 0; tt_ < tmax; tt_++)
            {
                xx[0] = 200; xx[1] = 3000; xx[2] = 1000;
                xx[8] = ta[tt_] - fx; xx[9] = tb[tt_] - fy;
                if (ta[tt_] - fx + xx[1] >= -12010 && ta[tt_] - fx <= n画面幅 + 12000)
                {
                    if (atype[t_] != 86 && atype[t_] != 90 && ttype[tt_] != 140)
                    {

                        //上
                        if (ttype[tt_] != 7)
                        {
                            //if (ttype[tt]==117 && txtype[t]==1){ad[t]=-1500;}
                            if (!(ttype[tt_] == 117))
                            {
                                //if (!(ttype[tt]==120 && txtype[t]==0)){
                                if (aa[t_] + anobia[t_] - fx > xx[8] + xx[0] && aa[t_] - fx < xx[8] + xx[1] - xx[0] * 1 && ab[t_] + anobib[t_] - fy > xx[9] && ab[t_] + anobib[t_] - fy < xx[9] + xx[1] && ad[t_] >= -100)
                                {
                                    ab[t_] = xx[9] - anobib[t_] + 100 + fy; ad[t_] = 0; axzimen[t_] = 1;
                                    //ジャンプ台
                                    if (ttype[tt_] == 120) { ad[t_] = -1600; azimentype[t_] = 30; }
                                    //}

                                }
                            }
                        }

                        //下
                        if (ttype[tt_] != 117)
                        {
                            if (aa[t_] + anobia[t_] - fx > xx[8] + xx[0] && aa[t_] - fx < xx[8] + xx[1] - xx[0] * 1 && ab[t_] - fy > xx[9] + xx[1] - xx[1] && ab[t_] - fy < xx[9] + xx[1] + xx[0])
                            {
                                ab[t_] = xx[9] + xx[1] + xx[0] + fy; if (ad[t_] < 0) { ad[t_] = 0; }                                                             //}
                            }
                        }

                        //左右
                        xx[27] = 0;
                        if ((atype[t_] >= 100 || (ttype[tt_] != 7 || ttype[tt_] == 7 && atype[t_] == 2)) && ttype[tt_] != 117)
                        {
                            if (aa[t_] + anobia[t_] - fx > xx[8] && aa[t_] - fx < xx[8] + xx[2] && ab[t_] + anobib[t_] - fy > xx[9] + xx[1] / 2 - xx[0] && ab[t_] - fy < xx[9] + xx[2]) { aa[t_] = xx[8] - anobia[t_] + fx; ac[t_] = 0; amuki[t_] = 0; xx[27] = 1; }
                            if (aa[t_] + anobia[t_] - fx > xx[8] + xx[1] - xx[0] * 2 && aa[t_] - fx < xx[8] + xx[1] && ab[t_] + anobib[t_] - fy > xx[9] + xx[1] / 2 - xx[0] && ab[t_] - fy < xx[9] + xx[2]) { aa[t_] = xx[8] + xx[1] + fx; ac[t_] = 0; amuki[t_] = 1; xx[27] = 1; }
                            //こうらブレイク
                            if (xx[27] == 1 && (ttype[tt_] == 7 || ttype[tt_] == 1) && atype[t_] == 2)
                            {
                                if (ttype[tt_] == 7)
                                {
                                    ot(nオーディオ_[4]); ttype[tt_] = 3;
                                    eyobi(ta[tt_] + 10, tb[tt_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                }
                                else if (ttype[tt_] == 1)
                                {
                                    ot(nオーディオ_[3]);
                                    eyobi(ta[tt_] + 1200, tb[tt_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(ta[tt_] + 1200, tb[tt_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(ta[tt_] + 1200, tb[tt_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(ta[tt_] + 1200, tb[tt_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    brockbreak(tt_);
                                }

                            }
                        }
                    }
                    if (atype[t_] == 86 || atype[t_] == 90)
                    {
                        if (aa[t_] + anobia[t_] - fx > xx[8] && aa[t_] - fx < xx[8] + xx[1] && ab[t_] + anobib[t_] - fy > xx[9] && ab[t_] - fy < xx[9] + xx[1])
                        {
                            ot(nオーディオ_[3]);
                            eyobi(ta[tt_] + 1200, tb[tt_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(ta[tt_] + 1200, tb[tt_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(ta[tt_] + 1200, tb[tt_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                            eyobi(ta[tt_] + 1200, tb[tt_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                            brockbreak(tt_);

                        }
                    }//90
                }
                //剣とってクリア
                if (ttype[tt_] == 140)
                {
                    if (ab[t_] - fy > xx[9] - xx[0] * 2 - 2000 && ab[t_] - fy < xx[9] + xx[1] - xx[0] * 2 + 2000 && aa[t_] + anobia[t_] - fx > xx[8] - 400 && aa[t_] - fx < xx[8] + xx[1])
                    {
                        ta[tt_] = -800000;//ot(oto[4]);
                        sracttype[20] = 1; sron[20] = 1;
                    }
                }
            }//tt

        }//tekizimen
    }
}
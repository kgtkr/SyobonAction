using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        //メッセージ
        static int nメッセージtm, nメッセージtype;

        static void DrawMsg()
        {
            //プレイヤーのメッセージ
            DXDraw.SetColorBlack();
            if (nメッセージtm >= 1)
            {
                nメッセージtm--;
                string xs_0 = "";

                if (nメッセージtype == 1) xs_0 = "お、おいしい!!";
                if (nメッセージtype == 2) xs_0 = "毒は無いが……";
                if (nメッセージtype == 3) xs_0 = "刺さった!!";
                if (nメッセージtype == 10) xs_0 = "食べるべきではなかった!!";
                if (nメッセージtype == 11) xs_0 = "俺は燃える男だ!!";
                if (nメッセージtype == 50) xs_0 = "体が……焼ける……";
                if (nメッセージtype == 51) xs_0 = "たーまやー!!";
                if (nメッセージtype == 52) xs_0 = "見事にオワタ";
                if (nメッセージtype == 53) xs_0 = "足が、足がぁ!!";
                if (nメッセージtype == 54) xs_0 = "流石は摂氏800度!!";
                if (nメッセージtype == 55) xs_0 = "溶岩と合体したい……";

                DXDraw.SetColorBlack();
                DXDraw.DrawString(xs_0, (ma + nプレイヤーnobia + 300) / 100 - 1, nプレイヤーb / 100 - 1);
                DXDraw.DrawString(xs_0, (ma + nプレイヤーnobia + 300) / 100 + 1, nプレイヤーb / 100 + 1);
                DXDraw.SetColorWhite();
                DXDraw.DrawString(xs_0, (ma + nプレイヤーnobia + 300) / 100, nプレイヤーb / 100);

            }//mmsgtm


            //敵キャラのメッセージ
            DXDraw.SetColorBlack();
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {
                if (n敵キャラmsgtm[t_] >= 1)
                {
                    n敵キャラmsgtm[t_]--;

                    string xs_0 = "";

                    if (n敵キャラmsgtype[t_] == 1001) xs_0 = "ヤッフー!!";
                    if (n敵キャラmsgtype[t_] == 1002) xs_0 = "え?俺勝っちゃったの?";
                    if (n敵キャラmsgtype[t_] == 1003) xs_0 = "貴様の死に場所はここだ!";
                    if (n敵キャラmsgtype[t_] == 1004) xs_0 = "二度と会う事もないだろう";
                    if (n敵キャラmsgtype[t_] == 1005) xs_0 = "俺、最強!!";
                    if (n敵キャラmsgtype[t_] == 1006) xs_0 = "一昨日来やがれ!!";
                    if (n敵キャラmsgtype[t_] == 1007) xs_0 = "漢に後退の二文字は無い!!";
                    if (n敵キャラmsgtype[t_] == 1008) xs_0 = "ハッハァ!!";

                    if (n敵キャラmsgtype[t_] == 1011) xs_0 = "ヤッフー!!";
                    if (n敵キャラmsgtype[t_] == 1012) xs_0 = "え?俺勝っちゃったの?";
                    if (n敵キャラmsgtype[t_] == 1013) xs_0 = "貴様の死に場所はここだ!";
                    if (n敵キャラmsgtype[t_] == 1014) xs_0 = "身の程知らずが……";
                    if (n敵キャラmsgtype[t_] == 1015) xs_0 = "油断が死を招く";
                    if (n敵キャラmsgtype[t_] == 1016) xs_0 = "おめでたい奴だ";
                    if (n敵キャラmsgtype[t_] == 1017) xs_0 = "屑が!!";
                    if (n敵キャラmsgtype[t_] == 1018) xs_0 = "無謀な……";

                    if (n敵キャラmsgtype[t_] == 1021) xs_0 = "ヤッフー!!";
                    if (n敵キャラmsgtype[t_] == 1022) xs_0 = "え?俺勝っちゃったの?";
                    if (n敵キャラmsgtype[t_] == 1023) xs_0 = "二度と会う事もないだろう";
                    if (n敵キャラmsgtype[t_] == 1024) xs_0 = "身の程知らずが……";
                    if (n敵キャラmsgtype[t_] == 1025) xs_0 = "僕は……負けない!!";
                    if (n敵キャラmsgtype[t_] == 1026) xs_0 = "貴様に見切れる筋は無い";
                    if (n敵キャラmsgtype[t_] == 1027) xs_0 = "今死ね、すぐ死ね、骨まで砕けろ!!";
                    if (n敵キャラmsgtype[t_] == 1028) xs_0 = "任務完了!!";

                    if (n敵キャラmsgtype[t_] == 1031) xs_0 = "ヤッフー!!";
                    if (n敵キャラmsgtype[t_] == 1032) xs_0 = "え?俺勝っちゃったの?";
                    if (n敵キャラmsgtype[t_] == 1033) xs_0 = "貴様の死に場所はここだ!";
                    if (n敵キャラmsgtype[t_] == 1034) xs_0 = "身の程知らずが……";
                    if (n敵キャラmsgtype[t_] == 1035) xs_0 = "油断が死を招く";
                    if (n敵キャラmsgtype[t_] == 1036) xs_0 = "おめでたい奴だ";
                    if (n敵キャラmsgtype[t_] == 1037) xs_0 = "屑が!!";
                    if (n敵キャラmsgtype[t_] == 1038) xs_0 = "無謀な……";

                    if (n敵キャラmsgtype[t_] == 15) xs_0 = "鉄壁!!よって、無敵!!";
                    if (n敵キャラmsgtype[t_] == 16) xs_0 = "丸腰で勝てるとでも?";
                    if (n敵キャラmsgtype[t_] == 17) xs_0 = "パリイ!!";
                    if (n敵キャラmsgtype[t_] == 18) xs_0 = "自業自得だ";
                    if (n敵キャラmsgtype[t_] == 20) xs_0 = "Zzz";
                    if (n敵キャラmsgtype[t_] == 21) xs_0 = "ク、クマー";
                    if (n敵キャラmsgtype[t_] == 24) xs_0 = "?";
                    if (n敵キャラmsgtype[t_] == 25) xs_0 = "食べるべきではなかった!!";
                    if (n敵キャラmsgtype[t_] == 30) xs_0 = "うめぇ!!";
                    if (n敵キャラmsgtype[t_] == 31) xs_0 = "ブロックを侮ったな?";
                    if (n敵キャラmsgtype[t_] == 32) xs_0 = "シャキーン";

                    if (n敵キャラmsgtype[t_] == 50) xs_0 = "波動砲!!";
                    if (n敵キャラmsgtype[t_] == 85) xs_0 = "裏切られたとでも思ったか?";
                    if (n敵キャラmsgtype[t_] == 86) xs_0 = "ポールアターック!!";


                    if (n敵キャラmsgtype[t_] != 31)
                    {
                        xx_5 = (n敵キャラa[t_] + n敵キャラnobia[t_] + 300 - fx) / 100; xx_6 = (n敵キャラb[t_] - fy) / 100;
                    }
                    else {
                        xx_5 = (n敵キャラa[t_] + n敵キャラnobia[t_] + 300 - fx) / 100; xx_6 = (n敵キャラb[t_] - fy - 800) / 100;
                    }

                    DX.ChangeFontType(DX.DX_FONTTYPE_EDGE);
                    DXDraw.SetColorWhite();
                    DXDraw.DrawString(xs_0, xx_5, xx_6);
                    DX.ChangeFontType(DX.DX_FONTTYPE_NORMAL);


                }//amsgtm
            }//amax
        }
    }
}

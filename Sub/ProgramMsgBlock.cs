﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;

namespace SyobonAction
{
    static partial class Program
    {
        //メッセージブロック
        static int nメッセージブロックtm, nメッセージブロックtype, nメッセージブロックy, nメッセージブロック;

        static void DrawMsgBlock()
        {
            //メッセージブロック
            if (nメッセージブロックtm > 0)
            {
                ttmsg();
                if (nメッセージブロックtype == 1)
                {
                    xx_0 = 1200;
                    nメッセージブロックy += xx_0;
                    if (nメッセージブロックtm == 1) { nメッセージブロックtm = 80000000; nメッセージブロックtype = 2; }
                }//1

                else if (nメッセージブロックtype == 2)
                {
                    nメッセージブロックy = 0; nメッセージブロックtype = 3; nメッセージブロックtm = 15 + 1;
                }

                else if (nメッセージブロックtype == 3)
                {
                    xx_0 = 1200;
                    nメッセージブロックy += xx_0;
                    if (nメッセージブロックtm == 15) DX.WaitKey();
                    if (nメッセージブロックtm == 1) { nメッセージブロックtm = 0; nメッセージブロックtype = 0; nメッセージブロックy = 0; }
                }//1

                nメッセージブロックtm--;
            }//tmsgtm
        }
    }
}

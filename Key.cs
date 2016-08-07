using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace SyobonAction
{
    public static class Key
    {

        public static void Init()
        {
            Key.key = Key.keyOld = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                key[i] = DX.FALSE;
            }
        }

        private static byte[] key;

        private static byte[] keyOld;

        public static void Update()
        {
            Key.keyOld = Key.key;
            Key.key = new byte[256];
            DX.GetHitKeyStateAll(out Key.key[0]);
        }

        public static bool GetKey(int code)
        {
            return Key.key[code] == DX.TRUE;
        }

        public static bool GetKeyDown(int code)
        {
            return Key.key[code] == DX.TRUE && Key.keyOld[code] == DX.FALSE;
        }

        public static  bool GetKeyUP(int code)
        {
            return Key.key[code] == DX.FALSE && Key.keyOld[code] == DX.TRUE;
        }
    }
}

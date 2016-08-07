using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyobonAction
{
     static partial class Program
    {
        //String 使用

        //プログラム中
        //main-10
        //タイトル-100
        static int main = 100, maintm = 0;

        //ステージ
        static int stagecolor = 0;
        static int sta = 1, stb = 4, stc = 0;

        //クイック
        static int fast = 1;

        //トラップ表示
        static int trap = 1;

        //中間ゲート
        static int tyuukan = 0;


        //スタッフロール
        static int ending = 0;


        //ステージ読み込みループ(いじらない)
        static int stagepoint;
        //オーバーフローさせる
        static int over = 0;

        //ステージスイッチ
        static int stageonoff = 0;


        static int maint;

        //描画
        static uint color;
        static int mirror;

        //ループ
        static int t1, t2, t3;


        //初期化
        static int zxon;

        //キーコンフィグ
        static int key, keytm;

        //三角関数
        static double pai = 3.1415926535;


        //地面
        const int smax = 31;
        static int sco;
        static int[] sa = new int[smax],
            sb = new int[smax], 
            sc = new int[smax],
            sd = new int[smax],
            stype = new int[smax], 
            sxtype = new int[smax],
            sr = new int[smax];
        static int[] sgtype=new int[smax];



        //プレイヤー
        static int mainmsgtype;
        static int mb, mnobia, mnobib, mhp;
        static int mc, md, atktm, nokori = 2, mactp, mact;

        static int mtype, mxtype, mtm, mzz;
        static int mzimen, mrzimen, mkasok, mmuki, mjumptm, mkeytm;
        static int mmutekitm, mmutekion;
        static int mztm, mztype;
        static int[] actaon=new int[7];
        //メッセージ
        static int mmsgtm, mmsgtype;

        static int mascrollmax = 21000;//9000




        //ブロック
        const int tmax = 641;
        static int tco;
        static int[] ta = new int[tmax],
            tb = new int[tmax],
            tc = new int[tmax],
            td = new int[tmax],
            thp = new int[tmax],
            ttype = new int[tmax];
        static int[] titem = new int[tmax],
            txtype = new int[tmax];

        //メッセージブロック
        static int tmsgtm, tmsgtype, tmsgy, tmsg;

        //効果を持たないグラ
        const int emax = 201;
        static int eco;
        static int[] ea = new int[emax],
            eb = new int[emax], 
            enobia = new int[emax], 
            enobib = new int[emax], 
            ec = new int[emax], 
            ed = new int[emax];
        static int[] ee = new int[emax],
            ef = new int[emax], 
            etm = new int[emax];
        static int[] egtype = new int[emax];



        //敵キャラ
        const int amax = 24;
        static int aco;
        static int[] aa = new int[amax],
            ab = new int[amax],
            anobia = new int[amax],
            anobib = new int[amax],
            ac = new int[amax],
            ad = new int[amax];
        static int[] ae = new int[amax],
            af = new int[amax],
            abrocktm = new int[amax];
        static int[] aacta = new int[amax],
            aactb = new int[amax],
            azimentype = new int[amax],
            axzimen = new int[amax];
        static int[] atype = new int[amax],
            axtype = new int[amax], 
            amuki = new int[amax], 
            ahp = new int[amax];
        static int[] anotm = new int[amax];
        static int[] atm = new int[amax],
            a2tm = new int[amax];
        static int[] amsgtm = new int[amax], 
            amsgtype = new int[amax];

        //敵出現
        const int bmax = 81;
        static int bco;
        static int[] ba = new int[bmax],
            bb = new int[bmax], 
            btm = new int[bmax];
        static int[] btype = new int[bmax], 
            bxtype = new int[bmax],
            bz = new int[bmax];


        //背景
        const int nmax = 41;
        static int nco;
        static int[] na = new int[nmax], 
            nb = new int[nmax], 
            nc = new int[nmax], 
            nd = new int[nmax], 
            ntype = new int[nmax];
        static int[] ng = new int[nmax],
            nx = new int[nmax];


        //リフト
        const int srmax = 21;
        static int srco;
        static int[] sra = new int[srmax],
            srb = new int[srmax], 
            src = new int[srmax], 
            srd = new int[srmax],
            sre = new int[srmax], 
            srf = new int[srmax];
        static int[] srtype = new int[srmax], 
            srgtype = new int[srmax], 
            sracttype = new int[srmax], 
            srsp = new int[srmax];
        static int[] srmuki = new int[srmax],
            sron = new int[srmax], 
            sree = new int[srmax];
        static int[] srsok = new int[srmax],
            srmovep = new int[srmax],
            srmove = new int[srmax];

        //スクロール範囲
        static int fx = 0, fy = 0, fzx, scrollx, scrolly;
        //全体のポイント
        static int fma = 0, fmb = 0;
        //強制スクロール
        static int kscroll = 0;
        //画面サイズ(ファミコンサイズ×2)(256-224)
        const int n画面幅 = 48000, n画面高さ = 42000;



        //ステージ
        static byte[,] stagedate=new byte[17,2001];

        //画面黒
        static int blacktm = 1, blackx = 0;



        //自由な値
        static int[] xx=new int[91];
        static double[] xd=new double[11];
        static string[] xs=new string[31];


        //タイマー測定
        static long stime;
    }
}

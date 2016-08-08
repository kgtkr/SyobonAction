using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyobonAction
{
    static partial class Program
    {
        static int ma;

        //String 使用

        //プログラム中
        //main-10
        //タイトル-100
        static E画面 e現在の画面 = E画面.Title;
        static int maintm = 0;

        enum E画面
        {
            Game=1,
            Title=100,
            Ending=2,
            機数表示=10,

        }

        //ステージ
        static int nステージ色 = 0;//1～5
        static int nステージa = 1, nステージb = 4, nステージc = 0;

        //クイック(trueにしたらどうなるか要検証)
        const bool bクイック = false;

        //トラップ表示(デパッグ)
        const bool bトラップ表示 = false;

        //中間ゲート
        static int n中間フラグ = 0;

        //スタッフロール
        static int nスタッフロール = 0;


        //ステージ読み込みループ(いじらない)
        static bool stagepoint;
        //オーバーフローさせる
        static int over;

        //ステージスイッチ
        static bool bステージスイッチ = false;

        //初期化
        static bool b初期化;

        //地面
        const int n地面max = 31;
        static int n地面co;
        static int[] n地面a = new int[n地面max],
            n地面b = new int[n地面max],
            n地面c = new int[n地面max],
            n地面d = new int[n地面max],
            n地面type = new int[n地面max],
            n地面xtype = new int[n地面max],
            n地面r = new int[n地面max];
        static int[] n地面gtype = new int[n地面max];



        //プレイヤー
        static int nプレイヤーainmsgtype;
        static int nプレイヤーb, nプレイヤーnobia, nプレイヤーnobib, nプレイヤーhp;
        static int nプレイヤーc,
            nプレイヤーd,
             nokori = 2, nプレイヤーactp, nプレイヤーact;

        static int nプレイヤーtype,
            nプレイヤーxtype,
            nプレイヤーtm,
            nプレイヤーzz;
        static int nプレイヤーzimen,
            nプレイヤーrzimen,
            nプレイヤーkasok,
            nプレイヤーmuki,
            nプレイヤーjumptm,
            nプレイヤーkeytm;
        static int nプレイヤーmutekitm;
        static int[] nプレイヤーactaon = new int[7];
        //メッセージ
        static int nメッセージtm, nメッセージtype;

        static int maScrollMax = 21000;//9000




        //ブロック
        const int nブロックmax = 641;
        static int nブロックco;
        static int[] nブロックa = new int[nブロックmax],
            nブロックb = new int[nブロックmax],
            nブロックc = new int[nブロックmax],
            nブロックd = new int[nブロックmax],
            nブロックhp = new int[nブロックmax],
            nブロックtype = new int[nブロックmax];
        static int[] nブロックitem = new int[nブロックmax],
            nブロックxtype = new int[nブロックmax];

        //メッセージブロック
        static int nメッセージブロックtm, nメッセージブロックtype, nメッセージブロックy, nメッセージブロック;

        //効果を持たないグラ
        const int n絵max = 201;
        static int n絵co;
        static int[] n絵a = new int[n絵max],
            n絵b = new int[n絵max],
            n絵nobia = new int[n絵max],
            n絵nobib = new int[n絵max],
            n絵c = new int[n絵max],
            n絵d = new int[n絵max];
        static int[] n絵e = new int[n絵max],
            n絵f = new int[n絵max],
            n絵tm = new int[n絵max];
        static int[] n絵gtype = new int[n絵max];



        //敵キャラ
        const int n敵キャラmax = 24;
        static int n敵キャラco;
        static int[] n敵キャラa = new int[n敵キャラmax],
            n敵キャラb = new int[n敵キャラmax],
            n敵キャラnobia = new int[n敵キャラmax],
            n敵キャラnobib = new int[n敵キャラmax],
            n敵キャラc = new int[n敵キャラmax],
            n敵キャラd = new int[n敵キャラmax];
        static int[] n敵キャラe = new int[n敵キャラmax],
            n敵キャラf = new int[n敵キャラmax],
            n敵キャラbrocktm = new int[n敵キャラmax];
        static int[] n敵キャラacta = new int[n敵キャラmax],
            n敵キャラactb = new int[n敵キャラmax],
            n敵キャラzimentype = new int[n敵キャラmax],
            n敵キャラxzimen = new int[n敵キャラmax];
        static int[] n敵キャラtype = new int[n敵キャラmax],
            n敵キャラxtype = new int[n敵キャラmax],
            n敵キャラmuki = new int[n敵キャラmax],
            n敵キャラhp = new int[n敵キャラmax];
        static int[] n敵キャラnotm = new int[n敵キャラmax];
        static int[] n敵キャラtm = new int[n敵キャラmax],
            n敵キャラ2tm = new int[n敵キャラmax];
        static int[] n敵キャラmsgtm = new int[n敵キャラmax],
            n敵キャラmsgtype = new int[n敵キャラmax];

        //敵出現
        const int n敵出現max = 81;
        static int n敵出現co;
        static int[] n敵出現a = new int[n敵出現max],
            n敵出現b = new int[n敵出現max],
            n敵出現tm = new int[n敵出現max];
        static int[] n敵出現type = new int[n敵出現max],
            n敵出現xtype = new int[n敵出現max],
            n敵出現z = new int[n敵出現max];


        //背景
        const int n背景max = 41;
        static int n背景co;
        static int[] n背景a = new int[n背景max],
            n背景b = new int[n背景max],
            n背景c = new int[n背景max],
            n背景d = new int[n背景max],
            n背景type = new int[n背景max];
        static int[] n背景g = new int[n背景max],
            n背景x = new int[n背景max];


        //リフト
        const int nリフトmax = 21;
        static int nリフトco;
        static int[] nリフトa = new int[nリフトmax],
            nリフトb = new int[nリフトmax],
            nリフトc = new int[nリフトmax],
            nリフトd = new int[nリフトmax],
            nリフトe = new int[nリフトmax],
            nリフトf = new int[nリフトmax];
        static int[] nリフトtype = new int[nリフトmax],
            nリフトgtype = new int[nリフトmax],
            nリフトacttype = new int[nリフトmax],
            nリフトsp = new int[nリフトmax];
        static int[] nリフトmuki = new int[nリフトmax],
            nリフトon = new int[nリフトmax],
            nリフトee = new int[nリフトmax];
        static int[] nリフトsok = new int[nリフトmax],
            nリフトmovep = new int[nリフトmax],
            nリフトmove = new int[nリフトmax];

        //スクロール範囲
        static int fx = 0, fy = 0, fzx, scrollX;
        //全体のポイント
        static int n全体のポイントa = 0, n全体のポイントb = 0;
        //強制スクロール
        static int n強制スクロール = 0;
        //画面サイズ(ファミコンサイズ×2)(256-224)
        const int n画面幅 = 48000, n画面高さ = 42000;



        //ステージ
        static byte[,] stageDate = new byte[17, 2001];

        //画面黒
        static int blackTm = 1, blackX = 0;



        //自由な値
        public static int[] xx = new int[91];
        static double[] xd = new double[11];
        static string[] xs = new string[31];


        //タイマー測定
        static long nタイマー測定;
    }
}
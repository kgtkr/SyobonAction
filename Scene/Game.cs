using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace SyobonAction
{
    public class Game : Scene
    {
        #region 変数
        int ma;

        //プログラム中
        //main-10
        //タイトル-100
        int maintm = 0;

        //ステージ
        int nステージ色 = 0;//1～5
        int nステージa = 1, nステージb = 4, nステージc = 0;

        //トラップ表示(デパッグ)
        public const bool bトラップ表示 = false;

        //中間ゲート
        int n中間フラグ = 0;

        //スタッフロール
        int nスタッフロール = 0;


        //ステージ読み込みループ(いじらない)
        bool stagepoint;
        //オーバーフローさせる
        int over;

        //ステージスイッチ
        bool bステージスイッチ = false;

        //初期化
        bool b初期化;

        int maScrollMax = 21000;//9000

        //スクロール範囲
        int fx = 0, fy = 0, fzx, scrollX;
        //全体のポイント
        int n全体のポイントa = 0, n全体のポイントb = 0;
        //強制スクロール
        int n強制スクロール = 0;
        

        //ステージ
        byte[,] stageDate = new byte[17, 2001];

        //画面黒
        int blackTm = 1, blackX = 0;

        #region xx
        public int xx_0;
        public int xx_1;
        public int xx_2;
        public int xx_3;
        public int xx_4;
        public int xx_5;
        public int xx_6;
        public int xx_7;
        public int xx_8;
        public int xx_9;
        public int xx_10;
        public int xx_11;
        public int xx_12;
        public int xx_13;
        public int xx_14;
        public int xx_15;
        public int xx_16;
        public int xx_17;
        public int xx_21;
        public int xx_22;
        public int xx_23;
        public int xx_24;
        public int xx_25;
        public int xx_26;
        #endregion
        #endregion
        public Game(int a,int b,int c,int lives,bool over)
        {
            nステージa = a;
            nステージb = b;
            nステージc = c;
            
        }

        public override void Draw()
        {
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

            DXDraw.DrawBox塗り潰し(0, 0, Program.W, Program.H);


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
                if (nプレイヤーainmsgtype >= 1)
                {
                    setfont(20, 4);
                    if (nプレイヤーainmsgtype == 1) { DX.DrawString(126, 100, "WELCOME TO OWATA ZONE", DX.GetColor(255, 255, 255)); }
                    if (nプレイヤーainmsgtype == 1) { for (int t2 = 0; t2 <= 2; t2++) DX.DrawString(88 + t2 * 143, 210, "1", DX.GetColor(255, 255, 255)); }
                    setfont(20, 5);
                }


                //画面黒
                if (blackTm > 0)
                {
                    blackTm--;
                    DXDraw.DrawBox塗り潰し(0, 0, Program.W, Program.H);
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
        }

        public override void Update()
        {
            if (nスタッフロール == 1) e現在の画面 = E画面.Ending;

            if (e現在の画面 == E画面.Game && nメッセージブロックtype == 0)
            {
                if (!b初期化)
                {
                    b初期化 = true;
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
                    bステージスイッチ = false;

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
                if (maintm >= 30)
                {
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
        }

        public void Stage()
        {
            //1-1
            if (nステージa == 1 && nステージb == 1 && nステージc == 0)
            {

                byte[,] stagedatex = stagedatex1;


                //追加情報
                tyobi(8 * 29, 9 * 29 - 12, 100);
                nブロックxtype[nブロックco] = 2;

                tyobi(13 * 29, 9 * 29 - 12, 102);
                nブロックxtype[nブロックco] = 0;

                tyobi(14 * 29, 5 * 29 - 12, 101);

                tyobi(35 * 29, 8 * 29 - 12, 110);

                tyobi(47 * 29, 9 * 29 - 12, 103);

                tyobi(59 * 29, 9 * 29 - 12, 112);

                tyobi(67 * 29, 9 * 29 - 12, 104);


                n地面co = 0;
                int t_ = n地面co;
                n地面a[t_] = 20 * 29 * 100 + 500;
                n地面b[t_] = -6000;
                n地面c[t_] = 5000;
                n地面d[t_] = 70000;
                n地面type[t_] = 100;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 54 * 29 * 100 - 500;
                n地面b[t_] = -6000;
                n地面c[t_] = 7000;
                n地面d[t_] = 70000;
                n地面type[t_] = 101;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 112 * 29 * 100 + 1000;
                n地面b[t_] = -6000;
                n地面c[t_] = 3000;
                n地面d[t_] = 70000;
                n地面type[t_] = 102;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 117 * 29 * 100;
                n地面b[t_] = (2 * 29 - 12) * 100 - 1500;
                n地面c[t_] = 15000;
                n地面d[t_] = 3000;
                n地面type[t_] = 103;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 125 * 29 * 100;
                n地面b[t_] = -6000;
                n地面c[t_] = 9000;
                n地面d[t_] = 70000;
                n地面type[t_] = 101;
                n地面co++;

                t_ = 28;
                n地面a[t_] = 29 * 29 * 100 + 500;
                n地面b[t_] = (9 * 29 - 12) * 100;
                n地面c[t_] = 6000;
                n地面d[t_] = 12000 - 200;
                n地面type[t_] = 50;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 49 * 29 * 100;
                n地面b[t_] = (5 * 29 - 12) * 100;
                n地面c[t_] = 9000 - 1;
                n地面d[t_] = 3000;
                n地面type[t_] = 51;
                n地面gtype[t_] = 0;
                n地面co++;

                t_ = n地面co;
                n地面a[t_] = 72 * 29 * 100;
                n地面b[t_] = (13 * 29 - 12) * 100;
                n地面c[t_] = 3000 * 5 - 1;
                n地面d[t_] = 3000;
                n地面type[t_] = 52;
                n地面co++;

                n敵出現co = 0;
                t_ = n敵出現co;
                n敵出現a[t_] = 27 * 29 * 100;
                n敵出現b[t_] = (9 * 29 - 12) * 100;
                n敵出現type[t_] = 0;
                n敵出現xtype[t_] = 0;
                n敵出現co++;

                t_ = n敵出現co;
                n敵出現a[t_] = 103 * 29 * 100;
                n敵出現b[t_] = (5 * 29 - 12 + 10) * 100;
                n敵出現type[t_] = 80;
                n敵出現xtype[t_] = 0;
                n敵出現co++;


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = 0; stageDate[i, tt_] = stagedatex[i, tt_];
                    }
                }

            }//sta1


            //1-2(地上)
            if (nステージa == 1 && nステージb == 2 && nステージc == 0)
            {

                //マリ　地上　入れ
                bgmChange(Res.nオーディオ_[100]);

                scrollX = 0 * 100;

                byte[,] stagedatex = stagedatex2;



                nブロックco = 0;
                //ヒント1
                nブロックxtype[nブロックco] = 1; tyobi(4 * 29, 9 * 29 - 12, 300);

                //毒1
                tyobi(13 * 29, 8 * 29 - 12, 114);

                //t=28;
                n地面co = 0;
                int t_ = n地面co; n地面a[t_] = 14 * 29 * 100 + 500; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 1; n地面co++;
                t_ = n地面co; n地面a[t_] = 12 * 29 * 100; n地面b[t_] = (11 * 29 - 12) * 100; n地面c[t_] = 3000; n地面d[t_] = 6000 - 200; n地面type[t_] = 40; n地面xtype[t_] = 0; n地面co++;
                t_ = n地面co; n地面a[t_] = 14 * 29 * 100 + 1000; n地面b[t_] = -6000; n地面c[t_] = 5000; n地面d[t_] = 70000; n地面type[t_] = 100; n地面xtype[t_] = 1; n地面co++;
                //ブロックもどき


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = 0; stageDate[i, tt_] = stagedatex[i, tt_];
                    }
                }

            }//sta2


            //1-2-1(地下)
            if (nステージa == 1 && nステージb == 2 && nステージc == 1)
            {

                //マリ　地下　入れ
                bgmChange(Res.nオーディオ_[103]);

                scrollX = 4080 * 100;
                ma = 6000; nプレイヤーb = 3000;
                nステージ色 = 2;


                byte[,] stagedatex = stagedatex3;



                nブロックco = 0;
                nブロックxtype[nブロックco] = 2; tyobi(7 * 29, 9 * 29 - 12, 102);

                tyobi(10 * 29, 9 * 29 - 12, 101);

                nブロックxtype[nブロックco] = 2;

                tyobi(49 * 29, 9 * 29 - 12, 114);

                for (int i = 0; i >= -7; i--)
                {

                    tyobi(53 * 29, i * 29 - 12, 1);
                }

                nブロックxtype[nブロックco] = 1; tyobi(80 * 29, 5 * 29 - 12, 104);
                nブロックxtype[nブロックco] = 2; tyobi(78 * 29, 5 * 29 - 12, 102);


                n地面co = 0;
                int t_ = n地面co; n地面a[t_] = 2 * 29 * 100; n地面b[t_] = (13 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 3000; n地面type[t_] = 52; n地面co++;
                t_ = n地面co; n地面a[t_] = 24 * 29 * 100; n地面b[t_] = (13 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 3000; n地面type[t_] = 52; n地面co++;
                t_ = n地面co; n地面a[t_] = 43 * 29 * 100 + 500; n地面b[t_] = -6000; n地面c[t_] = 3000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 1; n地面co++;
                t_ = n地面co; n地面a[t_] = 53 * 29 * 100 + 500; n地面b[t_] = -6000; n地面c[t_] = 3000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 2; n地面co++;
                t_ = n地面co; n地面a[t_] = 129 * 29 * 100; n地面b[t_] = (7 * 29 - 12) * 100; n地面c[t_] = 3000; n地面d[t_] = 6000 - 200; n地面type[t_] = 40; n地面xtype[t_] = 2; n地面co++;
                t_ = n地面co; n地面a[t_] = 154 * 29 * 100; n地面b[t_] = 3000; n地面c[t_] = 9000; n地面d[t_] = 3000; n地面type[t_] = 102; n地面xtype[t_] = 7; n地面co++;

                //ブロックもどき

                t_ = 27; n地面a[t_] = 69 * 29 * 100; n地面b[t_] = (1 * 29 - 12) * 100; n地面c[t_] = 9000 * 2 - 1; n地面d[t_] = 3000; n地面type[t_] = 51; n地面xtype[t_] = 0; n地面gtype[t_] = 0; n地面co++;
                t_ = 28; n地面a[t_] = 66 * 29 * 100; n地面b[t_] = (1 * 29 - 12) * 100; n地面c[t_] = 9000 - 1; n地面d[t_] = 3000; n地面type[t_] = 51; n地面xtype[t_] = 1; n地面gtype[t_] = 0; n地面co++;
                t_ = 29; n地面a[t_] = 66 * 29 * 100; n地面b[t_] = (-2 * 29 - 12) * 100; n地面c[t_] = 9000 * 3 - 1; n地面d[t_] = 3000; n地面type[t_] = 51; n地面xtype[t_] = 2; n地面gtype[t_] = 0; n地面co++;

                //26 ファイアー土管
                t_ = 26; n地面a[t_] = 103 * 29 * 100 - 1500; n地面b[t_] = (9 * 29 - 12) * 100 - 2000; n地面c[t_] = 3000; n地面d[t_] = 3000; n地面type[t_] = 180; n地面xtype[t_] = 0; n地面r[t_] = 0; n地面gtype[t_] = 48; n地面co++;
                t_ = n地面co; n地面a[t_] = 102 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 2; n地面co++;
                t_ = n地面co; n地面a[t_] = 123 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 3000 * 5 - 1; n地面d[t_] = 3000 * 5; n地面type[t_] = 52; n地面xtype[t_] = 1; n地面co++;

                t_ = n地面co; n地面a[t_] = 131 * 29 * 100; n地面b[t_] = (1 * 29 - 12) * 100; n地面c[t_] = 4700; n地面d[t_] = 3000 * 8 - 700; n地面type[t_] = 1; n地面xtype[t_] = 0; n地面co++;

                //オワタゾーン
                t_ = n地面co; n地面a[t_] = 143 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 5; n地面co++;
                t_ = n地面co; n地面a[t_] = 148 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 5; n地面co++;
                t_ = n地面co; n地面a[t_] = 153 * 29 * 100; n地面b[t_] = (9 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 12000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 5; n地面co++;



                n敵出現co = 0;
                t_ = n敵出現co; n敵出現a[t_] = 18 * 29 * 100; n敵出現b[t_] = (10 * 29 - 12) * 100; n敵出現type[t_] = 82; n敵出現xtype[t_] = 1; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 51 * 29 * 100 + 1000; n敵出現b[t_] = (2 * 29 - 12 + 10) * 100; n敵出現type[t_] = 80; n敵出現xtype[t_] = 1; n敵出現co++;

                //？ボール
                t_ = n敵出現co; n敵出現a[t_] = 96 * 29 * 100 + 100; n敵出現b[t_] = (10 * 29 - 12) * 100; n敵出現type[t_] = 105; n敵出現xtype[t_] = 0; n敵出現co++;


                //リフト
                nリフトco = 0;
                t_ = nリフトco; nリフトa[t_] = 111 * 29 * 100; nリフトb[t_] = (8 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 5; nリフトe[t_] = -300; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 111 * 29 * 100; nリフトb[t_] = (0 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 5; nリフトe[t_] = -300; nリフトco++;
                t_ = 10; nリフトa[t_] = 116 * 29 * 100; nリフトb[t_] = (4 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 1; nリフトacttype[t_] = 5; nリフトe[t_] = 300; nリフトco++;
                t_ = 11; nリフトa[t_] = 116 * 29 * 100; nリフトb[t_] = (12 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 1; nリフトacttype[t_] = 5; nリフトe[t_] = 300; nリフトco++;



                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = 0; stageDate[i, tt_] = stagedatex[i, tt_];
                    }
                }

            }//sta1-2-1




            //1-2(地上)
            if (nステージa == 1 && nステージb == 2 && nステージc == 2)
            {

                //マリ　地上　入れ
                bgmChange(Res.nオーディオ_[100]);

                scrollX = 900 * 100;
                ma = 7500; nプレイヤーb = 3000 * 9;

                byte[,] stagedatex = stagedatex4;

                int t_ = n地面co; n地面a[t_] = 5 * 29 * 100 + 500; n地面b[t_] = -6000; n地面c[t_] = 3000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 8; n地面co++;
                //空飛ぶ土管
                t_ = 28; n地面a[t_] = 44 * 29 * 100 + 500; n地面b[t_] = (10 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 9000 - 200; n地面type[t_] = 50; n地面co++;

                //ポールもどき
                n敵出現co = 0;
                t_ = n敵出現co; n敵出現a[t_] = 19 * 29 * 100; n敵出現b[t_] = (2 * 29 - 12) * 100; n敵出現type[t_] = 85; n敵出現xtype[t_] = 0; n敵出現co++;


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = 0; stageDate[i, tt_] = stagedatex[i, tt_];
                    }
                }

            }//sta2



            //必要BGM+SE

            //1-3(地上)
            if (nステージa == 1 && nステージb == 3 && nステージc == 6) { nステージc = 0; }
            if (nステージa == 1 && nステージb == 3 && nステージc == 0)
            {
                bgmChange(Res.nオーディオ_[100]);

                scrollX = 3900 * 100;
                //ma=3000;mb=3000;

                byte[,] stagedatex = stagedatex5;

                nブロックco = 0;

                tyobi(22 * 29, 3 * 29 - 12, 1);
                //毒1
                tyobi(54 * 29, 9 * 29 - 12, 116);
                //音符+
                tyobi(18 * 29, 14 * 29 - 12, 117);

                tyobi(19 * 29, 14 * 29 - 12, 117);

                tyobi(20 * 29, 14 * 29 - 12, 117);
                nブロックxtype[nブロックco] = 1; tyobi(61 * 29, 9 * 29 - 12, 101);//5

                tyobi(74 * 29, 9 * 29 - 12, 7);//6

                //ヒント2
                nブロックxtype[nブロックco] = 2; tyobi(28 * 29, 9 * 29 - 12, 300);//7
                                                                          //ファイア
                nブロックxtype[nブロックco] = 3; tyobi(7 * 29, 9 * 29 - 12, 101);
                //ヒント3
                nブロックxtype[nブロックco] = 4; tyobi(70 * 29, 8 * 29 - 12, 300);//9

                //もろいぶろっく×３
                nブロックxtype[nブロックco] = 1; tyobi(58 * 29, 13 * 29 - 12, 115);
                nブロックxtype[nブロックco] = 1; tyobi(59 * 29, 13 * 29 - 12, 115);
                nブロックxtype[nブロックco] = 1; tyobi(60 * 29, 13 * 29 - 12, 115);

                //ヒントブレイク
                nブロックxtype[nブロックco] = 0; tyobi(111 * 29, 6 * 29 - 12, 301);
                //ジャンプ
                nブロックxtype[nブロックco] = 0; tyobi(114 * 29, 9 * 29 - 12, 120);

                //ファイア
                n敵出現co = 0;
                int t_ = n敵出現co; n敵出現a[t_] = 101 * 29 * 100; n敵出現b[t_] = (5 * 29 - 12) * 100; n敵出現type[t_] = 4; n敵出現xtype[t_] = 1; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 146 * 29 * 100; n敵出現b[t_] = (10 * 29 - 12) * 100; n敵出現type[t_] = 6; n敵出現xtype[t_] = 1; n敵出現co++;

                t_ = n地面co; n地面a[t_] = 9 * 29 * 100; n地面b[t_] = (13 * 29 - 12) * 100; n地面c[t_] = 9000 - 1; n地面d[t_] = 3000; n地面type[t_] = 52; n地面co++;

                //土管
                t_ = n地面co; n地面a[t_] = 65 * 29 * 100 + 500; n地面b[t_] = (10 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 9000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 1; n地面co++;

                //トラップ
                t_ = n地面co; n地面a[t_] = 74 * 29 * 100; n地面b[t_] = (8 * 29 - 12) * 100 - 1500; n地面c[t_] = 6000; n地面d[t_] = 3000; n地面type[t_] = 103; n地面xtype[t_] = 1; n地面co++;
                t_ = n地面co; n地面a[t_] = 96 * 29 * 100 - 3000; n地面b[t_] = -6000; n地面c[t_] = 9000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 10; n地面co++;
                //ポール砲
                t_ = n地面co; n地面a[t_] = 131 * 29 * 100 - 1500; n地面b[t_] = (1 * 29 - 12) * 100 - 3000; n地面c[t_] = 15000; n地面d[t_] = 14000; n地面type[t_] = 104; n地面co++;


                //？ボール
                t_ = n敵出現co; n敵出現a[t_] = 10 * 29 * 100 + 100; n敵出現b[t_] = (11 * 29 - 12) * 100; n敵出現type[t_] = 105; n敵出現xtype[t_] = 1; n敵出現co++;
                //ブロックもどき
                t_ = n敵出現co; n敵出現a[t_] = 43 * 29 * 100; n敵出現b[t_] = (11 * 29 - 12) * 100; n敵出現type[t_] = 82; n敵出現xtype[t_] = 1; n敵出現co++;
                //うめぇ
                t_ = n敵出現co; n敵出現a[t_] = 1 * 29 * 100; n敵出現b[t_] = (2 * 29 - 12 + 10) * 100 - 1000; n敵出現type[t_] = 80; n敵出現xtype[t_] = 0; n敵出現co++;


                //リフト
                nリフトco = 0;
                t_ = nリフトco; nリフトa[t_] = 33 * 29 * 100; nリフトb[t_] = (3 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 1; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 39 * 29 * 100 - 2000; nリフトb[t_] = (6 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 1; nリフトe[t_] = 0; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 45 * 29 * 100 + 1500; nリフトb[t_] = (10 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 2; nリフトco++;

                t_ = nリフトco; nリフトa[t_] = 95 * 29 * 100; nリフトb[t_] = (7 * 29 - 12) * 100; nリフトc[t_] = 180 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 10; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 104 * 29 * 100; nリフトb[t_] = (9 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 12; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 117 * 29 * 100; nリフトb[t_] = (3 * 29 - 12) * 100; nリフトc[t_] = 90 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 1; nリフトe[t_] = 0; nリフトsp[t_] = 15; nリフトco++;
                t_ = nリフトco; nリフトa[t_] = 124 * 29 * 100; nリフトb[t_] = (5 * 29 - 12) * 100; nリフトc[t_] = 210 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトe[t_] = 0; nリフトsp[t_] = 10; nリフトco++;



                if (stagepoint) { stagepoint = false; ma = 4500; nプレイヤーb = -3000; n中間フラグ = 0; }


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = 0; stageDate[i, tt_] = stagedatex[i, tt_];
                    }
                }

            }//sta3



            //1-3(地下)
            if (nステージa == 1 && nステージb == 3 && nステージc == 1)
            {

                //マリ　地上　入れ
                bgmChange(Res.nオーディオ_[103]);

                scrollX = 0 * 100;
                ma = 6000; nプレイヤーb = 6000;
                nステージ色 = 2;


                byte[,] stagedatex = stagedatex6;


                nブロックco = 0;

                nステージc = 0;


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }

            }//sta3



            //1-3(空中)
            if (nステージa == 1 && nステージb == 3 && nステージc == 5)
            {

                nステージ色 = 3;

                bgmChange(Res.nオーディオ_[104]);

                scrollX = 0 * 100;
                ma = 3000; nプレイヤーb = 33000;

                stagepoint = true;

                byte[,] stagedatex = stagedatex7;

                n地面co = 0;
                int t_ = n地面co; n地面a[t_] = 14 * 29 * 100 - 5; n地面b[t_] = (11 * 29 - 12) * 100; n地面c[t_] = 6000; n地面d[t_] = 15000 - 200; n地面type[t_] = 50; n地面xtype[t_] = 1; n地面co++;


                nブロックxtype[nブロックco] = 0; tyobi(12 * 29, 4 * 29 - 12, 112);
                //ヒント3
                nブロックxtype[nブロックco] = 3; tyobi(12 * 29, 8 * 29 - 12, 300);

                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        stageDate[i, tt_] = 0; stageDate[i, tt_] = stagedatex[i, tt_];
                    }
                }

            }//sta5

            //1-4(地下)
            if (nステージa == 1 && nステージb == 4 && nステージc == 0)
            {

                //マリ　地上　入れ
                bgmChange(Res.nオーディオ_[105]);

                scrollX = 4400 * 100;
                ma = 12000; nプレイヤーb = 6000;
                nステージ色 = 4;


                byte[,] stagedatex = stagedatex8;

                n地面co = 0;//sco=140;
                int t_ = n地面co; n地面a[t_] = 35 * 29 * 100 - 1500 + 750; n地面b[t_] = (8 * 29 - 12) * 100 - 1500; n地面c[t_] = 1500; n地面d[t_] = 3000; n地面type[t_] = 105; n地面co++;
                t_ = n地面co; n地面a[t_] = 67 * 29 * 100; n地面b[t_] = (4 * 29 - 12) * 100; n地面c[t_] = 9000 - 1; n地面d[t_] = 3000 * 1 - 1; n地面type[t_] = 51; n地面xtype[t_] = 3; n地面gtype[t_] = 0; n地面co++;
                t_ = n地面co; n地面a[t_] = 73 * 29 * 100; n地面b[t_] = (13 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 3000; n地面type[t_] = 52; n地面co++;
                t_ = n地面co; n地面a[t_] = 123 * 29 * 100; n地面b[t_] = (1 * 29 - 12) * 100; n地面c[t_] = 30 * 6 * 100 - 1 + 0; n地面d[t_] = 3000 - 200; n地面type[t_] = 51; n地面xtype[t_] = 10; n地面co++;
                //スクロール消し
                t_ = n地面co; n地面a[t_] = 124 * 29 * 100 + 3000; n地面b[t_] = (2 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 300000; n地面type[t_] = 102; n地面xtype[t_] = 20; n地面co++;
                t_ = n地面co; n地面a[t_] = 148 * 29 * 100 + 1000; n地面b[t_] = (-12 * 29 - 12) * 100; n地面c[t_] = 3000 * 1 - 1; n地面d[t_] = 300000; n地面type[t_] = 102; n地面xtype[t_] = 30; n地面co++;

                //3連星
                t_ = n地面co; n地面a[t_] = 100 * 29 * 100 + 1000; n地面b[t_] = -6000; n地面c[t_] = 3000; n地面d[t_] = 70000; n地面type[t_] = 102; n地面xtype[t_] = 12; n地面co++;

                //地面1
                t_ = n地面co; n地面a[t_] = 0 * 29 * 100 - 0; n地面b[t_] = 9 * 29 * 100 + 1700; n地面c[t_] = 3000 * 7 - 1; n地面d[t_] = 3000 * 5 - 1; n地面type[t_] = 200; n地面xtype[t_] = 0; n地面co++;
                t_ = n地面co; n地面a[t_] = 11 * 29 * 100; n地面b[t_] = -1 * 29 * 100 + 1700; n地面c[t_] = 3000 * 8 - 1; n地面d[t_] = 3000 * 4 - 1; n地面type[t_] = 200; n地面xtype[t_] = 0; n地面co++;


                n敵出現co = 0;
                t_ = n敵出現co; n敵出現a[t_] = 8 * 29 * 100 - 1400; n敵出現b[t_] = (2 * 29 - 12) * 100 + 500; n敵出現type[t_] = 86; n敵出現xtype[t_] = 0; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 42 * 29 * 100 - 1400; n敵出現b[t_] = (-2 * 29 - 12) * 100 + 500; n敵出現type[t_] = 86; n敵出現xtype[t_] = 0; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 29 * 29 * 100 + 1500; n敵出現b[t_] = (7 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 105; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 47 * 29 * 100 + 1500; n敵出現b[t_] = (9 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 110; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 70 * 29 * 100 + 1500; n敵出現b[t_] = (9 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 105; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 66 * 29 * 100 + 1501; n敵出現b[t_] = (4 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 101; n敵出現co++;
                t_ = n敵出現co; n敵出現a[t_] = 85 * 29 * 100 + 1501; n敵出現b[t_] = (4 * 29 - 12) * 100 + 1500; n敵出現type[t_] = 87; n敵出現xtype[t_] = 105; n敵出現co++;

                //ステルスうめぇ
                t_ = n敵出現co; n敵出現a[t_] = 57 * 29 * 100; n敵出現b[t_] = (2 * 29 - 12 + 10) * 100 - 500; n敵出現type[t_] = 80; n敵出現xtype[t_] = 1; n敵出現co++;
                //ブロックもどき
                t_ = n敵出現co; n敵出現a[t_] = 77 * 29 * 100; n敵出現b[t_] = (5 * 29 - 12) * 100; n敵出現type[t_] = 82; n敵出現xtype[t_] = 2; n敵出現co++;
                //ボス
                t_ = n敵出現co; n敵出現a[t_] = 130 * 29 * 100; n敵出現b[t_] = (8 * 29 - 12) * 100; n敵出現type[t_] = 30; n敵出現xtype[t_] = 0; n敵出現co++;
                //クックル
                t_ = n敵出現co; n敵出現a[t_] = 142 * 29 * 100; n敵出現b[t_] = (10 * 29 - 12) * 100; n敵出現type[t_] = 31; n敵出現xtype[t_] = 0; n敵出現co++;

                //マグマ
                n背景co = 0;
                n背景a[n背景co] = 7 * 29 * 100 - 300;
                n背景b[n背景co] = 14 * 29 * 100 - 1200;
                n背景type[n背景co] = 6;
                n背景co++;
                if (n背景co >= n背景max) n背景co = 0;

                n背景a[n背景co] = 41 * 29 * 100 - 300;
                n背景b[n背景co] = 14 * 29 * 100 - 1200;
                n背景type[n背景co] = 6;
                n背景co++;

                if (n背景co >= n背景max) n背景co = 0;
                n背景a[n背景co] = 149 * 29 * 100 - 1100;
                n背景b[n背景co] = 10 * 29 * 100 - 600;
                //TODO 100を代入しているからマグマステージで例外が出る
                n背景type[n背景co] = 100;
                n背景co++;
                if (n背景co >= n背景max) n背景co = 0;

                nブロックco = 0;
                //ON-OFFブロック
                nブロックxtype[nブロックco] = 1; tyobi(29 * 29, 3 * 29 - 12, 130);
                //1-2
                tyobi(34 * 29, 9 * 29 - 12, 5);

                tyobi(35 * 29, 9 * 29 - 12, 5);
                //隠し
                tyobi(55 * 29 + 15, 6 * 29 - 12, 7);
                //隠しON-OFF
                nブロックxtype[nブロックco] = 10; tyobi(50 * 29, 9 * 29 - 12, 114);
                //ヒント3
                nブロックxtype[nブロックco] = 5; tyobi(1 * 29, 5 * 29 - 12, 300);
                //ファイア
                nブロックxtype[nブロックco] = 3;

                tyobi(86 * 29, 9 * 29 - 12, 101);
                //キノコなし　普通
                //音符
                nブロックxtype[nブロックco] = 2;

                tyobi(86 * 29, 6 * 29 - 12, 117);

                //もろいぶろっく×３
                for (int i = 0; i <= 2; i++)
                {
                    nブロックxtype[nブロックco] = 3; tyobi((79 + i) * 29, 13 * 29 - 12, 115);
                }

                //ジャンプ
                nブロックxtype[nブロックco] = 3; tyobi(105 * 29, 11 * 29 - 12, 120);
                //毒1
                nブロックxtype[nブロックco] = 3; tyobi(109 * 29, 7 * 29 - 12, 102);
                //デフラグ
                nブロックxtype[nブロックco] = 4; tyobi(111 * 29, 7 * 29 - 12, 101);
                //剣
                tyobi(132 * 29, 8 * 29 - 12 - 3, 140);

                tyobi(131 * 29, 9 * 29 - 12, 141);
                //メロン
                tyobi(161 * 29, 12 * 29 - 12, 142);
                //ファイアバー強化
                tyobi(66 * 29, 4 * 29 - 12, 124);


                //リフト
                nリフトco = 0;
                t_ = nリフトco; nリフトa[t_] = 93 * 29 * 100; nリフトb[t_] = (10 * 29 - 12) * 100; nリフトc[t_] = 60 * 100; nリフトtype[t_] = 0; nリフトacttype[t_] = 1; nリフトe[t_] = 0; nリフトco++;
                t_ = 20; nリフトa[t_] = 119 * 29 * 100 + 300; nリフトb[t_] = (10 * 29 - 12) * 100; nリフトc[t_] = 12 * 30 * 100 + 1000; nリフトtype[t_] = 0; nリフトacttype[t_] = 0; nリフトsp[t_] = 21; nリフトe[t_] = 0; nリフトco++;


                nステージc = 0;


                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }

            }//sta4

            if (nステージa == 2 && nステージb == 1 && nステージc == 0)
            {// 2-1
                ma = 5600;
                nプレイヤーb = 32000;

                bgmChange(Res.nオーディオ_[100]);
                nステージ色 = 1;
                scrollX = 2900 * (113 - 19);
                //
                byte[,] stagedatex = stagedatex9;
                //追加情報
                nブロックco = 0;
                //
                nブロックxtype[nブロックco] = 6;

                tyobi(1 * 29, 9 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(40 * 29, 9 * 29 - 12, 110);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 7;

                tyobi(79 * 29, 7 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 2;

                tyobi(83 * 29, 7 * 29 - 12, 102);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(83 * 29, 2 * 29 - 12, 114);
                nブロックco += 1;
                //
                for (int i = -1; i > -7; i -= 1)
                {

                    tyobi(85 * 29, i * 29 - 12, 4);
                    nブロックco += 1;
                }
                //
                n地面co = 0;
                n地面a[n地面co] = 30 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 12000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 51 * 29 * 100;
                n地面b[n地面co] = (4 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 51;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 84 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 105 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 15000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n敵出現co = 0;
                //
                n敵出現a[n敵出現co] = 6 * 29 * 100;
                n敵出現b[n敵出現co] = (3 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 13 * 29 * 100;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 4;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 23 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 25 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 27 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 88 * 29 * 100;
                n敵出現b[n敵出現co] = (12 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 2 && nステージc == 0)
            {//2-2(地上)

                bgmChange(Res.nオーディオ_[100]);
                nステージ色 = 1;
                scrollX = 2900 * (19 - 19);
                //
                byte[,] stagedatex = stagedatex10;
                //
                n地面a[n地面co] = 14 * 29 * 100 + 200;
                n地面b[n地面co] = -6000;
                n地面c[n地面co] = 5000;
                n地面d[n地面co] = 70000;
                n地面type[n地面co] = 100;
                n地面co += 1;
                //
                n地面a[n地面co] = 12 * 29 * 100 + 1200;
                n地面b[n地面co] = -6000;
                n地面c[n地面co] = 7000;
                n地面d[n地面co] = 70000;
                n地面type[n地面co] = 101;
                n地面co += 1;
                //
                n地面a[n地面co] = 12 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 6000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面gtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 14 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 12000 - 200;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 1;
                n地面co += 1;
                //
                tyobi(6 * 29, 9 * 29 - 12, 110);
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 2 && nステージc == 1)
            {//2-2(地下)

                bgmChange(Res.nオーディオ_[103]);
                nステージ色 = 2;
                ma = 7500; nプレイヤーb = 9000;
                scrollX = 2900 * (137 - 19);
                //
                byte[,] stagedatex = stagedatex11;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 32 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (-2 * 29 - 12) * 100 + 500;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = (31 * 29 - 12) * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 7;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 38 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 38 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 42 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 42 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 46 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 46 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 58 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 66 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 76 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (-2 * 29 - 12) * 100 + 500;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 2 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 300000 - 6001;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 3 * 29 * 100;
                n地面b[n地面co] = (7 * 29 - 12) * 100;
                n地面c[n地面co] = 3000;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 105;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 107 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 24000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 1;
                n地面co += 1;
                //
                n地面a[n地面co] = 111 * 29 * 100;
                n地面b[n地面co] = (7 * 29 - 12) * 100;
                n地面c[n地面co] = 3000;
                n地面d[n地面co] = 6000 - 200;
                n地面type[n地面co] = 40;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 113 * 29 * 100 + 1100;
                n地面b[n地面co] = (0 * 29 - 12) * 100;
                n地面c[n地面co] = 4700;
                n地面d[n地面co] = 27000 - 1000;
                n地面type[n地面co] = 0;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 128 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 24000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 1;
                n地面co += 1;
                //
                n地面a[n地面co] = 131 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 3000;
                n地面d[n地面co] = 6000 - 200;
                n地面type[n地面co] = 40;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 133 * 29 * 100 + 1100;
                n地面b[n地面co] = (0 * 29 - 12) * 100;
                n地面c[n地面co] = 4700;
                n地面d[n地面co] = 32000;
                n地面type[n地面co] = 0;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 0;

                tyobi(0 * 29, 0 * 29 - 12, 4);
                nブロックco = 1;
                nブロックxtype[nブロックco] = 0;

                tyobi(2 * 29, 9 * 29 - 12, 4);
                nブロックco = 2;
                nブロックxtype[nブロックco] = 0;

                tyobi(3 * 29, 9 * 29 - 12, 4);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(5 * 29, 9 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(6 * 29, 9 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(5 * 29, 10 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(6 * 29, 10 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(5 * 29, 11 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(6 * 29, 11 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(5 * 29, 12 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(6 * 29, 12 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(70 * 29, 7 * 29 - 12, 115);
                nブロックco += 1;
                nブロックxtype[nブロックco] = 1;

                tyobi(71 * 29, 7 * 29 - 12, 115);
                nブロックco += 1;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 2 && nステージc == 2)
            {// 2-2 地上
             //
                bgmChange(Res.nオーディオ_[100]);
                nステージ色 = 1;
                scrollX = 2900 * (36 - 19);
                ma = 7500;
                nプレイヤーb = 3000 * 9;
                //
                byte[,] stagedatex = stagedatex12;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 9 * 29 * 100;
                n敵出現b[n敵出現co] = (12 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 10 * 29 * 100;
                n敵出現b[n敵出現co] = (11 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 11 * 29 * 100;
                n敵出現b[n敵出現co] = (10 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 12 * 29 * 100;
                n敵出現b[n敵出現co] = (9 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 13 * 29 * 100;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 14 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 15 * 29 * 100;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 16 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 17 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 18 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 19 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 20 * 29 * 100;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }
            }
            //
            if (nステージa == 2 && nステージb == 3 && nステージc == 0)
            {// 2-3
                ma = 7500;
                nプレイヤーb = 3000 * 8;

                bgmChange(Res.nオーディオ_[100]);
                nステージ色 = 1;
                scrollX = 2900 * (126 - 19);
                //
                byte[,] stagedatex = stagedatex13;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 0;
                for (int i = -1; i > -7; i -= 1)
                {

                    tyobi(55 * 29, i * 29 - 12, 4);
                    nブロックco += 1;
                }
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(64 * 29, 12 * 29 - 12, 120);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(66 * 29, 3 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(67 * 29, 3 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(68 * 29, 3 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 8;

                tyobi(60 * 29, 6 * 29 - 12, 300);
                nブロックco += 1;
                n敵出現co = 1;
                n敵出現a[n敵出現co] = (54 * 29 - 12) * 100;
                n敵出現b[n敵出現co] = (1 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n地面co = 0;
                n敵出現a[n地面co] = (102 * 29 - 12) * 100;
                n敵出現b[n地面co] = (10 * 29 - 12) * 100;
                n敵出現type[n地面co] = 50;
                n敵出現xtype[n地面co] = 1;
                n地面co += 1;
                //
                nリフトco = 0;
                nリフトa[nリフトco] = 1 * 29 * 100;
                nリフトb[nリフトco] = (10 * 29 - 12) * 100;
                nリフトc[nリフトco] = 5 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 1;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 10;
                nリフトco++;
                //
                nリフトa[nリフトco] = 18 * 29 * 100;
                nリフトb[nリフトco] = (4 * 29 - 12) * 100;
                nリフトc[nリフトco] = 3 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 10;
                nリフトco++;
                //
                nリフトa[nリフトco] = 35 * 29 * 100;
                nリフトb[nリフトco] = (4 * 29 - 12) * 100;
                nリフトc[nリフトco] = 5 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 10;
                nリフトco++;
                //
                nリフトa[nリフトco] = 35 * 29 * 100;
                nリフトb[nリフトco] = (8 * 29 - 12) * 100;
                nリフトc[nリフトco] = 5 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 10;
                nリフトco++;
                //
                nリフトa[nリフトco] = 94 * 29 * 100;
                nリフトb[nリフトco] = (6 * 29 - 12) * 100;
                nリフトc[nリフトco] = 3 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 1;
                nリフトco++;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }
            }
            //
            if (nステージa == 2 && nステージb == 4 && (nステージc == 0 || nステージc == 10 || nステージc == 12))
            {// 2-4(1番)
                if (nステージc == 0)
                {
                    ma = 7500;
                    nプレイヤーb = 3000 * 4;
                }
                else {
                    ma = 19500;
                    nプレイヤーb = 3000 * 11;
                    nステージc = 0;
                }

                bgmChange(Res.nオーディオ_[105]);
                nステージ色 = 4;
                scrollX = 2900 * (40 - 19);
                //
                byte[,] stagedatex = stagedatex14;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 0;

                tyobi(0 * 29, -1 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(4 * 29, -1 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(1 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(6 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(7 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 2 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (-2 * 29 - 12) * 100 + 500;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 20 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (5 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 17 * 29 * 100;
                n地面b[n地面co] = (9 * 29 - 12) * 100;
                n地面c[n地面co] = 21000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 27 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 6000;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 6;
                n地面co += 1;
                //
                n地面a[n地面co] = 34 * 29 * 100;
                n地面b[n地面co] = (5 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 30000;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 1;
                n地面co += 1;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 4 && nステージc == 1)
            {// 2-4(2番)
                ma = 4500;
                nプレイヤーb = 3000 * 11;

                bgmChange(Res.nオーディオ_[105]);
                nステージ色 = 4;
                scrollX = 2900 * (21 - 19);
                //
                byte[,] stagedatex = stagedatex15;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 1;

                tyobi(12 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(13 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(14 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 6 * 29 * 100;
                n地面b[n地面co] = (6 * 29 - 12) * 100;
                n地面c[n地面co] = 18000 - 1;
                n地面d[n地面co] = 6000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 12 * 29 * 100;
                n地面b[n地面co] = (8 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 15 * 29 * 100;
                n地面b[n地面co] = (11 * 29 - 12) * 100;
                n地面c[n地面co] = 3000;
                n地面d[n地面co] = 6000;
                n地面type[n地面co] = 40;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 17 * 29 * 100 + 1100;
                n地面b[n地面co] = (0 * 29 - 12) * 100;
                n地面c[n地面co] = 4700;
                n地面d[n地面co] = 38000;
                n地面type[n地面co] = 0;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }
            }

            if (nステージa == 2 && nステージb == 4 && nステージc == 2)
            {// 2-4(3番)
                ma = 4500;
                nプレイヤーb = 3000 * 11;

                bgmChange(Res.nオーディオ_[105]);
                nステージ色 = 4;
                scrollX = 2900 * (128 - 19);
                //
                byte[,] stagedatex = stagedatex16;
                //
                nブロックco = 0;
                nブロックxtype[nブロックco] = 0;

                tyobi(1 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(2 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 9;

                tyobi(3 * 29, 4 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(32 * 29, 9 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(76 * 29, 14 * 29 - 12, 5);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(108 * 29, 11 * 29 - 12, 141);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(109 * 29, 10 * 29 - 12 - 3, 140);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 0;

                tyobi(121 * 29, 10 * 29 - 12, 142);
                nブロックco += 1;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 0 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 2 * 29 * 100;
                n敵出現b[n敵出現co] = (0 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 3 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 6 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 9 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 107;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 25 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (2 * 29 - 12) * 100 - 400;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 40 * 29 * 100;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 42 * 29 * 100;
                n敵出現b[n敵出現co] = (8 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 43 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 47 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 57 * 29 * 100;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 77 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (2 * 29 - 12) * 100 - 400;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 83 * 29 * 100 - 1400;
                n敵出現b[n敵出現co] = (2 * 29 - 12) * 100 - 400;
                n敵出現type[n敵出現co] = 86;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 88 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (9 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 88 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (9 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 90 * 29 * 100;
                n敵出現b[n敵出現co] = (9 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 107 * 29 * 100;
                n敵出現b[n敵出現co] = (10 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 30;
                n敵出現xtype[n敵出現co] = 0;
                n敵出現co += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 13 * 29 * 100;
                n地面b[n地面co] = (8 * 29 - 12) * 100;
                n地面c[n地面co] = 33000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 13 * 29 * 100;
                n地面b[n地面co] = (0 * 29 - 12) * 100;
                n地面c[n地面co] = 33000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 51;
                n地面xtype[n地面co] = 3;
                n地面co += 1;
                //
                n地面a[n地面co] = 10 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 6000;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 6;
                n地面co += 1;
                //
                n地面a[n地面co] = 46 * 29 * 100;
                n地面b[n地面co] = (12 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000 - 1;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 2;
                n地面co += 1;
                //
                n地面a[n地面co] = 58 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 6000;
                n地面d[n地面co] = 6000;
                n地面type[n地面co] = 50;
                n地面xtype[n地面co] = 6;
                n地面co += 1;
                //
                n地面a[n地面co] = 101 * 29 * 100 - 1500;
                n地面b[n地面co] = (10 * 29 - 12) * 100 - 3000;
                n地面c[n地面co] = 12000;
                n地面d[n地面co] = 12000;
                n地面type[n地面co] = 104;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 102 * 29 * 100 + 3000;
                n地面b[n地面co] = (2 * 29 - 12) * 100;
                n地面c[n地面co] = 3000 - 1;
                n地面d[n地面co] = 300000;
                n地面type[n地面co] = 102;
                n地面xtype[n地面co] = 20;
                n地面co += 1;
                //
                nリフトco = 0;
                nリフトa[nリフトco] = 74 * 29 * 100 - 1500;
                nリフトb[nリフトco] = (7 * 29 - 12) * 100;
                nリフトc[nリフトco] = 2 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 1;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 0;
                nリフトco = 20;
                //
                nリフトa[nリフトco] = 97 * 29 * 100;
                nリフトb[nリフトco] = (12 * 29 - 12) * 100;
                nリフトc[nリフトco] = 12 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 21;
                nリフトco += 1;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }
            }

            if (nステージa == 3 && nステージb == 1 && nステージc == 0)
            {// 3-1
                ma = 5600;
                nプレイヤーb = 32000;

                bgmChange(Res.nオーディオ_[100]);
                nステージ色 = 5;
                scrollX = 2900 * (112 - 19);
                byte[,] stagedatex = stagedatex17;
                //追加情報
                nブロックco = 0;
                //
                nブロックxtype[nブロックco] = 10;

                tyobi(2 * 29, 9 * 29 - 12, 300);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(63 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                nブロックxtype[nブロックco] = 1;

                tyobi(64 * 29, 13 * 29 - 12, 115);
                nブロックco += 1;
                //
                n地面co = 0;
                n地面a[n地面co] = 13 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n地面a[n地面co] = 84 * 29 * 100;
                n地面b[n地面co] = (13 * 29 - 12) * 100;
                n地面c[n地面co] = 9000 - 1;
                n地面d[n地面co] = 3000;
                n地面type[n地面co] = 52;
                n地面xtype[n地面co] = 0;
                n地面co += 1;
                //
                n敵出現co = 0;
                n敵出現a[n敵出現co] = 108 * 29 * 100;
                n敵出現b[n敵出現co] = (6 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 6;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 33 * 29 * 100;
                n敵出現b[n敵出現co] = (10 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 36 * 29 * 100;
                n敵出現b[n敵出現co] = (0 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 80;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 78 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 88;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 80 * 29 * 100 + 1500;
                n敵出現b[n敵出現co] = (7 * 29 - 12) * 100 + 1500;
                n敵出現type[n敵出現co] = 87;
                n敵出現xtype[n敵出現co] = 105;
                n敵出現co += 1;
                //
                n敵出現a[n敵出現co] = 85 * 29 * 100;
                n敵出現b[n敵出現co] = (11 * 29 - 12) * 100;
                n敵出現type[n敵出現co] = 82;
                n敵出現xtype[n敵出現co] = 1;
                n敵出現co += 1;
                //
                nリフトco = 0;
                nリフトa[nリフトco] = 41 * 29 * 100;
                nリフトb[nリフトco] = (3 * 29 - 12) * 100;
                nリフトc[nリフトco] = 3 * 3000;
                nリフトtype[nリフトco] = 0;
                nリフトacttype[nリフトco] = 0;
                nリフトe[nリフトco] = 0;
                nリフトsp[nリフトco] = 3;
                nリフトco = 0;
                //
                for (int tt_ = 0; tt_ <= 1000; tt_++)
                {
                    for (int t_ = 0; t_ <= 16; t_++)
                    {
                        stageDate[t_, tt_] = 0; stageDate[t_, tt_] = stagedatex[t_, tt_];
                    }
                }
            }
        }

        #region 色々
        //ブロック出現

        void tyobi(int x, int y, int type)
        {
            nブロックa[nブロックco] = x * 100; nブロックb[nブロックco] = y * 100; nブロックtype[nブロックco] = type;

            nブロックco++; if (nブロックco >= nブロックmax) nブロックco = 0;
        }//tyobi


        //ブロック破壊
        void brockBreak(int t)
        {
            nブロックa[t] = -800000;
        }//brock

        //グラ作成
        void eyobi(int xa, int xb, int xc, int xd, int xe, int xf, int xnobia, int xnobib, int xgtype, int xtm)
        {

            n絵a[n絵co] = xa; n絵b[n絵co] = xb; n絵c[n絵co] = xc; n絵d[n絵co] = xd; n絵e[n絵co] = xe; n絵f[n絵co] = xf;
            n絵gtype[n絵co] = xgtype; n絵tm[n絵co] = xtm;
            n絵nobia[n絵co] = xnobia; n絵nobib[n絵co] = xnobib;

            n絵co++;
            if (n絵co >= n絵max) n絵co = 0;

        }//eyobi


        //敵キャラ、アイテム作成
        void ayobi(int xa, int xb, int xc, int xd, int xnotm, int xtype, int xxtype)
        {
            int rz = 0;
            for (int t1 = 0; t1 <= 1; t1++)
            {
                t1 = 2;
                if (n敵キャラa[n敵キャラco] >= -9000 && n敵キャラa[n敵キャラco] <= 30000) t1 = 0; rz++;

                if (rz <= n敵キャラmax)
                {
                    t1 = 3;

                    n敵キャラa[n敵キャラco] = xa;
                    n敵キャラb[n敵キャラco] = xb;
                    n敵キャラc[n敵キャラco] = xc;
                    n敵キャラd[n敵キャラco] = xd;
                    if (xxtype > 100) n敵キャラc[n敵キャラco] = xxtype;
                    n敵キャラtype[n敵キャラco] = xtype;
                    if (xxtype >= 0 && xxtype <= 99100) n敵キャラxtype[n敵キャラco] = xxtype;//ahp[aco]=iz[bxtype[t]];aytm[aco]=0;
                                                                                     //if (xxtype==1)end();
                    n敵キャラnotm[n敵キャラco] = xnotm;
                    if (n敵キャラa[n敵キャラco] - fx <= ma + nプレイヤーnobia / 2) n敵キャラmuki[n敵キャラco] = 1;
                    if (n敵キャラa[n敵キャラco] - fx > ma + nプレイヤーnobia / 2) n敵キャラmuki[n敵キャラco] = 0;
                    if (n敵キャラbrocktm[n敵キャラco] >= 1) n敵キャラmuki[n敵キャラco] = 1;
                    if (n敵キャラbrocktm[n敵キャラco] == 20) n敵キャラmuki[n敵キャラco] = 0;

                    n敵キャラnobia[n敵キャラco] = Res.n敵サイズW_[n敵キャラtype[n敵キャラco]]; n敵キャラnobib[n敵キャラco] = Res.n敵サイズH_[n敵キャラtype[n敵キャラco]];



                    //大砲音
                    if (xtype == 7 && DX.CheckSoundMem(Res.nオーディオ_[10]) == 0) { v効果音再生(Res.nオーディオ_[10]); }
                    //ファイア音
                    if (xtype == 10 && DX.CheckSoundMem(Res.nオーディオ_[18]) == 0) { v効果音再生(Res.nオーディオ_[18]); }


                    n敵キャラzimentype[n敵キャラco] = 1;

                    if (xtype == 87) { n敵キャラtm[n敵キャラco] = DX.GetRand(179) + (-90); }

                    n敵キャラco += 1; if (n敵キャラco >= n敵キャラmax - 1) { n敵キャラco = 0; }
                }//t1

            }//rz

        }//ayobi

        void stagecls()
        {
            for (int t_ = 0; t_ < n地面max; t_++) { n地面a[t_] = -9000000; n地面b[t_] = 1; n地面c[t_] = 1; n地面d[t_] = 1; n地面gtype[t_] = 0; n地面type[t_] = 0; n地面xtype[t_] = 0; }
            for (int t_ = 0; t_ < nブロックmax; t_++) { nブロックa[t_] = -9000000; nブロックb[t_] = 1; nブロックc[t_] = 1; nブロックd[t_] = 1; nブロックitem[t_] = 0; nブロックxtype[t_] = 0; }
            for (int t_ = 0; t_ < nリフトmax; t_++) { nリフトa[t_] = -9000000; nリフトb[t_] = 1; nリフトc[t_] = 1; nリフトd[t_] = 1; nリフトe[t_] = 0; nリフトf[t_] = 0; nリフトmuki[t_] = 0; nリフトon[t_] = 0; nリフトee[t_] = 0; nリフトsok[t_] = 0; nリフトmove[t_] = 0; nリフトmovep[t_] = 0; nリフトsp[t_] = 0; }
            for (int t_ = 0; t_ < n敵キャラmax; t_++) { n敵キャラa[t_] = -9000000; n敵キャラb[t_] = 1; n敵キャラc[t_] = 0; n敵キャラd[t_] = 1; n敵キャラzimentype[t_] = 0; n敵キャラtype[t_] = 0; n敵キャラxtype[t_] = 0; n敵キャラe[t_] = 0; n敵キャラf[t_] = 0; n敵キャラtm[t_] = 0; n敵キャラ2tm[t_] = 0; n敵キャラbrocktm[t_] = 0; n敵キャラmsgtm[t_] = 0; }
            for (int t_ = 0; t_ < n敵出現max; t_++) { n敵出現a[t_] = -9000000; n敵出現b[t_] = 1; n敵出現z[t_] = 1; n敵出現tm[t_] = 0; n敵出現xtype[t_] = 0; }
            for (int t_ = 0; t_ < n絵max; t_++) { n絵a[t_] = -9000000; n絵b[t_] = 1; n絵c[t_] = 1; n絵d[t_] = 1; n絵gtype[t_] = 0; }
            for (int t_ = 0; t_ < n背景max; t_++)
            {
                n背景a[t_] = -9000000;
                n背景b[t_] = 1;
                n背景c[t_] = 1;
                n背景d[t_] = 1;
                Res.n背景サイズW_[t_] = 1;
                Res.n背景サイズH_[t_] = 1;
                n背景g[t_] = 0;
                n背景type[t_] = 0;
            }

            n地面co = 0; nブロックco = 0; n敵キャラco = 0; n敵出現co = 0; n絵co = 0; n背景co = 0;
        }//stagecls()

        //ステージロード
        void stage()
        {
            //fzx=6000*100;
            scrollX = 3600 * 100;

            stagep();


            for (int tt_ = 0; tt_ <= 1000; tt_++)
            {
                for (int t_ = 0; t_ <= 16; t_++)
                {
                    xx_10 = 0;
                    if (stageDate[t_, tt_] >= 1 && stageDate[t_, tt_] <= 255) xx_10 = (int)stageDate[t_, tt_];
                    xx_21 = tt_ * 29; xx_22 = t_ * 29 - 12; xx_23 = xx_10;
                    if (xx_10 >= 1 && xx_10 <= 19 && xx_10 != 9) { tyobi(tt_ * 29, t_ * 29 - 12, xx_10); }
                    if (xx_10 >= 20 && xx_10 <= 29) { nリフトa[nリフトco] = xx_21 * 100; nリフトb[nリフトco] = xx_22 * 100; nリフトc[nリフトco] = 3000; nリフトtype[nリフトco] = 0; nリフトco++; if (nリフトco >= nリフトmax) nリフトco = 0; }
                    if (xx_10 == 30) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100; n地面c[n地面co] = 3000; n地面d[n地面co] = 6000; n地面type[n地面co] = 500; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx_10 == 40) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100; n地面c[n地面co] = 6000; n地面d[n地面co] = 3000; n地面type[n地面co] = 1; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx_10 == 41) { n地面a[n地面co] = xx_21 * 100 + 500; n地面b[n地面co] = xx_22 * 100; n地面c[n地面co] = 5000; n地面d[n地面co] = 3000; n地面type[n地面co] = 2; n地面co++; if (n地面co >= n地面max) n地面co = 0; }

                    if (xx_10 == 43) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100 + 500; n地面c[n地面co] = 2900; n地面d[n地面co] = 5300; n地面type[n地面co] = 1; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                    if (xx_10 == 44) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100 + 700; n地面c[n地面co] = 3900; n地面d[n地面co] = 5000; n地面type[n地面co] = 5; n地面co++; if (n地面co >= n地面max) n地面co = 0; }

                    //これなぜかバグの原因ｗ
                    if (xx_10 >= 50 && xx_10 <= 79)
                    {
                        n敵出現a[n敵出現co] = xx_21 * 100; n敵出現b[n敵出現co] = xx_22 * 100; n敵出現type[n敵出現co] = xx_23 - 50; n敵出現co++; if (n敵出現co >= n敵出現max) n敵出現co = 0;
                    }

                    if (xx_10 >= 80 && xx_10 <= 89) { n背景a[n背景co] = xx_21 * 100; n背景b[n背景co] = xx_22 * 100; n背景type[n背景co] = xx_23 - 80; n背景co++; if (n背景co >= n背景max) n背景co = 0; }

                    //コイン
                    if (xx_10 == 9) { tyobi(tt_ * 29, t_ * 29 - 12, 800); }
                    if (xx_10 == 99) { n地面a[n地面co] = xx_21 * 100; n地面b[n地面co] = xx_22 * 100; n地面c[n地面co] = 3000; n地面d[n地面co] = (12 - t_) * 3000; n地面type[n地面co] = 300; n地面co++; if (n地面co >= n地面max) n地面co = 0; }
                }
            }

            if (n中間フラグ >= 1)
            {
                xx_17 = 0;
                for (int t_ = 0; t_ < n地面max; t_++)
                {
                    if (n地面type[t_] == 500 && n中間フラグ >= 1)
                    {
                        fx = n地面a[t_] - W / 2; fzx = fx;
                        ma = n地面a[t_] - fx;
                        nプレイヤーb = n地面b[t_] - fy;
                        n中間フラグ--; xx_17++;

                        n地面a[t_] = -80000000;
                    }
                }
                n中間フラグ += xx_17;
            }
        }//stage()

        void stagep()
        {

            //fzx=6000*100;
            scrollX = 3600 * 100;


            //1-レンガ,2-コイン,3-空,4-土台//5-6地面//7-隠し//

            //ステージ呼び出し
            Stage();

        }//stagep

        void tekizimen(int t_)
        {

            //壁
            for (int tt_ = 0; tt_ < n地面max; tt_++)
            {
                if (n地面a[tt_] - fx + n地面c[tt_] >= -12010 && n地面a[tt_] - fx <= W + 12100 && n地面type[tt_] <= 99)
                {
                    xx_0 = 200; xx_2 = 1000;
                    xx_1 = 2000;//anobia[t]

                    xx_8 = n地面a[tt_] - fx; xx_9 = n地面b[tt_] - fy;
                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 - xx_0 && n敵キャラa[t_] - fx < xx_8 + xx_2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_1 * 3 / 4 && n敵キャラb[t_] - fy < xx_9 + n地面d[tt_] - xx_2) { n敵キャラa[t_] = xx_8 - xx_0 - n敵キャラnobia[t_] + fx; n敵キャラmuki[t_] = 0; }
                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + n地面c[tt_] - xx_0 && n敵キャラa[t_] - fx < xx_8 + n地面c[tt_] + xx_0 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_1 * 3 / 4 && n敵キャラb[t_] - fy < xx_9 + n地面d[tt_] - xx_2) { n敵キャラa[t_] = xx_8 + n地面c[tt_] + xx_0 + fx; n敵キャラmuki[t_] = 1; }

                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 && n敵キャラa[t_] - fx < xx_8 + n地面c[tt_] - xx_0 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + n地面d[tt_] - xx_1 && n敵キャラd[t_] >= -100) { n敵キャラb[t_] = n地面b[tt_] - fy - n敵キャラnobib[t_] + 100 + fy; n敵キャラd[t_] = 0; n敵キャラxzimen[t_] = 1; }

                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 && n敵キャラa[t_] - fx < xx_8 + n地面c[tt_] - xx_0 && n敵キャラb[t_] - fy > xx_9 + n地面d[tt_] - xx_1 && n敵キャラb[t_] - fy < xx_9 + n地面d[tt_] + xx_0)
                    {
                        n敵キャラb[t_] = xx_9 + n地面d[tt_] + xx_0 + fy; if (n敵キャラd[t_] < 0) { n敵キャラd[t_] = -n敵キャラd[t_] * 2 / 3; }//axzimen[t]=1;
                    }

                }
            }

            //ブロック
            for (int tt_ = 0; tt_ < nブロックmax; tt_++)
            {
                xx_0 = 200; xx_1 = 3000; xx_2 = 1000;
                xx_8 = nブロックa[tt_] - fx; xx_9 = nブロックb[tt_] - fy;
                if (nブロックa[tt_] - fx + xx_1 >= -12010 && nブロックa[tt_] - fx <= W + 12000)
                {
                    if (n敵キャラtype[t_] != 86 && n敵キャラtype[t_] != 90 && nブロックtype[tt_] != 140)
                    {

                        //上
                        if (nブロックtype[tt_] != 7)
                        {
                            if (!(nブロックtype[tt_] == 117))
                            {
                                if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 && n敵キャラa[t_] - fx < xx_8 + xx_1 - xx_0 * 1 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 && n敵キャラd[t_] >= -100)
                                {
                                    n敵キャラb[t_] = xx_9 - n敵キャラnobib[t_] + 100 + fy; n敵キャラd[t_] = 0; n敵キャラxzimen[t_] = 1;
                                    //ジャンプ台
                                    if (nブロックtype[tt_] == 120) { n敵キャラd[t_] = -1600; n敵キャラzimentype[t_] = 30; }
                                }
                            }
                        }

                        //下
                        if (nブロックtype[tt_] != 117)
                        {
                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 && n敵キャラa[t_] - fx < xx_8 + xx_1 - xx_0 * 1 && n敵キャラb[t_] - fy > xx_9 + xx_1 - xx_1 && n敵キャラb[t_] - fy < xx_9 + xx_1 + xx_0)
                            {
                                n敵キャラb[t_] = xx_9 + xx_1 + xx_0 + fy; if (n敵キャラd[t_] < 0) { n敵キャラd[t_] = 0; }                                                             //}
                            }
                        }

                        //左右
                        int xx_27 = 0;
                        if ((n敵キャラtype[t_] >= 100 || (nブロックtype[tt_] != 7 || nブロックtype[tt_] == 7 && n敵キャラtype[t_] == 2)) && nブロックtype[tt_] != 117)
                        {
                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 && n敵キャラa[t_] - fx < xx_8 + xx_2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_1 / 2 - xx_0 && n敵キャラb[t_] - fy < xx_9 + xx_2) { n敵キャラa[t_] = xx_8 - n敵キャラnobia[t_] + fx; n敵キャラc[t_] = 0; n敵キャラmuki[t_] = 0; xx_27 = 1; }
                            if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_1 - xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + xx_1 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_1 / 2 - xx_0 && n敵キャラb[t_] - fy < xx_9 + xx_2) { n敵キャラa[t_] = xx_8 + xx_1 + fx; n敵キャラc[t_] = 0; n敵キャラmuki[t_] = 1; xx_27 = 1; }
                            //こうらブレイク
                            if (xx_27 == 1 && (nブロックtype[tt_] == 7 || nブロックtype[tt_] == 1) && n敵キャラtype[t_] == 2)
                            {
                                if (nブロックtype[tt_] == 7)
                                {
                                    v効果音再生(Res.nオーディオ_[4]); nブロックtype[tt_] = 3;
                                    eyobi(nブロックa[tt_] + 10, nブロックb[tt_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                }
                                else if (nブロックtype[tt_] == 1)
                                {
                                    v効果音再生(Res.nオーディオ_[3]);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                    brockBreak(tt_);
                                }

                            }
                        }
                    }
                    if (n敵キャラtype[t_] == 86 || n敵キャラtype[t_] == 90)
                    {
                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 && n敵キャラa[t_] - fx < xx_8 + xx_1 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 && n敵キャラb[t_] - fy < xx_9 + xx_1)
                        {
                            v効果音再生(Res.nオーディオ_[3]);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[tt_] + 1200, nブロックb[tt_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                            brockBreak(tt_);

                        }
                    }//90
                }
                //剣とってクリア
                if (nブロックtype[tt_] == 140)
                {
                    if (n敵キャラb[t_] - fy > xx_9 - xx_0 * 2 - 2000 && n敵キャラb[t_] - fy < xx_9 + xx_1 - xx_0 * 2 + 2000 && n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 - 400 && n敵キャラa[t_] - fx < xx_8 + xx_1)
                    {
                        nブロックa[tt_] = -800000;
                        nリフトacttype[20] = 1; nリフトon[20] = 1;
                    }
                }
            }

        }
        #endregion
        #region 背景
        //背景
        const int n背景max = 41;
        int n背景co;
        int[] n背景a = new int[n背景max],
            n背景b = new int[n背景max],
            n背景c = new int[n背景max],
            n背景d = new int[n背景max],
            n背景type = new int[n背景max];
        int[] n背景g = new int[n背景max],
            n背景x = new int[n背景max];

        void DrawBack()
        {
            //背景
            for (int t_ = 0; t_ < n背景max; t_++)
            {
                xx_0 = n背景a[t_] - fx;
                xx_1 = n背景b[t_] - fy;
                xx_2 = 16000;
                xx_3 = 16000;

                if (xx_0 + xx_2 >= -10 && xx_0 <= W && xx_1 + xx_3 >= -10 && xx_3 <= H)
                {

                    if (n背景type[t_] != 3)
                    {
                        if ((n背景type[t_] == 1 || n背景type[t_] == 2) && nステージ色 == 5)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[n背景type[t_] + 30, 4], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像_[n背景type[t_], 4], xx_0 / 100, xx_1 / 100);
                        }
                    }
                    if (n背景type[t_] == 3)
                        DXDraw.DrawGraph(Res.n切り取り画像_[n背景type[t_], 4], xx_0 / 100 - 5, xx_1 / 100);

                    //51
                    if (n背景type[t_] == 100)
                    {
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "51", DX.GetColor(255, 255, 255));
                    }

                    if (n背景type[t_] == 101)
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "ゲームクリアー", DX.GetColor(255, 255, 255));
                    if (n背景type[t_] == 102)
                        DX.DrawString(xx_0 / 100 + n全体のポイントa, xx_1 / 100 + n全体のポイントb, "プレイしてくれてありがとー", DX.GetColor(255, 255, 255));

                }
            }//t
        }
        #endregion
        #region ブロック
        //ブロック
        const int nブロックmax = 641;
        int nブロックco;
        int[] nブロックa = new int[nブロックmax],
            nブロックb = new int[nブロックmax],
            nブロックc = new int[nブロックmax],
            nブロックd = new int[nブロックmax],
            nブロックhp = new int[nブロックmax],
            nブロックtype = new int[nブロックmax];
        int[] nブロックitem = new int[nブロックmax],
            nブロックxtype = new int[nブロックmax];

        void UpdateBlock()
        {
            //ブロック
            //1-れんが、コイン、無し、土台、7-隠し
            xx_15 = 0;
            for (int t_ = 0; t_ < nブロックmax; t_++)
            {
                xx_0 = 200; xx_1 = 3000; xx_2 = 1000; xx_3 = 3000;//xx_2=1000
                xx_8 = nブロックa[t_] - fx; xx_9 = nブロックb[t_] - fy;//xx_15=0;
                if (nブロックa[t_] - fx + xx_1 >= -10 - xx_3 && nブロックa[t_] - fx <= W + 12000 + xx_3)
                {
                    if (nプレイヤーtype != 200 && nプレイヤーtype != 1 && nプレイヤーtype != 2)
                    {
                        if (nブロックtype[t_] < 1000 && nブロックtype[t_] != 800 && nブロックtype[t_] != 140 && nブロックtype[t_] != 141)
                        {
                            xx_16 = 0; xx_17 = 0;

                            //上
                            if (nブロックtype[t_] != 7 && nブロックtype[t_] != 110 && !(nブロックtype[t_] == 114))
                            {
                                if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 + 100 && ma < xx_8 + xx_1 - xx_0 * 2 - 100 && nプレイヤーb + nプレイヤーnobib > xx_9 && nプレイヤーb + nプレイヤーnobib < xx_9 + xx_1 && nプレイヤーd >= -100)
                                {
                                    if (nブロックtype[t_] != 115 && nブロックtype[t_] != 400 && nブロックtype[t_] != 117 && nブロックtype[t_] != 118 && nブロックtype[t_] != 120)
                                    {
                                        nプレイヤーb = xx_9 - nプレイヤーnobib + 100; nプレイヤーd = 0; nプレイヤーzimen = 1; xx_16 = 1;
                                    }
                                    else if (nブロックtype[t_] == 115)
                                    {
                                        v効果音再生(Res.nオーディオ_[3]);
                                        eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                        eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                        eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                        eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                        brockBreak(t_);
                                    }
                                    //Pスイッチ
                                    else if (nブロックtype[t_] == 400)
                                    {
                                        nプレイヤーd = 0; nブロックa[t_] = -8000000; v効果音再生(Res.nオーディオ_[13]);
                                        for (int tt_ = 0; tt_ < nブロックmax; tt_++) { if (nブロックtype[tt_] != 7) { nブロックtype[tt_] = 800; } }
                                    }

                                    //音符+
                                    else if (nブロックtype[t_] == 117)
                                    {
                                        v効果音再生(Res.nオーディオ_[14]);
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


                            //sstr=""+mjumptm;
                            //ブロック判定の入れ替え
                            xx_21 = 0; xx_22 = 1;//xx_12=0;
                            if (nプレイヤーzimen == 1 || nプレイヤーjumptm >= 10) { xx_21 = 3; xx_22 = 0; }
                            for (int t3 = 0; t3 <= 1; t3++)
                            {

                                //下
                                if (t3 == xx_21 && nプレイヤーtype != 100 && nブロックtype[t_] != 117)
                                {// && xx_12==0){
                                    if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 + 800 && ma < xx_8 + xx_1 - xx_0 * 2 - 800 && nプレイヤーb > xx_9 - xx_0 * 2 && nプレイヤーb < xx_9 + xx_1 - xx_0 * 2 && nプレイヤーd <= 0)
                                    {
                                        xx_16 = 1; xx_17 = 1;
                                        nプレイヤーb = xx_9 + xx_1 + xx_0; if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd * 2 / 3; }//}
                                                                                                                      //壊れる
                                        if (nブロックtype[t_] == 1 && nプレイヤーzimen == 0)
                                        {
                                            v効果音再生(Res.nオーディオ_[3]);
                                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                            brockBreak(t_);
                                        }
                                        //コイン
                                        if (nブロックtype[t_] == 2 && nプレイヤーzimen == 0)
                                        {
                                            v効果音再生(Res.nオーディオ_[4]);
                                            eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                            nブロックtype[t_] = 3;
                                        }
                                        //隠し
                                        if (nブロックtype[t_] == 7)
                                        {
                                            v効果音再生(Res.nオーディオ_[4]);
                                            eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                            nプレイヤーb = xx_9 + xx_1 + xx_0; nブロックtype[t_] = 3; if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd * 2 / 3; }
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
                                if (t3 == xx_22 && xx_15 == 0)
                                {
                                    if (nブロックtype[t_] != 7 && nブロックtype[t_] != 110 && nブロックtype[t_] != 117)
                                    {
                                        if (!(nブロックtype[t_] == 114))
                                        {// && txtype[t]==1)){
                                            if (nブロックa[t_] >= -20000)
                                            {
                                                if (ma + nプレイヤーnobia > xx_8 && ma < xx_8 + xx_2 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_1 / 2 - xx_0 && nプレイヤーb < xx_9 + xx_2 && nプレイヤーc >= 0)
                                                {
                                                    ma = xx_8 - nプレイヤーnobia; nプレイヤーc = 0; xx_16 = 1;
                                                }
                                                if (ma + nプレイヤーnobia > xx_8 + xx_2 && ma < xx_8 + xx_1 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_1 / 2 - xx_0 && nプレイヤーb < xx_9 + xx_2 && nプレイヤーc <= 0)
                                                {
                                                    ma = xx_8 + xx_1; nプレイヤーc = 0; xx_16 = 1;//end();
                                                }
                                            }
                                        }
                                    }
                                }

                            }//t3

                        }// && ttype[t]<50

                        if (nブロックtype[t_] == 800)
                        {
                            if (nプレイヤーb > xx_9 - xx_0 * 2 - 2000 && nプレイヤーb < xx_9 + xx_1 - xx_0 * 2 + 2000 && ma + nプレイヤーnobia > xx_8 - 400 && ma < xx_8 + xx_1)
                            {
                                nブロックa[t_] = -800000; v効果音再生(Res.nオーディオ_[4]);
                            }
                        }

                        //剣とってクリア
                        if (nブロックtype[t_] == 140)
                        {
                            if (nプレイヤーb > xx_9 - xx_0 * 2 - 2000 && nプレイヤーb < xx_9 + xx_1 - xx_0 * 2 + 2000 && ma + nプレイヤーnobia > xx_8 - 400 && ma < xx_8 + xx_1)
                            {
                                nブロックa[t_] = -800000;//ot(oto[4]);
                                nリフトacttype[20] = 1; nリフトon[20] = 1;
                                DX.StopSoundMem(Res.nオーディオ_[0]); nプレイヤーtype = 301; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[16]);

                            }
                        }


                        //特殊的
                        if (nブロックtype[t_] == 100)
                        {
                            if (nプレイヤーb > xx_9 - xx_0 * 2 - 2000 && nプレイヤーb < xx_9 + xx_1 - xx_0 * 2 + 2000 && ma + nプレイヤーnobia > xx_8 - 400 && ma < xx_8 + xx_1 && nプレイヤーd <= 0)
                            {
                                if (nブロックxtype[t_] == 0) nブロックb[t_] = nプレイヤーb + fy - 1200 - xx_1;
                            }

                            if (nブロックxtype[t_] == 1)
                            {
                                if (xx_17 == 1)
                                {
                                    if (ma + nプレイヤーnobia > xx_8 - 400 && ma < xx_8 + xx_1 / 2 - 1500) { nブロックa[t_] += 3000; }
                                    else if (ma + nプレイヤーnobia >= xx_8 + xx_1 / 2 - 1500 && ma < xx_8 + xx_1) { nブロックa[t_] -= 3000; }
                                }
                            }

                            if (xx_17 == 1 && nブロックxtype[t_] == 0)
                            {
                                v効果音再生(Res.nオーディオ_[4]);
                                eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                nブロックtype[t_] = 3;
                            }
                        }//100

                        //敵出現
                        if (nブロックtype[t_] == 101)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
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
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
                                nブロックtype[t_] = 3; n敵キャラbrocktm[n敵キャラco] = 16;
                                if (nブロックxtype[t_] == 0) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 100, 0);
                                if (nブロックxtype[t_] == 2) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 100, 2);
                                if (nブロックxtype[t_] == 3) ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 102, 1);
                            }
                        }//102

                        //まずいきのこ出現
                        if (nブロックtype[t_] == 103)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
                                nブロックtype[t_] = 3; n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 100, 1);
                            }
                        }//103


                        //悪スター出し
                        if (nブロックtype[t_] == 104)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
                                nブロックtype[t_] = 3; n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 110, 0);
                            }
                        }//104




                        //毒きのこ量産
                        if (nブロックtype[t_] == 110)
                        {
                            if (xx_17 == 1)
                            {
                                nブロックtype[t_] = 111; nブロックhp[t_] = 999;
                            }
                        }//110
                        if (nブロックtype[t_] == 111 && nブロックa[t_] - fx >= 0)
                        {
                            nブロックhp[t_]++; if (nブロックhp[t_] >= 16)
                            {
                                nブロックhp[t_] = 0;
                                v効果音再生(Res.nオーディオ_[8]);
                                n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 102, 1);
                            }
                        }


                        //コイン量産
                        if (nブロックtype[t_] == 112)
                        {
                            if (xx_17 == 1)
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
                                v効果音再生(Res.nオーディオ_[4]);
                                eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16);
                                //ttype[t]=3;
                            }
                        }


                        //隠し毒きのこ
                        if (nブロックtype[t_] == 114)
                        {
                            if (xx_17 == 1)
                            {
                                if (nブロックxtype[t_] == 0)
                                {
                                    v効果音再生(Res.nオーディオ_[8]); nブロックtype[t_] = 3;
                                    n敵キャラbrocktm[n敵キャラco] = 16; ayobi(nブロックa[t_], nブロックb[t_], 0, 0, 0, 102, 1);
                                }
                                if (nブロックxtype[t_] == 2) { v効果音再生(Res.nオーディオ_[4]); eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16); nブロックtype[t_] = 115; nブロックxtype[t_] = 0; }
                                if (nブロックxtype[t_] == 10)
                                {
                                    if (bステージスイッチ) { nブロックtype[t_] = 130; bステージスイッチ = false; v効果音再生(Res.nオーディオ_[13]); nブロックxtype[t_] = 2; for (t_ = 0; t_ < n敵キャラmax; t_++) { if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88) { if (n敵キャラxtype[t_] == 105) { n敵キャラxtype[t_] = 110; } } } }
                                    else { v効果音再生(Res.nオーディオ_[4]); eyobi(nブロックa[t_] + 10, nブロックb[t_], 0, -800, 0, 40, 3000, 3000, 0, 16); nブロックtype[t_] = 3; }
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
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[8]);
                                //ot(oto[13]);
                                nブロックtype[t_] = 3;//abrocktm[aco]=18;ayobi(ta[t],tb[t],0,0,0,104,1);
                                tyobi(nブロックa[t_] / 100, (nブロックb[t_] / 100) - 29, 400);
                            }
                        }//116


                        //ファイアバー強化
                        if (nブロックtype[t_] == 124)
                        {
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[13]);
                                for (t_ = 0; t_ < n敵キャラmax; t_++) { if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88) { if (n敵キャラxtype[t_] == 101) { n敵キャラxtype[t_] = 120; } } }
                                nブロックtype[t_] = 3;
                            }
                        }

                        //ONスイッチ
                        if (nブロックtype[t_] == 130)
                        {
                            if (xx_17 == 1)
                            {
                                if (nブロックxtype[t_] != 1)
                                {
                                    bステージスイッチ = false; v効果音再生(Res.nオーディオ_[13]);
                                }
                            }
                        }
                        else if (nブロックtype[t_] == 131)
                        {
                            if (xx_17 == 1 && nブロックxtype[t_] != 2)
                            {
                                bステージスイッチ = true; v効果音再生(Res.nオーディオ_[13]);
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
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[15]);
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
                            if (xx_17 == 1)
                            {
                                v効果音再生(Res.nオーディオ_[3]);
                                eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120); eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120); eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                                brockBreak(t_);
                            }
                        }//300


                    }
                    else if (nプレイヤーtype == 1)
                    {
                        if (ma + nプレイヤーnobia > xx_8 && ma < xx_8 + xx_1 && nプレイヤーb + nプレイヤーnobib > xx_9 && nプレイヤーb < xx_9 + xx_1)
                        {

                            v効果音再生(Res.nオーディオ_[3]);
                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -300, -1000, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, 240, -1400, 0, 160, 1000, 1000, 1, 120);
                            eyobi(nブロックa[t_] + 1200, nブロックb[t_] + 1200, -240, -1400, 0, 160, 1000, 1000, 1, 120);
                            brockBreak(t_);

                        }
                    }


                    //ONOFF
                    if (nブロックtype[t_] == 130 && !bステージスイッチ) { nブロックtype[t_] = 131; }
                    if (nブロックtype[t_] == 131 && bステージスイッチ) { nブロックtype[t_] = 130; }

                    //ヒント
                    if (nブロックtype[t_] == 300)
                    {
                        if (nブロックxtype[t_] >= 500 && nブロックa[t_] >= -6000)
                        {
                            if (nブロックxtype[t_] <= 539) nブロックxtype[t_]++;
                            if (nブロックxtype[t_] >= 540) { nブロックa[t_] -= 500; }
                        }
                    }//300


                }
            }//ブロック
        }

        void DrawBlock()
        {
            //ブロック描画
            for (int t_ = 0; t_ < nブロックmax; t_++)
            {
                xx_0 = nブロックa[t_] - fx; xx_1 = nブロックb[t_] - fy;
                xx_2 = 32; xx_3 = xx_2;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= W)
                {

                    xx_9 = 0;
                    if (nステージ色 == 2) { xx_9 = 30; }
                    if (nステージ色 == 4) { xx_9 = 60; }
                    if (nステージ色 == 5) { xx_9 = 90; }

                    if (nブロックtype[t_] < 100)
                    {
                        xx_6 = nブロックtype[t_] + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                    }

                    if (nブロックxtype[t_] != 10)
                    {

                        if (nブロックtype[t_] == 100 || nブロックtype[t_] == 101 || nブロックtype[t_] == 102 || nブロックtype[t_] == 103 || nブロックtype[t_] == 104 && nブロックxtype[t_] == 1 || nブロックtype[t_] == 114 && nブロックxtype[t_] == 1 || nブロックtype[t_] == 116)
                        {
                            xx_6 = 2 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (nブロックtype[t_] == 112 || nブロックtype[t_] == 104 && nブロックxtype[t_] == 0 || nブロックtype[t_] == 115 && nブロックxtype[t_] == 1)
                        {
                            xx_6 = 1 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (nブロックtype[t_] == 111 || nブロックtype[t_] == 113 || nブロックtype[t_] == 115 && nブロックxtype[t_] == 0 || nブロックtype[t_] == 124)
                        {
                            xx_6 = 3 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                    }

                    if (nブロックtype[t_] == 117 && nブロックxtype[t_] == 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像_[4, 5], xx_0 / 100, xx_1 / 100);
                    }

                    if (nブロックtype[t_] == 117 && nブロックxtype[t_] >= 3)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像_[3, 5], xx_0 / 100, xx_1 / 100);
                    }

                    if (nブロックtype[t_] == 115 && nブロックxtype[t_] == 3)
                    {
                        xx_6 = 1 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                    }

                    //ジャンプ台
                    if (nブロックtype[t_] == 120 && nブロックxtype[t_] != 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像_[16, 1], xx_0 / 100 + 3, xx_1 / 100 + 2);
                    }

                    //ON-OFF
                    if (nブロックtype[t_] == 130) DXDraw.DrawGraph(Res.n切り取り画像_[10, 5], xx_0 / 100, xx_1 / 100);
                    if (nブロックtype[t_] == 131) DXDraw.DrawGraph(Res.n切り取り画像_[11, 5], xx_0 / 100, xx_1 / 100);

                    if (nブロックtype[t_] == 140) DXDraw.DrawGraph(Res.n切り取り画像_[12, 5], xx_0 / 100, xx_1 / 100);
                    if (nブロックtype[t_] == 141) DXDraw.DrawGraph(Res.n切り取り画像_[13, 5], xx_0 / 100, xx_1 / 100);
                    if (nブロックtype[t_] == 142) DXDraw.DrawGraph(Res.n切り取り画像_[14, 5], xx_0 / 100, xx_1 / 100);


                    if (nブロックtype[t_] == 300 || nブロックtype[t_] == 301)
                        DXDraw.DrawGraph(Res.n切り取り画像_[1, 5], xx_0 / 100, xx_1 / 100);

                    //Pスイッチ
                    if (nブロックtype[t_] == 400) { DXDraw.DrawGraph(Res.n切り取り画像_[2, 5], xx_0 / 100, xx_1 / 100); }

                    //コイン
                    if (nブロックtype[t_] == 800) { DXDraw.DrawGraph(Res.n切り取り画像_[0, 2], xx_0 / 100 + 2, xx_1 / 100 + 1); }

                }
            }
        }
        #endregion
        #region 敵
        //敵キャラ
        const int n敵キャラmax = 24;
        int n敵キャラco;
        int[] n敵キャラa = new int[n敵キャラmax],
            n敵キャラb = new int[n敵キャラmax],
            n敵キャラnobia = new int[n敵キャラmax],
            n敵キャラnobib = new int[n敵キャラmax],
            n敵キャラc = new int[n敵キャラmax],
            n敵キャラd = new int[n敵キャラmax];
        int[] n敵キャラe = new int[n敵キャラmax],
            n敵キャラf = new int[n敵キャラmax],
            n敵キャラbrocktm = new int[n敵キャラmax];
        int[] n敵キャラacta = new int[n敵キャラmax],
            n敵キャラactb = new int[n敵キャラmax],
            n敵キャラzimentype = new int[n敵キャラmax],
            n敵キャラxzimen = new int[n敵キャラmax];
        int[] n敵キャラtype = new int[n敵キャラmax],
            n敵キャラxtype = new int[n敵キャラmax],
            n敵キャラmuki = new int[n敵キャラmax],
            n敵キャラhp = new int[n敵キャラmax];
        int[] n敵キャラnotm = new int[n敵キャラmax];
        int[] n敵キャラtm = new int[n敵キャラmax],
            n敵キャラ2tm = new int[n敵キャラmax];
        int[] n敵キャラmsgtm = new int[n敵キャラmax],
            n敵キャラmsgtype = new int[n敵キャラmax];

        //敵出現
        const int n敵出現max = 81;
        int n敵出現co;
        int[] n敵出現a = new int[n敵出現max],
            n敵出現b = new int[n敵出現max],
            n敵出現tm = new int[n敵出現max];
        int[] n敵出現type = new int[n敵出現max],
            n敵出現xtype = new int[n敵出現max],
            n敵出現z = new int[n敵出現max];

        void UpdateEnemy()
        {
            //敵キャラの配置
            for (int t_ = 0; t_ < n敵出現max; t_++)
            {
                if (n敵出現a[t_] >= -80000)
                {

                    if (n敵出現tm[t_] >= 0) { n敵出現tm[t_] = n敵出現tm[t_] - 1; }

                    for (int tt_ = 0; tt_ <= 1; tt_++)
                    {
                        xx_0 = 0; xx_1 = 0;


                        if (n敵出現z[t_] == 0 && n敵出現tm[t_] < 0 && n敵出現a[t_] - fx >= W + 2000 && n敵出現a[t_] - fx < W + 2000 + nプレイヤーc && tt_ == 0) { xx_0 = 1; n敵キャラmuki[n敵キャラco] = 0; }// && mmuki==1
                        if (n敵出現z[t_] == 0 && n敵出現tm[t_] < 0 && n敵出現a[t_] - fx >= -400 - Res.n敵サイズW_[n敵出現type[t_]] + nプレイヤーc && n敵出現a[t_] - fx < -400 - Res.n敵サイズW_[n敵出現type[t_]] && tt_ == 1) { xx_0 = 1; xx_1 = 1; n敵キャラmuki[n敵キャラco] = 1; }// && mmuki==0
                        if (n敵出現z[t_] == 1 && n敵出現a[t_] - fx >= 0 - Res.n敵サイズW_[n敵出現type[t_]] && n敵出現a[t_] - fx <= W + 4000 && n敵出現b[t_] - fy >= -9000 && n敵出現b[t_] - fy <= H + 4000 && n敵出現tm[t_] < 0) { xx_0 = 1; n敵出現z[t_] = 0; }// && xza<=5000// && tyuukan!=1
                        if (xx_0 == 1)
                        {//400
                            n敵出現tm[t_] = 401; xx_0 = 0;
                            if (n敵出現type[t_] >= 10) { n敵出現tm[t_] = 9999999; }

                            //10
                            ayobi(n敵出現a[t_], n敵出現b[t_], 0, 0, 0, n敵出現type[t_], n敵出現xtype[t_]);

                        }

                    }//tt

                }
            }//t

            //敵キャラ
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {
                xx_0 = n敵キャラa[t_] - fx; xx_1 = n敵キャラb[t_] - fy;
                xx_2 = n敵キャラnobia[t_]; xx_3 = n敵キャラnobib[t_]; xx_14 = 12000 * 1;
                if (n敵キャラnotm[t_] >= 0) n敵キャラnotm[t_]--;
                if (xx_0 + xx_2 >= -xx_14 && xx_0 <= W + xx_14 && xx_1 + xx_3 >= -10 - 9000 && xx_1 <= H + 20000)
                {
                    n敵キャラacta[t_] = 0; n敵キャラactb[t_] = 0;

                    xx_10 = 0;

                    switch (n敵キャラtype[t_])
                    {
                        case 0:
                            xx_10 = 100;
                            break;

                        //こうらの敵
                        case 1:
                            xx_10 = 100;
                            break;

                        //こうら
                        case 2:
                            xx_10 = 0; xx_17 = 800;
                            if (n敵キャラxtype[t_] >= 1) xx_10 = xx_17;
                            //他の敵を倒す
                            if (n敵キャラxtype[t_] >= 1)
                            {
                                for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = n敵キャラa[tt_] - fx; xx_9 = n敵キャラb[tt_] - fy;
                                    if (t_ != tt_)
                                    {
                                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + n敵キャラnobia[tt_] - xx_0 * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_5 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
                                        {
                                            n敵キャラa[tt_] = -800000; v効果音再生(Res.nオーディオ_[6]);
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

                            //xx_10=100;
                            break;

                        //スーパージエン
                        case 4:
                            xx_10 = 120;
                            xx_0 = 250;
                            xx_8 = n敵キャラa[t_] - fx;
                            xx_9 = n敵キャラb[t_] - fy;
                            if (n敵キャラtm[t_] >= 0) n敵キャラtm[t_]--;
                            if (Math.Abs(ma + nプレイヤーnobia - xx_8 - xx_0 * 2) < 9000 &&
                                Math.Abs((ma < xx_8 - n敵キャラnobia[t_] + xx_0 * 2) ? 1 : 0) < 3000 &&
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
                            xx_10 = 160;
                            //azimentype[t]=2;
                            break;

                        //デフラグさん
                        case 6:
                            if (n敵キャラzimentype[t_] == 30) { n敵キャラd[t_] = -1600; n敵キャラb[t_] += n敵キャラd[t_]; }

                            xx_10 = 120;
                            if (n敵キャラtm[t_] >= 10)
                            {
                                n敵キャラtm[t_]++;
                                if (nプレイヤーhp >= 1)
                                {
                                    if (n敵キャラtm[t_] <= 19) { ma = xx_0; nプレイヤーb = xx_1 - 3000; nプレイヤーtype = 0; }
                                    xx_10 = 0;
                                    if (n敵キャラtm[t_] == 20) { nプレイヤーc = 700; nプレイヤーkeytm = 24; nプレイヤーd = -1200; nプレイヤーb = xx_1 - 1000 - 3000; n敵キャラmuki[t_] = 1; if (n敵キャラxtype[t_] == 1) { nプレイヤーc = 840; n敵キャラxtype[t_] = 0; } }
                                    if (n敵キャラtm[t_] == 40) { n敵キャラmuki[t_] = 0; n敵キャラtm[t_] = 0; }
                                }
                            }

                            //ポール捨て
                            if (n敵キャラxtype[t_] == 1)
                            {
                                for (int tt_ = 0; tt_ < n地面max; tt_++)
                                {
                                    if (n地面type[tt_] == 300)
                                    {
                                        if (n敵キャラa[t_] - fx >= -8000 && n敵キャラa[t_] >= n地面a[tt_] + 2000 && n敵キャラa[t_] <= n地面a[tt_] + 3600 && n敵キャラxzimen[t_] == 1) { n地面a[tt_] = -800000; n敵キャラtm[t_] = 100; }
                                    }
                                }

                                if (n敵キャラtm[t_] == 100)
                                {
                                    eyobi(n敵キャラa[t_] + 1200 - 1200, n敵キャラb[t_] + 3000 - 10 * 3000 - 1500, 0, 0, 0, 0, 1000, 10 * 3000 - 1200, 4, 20);
                                    if (nプレイヤーtype == 300) { nプレイヤーtype = 0; DX.StopSoundMem(Res.nオーディオ_[11]); bgmChange(Res.nオーディオ_[100]); DX.PlaySoundMem(Res.nオーディオ_[0], DX.DX_PLAYTYPE_LOOP); }
                                    for (int t1 = 0; t1 < n地面max; t1++) { if (n地面type[t1] == 104) n地面a[t1] = -80000000; }
                                }
                                if (n敵キャラtm[t_] == 120) { eyobi(n敵キャラa[t_] + 1200 - 1200, n敵キャラb[t_] + 3000 - 10 * 3000 - 1500, 600, -1200, 0, 160, 1000, 10 * 3000 - 1200, 4, 240); n敵キャラmuki[t_] = 1; }
                                if (n敵キャラtm[t_] == 140) { n敵キャラmuki[t_] = 0; n敵キャラtm[t_] = 0; }
                            }
                            if (n敵キャラtm[t_] >= 220) { n敵キャラtm[t_] = 0; n敵キャラmuki[t_] = 0; }

                            //他の敵を投げる
                            for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                            {
                                xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                xx_8 = n敵キャラa[tt_] - fx; xx_9 = n敵キャラb[tt_] - fy;
                                if (t_ != tt_ && n敵キャラtype[tt_] >= 100)
                                {
                                    if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + n敵キャラnobia[tt_] - xx_0 * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_5 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
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
                            xx_10 = 0; xx_11 = 400;
                            if (n敵キャラxtype[t_] == 0) xx_10 = xx_11;
                            if (n敵キャラxtype[t_] == 1) xx_10 = -xx_11;
                            if (n敵キャラxtype[t_] == 2) n敵キャラb[t_] -= xx_11;
                            if (n敵キャラxtype[t_] == 3) n敵キャラb[t_] += xx_11;
                            break;

                        //スーパーブーン
                        case 8:
                            n敵キャラzimentype[t_] = 0;
                            xx_22 = 20;
                            if (n敵キャラtm[t_] == 0) { n敵キャラf[t_] += xx_22; n敵キャラd[t_] += xx_22; }
                            if (n敵キャラtm[t_] == 1) { n敵キャラf[t_] -= xx_22; n敵キャラd[t_] -= xx_22; }
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
                            if (n敵キャラb[t_] >= H + 1000) { n敵キャラd[t_] = 900; }
                            if (n敵キャラb[t_] >= H + 12000)
                            {
                                n敵キャラb[t_] = H; n敵キャラd[t_] = -2600;
                            }
                            break;

                        //ファイアー
                        case 10:
                            n敵キャラzimentype[t_] = 0;
                            xx_10 = 0; xx_11 = 400;
                            if (n敵キャラxtype[t_] == 0) xx_10 = xx_11;
                            if (n敵キャラxtype[t_] == 1) xx_10 = -xx_11;
                            break;


                        //モララー
                        case 30:
                            n敵キャラtm[t_] += 1;
                            if (n敵キャラxtype[t_] == 0)
                            {
                                if (n敵キャラtm[t_] == 50 && nプレイヤーb >= 6000) { n敵キャラc[t_] = 300; n敵キャラd[t_] -= 1600; n敵キャラb[t_] -= 1000; }

                                for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = n敵キャラa[tt_] - fx; xx_9 = n敵キャラb[tt_] - fy;
                                    if (t_ != tt_ && n敵キャラtype[tt_] == 102)
                                    {
                                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + n敵キャラnobia[tt_] - xx_0 * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_5 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 * 3 + xx_12 + 1500)
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
                            xx_10 = 1600;
                            if (n敵キャラxtype[t_] == 1) { xx_10 = 1200; n敵キャラb[t_] -= 200; }
                            if (n敵キャラxtype[t_] == 2) { xx_10 = 1200; n敵キャラb[t_] += 200; }
                            if (n敵キャラxtype[t_] == 3) { xx_10 = 900; n敵キャラb[t_] -= 600; }
                            if (n敵キャラxtype[t_] == 4) { xx_10 = 900; n敵キャラb[t_] += 600; }
                            break;

                        //雲の敵
                        case 80:
                            n敵キャラzimentype[t_] = 0;
                            //xx_10=100;
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
                            xx_23 = 400;
                            if (n敵キャラxtype[t_] == 0) { n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 1; }
                            if (nプレイヤーb >= 30000 && ma >= n敵キャラa[t_] - 3000 * 5 - fx && ma <= n敵キャラa[t_] - fx && n敵キャラxtype[t_] == 1) { n敵キャラxtype[t_] = 5; n敵キャラmuki[t_] = 0; }
                            if (nプレイヤーb >= 24000 && ma <= n敵キャラa[t_] + 3000 * 8 - fx && ma >= n敵キャラa[t_] - fx && n敵キャラxtype[t_] == 1) { n敵キャラxtype[t_] = 5; n敵キャラmuki[t_] = 1; }
                            if (n敵キャラxtype[t_] == 5) xx_10 = xx_23;
                            break;

                        case 86:
                            n敵キャラzimentype[t_] = 4;
                            xx_23 = 1000;
                            if (ma >= n敵キャラa[t_] - fx - nプレイヤーnobia - xx_26 && ma <= n敵キャラa[t_] - fx + n敵キャラnobia[t_] + xx_26) { n敵キャラtm[t_] = 1; }
                            if (n敵キャラtm[t_] == 1) { n敵キャラb[t_] += 1200; }
                            break;

                        //ファイアバー
                        case 87:
                            n敵キャラzimentype[t_] = 0;
                            if (n敵キャラa[t_] % 10 != 1) n敵キャラtm[t_] += 6;
                            else { n敵キャラtm[t_] -= 6; }
                            xx_25 = 2;
                            if (n敵キャラtm[t_] > 360 * xx_25) n敵キャラtm[t_] -= 360 * xx_25;
                            if (n敵キャラtm[t_] < 0) n敵キャラtm[t_] += 360 * xx_25;

                            for (int tt_ = 0; tt_ <= n敵キャラxtype[t_] % 100; tt_++)
                            {
                                xx_26 = 18;
                                double xd_4 = tt_ * xx_26 * Math.Cos(n敵キャラtm[t_] * Math.PI / 180 / 2); double xd_5 = tt_ * xx_26 * Math.Sin(n敵キャラtm[t_] * Math.PI / 180 / 2);

                                xx_4 = 1800; xx_5 = 800;
                                xx_8 = n敵キャラa[t_] - fx + (int)xd_4 * 100 - xx_4 / 2; xx_9 = n敵キャラb[t_] - fy + (int)xd_5 * 100 - xx_4 / 2;

                                if (ma + nプレイヤーnobia > xx_8 + xx_5 && ma < xx_8 + xx_4 - xx_5 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_5 && nプレイヤーb < xx_9 + xx_4 - xx_5)
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
                            xx_25 = 2;
                            if (n敵キャラtm[t_] > 360 * xx_25) n敵キャラtm[t_] -= 360 * xx_25;
                            if (n敵キャラtm[t_] < 0) n敵キャラtm[t_] += 360 * xx_25;

                            for (int tt_ = 0; tt_ <= n敵キャラxtype[t_] % 100; tt_++)
                            {
                                xx_26 = 18;
                                double xd_4 = -tt_ * xx_26 * Math.Cos(n敵キャラtm[t_] * Math.PI / 180 / 2);
                                double xd_5 = tt_ * xx_26 * Math.Sin(n敵キャラtm[t_] * Math.PI / 180 / 2);

                                xx_4 = 1800;
                                xx_5 = 800;
                                xx_8 = n敵キャラa[t_] - fx + (int)xd_4 * 100 - xx_4 / 2;
                                xx_9 = n敵キャラb[t_] - fy + (int)xd_5 * 100 - xx_4 / 2;

                                if (ma + nプレイヤーnobia > xx_8 + xx_5 && ma < xx_8 + xx_4 - xx_5 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_5 && nプレイヤーb < xx_9 + xx_4 - xx_5)
                                {
                                    nプレイヤーhp -= 1;
                                    nメッセージtype = 51; nメッセージtm = 30;
                                }
                            }

                            break;


                        case 90:
                            xx_10 = 160;
                            break;


                        //おいしいキノコ
                        case 100:
                            n敵キャラzimentype[t_] = 1;
                            xx_10 = 100;

                            //ほかの敵を巨大化
                            if (n敵キャラxtype[t_] == 2)
                            {
                                for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                                {
                                    xx_0 = 250; xx_5 = -800; xx_12 = 0; xx_1 = 1600;
                                    xx_8 = n敵キャラa[tt_] - fx; xx_9 = n敵キャラb[tt_] - fy;
                                    if (t_ != tt_)
                                    {
                                        if (n敵キャラa[t_] + n敵キャラnobia[t_] - fx > xx_8 + xx_0 * 2 && n敵キャラa[t_] - fx < xx_8 + n敵キャラnobia[tt_] - xx_0 * 2 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy > xx_9 + xx_5 && n敵キャラb[t_] + n敵キャラnobib[t_] - fy < xx_9 + xx_1 * 3 + xx_12)
                                        {
                                            if (n敵キャラtype[tt_] == 0 || n敵キャラtype[tt_] == 4)
                                            {
                                                n敵キャラtype[tt_] = 90;//ot(oto[6]);
                                                n敵キャラnobia[tt_] = 6400; n敵キャラnobib[tt_] = 6300; n敵キャラxtype[tt_] = 0;
                                                n敵キャラa[tt_] -= 1050; n敵キャラb[tt_] -= 1050;
                                                v効果音再生(Res.nオーディオ_[9]); n敵キャラa[t_] = -80000000;
                                            }
                                        }
                                    }
                                }
                            }

                            break;

                        //毒キノコ
                        case 102:
                            n敵キャラzimentype[t_] = 1;
                            xx_10 = 100;
                            if (n敵キャラxtype[t_] == 1) xx_10 = 200;
                            break;

                        //悪スター
                        case 110:
                            n敵キャラzimentype[t_] = 1;
                            xx_10 = 200;
                            if (n敵キャラxzimen[t_] == 1)
                            {
                                n敵キャラb[t_] -= 1200; n敵キャラd[t_] = -1400;
                            }
                            break;


                        case 200:
                            n敵キャラzimentype[t_] = 1;
                            xx_10 = 100;
                            break;


                    }//sw


                    if (n敵キャラbrocktm[t_] >= 1) xx_10 = 0;



                    if (n敵キャラmuki[t_] == 0) n敵キャラacta[t_] -= xx_10;
                    if (n敵キャラmuki[t_] == 1) n敵キャラacta[t_] += xx_10;

                    //最大値
                    xx_0 = 850; xx_1 = 1200;

                    if (n敵キャラd[t_] > xx_1 && n敵キャラzimentype[t_] != 5) { n敵キャラd[t_] = xx_1; }


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
                            xx_0 = 100;
                            if (n敵キャラc[t_] >= 200) { n敵キャラc[t_] -= xx_0; }
                            else if (n敵キャラc[t_] <= -200) { n敵キャラc[t_] += xx_0; }
                            else { n敵キャラc[t_] = 0; }
                        }

                        n敵キャラxzimen[t_] = 0;




                        //地面判定
                        if (n敵キャラzimentype[t_] != 2)
                        {
                            tekizimen(t_);
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
                    xx_0 = 250; xx_1 = 1600; xx_2 = 1000;
                    xx_4 = 500; xx_5 = -800;

                    xx_8 = n敵キャラa[t_] - fx; xx_9 = n敵キャラb[t_] - fy;
                    xx_12 = 0; if (nプレイヤーd >= 100) xx_12 = nプレイヤーd;
                    xx_25 = 0;

                    if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n敵キャラnobia[t_] - xx_0 * 2 && nプレイヤーb + nプレイヤーnobib > xx_9 - xx_5 && nプレイヤーb + nプレイヤーnobib < xx_9 + xx_1 + xx_12 && (nプレイヤーmutekitm <= 0 || nプレイヤーd >= 100) && n敵キャラbrocktm[t_] <= 0)
                    {
                        if (n敵キャラtype[t_] != 4 && n敵キャラtype[t_] != 9 && n敵キャラtype[t_] != 10 && (n敵キャラtype[t_] <= 78 || n敵キャラtype[t_] == 85) && nプレイヤーzimen != 1 && nプレイヤーtype != 200)
                        {

                            if (n敵キャラtype[t_] == 0)
                            {
                                if (n敵キャラxtype[t_] == 0)
                                    n敵キャラa[t_] = -900000;
                                if (n敵キャラxtype[t_] == 1)
                                {
                                    v効果音再生(Res.nオーディオ_[5]);
                                    nプレイヤーb = xx_9 - 900 - n敵キャラnobib[t_]; nプレイヤーd = -2100; xx_25 = 1; nプレイヤーactaon[2] = 0;
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
                                    if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n敵キャラnobia[t_] / 2 - xx_0 * 4)
                                    {
                                        n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 1;
                                    }
                                    else { n敵キャラxtype[t_] = 1; n敵キャラmuki[t_] = 0; }
                                }
                            }
                            if (n敵キャラtype[t_] == 3)
                            {
                                xx_25 = 1;
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
                                if (xx_25 == 0) { v効果音再生(Res.nオーディオ_[5]); nプレイヤーb = xx_9 - 1000 - n敵キャラnobib[t_]; nプレイヤーd = -1000; }
                            }
                            if (n敵キャラtype[t_] == 85)
                            {
                                if (xx_25 == 0) { v効果音再生(Res.nオーディオ_[5]); nプレイヤーb = xx_9 - 4000; nプレイヤーd = -1000; n敵キャラxtype[t_] = 5; }
                            }

                            if (nプレイヤーactaon[2] == 1) { nプレイヤーd = -1600; nプレイヤーactaon[2] = 0; }
                        }
                    }

                    xx_15 = -500;


                    //プレイヤーに触れた時
                    xx_16 = 0;
                    if (n敵キャラtype[t_] == 4 || n敵キャラtype[t_] == 9 || n敵キャラtype[t_] == 10) xx_16 = -3000;
                    if (n敵キャラtype[t_] == 82 || n敵キャラtype[t_] == 83 || n敵キャラtype[t_] == 84) xx_16 = -3200;
                    if (n敵キャラtype[t_] == 85) xx_16 = -n敵キャラnobib[t_] + 6000;
                    if (ma + nプレイヤーnobia > xx_8 + xx_4 && ma < xx_8 + n敵キャラnobia[t_] - xx_4 && nプレイヤーb < xx_9 + n敵キャラnobib[t_] + xx_15 && nプレイヤーb + nプレイヤーnobib > xx_9 + n敵キャラnobib[t_] - xx_0 + xx_16 && n敵キャラnotm[t_] <= 0 && n敵キャラbrocktm[t_] <= 0)
                    {
                        if (nプレイヤーmutekitm <= 0 && (n敵キャラtype[t_] <= 99 || n敵キャラtype[t_] >= 200))
                        {
                            if (nプレイヤーtype != 200)
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
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = DX.GetRand(7) + 1 + 1000 + (nステージb - 1) * 10;
                                    }

                                    if (n敵キャラtype[t_] == 1)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = DX.GetRand(2) + 15;
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
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = DX.GetRand(7) + 1 + 1000 + (nステージb - 1) * 10;
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
                                        n敵キャラmsgtm[t_] = 20; n敵キャラmsgtype[t_] = DX.GetRand(1) + 31;
                                        xx_24 = 900; n敵キャラtype[t_] = 83; n敵キャラa[t_] -= xx_24 + 100; n敵キャラb[t_] -= xx_24 - 100 * 0;
                                    }//82

                                    if (n敵キャラtype[t_] == 84)
                                    {
                                        nメッセージtm = 30; nメッセージtype = 50;
                                    }

                                    if (n敵キャラtype[t_] == 85)
                                    {
                                        n敵キャラmsgtm[t_] = 60; n敵キャラmsgtype[t_] = DX.GetRand(1) + 85;
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
                                        if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n敵キャラnobia[t_] / 2 - xx_0 * 4)
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

                            if (n敵キャラtype[t_] == 100 && n敵キャラxtype[t_] == 0) { nメッセージtm = 30; nメッセージtype = 1; v効果音再生(Res.nオーディオ_[9]); }
                            if (n敵キャラtype[t_] == 100 && n敵キャラxtype[t_] == 1) { nメッセージtm = 30; nメッセージtype = 2; v効果音再生(Res.nオーディオ_[9]); }
                            if (n敵キャラtype[t_] == 100 && n敵キャラxtype[t_] == 2) { nプレイヤーnobia = 5200; nプレイヤーnobib = 7300; v効果音再生(Res.nオーディオ_[9]); ma -= 1100; nプレイヤーb -= 4000; nプレイヤーtype = 1; nプレイヤーhp = 50000000; }

                            if (n敵キャラtype[t_] == 101) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 11; }
                            if (n敵キャラtype[t_] == 102) { nプレイヤーhp -= 1; nメッセージtm = 30; nメッセージtype = 10; }


                            //?ボール
                            if (n敵キャラtype[t_] == 105)
                            {
                                if (n敵キャラxtype[t_] == 0)
                                {
                                    v効果音再生(Res.nオーディオ_[4]); n地面gtype[26] = 6;
                                }
                                if (n敵キャラxtype[t_] == 1)
                                {
                                    nブロックxtype[7] = 80;
                                    v効果音再生(Res.nオーディオ_[4]);

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
        }

        void DrawEnemy()
        {
            DXDraw.nミラー = 0;
            //敵キャラ
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {

                xx_0 = n敵キャラa[t_] - fx; xx_1 = n敵キャラb[t_] - fy;
                xx_2 = n敵キャラnobia[t_] / 100; xx_3 = n敵キャラnobib[t_] / 100; xx_14 = 3000; xx_16 = 0;
                if (xx_0 + xx_2 * 100 >= -10 - xx_14 && xx_1 <= W + xx_14 && xx_1 + xx_3 * 100 >= -10 && xx_3 <= H)
                {
                    if (n敵キャラmuki[t_] == 1) { DXDraw.nミラー = 1; }
                    if (n敵キャラtype[t_] == 3 && n敵キャラxtype[t_] == 1) { DX.DrawRotaGraph(xx_0 / 100 + 13, xx_1 / 100 + 15, 1.0f, Math.PI / 1, Res.n切り取り画像_[n敵キャラtype[t_], 3], DX.TRUE); xx_16 = 1; }
                    if (n敵キャラtype[t_] == 9 && n敵キャラd[t_] >= 1) { DX.DrawRotaGraph(xx_0 / 100 + 13, xx_1 / 100 + 15, 1.0f, Math.PI / 1, Res.n切り取り画像_[n敵キャラtype[t_], 3], DX.TRUE); xx_16 = 1; }
                    if (n敵キャラtype[t_] >= 100 && n敵キャラmuki[t_] == 1) DXDraw.nミラー = 0;

                    //メイン
                    if (n敵キャラtype[t_] < 200 && xx_16 == 0 && n敵キャラtype[t_] != 6 && n敵キャラtype[t_] != 79 && n敵キャラtype[t_] != 86 && n敵キャラtype[t_] != 30)
                    {
                        if (!((n敵キャラtype[t_] == 80 || n敵キャラtype[t_] == 81) && n敵キャラxtype[t_] == 1))
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[n敵キャラtype[t_], 3], xx_0 / 100, xx_1 / 100);
                        }
                    }


                    //デフラグさん
                    if (n敵キャラtype[t_] == 6)
                    {
                        if (n敵キャラtm[t_] >= 10 && n敵キャラtm[t_] <= 19 || n敵キャラtm[t_] >= 100 && n敵キャラtm[t_] <= 119 || n敵キャラtm[t_] >= 200)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[150, 3], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像_[6, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }

                    //モララー
                    if (n敵キャラtype[t_] == 30)
                    {
                        if (n敵キャラxtype[t_] == 0) DXDraw.DrawGraph(Res.n切り取り画像_[30, 3], xx_0 / 100, xx_1 / 100);
                        if (n敵キャラxtype[t_] == 1) DXDraw.DrawGraph(Res.n切り取り画像_[155, 3], xx_0 / 100, xx_1 / 100);
                    }



                    //ステルス雲
                    if ((n敵キャラtype[t_] == 81) && n敵キャラxtype[t_] == 1)
                    {
                        DXDraw.DrawGraph(Res.n切り取り画像_[130, 3], xx_0 / 100, xx_1 / 100);
                    }

                    if (n敵キャラtype[t_] == 79)
                    {
                        DXDraw.SetColor(250, 250, 0);
                        DXDraw.DrawBox塗り潰し(xx_0 / 100, xx_1 / 100, xx_2, xx_3);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し(xx_0 / 100, xx_1 / 100, xx_2, xx_3);
                    }

                    if (n敵キャラtype[t_] == 82)
                    {

                        if (n敵キャラxtype[t_] == 0)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 5 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (n敵キャラxtype[t_] == 1)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 4 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100, xx_1 / 100);
                        }

                        if (n敵キャラxtype[t_] == 2)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[1, 5], xx_0 / 100, xx_1 / 100);
                        }

                    }
                    if (n敵キャラtype[t_] == 83)
                    {

                        if (n敵キャラxtype[t_] == 0)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 5 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100 + 10, xx_1 / 100 + 9);
                        }

                        if (n敵キャラxtype[t_] == 1)
                        {
                            xx_9 = 0; if (nステージ色 == 2) { xx_9 = 30; }
                            if (nステージ色 == 4) { xx_9 = 60; }
                            if (nステージ色 == 5) { xx_9 = 90; }
                            xx_6 = 4 + xx_9; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], xx_0 / 100 + 10, xx_1 / 100 + 9);
                        }

                    }

                    //偽ポール
                    if (n敵キャラtype[t_] == 85)
                    {
                        DXDraw.SetColorWhite();
                        DXDraw.DrawBox塗り潰し((xx_0) / 100 + 10, (xx_1) / 100, 10, xx_3);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((xx_0) / 100 + 10, (xx_1) / 100, 10, xx_3);
                        DXDraw.SetColor(0, 250, 200);
                        DXDraw.DrawOval塗り潰し((xx_0) / 100 + 15 - 1, (xx_1) / 100, 10, 10);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawOval塗り無し((xx_0) / 100 + 15 - 1, (xx_1) / 100, 10, 10);

                    }//85


                    //ニャッスン
                    if (n敵キャラtype[t_] == 86)
                    {
                        if (ma >= n敵キャラa[t_] - fx - nプレイヤーnobia - 4000 && ma <= n敵キャラa[t_] - fx + n敵キャラnobia[t_] + 4000)
                        {
                            DXDraw.DrawGraph(Res.n切り取り画像_[152, 3], xx_0 / 100, xx_1 / 100);
                        }
                        else {
                            DXDraw.DrawGraph(Res.n切り取り画像_[86, 3], xx_0 / 100, xx_1 / 100);
                        }
                    }

                    if (n敵キャラtype[t_] == 200)
                        DXDraw.DrawGraph(Res.n切り取り画像_[0, 3], xx_0 / 100, xx_1 / 100);

                    DXDraw.nミラー = 0;
                }
            }
        }

        void DrawEnemyファイアバー()
        {
            //ファイアバー
            for (int t_ = 0; t_ < n敵キャラmax; t_++)
            {

                xx_0 = n敵キャラa[t_] - fx; xx_1 = n敵キャラb[t_] - fy;
                xx_14 = 12000; xx_16 = 0;
                if (n敵キャラtype[t_] == 87 || n敵キャラtype[t_] == 88)
                {
                    if (xx_0 + xx_2 * 100 >= -10 - xx_14 && xx_1 <= W + xx_14 && xx_1 + xx_3 * 100 >= -10 && xx_3 <= H)
                    {

                        for (int tt_ = 0; tt_ <= n敵キャラxtype[t_] % 100; tt_++)
                        {
                            xx_26 = 18;
                            double xd_4 = tt_ * xx_26 * Math.Cos(n敵キャラtm[t_] * Math.PI / 180 / 2);
                            double xd_5 = tt_ * xx_26 * Math.Sin(n敵キャラtm[t_] * Math.PI / 180 / 2);
                            xx_24 = (int)xd_4;
                            xx_25 = (int)xd_5;
                            DXDraw.SetColor(230, 120, 0);
                            xx_23 = 8;
                            if (n敵キャラtype[t_] == 87)
                            {
                                DXDraw.DrawOval塗り潰し(xx_0 / 100 + xx_24, xx_1 / 100 + xx_25, xx_23, xx_23);
                                DXDraw.SetColor(0, 0, 0);
                                DXDraw.DrawOval塗り無し(xx_0 / 100 + xx_24, xx_1 / 100 + xx_25, xx_23, xx_23);
                            }
                            else {
                                DXDraw.DrawOval塗り潰し(xx_0 / 100 - xx_24, xx_1 / 100 + xx_25, xx_23, xx_23);
                                DXDraw.SetColor(0, 0, 0);
                                DXDraw.DrawOval塗り無し(xx_0 / 100 - xx_24, xx_1 / 100 + xx_25, xx_23, xx_23);
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region メッセージ
        //メッセージ
        int nメッセージtm, nメッセージtype;

        void DrawMsg()
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
        #endregion
        #region メッセージブロック
        //メッセージブロック
        int nメッセージブロックtm, nメッセージブロックtype, nメッセージブロックy, nメッセージブロック;

        void DrawMsgBlock()
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

        //メッセージ
        void ttmsg()
        {
            xx_1 = 6000 / 100;
            xx_2 = 4000 / 100;
            if (nメッセージブロックtype == 1 || nメッセージブロックtype == 2)
            {
                DXDraw.SetColorBlack();
                DXDraw.DrawBox塗り潰し(xx_1, xx_2, 360, nメッセージブロックy / 100);
                DXDraw.SetColorWhite();
                DXDraw.DrawBox塗り無し(xx_1, xx_2, 360, nメッセージブロックy / 100);
            }
            if (nメッセージブロックtype == 2)
            {
                //フォント
                setfont(20, 5);

                if (nメッセージブロック == 0)
                {
                    DXDraw.SetColorWhite();
                    //フォント
                    setfont(20, 5);
                    txmsg("テスト　hoge", 0);
                }

                if (nメッセージブロック == 1)
                {
                    DXDraw.SetColorWhite();
                    txmsg("", 0);
                    txmsg("ステージ 1 より", 0);
                    txmsg("特殊的なものが増えたので", 1);
                    txmsg("気をつけてくれよ～", 2);
                    txmsg("後、アイテムの一部を利用するかも…", 4);
                    txmsg("                       ちく より", 6);
                }

                if (nメッセージブロック == 2)
                {
                    txmsg("            ？が必要です ", 3);
                    txmsg("                         m9(^Д^)", 6);
                }


                if (nメッセージブロック == 3)
                {
                    txmsg("   別にコインに意味ないけどね ", 3);
                    txmsg("                      (・ω・ )ﾉｼ", 6);
                }

                if (nメッセージブロック == 4)
                {
                    txmsg("この先に隠しブロックがあります ", 2);
                    txmsg("注意してください !!", 4);
                }


                if (nメッセージブロック == 5)
                {
                    txmsg("", 0);
                    txmsg(" 前回よりも難易度を下げましたので", 1);
                    txmsg(" 気楽にプレイしてください    ", 3);
                    txmsg("                       ちく より", 6);
                }

                if (nメッセージブロック == 6)
                {
                    txmsg("", 0);
                    txmsg(" そこにいる敵のそばによると、      ", 1);
                    txmsg(" 自分と一緒にジャンプしてくれます。", 2);
                    txmsg("   可愛いですね。                  ", 3);
                }

                if (nメッセージブロック == 7)
                {
                    txmsg("", 0);
                    txmsg(" あの敵は連れて来れましたか?、     ", 1);
                    txmsg(" 連れて来れなかった貴方は、        ", 2);
                    txmsg(" そこの落とし穴から Let's dive!    ", 3);
                }

                if (nメッセージブロック == 8)
                {
                    txmsg("そんな容易に", 1);
                    txmsg("ヒントに頼るもんじゃないぜ", 2);
                    txmsg("ほら、さっさと次行きな!!", 3);
                }

                if (nメッセージブロック == 9)
                {
                    txmsg(" 正真正銘のファイナルステージ。    ", 1);
                    txmsg(" クリアすれば遂にエンディング!!    ", 2);
                    txmsg(" その土管から戻ってもいいんだぜ?   ", 3);
                }

                if (nメッセージブロック == 10)
                {
                    txmsg(" 床が凍ってるから、すっごい滑るよ。", 1);
                    txmsg(" ", 2);
                    txmsg(" 　                      ", 3);
                }

                if (nメッセージブロック == 100)
                {
                    txmsg("え？私ですか？ ", 0);
                    txmsg("いやぁ、ただの通りすがりの", 2);
                    txmsg("ヒントブロックですよ～", 3);
                    txmsg("決して怪しいブロックじゃないですよ", 5);
                    txmsg("                          (…チッ)", 6);
                }


                setfont(16, 4);
            }//2

            if (nメッセージブロックtype == 3)
            {
                xx_5 = (((15 - 1) * 1200 + 1500) / 100 - nメッセージブロックy / 100);
                if (xx_5 > 0)
                {
                    DXDraw.SetColorBlack();
                    DXDraw.DrawBox塗り潰し(xx_1, xx_2 + nメッセージブロックy / 100, 360, xx_5);
                    DXDraw.SetColorWhite();
                    DXDraw.DrawBox塗り無し(xx_1, xx_2 + nメッセージブロックy / 100, 360, xx_5);
                }
            }

        }//ttmsg
        #endregion
        #region プレイヤー
        //プレイヤー
        int nプレイヤーainmsgtype;
        int nプレイヤーb, nプレイヤーnobia, nプレイヤーnobib, nプレイヤーhp;
        int nプレイヤーc,
            nプレイヤーd,
             nokori = 2, nプレイヤーactp, nプレイヤーact;

        int nプレイヤーtype,
            nプレイヤーxtype,
            nプレイヤーtm,
            nプレイヤーzz;
        int nプレイヤーzimen,
            nプレイヤーrzimen,
            nプレイヤーkasok,
            nプレイヤーmuki,
            nプレイヤーjumptm,
            nプレイヤーkeytm;
        int nプレイヤーmutekitm;
        int[] nプレイヤーactaon = new int[7];

        void UpdatePlayer()
        {
            //プレイヤーの移動
            xx_0 = 0; nプレイヤーactaon[2] = 0; nプレイヤーactaon[3] = 0;
            if (nプレイヤーkeytm <= 0)
            {
                if (Key.GetKey(DX.KEY_INPUT_LEFT))
                {
                    nプレイヤーactaon[0] = -1;
                    nプレイヤーmuki = 0;
                    nプレイヤーactaon[4] = -1;
                }
                if (Key.GetKey(DX.KEY_INPUT_RIGHT))
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
                    stagepoint = false;
                }
            }


            if (nプレイヤーkeytm <= 0)
            {
                if (Key.GetKey(DX.KEY_INPUT_Z))
                {
                    if (nプレイヤーactaon[1] == 10)
                    {
                        nプレイヤーactaon[1] = 1;
                        xx_0 = 1;
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
                    xx_22 = 200;
                    if (nプレイヤーc >= xx_22 || nプレイヤーc <= -xx_22)
                    {
                        nプレイヤーd = -1400;
                    }

                    xx_22 = 600;
                    if (nプレイヤーc >= xx_22 || nプレイヤーc <= -xx_22)
                    {
                        nプレイヤーd = -1500;
                    }
                }
                if (xx_0 == 0) nプレイヤーactaon[1] = 10;
            }

            //加速による移動
            xx_0 = 40;
            xx_1 = 700;
            xx_8 = 500;
            xx_9 = 700;

            xx_12 = 1;
            xx_13 = 2;

            //すべり補正
            if (nプレイヤーrzimen == 1)
            {
                xx_0 = 20;
                xx_12 = 9;
                xx_13 = 10;
            }


            //if (mzimen==0){xx_0-=15;}
            if (nプレイヤーactaon[0] == -1)
            {
                if (!(nプレイヤーzimen == 0 && nプレイヤーc < -xx_8))
                {
                    if (nプレイヤーc >= -xx_9)
                    {
                        nプレイヤーc -= xx_0;
                        if (nプレイヤーc < -xx_9)
                        {
                            nプレイヤーc = -xx_9 - 1;
                        }
                    }

                    if (nプレイヤーc < -xx_9)
                    {
                        nプレイヤーc -= xx_0 / 10;
                    }
                }
                if (nプレイヤーrzimen != 1)
                {
                    if (nプレイヤーc > 100 && nプレイヤーzimen == 0)
                    {
                        nプレイヤーc -= xx_0 * 2 / 3;
                    }
                    if (nプレイヤーc > 100 && nプレイヤーzimen == 1)
                    {
                        nプレイヤーc -= xx_0;
                        if (nプレイヤーzimen == 1)
                        {
                            nプレイヤーc -= xx_0 * 1 / 2;
                        }
                    }
                    nプレイヤーactaon[0] = 3;
                    nプレイヤーkasok += 1;
                }
            }

            if (nプレイヤーactaon[0] == 1)
            {
                if (!(nプレイヤーzimen == 0 && nプレイヤーc > xx_8))
                {
                    if (nプレイヤーc <= xx_9)
                    {
                        nプレイヤーc += xx_0;
                        if (nプレイヤーc > xx_9)
                        {
                            nプレイヤーc = xx_9 + 1;
                        }
                    }
                    if (nプレイヤーc > xx_9)
                    {
                        nプレイヤーc += xx_0 / 10;
                    }
                }
                if (nプレイヤーrzimen != 1)
                {
                    if (nプレイヤーc < -100 && nプレイヤーzimen == 0)
                    {
                        nプレイヤーc += xx_0 * 2 / 3;
                    }
                    if (nプレイヤーc < -100 && nプレイヤーzimen == 1)
                    {
                        nプレイヤーc += xx_0;
                        if (nプレイヤーzimen == 1)
                        {
                            nプレイヤーc += xx_0 * 1 / 2;
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

                v効果音再生(Res.nオーディオ_[1]);

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
                v効果音再生(Res.nオーディオ_[12]);
                DX.StopSoundMem(Res.nオーディオ_[0]);
                DX.StopSoundMem(Res.nオーディオ_[11]);
                DX.StopSoundMem(Res.nオーディオ_[16]);
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
                if (nプレイヤーtm >= 100)
                {
                    b初期化 = false;
                    e現在の画面 = E画面.機数表示;
                    nプレイヤーtm = 0;
                    nプレイヤーkeytm = 0;
                    nokori--;
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
                    DX.StopSoundMem(Res.nオーディオ_[0]);
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
                        int t_ = 28;
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
                        if (nプレイヤーtm == 20) v効果音再生(Res.nオーディオ_[10]);

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
                            DX.StopSoundMem(Res.nオーディオ_[0]);
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
                        b初期化 = false;
                        n中間フラグ = 0;
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
                        xx_5 = 500;
                        ma -= xx_5;
                        fx += xx_5;
                        fzx += xx_5;
                    }

                    if ((nプレイヤーtype == 301 || nプレイヤーtype == 302) && nプレイヤーtm >= 2 && nプレイヤーtm <= 100)
                    {
                        nプレイヤーc = 250;
                        nプレイヤーmuki = 1;
                    }

                    if (nプレイヤーtm == 200)
                    {
                        v効果音再生(Res.nオーディオ_[17]);
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
                            b初期化 = false;
                            n中間フラグ = 0;
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
                xx_0 = 800; xx_1 = 1600;
                if (nプレイヤーc > xx_0 && nプレイヤーc < xx_0 + 200) { nプレイヤーc = xx_0; }
                if (nプレイヤーc > xx_0 + 200) { nプレイヤーc -= 200; }
                if (nプレイヤーc < -xx_0 && nプレイヤーc > -xx_0 - 200) { nプレイヤーc = -xx_0; }
                if (nプレイヤーc < -xx_0 - 200) { nプレイヤーc += 200; }
                if (nプレイヤーd > xx_1) { nプレイヤーd = xx_1; }
            }

            //プレイヤー
            //地面の摩擦
            if (nプレイヤーzimen == 1 && nプレイヤーactaon[0] != 3)
            {
                if ((nプレイヤーtype <= 9) || nプレイヤーtype == 300 || nプレイヤーtype == 301 || nプレイヤーtype == 302)
                {
                    if (nプレイヤーrzimen == 0)
                    {
                        xx_2 = 30; xx_1 = 60; xx_3 = 30;
                        if (nプレイヤーc >= -xx_3 && nプレイヤーc <= xx_3) { nプレイヤーc = 0; }
                        if (nプレイヤーc >= xx_2) { nプレイヤーc -= xx_1; }
                        if (nプレイヤーc <= -xx_2) { nプレイヤーc += xx_1; }
                    }
                    if (nプレイヤーrzimen == 1)
                    {
                        xx_2 = 5; xx_1 = 10; xx_3 = 5;
                        if (nプレイヤーc >= -xx_3 && nプレイヤーc <= xx_3) { nプレイヤーc = 0; }
                        if (nプレイヤーc >= xx_2) { nプレイヤーc -= xx_1; }
                        if (nプレイヤーc <= -xx_2) { nプレイヤーc += xx_1; }
                    }
                }
            }


            //地面判定初期化
            nプレイヤーzimen = 0;

            //場外
            if (nプレイヤーtype <= 9 && nプレイヤーhp >= 1)
            {
                if (ma < 100) { ma = 100; nプレイヤーc = 0; }
                if (ma + nプレイヤーnobia > W) { ma = W - nプレイヤーnobia; nプレイヤーc = 0; }
            }
            if (nプレイヤーb >= 38000 && nプレイヤーhp >= 0 && nステージ色 == 4) { nプレイヤーhp = -2; nメッセージtm = 30; nメッセージtype = 55; }
            if (nプレイヤーb >= 52000 && nプレイヤーhp >= 0) { nプレイヤーhp = -2; }
        }

        void DrawPlayer()
        {
            DXDraw.SetColor(0, 0, 255);

            if (nプレイヤーactp >= 2000) { nプレイヤーactp -= 2000; if (nプレイヤーact == 0) { nプレイヤーact = 1; } else { nプレイヤーact = 0; } }
            if (nプレイヤーmuki == 0) DXDraw.nミラー = 1;

            if (nプレイヤーtype != 200 && nプレイヤーtype != 1)
            {
                if (nプレイヤーzimen == 1)
                {
                    // 読みこんだグラフィックを拡大描画
                    if (nプレイヤーact == 0) DXDraw.DrawGraph(Res.n切り取り画像_[0, 0], ma / 100, nプレイヤーb / 100);
                    if (nプレイヤーact == 1) DXDraw.DrawGraph(Res.n切り取り画像_[1, 0], ma / 100, nプレイヤーb / 100);
                }
                if (nプレイヤーzimen == 0)
                {
                    DXDraw.DrawGraph(Res.n切り取り画像_[2, 0], ma / 100, nプレイヤーb / 100);
                }
            }
            //巨大化
            else if (nプレイヤーtype == 1)
            {
                DXDraw.DrawGraph(Res.n切り取り画像_[41, 0], ma / 100, nプレイヤーb / 100);
            }

            else if (nプレイヤーtype == 200)
            {
                DXDraw.DrawGraph(Res.n切り取り画像_[3, 0], ma / 100, nプレイヤーb / 100);
            }
        }
        #endregion
        #region 地面
        //地面
        const int n地面max = 31;
        int n地面co;
        int[] n地面a = new int[n地面max],
            n地面b = new int[n地面max],
            n地面c = new int[n地面max],
            n地面d = new int[n地面max],
            n地面type = new int[n地面max],
            n地面xtype = new int[n地面max],
            n地面r = new int[n地面max];
        int[] n地面gtype = new int[n地面max];

        void UpdateZimen()
        {
            //壁
            for (int t_ = 0; t_ < n地面max; t_++)
            {
                if (n地面a[t_] - fx + n地面c[t_] >= -12000 && n地面a[t_] - fx <= W)
                {
                    xx_0 = 200; xx_1 = 2400; xx_2 = 1000; xx_7 = 0;

                    xx_8 = n地面a[t_] - fx; xx_9 = n地面b[t_] - fy;
                    if ((n地面type[t_] <= 99 || n地面type[t_] == 200) && nプレイヤーtype < 10)
                    {

                        //おちるブロック
                        if (n地面type[t_] == 51)
                        {
                            if (ma + nプレイヤーnobia > xx_8 + xx_0 + 3000 && ma < xx_8 + n地面c[t_] - xx_0 && nプレイヤーb + nプレイヤーnobib > xx_9 + 3000 && n地面gtype[t_] == 0)
                            {
                                if (n地面xtype[t_] == 0)
                                {
                                    n地面gtype[t_] = 1; n地面r[t_] = 0;
                                }
                            }
                            if (ma + nプレイヤーnobia > xx_8 + xx_0 + 1000 && ma < xx_8 + n地面c[t_] - xx_0 && nプレイヤーb + nプレイヤーnobib > xx_9 + 3000 && n地面gtype[t_] == 0)
                            {
                                if ((n地面xtype[t_] == 10) && n地面gtype[t_] == 0)
                                {
                                    n地面gtype[t_] = 1; n地面r[t_] = 0;
                                }
                            }

                            if ((n地面xtype[t_] == 1) && n地面b[27] >= 25000 && n地面a[27] > ma + nプレイヤーnobia && t_ != 27 && n地面gtype[t_] == 0)
                            {
                                n地面gtype[t_] = 1; n地面r[t_] = 0;
                            }
                            if (n地面xtype[t_] == 2 && n地面b[28] >= 48000 && t_ != 28 && n地面gtype[t_] == 0 && nプレイヤーhp >= 1)
                            {
                                n地面gtype[t_] = 1; n地面r[t_] = 0;
                            }
                            if ((n地面xtype[t_] == 3 && nプレイヤーb >= 30000 || n地面xtype[t_] == 4 && nプレイヤーb >= 25000) && n地面gtype[t_] == 0 && nプレイヤーhp >= 1 && ma + nプレイヤーnobia > xx_8 + xx_0 + 3000 - 300 && ma < xx_8 + n地面c[t_] - xx_0)
                            {
                                n地面gtype[t_] = 1; n地面r[t_] = 0;
                                if (n地面xtype[t_] == 4) n地面r[t_] = 100;
                            }

                            if (n地面gtype[t_] == 1 && n地面b[t_] <= H + 18000)
                            {
                                n地面r[t_] += 120; if (n地面r[t_] >= 1600) { n地面r[t_] = 1600; }
                                n地面b[t_] += n地面r[t_];
                                if (ma + nプレイヤーnobia > xx_8 + xx_0 && ma < xx_8 + n地面c[t_] - xx_0 && nプレイヤーb + nプレイヤーnobib > xx_9 && nプレイヤーb < xx_9 + n地面d[t_] + xx_0)
                                {
                                    nプレイヤーhp--; xx_7 = 1;
                                }
                            }
                        }

                        //おちるブロック2
                        if (n地面type[t_] == 52)
                        {
                            if (n地面gtype[t_] == 0 && ma + nプレイヤーnobia > xx_8 + xx_0 + 2000 && ma < xx_8 + n地面c[t_] - xx_0 - 2500 && nプレイヤーb + nプレイヤーnobib > xx_9 - 3000)
                            {
                                n地面gtype[t_] = 1; n地面r[t_] = 0;
                            }
                            if (n地面gtype[t_] == 1)
                            {
                                n地面r[t_] += 120; if (n地面r[t_] >= 1600) { n地面r[t_] = 1600; }
                                n地面b[t_] += n地面r[t_];
                            }
                        }



                        //通常地面
                        if (xx_7 == 0)
                        {
                            if (ma + nプレイヤーnobia > xx_8 + xx_0 && ma < xx_8 + n地面c[t_] - xx_0 && nプレイヤーb + nプレイヤーnobib > xx_9 && nプレイヤーb + nプレイヤーnobib < xx_9 + xx_1 && nプレイヤーd >= -100) { nプレイヤーb = n地面b[t_] - fy - nプレイヤーnobib + 100; nプレイヤーd = 0; nプレイヤーzimen = 1; }
                            if (ma + nプレイヤーnobia > xx_8 - xx_0 && ma < xx_8 + xx_2 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_1 * 3 / 4 && nプレイヤーb < xx_9 + n地面d[t_] - xx_2) { ma = xx_8 - xx_0 - nプレイヤーnobia; nプレイヤーc = 0; }
                            if (ma + nプレイヤーnobia > xx_8 + n地面c[t_] - xx_0 && ma < xx_8 + n地面c[t_] + xx_0 && nプレイヤーb + nプレイヤーnobib > xx_9 + xx_1 * 3 / 4 && nプレイヤーb < xx_9 + n地面d[t_] - xx_2) { ma = xx_8 + n地面c[t_] + xx_0; nプレイヤーc = 0; }
                            if (ma + nプレイヤーnobia > xx_8 + xx_0 * 2 && ma < xx_8 + n地面c[t_] - xx_0 * 2 && nプレイヤーb > xx_9 + n地面d[t_] - xx_1 && nプレイヤーb < xx_9 + n地面d[t_] + xx_0)
                            {
                                nプレイヤーb = xx_9 + n地面d[t_] + xx_0; if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd * 2 / 3; }
                            }
                        }//xx_7

                        //入る土管
                        if (n地面type[t_] == 50)
                        {
                            if (ma + nプレイヤーnobia > xx_8 + 2800 && ma < xx_8 + n地面c[t_] - 3000 && nプレイヤーb + nプレイヤーnobib > xx_9 - 1000 && nプレイヤーb + nプレイヤーnobib < xx_9 + xx_1 + 3000 && nプレイヤーzimen == 1 && nプレイヤーactaon[3] == 1 && nプレイヤーtype == 0)
                            {
                                //飛び出し
                                if (n地面xtype[t_] == 0)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 0;
                                }
                                //普通
                                if (n地面xtype[t_] == 1)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 1;
                                }
                                //普通
                                if (n地面xtype[t_] == 2)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 2;
                                }
                                if (n地面xtype[t_] == 5)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 5;
                                }
                                // ループ
                                if (n地面xtype[t_] == 6)
                                {
                                    nプレイヤーtype = 100; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 6;
                                }
                            }
                        }//50

                        //入る土管(左から)
                        if (n地面type[t_] == 40)
                        {
                            if (ma + nプレイヤーnobia > xx_8 - 300 && ma < xx_8 + n地面c[t_] - 1000 && nプレイヤーb > xx_9 + 1000 && nプレイヤーb + nプレイヤーnobib < xx_9 + xx_1 + 4000 && nプレイヤーzimen == 1 && nプレイヤーactaon[4] == 1 && nプレイヤーtype == 0)
                            {//end();
                             //飛び出し
                                if (n地面xtype[t_] == 0)
                                {
                                    nプレイヤーtype = 500; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]);//mxtype=1;
                                    nプレイヤーtype = 100; nプレイヤーxtype = 10;
                                }

                                if (n地面xtype[t_] == 2)
                                {
                                    nプレイヤーxtype = 3;
                                    nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]);//mxtype=1;
                                    nプレイヤーtype = 100;
                                }
                                // ループ
                                if (n地面xtype[t_] == 6)
                                {
                                    nプレイヤーtype = 3; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[7]); nプレイヤーxtype = 6;
                                }
                            }
                        }//40




                    }//stype
                    else {
                        if (ma + nプレイヤーnobia > xx_8 + xx_0 && ma < xx_8 + n地面c[t_] - xx_0 && nプレイヤーb + nプレイヤーnobib > xx_9 && nプレイヤーb < xx_9 + n地面d[t_] + xx_0)
                        {
                            if (n地面type[t_] == 100)
                            {
                                if (n地面xtype[t_] == 0 || n地面xtype[t_] == 1 && nブロックtype[1] != 3)
                                {
                                    ayobi(n地面a[t_] + 1000, 32000, 0, 0, 0, 3, 0); n地面a[t_] = -800000000; v効果音再生(Res.nオーディオ_[10]);
                                }
                            }
                            if (n地面type[t_] == 101) { ayobi(n地面a[t_] + 6000, -4000, 0, 0, 0, 3, 1); n地面a[t_] = -800000000; v効果音再生(Res.nオーディオ_[10]); }
                            if (n地面type[t_] == 102)
                            {
                                if (n地面xtype[t_] == 0)
                                {
                                    for (int t3 = 0; t3 <= 3; t3++) { ayobi(n地面a[t_] + t3 * 3000, -3000, 0, 0, 0, 0, 0); }
                                }
                                if (n地面xtype[t_] == 1 && nプレイヤーb >= 16000) { ayobi(n地面a[t_] + 1500, 44000, 0, -2000, 0, 4, 0); }
                                else if (n地面xtype[t_] == 2) { ayobi(n地面a[t_] + 4500, 30000, 0, -1600, 0, 5, 0); v効果音再生(Res.nオーディオ_[10]); n地面xtype[t_] = 3; n地面a[t_] -= 12000; }
                                else if (n地面xtype[t_] == 3) { n地面a[t_] += 12000; n地面xtype[t_] = 4; }
                                else if (n地面xtype[t_] == 4) { ayobi(n地面a[t_] + 4500, 30000, 0, -1600, 0, 5, 0); v効果音再生(Res.nオーディオ_[10]); n地面xtype[t_] = 5; n地面xtype[t_] = 0; }

                                else if (n地面xtype[t_] == 7) { nプレイヤーainmsgtype = 1; }
                                else if (n地面xtype[t_] == 8) { ayobi(n地面a[t_] - 5000 - 3000 * 1, 26000, 0, -1600, 0, 5, 0); v効果音再生(Res.nオーディオ_[10]); }
                                else if (n地面xtype[t_] == 9) { for (int t3 = 0; t3 <= 2; t3++) { ayobi(n地面a[t_] + t3 * 3000 + 3000, 48000, 0, -6000, 0, 3, 0); } }
                                if (n地面xtype[t_] == 10) { n地面a[t_] -= 5 * 30 * 100; n地面type[t_] = 101; }

                                if (n地面xtype[t_] == 12)
                                {
                                    for (int t3 = 1; t3 <= 3; t3++) { ayobi(n地面a[t_] + t3 * 3000 - 1000, 40000, 0, -2600, 0, 9, 0); }
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
                                    DX.StopSoundMem(Res.nオーディオ_[0]); nプレイヤーtype = 302; nプレイヤーtm = 0; v効果音再生(Res.nオーディオ_[16]);
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


                            if (n地面type[t_] == 300 && nプレイヤーtype == 0 && nプレイヤーb < xx_9 + n地面d[t_] + xx_0 - 3000 && nプレイヤーhp >= 1) { DX.StopSoundMem(Res.nオーディオ_[0]); nプレイヤーtype = 300; nプレイヤーtm = 0; ma = n地面a[t_] - fx - 2000; v効果音再生(Res.nオーディオ_[11]); }

                            //中間ゲート
                            if (n地面type[t_] == 500 && nプレイヤーtype == 0 && nプレイヤーhp >= 1)
                            {
                                n中間フラグ += 1;
                                n地面a[t_] = -80000000;
                            }

                        }

                        if (n地面type[t_] == 180)
                        {
                            n地面r[t_]++;
                            if (n地面r[t_] >= n地面gtype[t_])
                            {
                                n地面r[t_] = 0;
                                ayobi(n地面a[t_], 30000, DX.GetRand(600) - 300, -1600 - DX.GetRand(900), 0, 84, 0);
                            }
                        }

                    }
                }
            }//壁
        }

        void DrawZimen()
        {
            //地面(壁)//土管も
            for (int t_ = 0; t_ < n地面max; t_++)
            {
                if (n地面a[t_] - fx + n地面c[t_] >= -10 && n地面a[t_] - fx <= W + 1100)
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
                            for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[1, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                            }
                        }
                        if (n地面xtype[t_] == 1 || n地面xtype[t_] == 2)
                        {
                            for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[31, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                            }
                        }
                        if (n地面xtype[t_] == 3 || n地面xtype[t_] == 4)
                        {
                            for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                for (int t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(Res.n切り取り画像_[65, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + 29 * t2 + n全体のポイントb);
                                }
                            }
                        }

                        if (n地面xtype[t_] == 10)
                        {
                            for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[65, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                            }
                        }

                    }//51


                    //落ちるやつ
                    if (n地面type[t_] == 52)
                    {
                        int xx_29 = 0; if (nステージ色 == 2) { xx_29 = 30; }
                        if (nステージ色 == 4) { xx_29 = 60; }
                        if (nステージ色 == 5) { xx_29 = 90; }

                        for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                        {
                            if (n地面xtype[t_] == 0)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[5 + xx_29, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb);
                                if (nステージ色 != 4) { DXDraw.DrawGraph(Res.n切り取り画像_[6 + xx_29, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29); }
                                else { DXDraw.DrawGraph(Res.n切り取り画像_[5 + xx_29, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29); }
                            }
                            if (n地面xtype[t_] == 1)
                            {
                                for (int t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(Res.n切り取り画像_[1 + xx_29, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29 * t2);
                                }
                            }

                            if (n地面xtype[t_] == 2)
                            {
                                for (int t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                                {
                                    DXDraw.DrawGraph(Res.n切り取り画像_[5 + xx_29, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + n全体のポイントb + 29 * t2);
                                }
                            }

                        }
                    }


                    //ステージトラップ
                    if (bトラップ表示)
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
                        DXDraw.DrawGraph(Res.n切り取り画像_[20, 4], (n地面a[t_] - fx) / 100, (n地面b[t_] - fy) / 100);
                    }
                }
            }//t


            //描画上書き(土管)
            for (int t_ = 0; t_ < n地面max; t_++)
            {
                if (n地面a[t_] - fx + n地面c[t_] >= -10 && n地面a[t_] - fx <= W + 1100)
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
                        for (int t3 = 0; t3 <= n地面c[t_] / 3000; t3++)
                        {
                            for (int t2 = 0; t2 <= n地面d[t_] / 3000; t2++)
                            {
                                DXDraw.DrawGraph(Res.n切り取り画像_[65, 1], (n地面a[t_] - fx) / 100 + n全体のポイントa + 29 * t3, (n地面b[t_] - fy) / 100 + 29 * t2 + n全体のポイントb);
                            }
                        }
                    }

                }
            }//t
        }
        #endregion
        #region リフト
        //リフト
        int nリフトmax = 21;
        int nリフトco;
        int[] nリフトa = new int[nリフトmax],
            nリフトb = new int[nリフトmax],
            nリフトc = new int[nリフトmax],
            nリフトd = new int[nリフトmax],
            nリフトe = new int[nリフトmax],
            nリフトf = new int[nリフトmax];
        int[] nリフトtype = new int[nリフトmax],
            nリフトgtype = new int[nリフトmax],
            nリフトacttype = new int[nリフトmax],
            nリフトsp = new int[nリフトmax];
        int[] nリフトmuki = new int[nリフトmax],
            nリフトon = new int[nリフトmax],
            nリフトee = new int[nリフトmax];
        int[] nリフトsok = new int[nリフトmax],
            nリフトmovep = new int[nリフトmax],
            nリフトmove = new int[nリフトmax];

        void Updateリフト()
        {
            //リフト
            for (int t_ = 0; t_ < nリフトmax; t_++)
            {
                xx_10 = nリフトa[t_]; xx_11 = nリフトb[t_]; xx_12 = nリフトc[t_]; xx_13 = nリフトd[t_];
                xx_8 = xx_10 - fx; xx_9 = xx_11 - fy;
                if (xx_8 + xx_12 >= -10 - 12000 && xx_8 <= W + 12100)
                {
                    xx_0 = 500; xx_1 = 1200; xx_2 = 1000; xx_7 = 2000;
                    if (nプレイヤーd >= 100) { xx_1 = 900 + nプレイヤーd; }

                    if (nプレイヤーd > xx_1) xx_1 = nプレイヤーd + 100;

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
                            if (nリフトb[t_] - fy < -2100) { nリフトb[t_] = H + fy + 2000; }
                            if (nリフトb[t_] - fy > H + 2000) { nリフトb[t_] = -2100 + fy; }
                            break;

                        case 6:
                            if (nリフトon[t_] == 1) nリフトf[t_] = 40;
                            break;

                        case 7:
                            break;


                    }//sw

                    //乗ったとき
                    if (ma + nプレイヤーnobia > xx_8 + xx_0 && ma < xx_8 + xx_12 - xx_0 && nプレイヤーb + nプレイヤーnobib > xx_9 && nプレイヤーb + nプレイヤーnobib < xx_9 + xx_1 && nプレイヤーd >= -100)
                    {
                        nプレイヤーb = xx_9 - nプレイヤーnobib + 100;

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
                            v効果音再生(Res.nオーディオ_[3]);
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
                        if (ma + nプレイヤーnobia > xx_8 + xx_0 - 2000 && ma < xx_8 + xx_12 - xx_0) { nリフトon[t_] = 1; }// && mb+mnobib>xx_9-1000 && mb+mnobib<xx_9+xx_1+2000)
                        if (nリフトon[t_] == 1) { nリフトf[t_] = 60; nリフトb[t_] += nリフトe[t_]; }
                    }


                    //トゲ(下)
                    if (ma + nプレイヤーnobia > xx_8 + xx_0 && ma < xx_8 + xx_12 - xx_0 && nプレイヤーb > xx_9 - xx_1 / 2 && nプレイヤーb < xx_9 + xx_1 / 2)
                    {
                        if (nリフトtype[t_] == 2) { if (nプレイヤーd < 0) { nプレイヤーd = -nプレイヤーd; } nプレイヤーb += 110; if (nプレイヤーmutekitm <= 0) nプレイヤーhp -= 1; nプレイヤーmutekitm = 40; }
                    }
                    //落下
                    if (nリフトacttype[t_] == 6)
                    {
                        if (ma + nプレイヤーnobia > xx_8 + xx_0 && ma < xx_8 + xx_12 - xx_0) { nリフトon[t_] = 1; }
                    }

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
                    for (int tt_ = 0; tt_ < n敵キャラmax; tt_++)
                    {
                        if (n敵キャラzimentype[tt_] == 1)
                        {
                            if (n敵キャラa[tt_] + n敵キャラnobia[tt_] - fx > xx_8 + xx_0 && n敵キャラa[tt_] - fx < xx_8 + xx_12 - xx_0 && n敵キャラb[tt_] + n敵キャラnobib[tt_] > xx_11 - 100 && n敵キャラb[tt_] + n敵キャラnobib[tt_] < xx_11 + xx_1 + 500 && n敵キャラd[tt_] >= -100)
                            {
                                n敵キャラb[tt_] = xx_9 - n敵キャラnobib[tt_] + 100; n敵キャラd[tt_] = 0; n敵キャラxzimen[tt_] = 1;
                            }
                        }
                    }
                }
            }//リフト
        }

        void Drawリフト()
        {
            //リフト
            for (int t_ = 0; t_ < nリフトmax; t_++)
            {
                xx_0 = nリフトa[t_] - fx; xx_1 = nリフトb[t_] - fy;
                if (xx_0 + nリフトc[t_] >= -10 && xx_1 <= W + 12100 && nリフトc[t_] / 100 >= 1)
                {
                    xx_2 = 14; if (nリフトsp[t_] == 1) { xx_2 = 12; }

                    if (nリフトsp[t_] <= 9 || nリフトsp[t_] >= 20)
                    {
                        DXDraw.SetColor(220, 220, 0);
                        if (nリフトsp[t_] == 2 || nリフトsp[t_] == 3) { DXDraw.SetColor(0, 220, 0); }
                        if (nリフトsp[t_] == 21) { DXDraw.SetColor(180, 180, 180); }
                        DXDraw.DrawBox塗り潰し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, xx_2);

                        DXDraw.SetColor(180, 180, 0);
                        if (nリフトsp[t_] == 2 || nリフトsp[t_] == 3) { DXDraw.SetColor(0, 180, 0); }
                        if (nリフトsp[t_] == 21) { DXDraw.SetColor(150, 150, 150); }
                        DXDraw.DrawBox塗り無し((nリフトa[t_] - fx) / 100, (nリフトb[t_] - fy) / 100, nリフトc[t_] / 100, xx_2);
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
                        for (int t2 = 0; t2 <= 2; t2++)
                        {
                            xx_6 = 1 + 0; DXDraw.DrawGraph(Res.n切り取り画像_[xx_6, 1], (nリフトa[t_] - fx) / 100 + t2 * 29, (nリフトb[t_] - fy) / 100);
                        }
                    }//15
                }
            }//t
        }
        #endregion
        #region 絵
        //効果を持たないグラ
        const int n絵max = 201;
        int n絵co;
        int[] n絵a = new int[n絵max],
            n絵b = new int[n絵max],
            n絵nobia = new int[n絵max],
            n絵nobib = new int[n絵max],
            n絵c = new int[n絵max],
            n絵d = new int[n絵max];
        int[] n絵e = new int[n絵max],
            n絵f = new int[n絵max],
            n絵tm = new int[n絵max];
        int[] n絵gtype = new int[n絵max];

        void Update絵()
        {
            //グラ
            for (int t_ = 0; t_ < n絵max; t_++)
            {
                xx_0 = n絵a[t_] - fx; xx_1 = n絵b[t_] - fy;
                xx_2 = n絵nobia[t_] / 100; xx_3 = n絵nobib[t_] / 100;
                if (n絵tm[t_] >= 0) n絵tm[t_]--;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= W && xx_1 + xx_3 * 100 >= -10 - 8000 && xx_3 <= H && n絵tm[t_] >= 0)
                {
                    n絵a[t_] += n絵c[t_]; n絵b[t_] += n絵d[t_];
                    n絵c[t_] += n絵e[t_]; n絵d[t_] += n絵f[t_];

                }
                else { n絵a[t_] = -9000000; }

            }//emax
        }

        void Draw絵()
        {
            //グラ
            for (int t_ = 0; t_ < n絵max; t_++)
            {
                xx_0 = n絵a[t_] - fx; xx_1 = n絵b[t_] - fy;
                xx_2 = n絵nobia[t_] / 100; xx_3 = n絵nobib[t_] / 100;
                if (xx_0 + xx_2 * 100 >= -10 && xx_1 <= W && xx_1 + xx_3 * 100 >= -10 - 8000 && xx_3 <= H)
                {

                    //コイン
                    if (n絵gtype[t_] == 0)
                        DXDraw.DrawGraph(Res.n切り取り画像_[0, 2], xx_0 / 100, xx_1 / 100);

                    //ブロックの破片
                    if (n絵gtype[t_] == 1)
                    {
                        if (nステージ色 == 1 || nステージ色 == 3 || nステージ色 == 5) DXDraw.SetColor(9 * 16, 6 * 16, 3 * 16);
                        if (nステージ色 == 2) DXDraw.SetColor(0, 120, 160);
                        if (nステージ色 == 4) DXDraw.SetColor(192, 192, 192);

                        DXDraw.DrawOval塗り潰し(xx_0 / 100, xx_1 / 100, 7, 7);
                        DXDraw.SetColor(0, 0, 0);
                        DXDraw.DrawOval塗り無し(xx_0 / 100, xx_1 / 100, 7, 7);
                    }

                    //リフトの破片
                    if (n絵gtype[t_] == 2 || n絵gtype[t_] == 3)
                    {
                        if (n絵gtype[t_] == 3) DXDraw.nミラー = 1;
                        DXDraw.DrawGraph(Res.n切り取り画像_[0, 5], xx_0 / 100, xx_1 / 100);
                        DXDraw.nミラー = 0;
                    }

                    //ポール
                    if (n絵gtype[t_] == 4)
                    {
                        DXDraw.SetColorWhite();
                        DXDraw.DrawBox塗り潰し((xx_0) / 100 + 10, (xx_1) / 100, 10, xx_3);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawBox塗り無し((xx_0) / 100 + 10, (xx_1) / 100, 10, xx_3);
                        DXDraw.SetColor(250, 250, 0);
                        DXDraw.DrawOval塗り潰し((xx_0) / 100 + 15 - 1, (xx_1) / 100, 10, 10);
                        DXDraw.SetColorBlack();
                        DXDraw.DrawOval塗り無し((xx_0) / 100 + 15 - 1, (xx_1) / 100, 10, 10);
                    }


                }
            }
        }
        #endregion
        #region ステージデータ
        static byte[,] NewMap(byte[][] def)
        {
            int h = 17, w = 1001;

            var map = new byte[h, w];
            for (int i = 0; i < def.Length; i++)
            {
                for (int j = 0; j < def[i].Length; j++)
                {
                    map[i, j] = def[i][j];
                }
            }

            return map;
        }

        static byte[,] stagedatex1 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,99, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,98,98,98, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0,98, 0, 0, 0, 1,98, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 1,98, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,98, 0, 0, 0, 0, 0, 0, 1,98, 0, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0,80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0,40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 7, 7, 7, 7, 7,40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,83, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0,41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,40, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50, 0, 0, 0, 0, 0,50, 0, 0,81,41, 0, 0, 0, 0, 0,81,98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50, 0,50, 0, 0,51, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,81, 0, 0, 0, 4, 4, 4, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0,41, 0, 0, 0, 0, 0,50, 0,50, 0, 0,41, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 4,81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex2 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 7},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0,83, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,44, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex3 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 0, 0},
        new byte[]{ 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,98, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,97,44, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,54, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7, 7, 7, 7, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0,98, 2, 2,98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 7, 7, 7, 7, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 4, 4, 4, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 4, 0,51, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 1, 1, 4, 4, 4, 4, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 4, 0, 0, 0, 0, 4, 0, 4, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,40, 0, 0, 0, 0, 0, 0,30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 4, 4, 4, 4, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 1, 0, 7, 0, 0, 0, 0, 0, 0, 0,50, 0,50, 0, 4, 0, 4, 0, 4, 0, 4, 0,50, 0, 0, 4, 0, 4, 0, 4, 0, 4, 0, 0, 0, 0,50,50,50, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 4, 4, 4, 4, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        new byte[]{ 5, 5, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 0, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0} ,
        new byte[]{ 6, 6, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 0, 0, 6, 6, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        });

        static byte[,] stagedatex4 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,99, 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,83, 0, 0,},
        new byte[]{ 0, 0,40, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0,41, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 81,},
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex5 = NewMap(new byte[][]{//                                                                                                                                                                                     中間                                                                                                                                                                                                                                                           
		new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,57, 0, 0, 0,84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,51, 0, 0, 0,84, 0, 0, 0, 0, 0,99, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 0, 0,57, 0, 0, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,56, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0,83, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,83, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,30, 0, 0, 0, 0, 0, 0,85,85, 0, 0, 0, 0, 0, 0, 0,97, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0,81, 0, 0, 0, 0, 0, 0, 0, 0, 0,81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,81, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0,81, 0, 0, 0, 0,50, 0,50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,81, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 0, 0, 0, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex6 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,},
        new byte[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,},
        new byte[]{ 1,54, 0,54, 0,54, 0,54, 0,54, 0,54, 0,54, 0,54, 1, 0,},
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 1, 8, 8, 8, 8,} ,
        new byte[]{ 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex7 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 9, 0, 9, 0, 9, 0, 9, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
        new byte[]{ 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 0, 0, 8, 8, 8, 8, 8,} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex8 = NewMap(new byte[][]{//                                                                                                                                                                                     中間                                                                                                                                                                                                                                                           
		new byte[]{ 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 7, 7, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 3, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0,30, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 3, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 7, 7, 2, 2, 7, 5, 5, 5, 5, 0, 0, 0, 3, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0,59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,59, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0,59, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,40, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,41, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 5, 5, 5,86, 0, 0,86, 0, 5, 5, 5, 5, 5,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,86, 0, 0,86, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,86, 5, 5, 5, 5, 5,86, 0, 0,86, 0, 0, 5, 5, 5, 5, 5, 5, 5,86, 0, 0,86, 5, 5, 5, 5,86, 0, 0,86, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,86, 0, 5, 5,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0,86, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,41, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex9 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,99, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 4, 4, 4, 4, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 4, 4, 4, 4, 4, 0, 0, 4, 7, 7, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 2, 2,98, 2, 4, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,10,10,10,10, 0, 0,10,10,10,10, 4, 1, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 7, 0, 4, 4, 4, 4, 4, 4, 4, 4} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 7, 7, 7, 4, 4, 4, 0, 0, 0, 0,80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 7, 0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0,81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,81, 0, 0, 0,81, 0, 0, 0, 0, 0, 0, 0, 0,50, 0, 0,50, 0, 0,50,81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,81, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 5, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 5, 5, 5} ,
        new byte[]{ 6, 6, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 0, 0, 6, 6, 6} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex10 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7, 0, 0, 0},
        new byte[]{ 0,80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5},
        new byte[]{ 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex11 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,98, 4, 4, 4, 4, 4, 4, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,98, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,10,10,10,10,10,10,10,10,10,10,10, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0,10,10,10,10,10,10,10,10,10, 0, 0, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,51, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,10,10,10,10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0,30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,57, 0, 0, 0, 0, 0,57, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0,10, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,44, 0, 0, 1, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 7, 7, 7, 0,97, 0, 0, 0, 1, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1} ,
        new byte[]{ 4, 7, 7, 7, 7, 7, 7, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 0, 0, 0, 1, 1, 0, 0, 0, 0,44, 0, 0, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 1, 1, 0, 0, 0,97, 0, 0, 0, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1} ,
        new byte[]{ 4, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1} ,
        new byte[]{ 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1} ,
        new byte[]{ 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 6, 6, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex12 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,99, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50,51, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0,40, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new byte[]{ 0, 0,41, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0,54, 0, 0},
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex13 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 7, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0,56, 0, 0, 0, 0, 0, 0, 0, 0, 4,10,10,10,10,10,10,10,10,10,10,10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,99, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,51, 0, 1, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 1, 0, 0, 0, 1, 7, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0,10, 4, 4, 4, 0,54, 0,54, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 4, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,58, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,52, 0, 0, 0, 0, 4, 1, 1, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,10,10, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0,30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 6, 6, 6, 6, 6} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex14 = NewMap(new byte[][]{
        new byte[]{ 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0,10, 0, 0, 0,10,10,10, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7,10,10,10, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5} ,
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 7, 7, 7, 3, 7, 0, 7, 5, 0, 0, 5, 5, 5, 0,58, 0, 5, 0, 0, 5, 5} ,
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 0, 0, 0, 0,59,59, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5,59, 0, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 5, 5, 5, 5, 5,40, 0, 5, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0,59, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 5,86, 5, 5, 5, 5,41, 0, 5,86, 0, 0,86, 5, 5, 5, 5,86, 0, 0,86, 0, 0,86, 5, 0,86, 5, 5, 5,86, 0, 0, 5, 5, 5, 5, 5} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,59,59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,59, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex15 = NewMap(new byte[][]{
        new byte[]{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,98} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 7, 7, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 5, 5, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0,10,10, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0,44, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0,97, 0, 0, 0} ,
        new byte[]{ 0,40, 0, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 5, 5, 5} ,
        new byte[]{86,41, 0,86, 0, 5,86, 0, 0,86, 0, 5,86, 0, 0,86, 0, 0,86} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });

        static byte[,] stagedatex16 = NewMap(new byte[][]{
        new byte[]{ 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 5, 5, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 5, 0, 0, 5, 0, 5, 0,10,10, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,60, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 5, 0, 5, 0, 0, 0, 5, 0, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 3, 0, 5, 0, 3, 0, 0, 0, 5, 0, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 5, 0, 5, 5, 5, 0, 5, 0, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7, 7, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 3, 0, 0, 3, 0, 0, 3, 7, 0, 3, 7, 7, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 5, 0, 5, 0, 0, 0, 5, 0, 5,10,10, 0, 5, 0, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 7, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 5, 0, 0, 0, 5, 0, 5, 7, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0,30, 0, 5, 0, 0, 0, 0, 0, 0, 7, 7, 5, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 5, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 5, 5, 5, 5, 0, 0, 5, 0, 0, 7, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 5, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 5,59, 0,59, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 5,40, 0, 5, 0, 0, 5, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 5, 0, 5, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 5, 0,59, 0, 5, 5, 5, 5, 5, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 5,41, 0, 5,86, 0, 5,86, 0, 5, 5, 5, 5,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0, 5,86, 0, 0,86, 0, 0,86, 5, 0,86, 0, 5,86, 5, 0, 5,86, 0, 0, 5, 5, 5, 5,86, 0, 0, 5,86,59, 0, 5, 5, 5, 5, 5,86, 0, 0,86, 5, 5,86, 0, 0,86, 0, 0,86, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5,86, 0, 0,86, 0, 0,86, 0, 0,86, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,59, 0, 0, 0, 0, 0,59, 0,59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,59, 0,59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });
        static byte[,] stagedatex17 = NewMap(new byte[][]{
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,99, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 7, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 7, 7, 7, 7, 4, 0, 0,82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4,10,10, 0, 0,10,10, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 7, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 3, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 7, 4, 4, 4, 4, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 0, 0, 4, 0, 7, 7, 4, 4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 4} ,
        new byte[]{ 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 4, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,51, 1, 0,81, 0, 0, 1, 1, 1, 1, 1, 7, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 7, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4} ,
        new byte[]{ 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 0, 7, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5} ,
        new byte[]{ 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6} ,
        new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        });
        #endregion
    }
}

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
        static void Main(string[] args)
        {
            //applog無効
            DX.SetOutApplicationLogValidFlag(DX.FALSE);
            //画面サイズ設定
            DX.SetGraphMode(W / 100, H / 100, 16);
            //最大化の防止
            DX.ChangeWindowMode(DX.TRUE);
            //タイトルの変更
            DX.SetMainWindowText("しょぼんのアクション");
                        //アイコン
            DX.SetWindowIconHandle(Properties.Resources.icon.Handle);


            // ＤＸライブラリ初期化処理(エラーが起きたら直ちに終了)
            if (DX.DxLib_Init() == -1) return;

            //初期化
            Res.Init();
            Key.Init();

            //フォント
            DX.SetFontSize(16);
            DX.SetFontThickness(4);

            Scene scene = new Title();
            //ループ
            while (DX.ProcessMessage() == 0 && !Key.GetKey(DX.KEY_INPUT_ESCAPE))
            {
                long nタイマー測定 = DX.GetNowCount();

                Key.Update();

                //ダブルバッファリング
                DX.SetDrawScreen(DX.DX_SCREEN_BACK);
                DX.ClearDrawScreen();
                
                scene.Update();
                scene.Draw();
                Scene next=scene.NextScene;
                if (next != null)
                {
                    scene = next;
                }
                
                DX.ScreenFlip();

                //30-fps
                xx_0 = 30;
                if (Key.GetKey(DX.KEY_INPUT_SPACE)) {
                    xx_0 = 60;
                }

                while (DX.GetNowCount() - nタイマー測定 < 1000 / xx_0) ;
            }

            //ＤＸライブラリ使用の終了処理
            DX.DxLib_End();
        }

    }
}
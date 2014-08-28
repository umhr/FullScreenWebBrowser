using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FullScreenWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // ウィンドウの枠無し
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // ウィンドウの位置を指定できるように。
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;

            // ◆モニタサイズを取得（複数の場合も対応）
            // モニタサイズ保持用の構造体を生成
            //*
            Rectangle screenRectangle = new MultiScreen().rectangle();
            this.Top = screenRectangle.Top;
            this.Left = screenRectangle.Left;
            this.Width = screenRectangle.Width;
            this.Height = screenRectangle.Height;
            /**/

            // バイナリーと同階層のindex.htmlをブラウザで表示
            String htmlPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "index.html";

            // 実行ファイルにファイルをドロップした場合はそのパスに上書き
            // 実行ファイルにドロップされたファイルのパスを取得する
            // http://dobon.net/vb/dotnet/programing/dropfiletoexe.html
            string[] cmds = System.Environment.GetCommandLineArgs();

            if (cmds.Length > 1)
            {
                //ドロップされたファイルのパスをすべて表示
                for (int i = 1; i < cmds.Length; i++)
                {
                    // Console.WriteLine(cmds[i]);
                    htmlPath = cmds[i];
                }
            }

            // ブラウザにURIを渡す。
            webBrowser1.Url = new Uri(htmlPath);
        }
    }
}

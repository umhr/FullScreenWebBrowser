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

            // ◆モニタサイズを取得（複数の場合も対応）
            // モニタサイズ保持用の構造体を生成
            //Rectangle screenRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle screenRectangle = new MultiScreen().rectangle();
            this.Top = screenRectangle.Top;
            this.Left = screenRectangle.Left;
            this.Width = screenRectangle.Width;
            this.Height = screenRectangle.Height;

            /*
            // ディスプレイの解像度を取得するには？
            // http://www.atmarkit.co.jp/fdotnet/dotnettips/003screen/screen.html
            foreach (Screen s in Screen.AllScreens)
            {
                //Console.WriteLine(s.Bounds);
                screenRectangle.X = Math.Min(screenRectangle.X, s.Bounds.X);
                screenRectangle.Y = Math.Min(screenRectangle.Y, s.Bounds.Y);

                screenRectangle.Width = Math.Max(screenRectangle.Width, s.Bounds.Right);
                screenRectangle.Height = Math.Max(screenRectangle.Height, s.Bounds.Bottom);
            }
            //Console.WriteLine(screenRectangle);

            // ウィンドウの位置やサイズを指定
            this.Top = screenRectangle.Top;
            this.Left = screenRectangle.Left;
            this.Width = screenRectangle.Width - screenRectangle.X;
            this.Height = screenRectangle.Height - screenRectangle.Y;
            */

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

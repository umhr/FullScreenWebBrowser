using System;
using System.Drawing;
using System.Windows.Forms;

namespace FullScreenWebBrowser
{
    class MultiScreen
    {
        public Rectangle rectangle()
        {
            Rectangle result = new Rectangle(0, 0, 0, 0);
            Rectangle temp = new Rectangle(0, 0, 0, 0);

            // ディスプレイの解像度を取得するには？
            // http://www.atmarkit.co.jp/fdotnet/dotnettips/003screen/screen.html
            foreach (Screen s in Screen.AllScreens)
            {
                //Console.WriteLine(s.Bounds);
                temp.X = Math.Min(temp.X, s.Bounds.X);
                temp.Y = Math.Min(temp.Y, s.Bounds.Y);

                temp.Width = Math.Max(temp.Width, s.Bounds.Right);
                temp.Height = Math.Max(temp.Height, s.Bounds.Bottom);
            }
            //Console.WriteLine(screenRectangle);

            // ウィンドウの位置やサイズを指定
            result.X = temp.X;
            result.Y = temp.Y;
            result.Width = temp.Width - temp.X;
            result.Height = temp.Height - temp.Y;

            if (Properties.Settings.Default.Width > -1)
            {
                result.Width = Properties.Settings.Default.Width;
            }
            if (Properties.Settings.Default.Height > -1)
            {
                result.Height = Properties.Settings.Default.Height;
            }
            if (Properties.Settings.Default.Left > -1)
            {
                result.X = Properties.Settings.Default.Left;
            }
            if (Properties.Settings.Default.Top > -1)
            {
                result.Y = Properties.Settings.Default.Top;
            }

            return result;
        }
    }

}

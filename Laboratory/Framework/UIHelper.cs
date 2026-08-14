using System;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Framework
{
    public static class UiHelper
    {
        public static void SetRoundedCorners(Control control, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            control.Region = new Region(path);
        }

        public static class AppColors
        {
            public static readonly Color Primary = Color.FromArgb(37, 99, 235);
            public static readonly Color PrimaryDark = Color.FromArgb(30, 64, 175);
            public static readonly Color LightBlue = Color.FromArgb(219, 234, 254);
            public static readonly Color Background = Color.FromArgb(248, 250, 252);
            public static readonly Color Gray = Color.FromArgb(107, 114, 128);
            public static readonly Color Warning = Color.FromArgb(255, 193, 7);
            public static readonly Color Secondary = Color.FromArgb(108, 117, 125);
            public static readonly Color Success = Color.FromArgb(25, 135, 84);
        }

        public static void SetOpacity(Control control, float opacity)
        {
            if(control == null) return;
            opacity = Math.Max(0f, Math.Min(1f, opacity));
            if (control is PictureBox pictureBox && pictureBox.Image != null)
            {
                pictureBox.Image = SetImageOpacity(pictureBox.Image, opacity);
                return;
            }

            var color = control.BackColor;
            control.BackColor = Color.FromArgb((int)(opacity * 255),
                color.R,
                color.G,
                color.B
                );
        }

        private static Image SetImageOpacity(Image image, float opacity)
        {
            var bitmap = new Bitmap(image.Width, image.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                var colorMatrix = new ColorMatrix
                {
                    Matrix33 = opacity
                };

                using (var attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(
                        colorMatrix,
                        ColorMatrixFlag.Default,
                        ColorAdjustType.Bitmap
                        );

                    graphics.DrawImage(
                        image,
                        new Rectangle(0, 0, image.Width, image.Height),
                        0, 0, 
                        image.Width, 
                        image.Height, 
                        GraphicsUnit.Pixel, 
                        attributes);
                }
            }

            return bitmap;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace projetoJogo_IsabellaEMariaLucia
{
    public class Bullet : PictureBox
    {
        public int Velocidade { get; set; } = 37;

        public Bullet(int x, int y)
        {
            BackColor = Color.Transparent;

            Left = x;
            Top = y;
            Size = new System.Drawing.Size(100,50);
            SizeMode = PictureBoxSizeMode.StretchImage;
            string caminhoimagem = Path.Combine( 
                Application.StartupPath,
                "assets",
                "bullet.png");
            Image = Image.FromFile(caminhoimagem);
        }
        public void Mover()
        {
            Left += Velocidade;
        }
        public bool SaiuDaTela()
        {
            return Left + Width > 1920;
        }
    }
}

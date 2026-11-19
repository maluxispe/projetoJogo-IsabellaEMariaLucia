using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace projetoJogo_IsabellaEMariaLucia
{
    public class Player : PictureBox
    {
        public int Velocidade { get; set; } = 10;

        public List <Bullet> Balas { get; set; } = new List<Bullet>();

        public Player() // metodo construtor
        {
            Size = new System.Drawing.Size(200, 150);//tamanho de player
            SizeMode = PictureBoxSizeMode.StretchImage; //ajustando imagem
            string caminhoimagem = Path.Combine( //criando variavel caminhoimagem
            Application.StartupPath,
            "assets",
            "sabrina.png"
            );
            Image = Image.FromFile(caminhoimagem);
        }
            public void Mover(Keys tecla, int larguraTela,int alturaTela)
        {
            if (tecla == Keys.W || tecla == Keys.Up)
            {
                //Top = Top - Velocidade
                Top -= Velocidade;
                //verificar se saiu pela parte decima da tela
                if(Top + Height < 0)
                {
                    Top = alturaTela;//aparece na parte de baixo da tela
                }
            }
            else if (tecla == Keys.A || tecla == Keys.Left)
            {
                Left -= Velocidade;
                if (Left + Width < 0)
                {
                    Left = larguraTela; //aparece na parte esquerda da tela
                }
            }
            else if (tecla == Keys.S || tecla == Keys.Down)
            {
                Top += Velocidade;
                 if (Top > alturaTela)
                {
                    Top = 0;//aparece na parte de cima da tela
                }
            }
            else if (tecla == Keys.D || tecla == Keys.Right)
            {
                Left += Velocidade;
                if (Left > larguraTela)
                {
                    Left = 0; //aparece na parte direita da tela
                }
            }
           
        }
        public Bullet Atirar()
        {
            Bullet disparo = new Bullet(
                Left + (Width / 2),
                Top + (Height/2)
                );
            Balas.Add(disparo);
            return disparo;
        }
    }
}

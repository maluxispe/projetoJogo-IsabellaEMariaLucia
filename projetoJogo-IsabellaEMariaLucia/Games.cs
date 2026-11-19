using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoJogo_IsabellaEMariaLucia
{
    public partial class Games : Form
    {
        private Player jogador;
        public Games()
        {
            InitializeComponent();
            IniciarJogo();
        }
        private void IniciarJogo()
        {
            //instalar um objeto player
            jogador = new Player();
            //Definir uma posição para o jogador
            jogador.Location = new Point(50, 340);//primeiro largura e depois altura
            //adicionar o Player no formulário
            Controls.Add(jogador);

            //ativa a verificação de teclas pressionadas
            KeyPreview = true;
            //quando a tecla for pressionada, executa o método key_Donw
            KeyDown += Games_KeyDown;

        }

        private void Games_KeyDown(object sender, KeyEventArgs e)
        {
            //executa o método mover e passa a tecla pressionada
            jogador.Mover(e.KeyCode, ClientSize.Width, ClientSize.Height);
            if (e.KeyCode == Keys.Space)
            {
                Bullet disparo = jogador.Atirar();
                Controls.Add(disparo);
            }
        }

        private void Games_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = jogador.Balas.Count - 1; i>=0; i--)
            {
                Bullet disparo = jogador.Balas[i];
                disparo.Mover();

                if (disparo.SaiuDaTela())
                {
                    Controls.Remove(disparo);
                    jogador.Balas.RemoveAt(i);
                    disparo.Dispose();
                }
            }
        }
    }
}

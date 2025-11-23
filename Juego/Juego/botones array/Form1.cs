using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Crea los botones que va a haber
        public Button[] boton = new Button[42];
        int turno = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //La posicion inicial de los botones loc vertical, loc1 horizontal (de la primera fila)
            int Loc = 200;
            int Loc1 = 430;
            turno = turno + 1;



            for (int n = 0; n < 42; n++)
            {
                boton[n] = new Button();
                this.Controls.Add(boton[n]);
                //Baja las cordenadas de las siguientes filas
                if (n == 7 || n == 14 || n == 21 || n == 28 || n == 35 || n == 42)
                {
                    Loc = Loc + 70;
                    Loc1 = 430;
                }
                boton[n].Left = 1 + Loc1;
                boton[n].Top = 15 + Loc;
                //El tamaño de los botones
                boton[n].Width = 40;
                boton[n].Height = 40;
                boton[n].BackColor = SystemColors.Info;
                boton[n].Click += new EventHandler(Jugadas);

                if (n < 35)
                {
                    boton[n].Enabled = false;

                }

                //La distancia entre los botones de la misma fila
                Loc1 = Loc1 + 100;
                this.button1.Visible = false;
            }
        }


        public void Jugadas(object sender, EventArgs e)
        {
            turno = turno + 1;
            if (turno % 2 == 0)
            {
                Button B = (Button)sender;
                int index = Array.IndexOf(boton, B);

                B.Enabled = false;
                B.BackColor = Color.Blue;

                // Habilitar el botón de arriba
                if (index - 7 >= 0)
                {
                    boton[index - 7].Enabled = true;
                }
            }
            else
            {
                Button B = (Button)sender;
                int index = Array.IndexOf(boton, B);
                B.Enabled = false;
                B.BackColor = Color.Red;

                // Habilitar el botón de arriba
                if (index - 7 >= 0)
                {
                    boton[index - 7].Enabled = true;
                }
            }
        }

    private void Form1_Load(object sender, EventArgs e)
        {
            //Maximiza la pantalla automaticamente    
            this.WindowState = FormWindowState.Maximized;
        }
    }
}

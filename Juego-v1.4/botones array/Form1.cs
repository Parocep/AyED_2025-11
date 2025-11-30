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
            int Loc = 150;
            int Loc1 = 300;
            turno = turno + 1;



            for (int n = 0; n < 42; n++)
            {
                boton[n] = new Button();
                this.Controls.Add(boton[n]);
                //Baja las cordenadas de las siguientes filas
                if (n == 7 || n == 14 || n == 21 || n == 28 || n == 35 || n == 42)
                {
                    Loc = Loc + 70;
                    Loc1 = 300;
                }
                boton[n].Left = 1 + Loc1;
                boton[n].Top = 15 + Loc;
                //El tamaño de los botones
                boton[n].Width = 40;
                boton[n].Height = 40;
                boton[n].BackColor = SystemColors.Info;
                //Conecta con las otras funciones
                boton[n].Click += new EventHandler(Jugadas);
                boton[n].Click += new EventHandler(CondicionGanarHorizontalAzul);
                boton[n].Click += new EventHandler(CondicionGanarHorizontalRojo);
                boton[n].Click += new EventHandler(CondicionGanarVerticalAzul);
                boton[n].Click += new EventHandler(CondicionGanarVerticalRojo);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalDerechaAzul);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalDerechaRojo);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalIzquierdaAzul);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalIzquierdaRojo);
                //Desactiva las filas superiores
                if (n < 35)
                {
                    boton[n].Enabled = false;

                }

                //La distancia entre los botones de la misma fila
                Loc1 = Loc1 + 100;
                //Hace invisible a los botones del menu
                this.button1.Visible = false;
                this.button2.Visible = false;
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
        public void JugadasFacil(object sender, EventArgs e)
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
               
                Random R = new Random();
                int aleatorio = R.Next(boton.Length);
                while (boton[aleatorio].Enabled != true)
                {
                  aleatorio = R.Next(boton.Length);
                }
                boton[aleatorio].Enabled = false;
                boton[aleatorio].BackColor = Color.Red;

          
                if (aleatorio - 7 >= 0)
                {
                  boton[aleatorio - 7].Enabled = true;
                }
        }
        public void JugadasDificil(object sender, EventArgs e)
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
            Random R = new Random();
            int aleatorio = R.Next(boton.Length);
            int bloqueo = 0;
            if(index < 29)
            {
                if (boton[index].BackColor == boton[index + 7].BackColor && boton[index].BackColor == boton[index + 14].BackColor )
                {
                    boton[index - 7].BackColor = Color.Red;
                    boton[index - 7].Enabled = false;
                    if(index > 7)
                    {
                        boton[index - 14].Enabled = true;
                    }
                    bloqueo = bloqueo + 1;
                }
            }
            if (bloqueo == 0)
            {
                if (boton[index]. BackColor == Color.Blue &&
                    boton[index-1].BackColor == Color.Blue &&
                    boton[index-2].BackColor == Color.Blue)
                {
                    if((index+1) == 7 || (index + 1) == 14 || (index + 1) == 21 || (index + 1) == 28 || (index + 1) == 35 || (index + 1) == 42||
                        boton[index+1].BackColor == Color.Red)
                    {
                        if (boton[index-3].Enabled == true)
                        {
                            boton[index-3].BackColor = Color.Red;
                            boton[index -3].Enabled = false;
                            bloqueo = bloqueo + 1;
                            if (index > 7)
                            {
                                boton[index - 10].Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        if (boton[index + 1].Enabled == true)
                        {
                            boton[index + 1].BackColor = Color.Red;
                            boton[index + 1].Enabled = false;
                            bloqueo = bloqueo + 1;
                            if (index > 7)
                            {
                                boton[index - 6].Enabled = true;
                            }
                        }
                    }
                }
            }
            if (bloqueo == 0 && index < 39)
            {
                if (boton[index].BackColor == Color.Blue &&
                    boton[index + 1].BackColor == Color.Blue &&
                    boton[index + 2].BackColor == Color.Blue)
                {
                    if ((index - 1) == -1 || (index - 1) == 6 || (index - 1) == 13 || (index - 1) == 20 || (index - 1) == 27 || (index - 1) == 34 ||
                        boton[index - 1].BackColor == Color.Red)
                    {
                        if (boton[index + 3].Enabled == true)
                        {
                            boton[index + 3].BackColor = Color.Red;
                            boton[index + 3].Enabled = false;
                            bloqueo = bloqueo + 1;
                            if (index > 7)
                            {
                                boton[index - 4].Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        if (boton[index - 1].Enabled == true)
                        {
                            boton[index - 1].BackColor = Color.Red;
                            boton[index - 1].Enabled = false;
                            bloqueo = bloqueo + 1;
                            if (index > 7)
                            {
                                boton[index - 8].Enabled = true;
                            }
                        }
                    }
                }
            }
            if (bloqueo == 0)
            {
                while (boton[aleatorio].Enabled != true)
                {
                    aleatorio = R.Next(boton.Length);
                }
                boton[aleatorio].Enabled = false;
                boton[aleatorio].BackColor = Color.Red;
                if (aleatorio - 7 >= 0)
                {
                    boton[aleatorio - 7].Enabled = true;
                }
            }
            bloqueo = bloqueo - 1;
          
        }
       
        //Crea la condicion de ganar del azul horizontalmente
        public void CondicionGanarHorizontalAzul(object sender, EventArgs e)
        {
            //fila 1  
            if (boton[0].BackColor == boton[1].BackColor && boton[0].BackColor == boton[2].BackColor && boton[0].BackColor == boton[3].BackColor && boton[0].BackColor == Color.Blue ||
                boton[1].BackColor == boton[2].BackColor && boton[1].BackColor == boton[3].BackColor && boton[1].BackColor == boton[4].BackColor && boton[1].BackColor == Color.Blue ||
                boton[2].BackColor == boton[3].BackColor && boton[2].BackColor == boton[4].BackColor && boton[2].BackColor == boton[5].BackColor && boton[2].BackColor == Color.Blue ||
                boton[3].BackColor == boton[4].BackColor && boton[3].BackColor == boton[5].BackColor && boton[3].BackColor == boton[6].BackColor && boton[3].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 2
            if (boton[7].BackColor == boton[8].BackColor && boton[7].BackColor == boton[9].BackColor && boton[7].BackColor == boton[10].BackColor && boton[7].BackColor == Color.Blue ||
                boton[8].BackColor == boton[9].BackColor && boton[8].BackColor == boton[10].BackColor && boton[8].BackColor == boton[11].BackColor && boton[8].BackColor == Color.Blue ||
                boton[9].BackColor == boton[10].BackColor && boton[9].BackColor == boton[11].BackColor && boton[9].BackColor == boton[12].BackColor && boton[9].BackColor == Color.Blue ||
                boton[10].BackColor == boton[11].BackColor && boton[10].BackColor == boton[12].BackColor && boton[10].BackColor == boton[13].BackColor && boton[10].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 3
            if (boton[14].BackColor == boton[15].BackColor && boton[14].BackColor == boton[16].BackColor && boton[14].BackColor == boton[17].BackColor && boton[14].BackColor == Color.Blue ||
                boton[15].BackColor == boton[16].BackColor && boton[15].BackColor == boton[17].BackColor && boton[15].BackColor == boton[18].BackColor && boton[15].BackColor == Color.Blue ||
                boton[16].BackColor == boton[17].BackColor && boton[16].BackColor == boton[18].BackColor && boton[16].BackColor == boton[19].BackColor && boton[16].BackColor == Color.Blue ||
                boton[17].BackColor == boton[18].BackColor && boton[17].BackColor == boton[19].BackColor && boton[17].BackColor == boton[20].BackColor && boton[17].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 4
            if (boton[21].BackColor == boton[22].BackColor && boton[21].BackColor == boton[23].BackColor && boton[21].BackColor == boton[24].BackColor && boton[21].BackColor == Color.Blue ||
              boton[22].BackColor == boton[23].BackColor && boton[22].BackColor == boton[24].BackColor && boton[22].BackColor == boton[25].BackColor && boton[22].BackColor == Color.Blue ||
              boton[23].BackColor == boton[24].BackColor && boton[23].BackColor == boton[25].BackColor && boton[23].BackColor == boton[26].BackColor && boton[23].BackColor == Color.Blue ||
              boton[24].BackColor == boton[25].BackColor && boton[24].BackColor == boton[26].BackColor && boton[24].BackColor == boton[27].BackColor && boton[24].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 5
            if (boton[28].BackColor == boton[29].BackColor && boton[28].BackColor == boton[30].BackColor && boton[28].BackColor == boton[31].BackColor && boton[28].BackColor == Color.Blue ||
              boton[29].BackColor == boton[30].BackColor && boton[29].BackColor == boton[31].BackColor && boton[29].BackColor == boton[32].BackColor && boton[29].BackColor == Color.Blue ||
              boton[30].BackColor == boton[31].BackColor && boton[30].BackColor == boton[32].BackColor && boton[30].BackColor == boton[33].BackColor && boton[30].BackColor == Color.Blue ||
              boton[31].BackColor == boton[32].BackColor && boton[31].BackColor == boton[33].BackColor && boton[31].BackColor == boton[34].BackColor && boton[31].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 6
            if (boton[35].BackColor == boton[36].BackColor && boton[35].BackColor == boton[37].BackColor && boton[35].BackColor == boton[38].BackColor && boton[35].BackColor == Color.Blue ||
              boton[36].BackColor == boton[37].BackColor && boton[36].BackColor == boton[38].BackColor && boton[36].BackColor == boton[39].BackColor && boton[36].BackColor == Color.Blue ||
              boton[37].BackColor == boton[38].BackColor && boton[37].BackColor == boton[39].BackColor && boton[37].BackColor == boton[40].BackColor && boton[37].BackColor == Color.Blue ||
              boton[38].BackColor == boton[39].BackColor && boton[38].BackColor == boton[40].BackColor && boton[38].BackColor == boton[41].BackColor && boton[38].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }



        }
        //Crea la condicion de ganar del rojo horizontalmente
        public void CondicionGanarHorizontalRojo(object sender, EventArgs e)
        {
            //fila 1  
            if (boton[0].BackColor == boton[1].BackColor && boton[0].BackColor == boton[2].BackColor && boton[0].BackColor == boton[3].BackColor && boton[0].BackColor == Color.Red ||
                boton[1].BackColor == boton[2].BackColor && boton[1].BackColor == boton[3].BackColor && boton[1].BackColor == boton[4].BackColor && boton[1].BackColor == Color.Red ||
                boton[2].BackColor == boton[3].BackColor && boton[2].BackColor == boton[4].BackColor && boton[2].BackColor == boton[5].BackColor && boton[2].BackColor == Color.Red ||
                boton[3].BackColor == boton[4].BackColor && boton[3].BackColor == boton[5].BackColor && boton[3].BackColor == boton[6].BackColor && boton[3].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 2
            if (boton[7].BackColor == boton[8].BackColor && boton[7].BackColor == boton[9].BackColor && boton[7].BackColor == boton[10].BackColor && boton[7].BackColor == Color.Red ||
                boton[8].BackColor == boton[9].BackColor && boton[8].BackColor == boton[10].BackColor && boton[8].BackColor == boton[11].BackColor && boton[8].BackColor == Color.Red ||
                boton[9].BackColor == boton[10].BackColor && boton[9].BackColor == boton[11].BackColor && boton[9].BackColor == boton[12].BackColor && boton[9].BackColor == Color.Red ||
                boton[10].BackColor == boton[11].BackColor && boton[10].BackColor == boton[12].BackColor && boton[10].BackColor == boton[13].BackColor && boton[10].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 3
            if (boton[14].BackColor == boton[15].BackColor && boton[14].BackColor == boton[16].BackColor && boton[14].BackColor == boton[17].BackColor && boton[14].BackColor == Color.Red ||
                boton[15].BackColor == boton[16].BackColor && boton[15].BackColor == boton[17].BackColor && boton[15].BackColor == boton[18].BackColor && boton[15].BackColor == Color.Red ||
                boton[16].BackColor == boton[17].BackColor && boton[16].BackColor == boton[18].BackColor && boton[16].BackColor == boton[19].BackColor && boton[16].BackColor == Color.Red ||
                boton[17].BackColor == boton[18].BackColor && boton[17].BackColor == boton[19].BackColor && boton[17].BackColor == boton[20].BackColor && boton[17].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 4
            if (boton[21].BackColor == boton[22].BackColor && boton[21].BackColor == boton[23].BackColor && boton[21].BackColor == boton[24].BackColor && boton[21].BackColor == Color.Red ||
              boton[22].BackColor == boton[23].BackColor && boton[22].BackColor == boton[24].BackColor && boton[22].BackColor == boton[25].BackColor && boton[22].BackColor == Color.Red ||
              boton[23].BackColor == boton[24].BackColor && boton[23].BackColor == boton[25].BackColor && boton[23].BackColor == boton[26].BackColor && boton[23].BackColor == Color.Red ||
              boton[24].BackColor == boton[25].BackColor && boton[24].BackColor == boton[26].BackColor && boton[24].BackColor == boton[27].BackColor && boton[24].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 5
            if (boton[28].BackColor == boton[29].BackColor && boton[28].BackColor == boton[30].BackColor && boton[28].BackColor == boton[31].BackColor && boton[28].BackColor == Color.Red ||
              boton[29].BackColor == boton[30].BackColor && boton[29].BackColor == boton[31].BackColor && boton[29].BackColor == boton[32].BackColor && boton[29].BackColor == Color.Red ||
              boton[30].BackColor == boton[31].BackColor && boton[30].BackColor == boton[32].BackColor && boton[30].BackColor == boton[33].BackColor && boton[30].BackColor == Color.Red ||
              boton[31].BackColor == boton[32].BackColor && boton[31].BackColor == boton[33].BackColor && boton[31].BackColor == boton[34].BackColor && boton[31].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //fila 6
            if (boton[35].BackColor == boton[36].BackColor && boton[35].BackColor == boton[37].BackColor && boton[35].BackColor == boton[38].BackColor && boton[35].BackColor == Color.Red ||
              boton[36].BackColor == boton[37].BackColor && boton[36].BackColor == boton[38].BackColor && boton[36].BackColor == boton[39].BackColor && boton[36].BackColor == Color.Red ||
              boton[37].BackColor == boton[38].BackColor && boton[37].BackColor == boton[39].BackColor && boton[37].BackColor == boton[40].BackColor && boton[37].BackColor == Color.Red ||
              boton[38].BackColor == boton[39].BackColor && boton[38].BackColor == boton[40].BackColor && boton[38].BackColor == boton[41].BackColor && boton[38].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }


        }
        //Crea la condicion de ganar del azul vertical
        public void CondicionGanarVerticalAzul(object sender, EventArgs e)
        {
            //Columna 1
            if (boton[0].BackColor == boton[7].BackColor && boton[0].BackColor == boton[14].BackColor && boton[0].BackColor == boton[21].BackColor && boton[0].BackColor == Color.Blue ||
                boton[7].BackColor == boton[14].BackColor && boton[7].BackColor == boton[21].BackColor && boton[7].BackColor == boton[28].BackColor && boton[7].BackColor == Color.Blue ||
                boton[14].BackColor == boton[21].BackColor && boton[14].BackColor == boton[28].BackColor && boton[14].BackColor == boton[35].BackColor && boton[14].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 2
            if (boton[1].BackColor == boton[8].BackColor && boton[1].BackColor == boton[15].BackColor && boton[1].BackColor == boton[22].BackColor && boton[1].BackColor == Color.Blue ||
                boton[8].BackColor == boton[15].BackColor && boton[8].BackColor == boton[22].BackColor && boton[8].BackColor == boton[29].BackColor && boton[8].BackColor == Color.Blue ||
                boton[15].BackColor == boton[22].BackColor && boton[15].BackColor == boton[29].BackColor && boton[15].BackColor == boton[36].BackColor && boton[15].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 3
            if (boton[2].BackColor == boton[9].BackColor && boton[2].BackColor == boton[16].BackColor && boton[2].BackColor == boton[23].BackColor && boton[2].BackColor == Color.Blue ||
                boton[9].BackColor == boton[16].BackColor && boton[9].BackColor == boton[23].BackColor && boton[9].BackColor == boton[30].BackColor && boton[9].BackColor == Color.Blue ||
                boton[16].BackColor == boton[23].BackColor && boton[16].BackColor == boton[30].BackColor && boton[16].BackColor == boton[37].BackColor && boton[16].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 4
            if (boton[3].BackColor == boton[10].BackColor && boton[3].BackColor == boton[17].BackColor && boton[3].BackColor == boton[24].BackColor && boton[3].BackColor == Color.Blue ||
                boton[10].BackColor == boton[17].BackColor && boton[10].BackColor == boton[24].BackColor && boton[10].BackColor == boton[31].BackColor && boton[10].BackColor == Color.Blue ||
                boton[17].BackColor == boton[24].BackColor && boton[17].BackColor == boton[31].BackColor && boton[17].BackColor == boton[38].BackColor && boton[17].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 5
            if (boton[4].BackColor == boton[11].BackColor && boton[4].BackColor == boton[18].BackColor && boton[4].BackColor == boton[25].BackColor && boton[4].BackColor == Color.Blue ||
                boton[11].BackColor == boton[18].BackColor && boton[11].BackColor == boton[25].BackColor && boton[11].BackColor == boton[32].BackColor && boton[11].BackColor == Color.Blue ||
                boton[18].BackColor == boton[25].BackColor && boton[18].BackColor == boton[32].BackColor && boton[18].BackColor == boton[39].BackColor && boton[18].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 6
            if (boton[5].BackColor == boton[12].BackColor && boton[5].BackColor == boton[19].BackColor && boton[5].BackColor == boton[26].BackColor && boton[5].BackColor == Color.Blue ||
                boton[12].BackColor == boton[19].BackColor && boton[12].BackColor == boton[26].BackColor && boton[12].BackColor == boton[33].BackColor && boton[12].BackColor == Color.Blue ||
                boton[19].BackColor == boton[26].BackColor && boton[19].BackColor == boton[33].BackColor && boton[19].BackColor == boton[40].BackColor && boton[19].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 7
            if (boton[6].BackColor == boton[13].BackColor && boton[6].BackColor == boton[20].BackColor && boton[6].BackColor == boton[27].BackColor && boton[6].BackColor == Color.Blue ||
                boton[13].BackColor == boton[20].BackColor && boton[13].BackColor == boton[27].BackColor && boton[13].BackColor == boton[34].BackColor && boton[13].BackColor == Color.Blue ||
                boton[20].BackColor == boton[27].BackColor && boton[20].BackColor == boton[34].BackColor && boton[20].BackColor == boton[41].BackColor && boton[20].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
        }
        //Crea la condicion de ganar del rojo vertical
        public void CondicionGanarVerticalRojo(object sender, EventArgs e)
        {
            //Columna 1
            if (boton[0].BackColor == boton[7].BackColor && boton[0].BackColor == boton[14].BackColor && boton[0].BackColor == boton[21].BackColor && boton[0].BackColor == Color.Red ||
                boton[7].BackColor == boton[14].BackColor && boton[7].BackColor == boton[21].BackColor && boton[7].BackColor == boton[28].BackColor && boton[7].BackColor == Color.Red ||
                boton[14].BackColor == boton[21].BackColor && boton[14].BackColor == boton[28].BackColor && boton[14].BackColor == boton[35].BackColor && boton[14].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 2
            if (boton[1].BackColor == boton[8].BackColor && boton[1].BackColor == boton[15].BackColor && boton[1].BackColor == boton[22].BackColor && boton[1].BackColor == Color.Red ||
                boton[8].BackColor == boton[15].BackColor && boton[8].BackColor == boton[22].BackColor && boton[8].BackColor == boton[29].BackColor && boton[8].BackColor == Color.Red ||
                boton[15].BackColor == boton[22].BackColor && boton[15].BackColor == boton[29].BackColor && boton[15].BackColor == boton[36].BackColor && boton[15].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 3
            if (boton[2].BackColor == boton[9].BackColor && boton[2].BackColor == boton[16].BackColor && boton[2].BackColor == boton[23].BackColor && boton[2].BackColor == Color.Red ||
                boton[9].BackColor == boton[16].BackColor && boton[9].BackColor == boton[23].BackColor && boton[9].BackColor == boton[30].BackColor && boton[9].BackColor == Color.Red ||
                boton[16].BackColor == boton[23].BackColor && boton[16].BackColor == boton[30].BackColor && boton[16].BackColor == boton[37].BackColor && boton[16].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 4
            if (boton[3].BackColor == boton[10].BackColor && boton[3].BackColor == boton[17].BackColor && boton[3].BackColor == boton[24].BackColor && boton[3].BackColor == Color.Red ||
                boton[10].BackColor == boton[17].BackColor && boton[10].BackColor == boton[24].BackColor && boton[10].BackColor == boton[31].BackColor && boton[10].BackColor == Color.Red ||
                boton[17].BackColor == boton[24].BackColor && boton[17].BackColor == boton[31].BackColor && boton[17].BackColor == boton[38].BackColor && boton[17].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 5
            if (boton[4].BackColor == boton[11].BackColor && boton[4].BackColor == boton[18].BackColor && boton[4].BackColor == boton[25].BackColor && boton[4].BackColor == Color.Red ||
                boton[11].BackColor == boton[18].BackColor && boton[11].BackColor == boton[25].BackColor && boton[11].BackColor == boton[32].BackColor && boton[11].BackColor == Color.Red ||
                boton[18].BackColor == boton[25].BackColor && boton[18].BackColor == boton[32].BackColor && boton[18].BackColor == boton[39].BackColor && boton[18].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 6
            if (boton[5].BackColor == boton[12].BackColor && boton[5].BackColor == boton[19].BackColor && boton[5].BackColor == boton[26].BackColor && boton[5].BackColor == Color.Red ||
                boton[12].BackColor == boton[19].BackColor && boton[12].BackColor == boton[26].BackColor && boton[12].BackColor == boton[33].BackColor && boton[12].BackColor == Color.Red ||
                boton[19].BackColor == boton[26].BackColor && boton[19].BackColor == boton[33].BackColor && boton[19].BackColor == boton[40].BackColor && boton[19].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Columna 7
            if (boton[6].BackColor == boton[13].BackColor && boton[6].BackColor == boton[20].BackColor && boton[6].BackColor == boton[27].BackColor && boton[6].BackColor == Color.Red ||
                boton[13].BackColor == boton[20].BackColor && boton[13].BackColor == boton[27].BackColor && boton[13].BackColor == boton[34].BackColor && boton[13].BackColor == Color.Red ||
                boton[20].BackColor == boton[27].BackColor && boton[20].BackColor == boton[34].BackColor && boton[20].BackColor == boton[41].BackColor && boton[20].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
        }
        //Crea la condicion de ganar del azul diagonal derecha
        public void CondicionGanarDiagonalDerechaAzul(object sender, EventArgs e)
        {
            //Diagonal 1
            if (boton[14].BackColor == boton[22].BackColor && boton[14].BackColor == boton[30].BackColor && boton[14].BackColor == boton[38].BackColor && boton[14].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 2
            if (boton[7].BackColor == boton[15].BackColor && boton[7].BackColor == boton[23].BackColor && boton[7].BackColor == boton[31].BackColor && boton[7].BackColor == Color.Blue ||
                boton[15].BackColor == boton[23].BackColor && boton[15].BackColor == boton[31].BackColor && boton[15].BackColor == boton[39].BackColor && boton[15].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 3
            if (boton[0].BackColor == boton[8].BackColor && boton[0].BackColor == boton[16].BackColor && boton[0].BackColor == boton[24].BackColor && boton[0].BackColor == Color.Blue ||
                boton[8].BackColor == boton[16].BackColor && boton[8].BackColor == boton[24].BackColor && boton[8].BackColor == boton[32].BackColor && boton[8].BackColor == Color.Blue ||
                boton[16].BackColor == boton[24].BackColor && boton[16].BackColor == boton[32].BackColor && boton[16].BackColor == boton[40].BackColor && boton[16].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 4
            if (boton[1].BackColor == boton[9].BackColor && boton[1].BackColor == boton[17].BackColor && boton[1].BackColor == boton[25].BackColor && boton[1].BackColor == Color.Blue ||
                boton[9].BackColor == boton[17].BackColor && boton[9].BackColor == boton[25].BackColor && boton[9].BackColor == boton[33].BackColor && boton[9].BackColor == Color.Blue ||
                boton[17].BackColor == boton[25].BackColor && boton[17].BackColor == boton[33].BackColor && boton[17].BackColor == boton[41].BackColor && boton[17].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 5
            if (boton[2].BackColor == boton[10].BackColor && boton[2].BackColor == boton[18].BackColor && boton[2].BackColor == boton[26].BackColor && boton[2].BackColor == Color.Blue ||
                boton[10].BackColor == boton[18].BackColor && boton[10].BackColor == boton[26].BackColor && boton[10].BackColor == boton[34].BackColor && boton[10].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 6
            if (boton[3].BackColor == boton[11].BackColor && boton[3].BackColor == boton[19].BackColor && boton[3].BackColor == boton[27].BackColor && boton[3].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
        }
        //Crea la condicion de ganar del rojo diagonal derecha
        public void CondicionGanarDiagonalDerechaRojo(object sender, EventArgs e)
        {
            //Diagonal 1
            if (boton[14].BackColor == boton[22].BackColor && boton[14].BackColor == boton[30].BackColor && boton[14].BackColor == boton[38].BackColor && boton[14].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 2
            if (boton[7].BackColor == boton[15].BackColor && boton[7].BackColor == boton[23].BackColor && boton[7].BackColor == boton[31].BackColor && boton[7].BackColor == Color.Red ||
                boton[15].BackColor == boton[23].BackColor && boton[15].BackColor == boton[31].BackColor && boton[15].BackColor == boton[39].BackColor && boton[15].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 3
            if (boton[0].BackColor == boton[8].BackColor && boton[0].BackColor == boton[16].BackColor && boton[0].BackColor == boton[24].BackColor && boton[0].BackColor == Color.Red ||
                boton[8].BackColor == boton[16].BackColor && boton[8].BackColor == boton[24].BackColor && boton[8].BackColor == boton[32].BackColor && boton[8].BackColor == Color.Red ||
                boton[16].BackColor == boton[24].BackColor && boton[16].BackColor == boton[32].BackColor && boton[16].BackColor == boton[40].BackColor && boton[16].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 4
            if (boton[1].BackColor == boton[9].BackColor && boton[1].BackColor == boton[17].BackColor && boton[1].BackColor == boton[25].BackColor && boton[1].BackColor == Color.Red ||
                boton[9].BackColor == boton[17].BackColor && boton[9].BackColor == boton[25].BackColor && boton[9].BackColor == boton[33].BackColor && boton[9].BackColor == Color.Red ||
                boton[17].BackColor == boton[25].BackColor && boton[17].BackColor == boton[33].BackColor && boton[17].BackColor == boton[41].BackColor && boton[17].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 5
            if (boton[2].BackColor == boton[10].BackColor && boton[2].BackColor == boton[18].BackColor && boton[2].BackColor == boton[26].BackColor && boton[2].BackColor == Color.Red ||
                boton[10].BackColor == boton[18].BackColor && boton[10].BackColor == boton[26].BackColor && boton[10].BackColor == boton[34].BackColor && boton[10].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 6
            if (boton[3].BackColor == boton[11].BackColor && boton[3].BackColor == boton[19].BackColor && boton[3].BackColor == boton[27].BackColor && boton[3].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
        }
        //Crea la condicion de ganar del azul diagonal izquierda
        public void CondicionGanarDiagonalIzquierdaAzul(object sender, EventArgs e)
        {
            //Diagonal 1
            if (boton[20].BackColor == boton[26].BackColor && boton[20].BackColor == boton[32].BackColor && boton[20].BackColor == boton[38].BackColor && boton[20].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 2
            if (boton[13].BackColor == boton[19].BackColor && boton[13].BackColor == boton[25].BackColor && boton[13].BackColor == boton[31].BackColor && boton[13].BackColor == Color.Blue ||
                boton[19].BackColor == boton[25].BackColor && boton[19].BackColor == boton[31].BackColor && boton[19].BackColor == boton[37].BackColor && boton[19].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 3
            if (boton[6].BackColor == boton[12].BackColor && boton[6].BackColor == boton[18].BackColor && boton[6].BackColor == boton[24].BackColor && boton[6].BackColor == Color.Blue ||
                boton[12].BackColor == boton[18].BackColor && boton[12].BackColor == boton[24].BackColor && boton[12].BackColor == boton[30].BackColor && boton[12].BackColor == Color.Blue ||
                boton[18].BackColor == boton[24].BackColor && boton[18].BackColor == boton[30].BackColor && boton[18].BackColor == boton[36].BackColor && boton[18].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 4
            if (boton[5].BackColor == boton[11].BackColor && boton[5].BackColor == boton[17].BackColor && boton[5].BackColor == boton[23].BackColor && boton[5].BackColor == Color.Blue ||
                boton[11].BackColor == boton[17].BackColor && boton[11].BackColor == boton[23].BackColor && boton[11].BackColor == boton[29].BackColor && boton[11].BackColor == Color.Blue ||
                boton[17].BackColor == boton[23].BackColor && boton[17].BackColor == boton[29].BackColor && boton[17].BackColor == boton[35].BackColor && boton[17].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 5
            if (boton[4].BackColor == boton[10].BackColor && boton[4].BackColor == boton[16].BackColor && boton[4].BackColor == boton[22].BackColor && boton[4].BackColor == Color.Blue ||
                boton[10].BackColor == boton[16].BackColor && boton[10].BackColor == boton[22].BackColor && boton[10].BackColor == boton[28].BackColor && boton[10].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 6
            if (boton[3].BackColor == boton[9].BackColor && boton[3].BackColor == boton[15].BackColor && boton[3].BackColor == boton[21].BackColor && boton[3].BackColor == Color.Blue)
            {
                boton[35].BackColor = Color.Yellow;
            }
        }
        public void CondicionGanarDiagonalIzquierdaRojo(object sender, EventArgs e)
        {
            //Diagonal 1
            if (boton[20].BackColor == boton[26].BackColor && boton[20].BackColor == boton[32].BackColor && boton[20].BackColor == boton[38].BackColor && boton[20].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 2
            if (boton[13].BackColor == boton[19].BackColor && boton[13].BackColor == boton[25].BackColor && boton[13].BackColor == boton[31].BackColor && boton[13].BackColor == Color.Red ||
                boton[19].BackColor == boton[25].BackColor && boton[19].BackColor == boton[31].BackColor && boton[19].BackColor == boton[37].BackColor && boton[19].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 3
            if (boton[6].BackColor == boton[12].BackColor && boton[6].BackColor == boton[18].BackColor && boton[6].BackColor == boton[24].BackColor && boton[6].BackColor == Color.Red ||
                boton[12].BackColor == boton[18].BackColor && boton[12].BackColor == boton[24].BackColor && boton[12].BackColor == boton[30].BackColor && boton[12].BackColor == Color.Red ||
                boton[18].BackColor == boton[24].BackColor && boton[18].BackColor == boton[30].BackColor && boton[18].BackColor == boton[36].BackColor && boton[18].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 4
            if (boton[5].BackColor == boton[11].BackColor && boton[5].BackColor == boton[17].BackColor && boton[5].BackColor == boton[23].BackColor && boton[5].BackColor == Color.Red ||
                boton[11].BackColor == boton[17].BackColor && boton[11].BackColor == boton[23].BackColor && boton[11].BackColor == boton[29].BackColor && boton[11].BackColor == Color.Red ||
                boton[17].BackColor == boton[23].BackColor && boton[17].BackColor == boton[29].BackColor && boton[17].BackColor == boton[35].BackColor && boton[17].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 5
            if (boton[4].BackColor == boton[10].BackColor && boton[4].BackColor == boton[16].BackColor && boton[4].BackColor == boton[22].BackColor && boton[4].BackColor == Color.Red ||
                boton[10].BackColor == boton[16].BackColor && boton[10].BackColor == boton[22].BackColor && boton[10].BackColor == boton[28].BackColor && boton[10].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
            //Diagonal 6
            if (boton[3].BackColor == boton[9].BackColor && boton[3].BackColor == boton[15].BackColor && boton[3].BackColor == boton[21].BackColor && boton[3].BackColor == Color.Red)
            {
                boton[35].BackColor = Color.Yellow;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Maximiza la pantalla automaticamente    
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = true;
            this.button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //La posicion inicial de los botones loc vertical, loc1 horizontal (de la primera fila)
            int Loc = 150;
            int Loc1 = 300;



            for (int n = 0; n < 42; n++)
            {
                boton[n] = new Button();
                this.Controls.Add(boton[n]);
                //Baja las cordenadas de las siguientes filas
                if (n == 7 || n == 14 || n == 21 || n == 28 || n == 35 || n == 42)
                {
                    Loc = Loc + 70;
                    Loc1 = 300;
                }
                boton[n].Left = 1 + Loc1;
                boton[n].Top = 15 + Loc;
                //El tamaño de los botones
                boton[n].Width = 40;
                boton[n].Height = 40;
                boton[n].BackColor = SystemColors.Info;
                //Conecta con las otras funciones
                boton[n].Click += new EventHandler(JugadasFacil);
                boton[n].Click += new EventHandler(CondicionGanarHorizontalAzul);
                boton[n].Click += new EventHandler(CondicionGanarHorizontalRojo);
                boton[n].Click += new EventHandler(CondicionGanarVerticalAzul);
                boton[n].Click += new EventHandler(CondicionGanarVerticalRojo);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalDerechaAzul);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalDerechaRojo);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalIzquierdaAzul);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalIzquierdaRojo);
                if (n < 35)
                {
                    boton[n].Enabled = false;

                }
                Loc1 = Loc1 + 100;
                this.button3.Visible = false;
                this.button4.Visible = false;  
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //La posicion inicial de los botones loc vertical, loc1 horizontal (de la primera fila)
            int Loc = 150;
            int Loc1 = 300;



            for (int n = 0; n < 42; n++)
            {
                boton[n] = new Button();
                this.Controls.Add(boton[n]);
                //Baja las cordenadas de las siguientes filas
                if (n == 7 || n == 14 || n == 21 || n == 28 || n == 35 || n == 42)
                {
                    Loc = Loc + 70;
                    Loc1 = 300;
                }
                boton[n].Left = 1 + Loc1;
                boton[n].Top = 15 + Loc;
                //El tamaño de los botones
                boton[n].Width = 40;
                boton[n].Height = 40;
                boton[n].BackColor = SystemColors.Info;
                //Conecta con las otras funciones
                boton[n].Click += new EventHandler(JugadasDificil);
                boton[n].Click += new EventHandler(CondicionGanarHorizontalAzul);
                boton[n].Click += new EventHandler(CondicionGanarHorizontalRojo);
                boton[n].Click += new EventHandler(CondicionGanarVerticalAzul);
                boton[n].Click += new EventHandler(CondicionGanarVerticalRojo);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalDerechaAzul);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalDerechaRojo);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalIzquierdaAzul);
                boton[n].Click += new EventHandler(CondicionGanarDiagonalIzquierdaRojo);
                if (n < 35)
                {
                    boton[n].Enabled = false;

                }
                Loc1 = Loc1 + 100;
                this.button3.Visible = false;
                this.button4.Visible = false;

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CazaBichos
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D fondo;
        Texture2D jugador;
        Texture2D bicho;
        Texture2D bicho2;
        Texture2D bicho3;
        SpriteFont puntaje;
        SpriteFont timer;
        SpriteFont felicidades;
        String salida;
        String mensage;
        String tiempo;
        
        Song musica;
        SoundEffect punto;
        SoundEffect hoho;
        bool bordesX = false;
       
        bool bordesY = false;
        //bool velosidad = false;
        bool aplasta = false;
        bool aplasta2 = false;
        bool aplasta3 = false;
        int velocidadbicho = 3;
        int puntos = 0;
        int width = 800;
        int height = 500;
        int i = 0;
        int n=0;
        int reb = 0;
        int pun=0;
        int time =500;
        Vector2 posicionjugador;

        Vector2 posicionbicho = new Vector2(50,50);
        Vector2 posicionbicho2 = new Vector2(100,50);
        Vector2 posicionbicho3 = new Vector2(150,50);
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           
            
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            posicionjugador.X = 400;
            posicionjugador.Y = 470;
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fondo = Content.Load<Texture2D>("Fondo/FondoNegro");
            jugador = Content.Load<Texture2D>("Graficos/pelota");
            bicho = Content.Load<Texture2D>("Graficos/Bicho");
            bicho2 = Content.Load<Texture2D>("Graficos/Bicho2");
            bicho3 = Content.Load<Texture2D>("Graficos/Bicho3");
            puntaje = Content.Load<SpriteFont>("Puntage");
            timer = Content.Load<SpriteFont>("Timer");
            felicidades = Content.Load<SpriteFont>("felicidades");
            punto = Content.Load<SoundEffect>("Musica/vox_Stewie_5acx19_excellent_01");
            hoho = Content.Load<SoundEffect>("Musica/vox_Stewie_6acx18_uhoh_01");
            musica = Content.Load<Song>("Musica/avicci");
            
            MediaPlayer.Play(musica);
            MediaPlayer.IsRepeating = true;
            
            MediaPlayer.Volume = 0.3f;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
             KeyboardState keyboard = Keyboard.GetState(); 
 
         // Dar la posibilidad de salir del juego 
             if (keyboard.IsKeyDown(Keys.Escape))this.Exit();
            
            
                 if (keyboard.IsKeyDown(Keys.Right)) posicionjugador.X += 5;
                 if (keyboard.IsKeyDown(Keys.Left)) posicionjugador.X -= 5;
                 if (keyboard.IsKeyDown(Keys.Space))
                 {
                     posicionjugador.Y -= 100;
                     reb = 1;
                 }
            //Condicion de Ganar
                 if (puntos <=6) 
                 {
                                          
                     //rebote contra los limites de la pantalla
                     if ((posicionjugador.Y < 0) && (reb == 1) || (posicionjugador.Y < 470))
                     {
                         posicionjugador.Y += 50;
                     }

                     // controla el golpe de la pelota
                     Rectangle rectangulojugador = new Rectangle((int)posicionjugador.X, (int)posicionjugador.Y,
                 jugador.Width, jugador.Height);

                     //rectangulo bicho
                     Rectangle rectangulobicho = new Rectangle((int)posicionbicho.X,
                           (int)posicionbicho.Y,
               bicho.Width, bicho.Height);

                     //rectangulo bicho2
                     Rectangle rectangulobicho2 = new Rectangle((int)posicionbicho2.X,
                           (int)posicionbicho2.Y,
               bicho2.Width, bicho2.Height);

                     //rectangulo bicho3
                     Rectangle rectangulobicho3 = new Rectangle((int)posicionbicho3.X,
                           (int)posicionbicho3.Y,
               bicho3.Width, bicho3.Height);

                     if (rectangulojugador.Intersects(rectangulobicho) && (aplasta == false))
                     {
                         velocidadbicho = 4;
                         aplasta = true;
                         pun = 1;
                         puntos = puntos + pun;
                         punto.Play();

                     }
                     if (rectangulojugador.Intersects(rectangulobicho2) && (aplasta2 == false))
                     {
                         velocidadbicho = 4;
                         aplasta2 = true;
                         pun = 2;
                         puntos = puntos + pun;
                         punto.Play();
                     }
                     if (rectangulojugador.Intersects(rectangulobicho3) && (aplasta3 == false))
                     {
                         velocidadbicho = 4;
                         aplasta3 = true;
                         pun = 3;
                         puntos = puntos + pun;
                         punto.Play();
                     }

                     // que lleguen al limite derecho
                     if (posicionbicho.X >= 700 || posicionbicho2.X >= 700 || posicionbicho3.X >= 700)
                     {
                         bordesX = true;

                     }
                     if (posicionbicho.X <= 48 || posicionbicho2.X <= 48 || posicionbicho3.X <= 48)
                     {
                         bordesX = false;
                         posicionbicho.X += velocidadbicho;
                         posicionbicho2.X += velocidadbicho;
                         posicionbicho3.X += velocidadbicho;
                     }

                     // que lleguen abajo
                     if (posicionbicho.Y >= 480 || posicionbicho2.Y >= 480 || posicionbicho3.Y >= 480 || posicionbicho.Y <= 0 || posicionbicho2.Y <= 0 || posicionbicho3.Y <= 0)
                     {
                         this.Exit();
                         bordesY = true;
                     }
                     //bicho
                     if (bordesY == false && aplasta == false)
                     {
                         if (bordesX == false)
                         {
                             posicionbicho.X += velocidadbicho;

                         }

                         if (bordesX == true)
                         {
                             posicionbicho.X -= velocidadbicho;


                         }

                         if (bordesX == true)
                         {
                             n++;
                             posicionbicho.Y = n;

                         }

                     }
                     //bicho2
                     if (bordesY == false && aplasta2 == false)
                     {
                         if (bordesX == false)
                         {
                             posicionbicho2.X += velocidadbicho;

                         }

                         if (bordesX == true)
                         {

                             posicionbicho2.X -= velocidadbicho;


                         }

                         if (bordesX == true)
                         {
                             n++;

                             posicionbicho2.Y = n;
                         }

                     }

                     //bicho3
                     if (bordesY == false && aplasta3 == false)
                     {
                         if (bordesX == false)
                         {

                             posicionbicho3.X += velocidadbicho;
                         }

                         if (bordesX == true)
                         {

                             posicionbicho3.X -= velocidadbicho;

                         }

                         if (bordesX == true)
                         {
                             n++;

                             posicionbicho3.Y = n;
                         }

                     }
                     time -= 1;
                     //si se termina el tiempo
                     if (time == 0)
                     {
                         this.Exit();

                     }

                     mensage = "La Puntuacion es:" + puntos + " ";
                     salida = string.Concat(mensage);


                     tiempo = "Teimpo Restante:" + time + " ";
                     tiempo = string.Concat(tiempo);
                 }
            base.Update(gameTime);
       
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
                     
            spriteBatch.Draw(fondo, Vector2.Zero, Color.White);
            if (puntos < 6)
            {
                if (aplasta == false)
                {
                    spriteBatch.Draw(bicho, posicionbicho, Color.White);
                }
                if (aplasta2 == false)
                {
                    spriteBatch.Draw(bicho2, posicionbicho2, Color.White);
                }
                if (aplasta3 == false)
                {
                    spriteBatch.Draw(bicho3, posicionbicho3, Color.White);
                }

                spriteBatch.Draw(jugador, posicionjugador, Color.White);
                spriteBatch.DrawString(puntaje, salida, new Vector2(0, 0), Color.Orange);
                spriteBatch.DrawString(timer, tiempo, new Vector2(0, 20), Color.Orange);
            }
             if (puntos >= 6)
                {
                    spriteBatch.DrawString(felicidades, "GANASTE!", new Vector2(280, 160), Color.Red);
                    i = 1;
                }
           
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

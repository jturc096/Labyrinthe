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

namespace Labyrinthe
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState oldState;
        List<Texture2D> tiles = new List<Texture2D>();
        Matrice mat;
        int mapWidth;
        // Create an instance of Texture2D that will
        // contain the background texture.
        Texture2D background;

        // Create a Rectangle that will define
        // the limits for the main game screen.
        Rectangle mainFrame;


        int[,] pos;
        int[,] map;
        int dimHeightMat = 10;
        int dimWidthMat = 10;
        int tilewidth = 10;
        int tileheight = 10;
        bool end;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Components.Add(new GamerServicesComponent(this));
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
            //mat = new Matrice((((graphics.PreferredBackBufferHeight / 3) - 3) / tileheight), (((graphics.PreferredBackBufferWidth / 3) - 3) / tilewidth));
            mat = new Matrice(dimHeightMat, dimWidthMat);
            map = mat.getMap();
            pos = new int[1,2];
            pos[0, 0] = 1;
            pos[0, 1] = 2;
            mapWidth = mat.getDim()[0, 1];
            tiles.Add(Content.Load<Texture2D>("blackTile"));
            tiles.Add(Content.Load<Texture2D>("greytile"));
            tiles.Add(Content.Load<Texture2D>("whiteTile"));
            tiles.Add(Content.Load<Texture2D>("blueTile"));

            // Load the background content.
            background = Content.Load<Texture2D>("Textures\\MARTIN");

            // Set the rectangle parameters.
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            //Sets end boolean to false for the beginning of the game
            end = false;

            // TODO: use this.Content to load your game content here
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
            if(!end){
            KeyboardState newState = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            else if(newState.IsKeyDown(Keys.Escape))
                this.Exit();
            else if ((newState.IsKeyDown(Keys.Down)) && (!oldState.IsKeyDown(Keys.Down)))
            {

                if (map[(pos[0, 0] + 1), pos[0, 1]] == 1) {
                    pos[0, 0]++;
                    if ((pos[0, 0] == map.GetLength(0)-2) && (pos[0, 1] == map.GetLength(1) - 3)) {
                        end = true;
                        GameWon();
                    }
                }
            }
            else if ((newState.IsKeyDown(Keys.Up)) && (!oldState.IsKeyDown(Keys.Up)))
            {
                if (map[(pos[0, 0] - 1), pos[0, 1]] == 1 && (pos[0,0] != 1))
                {
                    pos[0, 0]--;
                }
            }
            else if ((newState.IsKeyDown(Keys.Right)) && (!oldState.IsKeyDown(Keys.Right)))
            {
                if (map[pos[0, 0], (pos[0, 1] + 1)] == 1)
                {
                    pos[0, 1]++;
                }
            }
            else if ((newState.IsKeyDown(Keys.Left)) && (!oldState.IsKeyDown(Keys.Left)))
            {
                if (map[pos[0, 0], (pos[0, 1] - 1)] == 1)
                {
                    pos[0, 1]--;
                }
            }
            // Update saved state.
            oldState = newState;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private void GameWon() {
            List<string> MBOPTIONS = new List<string>();
            MBOPTIONS.Add("OK");
            string msg = "Le niveau a été réussi!.\nCliquer OK pour continuer...";
            Guide.BeginShowMessageBox(
                    "Niveau Réussi", msg, MBOPTIONS, 0,
                    MessageBoxIcon.Alert, GetMBResult, null);
        }

        protected void GetMBResult(IAsyncResult r)
        {
            int? b = Guide.EndShowMessageBox(r);
            if (r.IsCompleted) {
                dimWidthMat += 5;
                Initialize();
            }
            
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
  


                Color colori;
                GraphicsDevice.Clear(Color.White);

                // Draw the background.

                // Start building the sprite.
                spriteBatch.Begin();

                // Draw the background.
                spriteBatch.Draw(background, mainFrame, Color.White);

                // End building the sprite.
                spriteBatch.End();
                
            
                

                spriteBatch.Begin();
                for (int y = 1; y < (map.GetLength(0) - 1); y++)
                {
                    for (int x = 1; x < (map.GetLength(1) - 1); x++)
                    {
                        if ((map[y, x] + 1) == 0)
                        {
                            colori = Color.Black;
                        }
                        else if ((map[y, x] + 1) == 1)
                        {
                            colori = Color.DarkSlateGray;
                        }
                        else
                        {
                            colori = Color.White;
                        }
                        spriteBatch.Draw(tiles[(map[y, x] + 1)],
                        new Rectangle(
                                (x + ((graphics.PreferredBackBufferWidth / 2) - (mapWidth * tilewidth)/2) / tilewidth) * tilewidth,
                                (y + graphics.PreferredBackBufferHeight/40) * tileheight,
                                tilewidth,
                                tileheight), colori);
                       
                    }
                }
                spriteBatch.Draw(tiles[3],
                        new Rectangle(
                                (pos[0, 1] + ((graphics.PreferredBackBufferWidth / 2) - (mapWidth * tilewidth) / 2) / tilewidth) * tilewidth,
                                (pos[0, 0] + graphics.PreferredBackBufferHeight/40) * tileheight,
                                tilewidth,
                                tileheight), Color.AliceBlue);
                base.Draw(gameTime);
                spriteBatch.End();

                // TODO: Add your drawing code here

                base.Draw(gameTime);
            
        }
    }
}

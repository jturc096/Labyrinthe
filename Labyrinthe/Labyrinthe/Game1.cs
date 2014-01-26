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
        
        List<Texture2D> tiles = new List<Texture2D>();
        Matrice mat;
        int[,] map;
        int tilewidth = 10;
        int tileheight = 10;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            mat = new Matrice((((graphics.PreferredBackBufferHeight / 2) - 3) / tileheight), (((graphics.PreferredBackBufferWidth / 2) - 3) / tilewidth));
            map = mat.getMap();
            tiles.Add(Content.Load<Texture2D>("blackTile"));
            tiles.Add(Content.Load<Texture2D>("greytile"));
            tiles.Add(Content.Load<Texture2D>("whiteTile"));

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
            KeyboardState newState = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            else if(newState.IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Color colori;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            for (int y = 1; y < (map.GetLength(0)-1); y++)
            {
                for (int x = 1; x < (map.GetLength(1)-1); x++)
                {
                    if ((map[y, x] + 1) == 0)
                        colori = Color.Black;
                    else if ((map[y, x] + 1) == 1)
                        colori = Color.DarkSlateGray;
                    else
                        colori = Color.White;


                    spriteBatch.Draw(tiles[(map[y, x] + 1)],
                    new Rectangle(
                            (x -1) * tilewidth,
                            (y-1) * tileheight,
                            tilewidth,
                            tileheight), colori);
                    
                }
            }

            base.Draw(gameTime);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

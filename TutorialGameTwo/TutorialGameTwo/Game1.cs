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

namespace TutorialGameTwo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D paddle;
        Vector2 paddlePos = Vector2.Zero;
        Texture2D ball;
        Vector2 ballPos = Vector2.Zero;
        Texture2D blueBlock;
        Texture2D greenBlock;
        Texture2D purpleBlock;
        List<Pair<int, Vector2>> blockList;
        int blockWidth;
        int blockHeight;
        bool movingUp;
        bool movingLeft;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            paddle = Content.Load<Texture2D>("paddle");
            paddlePos = new Vector2((graphics.GraphicsDevice.Viewport.Width / 2) - (paddle.Width / 2), graphics.GraphicsDevice.Viewport.Height - 50);
            ball = Content.Load<Texture2D>("ball");
            ballPos = new Vector2((paddlePos.X + (paddle.Width / 2) - (ball.Width / 2)), paddlePos.Y - (paddle.Height / 2) - (ball.Height / 2));
            blueBlock = Content.Load<Texture2D>("blueBlock");
            greenBlock = Content.Load<Texture2D>("greenBlock");
            purpleBlock = Content.Load<Texture2D>("purpleBlock");
            blockWidth = blueBlock.Width;
            blockHeight = blueBlock.Height;
            blockList = generateBlocks();
            movingUp = true;
            movingLeft = true;

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left) && paddlePos.X > 0)
            {
                paddlePos.X -= 3;
            }
            else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right) && (paddlePos.X + paddle.Width < graphics.GraphicsDevice.Viewport.Width))
            {
                paddlePos.X += 3;
            }

            if(movingUp)
            {
                ballPos.Y -= 3;
            }
            else
            {
                ballPos.Y += 3;
            }
            
            if(movingLeft)
            {
                ballPos.X -= 3;
            }
            else
            {
                ballPos.X += 3;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(paddle, paddlePos, Color.White);
            spriteBatch.Draw(ball, ballPos, Color.White);
            foreach(Pair<int, Vector2> pair in blockList)
            {
                switch(pair.First)
                {
                    case 1:
                        spriteBatch.Draw(blueBlock, pair.Second, Color.White);
                        break;

                    case 2:
                        spriteBatch.Draw(greenBlock, pair.Second, Color.White);
                        break;

                    case 3:
                        spriteBatch.Draw(purpleBlock, pair.Second, Color.White);
                        break;
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected List<Pair<int, Vector2>> generateBlocks()
        {
            List<Pair<int, Vector2>> blocks = new List<Pair<int, Vector2>>();
            Pair<int, Vector2> tempPair;
            Random randBlock = new Random();
            Vector2 startVec = new Vector2(-12, 50);
            int tempTex;
            Vector2 tempVec;
            for(int x = 1; x < 11; ++x)
            {
                for(int y = 1; y < 11; ++y)
                {
                    tempTex = randBlock.Next(1, 4);
                    tempVec = new Vector2((startVec.X + (blockWidth * x)), (startVec.Y + (blockHeight * y)));
                    tempPair = new Pair<int, Vector2>(tempTex, tempVec);
                    blocks.Add(tempPair);
                }
            }

        return blocks;
        }
    }
}

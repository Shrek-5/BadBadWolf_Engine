//Using Statementes
/*
These using statements make it easier
to use the code that MonoGame has to offer.

They are prefixed with Microsoft.Xna.Framework
because MonoGame is an open source re-implementation of Microsoft's XNA framework,
and in order to maintain compatibility with the XNA code,
it uses the same namespaces.
*/

using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BadBadWolfEngine.Controlls;
using BadBadWolfEngine.Entities;

namespace BadBadWolfEngine
{

/* ! The Game1 Class ! 

The main Game1 class inherits from the Game class,
which provides all the core methods for your game
(ie. Load/Unload Content, Update, Draw etc.).
You usually only have one Game class per game,
so its name is not that important.
*/
    public class TestGame : Game
    {

        /* ! Instance Variables !

The two default variables that the blank template starts with are
the GraphicsDeviceManager and SpriteBatch.
Both of these variables are used for drawing to the screen.
*/
        private GraphicsDeviceManager mygraphics;
        private SpriteBatch myspriteBatch;

        public static int windowWidth = 800;
        public static int windowHeight = 600;

        Controller myController;
        private List<Block> blocks;
        private Ball testBall;


        /* ! Constructor !

The main game constructor is used to initialize the starting variables.
In this case, a new GraphicsDeviceManager is created,
and the root directory containing the game's content files is set.
*/
        public TestGame()
        {
            mygraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            mygraphics.PreferredBackBufferWidth = windowWidth;
            mygraphics.PreferredBackBufferHeight = windowHeight;
            mygraphics.ApplyChanges();
        }

        /* ! Initialize Method !

The Initialize method is called after the constructor
but before the main game loop (Update/Draw).
This is where you can query any required services
and load any non-graphic related content.
*/
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            testBall = new Ball();
            blocks = new List<Block>
            {
                new Block(0, 0),
                new Block(64, 64),
                new Block(0, 64),
                new Block(64, 0),
                new Block(-256, -128)
            };
            myController = new Controller();
            base.Initialize();
        }

        /* ! LoadContent Method !

The LoadContent method is used to load your game content.
It is called only once per game,
within the Initialize method,
before the main game loop starts.
*/
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            myspriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            // Load content for each block and the ball
            foreach (var block in blocks)
                block.LoadContent(Content);
            
            testBall.LoadContent(Content);
        }

        /* ! Update Method !

The Update method is called multiple times per second,
and it is used to update your game state
(checking for collisions, gathering input, playing audio, etc.).
*/
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
        
            // The Time since Update was called Last
            float elapedSec = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            myController.UpdateInputStates();

            if (myController.inputExit.getState())
                Exit();

            testBall.UpdateBallState(blocks);

            testBall.Update(myController, elapedSec);

            base.Update(gameTime);
        }
        
        /* ! Draw Method !

Similar to the Update method,
the Draw method is also called multiple times per second.
This, as the name suggests,
is responsible for drawing content to the screen.
*/
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            myspriteBatch.Begin();
            // Draw each block and the ball
            foreach (var block in blocks)
            block.Draw(myspriteBatch);
            testBall.Draw(myspriteBatch);
            myspriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
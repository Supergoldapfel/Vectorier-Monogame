using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Vectorier
{
    public class MenuScreen : GameScreen
    {
        private Game game;
        private GraphicsDeviceManager _graphics;
        private readonly ScreenManager screenManager;
        private SpriteBatch _spriteBatch;
        private GameObjectManager gameObjectManager;
        Texture2D backgroundTexture;
        Texture2D[] newButtonTextures;

        public MenuScreen(Game game, GraphicsDeviceManager gameGraphics, ScreenManager screenManager) : base(game) 
        {
            this.game = game;
            _graphics = gameGraphics;
            this.screenManager = screenManager;
        }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("Images\\menu_background");
            newButtonTextures = new Texture2D[3];
            newButtonTextures[0] = Content.Load<Texture2D>("Images\\new_button");
            newButtonTextures[1] = Content.Load<Texture2D>("Images\\new_button_hover");
            newButtonTextures[2] = Content.Load<Texture2D>("Images\\new_button_click");


            gameObjectManager = new GameObjectManager(game);
            Button newButton = new Button(newButtonTextures[0], newButtonTextures[1], newButtonTextures[2], Vector2.Zero);
            newButton.click += onNewButtonClicked;
            gameObjectManager.addObject(newButton);
        }


		public override void Draw(GameTime gameTime)
        {
            // Background Color
            GraphicsDevice.Clear(Color.LightSkyBlue);

            _spriteBatch.Begin();
            drawBackground();
            _spriteBatch.End();

            gameObjectManager.drawAll();
        }

        public override void Update(GameTime gameTime)
        {
            gameObjectManager.updateAll(gameTime);
        }

        private void drawBackground()
        {
            float screenWidth = _graphics.PreferredBackBufferWidth;
            float screenHeight = _graphics.PreferredBackBufferHeight;
            float backgroundHeightScaling = screenWidth / backgroundTexture.Width;
            float backgroundWidthScaling = screenHeight / backgroundTexture.Height;
            float backgroundAspect = backgroundTexture.Width / backgroundTexture.Height;
            Vector2 backgroundScale;
            // If width scaling is bigger than height scaling, scale by height
            if (backgroundWidthScaling >= backgroundHeightScaling)
            {
                backgroundScale = new Vector2(backgroundWidthScaling, backgroundWidthScaling / backgroundAspect);
            }
            else
            {
                backgroundScale = new Vector2(backgroundHeightScaling * backgroundAspect, backgroundHeightScaling);
            }
            _spriteBatch.Draw(
                backgroundTexture,
                new Vector2(0, 0), // Position
                null, // Rectangle
                Color.White, // Color
                0f, // Rotation
                new Vector2(0, 0), // Origin
                backgroundScale, // Scale
                SpriteEffects.None, // Effects
                0f // Layer
            );
        }

        private void onNewButtonClicked(object sender, EventArgs e)
		{
            screenManager.LoadScreen(new EditorScreen(game), new FadeTransition(GraphicsDevice, Color.Black));
        }
    }
}

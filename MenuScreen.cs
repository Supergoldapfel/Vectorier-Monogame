using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Vectorier
{
    public class MenuScreen : GameScreen
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D backgroundTexture;

        public MenuScreen(Game1 game, GraphicsDeviceManager gameGraphics) : base(game) 
        {
            _graphics = gameGraphics;
        }

		public override void LoadContent()
		{
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("Images\\menu_background");
        }
		public override void Draw(GameTime gameTime)
        {
            // Background Color
            GraphicsDevice.Clear(Color.LightSkyBlue);

            _spriteBatch.Begin();

            drawBackground();
            
            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add update logic here
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
    }
}

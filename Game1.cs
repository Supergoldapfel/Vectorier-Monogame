using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Vectorier
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private readonly ScreenManager _screenManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Register the ScreenManager
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        private void LoadMenuScreen()
        {
            _screenManager.LoadScreen(new MenuScreen(this, _graphics), new FadeTransition(GraphicsDevice, Color.Black));
        }

        protected override void Initialize()
        {
            base.Initialize();
            LoadMenuScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}

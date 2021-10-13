using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Vectorier
{
    public class MenuScreen : GameScreen
    {
        public MenuScreen(Game1 game) : base(game) { }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add update logic here
        }
    }
}

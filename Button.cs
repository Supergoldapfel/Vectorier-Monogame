using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Vectorier
{
	class Button : GameObject
	{
		private bool wasHovering = false;
		private bool wasClicked = false;
		private Texture2D idleTexture;
		private Texture2D hoverTexture;
		private Texture2D clickTexture;
		public event EventHandler click;

		public Button(Texture2D texture, Texture2D hover, Texture2D click, Vector2 position, Vector2 origin, Vector2 scale, float rotation = 0f) : base(texture, position, origin, scale, rotation) 
		{
			idleTexture = texture;
			hoverTexture = hover;
			clickTexture = click;
		}
		public Button(Texture2D texture, Texture2D hover, Texture2D click, Vector2 position, float rotation = 0f) : base(texture, position, rotation) 
		{
			idleTexture = texture;
			hoverTexture = hover;
			clickTexture = click;
		}

		private bool isHovering()
		{
			float mx = Mouse.GetState().X;
			float my = Mouse.GetState().Y;
			float bLeft = position.X - origin.X;
			float bRight = bLeft + texture.Width;
			float bTop = position.Y - origin.Y;
			float bBot = bTop + texture.Height;
			return ((mx>bLeft && mx<bRight) && (my>bTop && my<bBot));
		}

		public override void Update(GameTime gameTime)
		{
			bool isHovering = this.isHovering();
			ButtonState leftButtonState = Mouse.GetState().LeftButton;
			if(isHovering && (leftButtonState == ButtonState.Released) && !wasHovering) {
				texture = hoverTexture;
				wasHovering = true;
			} else if(isHovering && wasHovering && (leftButtonState == ButtonState.Pressed) && !wasClicked) {
				texture = clickTexture;
				wasClicked = true;
			} else if(isHovering && wasClicked && (leftButtonState == ButtonState.Released)) {
				wasClicked = false;
				onClick(EventArgs.Empty);
			} else if(!isHovering) {
				texture = idleTexture;
				wasHovering = false;
				wasClicked = false;
			}
		}

		private void onClick(EventArgs e)
		{
			EventHandler handler = click;
			handler?.Invoke(this, e);
		}
	}
}

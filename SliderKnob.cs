using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Vectorier
{
	class SliderKnob : GameObject
	{
		private Slider slider;

		public SliderKnob(Slider slider, Texture2D texture, Vector2 position, Vector2 origin, Vector2 scale, Color? color = null, float rotation = 0f, float layer = 1f) : base(texture, position, origin, scale, color, rotation, layer)
		{
			this.slider = slider;
		}
		public SliderKnob(Slider slider, Texture2D texture, Vector2 position, Color? color = null, float rotation = 0f, float layer = 1f) : base(texture, position, color, rotation, layer) 
		{
			this.slider = slider;
		}

		public override void Update(GameTime gameTime)
		{
			//Debug.WriteLine(position + " - " + parent.GetType() + " - " + localPosition);
		}
	}
}

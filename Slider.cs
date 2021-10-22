using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Vectorier
{
	class Slider : GameObject
	{
		public SliderKnob sliderKnob;

		public Slider(GameObjectManager manager, Texture2D texture, Texture2D knobTexture, Vector2 position, Vector2 origin, Vector2 scale, Color? color = null, Color? knobColor = null, float rotation = 0f, float layer = 0f) : base(texture, position, origin, scale, color, rotation, layer)
		{
			sliderKnob = new SliderKnob(this, knobTexture, Vector2.Zero, new Vector2(0, knobTexture.Height/2), scale, knobColor ?? Color.Black, layer: layer != 0 ? float.Parse(layer.ToString() + "1") : layer + 0.1f);
			sliderKnob.setParent(this);
			sliderKnob.setLocalPosition(Vector2.Zero);
			manager.addObject(sliderKnob);
		}
		public Slider(GameObjectManager manager, Texture2D texture, Texture2D knobTexture, Vector2 position, Color? color = null, Color? knobColor = null, float rotation = 0f, float layer = 0f) : base(texture, position, color, rotation, layer)
		{
			sliderKnob = new SliderKnob(this, knobTexture, Vector2.Zero, new Vector2(0, knobTexture.Height / 2), Vector2.One, knobColor ?? Color.Black, layer: layer != 0 ? float.Parse(layer.ToString() + "1") : layer + 0.1f);
			sliderKnob.setParent(this);
			sliderKnob.setLocalPosition(Vector2.Zero);
			manager.addObject(sliderKnob);
		}

		public override void Update(GameTime gameTime)
		{
			// Update
		}
	}
}

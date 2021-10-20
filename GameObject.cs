using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Vectorier
{
	abstract class GameObject
	{
		public Texture2D texture;
		public Vector2 position;
		public Vector2 origin;
		public Vector2 scale;
		public float rotation;

		public GameObject(Texture2D texture, Vector2 position, Vector2 origin, Vector2 scale, float rotation = 0f)
		{
			this.texture = texture;
			this.position = position;
			this.origin = origin;
			this.scale = scale;
			this.rotation = rotation;
		}
		public GameObject(Texture2D texture, Vector2 position, float rotation = 0f) 
		{
			this.texture = texture;
			this.position = position;
			this.origin = Vector2.Zero;
			this.scale = Vector2.One;
			this.rotation = rotation;
		}

		public abstract void Update(GameTime gameTime);
	}
}

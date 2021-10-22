using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Vectorier
{
	abstract class GameObject
	{
		public Texture2D texture;
		protected Vector2 position;
		protected Vector2 localPosition;
		public Color color;
		public Vector2 origin;
		public Vector2 scale;
		public float rotation;
		public float layer;
		protected GameObject parent;
		protected List<GameObject> children = new List<GameObject>();

		public GameObject(Texture2D texture, Vector2 position, Vector2 origin, Vector2 scale, Color? color = null, float rotation = 0f, float layer = 1f)
		{
			this.texture = texture;
			this.position = position;
			this.origin = origin;
			this.scale = scale;
			this.color = color ?? Color.White;
			this.rotation = rotation;
			this.layer = layer;
		}
		public GameObject(Texture2D texture, Vector2 position, Color? color = null, float rotation = 0f, float layer = 1f)
		{
			this.texture = texture;
			this.position = position;
			this.origin = Vector2.Zero;
			this.scale = Vector2.One;
			this.color = color ?? Color.White;
			this.rotation = rotation;
			this.layer = layer;
		}

		public abstract void Update(GameTime gameTime);

		public Vector2 getPosition() { return position; }
		public void setPosition(Vector2 newPosition)
		{
			position = newPosition;
			localPosition = parent == null ? position : position - parent.getPosition();
		}
		public Vector2 getLocalPosition() { return localPosition; }
		public void setLocalPosition(Vector2 newLocalPosition)
		{
			localPosition = newLocalPosition;
			position = parent == null ? localPosition : localPosition + parent.getPosition();
		}

		// Parent and Children methods
		public GameObject getParent() { return parent; }
		public void setParent(GameObject newParent)
		{
			var oldParent = parent;
			parent = newParent;
			if (oldParent != null) parent.removeChild(this);
			if (newParent == null) return;
			if (!newParent.getChildren().Contains(this)) newParent.addChild(this);
		}
		public List<GameObject> getChildren() { return children; }
		public void addChild(GameObject newChild)
		{
			if (children.Contains(newChild) || newChild == null) return;
			children.Add(newChild);
			if (newChild.getParent() != this) newChild.setParent(this);
		}
		public void removeChild(GameObject removedChild)
		{
			if (!children.Contains(removedChild) || removedChild == null) return;
			children.Remove(removedChild);
			if (removedChild.getParent() == this) removedChild.setParent(null);
		}
	}
}

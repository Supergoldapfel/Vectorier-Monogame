using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Vectorier
{
	class GameObjectManager
	{
		private List<GameObject> gameObjects = new List<GameObject>();
		private Game game;

		public GameObjectManager(Game game)
		{
			this.game = game;
		}

		public void addObject(GameObject newGameObject)
		{
			gameObjects.Add(newGameObject);
		}
		public void addObjects(List<GameObject> newGameObjects)
		{
			gameObjects.AddRange(newGameObjects);
		}

		public void drawAll(SpriteBatch spriteBatch)
		{
			foreach(GameObject currentGameObject in gameObjects)
			{
				spriteBatch.Draw(
					currentGameObject.texture, // Texture
					currentGameObject.getPosition(), // Position
					null, // Rectangle
					currentGameObject.color, // Color
					currentGameObject.rotation, // Rotation
					currentGameObject.origin, // Origin
					currentGameObject.scale, // Scale
					SpriteEffects.None, // Effects
					currentGameObject.layer // Layer
				);
			}
		}

		public void updateAll(GameTime gameTime)
		{
			foreach(GameObject currentGameObject in gameObjects)
			{
				currentGameObject.Update(gameTime);
			}
		}
	}
}

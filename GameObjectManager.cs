using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Vectorier
{
	class GameObjectManager
	{
		private List<GameObject> gameObjects = new List<GameObject>();
		private Game game;
		private SpriteBatch spriteBatch;

		public GameObjectManager(Game game)
		{
			this.game = game;
			spriteBatch = new SpriteBatch(game.GraphicsDevice);
		}

		public void addObject(GameObject newGameObject)
		{
			gameObjects.Add(newGameObject);
		}
		public void addObjects(List<GameObject> newGameObjects)
		{
			gameObjects.AddRange(newGameObjects);
		}

		public void drawAll()
		{
			spriteBatch.Begin();
			foreach(GameObject currentGameObject in gameObjects)
			{
				spriteBatch.Draw(
					currentGameObject.texture, // Texture
					currentGameObject.position, // Position
					null, // Rectangle
					Color.White, // Color
					currentGameObject.rotation, // Rotation
					currentGameObject.origin, // Origin
					currentGameObject.scale, // Scale
					SpriteEffects.None, // Effects
					1f // Layer
				);
			}
			spriteBatch.End();
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

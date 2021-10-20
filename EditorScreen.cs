using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Vectorier
{
	class EditorScreen : GameScreen
	{
		private Game game;
		private OrthographicCamera cam;
		private SpriteBatch spriteBatch;

		private float cellSize = 100;

		public EditorScreen(Game game) : base(game)
		{
			this.game = game;
		}

		public override void Initialize()
		{
			base.Initialize();

			var viewportAdapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, 800, 480);
			cam = new OrthographicCamera(viewportAdapter);
		}

		public override void LoadContent()
		{
			spriteBatch = new SpriteBatch(game.GraphicsDevice);
		}

		public override void Draw(GameTime gameTime)
		{
			var transformMatrix = cam.GetViewMatrix();
			spriteBatch.Begin(transformMatrix: transformMatrix);

			drawGrid();
			
			spriteBatch.End();
		}

		private Vector2 GetMovementDirection()
		{
			var movementDirection = Vector2.Zero;
			var state = Keyboard.GetState();
			if (state.IsKeyDown(Keys.Down))
			{
				movementDirection += Vector2.UnitY;
			}
			if (state.IsKeyDown(Keys.Up))
			{
				movementDirection -= Vector2.UnitY;
			}
			if (state.IsKeyDown(Keys.Left))
			{
				movementDirection -= Vector2.UnitX;
			}
			if (state.IsKeyDown(Keys.Right))
			{
				movementDirection += Vector2.UnitX;
			}
			return movementDirection;
		}

		public override void Update(GameTime gameTime)
		{
			const float movementSpeed = 200;
			cam.Move(GetMovementDirection() * movementSpeed * gameTime.GetElapsedSeconds());
		}

		private void drawGrid()
        {
			game.GraphicsDevice.Clear(Color.White);

			RectangleF camBounds = cam.BoundingRectangle;
			Vector2 closestGridPoint = new Vector2(camBounds.Left - (camBounds.Left % cellSize), camBounds.Top - (camBounds.Top % cellSize));

			// Draw all vertical grid lines
			for (int i = 0; i * cellSize + closestGridPoint.X <= camBounds.Right; i++)
			{
				spriteBatch.DrawLine(new Vector2(i * cellSize + closestGridPoint.X, camBounds.Top), new Vector2(i * cellSize + closestGridPoint.X, camBounds.Bottom), Color.Black, 2);
			}
			// Draw all horizontal grid lines
			for (int i = 0; i * cellSize + closestGridPoint.Y <= camBounds.Bottom; i++)
			{
				spriteBatch.DrawLine(new Vector2(camBounds.Left, i * cellSize + closestGridPoint.Y), new Vector2(camBounds.Right, i * cellSize + closestGridPoint.Y), Color.Black, 2);
			}

			spriteBatch.DrawPoint(0f, 0f, Color.Green, 4);
		}
	}
}

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
		private SpriteBatch overlayBatch;
		private GameObjectManager gameObjectManager;
		private GameObjectManager overlayManager;

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
			overlayBatch = new SpriteBatch(game.GraphicsDevice);

			gameObjectManager = new GameObjectManager(game);
			overlayManager = new GameObjectManager(game);

			var sliderTexture = Content.Load<Texture2D>("Images\\slider");
			var sliderKnobTexture = Content.Load<Texture2D>("Images\\sliderKnob");

			var camBounds = cam.BoundingRectangle;
			var sliderWidth = camBounds.Width / sliderTexture.Width;
			var sliderHeight = .35f;
			Slider slider = new Slider(overlayManager, sliderTexture, sliderKnobTexture, new Vector2(0, camBounds.Height - (sliderHeight*sliderTexture.Height)/2), new Vector2(0, sliderTexture.Height/2), new Vector2(sliderWidth, sliderHeight),  Color.Gray, layer: .11f);
			overlayManager.addObject(slider);
		}

		public override void Draw(GameTime gameTime)
		{
			var transformMatrix = cam.GetViewMatrix();
			spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: transformMatrix);

			drawGrid();
			gameObjectManager.drawAll(spriteBatch);
			
			spriteBatch.End();

			overlayBatch.Begin(SpriteSortMode.FrontToBack);

			drawLayout();
			overlayManager.drawAll(overlayBatch);

			overlayBatch.End();
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
				spriteBatch.DrawLine(new Vector2(i * cellSize + closestGridPoint.X, camBounds.Top), new Vector2(i * cellSize + closestGridPoint.X, camBounds.Bottom), Color.Black, 2, .01f);
			}
			// Draw all horizontal grid lines
			for (int i = 0; i * cellSize + closestGridPoint.Y <= camBounds.Bottom; i++)
			{
				spriteBatch.DrawLine(new Vector2(camBounds.Left, i * cellSize + closestGridPoint.Y), new Vector2(camBounds.Right, i * cellSize + closestGridPoint.Y), Color.Black, 2, .01f);
			}

			spriteBatch.DrawPoint(0f, 0f, Color.Green, 8, .011f);
		}

		private void drawLayout()
		{
			var objectListAreaHeight = 150;

			var camBounds = cam.BoundingRectangle;
			var objectListArea = new RectangleF(0, camBounds.Height - objectListAreaHeight, camBounds.Width, objectListAreaHeight);
			overlayBatch.FillRectangle(objectListArea, Color.LightGray, .1f);
		}
	}
}

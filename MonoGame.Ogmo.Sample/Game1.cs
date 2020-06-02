using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Ogmo.Component;

namespace MonoGame.Ogmo.Sample
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private OgmoSettings _ogmoSettings;
		private Texture2D _tilesetTexture;
		private OgmoMap _ogmoMap;
		private OgmoMapTileLayer _ogmoMapTileLayer;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			_ogmoSettings = Content.Load<OgmoSettings>("ogmo1");
			Console.WriteLine(_ogmoSettings.TileLayers.Length);

			_tilesetTexture = Content.Load<Texture2D>("tiles");

			_ogmoMap = Content.Load<OgmoMap>("lv1");
			_ogmoMapTileLayer = new OgmoMapTileLayer(_ogmoMap.MapSize, _ogmoMap.MapOffset, _ogmoMap.TilesLayers[0],
				new OgmoTileset(_ogmoSettings.TilesetSettings[0], _tilesetTexture));
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			_ogmoMapTileLayer.Draw(_spriteBatch);
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
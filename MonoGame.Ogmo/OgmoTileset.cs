using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Ogmo
{
	// TODO : Allow creating tileset without OgmoTilesetSetting 
	public class OgmoTileset
	{
		public OgmoTilesetSetting OgmoTilesetSetting;

		public Texture2D Texture2D
		{
			get => _texture2D;
			set
			{
				_texture2D = value;
				_tileCount = new Point((int)Math.Floor((double)_texture2D.Width / OgmoTilesetSetting.TileSize.X),
					(int)Math.Floor((double)_texture2D.Height / OgmoTilesetSetting.TileSize.Y));
			}
		}

		private Texture2D _texture2D;

		private Point _tileCount;

		/// <summary>
		/// Create tileset manually by passing texture2D
		/// </summary>
		/// <param name="ogmoTilesetSetting"></param>
		/// <param name="texture2D"></param>
		public OgmoTileset(OgmoTilesetSetting ogmoTilesetSetting, Texture2D texture2D)
		{
			OgmoTilesetSetting = ogmoTilesetSetting;
			Texture2D = texture2D;
		}

		/// <summary>
		/// Create tile automatically using ogmoTilesetSetting.Path for loading the image. This might fail because
		/// you might saving the texture in different path. Also, path extension automatically removed for Content
		/// loading purpose
		/// </summary>
		/// <param name="ogmoTilesetSetting"></param>
		public OgmoTileset(OgmoTilesetSetting ogmoTilesetSetting, ContentManager contentManager)
		{
			Texture2D = contentManager.Load<Texture2D>(ogmoTilesetSetting.Path.Replace(".png", ""));
			OgmoTilesetSetting = ogmoTilesetSetting;
			
			if(Texture2D == null)
				Console.WriteLine("Loading texture is failed. Assets name invalid : " + ogmoTilesetSetting.Path.Replace(".png", ""));
		}

		public bool IsTilesetName(string name)
		{
			return OgmoTilesetSetting.Label == name;
		}

		public Point IndexToTextureCoordinate(int i)
		{
			return OgmoTilesetSetting.TileSeparation + IndexToXY(i) * (OgmoTilesetSetting.TileSize + OgmoTilesetSetting.TileSeparation );
		}

		public Point IndexToXY(int i)
		{
			return new Point(i % _tileCount.X, 
				(int) Math.Floor((double)i / _tileCount.X));
		}
	}
}
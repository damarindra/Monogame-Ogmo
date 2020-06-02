using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoGame.Ogmo
{
	/// <summary>
	/// Ogmo Settings, .ogmo file reader.
	/// Why we need this? to automate the tileset settings, so it will consistent between ogmo and monogame
	/// Layer ? I don't know, do we need it ? I think not.
	/// Why not create the Tileset directly, without needing this library. Yes you are right.
	/// </summary>
	public class OgmoSettings
	{
		public OgmoLayerSettings[] TileLayers;
		public OgmoLayerSettings[] EntityLayers;
		public OgmoLayerSettings[] GridLayers;

		public OgmoTilesetSetting[] TilesetSettings;
		public OgmoEntitySettings[] EntitySettings;

		public bool TryGetTilesetSettings(string label, out OgmoTilesetSetting? val)
		{
			val = null;
			foreach (OgmoTilesetSetting tilesetSettingse in TilesetSettings)
			{
				if (tilesetSettingse.Label == label)
				{
					val = tilesetSettingse;
					return true;
				}
			}
			return false;
		}
	}

	public struct OgmoLayerSettings
	{
		public string Name { get; }
		public Point GridSize { get; }

		public OgmoLayerSettings(string name, Point gridSize)
		{
			Name = name;
			GridSize = gridSize;
		}
	}

	public struct OgmoEntitySettings
	{
		public string Name { get; }
		public Point Size { get; }
		public Vector2 Origin { get; }
		public Color Color { get; }
		public bool TileX { get; }
		public bool TileY { get; }
		public Point TileSize { get; }
		public bool ResizeableX { get; }
		public bool ResizeableY { get; }
		public float RotationDegrees { get; }
		public string[] Tags { get; }

		public OgmoEntitySettings(string name, Point size, Vector2 origin, Color color, bool tileX, bool tileY, Point tileSize, bool resizeableX, bool resizeableY, float rotationDegrees, string[] tags)
		{
			Name = name;
			Size = size;
			Origin = origin;
			Color = color;
			TileX = tileX;
			TileY = tileY;
			TileSize = tileSize;
			ResizeableX = resizeableX;
			ResizeableY = resizeableY;
			RotationDegrees = rotationDegrees;
			Tags = tags;
		}
	}

	public struct OgmoTilesetSetting
	{
		public string Label { get; }
		public Point TileSize { get; }
		public Point TileSeparation { get; }
		public string Path { get; }

		public OgmoTilesetSetting(string label, Point tileSize, Point tileSeparation, string path)
		{
			Label = label;
			TileSize = tileSize;
			TileSeparation = tileSeparation;
			Path = path;
		}
		
		public Rectangle GetByIndex(int index)
		{
			return new Rectangle(
				TileSeparation + (TileSize + TileSeparation) * new Point(index, index),
				TileSize);
		}
	}
	
	
}
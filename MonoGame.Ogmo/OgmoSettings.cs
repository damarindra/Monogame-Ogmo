using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoGame.Ogmo
{
	public class OgmoSettings
	{
		public OgmoLayerSettings[] TileLayers;
		public OgmoLayerSettings[] EntityLayers;
		public OgmoLayerSettings[] GridLayers;

		public OgmoTilesetSettings[] TilesetSettings;
		public OgmoEntitySettings[] EntitySettings;

		public bool TryGetTilesetSettings(string label, out OgmoTilesetSettings? val)
		{
			val = null;
			foreach (OgmoTilesetSettings tilesetSettingse in TilesetSettings)
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

	public struct OgmoTilesetSettings
	{
		public string Label { get; }
		public Point TileSize { get; }
		public Point TileSeparation { get; }
		public string Path { get; }

		public OgmoTilesetSettings(string label, Point tileSize, Point tileSeparation, string path)
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
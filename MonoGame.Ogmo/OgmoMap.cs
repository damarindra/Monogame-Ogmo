using Microsoft.Xna.Framework;

namespace MonoGame.Ogmo
{
	public struct OgmoMap
	{
		public Point MapSize { get; }
		public Point MapOffset { get; }
		
		public OgmoTileLayer[] TilesLayers { get; }
		public OgmoEntityLayer[] EntityLayers { get; }
		public OgmoGridLayer[] GridLayers { get; }

		public OgmoMap(Point mapSize, Point mapOffset, OgmoTileLayer[] tilesLayers, 
			OgmoEntityLayer[] entityLayers, OgmoGridLayer[] gridLayers)
		{
			MapSize = mapSize;
			MapOffset = mapOffset;
			TilesLayers = tilesLayers;
			EntityLayers = entityLayers;
			GridLayers = gridLayers;
		}
	}

	public struct OgmoLayerDefinition
	{
		public OgmoLayerDefinition(string name, Point offset, Point gridCellSize, Point gridCellCount)
		{
			Name = name;
			Offset = offset;
			GridCellSize = gridCellSize;
			GridCellCount = gridCellCount;
		}

		public string Name { get; }
		public Point Offset { get; }
		public Point GridCellSize { get; }
		public Point GridCellCount { get; }
	}

	public struct OgmoTileLayer
	{
		public OgmoLayerDefinition LayerDefinition { get; }
		public string Tileset { get; }
		public int[] Data { get; }

		public OgmoTileLayer(OgmoLayerDefinition layerDefinition, string tileset, int[] data)
		{
			LayerDefinition = layerDefinition;
			Tileset = tileset;
			Data = data;
		}
	}

	public struct OgmoEntityLayer
	{
		public OgmoLayerDefinition LayerDefinition { get; }
		public OgmoEntity[] Entities { get; }

		public OgmoEntityLayer(OgmoLayerDefinition layerDefinition, OgmoEntity[] entities)
		{
			LayerDefinition = layerDefinition;
			Entities = entities;
		}
	}

	public struct OgmoEntity
	{
		public string Name { get; }
		public Point Position { get; }
		public Vector2 Origin { get; }
		public EntityValues Values { get; }

		public OgmoEntity(string name, Point position, Vector2 origin, EntityValues values)
		{
			Name = name;
			Position = position;
			Origin = origin;
			Values = values;
		}
	}

	public struct EntityValues
	{
		public Rectangle Rectangle { get; }
		public string ImageName { get; }
		public bool Collision { get; }

		public EntityValues(Rectangle rectangle, string imageName, bool collision)
		{
			Rectangle = rectangle;
			ImageName = imageName;
			Collision = collision;
		}
	}

	public struct OgmoGridLayer
	{
		public OgmoLayerDefinition LayerDefinition { get; }
		public int[] Grid { get; }

		public OgmoGridLayer(OgmoLayerDefinition layerDefinition, int[] grid)
		{
			LayerDefinition = layerDefinition;
			Grid = grid;
		}
	}
}
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Ogmo.Component
{
	public class OgmoMapTileLayer
	{
		public Point MapSize;
		public Point MapOffset;
		public OgmoTileLayer TileLayer;
		public OgmoTileset Tileset;

		public OgmoMapTileLayer(Point mapSize, Point mapOffset, OgmoTileLayer tileLayer, OgmoTileset tileset)
		{
			MapSize = mapSize;
			MapOffset = mapOffset;
			TileLayer = tileLayer;
			Tileset = tileset;
		}

		/// <summary>
		/// Drawing the Tile layer. SpriteBatch.Begin and End is not called. It consider you already called it
		/// </summary>
		/// <param name="batch"></param>
		public void Draw(SpriteBatch batch)
		{
			Vector2 startLoc = new Vector2(MapOffset.X, MapOffset.Y);

			for(int i = 0; i < TileLayer.Data.Length; i++)
			{
				int tileData = TileLayer.Data[i];
				
				// Skip
				if (tileData == -1)
					continue;
				
				batch.Draw(Tileset.Texture2D, 
					startLoc + IndexToWorldCoordinate(i), 
					new Rectangle(Tileset.IndexToTextureCoordinate(tileData), Tileset.OgmoTilesetSetting.TileSize),
					Color.White
					);
			}
		}

		protected Rectangle TileDataToTextureCoordinate(int tileData)
		{
			Point offset = Tileset.OgmoTilesetSetting.TileSeparation;
			Point size = Tileset.OgmoTilesetSetting.TileSize;
			
			return new Rectangle(offset + (new Point(tileData) * (size + offset)), size);
		}
		
		

		/// <summary>
		/// Convert Index to World Coordinate
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		protected Vector2 IndexToWorldCoordinate(int i)
		{
			return IndexConverter.IndexToXYByCount(i, TileLayer.LayerDefinition.GridCellCount.X).ToVector2()
			       * new Vector2(TileLayer.LayerDefinition.GridCellSize.X, TileLayer.LayerDefinition.GridCellSize.Y);
		}

		/// <summary>
		/// Convert Index into XY coordinate
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		protected Vector2 IndexToLayerXY(int i)
		{
			return new Vector2( i % TileLayer.LayerDefinition.GridCellCount.X, 
				(float) Math.Floor((double)i / TileLayer.LayerDefinition.GridCellCount.X));
		}
	}
}
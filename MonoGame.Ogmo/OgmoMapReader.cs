using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonoGame.Ogmo
{
	public class OgmoMapReader : ContentTypeReader<OgmoMap>
	{
		protected override OgmoMap Read(ContentReader input, OgmoMap existingInstance)
		{
			var mapSize = new Point(input.ReadInt32(), input.ReadInt32());
			var mapOffset = new Point(input.ReadInt32(), input.ReadInt32());

			// TILES LAYER
			var tilesLayers = new OgmoTileLayer[input.ReadInt32()];

			for (int i = 0; i < tilesLayers.Length; i++)
			{
				string name = input.ReadString();
				Point offset = new Point(input.ReadInt32(), input.ReadInt32());
				Point cellSize = new Point(input.ReadInt32(), input.ReadInt32());
				Point cellCount = new Point(input.ReadInt32(), input.ReadInt32());
				OgmoLayerDefinition layerDefinition = new OgmoLayerDefinition(name, offset, cellSize, cellCount);
				
				string tileset = input.ReadString();
				
				int[] data = new int[input.ReadInt32()];
				for (int j = 0; j < data.Length; j++)
				{
					data[j] = input.ReadInt32();
				}
				
				tilesLayers[i] = new OgmoTileLayer(layerDefinition, tileset, data);
			}
			
			
			// ENTITY LAYERS
			var entityLayers = new OgmoEntityLayer[input.ReadInt32()];

			for (int i = 0; i < entityLayers.Length; i++)
			{
				string name = input.ReadString();
				Point offset = new Point(input.ReadInt32(), input.ReadInt32());
				Point cellSize = new Point(input.ReadInt32(), input.ReadInt32());
				Point cellCount = new Point(input.ReadInt32(), input.ReadInt32());
				OgmoLayerDefinition layerDefinition = new OgmoLayerDefinition(name, offset, cellSize, cellCount);
				
				OgmoEntity[] entities = new OgmoEntity[input.ReadInt32()];
				for (int j = 0; j < entities.Length; j++)
				{
					//Entity
					string eName = input.ReadString();
					Point ePosition = new Point(input.ReadInt32(), input.ReadInt32());
					Vector2 eOrigin = new Vector2((float)input.ReadDouble(), (float)input.ReadDouble());
					
					// Values
					Rectangle vRectangle = new Rectangle(input.ReadInt32(), input.ReadInt32(), 
						input.ReadInt32(), input.ReadInt32());
					string vImageName = input.ReadString();
					bool vCollision = input.ReadBoolean();
					
					entities[j] = new OgmoEntity(eName, ePosition, eOrigin, new EntityValues(vRectangle, vImageName, vCollision));
				}
				
				entityLayers[i] = new OgmoEntityLayer(layerDefinition, entities);
			}
			
			
			//GRID LAYERS
			 var gridLayers = new OgmoGridLayer[input.ReadInt32()];

			for (int i = 0; i < gridLayers.Length; i++)
			{
				string name = input.ReadString();
				Point offset = new Point(input.ReadInt32(), input.ReadInt32());
				Point cellSize = new Point(input.ReadInt32(), input.ReadInt32());
				Point cellCount = new Point(input.ReadInt32(), input.ReadInt32());
				OgmoLayerDefinition layerDefinition = new OgmoLayerDefinition(name, offset, cellSize, cellCount);
				
				int[] grid = new int[input.ReadInt32()];
				for (int j = 0; j < grid.Length; j++)
				{
					grid[j] = input.ReadInt32();
				}
				
				gridLayers[i] = new OgmoGridLayer(layerDefinition, grid);
			}

			return new OgmoMap(mapSize, mapOffset, tilesLayers, entityLayers, gridLayers);
		}
	}
}
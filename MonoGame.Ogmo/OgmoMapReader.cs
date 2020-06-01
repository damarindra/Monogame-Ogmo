using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonoGame.Ogmo
{
	public class OgmoMapReader : ContentTypeReader<OgmoMap>
	{
		protected override OgmoMap Read(ContentReader input, OgmoMap existingInstance)
		{
			OgmoMap result = new OgmoMap();
			
			result.MapSize = new Point(input.ReadInt32(), input.ReadInt32());
			result.MapOffset = new Point(input.ReadInt32(), input.ReadInt32());

			// TILES LAYER
			result.TilesLayers = new OgmoTilesLayer[input.ReadInt32()];

			for (int i = 0; i < result.TilesLayers.Length; i++)
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
				
				result.TilesLayers[i] = new OgmoTilesLayer(layerDefinition, tileset, data);
			}
			
			
			// ENTITY LAYERS
			result.EntityLayers = new OgmoEntityLayer[input.ReadInt32()];

			for (int i = 0; i < result.EntityLayers.Length; i++)
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
				
				result.EntityLayers[i] = new OgmoEntityLayer(layerDefinition, entities);
			}
			
			
			//GRID LAYERS
			result.GridLayers = new OgmoGridLayer[input.ReadInt32()];

			for (int i = 0; i < result.GridLayers.Length; i++)
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
				
				result.GridLayers[i] = new OgmoGridLayer(layerDefinition, grid);
			}

			return result;
		}
	}
}
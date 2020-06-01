using System;
using System.Linq;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TWrite = MonoGame.Ogmo.Map.Pipeline.Models.OgmoMap;
using MonoGame.Ogmo.Map.Pipeline.Models;

namespace MonoGame.Ogmo.Map.Pipeline
{
	[ContentTypeWriter]
	public class OgmoMapWriter : ContentTypeWriter<TWrite>
	{
		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			// return must be class that can read the all value
			return "MonoGame.Ogmo.OgmoMapReader, MonoGame.Ogmo";
		}

		// TODO : Decals
		protected override void Write(ContentWriter output, TWrite value)
		{
			output.Write((int)value.Width);
			output.Write((int)value.Height);
			output.Write((int)value.OffsetX);
			output.Write((int)value.OffsetY);
			
			//Tiles layer
			Layer[] tileLayers = value.Layers.Where(p => p.Data != null).ToArray();
			
			// tile layer count
			output.Write(tileLayers.Length);

			foreach (Layer layer in tileLayers)
			{
				// layer name
				output.Write(layer.Name);
				
				// offset
				output.Write((int)layer.OffsetX);
				output.Write((int)layer.OffsetY);
				
				//Grid Cell Size
				output.Write((int)layer.GridCellWidth);
				output.Write((int)layer.GridCellHeight);
				
				//Grid cell count
				output.Write((int)layer.GridCellsX);
				output.Write((int)layer.GridCellsY);
				
				// Tileset
				output.Write(layer.Tileset);
				
				// Data count
				output.Write(layer.Data.Length);

				//Read all tiles index
				foreach (long l in layer.Data)
				{
					output.Write((int)l);
				}
			}
			
			
			// Entity layer
			Layer[] entityLayers = value.Layers.Where(p => p.Entities != null).ToArray();

			// Entity layer count
			output.Write(entityLayers.Length);

			foreach (Layer layer in entityLayers)
			{
				//layer name
				output.Write(layer.Name);
				
				// offset
				output.Write((int)layer.OffsetX);
				output.Write((int)layer.OffsetY);
				
				//Grid Cell Size
				output.Write((int)layer.GridCellWidth);
				output.Write((int)layer.GridCellHeight);
				
				//Grid cell count
				output.Write((int)layer.GridCellsX);
				output.Write((int)layer.GridCellsY);

				// Entity Count
				output.Write((int)layer.Entities.Length);
				
				// Save entity details
				foreach (Entity entity in layer.Entities)
				{
					// entity name
					output.Write(entity.Name.ToString());
					
					// Positino
					output.Write((int)entity.X);
					output.Write((int)entity.Y);
					
					// origin
					output.Write(entity.OriginX);
					output.Write(entity.OriginY);
					
					//Save Entity Value Detail
					// Value Rectangle
					output.Write((int)entity.Values.X);
					output.Write((int)entity.Values.Y);
					output.Write((int)entity.Values.Width);
					output.Write((int)entity.Values.Height);
					
					// Image name
					output.Write(entity.Values.ImageName.ToString());
					
					//Collision
					output.Write(entity.Values.Collision);
				}
			}
			
			
			// Grid layer
			Layer[] gridLayers = value.Layers.Where(p => p.Grid != null).ToArray();
			
			// grid count
			output.Write(gridLayers.Length);

			foreach (Layer layer in gridLayers)
			{
				// layer name
				output.Write(layer.Name);
				
				// offset
				output.Write((int)layer.OffsetX);
				output.Write((int)layer.OffsetY);
				
				//Grid Cell Size
				output.Write((int)layer.GridCellWidth);
				output.Write((int)layer.GridCellHeight);
				
				//Grid cell count
				output.Write((int)layer.GridCellsX);
				output.Write((int)layer.GridCellsY);

				// Grid count
				output.Write(layer.Grid.Length);

				foreach (long l in layer.Grid)
				{
					output.Write((int)l);
				}
			}
		}
	}
}
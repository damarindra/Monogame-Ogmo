using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TWrite = MonoGame.Ogmo.Pipeline.Models.Ogmo;
using System.Linq;
using MonoGame.Ogmo.Pipeline.Models;

// TODO rename namespace
namespace OgmoPipeline
{
	[ContentTypeWriter]
	public class OgmoWriter : ContentTypeWriter<TWrite>
	{
		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return "MonoGame.Ogmo.OgmoReader, MonoGame.Ogmo";
		}

		protected override void Write(ContentWriter output, TWrite value)
		{
			// Tile LAYER
			Layer[] tileLayers = value.Layers.Where(l => l.Definition == "tile").ToArray();
			
			//Total Tile layer
			output.Write(tileLayers.Length);

			foreach (Layer layer in tileLayers)
			{
				// Type of layer {tile, entity, decal, grid} 
				//output.Write(layer.Definition);
				
				// Layer name
				output.Write(layer.Name);
				
				// Layer grid Width
				output.Write((int)layer.GridSize.X);
				
				// Layer grid Height
				output.Write((int)layer.GridSize.Y);
			}
			
			// Entity LAYER
			Layer[] entityLayers = value.Layers.Where(l => l.Definition == "entity").ToArray();
			
			//Total layer
			output.Write(entityLayers.Length);

			foreach (var layer in entityLayers)
			{
				// Type of layer {tile, entity, decal, grid} 
				//output.Write(layer.Definition);
				
				// Layer name
				output.Write(layer.Name);
				
				// Layer grid Width
				output.Write((int)layer.GridSize.X);
				
				// Layer grid Height
				output.Write((int)layer.GridSize.Y);
			}
			
			
			// Grid LAYER
			Layer[] gridLayers = value.Layers.Where(l => l.Definition == "grid").ToArray();
			
			//Total layer
			output.Write(gridLayers.Length);

			foreach (var layer in gridLayers)
			{
				// Type of layer {tile, entity, decal, grid} 
				//output.Write(layer.Definition);
				
				// Layer name
				output.Write(layer.Name);
				
				// Layer grid Width
				output.Write((int)layer.GridSize.X);
				
				// Layer grid Height
				output.Write((int)layer.GridSize.Y);
			}
			
			
			// TILESET
			
			// Total Tileset
			output.Write(value.Tilesets.Length);

			foreach (Tileset tileset in value.Tilesets)
			{
				// Tileset name
				output.Write(tileset.Label);
				
				// Tile Width
				output.Write((int)tileset.TileWidth);
				
				// Tile Height
				output.Write((int)tileset.TileHeight);

				// Tile Separation X
				output.Write((int)tileset.TileSeparationX);

				// Tile Separation Y
				output.Write((int)tileset.TileSeparationY);
				
				// image path
				output.Write(tileset.Path);
			}
			
			// Entity
			output.Write(value.Entities.Length);

			foreach (Entity entity in value.Entities)
			{
				// name
				output.Write(entity.Name);
				
				//Size
				output.Write((int)entity.Size.X);
				output.Write((int)entity.Size.X);
				
				// Origin
				output.Write((double)entity.Origin.X);
				output.Write((double)entity.Origin.X);

				//Color
				output.Write(entity.Color);
				
				//Tile
				output.Write(entity.TileX);
				output.Write(entity.TileY);
				
				//TileSize
				output.Write((int)entity.TileSize.X);
				output.Write((int)entity.TileSize.Y);
				
				// Resizeable
				output.Write(entity.ResizeableX);
				output.Write(entity.ResizeableY);
				
				// Rotation deg
				output.Write((double)entity.RotationDegrees);
				
				//tags count
				output.Write(entity.Tags.Length);

				foreach (string tag in entity.Tags)
				{
					output.Write(tag);
				}
			}
		}



	}
}
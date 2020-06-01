using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonoGame.Ogmo
{
	public class OgmoReader : ContentTypeReader<OgmoSettings>
	{
		protected override OgmoSettings Read(ContentReader input, OgmoSettings existingInstance)
		{
			OgmoSettings result = new OgmoSettings();

			int arrayCount = input.ReadInt32();

			// Input Tile Layers
			result.TileLayers = new OgmoLayerSettings[arrayCount];

			for (int i = 0; i < arrayCount; i++)
			{
				result.TileLayers[i] = new OgmoLayerSettings(input.ReadString(), 
					new Point((int)input.ReadInt32(), (int)input.ReadInt32()));
			}

			arrayCount = (int)input.ReadInt32();
			
			// Input Entity Layers
			result.EntityLayers = new OgmoLayerSettings[arrayCount];

			for (int i = 0; i < arrayCount; i++)
			{
				result.EntityLayers[i] = new OgmoLayerSettings(input.ReadString(), 
					new Point((int)input.ReadInt32(), (int)input.ReadInt32()));
			}

			arrayCount = (int)input.ReadInt32();
			
			// Input Grid Layers
			result.GridLayers = new OgmoLayerSettings[arrayCount];

			for (int i = 0; i < arrayCount; i++)
			{
				result.GridLayers[i] = new OgmoLayerSettings(input.ReadString(), 
					new Point((int)input.ReadInt32(), (int)input.ReadInt32()));
			}

			arrayCount = (int)input.ReadInt32();
			
			// Input Tileset
			result.TilesetSettings = new OgmoTilesetSettings[arrayCount];

			for (int i = 0; i < arrayCount; i++)
			{
				result.TilesetSettings[i] = new OgmoTilesetSettings(input.ReadString(),
					new Point((int)input.ReadInt32(), (int)input.ReadInt32()),
					new Point((int)input.ReadInt32(), (int)input.ReadInt32()),
					input.ReadString());
			}
			
			//Entity
			result.EntitySettings = new OgmoEntitySettings[input.ReadInt32()];

			for (int i = 0; i < result.EntitySettings.Length; i++)
			{
				string name = input.ReadString();
				var size = new Point(input.ReadInt32(), input.ReadInt32());
				var origin = new Vector2((float) input.ReadDouble(), (float) input.ReadDouble());
				var color = HextToColor(input.ReadString());
				var tileX = input.ReadBoolean();
				var tileY =input.ReadBoolean();
				var tileSize = new Point(input.ReadInt32(), input.ReadInt32());
				var resizeableX = input.ReadBoolean();
				var resizeableY = input.ReadBoolean();
				var rotationDeg = (float) input.ReadDouble();
				
				string[] tags = new string[input.ReadInt32()];

				for (int j = 0; j < tags.Length; j++)
				{
					tags[j] = input.ReadString();
				}
				
				result.EntitySettings[i] = new OgmoEntitySettings(
					name, size, origin, color, tileX, tileY, tileSize, resizeableX, resizeableY, rotationDeg, tags
					);
			}

			return result;
		}
		
		/// <summary>
		///     Converts a hex string into a Microsoft.Xna.Color
		/// </summary>
		/// <param name="hex">The 6 digit or 8 digit hex string without the # at the beginning</param>
		/// <returns></returns>
		private Color HextToColor(string hex)
		{
			hex = hex.Replace("#", "");
			if (hex.Length >= 6)
			{
				float r = (HexToByte(hex[0]) * 16 + HexToByte(hex[1])) / 255.0f;
				float g = (HexToByte(hex[2]) * 16 + HexToByte(hex[3])) / 255.0f;
				float b = (HexToByte(hex[4]) * 16 + HexToByte(hex[5])) / 255.0f;

				if (hex.Length == 8)
				{
					float a = (HexToByte(hex[6]) * 16 + HexToByte(hex[7])) / 255.0f;
					return new Color(r, g, b, a);
				}

				return new Color(r, g, b);
			}

			return Color.White;
		}

		/// <summary>
		///     Lookup table for base16 digits
		/// </summary>
		private const string Hex = "0123456789ABCDEF";

		/// <summary>
		///     Converts the given hex digit to a byte
		/// </summary>
		/// <param name="c">The hex digit as a char</param>
		/// <returns></returns>
		private byte HexToByte(char c)
		{
			return (byte)Hex.IndexOf(char.ToUpper(c));
		}
	}
}
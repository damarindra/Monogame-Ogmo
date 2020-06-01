using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Ogmo
{
	public class OgmoTileset
	{
		private OgmoTilesetSettings _ogmoTilesetSettings;
		public Texture2D Texture2D;

		public OgmoTileset(OgmoTilesetSettings ogmoTilesetSettings, Texture2D texture2D)
		{
			_ogmoTilesetSettings = ogmoTilesetSettings;
			Texture2D = texture2D;
		}
	}
}
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;

using TImport = System.String;

namespace MonoGame.Ogmo.Map.Pipeline
{
    [ContentImporter(".json", DisplayName = "Ogmo Map Importer", DefaultProcessor = "OgmoMapProcessor")]
    public class OgmoMapImporter : ContentImporter<TImport>
    {
        public override TImport Import(string filename, ContentImporterContext context)
        {
            return File.ReadAllText(filename);
        }
    }
}

using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;

using TImport = System.String;

namespace MonoGame.Ogmo.Pipeline
{
    [ContentImporter(".ogmo", DisplayName = "Ogmo Importer", DefaultProcessor = "OgmoProcessor")]
    public class OgmoImporter : ContentImporter<TImport>
    {
        public override TImport Import(string filename, ContentImporterContext context)
        {
            return File.ReadAllText(filename);
        }
    }
}

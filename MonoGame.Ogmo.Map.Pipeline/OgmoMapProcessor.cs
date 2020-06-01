using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Ogmo.Map.Pipeline.Models;
using TInput = System.String;

namespace MonoGame.Ogmo.Map.Pipeline
{
    [ContentProcessor(DisplayName = "Ogmo Map Processor")]
    class OgmoMapProcessor : ContentProcessor<TInput, OgmoMap>
    {
        public override OgmoMap Process(TInput input, ContentProcessorContext context)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<OgmoMap>(input);
        }
    }
}

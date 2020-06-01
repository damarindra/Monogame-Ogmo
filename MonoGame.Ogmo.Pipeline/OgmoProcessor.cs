using System;
using Microsoft.Xna.Framework.Content.Pipeline;
using TInput = System.String;
using TOutput = MonoGame.Ogmo.Pipeline.Models.Ogmo;

namespace MonoGame.Ogmo.Pipeline
{
    [ContentProcessor(DisplayName = "Ogmo Processor")]
    class OgmoProcessor : ContentProcessor<TInput, Models.Ogmo>
    {
        public override Models.Ogmo Process(TInput input, ContentProcessorContext context)
        {
            Console.WriteLine("Uhys");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Ogmo>(input);
        }
    }
}

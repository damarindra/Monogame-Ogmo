namespace MonoGame.Ogmo.Map.Pipeline.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class OgmoMap
    {
        [JsonProperty("ogmoVersion")]
        public string OgmoVersion { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("offsetX")]
        public long OffsetX { get; set; }

        [JsonProperty("offsetY")]
        public long OffsetY { get; set; }

        [JsonProperty("layers")]
        public Layer[] Layers { get; set; }
    }

    public partial class Layer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("_eid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Eid { get; set; }

        [JsonProperty("offsetX")]
        public long OffsetX { get; set; }

        [JsonProperty("offsetY")]
        public long OffsetY { get; set; }

        [JsonProperty("gridCellWidth")]
        public long GridCellWidth { get; set; }

        [JsonProperty("gridCellHeight")]
        public long GridCellHeight { get; set; }

        [JsonProperty("gridCellsX")]
        public long GridCellsX { get; set; }

        [JsonProperty("gridCellsY")]
        public long GridCellsY { get; set; }

        [JsonProperty("tileset", NullValueHandling = NullValueHandling.Ignore)]
        public string Tileset { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Data { get; set; }

        [JsonProperty("exportMode", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExportMode { get; set; }

        [JsonProperty("arrayMode", NullValueHandling = NullValueHandling.Ignore)]
        public long? ArrayMode { get; set; }

        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public Entity[] Entities { get; set; }

        [JsonProperty("decals", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Decals { get; set; }

        [JsonProperty("folder", NullValueHandling = NullValueHandling.Ignore)]
        public string Folder { get; set; }

        [JsonProperty("grid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] Grid { get; set; }
    }

    public partial class Entity
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("_eid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Eid { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("originX")]
        public double OriginX { get; set; }

        [JsonProperty("originY")]
        public double OriginY { get; set; }

        [JsonProperty("values")]
        public Values Values { get; set; }
    }

    public partial class Values
    {
        [JsonProperty("X")]
        public long X { get; set; }

        [JsonProperty("Y")]
        public long Y { get; set; }

        [JsonProperty("Width")]
        public long Width { get; set; }

        [JsonProperty("Height")]
        public long Height { get; set; }

        [JsonProperty("image_name")]
        public ImageName ImageName { get; set; }

        [JsonProperty("collision")]
        public bool Collision { get; set; }
    }

    public enum Name { Trees };

    public enum ImageName { Objects };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                NameConverter.Singleton,
                ImageNameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "trees")
            {
                return Name.Trees;
            }
            throw new Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            if (value == Name.Trees)
            {
                serializer.Serialize(writer, "trees");
                return;
            }
            throw new Exception("Cannot marshal type Name");
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }

    internal class ImageNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ImageName) || t == typeof(ImageName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "objects")
            {
                return ImageName.Objects;
            }
            throw new Exception("Cannot unmarshal type ImageName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ImageName)untypedValue;
            if (value == ImageName.Objects)
            {
                serializer.Serialize(writer, "objects");
                return;
            }
            throw new Exception("Cannot marshal type ImageName");
        }

        public static readonly ImageNameConverter Singleton = new ImageNameConverter();
    }

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long[]);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<long>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = ParseStringConverter.Singleton;
                var arrayItem = (long)converter.ReadJson(reader, typeof(long), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (long[])untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = ParseStringConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
            return;
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
    }
}

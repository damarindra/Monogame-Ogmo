namespace MonoGame.Ogmo.Pipeline.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Ogmo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ogmoVersion")]
        public string OgmoVersion { get; set; }

        [JsonProperty("levelPaths")]
        public string[] LevelPaths { get; set; }

        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("gridColor")]
        public string GridColor { get; set; }

        [JsonProperty("anglesRadians")]
        public bool AnglesRadians { get; set; }

        [JsonProperty("directoryDepth")]
        public long DirectoryDepth { get; set; }

        [JsonProperty("layerGridDefaultSize")]
        public LayerGridDefaultSize LayerGridDefaultSize { get; set; }

        [JsonProperty("levelDefaultSize")]
        public LayerGridDefaultSize LevelDefaultSize { get; set; }

        [JsonProperty("levelMinSize")]
        public LayerGridDefaultSize LevelMinSize { get; set; }

        [JsonProperty("levelMaxSize")]
        public LayerGridDefaultSize LevelMaxSize { get; set; }

        [JsonProperty("levelValues")]
        public object[] LevelValues { get; set; }

        [JsonProperty("defaultExportMode")]
        public string DefaultExportMode { get; set; }

        [JsonProperty("compactExport")]
        public bool CompactExport { get; set; }

        [JsonProperty("externalScript")]
        public string ExternalScript { get; set; }

        [JsonProperty("playCommand")]
        public string PlayCommand { get; set; }

        [JsonProperty("entityTags")]
        public string[] EntityTags { get; set; }

        [JsonProperty("layers")]
        public Layer[] Layers { get; set; }

        [JsonProperty("entities")]
        public Entity[] Entities { get; set; }

        [JsonProperty("tilesets")]
        public Tileset[] Tilesets { get; set; }
    }

    public partial class Entity
    {
        [JsonProperty("exportID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ExportId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("size")]
        public LayerGridDefaultSize Size { get; set; }

        [JsonProperty("origin")]
        public Vec2 Origin { get; set; }

        [JsonProperty("originAnchored")]
        public bool OriginAnchored { get; set; }

        [JsonProperty("shape")]
        public Shape Shape { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("tileX")]
        public bool TileX { get; set; }

        [JsonProperty("tileY")]
        public bool TileY { get; set; }

        [JsonProperty("tileSize")]
        public LayerGridDefaultSize TileSize { get; set; }

        [JsonProperty("resizeableX")]
        public bool ResizeableX { get; set; }

        [JsonProperty("resizeableY")]
        public bool ResizeableY { get; set; }

        [JsonProperty("rotatable")]
        public bool Rotatable { get; set; }

        [JsonProperty("rotationDegrees")]
        public long RotationDegrees { get; set; }

        [JsonProperty("canFlipX")]
        public bool CanFlipX { get; set; }

        [JsonProperty("canFlipY")]
        public bool CanFlipY { get; set; }

        [JsonProperty("canSetColor")]
        public bool CanSetColor { get; set; }

        [JsonProperty("hasNodes")]
        public bool HasNodes { get; set; }

        [JsonProperty("nodeLimit")]
        public long NodeLimit { get; set; }

        [JsonProperty("nodeDisplay")]
        public long NodeDisplay { get; set; }

        [JsonProperty("nodeGhost")]
        public bool NodeGhost { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("values")]
        public EntityValue[] Values { get; set; }
    }

    public partial class LayerGridDefaultSize
    {
        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }
    }
    
    public partial class Vec2
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }

    public partial class Shape
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("points")]
        public LayerGridDefaultSize[] Points { get; set; }
    }

    public partial class EntityValue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("defaults")]
        public Defaults Defaults { get; set; }

        [JsonProperty("bounded", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Bounded { get; set; }

        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public long? Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public long? Max { get; set; }

        [JsonProperty("maxLength", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxLength { get; set; }

        [JsonProperty("trimWhitespace", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TrimWhitespace { get; set; }
    }

    public partial class Layer
    {
        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gridSize")]
        public LayerGridDefaultSize GridSize { get; set; }

        [JsonProperty("exportID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ExportId { get; set; }

        [JsonProperty("exportMode", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExportMode { get; set; }

        [JsonProperty("arrayMode", NullValueHandling = NullValueHandling.Ignore)]
        public long? ArrayMode { get; set; }

        [JsonProperty("defaultTileset", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultTileset { get; set; }

        [JsonProperty("requiredTags", NullValueHandling = NullValueHandling.Ignore)]
        public object[] RequiredTags { get; set; }

        [JsonProperty("excludedTags", NullValueHandling = NullValueHandling.Ignore)]
        public object[] ExcludedTags { get; set; }

        [JsonProperty("folder", NullValueHandling = NullValueHandling.Ignore)]
        public string Folder { get; set; }

        [JsonProperty("includeImageSequence", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeImageSequence { get; set; }

        [JsonProperty("scaleable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Scaleable { get; set; }

        [JsonProperty("rotatable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rotatable { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public LayerValue[] Values { get; set; }

        [JsonProperty("legend", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Legend { get; set; }
    }

    public partial class LayerValue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("defaults")]
        public long Defaults { get; set; }

        [JsonProperty("bounded")]
        public bool Bounded { get; set; }

        [JsonProperty("min")]
        public long Min { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }
    }

    public partial class Tileset
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("tileWidth")]
        public long TileWidth { get; set; }

        [JsonProperty("tileHeight")]
        public long TileHeight { get; set; }

        [JsonProperty("tileSeparationX")]
        public long TileSeparationX { get; set; }

        [JsonProperty("tileSeparationY")]
        public long TileSeparationY { get; set; }
    }

    public partial struct Defaults
    {
        public bool? Bool;
        public long? Integer;
        public string String;

        public static implicit operator Defaults(bool Bool) => new Defaults { Bool = Bool };
        public static implicit operator Defaults(long Integer) => new Defaults { Integer = Integer };
        public static implicit operator Defaults(string String) => new Defaults { String = String };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DefaultsConverter.Singleton,
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

    internal class DefaultsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Defaults) || t == typeof(Defaults?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new Defaults { Integer = integerValue };
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new Defaults { Bool = boolValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Defaults { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type Defaults");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Defaults)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Bool != null)
            {
                serializer.Serialize(writer, value.Bool.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type Defaults");
        }

        public static readonly DefaultsConverter Singleton = new DefaultsConverter();
    }
}

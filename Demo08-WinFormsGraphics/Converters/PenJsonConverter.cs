using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;

namespace WinFormsGraphics.Converters
{
    public class PenJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Pen));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Pen pen = (Pen)value;
            JObject jo = new JObject();
            jo.Add("color", pen.Color.ToArgb());
            jo.Add("width", pen.Width);
            jo.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            return new Pen(Color.FromArgb((int)jo["color"]), (float)jo["width"]);
        }
    }
}

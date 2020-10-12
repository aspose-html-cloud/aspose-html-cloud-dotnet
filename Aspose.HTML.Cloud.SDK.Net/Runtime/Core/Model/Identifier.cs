using System;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model.Json;
using Newtonsoft.Json;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Core.Model
{
    [JsonConverter(typeof(IdentifierConverter))]
    public sealed class Identifier : IEquatable<Identifier>
    {
        public const string UNDEFINED = "UN";
        public const string CONVERSION = "CN";

        public static readonly Identifier Empty = new Identifier(UNDEFINED, Guid.Empty);

        Identifier(string type)
            : this(type, Guid.NewGuid())
        {
        }

        Identifier(string type, Guid value)
        {
            this.Type = type;
            this.Value = value;
        }

        public string Type { get; }
        public Guid Value { get; }

        public static Identifier New(string type = UNDEFINED)
        {
            return new Identifier(type);
        }

        public static Identifier FromString(string identifier)
        {
            var index = identifier.IndexOf('-');
            return new Identifier(identifier.Substring(0, index), new Guid(identifier.Substring(index + 1)));
        }

        public bool Equals(Identifier other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Type == other.Type && Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Identifier other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Type != null ? Type.GetHashCode() : 0) * 397) ^ Value.GetHashCode();
            }
        }

        public static bool operator ==(Identifier left, Identifier right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Identifier left, Identifier right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{Type}-{Value}";
        }
    }
}
using System;
using VCards.Types;

namespace VCards.Models
{
    public sealed class Relation
    {
        public RelationType Type { get; set; }
        public int Preference { get; set; }
        public Uri RelationUri { get; set; }
    }
}
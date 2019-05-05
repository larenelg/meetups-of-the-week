using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DataDrivenDiversity.Api.Models
{
    public class NerRepsonse
    {
        public DateTime DocDate { get; set; }
        public IList<NerResultItem> Sentences { get; set; }
    }

    public class NerResultItem
    {
        public int Index { get; set; }
        public IList<NerEntityMentions> Entitymentions { get; set; }
        public IList<NerTokens> Tokens { get; set; }
    }

    public class NerEntityMentions
    {
        public int DocTokenBegin { get; set; }
        public int DocTokenEnd { get; set; }
        public int TokenBegin { get; set; }
        public int TokenEnd { get; set; }
        public string Text { get; set; }
        public int CharacterOffsetBegin { get; set; }

        public int CharacterOffsetEnd { get; set; }
        public string Ner { get; set; } // PERSON
    }

    public class NerTokens
    {
        public int Index { get; set; }
        public string Word { get; set; }
        public string OriginalText { get; set; }
        public string Lemma { get; set; } 
        public int CharacterOffsetBegin { get; set; }
        public int CharacterOffsetEnd { get; set; }
        public string Pos { get; set; }
        public string Ner { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
    }
}
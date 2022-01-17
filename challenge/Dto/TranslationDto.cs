using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace challenge.Dto
{
    public class TranslationDto
    {
        [MaxLength(600)]
        public string Text { get; set; }
        [Required]
        public Language LangFrom { get; set; }
        [Required]
        public Language LangTo { get; set; }
    }
}


using System;
using challenge.Dto;

namespace challenge.Services
{
    public interface ITranslationService
    {
        Task<string> Translate(String textToTranslate, Language fromLanguage, Language toLanguage);
    }
}


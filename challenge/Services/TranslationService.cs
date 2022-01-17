using System;
using System.Text;
using System.Text.Json;
using challenge.Dto;
using Newtonsoft.Json;

namespace challenge.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly IHttpClientFactory _clientFactory;

        public TranslationService(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        public async Task<string> Translate(String textToTranslate,
            Language fromLanguage, Language toLanguage)
        {

            var content = new
            {
                text = textToTranslate
            };

            var model = getTranslationModel(fromLanguage, toLanguage);

            var request = new HttpRequestMessage(HttpMethod.Post,
                $"https://api.nlpcloud.io/v1/{model}/translation");
            request.Headers.Add("Authorization", "Token c47056a7eda699bb5d0904a4f8a0eceea78cf382");
            request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var parsedBody = JsonConvert.DeserializeObject<ExternalApiTranslationDto>(body);
                return parsedBody.translation_text;
            }
            return "error";
        }

        /// <summary>
        /// The external API for translation has several IA models to translate.
        /// Use this function to obtain the name of the model
        /// </summary>
        /// <param name="langFrom">Original language of the text to translate.</param>
        /// <param name="langTo">Language the text will be translated to</param>
        /// <returns>Name of the model</returns>
        private string getTranslationModel(Language langFrom, Language langTo)
        {
            Dictionary<Language, Dictionary<Language, string>> models =
                new Dictionary<Language, Dictionary<Language, string>>();
            // English to XX
            models.Add(Language.English, new Dictionary<Language, string>()
            {
                {Language.French, "opus-mt-en-fr" },
                {Language.German, "opus-mt-en-de" }
            });
            // German to XX
            models.Add(Language.German, new Dictionary<Language, string>()
            {
                {Language.French, "opus-mt-de-fr" },
                {Language.English, "opus-mt-de-en" }
            });
            // French to XX
            models.Add(Language.French, new Dictionary<Language, string>()
            {
                {Language.German, "" },
                {Language.English, "opus-mt-fr-en" }
            });

            return models[langFrom][langTo];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Dto;
using challenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        ITranslationService _translationServ;

        public TranslationController(ITranslationService service)
        {
            this._translationServ = service;
        }

        [HttpPost(Name = "translate")]
        public async Task<ActionResult<TranslationResponseDto>> Post(TranslationDto translation)
        {
            var translatedText = await this._translationServ.Translate(translation.Text,
                translation.LangFrom, translation.LangTo);

            var response = new TranslationResponseDto()
            {
                Language = translation.LangTo,
                TanslatedText = translatedText
            };

            return Ok(response);
        }
    }
}
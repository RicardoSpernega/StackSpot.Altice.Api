using Altice.Application.CreateForm;
using Altice.Application.Form;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Altice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : MainController
    {
        private readonly IMediator _mediator;

        public FormController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("new-form")]
        public async Task<IActionResult> Post([FromBody] CreateFormCommand command)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return Ok(ex.Message);
            }
           
        }

        [HttpGet("{Email}")]
        [HttpGet("")]
        public async Task<IActionResult> Get([FromRoute]ListFormCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (System.Exception ex)
            {

                return Ok(ex.Message);
            }
        }
    }
}

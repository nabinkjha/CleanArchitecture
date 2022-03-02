using ECom.API.Controllers;
using ECom.Application.Features.PaymentDetails.Commands.Create;
using ECom.Application.Features.PaymentDetails.Commands.Delete;
using ECom.Application.Features.PaymentDetails.Commands.Update;
using ECom.Application.Features.PaymentDetails.Queries.GetAllPaged;
using ECom.Application.Features.PaymentDetails.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECom.Api.Controllers.v1
{
    public class PaymentDetailController : BaseApiController<PaymentDetailController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var PaymentDetails = await _mediator.Send(new GetAllPaymentDetailsQuery(pageNumber, pageSize));
            return Ok(PaymentDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var PaymentDetail = await _mediator.Send(new GetPaymentDetailByIdQuery() { Id = id });
            return Ok(PaymentDetail);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePaymentDetailCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePaymentDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePaymentDetailCommand { Id = id }));
        }
    }
}
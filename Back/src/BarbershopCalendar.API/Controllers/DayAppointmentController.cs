using BarbershopCalendar.Application;
using BarbershopCalendar.Application.Dtos.DayAppointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarbershopCalendar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DayAppointmentController : ControllerBase
    {
        private readonly DayAppointmentService _dayAppointmentService;

        public DayAppointmentController(DayAppointmentService dayAppointmentService)
        {
            _dayAppointmentService = dayAppointmentService;
        }

        [HttpGet,
         Route("/listDays")]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int row = 5)
        {

            try
            {
                DayAppointmentOnlyDayDto[] listResult = await _dayAppointmentService.
                    GetDayAppointmentDtoByPageAsync(page, row);
                return Ok(listResult);
            }
            catch (IndexOutOfRangeException ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro inesperado ao tentar recuperar lista de dias da agenda. Erro:{ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                DayAppointmentDto result = await _dayAppointmentService.GetDayAppointmentDtoByIdAsync(id);
                return Ok(result);
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro inesperado ao tentar recuperar o dia de agendamento. Erro:{ex.Message}");
            }
            
        }
    }
}

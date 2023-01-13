using BarbershopCalendar.Application;
using BarbershopCalendar.Application.Dtos.DayAppointment;
using BarbershopCalendar.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BarbershopCalendar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DayAppointmentController : ControllerBase
    {
        private readonly IDayAppointmentService _dayAppointmentService;

        public DayAppointmentController(IDayAppointmentService dayAppointmentService)
        {
            _dayAppointmentService = dayAppointmentService;
        }

        [HttpGet,
         Route("/listDays")]
        public async Task<IActionResult> Get([FromQuery] int? page = 1, [FromQuery] int? row = 5)
        {

            try
            {
                DayAppointmentOnlyDayDto[] listResult = await _dayAppointmentService.
                    GetDayAppointmentDtoByPageAsync(page.Value, row.Value) ;
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

        [HttpPost]
        public async Task<IActionResult> Post(DayAppointmentDto model)
        {
            try
            {
                var dayAppointment = await _dayAppointmentService.AddDayAppointment(model);
                return Ok(dayAppointment);

            }
            catch(InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar dia a agenda. Erro:{ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DayAppointmentDto model)
        {
            try
            {
                var dayAppointment = await _dayAppointmentService.UpdateDayAppointment(id, model);
                return Ok(dayAppointment);

            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar eventos. Erro:{ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _dayAppointmentService.DeleteDayAppointmentDto(id);
                return Ok("Dia retirado da agenda com sucesso");

            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro:{ex.Message}");
            }
        }
    }
}

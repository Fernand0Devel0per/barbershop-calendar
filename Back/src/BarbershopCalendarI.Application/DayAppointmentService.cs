using AutoMapper;
using BarbershopCalendar.Application.Dtos.DayAppointment;
using BarbershopCalendar.Application.Interface;
using BarbershopCalendar.Domain;
using BarbershopCalendar.Persistence.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Application
{
    public class DayAppointmentService : IDayAppointmentService
    {
        private readonly ICommonPersist _commonPersist;
        private readonly IDayAppointmentPersist _dayAppointmentPersist;
        private readonly IMapper _mapper;

        public DayAppointmentService(ICommonPersist commonPersist,
                                     IDayAppointmentPersist dayAppointmentPersist,
                                     IMapper mapper)
        {
            _commonPersist = commonPersist;
            _dayAppointmentPersist = dayAppointmentPersist;
            _mapper = mapper;
        }

        public async Task<DayAppointmentDto> AddDayAppointment(DayAppointmentDto model)
        {
            var dayAppointments = _dayAppointmentPersist.GetDayAppointmentByDateAsync(model.Date.ToString("dd/MM/yyyy"));
            if (dayAppointments != null) throw new InvalidDataException("Ja existe um cadastro deste dia na agenda");

            var result = _mapper.Map<DayAppointment>(model);
            _commonPersist.Add<DayAppointment>(result);
            if (await _commonPersist.SaveChangesAsync())
            {
                result = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(result.Id);
                return _mapper.Map<DayAppointmentDto>(result);
            }
            throw new Exception($"Ocorreu um erro ao tentar adiconar {model.Date.ToString("dd/MM/yyyy")} a agenda");

        }

        public async Task<DayAppointmentDto> UpdateDayAppointment(int dayAppointmentId, DayAppointmentDto model)
        {

            var dayAppointment = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(dayAppointmentId);
            if (dayAppointment == null) throw new NullReferenceException("Não foi encontrado nenhum dia com este id");

            _mapper.Map(model, dayAppointment);
            model.Id = dayAppointment.Id;

            _commonPersist.Updade(dayAppointment);
            if (await _commonPersist.SaveChangesAsync())
            {
                var result = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(dayAppointmentId);
                return _mapper.Map<DayAppointmentDto>(result);
            }

            throw new
                Exception($"Ocorreu um erro ao tentar atualizar o dia {dayAppointment.Date.ToString("dd/MM/yyyy")} agenda");


        }

        public async Task<bool> DeleteDayAppointmentDto(int dayAppointmentId)
        {

            var dayAppointment = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(dayAppointmentId);
            if (dayAppointment == null) throw new NullReferenceException("Data de agenda para remoção não encontrado");

            dayAppointment.Id = dayAppointmentId;

            _commonPersist.Delete(dayAppointment);
            return await _commonPersist.SaveChangesAsync();
        }

        public async Task<DayAppointmentDto> GetDayAppointmentDtoByIdAsync(int dayAppointmentId)
        {

            var dayAppointment = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(dayAppointmentId);
            if (dayAppointment == null) throw new NullReferenceException("Não foi encontrado nenhum dia com este id");

            var result = _mapper.Map<DayAppointmentDto>(dayAppointment);

            return result;


        }

        public async Task<DayAppointmentOnlyDayDto[]> GetDayAppointmentDtoByPageAsync(int page, int row)
        {

            if (row > 5) throw new ArgumentOutOfRangeException("O retorno maximo de resultado é igual a 5");

            var dayAppointment = await _dayAppointmentPersist.GetAllDayAppointmentsAsync();
            dayAppointment = dayAppointment.Where(dayApp => dayApp.Date >= DateTime.Today).ToArray();
            dayAppointment = dayAppointment.Skip((page - 1) * row).Take(row).ToArray();

            if (dayAppointment.Length == 0 || dayAppointment == null)
                throw new IndexOutOfRangeException("Não existe mais resultados para serem enviados");

            var result = _mapper.Map<DayAppointmentOnlyDayDto[]>(dayAppointment);
            return result;

        }
    }
}

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

        public async Task<DayAppointmentDto> AddDayAppointmentDto(DayAppointmentDto model)
        {

            try
            {
                var result = _mapper.Map<DayAppointment>(model);
                _commonPersist.Add<DayAppointment>(result);
                if (await _commonPersist.SaveChangesAsync())
                {
                    result = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(result.Id);
                    return _mapper.Map<DayAppointmentDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<DayAppointmentDto> UpdateDayAppointmentDto(int dayAppointmentId, DayAppointmentDto model)
        {
            try
            {
                var dayAppointment = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(dayAppointmentId);
                if (dayAppointment == null) return null;

                _mapper.Map(model, dayAppointment);
                model.Id = dayAppointment.Id;

                _commonPersist.Updade(dayAppointment);
                if (await _commonPersist.SaveChangesAsync())
                {
                    var result = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(dayAppointmentId);
                    return _mapper.Map<DayAppointmentDto>(result);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteDayAppointmentDto(int dayAppointmentId)
        {
            try
            {
                var dayAppointment = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(dayAppointmentId);
                if (dayAppointment == null) throw new Exception("Data de agenda para remoção não encontrado");

                dayAppointment.Id = dayAppointmentId;

                _commonPersist.Delete(dayAppointment);
                return await _commonPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<DayAppointmentDto> GetDayAppointmentDtoByIdAsync(int dayAppointmentId)
        {

            try
            {
                var dayAppointment = await _dayAppointmentPersist.GetDayAppointmentByIdAsync(dayAppointmentId);
                var result = _mapper.Map<DayAppointmentDto>(dayAppointment);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<DayAppointmentOnlyDayDto[]> GetDayAppointmentDtoByPageAsync(int page = 1, int row = 5)
        {
            throw new NotImplementedException();
        }

    }
}


import { defineStore } from 'pinia';
import axios from 'axios';
import IDayAppointment from "@/interfaces/IDayAppointment"

export const useDayAppointmentStore = defineStore('dayAppointment', {
    state: () => (
        { 
          DayAppointmentList: [] as IDayAppointment[],
          UrlBase: 'https://localhost:44371/'
        }),
    getters: {
      
    },
    actions: {
      DayAppointment(page: number, row: number) {
        axios.get(`${this.UrlBase}listDays?page=${page}&row=${row}`)
          .then((response) => this.DayAppointmentList = response.data)
      },
    },
  })
  
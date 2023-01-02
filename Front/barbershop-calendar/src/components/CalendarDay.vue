<template>
    <div class="is-flex">

        <span class="icon has-text-info right-left-padding is-align-self-center">
            <i class="fa-solid fa-circle-chevron-left is-large fas fa-2x"></i>
        </span>

        <div class="is-flex" >
            <div class="right-left-padding" v-for="(day, index) in listIDayAppointment" :key="index">
                <div class="card is-clickable">
                    <div class="card-header has-background-link ">
                        <div class="card-header-title is-centered p-0 has-text-white">{{day.weekDay  }}</div>
                    </div>
                    <div class="card-content is-centered p-1">
                        <span class="tag is-link">{{day.date}}</span>
                        <br />
                        <span class="tag" :class="`${day.isAvailable ? 'is-success' : 'is-danger'}`">{{hasAppointment(day.is)}}</span>
                    </div>
                </div>
            </div>
        </div>

        <span class="icon has-text-info right-left-padding is-align-self-center">
            <i class="fa-solid fa-circle-chevron-right is-large fas fa-2x"></i>
        </span>

    </div>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
import IDayAppointment from '@/interfaces/IDayAppointment'
export default defineComponent({
    name: 'CalendarDay',
    props:{

    },
    data() {
        return {
            listIDayAppointment: null as IDayAppointment[] | null,

        }
    },
    mounted () {
        this.listIDayAppointment = [
            {
            weekDay: "Segunda",
            date : "02/01/2023",
            isAvailable: false
            },
            {
            weekDay: "Terça",
            date : "03/01/2023",
            isAvailable: true
            },
            {
            weekDay: "Quarta",
            date : "04/01/2023",
            isAvailable: true
            },
            {
            weekDay: "Quinta",
            date : "05/01/2023",
            isAvailable: true
            },
            {
            weekDay: "Sexta",
            date : "06/01/2023",
            isAvailable: false
            }
        ]
    },
    methods:{
        hasAppointment(isOpen: boolean): string {
            return (isOpen) ? 'Disponivel' : 'Indiponivel'
        }
    }
})
</script>
<style scoped>
.right-left-padding {
    padding: 0px 25px;
}

</style>
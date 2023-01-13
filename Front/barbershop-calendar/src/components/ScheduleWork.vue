<template>
    <section class="is-gapless is-multiline">
    <div class="column 
                is-flex 
                is-justify-content-center 
                is-align-items-center
                calendar-box" >
      <CalendarDay></CalendarDay>
    </div>
    <div class="column" style="background-color: red; width: 100%; height: 80vh;">
      Second column
    </div>
  </section>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
import CalendarDay from '@/components/CalendarDay.vue'
export default defineComponent({
    name: 'ScheduleWork',
    components:{
      CalendarDay
    }
    
})
</script>
<style >

.calendar-box{
  width: 100%;
  height: 20vh;
  background-image: var(--main-bg-color);
}
</style>
<template>
    <section class="is-gapless is-multiline">
    <div class="column 
                is-flex 
                is-justify-content-center 
                is-align-items-center" style="background-image: linear-gradient(165deg,#0088e0, #fbf3ef, #fbf3ef, #e24c3b ); width: 100%; height: 20vh;">
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
</style>
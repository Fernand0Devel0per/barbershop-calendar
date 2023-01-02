<template>
    <main class="columns is-gapless is-multiline">
      <div class="column is-one-quarter">
        <LateralBar/>
      </div>
      <div class="column is-three-quarter">
        <ScheduleWork/>
      </div>
    </main>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
import LateralBar from '@/components/LateralBar.vue'
import ScheduleWork from '@/components/ScheduleWork.vue'
export default defineComponent({
  name: 'App',
  components:{
    LateralBar,
    ScheduleWork
  }
  
})
</script>
<style>

</style>

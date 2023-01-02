<template>
    <header class="header-lateral">
        <div class="title-menu">
            <h1 ><span><i class="fa-solid fa-scissors title is-4"></i></span><span class="title is-3">Barbearia</span> </h1>
        </div>
        <img src="../assets/barbershop-logo.jpg" alt="" /> 
    </header>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
export default defineComponent({
    name: 'LateralBar'
})
</script>
<style scoped>
img{
    width: 70%;
    border-radius: 30px;
}

.header-lateral{
    background-image: linear-gradient(165deg,#0088e0, #fbf3ef, #fbf3ef, #e24c3b );;
    width: 100%;
    height: 100vh;
    text-align: center;
}

.title-menu{
    padding: 10px;
}



</style>
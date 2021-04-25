<template>
  <div class="dashboard-container">
    <div class="grid-dashboar">
      <DashboardItem :title="'Kursevi'" :value="3" />
      <DashboardItem :title="'Studenti'" :value="3" />
      <DashboardItem :title="'Godine'" :value="3" />
    </div>
  </div>
</template>

<script>
import DashboardItem from "@/components/DashboardItem";
export default {
  components: { DashboardItem },
  methods: {}
};
</script>
<style lang="scss" scoped>
.dashboard-container {
  padding: 40px 70px 50px 300px;
  overflow-x: auto;
  // min-width: 1120px;
}
.grid-dashboar {
  display: grid;
  grid-column-gap: 30px;
  grid-row-gap: 50px;
  grid-template-columns: 1fr 1fr 1fr;
}
</style>

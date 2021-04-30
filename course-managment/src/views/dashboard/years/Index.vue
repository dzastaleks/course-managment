<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="header">
        <div class="title">Godina</div>
        <btn
          :styleBtn="'primary'"
          :title="'Dodaj godinu'"
          :icon="'solid-plus'"
          style="margin-bottom: 0px !important"
          @click="redirectToComponent('YearCreate')"
        ></btn>
      </div>
      <table class="mytable">
        <thead>
          <tr>
            <th>ID</th>
            <th>Naziv</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="(tr, indextr) in years"
            v-bind:key="indextr"
            @mouseover="showActionButtons(indextr)"
          >
            <td>{{ tr.yearId }}</td>
            <td class="bold">{{ tr.naziv }}</td>
            <td>
              <div class="actions" v-show="buttonsIndex === indextr">
                <btn
                  :styleBtn="'secondary'"
                  :title="''"
                  :icon="'solid-pen'"
                  @click="editClick(tr.yearId)"
                ></btn>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import store from "@/store/index";

export default {
  components: {},
  methods: {
    redirectToComponent(component) {
      if (this.$route.name == component) return;
      this.$router.push({ name: component });
    },
    getAll() {
      store
        .dispatch("GET_ALL_YEAR")
        .then((response) => {
          this.years = response.data.years;
        })
        .catch((error) => {
          console.log(error);
        });
    },
    editClick(id) {
      this.$router.push({
        name: "YearEdit",
        params: { yearId: id }
      });
    },
    showActionButtons(id) {
      this.buttonsIndex = id;
    }
  },
  data() {
    return {
      years: [],
      buttonsIndex: 0
    };
  },
  created() {
    this.getAll();
  }
};
</script>
<style lang="scss" scoped>
.dashboard-container {
  padding: 40px 70px 50px 300px;
  overflow-x: auto;
  // min-width: 1120px;
}
.grid-dashboard {
  // display: grid;
  // grid-column-gap: 30px;
  // grid-row-gap: 50px;
  // grid-template-columns: 1fr 1fr 1fr;
  .header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 30px;
    background: #fff;
    padding: 20px 40px;
    border-radius: 4px;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.05);
    .title {
      font-size: 36px;
      text-align: left;
    }
  }
}
table.mytable {
  font-family: "Sarabun";
  font-style: normal;
  font-weight: normal;
  font-size: 14px;
  line-height: 22px;
  width: 100%;
  border-collapse: collapse;
  background: #fff;
  border-radius: 4px;
  thead {
    tr {
      height: 56px;
      font-size: 14px;
      line-height: 22px;
      border-bottom: 1px solid #f0f0f0;
      th {
        font-family: "Sarabun", sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 14px;
        line-height: 22px;
        color: rgba(0, 0, 0, 0.85);
        text-align: left;
        padding-left: 16px;
        border-bottom: 1px solid #f0f0f0;
      }
    }
  }
  tbody {
    tr {
      height: 56px;
      font-size: 14px;
      line-height: 22px;
      td {
        font-family: "Sarabun", sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 14px;
        line-height: 22px;
        color: rgba(0, 0, 0, 0.65);
        text-align: left;
        padding-left: 16px;
        border-bottom: 1px solid #f0f0f0;
      }
      td.bold {
        font-family: "Sarabun", sans-serif;
        font-style: normal;
        font-weight: bold;
        font-size: 14px;
        line-height: 22px;
        color: rgba(0, 0, 0, 0.65);
        text-align: left;
        padding-left: 16px;
      }
      td:last-child {
        text-align: right !important;
        padding-right: 10px;
        padding-top: 10px;
      }
      &:hover {
        background: #fbfbfb;
      }
    }
  }
}
</style>

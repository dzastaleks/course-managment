<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="title">Godina</div>
      <table class="mytable">
        <thead>
          <tr>
            <th>ID</th>
            <th>Naziv</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(tr, indextr) in incomes" v-bind:key="indextr">
            <td>{{ tr.category }}</td>
            <td class="bold">{{ tr.actual }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
export default {
  components: {},
  methods: {},
  data() {
    return {
      incomes: [
        {
          id: 1,
          category: "Apartment Rent",
          actual: "$1,000.00",
          planned: "$1,200.00",
          difference: "- $200.00",
          percentage: "37.5%",
          color: "#0E8DD3"
        },
        {
          id: 2,
          category: "Premises Rent",
          actual: "$1,300.00",
          planned: "$1,500.00",
          difference: "- $200.00",
          percentage: "25%",
          color: "#32A2E0"
        },
        {
          id: 3,
          category: "Bilboard Rent",
          actual: "$1,243.60",
          planned: "$1000.00",
          difference: "+ $243.60",
          percentage: "12.5%",
          color: "#29B2FD"
        },
        {
          id: 4,
          category: "Loans",
          actual: "$1,000.00",
          planned: "$500.00",
          difference: "- $500.00",
          percentage: "12.5%",
          color: "#4CBFFF"
        },
        {
          id: 5,
          category: "Others",
          actual: "$200.00",
          planned: "$100.00 ",
          difference: "+ $100.00",
          percentage: "12.5%",
          color: "#75CEFF"
        }
      ]
    };
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
  .title {
    font-size: 36px;
    text-align: left;
    margin-bottom: 30px;
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
      &:hover {
        background: #fbfbfb;
      }
    }
  }
}
</style>

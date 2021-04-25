<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="title">Novi Student</div>
      <div class="form-card">
        <h1>Dodajte novog studenta</h1>
        <div class="form-items">
          <div class="input-group">
            <label for="ime">Ime: </label>
            <input type="text" placeholder="Unesite Ime studenta" />
          </div>
          <div class="input-group">
            <label for="prezime">Prezime: </label>
            <input type="text" placeholder="Unesite Prezime studenta" />
          </div>
          <div class="input-group">
            <label for="brojIndeksa">Broj Indeksa: </label>
            <input type="text" placeholder="Unesite Broj indeksa studenta" />
          </div>
          <div class="input-group">
            <label for="Status">Status:</label>
            <dropdown
              :options="statusDropdownOptions"
              :default="statusDropdownDefault"
              @input="handleDropdown"
              :tabindex="1"
            ></dropdown>
          </div>
          <div class="input-group">
            <label for="Godina">Godina:</label>
            <dropdown
              :options="godinaDropdownOptions"
              :default="godinaDropdownDefault"
              @input="handleDropdown"
              :tabindex="1"
            ></dropdown>
          </div>
          <div>
            <btn :styleBtn="'primary'" :title="'Sačuvaj'"></btn>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  components: {},
  methods: {
    handleDropdown(value) {
      console.log("dropdown", value);
    }
  },
  data() {
    return {
      statusDropdownOptions: [
        { id: 1, name: "Redovni" },
        { id: 2, name: "Vanredni" }
      ],
      statusDropdownDefault: { id: 0, name: "Izaberi" },
      godinaDropdownOptions: [
        { id: 1, name: "Prva" },
        { id: 2, name: "Druga" },
        { id: 3, name: "Treca" },
        { id: 4, name: "Cetvrta" }
      ],
      godinaDropdownDefault: { id: 0, name: "Izaberi" }
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
  .form-card {
    margin: 0 auto !important;
    text-align: center;
    background: #ffffff;
    box-shadow: 0px 4px 20px rgba(0, 0, 0, 0.15);
    border: none !important;
    width: 100%;
    min-height: calc(100vh - 200px);
    padding-bottom: 70px;
    h1 {
      font-family: "Roboto";
      font-style: normal;
      font-weight: 500;
      font-size: 30px;
      line-height: 38px;
      color: #000000;
      padding-top: 43px;
      margin-bottom: 96px;
    }
    .form-items {
      max-width: 395px;
      margin: 0 auto;
      .input-group {
        .eye-icon {
          position: absolute;
          right: 20px;
          // bottom: 20px;
          top: 48px;
          font-size: 9px;
          line-height: 9px;
          color: #6b6b6b;
          cursor: pointer;
        }
      }
    }
  }
}
</style>

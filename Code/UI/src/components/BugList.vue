<template>
  <div class="buglist">
    <table class="table table-striped table-bordered table-hover table-condensed">
      <thead>
        <tr>
          <th>ID</th>
          <th>Tittle</th>
          <th>Severity</th>
          <th>Priority</th>
          <th>Status</th>
        </tr>
      </thead>
      <tbody>
        <tr >
          <td>1</td>
          <td>Bangalore</td>
          <td>High</td>
          <td>High</td>
          <td>New</td>
        </tr>
        <tr>
          <td>2</td>
          <td>Bangalore</td>
          <td>High</td>
          <td>High</td>
          <td>Fixed</td>
        </tr>
        <tr>
          <td>3</td>
          <td>Bangalore</td>
          <td>High</td>
          <td>High</td>
          <td>Assigned</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: 'BugList',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
/* h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
} */
</style>

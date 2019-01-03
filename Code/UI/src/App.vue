<template>
  <div id="app">
      <!-- <div id="header" class="container-fluid">
        <div class="logo"><h1>Bug Free</h1></div>
        <div class="navbar navbar-default" role="navigation">
           <ul class="nav navbar-nav">
            <li class="active"><a href="#">Project</a></li>
            <li><a href="#">Bug</a></li>
            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                    Admin
                    <b class="caret"></b>
                </a>
                <ul class="dropdown-menu">
                    <li><a href="#">Users</a></li>
                    <li><a href="#">Roles</a></li>
                    <li><a href="#">Change Password</a></li>
                </ul>
            </li>
        </ul>
        </div>
        <div class="user"></div>
      </div> -->
      <nav class="navbar navbar-default" role="navigation">
    <div class="container-fluid"> 
    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse"
                data-target="#example-navbar-collapse">
            <span class="sr-only">切换导航</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand" href="#">菜鸟教程</a>
    </div>
    <div class="collapse navbar-collapse" id="example-navbar-collapse">
        <ul class="nav navbar-nav">
            <li class="active"><a href="#">iOS</a></li>
            <li><a href="#">SVN</a></li>
            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                    Java <b class="caret"></b>
                </a>
                <ul class="dropdown-menu">
                    <li><a href="#">jmeter</a></li>
                    <li><a href="#">EJB</a></li>
                    <li><a href="#">Jasper Report</a></li>
                    <li class="divider"></li>
                    <li><a href="#">分离的链接</a></li>
                    <li class="divider"></li>
                    <li><a href="#">另一个分离的链接</a></li>
                </ul>
            </li>
        </ul>
    </div>
    </div>
</nav>
      <div id="body" class="container">
        <router-view/>
      </div>
      <div id="footer">
      </div>
  </div>
</template>

<script>
export default {
  import: ['jquery/dist/js/jquery.slim.min.js', 'popper.js/dist/umd/popper.min.js', 'bootstrap/dist/js/bootstrap.min.js'],
  name: 'App'
}
</script>

<style>
  @import 'bootstrap/dist/css/bootstrap.min.css';
  #app {
    background-color:bisque;
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
  #header {
    background-color: aqua;
    height: 100px;
    text-align: center;
    padding: 5px;
  }
  #header .logo {
    background-color:cadetblue;
    float: left;
    height: 90px;
    width: 200px;
    text-align:center;
    padding: 5px;
  }
  #header .nav {
    background-color:chartreuse;
    float: left;
  }
</style>

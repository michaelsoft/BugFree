import Vue from 'vue'
import Router from 'vue-router'
import BugList from '@/components/BugList'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'BugList',
      component: BugList
    }
  ]
})

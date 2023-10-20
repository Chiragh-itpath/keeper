import { RouterEnum } from '@/Models/enum'
import type { RouteLocationNormalized } from 'vue-router'
import { ItemStore, KeepStore, ProjectStore } from '@/stores'

const beforeResolve = async (route: RouteLocationNormalized) => {
    const id = Array.isArray(route.params.id) ? route.params.id.join('') : route.params.id
    const tag = Array.isArray(route.params.tag) ? route.params.tag.join('') : route.params.tag
    const projectStore = ProjectStore()
    const keepStore = KeepStore()
    const itemStore = ItemStore()
    switch (route.name) {
        case RouterEnum.PROJECT:
            await projectStore.getProjects()
            projectStore.FetchProjects()
            break
        case RouterEnum.PROJECT_BY_TAG:
            await projectStore.getProjects()
            projectStore.FilterByTag(tag)
            break
        case RouterEnum.SHARED:
            await projectStore.FetchSharedProjects()
            break
        case RouterEnum.KEEP:
            await keepStore.GetKeeps(id)
            break
        case RouterEnum.KEEP_BY_TAG:
            keepStore.FilterByTag(tag)
            break
        case RouterEnum.ITEM:
            await itemStore.GetAllItems(id)
            break
        case RouterEnum.HOME:
        case RouterEnum.LOGIN:
        case RouterEnum.SIGNUP:
            break
    }
}

export { beforeResolve }

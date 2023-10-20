import { defineStore, storeToRefs } from 'pinia'
import { computed, ref, type Ref } from 'vue'
import { InviteStore } from '@/stores'
import { Colors } from '@/Models/enum'

const Uitlity = defineStore('toster', () => {
    const { InvitedProjectList, InvitedKeepList } = storeToRefs(InviteStore())
    const visible: Ref<boolean> = ref(false)
    const text: Ref<string> = ref('')
    const color: Ref<string> = ref('primary')
    const Loading: Ref<boolean> = ref(false)
    const SideBarIsVisible: Ref<boolean> = ref(true)

    const NotificationCount = computed((): number => {
        return InvitedProjectList.value.length + InvitedKeepList.value.length
    })
    const ToggleSideBar = (): void => {
        SideBarIsVisible.value = !SideBarIsVisible.value
    }
    const makeToster = (message: string, _color: Colors) => {
        text.value = message
        color.value = _color
        visible.value = true
    }
    return {
        visible,
        text,
        color,
        Loading,
        SideBarIsVisible,
        NotificationCount,
        makeToster,
        ToggleSideBar
    }
})
export { Uitlity }

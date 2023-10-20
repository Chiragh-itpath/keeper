import { computed, ref, type Ref } from 'vue'
import { defineStore } from 'pinia'
import type { IKeep, IAddKeep, IEditKeep } from '@/Models/KeepModels'
import { Insert, GetAll, Update, Delete } from '@/Services/KeepService'
import { dateHelper } from '@/Services/HelperFunction'

const KeepStore = defineStore('KeepStore', () => {
    const AllKeeps: Ref<IKeep[]> = ref([])
    const Keeps: Ref<IKeep[]> = ref([])

    const keepTags = computed(() => {
        const tags = AllKeeps.value.map((x) => x.tag)
        return [...new Set(tags)]
    })

    const getSingleKeep = (id: string): IKeep | undefined => {
        const keep = Keeps.value.find((x) => x.id == id)
        return keep
    }

    const FindIndex = (id: string): number => Keeps.value.findIndex((x) => x.id == id)

    const AddKeep = async (addKeep: IAddKeep): Promise<any> => {
        const response = await Insert(addKeep)
        if (response) {
            AllKeeps.value.push(response)
            fetchKeeps()
        }
    }
    const getSingle = (id: string) => {
        return AllKeeps.value.find((x) => x.id == id)
    }
    const GetKeeps = async (projectId: string): Promise<any> => {
        const response = await GetAll(projectId)
        if (response) {
            AllKeeps.value = response
            fetchKeeps()
        }
    }
    const DeleteKeep = async (keepId: string): Promise<any> => {
        const response = await Delete(keepId)
        if (response) {
            const index = Keeps.value.findIndex((x) => x.id == keepId)
            if (index !== -1) Keeps.value.splice(index, 1)
        }
    }
    const Updatekeep = async (editKeep: IEditKeep): Promise<any> => {
        const response = await Update(editKeep)
        if (response) {
            const index = FindIndex(editKeep.id)
            AllKeeps.value.splice(index, 1, response)
            fetchKeeps()
        }
    }
    const fetchKeeps = (): void => {
        Keeps.value = AllKeeps.value
    }
    const FilterByDate = (date: string) => {
        if (date == '') {
            fetchKeeps()
        } else {
            Keeps.value = AllKeeps.value.filter((x) => dateHelper(date) == dateHelper(x.createdOn))
        }
    }
    const FilterByTag = (tag: string) => {
        Keeps.value = AllKeeps.value.filter((x) => x.tag == tag)
    }
    return {
        Keeps,
        keepTags,
        AddKeep,
        GetKeeps,
        DeleteKeep,
        Updatekeep,
        getSingleKeep,
        FilterByDate,
        FilterByTag,
        fetchKeeps,
        getSingle
    }
})
export { KeepStore }

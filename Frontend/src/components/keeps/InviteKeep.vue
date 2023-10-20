<script setup lang="ts">
import { type Ref, ref, watch } from 'vue'
import TextField from '@/components/Custom/TextField.vue'
import type { IUser } from '@/Models/UserModels'
import { InviteStore, Uitlity, UserStore } from '@/stores'
import { Colors } from '@/Models/enum'
import type { Collaborators } from '@/Models/Collaborators'

const props = withDefaults(defineProps<{
    modelValue: boolean,
    id: string,
    projectId: string
}>(), {
    modelValue: false
})

const { CheckEmail, User } = UserStore()
const { makeToster } = Uitlity()
const { InviteUsersToKeep, GetProjectCollaborators, GetKeepCollaborators } = InviteStore()

const visible: Ref<boolean> = ref(false)
const email: Ref<string> = ref('')
const form = ref()
const inviteList: Ref<IUser[]> = ref([])
const errorMessages: Ref<string[]> = ref([])
const collaborators: Ref<Collaborators[]> = ref([])
const collaboratorsList: Ref<Collaborators[]> = ref([])

const HandleCheckEmail = async () => {
    errorMessages.value = []
    const { valid } = await form.value.validate()
    if (!valid) return
    const isAlreadyInvited = collaborators.value.find(x => x.email.toLocaleLowerCase() == email.value.toLowerCase())
    if (isAlreadyInvited) {
        errorMessages.value.push('User is already invited')
        email.value = ''
        return
    }
    const isAlreadyAdded = inviteList.value.find(x => x.email.toLowerCase() == email.value.toLowerCase())
    if (isAlreadyAdded) {
        errorMessages.value.push('User is already added')
        email.value = ''
        return
    }
    if (User.email.toLocaleLowerCase() == email.value.toLowerCase()) {
        errorMessages.value.push('Cannot Add your self')
        email.value = ''
        return
    }
    const user = await CheckEmail(email.value)
    if (user) {
        inviteList.value.push(user)
        form.value.reset()
    } else {
        errorMessages.value.push('Email Does not exist')
    }

}
const handleRemove = (email: string) => {
    inviteList.value = inviteList.value.filter(x => x.email != email)
}
const handleInvite = async (): Promise<void> => {

    if (inviteList.value.length == 0) {
        makeToster('Please select users', Colors.SUCCESS)
    } else {
        await InviteUsersToKeep(props.id, props.projectId, inviteList.value.map(e => e.email))
        visible.value = false
    }
}

watch(props, async () => {
    visible.value = props.modelValue
    if (props.modelValue) {
        const res1 = await GetProjectCollaborators(props.projectId)
        const res2 = await GetKeepCollaborators(props.id)
        collaborators.value = [...res1, ...res2]
        collaboratorsList.value = collaborators.value.filter(x => x.hasAccepted)
    }
})

watch(visible, () => {
    if (!visible.value) {
        emits('update:modelValue', visible.value)
    }
    inviteList.value = []
    email.value = ''
})
const emits = defineEmits<{
    (e: 'update:modelValue', modelValue: boolean): void
}>()

</script>
<template>
    <v-dialog transition="scale-transition" v-model="visible" max-width="600" close-on-back>
        <v-card>
            <v-card-title class="text-center"> Invite To Keep </v-card-title>
            <v-card-text>
                <v-row>
                    <v-col cols="12">
                        <v-form ref="form" validate-on="submit">
                            <div class="d-flex">
                                <text-field label="Email" v-model="email" class="me-3" is-required is-email
                                    :error-messages="errorMessages" />
                                <v-btn icon="mdi-plus" color="primary" @click="HandleCheckEmail" />
                            </div>
                        </v-form>
                    </v-col>
                    <v-col cols="12" v-if="collaborators.length > 0">
                        <p class="font-weight-bold">Collaborators:</p>
                        <v-list>
                            <v-list-item v-for="(item, index) in collaboratorsList" :key="index"
                                class="border rounded-lg my-2 ">
                                <div class="d-flex align-center" v-if="item.hasAccepted">
                                    <v-icon color="primary" class="me-3" size="x-large">mdi-account-circle</v-icon>
                                    <div class="d-flex flex-column ">
                                        <span> {{ item.userName }}</span>
                                        <span class="text-body-2 text-grey">{{ item.email }}</span>
                                    </div>
                                </div>
                            </v-list-item>
                        </v-list>
                    </v-col>
                    <v-col cols="12" v-if="inviteList.length > 0">
                        <p class="font-weight-bold">Invitation List:</p>
                        <v-list>
                            <v-list-item v-for="(item, index) in inviteList" :key="index" role="button"
                                class="border rounded-lg my-2 ">
                                <div class="d-flex align-center">
                                    <v-icon color="primary" class="me-3" size="x-large">mdi-account-circle</v-icon>
                                    <div class="d-flex flex-column ">
                                        <span> {{ item.userName }}</span>
                                        <span class="text-body-2 text-grey">{{ item.email }}</span>
                                    </div>
                                    <v-spacer></v-spacer>
                                    <v-icon color="red" @click="handleRemove(item.email)">mdi-close</v-icon>
                                </div>
                            </v-list-item>
                        </v-list>
                    </v-col>
                </v-row>
            </v-card-text>
            <v-card-actions class="justify-end">
                <v-btn color="primary" variant="elevated" width="100" class="mb-5 me-5" @click="handleInvite">
                    invite
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

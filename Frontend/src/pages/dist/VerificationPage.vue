<!-- <script setup lang="ts">
import { onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { useAccountStore } from '@/stores
import type { ISharedItem } from '@/Models/SharedItem'
import { RouterEnum } from '@/Models/enum'
const { SharedItemDetail } = useAccountStore()
onMounted(async () => {
    var type = Number.parseInt(useRoute().params.type.toString())
    var uId = useRoute().params.userId.toString()
    var tId = useRoute().params.typeId.toString()
    var model: ISharedItem = {
        type: type,
        uId: uId,
        typeId: tId
    }
    await SharedItemDetail(model)

    // if(type==0){

    // }
    // else{

    // }
})
</script>
<template>
    <v-app class="bg-teal-lighten-3">
        <v-main class="d-flex justify-center align-center">
            <v-col cols="12" sm="12" md="6" lg="4" xl="3" xxl="2" class="mx-auto">
                <v-card class="pa-4 elevation-12">
                    <v-card-title class="text-center mt-5">
                        <h2 class="text-teal">Welcome!!</h2>
                    </v-card-title>
                    <v-card-subtitle class="text-center mb-5"
                        ><v-img
                            class="mx-auto"
                            :width="200"
                            src="https://img.icons8.com/clouds/100/000000/handshake.png"
                        ></v-img>
                    </v-card-subtitle>
                    <v-card-text class="text-center text-subtitle-1">
                        Thank you for your collaboration! Feel free to make any edits or add your
                        thoughts directly to the note.To access the note and start collaborating,
                        click the button below:
                    </v-card-text>
                    <v-card-actions>
                        <div class="d-flex flex-column justify-center mx-auto">
                            <v-btn
                                type="submit"
                                flatcolor="#5865f2"
                                rounded="lg"
                                size="large"
                                variant="flat"
                                color="teal"
                                class="mt-4"
                                @click="$router.push({ name: RouterEnum.LOGIN })"
                                >Open</v-btn
                            >
                        </div>
                    </v-card-actions>
                </v-card>
            </v-col>
        </v-main>
    </v-app>
</template> -->

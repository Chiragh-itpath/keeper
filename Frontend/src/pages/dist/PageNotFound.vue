<script setup lang="ts">
import navbar from '@/components/NavBar.vue'
</script>
<template>
    <v-app>
        <navbar />
        <v-main class="d-flex justify-center align-center bg-teal-lighten-3">
            <v-container fill-height fluid>
                <v-row class="my-auto" align="center" justify="center">
                    <v-col lg="6" order-lg="2">
                        <img
                            class="img-fluid"
                            src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNjg1IiBoZWlnaHQ9IjQ0MCIgdmlld0JveD0iMCAwIDY4NSA0NDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNMC4xNDQ1NTkgMjA5Ljk2MkwxMzcuMzAzIDI0NC42NTFMMTI2LjE1OCAyODguNzE4TDE5OS40MiAzMDcuMjQ2TDIxMC41NjUgMjYzLjE3OUwyMzguNDM4IDI3MC4yMjhDMjc2LjY1NSAzNDguOTc3IDM0MS4yNzUgMzc3LjI5NCA0MTAuNjYyIDM0Ny45NEM0MjEuNTgxIDM0My4zMjEgNDMxLjM4IDMzNy43OTEgNDQwLjAyNiAzMzEuNDI5TDQzOS4wNjcgMzg2Ljc5NUw0NzEuMDg5IDQzOS4xNEw1OTEuNzc1IDM2NS4zMTFMNjE1LjQ5NSA0MDQuMDg2TDY3OS45NTggMzY0LjY1MUw2NTYuMjM4IDMyNS44NzZMNjg0LjgzNCAzMDguMzgyTDY1Mi44MTEgMjU2LjAzN0w2MjQuMjE1IDI3My41M0w1MjguMTQ4IDExNi40OTRMNDY3LjUzNiAxNTMuNTczQzQyOS45MzggNjguMDgxIDM2NC4wMTkgMzguNjk0NyAyOTIuMTcxIDY5LjI0MTlDMjc3LjIyOSA3NS41OTQ1IDI2NC4zNDggODMuNTMyNCAyNTMuNjMgOTIuODk5OUwyNzAuNzQ3IDI1LjIxNjlMMTczLjggMC42OTgyNTFMMTUuMTkwMSAxNTAuNDcyTDAuMTQ0NTU5IDIwOS45NjJaTTQ2Ny41MzYgMTUzLjU3M0w0NDIuODQ0IDE2OC42NzhMNDQwLjAyNiAzMzEuNDI5QzQ4OS4wNzggMjk1LjMzMiA1MDAuOTU3IDIzMi40MzggNDY5LjAzMyAxNTcuMDQxQzQ2OC41MzkgMTU1Ljg3NSA0NjguMDQgMTU0LjcxOSA0NjcuNTM2IDE1My41NzNaTTI1My42MyA5Mi44OTk5TDIyNS42MSAyMDMuNjg5TDI1OC4xMSAyMTEuOTA4TDI0My4wNjQgMjcxLjM5OUwyMzguNDM4IDI3MC4yMjhDMjM2LjQ0OSAyNjYuMTMgMjM0LjUzMiAyNjEuODk2IDIzMi42ODkgMjU3LjUyNkMyMDMuMDIyIDE4Ny4xNzEgMjEyLjAyNCAxMjkuMjYzIDI1My42MyA5Mi44OTk5Wk0xNTQuMDAxIDE4NS41NzhMOTAuNjU1IDE2OS41NThMOTEuMjEyMiAxNjcuMzU0TDE3Ni44NzQgODUuODdMMTc5LjA3NyA4Ni40MjczTDE1NC4wMDEgMTg1LjU3OFpNNTYxLjIwNyAzMTIuMDc2TDUwNS40NjggMzQ2LjE3NEw1MDQuMjgyIDM0NC4yMzVMNTA1Ljg5NyAyMjYuMDE5TDUwNy44MzYgMjI0LjgzM0w1NjEuMjA3IDMxMi4wNzZaTTMwNy45ODQgMjI1LjUxM0MzMzEuNjc3IDI4MS45NjUgMzYwLjQ0MyAyOTkuNTI1IDM4NS41NDEgMjg4Ljg1NEM0MTAuNjQgMjc4LjE4MyA0MTcuODIyIDI0NS4zMzkgMzkzLjczNyAxODkuMDU0QzM3MC4yMDggMTM0LjA3NiAzNDIuMTY4IDExNy4xMzQgMzE3LjA3IDEyNy44MDVDMjkxLjk3MSAxMzguNDc2IDI4NC44NDcgMTcwLjM2OCAzMDcuOTg0IDIyNS41MTNaIiBmaWxsPSJ3aGl0ZSIvPgo8L3N2Zz4K"
                            alt="Figure"
                        />
                    </v-col>
                    <v-col md="8" lg="5" order-lg="1" class="text-center text-lg-start">
                        <h1>
                            <span class="text-red" style="font-size: 4rem">Opps!</span> Page not
                            found.
                        </h1>
                        <p>The page you’re looking for doesn’t exist.</p>

                        <router-link to="/">
                            <v-btn
                                class="my-2"
                                variant="elevated"
                                :rounded="true"
                                color="white"
                                size="x-large"
                                >Go Home
                            </v-btn>
                        </router-link>
                    </v-col>
                </v-row>
            </v-container>
        </v-main>
    </v-app>
</template>

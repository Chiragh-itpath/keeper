<script setup lang="ts">
const props = withDefaults(defineProps<{
    variant?: NonNullable<"flat"> | undefined;
}>(), {
    variant: 'flat'
});
</script>

<template>
    <v-row>
        <v-col cols="12">
            <v-sheet>

                <v-card :variant="props.variant">
            <div class="d-flex flex-no-wrap justify-space-between">
                    <div>
                        <v-card-title>
                            <slot name="title">
                            </slot>
                        </v-card-title>
                        <v-card-subtitle>
                            <slot name="subtitle">
                            </slot>
                        </v-card-subtitle>
                        <v-card-text>
                            <slot name="text">
                            </slot>
                        </v-card-text>
                        <v-card-actions>
                            <slot name="actions"></slot>
                        </v-card-actions>
                    </div>
                <div>                       
                    <slot name="image"></slot>
                </div>
            </div>
        </v-card>
            </v-sheet>
      </v-col>
        </v-row>
</template>
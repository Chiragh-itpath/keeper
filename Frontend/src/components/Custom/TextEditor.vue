<script setup lang="ts">
import { ref, watch } from 'vue'
import { QuillEditor } from '@vueup/vue-quill'

const props = defineProps<{
    modelValue?: string
}>()

const text = ref(props.modelValue)

watch(text, () => {
    emits('update:modelValue', text.value)
})
const emits = defineEmits<{
    (e: 'update:modelValue', modelValue: string | undefined): void
}>()
defineOptions({
    inheritAttrs: false
})
const toolbar = [
    ['bold', 'italic', 'underline', 'strike'],
    ['blockquote', 'code-block', 'link'],
    [{ 'header': [1, 2, 3, false] }],
    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
    [{ 'color': [] }, { 'background': [] }],
    [{ 'size': ['small', false, 'large'] }],
    [{ 'font': [] }],
    [{ 'align': [] }],
]
</script>

<template>
    <div class="container">
        <quill-editor :toolbar="toolbar" style="height: 200px;" v-model:content="text" content-type="html"></quill-editor>
    </div>
</template>
<style>
.ql-flip {
    left: 10px !important;
}
</style>
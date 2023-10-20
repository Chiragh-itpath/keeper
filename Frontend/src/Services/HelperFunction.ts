const dateHelper = (d: string | null | undefined): string => {
    if (d) {
        const date = new Date(d)
        return date.toLocaleString(undefined, { month: 'short', day: 'numeric', year: 'numeric' })
    }
    return '-'
}

export { dateHelper }

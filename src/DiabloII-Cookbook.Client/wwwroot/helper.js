export function getScreenDimensions() {
    return { height: window.innerHeight, width: window.innerWidth }
}

export function getDimensions(element) {
    return element.getBoundingClientRect()
}
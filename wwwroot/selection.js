window.getSelectionText = () => {
    const selection = window.getSelection();
    if (!selection || selection.rangeCount === 0) return null;

    const range = selection.getRangeAt(0);
    const text = selection.toString();

    if (!text.trim()) return null;

    return {
        text,
        startOffset: range.startOffset,
        endOffset: range.endOffset
    };
};

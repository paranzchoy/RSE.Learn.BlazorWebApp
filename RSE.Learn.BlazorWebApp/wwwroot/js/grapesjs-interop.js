// Simple global variable to hold our editor instance
let editor = null;

// Initialize GrapesJS with basic settings
export function initializeGrapesJS(elementId) {
    // Clear any existing editor instance
    if (editor) {
        editor.destroy();
        editor = null;
    }
    
    // Initialize with basic configuration
    editor = grapesjs.init({
        container: `#${elementId}`,
        height: '700px',
        width: 'auto',
        fromElement: true,
        storageManager: false,
        blockManager: {
            appendTo: '#blocks',
            blocks: [
                {
                    id: 'section',
                    label: 'Section',
                    attributes: { class: 'gjs-block-section' },
                    content: '<section><h1>This is a simple title</h1><div>This is just a basic text</div></section>',
                },
                {
                    id: 'text',
                    label: 'Text',
                    content: '<div data-gjs-type="text">Insert your text here</div>',
                },
                {
                    id: 'image',
                    label: 'Image',
                    content: { type: 'image' },
                }
            ]
        }
    });

    return editor;
}

// Load plain HTML and CSS
export function loadContent(html, css) {
    if (!editor) return;
    
    if (html && html.trim()) {
        editor.setComponents(html);
    }
    
    if (css && css.trim()) {
        editor.setStyle(css);
    }
}

// Get HTML content from the editor
export function getHtmlContent() {
    if (!editor) return '';
    return editor.getHtml();
}

// Get CSS content from the editor
export function getCssContent() {
    if (!editor) return '';
    return editor.getCss();
}
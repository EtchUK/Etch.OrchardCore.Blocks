import Embed from '@editorjs/embed';
import Header from '@editorjs/header';
import List from '@editorjs/list';
import Paragraph from '@editorjs/paragraph';
import Raw from '@editorjs/raw';
import Quote from '@editorjs/quote';
import SimpleImage from '@editorjs/simple-image';

import EditorJS from '@editorjs/editorjs';

window.initializeEditorJS = (id, hiddenFieldId) => {
    const $hiddenField = document.getElementById(hiddenFieldId);

    if (!$hiddenField) {
        return;
    }

    const $form = $hiddenField.closest('form');

    if (!$form) {
        return;
    }

    const editor = new EditorJS({
        holder: id,

        placeholder: 'Enter your content here...',

        tools: {
            embed: Embed,
            header: {
                class: Header,
                inlineToolbar: true,
            },
            image: SimpleImage,
            list: {
                class: List,
                inlineToolbar: true,
            },
            paragraph: {
                class: Paragraph,
                inlineToolbar: true,
            },
            quote: Quote,
            raw: Raw,
        },

        data: !$hiddenField.value ? {} : JSON.parse($hiddenField.value),
    });

    const onSubmit = e => {
        editor
            .save()
            .then(outputData => {
                $hiddenField.value = JSON.stringify(outputData);
                $form.removeEventListener('submit', onSubmit);
                $form.submit();
            })
            .catch(error => {});
    };

    $form.addEventListener('submit', onSubmit);
};

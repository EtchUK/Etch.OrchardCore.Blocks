import 'bootstrap';
import $ from 'jquery';

import './index.css';

const selectors = {
    mediaApp: '#mediaApp',
    mediaFieldSelectButton: '.mediaFieldSelectButton',
    modalBody: '.modal-body',
};

export default class MediaLibraryTool {
    static get toolbox() {
        return {
            title: 'Image',
            icon:
                '<svg width="17" height="15" viewBox="0 0 336 276" xmlns="http://www.w3.org/2000/svg"><path d="M291 150V79c0-19-15-34-34-34H79c-19 0-34 15-34 34v42l67-44 81 72 56-29 42 30zm0 52l-43-30-56 30-81-67-66 39v23c0 19 15 34 34 34h178c17 0 31-13 34-29zM79 0h178c44 0 79 35 79 79v118c0 44-35 79-79 79H79c-44 0-79-35-79-79V79C0 35 35 0 79 0z"/></svg>',
        };
    }

    constructor({ data, config, api }) {
        this.api = api;
        this.config = config || {};

        this._data = { media: data.media || [] };
        this.data = data;

        this.modalBodyElement = document.getElementById(
            `${config.id}-ModalBody`
        );
    }

    render() {
        this.wrapper = document.createElement('div');
        this.wrapper.classList.add('cdx-block');
        this.wrapper.classList.add('media-library-tool');

        if (!this.data.media) {
            this._openMediaLibrary();
            return this.wrapper;
        }

        this._renderItems();
        return this.wrapper;
    }

    save() {
        const $captions = this.wrapper.querySelectorAll(
            '.media-library-item__caption'
        );
        for (var i = 0; i < this._data.media.length; i++) {
            this._data.media[i].caption = $captions[i].innerHTML;
        }

        return this._data;
    }

    /**
     * Opens the Orchard Core media library.
     */
    _openMediaLibrary() {
        const self = this;

        $(selectors.mediaApp)
            .detach()
            .appendTo($(this.modalBodyElement).find(selectors.modalBody));

        $(selectors.mediaApp).show();

        const modal = $(this.modalBodyElement).modal();

        $(this.modalBodyElement)
            .find(selectors.mediaFieldSelectButton)
            .off('click')
            .on('click', async function() {
                if (window.mediaApp.selectedMedias.length) {
                    self._setMediaItems(window.mediaApp.selectedMedias);
                }

                window.mediaApp.selectedMedias = [];

                modal.modal('hide');
                return true;
            });
    }

    _renderMediaItem(media) {
        const item = document.createElement('div');
        item.classList.add('media-library-item');

        const imageWrapper = document.createElement('div');
        imageWrapper.classList.add('media-library-item__image');

        const image = document.createElement('img');
        image.classList.add('media-library-item__image');
        image.src = media.url;
        imageWrapper.appendChild(image);

        const caption = document.createElement('div');
        caption['contentEditable'] = true;
        caption.dataset.placeholder = 'Caption...';
        caption.classList.add('cdx-input');
        caption.classList.add('media-library-item__caption');
        caption.innerHTML = media.caption;

        item.appendChild(imageWrapper);
        item.appendChild(caption);

        this.wrapper.appendChild(item);
    }

    _renderItems() {
        this.data.media.forEach(media => {
            this._renderMediaItem(media);
        });
    }

    /**
     * Updates block with selected media items.
     * @param {*} mediaItems
     */
    _setMediaItems(mediaItems) {
        this.wrapper.innerHTML = '';

        mediaItems.forEach(media => {
            const item = {
                caption: '',
                mediaPath: media.mediaPath,
                url: media.url,
            };

            this._data.media.push(item);
            this._renderMediaItem(item);
        });
    }
}

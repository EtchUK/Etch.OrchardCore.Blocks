import { make } from '../utils/dom';

export default class Ui {
    constructor() {
        this.nodes = {
            caption: make('div', ['cdx-input', 'media-library-item__caption'], {
                contentEditable: true,
            }),
            image: make('img', ['media-library-item__image']),
            imageWrapper: make('div', ['media-library-item__image']),
            item: make('div', ['media-library-item']),
            wrapper: make('div', ['cdx-block', 'media-library-tool']),
        };

        this.nodes.caption.dataset.placeholder = 'Caption...';

        this.nodes.imageWrapper.appendChild(this.nodes.image);
        this.nodes.item.appendChild(this.nodes.imageWrapper);
        this.nodes.item.appendChild(this.nodes.caption);
        this.nodes.wrapper.appendChild(this.nodes.item);
    }

    getCaption() {
        return this.nodes.caption.innerHTML;
    }

    render(toolData) {
        this.nodes.image.src = toolData.url;
        this.nodes.caption.innerHTML = toolData.caption;

        return this.nodes.wrapper;
    }
}

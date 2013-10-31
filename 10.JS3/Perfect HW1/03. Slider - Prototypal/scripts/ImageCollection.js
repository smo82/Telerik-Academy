/// <reference path="ImageInfo.js" />
(function () {
    ImageCollection = {
        init: function () {
            this.images = [];
            this.current = 0;
        },
        addImage: function (imgTitle, imgSrc, thumbnailSrc) {
            var newImgInfo = Object.create(ImageInfo);
            newImgInfo.init(imgTitle, imgSrc, thumbnailSrc);
            this.images.push(newImgInfo); 
        },
        setCurrentByTitle: function (title) {
            for (var i in this.images) {
                if (this.images[i].title === title) {
                    this.current = i;
                    return this.images[i];
                }
                this.current = 0;
            }
        },
        getFirst: function () {
            return this.images[0];
        },
        getNext: function () {
            this.current++;
            if (this.current >= this.images.length) {
                this.current = 0;
            }

            return this.images[this.current];
        },
        getPrevious: function () {
            this.current--;
            if (this.current < 0) {
                this.current = this.images.length - 1;
            }

            return this.images[this.current];
        }

    }
}())
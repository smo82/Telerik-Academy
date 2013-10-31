/// <reference path="OOPUtils.js" />
/// <reference path="Folder.js" />
/// <reference path="URL.js" />

(function () {
    Sitebar = Class.create({
        init: function (title, containerSelector) {
            this.topFolder = new Folder(title);

            this.container = document.querySelector(containerSelector);
            this.initContainer();
        },
        initContainer: function () {
            this.container.addEventListener("click", function (ev) {
                if (ev.target.nodeName === "DIV") {
                    if (ev.target.nextSibling.style.display === "none") {
                        ev.target.nextSibling.style.display = "";
                    }
                    else {
                        ev.target.nextSibling.style.display = "none";
                    }
                }
            },
            false);
        },
        addFolder: function (title) {
            return this.topFolder.addFolder(title);
        },
        addUrl: function (title, url) {
            this.topFolder.addUrl(title, url);
        },
        render: function () {
            var rendered = this.topFolder.render();
            var firstLevelFolders = rendered.lastChild;
            firstLevelFolders.style.display = "";
            this.container.appendChild(rendered);
        }
    });
}())
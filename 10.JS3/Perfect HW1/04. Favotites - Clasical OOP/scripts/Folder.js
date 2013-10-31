/// <reference path="OOPUtils.js" />
/// <reference path="URL.js" />

(function () {
    Folder = Class.create({
        init: function (title) {
            this.title = title;
            this.URLs = [];
            this.subFolders = [];
        },
        addURL: function (title, url) {
            var newURL = new URL(title, url);
            this.URLs.push(newURL);
        },
        addFolder: function (title) {
            var newFolder = new Folder(title);
            this.subFolders.push(newFolder);
            return newFolder;
        },
        render: function () {
            var fragment = document.createDocumentFragment();

            // title
            var titleContainer = document.createElement("div");
            titleContainer.innerHTML += this.title;
            fragment.appendChild(titleContainer);

            // urls and folders
            var itemsContainer = document.createElement("ul");
            itemsContainer.style.display = "none";
            for (var i = 0; i < this.URLs.length; i++) {
                var anchor = document.createElement("a");
                anchor.href = this.URLs[i].url;
                anchor.title = this.URLs[i].title;
                anchor.innerHTML = this.URLs[i].title;

                var li = document.createElement("li");
                li.appendChild(anchor);
                itemsContainer.appendChild(li);
            }

            for (var i = 0; i < this.subFolders.length; i++) {
                var li = document.createElement("li");
                li.appendChild(this.subFolders[i].render());
                itemsContainer.appendChild(li);
            }

            fragment.appendChild(itemsContainer);

            return fragment;
        }
    });
}())
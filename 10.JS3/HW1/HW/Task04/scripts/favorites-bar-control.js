var controls = (function(){

  var Folder = Class.create({
    init: function(title) {
      this.title = title;
      this.urls = [];
      this.subFolders = [];

      this.rootFolderElement = document.createElement("li");
      this.subFoldersList = document.createElement("ul");
      this.urlsList = document.createElement("ul");
    },

    addUrl: function(title, url) {
      var urlObject = new Url(title, url);
      this.urls.push(urlObject)
    },

    addFolder: function(folder) {
      this.subFolders.push(folder)
    },

    render: function() {
      while (this.rootFolderElement.firstChild) {
        this.rootFolderElement.removeChild(this.rootFolderElement.firstChild);
      }

      while (this.subFoldersList.firstChild) {
        this.subFoldersList.removeChild(this.subFoldersList.firstChild);
      }

      while (this.urlsList.firstChild) {
        this.urlsList.removeChild(this.urlsList.firstChild);
      }

      var rootTitle = document.createElement("span");
      rootTitle.className = "folder-title";
      rootTitle.innerHTML = this.title;

      var domItem;
      for (var i = 0, len = this.urls.length; i < len; i += 1) {
        domItem = this.urls[i].render();
        this.urlsList.appendChild(domItem);
      }

      for (var i = 0, len = this.subFolders.length; i < len; i += 1) {
        domItem = this.subFolders[i].render();
        this.subFoldersList.appendChild(domItem);
      }

      this.rootFolderElement.appendChild(rootTitle);

      if (this.subFolders.length > 0){
        this.rootFolderElement.appendChild(this.subFoldersList);
      }

      if (this.urls.length > 0){
        this.rootFolderElement.appendChild(this.urlsList);
      }
      console.log(this.rootFolderElement);
      return this.rootFolderElement;
    }
  });

  var Url = Class.create({
    init: function(title, url) {
      this.title = title;
      this.url = url;
    },

    render: function() {
      var urlNode = document.createElement("li");
      urlNode.innerHTML = "<a href='" + this.url + "' target = '_blank'>" + this.title + "</a>";
      return urlNode;
    }
  });

  var FavoritesBar = Class.create({
    init: function(selector) {
      this.urls = [];
      this.subFolders = [];

      this.rootElement = document.querySelector(selector);
      this.foldersList = document.createElement("ul");
      this.urlsList = document.createElement("ul");
    },

    addUrl: function(title, url) {
      var urlObject = new Url(title, url);
      this.urls.push(urlObject)
    },

    addFolder: function(folder) {
      this.subFolders.push(folder)
    },

    render: function() {
      while (this.rootElement.firstChild) {
        this.rootElement.removeChild(this.rootElement.firstChild);
      }

      while (this.foldersList.firstChild) {
        this.foldersList.removeChild(this.foldersList.firstChild);
      }

      while (this.urlsList.firstChild) {
        this.urlsList.removeChild(this.urlsList.firstChild);
      }

      var domItem;
      for (var i = 0, len = this.urls.length; i < len; i += 1) {
        domItem = this.urls[i].render();
        this.urlsList.appendChild(domItem);
      }

      for (var i = 0, len = this.subFolders.length; i < len; i += 1) {
        domItem = this.subFolders[i].render();
        this.foldersList.appendChild(domItem);
      }

      if (this.subFolders.length > 0){
        this.rootElement.appendChild(this.foldersList);
      }

      if (this.urls.length > 0){
        this.rootElement.appendChild(this.urlsList);
      }
      return this;
    }
  });

  return{
    getFavoritesBar : function(selector) {
      return new FavoritesBar(selector);
    },

    createFolder : function (title){
      return new Folder(title);
    }
  }
}());
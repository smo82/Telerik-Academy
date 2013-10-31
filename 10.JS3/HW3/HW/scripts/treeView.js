(function($) {
  function addSubTree(subTreeParent, subTreeData){
    var subTreeRootText = subTreeData.text || "";

    var subTreeElement = $(document.createElement("li"));
    subTreeElement.html("<img src = 'images/itemIcon.png'>" + subTreeRootText);
    subTreeParent.append(subTreeElement);

    var subTreeChildList = subTreeData.childs || [];

    if (subTreeChildList.length > 0){
      var subTreeChildRoot = $(document.createElement("ul"));
      subTreeChildRoot.css("display", "none");
      subTreeChildRoot.css("list-style", "none");

      for (var i = 0; i < subTreeChildList.length; i++) {
        var treeItem = addSubTree(subTreeChildRoot, subTreeChildList[i]);
      };

      subTreeElement.append(subTreeChildRoot);
    }
  }

  $.fn.treeView = function(treeViewParam, mode) {
    var treeViewMode = mode || "collapse";
    var treeViewData = treeViewParam.treeViewData || [];

    var treeViewRoot = $(document.createElement("ul"));
    treeViewRoot.attr("id", "treeViewRoot");
    treeViewRoot.css("list-style", "none");

    for (var i = 0; i < treeViewData.length; i++) {
      addSubTree(treeViewRoot, treeViewData[i]);
    };
    this.append(treeViewRoot);

    this.on('click', function (ev){

      var clickedItemHTML = ev.target;
      var clickedItem = $(clickedItemHTML);

      if (!(clickedItemHTML instanceof HTMLLIElement)) {
        return;
      }

      // First 

      if (treeViewMode == "collapse")
      {
        var childUl = clickedItem.children("ul");
        if (childUl.css("display") == "none"){
          childUl.css("display", "");
        }
        else{
          childUl.css("display", "none");
        }        
      } else if (treeViewMode == "singleItemOpen"){
        var previousSelectedItems = $(".selected");
        previousSelectedItems.removeClass("selected");

        var listItems = treeViewRoot.find("ul");
        listItems.css("display", "none");

        var childUl = clickedItem.children("ul");
        childUl.css("display", "");

        var itemParent = clickedItem.parent();

        while (itemParent.attr("id") != "treeViewRoot"){
          itemParent.css("display", "");
          itemParent = itemParent.parent();
        }
      }

    });

    return this;
  }
}(jQuery))
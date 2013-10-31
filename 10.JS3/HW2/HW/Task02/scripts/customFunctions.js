var controls = (function(){

  insertBefore = function(insertedElement, targetElement){
    var targetParent = targetElement.parent();
    targetParent.prepend(insertedElement);

    var previousNode = targetElement.prev();
    while($(previousNode)[0] != $(insertedElement)[0]){
      var newPreviousNode = previousNode.prev();
      targetParent.prepend(previousNode);
      previousNode = newPreviousNode;
    }
  }

  insertAfter = function(insertedElement, targetElement){
    var targetParent = targetElement.parent();
    targetParent.append(insertedElement);

    var previousNode = targetElement.next();
    while($(previousNode)[0] != $(insertedElement)[0]){
      var newPreviousNode = previousNode.next();
      targetParent.append(previousNode);
      previousNode = newPreviousNode;
    }
  }


  return{
    insertBefore : insertBefore,
    insertAfter : insertAfter
  }
}());
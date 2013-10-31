/***************************************************************************************************/
/* TASK 01 */
/***************************************************************************************************/
/* TEST FOOD */
/***************************************************************************************************/
module("Food.init");

test("When the moving food is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var size = 10;
  var food = new snakeGame.Food(position, size);

  equal(position, food.position, "Position is set");
  equal(size, food.size, "Size is set");
});

/***************************************************************************************************/
module("Food.changePosition");

test("When position is changed", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var food = new snakeGame.Food(position, size);

  var newPosition = { x: 250, y: 250 };
  food.changePosition(newPosition);
  equal(newPosition.x, food.position.x, "Position X changed");
  equal(newPosition.y, food.position.y, "Position X changed");
});
/*******************************************************************************/

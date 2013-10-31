/***************************************************************************************************/
/* TASK 01 */
/***************************************************************************************************/
/* TEST MOVING FOOD */
/***************************************************************************************************/
module("Moving food.init");

test("When the moving food is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  equal(position, movingFood.position, "Position is set");
  equal(size, movingFood.size, "Size is set");
  equal(speed, movingFood.speed, "Speed is set");
  equal(direction, movingFood.direction, "Direction is set");
});

/***************************************************************************************************/
module("Moving food.move");

test("When direction is 0, decrease x", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  movingFood.move();
  position.x - speed;
  deepEqual(movingFood.position, position);
});

test("When direction is 1, decrease y", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  movingFood.move();
  position.y - speed;
  deepEqual(movingFood.position, position);
});

test("When direction is 2, increase x", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  movingFood.move();
  position.x + speed;
  deepEqual(movingFood.position, position);
});

test("When direction is 3, should increase x", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  movingFood.move();
  position.y + speed;
  deepEqual(movingFood.position, position);
});


/***************************************************************************************************/
module("Moving food.changeDirection");

test("When direction is 0 and we change it to 1", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  var newDirection = 1;
  movingFood.changeDirection(newDirection);
  equal(newDirection, movingFood.direction, "Direction is set");
});

test("When direction is 0 and we change it to 2", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  var newDirection = 2;
  movingFood.changeDirection(newDirection);
  equal(newDirection, movingFood.direction, "Direction is set");
});

test("When direction is 0 and we change it to 3", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  var newDirection = 3;
  movingFood.changeDirection(newDirection);
  deepEqual(movingFood.direction, newDirection);
});

test("When direction is 0 and we change it to 0", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  var newDirection = 0;
  movingFood.changeDirection(newDirection);
  deepEqual(movingFood.direction, direction);
});

/***************************************************************************************************/
module("Moving food.changePosition");

test("When position is changed", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingFood = new snakeGame.MovingFood(position, size, speed, direction);

  var newPosition = { x: 250, y: 250 };
  movingFood.changePosition(newPosition);
  equal(newPosition.x, movingFood.position.x, "Position X changed");
  equal(newPosition.y, movingFood.position.y, "Position X changed");
});
/*******************************************************************************/

/***************************************************************************************************/
/* TASK 01 */
/***************************************************************************************************/
/* TEST MOVING FOOD */
/***************************************************************************************************/
module("Moving obstacle.init");

test("When the moving obstacle is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingObstacle = new snakeGame.MovingObstacle(position, size, speed, direction);

  equal(position, movingObstacle.position, "Position is set");
  equal(size, movingObstacle.size, "Size is set");
  equal(speed, movingObstacle.speed, "Speed is set");
  equal(direction, movingObstacle.direction, "Direction is set");
});

/***************************************************************************************************/
module("Moving obstacle.move");

test("When direction is 0, decrease x", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingObstacle = new snakeGame.MovingObstacle(position, size, speed, direction);

  movingObstacle.move();
  position.x - speed;
  deepEqual(movingObstacle.position, position);
});

test("When direction is 1, decrease y", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingObstacle = new snakeGame.MovingObstacle(position, size, speed, direction);

  movingObstacle.move();
  position.y - speed;
  deepEqual(movingObstacle.position, position);
});

test("When direction is 2, increase x", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingObstacle = new snakeGame.MovingObstacle(position, size, speed, direction);

  movingObstacle.move();
  position.x + speed;
  deepEqual(movingObstacle.position, position);
});

test("When direction is 3, should increase x", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingObstacle = new snakeGame.MovingObstacle(position, size, speed, direction);

  movingObstacle.move();
  position.y + speed;
  deepEqual(movingObstacle.position, position);
});


/***************************************************************************************************/
module("Moving obstacle.changeDirection");

test("When direction is 0 and we change it to 1", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingObstacle = new snakeGame.MovingObstacle(position, size, speed, direction);

  var newDirection = 1;
  movingObstacle.changeDirection(newDirection);
  equal(newDirection, movingObstacle.direction, "Direction is set");
});

test("When direction is 0 and we change it to 2", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingObstacle = new snakeGame.MovingObstacle(position, size, speed, direction);

  var newDirection = 2;
  movingObstacle.changeDirection(newDirection);
  equal(newDirection, movingObstacle.direction, "Direction is set");
});

test("When direction is 0 and we change it to 3", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingObstacle = new snakeGame.MovingObstacle(position, size, speed, direction);

  var newDirection = 3;
  movingObstacle.changeDirection(newDirection);
  deepEqual(movingObstacle.direction, newDirection);
});

test("When direction is 0 and we change it to 0", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var speed = 15;
  var direction = 0;
  var movingObstacle = new snakeGame.MovingObstacle(position, size, speed, direction);

  var newDirection = 0;
  movingObstacle.changeDirection(newDirection);
  deepEqual(movingObstacle.direction, direction);
});
/*******************************************************************************/

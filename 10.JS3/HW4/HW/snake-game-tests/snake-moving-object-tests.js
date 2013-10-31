/***************************************************************************************************/
/* TASK 01 */
/***************************************************************************************************/
/* TEST MOVING OBJECT */
/***************************************************************************************************/
module("Moving object.init");

test("When the moving object is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 0;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  equal(position, movingObject.position, "Position is set");
  equal(size, movingObject.size, "Size is set");
  equal(fcolor, movingObject.fcolor, "Fcolor is set");
  equal(scolor, movingObject.scolor, "Scolor is set");
  equal(speed, movingObject.speed, "Speed is set");
  equal(direction, movingObject.direction, "Direction is set");
});

/***************************************************************************************************/
module("Moving object.move");

test("When direction is 0, decrease x", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 0;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  movingObject.move();
  position.x - speed;
  deepEqual(movingObject.position, position);
});

test("When direction is 1, decrease update y", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 0;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  movingObject.move();
  position.y - speed;
  deepEqual(movingObject.position, position);
});

test("When direction is 2, increase x", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 0;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  movingObject.move();
  position.x + speed;
  deepEqual(movingObject.position, position);
});

test("When direction is 3, should increase x", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 0;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  movingObject.move();
  position.y + speed;
  deepEqual(movingObject.position, position);
});


/***************************************************************************************************/
module("Moving object.changeDirection");

test("When direction is 0 and we change it to 1", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 0;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 1;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, newDirection);
});

test("When direction is 0 and we change it to 2", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 0;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 2;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, direction);
});

test("When direction is 0 and we change it to 3", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 0;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 3;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, newDirection);
});

test("When direction is 0 and we change it to 0", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 0;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 0;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, direction);
});



test("When direction is 1 and we change it to 0", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 1;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 0;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, newDirection);
});

test("When direction is 1 and we change it to 2", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 1;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 2;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, newDirection);
});

test("When direction is 1 and we change it to 3", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 1;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 3;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, direction);
});

test("When direction is 1 and we change it to 1", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 1;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 1;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, direction);
});



test("When direction is 2 and we change it to 0", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 2;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 0;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, direction);
});

test("When direction is 2 and we change it to 2", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 2;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 2;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, direction);
});

test("When direction is 2 and we change it to 3", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 2;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 3;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, newDirection);
});

test("When direction is 2 and we change it to 1", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 2;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 1;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, newDirection);
});



test("When direction is 3 and we change it to 0", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 3;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 0;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, newDirection);
});

test("When direction is 3 and we change it to 2", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 3;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 2;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, newDirection);
});

test("When direction is 3 and we change it to 3", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 3;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 3;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, direction);
});

test("When direction is 3 and we change it to 1", function(){
  var position = { x: 150, y: 150 };
  var size = 10;
  var fcolor = "#cccccc";
  var scolor = "#444444";
  var speed = 15;
  var direction = 3;
  var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  var newDirection = 1;
  movingObject.changeDirection(newDirection);
  deepEqual(movingObject.direction, direction);
});

/*******************************************************************************/

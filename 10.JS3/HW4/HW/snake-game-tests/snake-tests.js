/***************************************************************************************************/
/* TASK 02 */
/***************************************************************************************************/
/* TEST SNAKE */
/***************************************************************************************************/
(function (){
  module("Snake.init");
  QUnit.testStart(function() {
    position = {
      x: 150,
      y: 150
    };
    speed = 15;
    direction = 0;
    snake = new snakeGame.Snake(position, speed, direction);
  });

  var position;
  var speed;
  var direction;
  var snake;

  test("When snake is initialized, should set the correct values", function() {
    equal(position, snake.position, "Position is set");
    equal(speed, snake.speed, "Speed is set");
    equal(direction, snake.direction, "Direction is set");
  });

  test("When snake is initialized, should contain 5 SnakePieces", function() {
    ok(snake.pieces,"SnakePieces are created");
    equal(snake.pieces.length, 5,"Five SnakePieces are created");
    ok(snake.head, "HeadSnakePiece is created");
  });

  test("When snake is initialized, all parts direction should be the one that was set", function() {
    equal(snake.head.direction, direction,"Head direction is as expected");

    for (var i = 1; i < snake.pieces.length; i++) {
      equal(snake.pieces[i].direction, direction,"Piece " + i + " direction is as expected");    
    };
  });

  test("When snake is initialized, all parts are one after the other", function() {
    var piecePositionX;
    var piecePositionY;
    var piece;
    for (var i = 1; i < snake.pieces.length; i++) {
      piece = snake.pieces[i];
      piecePositionX = position.x - (snakeGame.directions[direction].x * snakeGame.defaultSnakePieceSize) * i;
      piecePositionY = position.y - (snakeGame.directions[direction].y * snakeGame.defaultSnakePieceSize) * i;
      equal(snake.pieces[i].position.x, piecePositionX,"Piece " + i + " position X is as expected");
      equal(snake.pieces[i].position.y, piecePositionY,"Piece " + i + " position Y is as expected");
    };
  });

  /***************************************************************************************************/
  module("Snake.move");

  test("When snake is moved, all parts should be moved correctly", function() {
    /* Deep compy original pieces array to not be affected by the move() method*/
    var oldPieces = [];
    for (var i = 0; i < snake.pieces.length; i++) {
      oldPieces.push($.extend(true, {}, snake.pieces[i]));
    };

    snake.move();

    var newPositionX;
    var newPositionY;
    for (var i = snake.pieces.length - 1; i > 0; i -= 1) {
      newPositionX = oldPieces[i].position.x + snakeGame.directions[oldPieces[i].direction].x * speed;
      newPositionY = oldPieces[i].position.y + snakeGame.directions[oldPieces[i].direction].y * speed;

      equal(snake.pieces[i].position.x, newPositionX,"Piece " + i + " position X is as expected");
      equal(snake.pieces[i].position.y, newPositionY,"Piece " + i + " position Y is as expected");

      equal(snake.pieces[i].direction, oldPieces[i-1].direction,"Piece " + i + " direction is as expected");
    }
  });

  /***************************************************************************************************/
  module("Snake.changeDirection");

  test("When snake changes direction, all parts should be moved correctly", function() {
    /* Deep compy original pieces array to not be affected by the move() method*/
    var oldPieces = [];
    for (var i = 0; i < snake.pieces.length; i++) {
      oldPieces.push($.extend(true, {}, snake.pieces[i]));
    };

    var newSnakeDirection = 1;
    snake.changeDirection(newSnakeDirection);

    oldPieces[0].changeDirection(newSnakeDirection);
    var newPositionX;
    var newPositionY;
    for (var i = snake.pieces.length - 1; i > 0; i -= 1) {
      newPositionX = oldPieces[i].position.x + snakeGame.directions[oldPieces[i].direction].x * speed;
      newPositionY = oldPieces[i].position.y + snakeGame.directions[oldPieces[i].direction].y * speed;

      equal(snake.pieces[i].position.x, newPositionX,"Piece " + i + " position X is as expected");
      equal(snake.pieces[i].position.y, newPositionY,"Piece " + i + " position Y is as expected");

      equal(snake.pieces[i].direction, oldPieces[i-1].direction,"Piece " + i + " direction is as expected");
    }
  });

  /***************************************************************************************************/
  module("Snake.grow");

  test("When snake grows, new piece should be at the correct place", function() {
    var snakeLastPiece = snake.pieces[snake.pieces.length - 1];
    snake.grow();

    var newPieceX = snakeLastPiece.position.x - (snakeGame.directions[snakeLastPiece.direction].x * snakeGame.defaultSnakePieceSize);
    var newPieceY = snakeLastPiece.position.y - (snakeGame.directions[snakeLastPiece.direction].y * snakeGame.defaultSnakePieceSize);

    var newSnakeLastPiece = snake.pieces[snake.pieces.length - 1];
    equal(newSnakeLastPiece.position.x, newPieceX,"Last piece position X is as expected");
    equal(newSnakeLastPiece.position.y, newPieceY,"Last piece position Y is as expected");
  });


  /***************************************************************************************************/
  module("Snake.Consume");
  test("When object is Food, should grow", function() {
    var size = snake.size;
    snake.consume(new snakeGame.Food());
    var actual = snake.size;
    var expected = size + 1;
    equal(actual, expected);
  });

  test("When object is SnakePiece, should die", function() {
    var isDead = false;

    snake.addDieHandler(function() {
      isDead = true;
    });

    snake.consume(new snakeGame.SnakePiece());
    ok(isDead, "The snake is dead");
  });

  test("When object is Obstacle, should die", function() {
    var isDead = false;

    snake.addDieHandler(function() {
      isDead = true;
    });

    snake.consume(new snakeGame.Obstacle());
    ok(isDead, "The snake is dead");
  });
})();
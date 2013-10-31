/***************************************************************************************************/
/* TASK 02 */
/***************************************************************************************************/
/* TEST SNAKEOBSTACLE */
/***************************************************************************************************/
(function (){
  module("SnakeObstacle.init");
  QUnit.testStart(function() {
    position = {
      x: 150,
      y: 150
    };
    size = snakeGame.defaultSnakePieceSize;
    speed = 15;
    direction = 0;
    snakeObstacle = new snakeGame.SnakeObstacle(position, size, speed, direction);
  });

  var position;
  var speed;
  var direction;
  var snakeObstacle;
  var size;

  test("When Snake Obstacle is initialized, should set the correct values", function() {
    equal(position, snakeObstacle.position, "Position is set");
    equal(speed, snakeObstacle.speed, "Speed is set");
    equal(direction, snakeObstacle.direction, "Direction is set");
  });

  test("When Snake Obstacle is initialized, should contain 5 SnakeObstaclePieces", function() {
    ok(snakeObstacle.pieces,"SnakeObstaclePieces are created");
    equal(snakeObstacle.pieces.length, 5,"Five SnakeObstaclePieces are created");
    ok(snakeObstacle.head, "HeadSnakeObstaclePiece is created");
  });

  test("When Snake Obstacle is initialized, all parts direction should be the one that was set", function() {
    equal(snakeObstacle.head.direction, direction,"Head direction is as expected");

    for (var i = 1; i < snakeObstacle.pieces.length; i++) {
      equal(snakeObstacle.pieces[i].direction, direction,"Piece " + i + " direction is as expected");    
    };
  });

  test("When Snake Obstacle is initialized, all parts are one after the other", function() {
    var piecePositionX;
    var piecePositionY;
    var piece;
    for (var i = 1; i < snakeObstacle.pieces.length; i++) {
      piece = snakeObstacle.pieces[i];
      piecePositionX = position.x - (snakeGame.directions[direction].x * snakeGame.defaultSnakePieceSize) * i;
      piecePositionY = position.y - (snakeGame.directions[direction].y * snakeGame.defaultSnakePieceSize) * i;
      equal(snakeObstacle.pieces[i].position.x, piecePositionX,"Piece " + i + " position X is as expected");
      equal(snakeObstacle.pieces[i].position.y, piecePositionY,"Piece " + i + " position Y is as expected");
    };
  });

  /***************************************************************************************************/
  module("SnakeObstacle.move");

  test("When Snake Obstacle is moved, all parts should be moved correctly", function() {
    /* Deep copy original pieces array to not be affected by the move() method*/
    var oldPieces = [];
    for (var i = 0; i < snakeObstacle.pieces.length; i++) {
      oldPieces.push($.extend(true, {}, snakeObstacle.pieces[i]));
    };

    snakeObstacle.move();

    var newPositionX;
    var newPositionY;
    for (var i = snakeObstacle.pieces.length - 1; i > 0; i -= 1) {
      newPositionX = oldPieces[i].position.x + snakeGame.directions[oldPieces[i].direction].x * speed;
      newPositionY = oldPieces[i].position.y + snakeGame.directions[oldPieces[i].direction].y * speed;

      equal(snakeObstacle.pieces[i].position.x, newPositionX,"Piece " + i + " position X is as expected");
      equal(snakeObstacle.pieces[i].position.y, newPositionY,"Piece " + i + " position Y is as expected");

      equal(snakeObstacle.pieces[i].direction, oldPieces[i-1].direction,"Piece " + i + " direction is as expected");
    }
  });

  /***************************************************************************************************/
  module("SnakeObstacle.changeDirection");

  test("When Snake Obstacle changes direction, all parts should be moved correctly", function() {
    /* Deep compy original pieces array to not be affected by the move() method*/
    var oldPieces = [];
    for (var i = 0; i < snakeObstacle.pieces.length; i++) {
      oldPieces.push($.extend(true, {}, snakeObstacle.pieces[i]));
    };

    var newSnakeDirection = 1;
    snakeObstacle.changeDirection(newSnakeDirection);

    oldPieces[0].changeDirection(newSnakeDirection);
    var newPositionX;
    var newPositionY;
    for (var i = snakeObstacle.pieces.length - 1; i > 0; i -= 1) {
      newPositionX = oldPieces[i].position.x + snakeGame.directions[oldPieces[i].direction].x * speed;
      newPositionY = oldPieces[i].position.y + snakeGame.directions[oldPieces[i].direction].y * speed;

      equal(snakeObstacle.pieces[i].position.x, newPositionX,"Piece " + i + " position X is as expected");
      equal(snakeObstacle.pieces[i].position.y, newPositionY,"Piece " + i + " position Y is as expected");

      equal(snakeObstacle.pieces[i].direction, oldPieces[i-1].direction,"Piece " + i + " direction is as expected");
    }
  });

  /***************************************************************************************************/
  module("SnakeObstacle.grow");

  test("When Snake Obstacle grows, new piece should be at the correct place", function() {
    var snakeLastPiece = snakeObstacle.pieces[snakeObstacle.pieces.length - 1];
    snakeObstacle.grow();

    var newPieceX = snakeLastPiece.position.x - (snakeGame.directions[snakeLastPiece.direction].x * snakeGame.defaultSnakePieceSize);
    var newPieceY = snakeLastPiece.position.y - (snakeGame.directions[snakeLastPiece.direction].y * snakeGame.defaultSnakePieceSize);

    var newSnakeLastPiece = snakeObstacle.pieces[snakeObstacle.pieces.length - 1];
    equal(newSnakeLastPiece.position.x, newPieceX,"Last piece position X is as expected");
    equal(newSnakeLastPiece.position.y, newPieceY,"Last piece position Y is as expected");
  });


  /***************************************************************************************************/
  module("Snake.Consume");
  test("When object is Food, should grow", function() {
    var size = snakeObstacle.size;
    snakeObstacle.consume(new snakeGame.Food());
    var actual = snakeObstacle.size;
    var expected = size + 1;
    equal(actual, expected);
  });
})();
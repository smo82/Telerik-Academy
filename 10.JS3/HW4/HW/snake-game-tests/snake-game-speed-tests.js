/***************************************************************************************************/
/* TASK 02 */
/***************************************************************************************************/
/* TEST GAME SPEED CHANGE */
/***************************************************************************************************/
(function (){
  module("SnakeGame.changeGameSpeed");
  test("Test game speed change after 5 foods eaten", function() {
    var game = new snakeGame.SnakeEngine(undefined, 300, 300); 
    var initialTimeInterval = game.timeInterval;
    var snakePosition = game.snake.position;
    for (var i = 0; i < 5; i++) {
      game.food.position = snakePosition;
      game.checkCollisions();
    };

    equal(initialTimeInterval * 0.8, game.timeInterval, "Speed changed");
  });

})();
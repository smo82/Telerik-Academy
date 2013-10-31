//Task01
//The AcademyPopcorn class contains an IndestructibleBlock class. 
//Use it to create side and ceiling walls to the game. 
//You can ONLY edit the AcademyPopcornMain.cs file.

//Task02
//The Engine class has a hardcoded sleep time (search for "System.Threading.Sleep(500)". 
//Make the sleep time a field in the Engine and implement a constructor, which takes it as an additional parameter.

//Task05
//Implement a TrailObject class. It should inherit the GameObject class and should have 
//a constructor which takes an additional "lifetime" integer. 
//The TrailObject should disappear after a "lifetime" amount of turns. 
//You must NOT edit any existing .cs file. 
//Then test the TrailObject by adding an instance of it in the engine through the AcademyPopcornMain.cs file.


//Task07
//Test the MeteoriteBall by replacing the normal ball in the AcademyPopcornMain.cs file.

//Task09
//Test the UnpassableBlock and the UnstoppableBall by adding them to the engine in AcademyPopcornMain.cs file

//Task10
//Implement an ExplodingBlock. It should destroy all blocks around it when it is destroyed. 
//You must NOT edit any existing .cs file. Hint: what does an explosion "produce"?

//Task12
//Implement a GiftBlock class. It should be a block, which "drops" a Gift object when it is destroyed. 
//You must NOT edit any existing .cs file. Test the Gift and GiftBlock classes by adding them through the AcademyPopcornMain.cs file.

//Task13
//Implement a shoot ability for the player racket. The ability should only be activated when a Gift object falls on the racket. 
//The shot objects should be a new class (e.g. Bullet) and should destroy normal Block objects 
//(and be destroyed on collision with any block). 
//Use the engine and ShootPlayerRacket method you implemented in task 4, 
//but don't add items in any of the engine lists through the ShootPlayerRacket method. 
//Also don't edit the Racket.cs file. 
//Hint: you should have a ShootingRacket class and override its ProduceObjects method.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        public const int RacketLength = 6;
        const int SleepTime = 100;  //Task02

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            //------
            //Task01
            //------

            //Under Task09 changed the IndestructibleBlock with UnpassableBlock
            for (int i = 0; i < WorldCols; i++)
            {
                UnpassableBlock ceilingBlock = new UnpassableBlock(new MatrixCoords(1, i));

                engine.AddObject(ceilingBlock);
            } 

            for (int i = 2; i < WorldRows; i++)
            {
                UnpassableBlock leftWallBlock = new UnpassableBlock(new MatrixCoords(i, 0));
                engine.AddObject(leftWallBlock);
                UnpassableBlock rigthWallBlock = new UnpassableBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(rigthWallBlock);
            }

            //------

            //------
            //Task05
            //------

            engine.AddObject(new TrailObject(new MatrixCoords(5, 15), new char[,] { { '$' } }, 150));

            //------

            /*Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));*/

            //------
            //Task07
            //------
            /*MeteorBall theBall = new MeteorBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));*/
            //------

            //------
            //Task09
            //------

            engine.AddObject(new UnpassableBlock(new MatrixCoords(WorldRows / 2 - 7, 6)));
            engine.AddObject(new UnpassableBlock(new MatrixCoords(WorldRows / 2 - 7, 7)));

            UnstopableBall theBall = new UnstopableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            //------

            //------
            //Task10
            //------

            for (int i = WorldCols / 2; i < WorldCols - 2; i++)
            {
                engine.AddObject(new ExplodingBlock(new MatrixCoords(2, i)));
            } 
            
            //------

            //------
            //Task12
            //------

            for (int i = WorldCols / 2; i < WorldCols - 2; i++)
            {
                engine.AddObject(new GiftBlock(new MatrixCoords(WorldRows / 2 - 7, i)));
            }
            
            //------

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //Engine gameEngine = new Engine(renderer, keyboard, SleepTime); //Task02
            ShootPlayerRacketEngine gameEngine = new ShootPlayerRacketEngine(renderer, keyboard, SleepTime); //Task13

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            //------
            //Task13
            //------
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.DoRacketAction();
            };
            //------

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}

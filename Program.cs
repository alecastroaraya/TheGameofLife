using TheGameOfLife;

GameEngine engine = new GameEngine(0, true);
engine.SelectSize();
engine.Grid.SelectCells();
engine.GameStart();
engine.GameLoop();


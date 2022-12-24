using Godot;
using System.Linq;
using System.Timers;
using RLEngine;
using RLEngine.Generators;
using RLEngine.Enumerations;
using System.Threading.Tasks;

public class Main : Node2D
{

    const int TileSize = 16;
    const int DrawDistance = 16;

    [Export]
    private NodePath tileMapPath = null;
    [Export]
    private NodePath camera2DPath = null;
    private TileMap tileMap = null;
    private Camera2D camera2D = null;


    IGameBoard GameBoard { get; set; }
    IGameObject Player { get; set; }

    System.Timers.Timer GameTimer { get; set; }

    public override void _Ready()
    {

        // set-up the visual elements
        tileMap = GetNode<TileMap>(tileMapPath);
        camera2D = GetNode<Camera2D>(camera2DPath);

        // make a new GameBoard!
        GameBoard = new GameBoard(new GameLoop(GameLoopType.Serial));

        // Create a player
        Player = new GameObject(GameBoard, GameObjectType.Player);
        GameBoard.AddGameObject(Player, 0, 0, 0);
        GameBoard.AddGameObjects(-9, -9, RectangleRoomGenerator.Generate(19, 19));
        GameBoard.AddGameObject(GameObjectType.Wall, 1, 3, 0);
        GameBoard.AddGameObject(GameObjectType.Wall, 3, 2, 0);
        GameBoard.AddGameObject(GameObjectType.Monster, -2, -2, 0);

        // GameTimer = new System.Timers.Timer(1000);
        // GameTimer.Elapsed += async (object sender, ElapsedEventArgs e) => await AdvanceGameLoop(sender, e, GameBoard);
        //  GameTimer.Start();
    }

    public override void _Process(float delta)
    {

        base._Process(delta);
        if (tileMap == null) return;

        // gameloop. If no key press, do not update
        if (HandleInput()) AdvanceGameLoop(); ;

        RedrawScreen();
    }



    public bool HandleInput()
    {
        var action = false;
        (int x, int y, int z) moveDirection = (0, 0, 0);

        if (!action && Input.IsActionJustReleased("ui_right") && Input.IsActionJustReleased("ui_left")) return false;
        if (!action && Input.IsActionJustReleased("ui_up") && Input.IsActionJustReleased("ui_down")) return false;

        if (!action && Input.IsActionJustReleased("ui_right") && Input.IsActionJustReleased("ui_up"))
        {
            // Move right.
            moveDirection = (1, -1, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_right") && Input.IsActionJustReleased("ui_down"))
        {
            // Move right.
            moveDirection = (1, 1, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_left") && Input.IsActionJustReleased("ui_up"))
        {
            // Move right.
            moveDirection = (-1, -1, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_left") && Input.IsActionJustReleased("ui_down"))
        {
            // Move right.
            moveDirection = (-1, 1, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_right"))
        {
            // Move right.
            moveDirection = (1, 0, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_left"))
        {
            // Move right.
            moveDirection = (-1, 0, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_up"))
        {
            // Move right.
            moveDirection = (0, -1, 0);
            action = true;
        }
        if (!action && Input.IsActionJustReleased("ui_down"))
        {
            // Move right.
            moveDirection = (0, 1, 0);
            action = true;
        }


        if (action)
        {
            var scheduledAction = new ScheduledAction(Player.Id, new MoveAction(Player,
                                                                          moveDirection.x,
                                                                          moveDirection.y,
                                                                          moveDirection.z));

            GameBoard.GameLoop.ScheduleAction(scheduledAction);

        }


        return action;
    }
    /*
        public async Task<long> AdvanceGameLoop(object source, ElapsedEventArgs e, IGameBoard gameBoard)
        {
            // run the gameloop on player input.
            var currentTick = gameBoard.GameLoop.GameTick;
            var gameTick = await gameBoard.GameLoop.ExecuteActions();

            if (gameTick == currentTick) return gameTick;
            GD.Print(gameTick);


            return gameTick;


        }

        */


    public async Task<long> AdvanceGameLoop()
    {
        // run the gameloop on player input.

        var gameTick = await GameBoard.GameLoop.ExecuteActions();
        GD.Print(gameTick);
        return gameTick;

    }

    public void RedrawScreen()
    {

        tileMap.Clear();
        SetCameraPosition();

        var gameBoardView = new GameBoardView(GameBoard, Player.X - DrawDistance, Player.Y - DrawDistance, DrawDistance * 2, DrawDistance * 2, 0);

        foreach (var pos in gameBoardView.Positions)
        {
            var posEntity = pos.GameObjects.OrderByDescending(x => x.Layer).FirstOrDefault();
            int positionType = (int)(posEntity?.Type ?? GameObjectType.None);
            tileMap.SetCell(pos.X, pos.Y, positionType);
        }

    }



    public void SetCameraPosition()
    {
        camera2D.Position = tileMap.MapToWorld(new Vector2(Player.X, Player.Y)) + new Vector2(TileSize / 2, TileSize / 2);
    }

}
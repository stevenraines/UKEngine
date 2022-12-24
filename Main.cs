using Godot;
using System;
using System.Linq;
using static Godot.GD;
using static UKEngine.Factories.TerrainFactory;
using static UKEngine.Factories.EntityFactory;

using RLEngine.Generators;
using RLEngine;
using RLEngine.Enumerations;

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
        GameBoard.AddGameObjects(-5, -5, RectangleRoomGenerator.Generate(11, 11));
        GameBoard.AddGameObject(GameObjectType.Wall, 1, 3, 0);
        GameBoard.AddGameObject(GameObjectType.Wall, 3, 2, 0);
    }

    public override void _Process(float delta)
    {

        base._Process(delta);
        if (tileMap == null) return;

        // gameloop. If no key press, do not update
        if (!HandleInput())
        {
            AdvanceGameLoop();
        };

        tileMap.Clear();
        SetCameraPosition();
        RedrawScreen();

    }

    public bool HandleInput()
    {
        var action = false;

        if (!action && Input.IsActionJustReleased("ui_right") && Input.IsActionJustReleased("ui_left")) return false;
        if (!action && Input.IsActionJustReleased("ui_up") && Input.IsActionJustReleased("ui_down")) return false;

        if (!action && Input.IsActionJustReleased("ui_right") && Input.IsActionJustReleased("ui_up"))
        {
            // Move right.
            Player.Move(1, -1, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_right") && Input.IsActionJustReleased("ui_down"))
        {
            // Move right.
            Player.Move(1, 1, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_left") && Input.IsActionJustReleased("ui_up"))
        {
            // Move right.
            Player.Move(-1, -1, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_left") && Input.IsActionJustReleased("ui_down"))
        {
            // Move right.
            Player.Move(-1, 1, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_right"))
        {
            // Move right.
            Player.Move(1, 0, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_left"))
        {
            // Move right.
            Player.Move(-1, 0, 0);
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_up"))
        {
            // Move right.
            Player.Move(0, -1, 0);
            action = true;
        }
        if (!action && Input.IsActionJustReleased("ui_down"))
        {
            // Move right.
            Player.Move(0, 1, 0);
            action = true;
        }

        return action;
    }

    public void AdvanceGameLoop()
    {

    }

    public void RedrawScreen()
    {

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
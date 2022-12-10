using Godot;
using System.Linq;
using static Godot.GD;
using static UKEngine.Factories.TerrainFactory;
using static UKEngine.Factories.EntityFactory;
using UKEngine.Maps;
using UKEngine.Maps.Generators;
using UKEngine.Entities;

public class Main : Node2D
{

    const int TileSize = 16;

    [Export]
    private NodePath tileMapPath = null;
    [Export]
    private NodePath camera2DPath = null;
    private TileMap tileMap = null;
    private Camera2D camera2D = null;

    Map map { get; set; }
    GameObject player { get; set; }

    public override void _Ready()
    {

        tileMap = GetNode<TileMap>(tileMapPath);
        camera2D = GetNode<Camera2D>(camera2DPath);
        map = new Map();

        player = new GameObject(UKEngine.Types.EntityType.Player);

        map.AddEntity(1, 0, 0, player);
        map.AssignTerrain((-4, -4), RectangleRoomGenerator.Generate(10, 10));

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
            player.Move((1, -1));
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_right") && Input.IsActionJustReleased("ui_down"))
        {
            // Move right.
            player.Move((1, 1));
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_left") && Input.IsActionJustReleased("ui_up"))
        {
            // Move right.
            player.Move((-1, -1));
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_left") && Input.IsActionJustReleased("ui_down"))
        {
            // Move right.
            player.Move((-1, 1));
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_right"))
        {
            // Move right.
            player.Move((1, 0));
            action = true;
        }

        if (!action && Input.IsActionJustReleased("ui_left"))
        {
            // Move right.
            player.Move((-1, 0));
            action = true;
        }
        if (!action && Input.IsActionJustReleased("ui_up"))
        {
            // Move right.
            player.Move((0, -1));
            action = true;
        }
        if (!action && Input.IsActionJustReleased("ui_down"))
        {
            // Move right.
            player.Move((0, 1));
            action = true;
        }

        return action;
    }

    public void AdvanceGameLoop()
    {

    }

    public void RedrawScreen()
    {
        var positions = map.GetLayer(0);
        foreach (var pos in positions.OrderBy(p => p.Layer))
        {
            tileMap.SetCell(pos.X, pos.Y, (int)pos.Entity.EntityType);
        }
        positions = map.GetLayer(1);
        foreach (var pos in positions.OrderBy(p => p.Layer))
        {
            tileMap.SetCell(pos.X, pos.Y, (int)pos.Entity.EntityType);
        }

    }

    public void SetCameraPosition()
    {
        camera2D.Position = tileMap.MapToWorld(new Vector2(player.Position.X, player.Position.Y)) + new Vector2(TileSize / 2, TileSize / 2);
    }

}
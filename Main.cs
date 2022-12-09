using Godot;
using System.Linq;
using static Godot.GD;
using static UKEngine.Factories.TerrainFactory;
using static UKEngine.Factories.EntityFactory;
using UKEngine.Maps;

public class Main : Node2D
{
    [Export]
    private NodePath tileMapPath = null;
    private TileMap tileMap = null;

    Map map { get; set; }

    public override void _Ready()
    {

        tileMap = GetNode<TileMap>(tileMapPath);

        map = new Map();
        map.AssignTerrain((5, 3), map.BuildRectangleRoom(10, 10));

    }

    public override void _Process(float delta)
    {

        base._Process(delta);


        if (tileMap == null) return;

        var positions = map.GetLayer(0);
        foreach (var pos in positions)
        {
            tileMap.SetCell(pos.X, pos.Y, pos.Navigable ? 0 : 178);


        }


    }

}
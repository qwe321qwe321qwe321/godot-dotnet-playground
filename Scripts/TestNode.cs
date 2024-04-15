using Godot;
using System;
namespace Dotnet_Playground.Scripts;

public partial class TestNode : Node {
    public override void _Ready() {
        StaticNode.CallMe();
        SingletonTest.Instance.CallMe();
    }
    
    private void _Process(float delta) {
        if (Input.IsActionJustPressed("ui_accept")) {
            GD.Print("ui_accept pressed!");
            StaticNode.AddChildToRoot(new SingletonTest());
        }
    }
}

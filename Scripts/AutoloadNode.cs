using Godot;

namespace Dotnet_Playground.Scripts;

public partial class AutoloadNode : Node {
    public static AutoloadNode Instance { get; private set; }
    public static SceneTree SceneTree { get; private set; }
    public static Window Root { get; private set; }
    
    
    /// <summary>
    /// This method is called when the node enters the scene tree for the first time.
    /// It is earlier than _Ready.
    /// </summary>
    public override void _EnterTree() {
        Instance = this.GetNode<AutoloadNode>("/root/AutoloadNode");
        SceneTree = Instance.GetTree();
        Root = SceneTree.Root;
        GD.Print($"AutoloadNode is ready! Root={Root}");
    }
}
using Godot;

namespace Dotnet_Playground.Scripts;

public static class DeferredCalls {
    /// <summary>
    /// Add a child to a node.
    /// </summary>
    /// <param name="node"></param>
    /// <param name="child"></param>
    public static void AddChild(Node node, Node child) {
        node.CallDeferred("add_child", child);
    }
}
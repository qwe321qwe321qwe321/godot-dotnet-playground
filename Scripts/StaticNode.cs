using Godot;
using System;
namespace Dotnet_Playground.Scripts;

public static class StaticNode {
    public static void CallMe() {
        GD.Print("StaticClass.CallMe() called!");
    } 
    
    public static T GetNode<T>(string path) where T : class {
        if (!ValidateAutoloadNode()) {
            GD.PushError("Autoload has not been initialized.");
            return null;
        }

        return AutoloadNode.Root.GetNode<T>(path);
    }
    
    public static void AddChildToRoot(Node node, bool deferred = false) {
        if (!ValidateAutoloadNode()) {
            GD.PushError("Autoload has not been initialized.");
            return;
        }

        if (deferred) {
            DeferredCalls.AddChild(AutoloadNode.Root, node);
        } else {
            AutoloadNode.Root.AddChild(node);
        }
    }
    
    private static bool ValidateAutoloadNode() {
        return AutoloadNode.Instance != null;
    }
}

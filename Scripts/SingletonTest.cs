using Godot;

namespace Dotnet_Playground.Scripts;

public partial class SingletonTest : Node {
    private static SingletonTest _instance;
    public static SingletonTest Instance {
        get {
            if (_instance == null) {
                _instance = new SingletonTest() {
                    Name = "SingletonTest"
                };
                StaticNode.AddChildToRoot(_instance, true);
            }
            return _instance;
        }
    }
    
    public void CallMe() {
        GD.Print("SingletonTest.CallMe() called!");
    }
}
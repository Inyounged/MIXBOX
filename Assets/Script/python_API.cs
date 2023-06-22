using UnityEditor.Scripting.Python;
using UnityEditor;

public class HelloWorld
{
    [MenuItem("Python/Hello World")]
    static void PrintHelloWorldFromPython()
    {
        PythonRunner.RunString(@"
                import UnityEngine;
                UnityEngine.Debug.Log('hello world')
                ");
    }
}
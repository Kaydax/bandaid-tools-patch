using HarmonyLib;

//The name space must always be "BandaidPatch" else everything will just break
namespace BandaidPatch;
public class Patch //The class name must also remain Patch
{
  //This is our entry point into our patch! This is where we create the harmony instance and do all our cool patch stuff
  public static void DoPatching()
  {
    var harmony = new Harmony("xyz.kaydax.toolspatches");
    harmony.PatchAll();
  }

  //An example patch which patches Sandbox.Engine.Sandbox.JumpListManager's Startup Method. We then prefix a console log message at the top of the method
  [HarmonyPatch("JumpListManager", "BuildJumpList")]
  class JumpListPatch
  {
    [HarmonyPrefix]
    static bool Prefix()
    {
      Console.WriteLine("[Tools Patch] Jump List currently are broken under proton, so lets patch that out!");
      return false;
    }
  }
}

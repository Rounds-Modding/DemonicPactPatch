using BepInEx;
using HarmonyLib;

namespace DemonicPactPatch
{
    [BepInPlugin(ModId, ModName, "0.0.0")]
    [BepInProcess("Rounds.exe")]
    public class DemonicPactPatch : BaseUnityPlugin
    {
        private void Awake()
        {
            new Harmony(ModId).PatchAll();
        }
        private void Start()
        {
        }

        private const string ModId = "pykess.rounds.plugins.demonicpactpatch";

        private const string ModName = "Demonic Pact Patch";
    }
    [HarmonyPatch(typeof(Player), "FullReset")]
    class PlayerPatchFullReset
    {
        private static void Prefix(Player __instance)
        {
            __instance.GetComponent<Holding>().holdable.GetComponent<Gun>().dontAllowAutoFire = false;
        }
    }
}
using UnityEngine;
using HarmonyLib;
using HMLLibrary;

public class WiFiAntenna : Mod
{
    Harmony harmony;
    public void Start()
    {
        harmony = new Harmony("com.aidanamite.WiFiAntenna");
        harmony.PatchAll();
        Log("Mod has been loaded!");
    }
    
    public void OnModUnload()
    {
        harmony.UnpatchAll();
        Log("Mod has been unloaded!");
    }

    public static void Log(object message)
    {
        Debug.Log("[WiFiAntenna]: " + message.ToString());
    }
}

[HarmonyPatch(typeof(Reciever_Antenna), "Awake")]
public class Patch_Start
{
    static void Postfix(ref Reciever_Antenna __instance)
    {
        Traverse.Create(__instance).Field("wire").GetValue<Rope>().gameObject.SetActive(false);
    }
}

[HarmonyPatch(typeof(Reciever_Antenna), "ConnectToReciever")]
public class Patch_Connect
{
    static void Postfix(ref Reciever_Antenna __instance)
    {
        Traverse.Create(__instance).Field("wire").GetValue<Rope>().gameObject.SetActive(false);
    }
}

[HarmonyPatch(typeof(Reciever_Antenna), "DisconnectFromReciever")]
public class Patch_Disconnect
{
    static void Postfix(ref Reciever_Antenna __instance)
    {
        Traverse.Create(__instance).Field("wire").GetValue<Rope>().gameObject.SetActive(false);
    }
}
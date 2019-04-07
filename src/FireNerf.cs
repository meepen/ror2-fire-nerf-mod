using Harmony;
using RoR2.Mods;
using RoR2;
using System;
using UnityEngine;

namespace FireNerf
{
    public class FireNerf
    {
        [ModEntry("Fire Nerf", "1.0.0", "Meepen")]
        public static void Init()
        {
            var harmony = HarmonyInstance.Create("dev.meepen.fire-nerf");
            harmony.PatchAll();
        }
    }

    public class FirePatch
    {

        [HarmonyPatch(typeof(DotController))]
        [HarmonyPatch("InflictDot")]
        [HarmonyPatch(new Type[] { typeof(GameObject), typeof(GameObject), typeof(DotController.DotIndex), typeof(float), typeof(float) })]
        static void Prefix(DotController __instance, GameObject victimObject, GameObject attackerObject, DotController.DotIndex dotIndex, ref float duration, ref float damageMultiplier)
        {
            if (dotIndex == DotController.DotIndex.Burn)
            {
                Debug.Log("Nerfing fire damage " + damageMultiplier + " for " + duration + " seconds");
                damageMultiplier /= 10;
                duration /= 3;
                Debug.Log("New fire damage " + damageMultiplier + " for " + duration + " seconds");
            }
            
        }
    }
}
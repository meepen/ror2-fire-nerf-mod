using Harmony;
using RoR2.Mods;
using RoR2;
using System;
using UnityEngine;
using System.Reflection;
using System.IO;

namespace FireNerf
{
    public class FireNerf
    {
        [ModEntry("Fire Nerf", "1.0.0", "Meepen")]
        public static void Init()
        {
            var harmony = HarmonyInstance.Create("dev.meepen.fire-nerf");
            harmony.Patch(typeof(DotController).GetMethod("InflictDot", BindingFlags.Static | BindingFlags.Public), new HarmonyMethod(typeof(FirePatch).GetMethod("Prefix", BindingFlags.NonPublic | BindingFlags.Static)));
        }
    }

    public class FirePatch
    {
        static void Prefix(GameObject victimObject, GameObject attackerObject, DotController.DotIndex dotIndex, ref float duration, ref float damageMultiplier)
        {
            if (dotIndex == DotController.DotIndex.Burn)
            {
                damageMultiplier /= 5;
                duration /= 3;
            }
        }
    }
}
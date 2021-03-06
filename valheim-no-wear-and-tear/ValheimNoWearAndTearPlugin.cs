﻿using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace valheim_no_wear_and_tear
{
    [BepInPlugin("de.mrnotsoevil.valheim.no-wear-and-tear", "Valheim No Wear And Tear", "1.0.0.0")]
    public class ValheimNoWearAndTearPlugin : BaseUnityPlugin
    {
        private ConfigEntry<bool> configEnableWear;
        private ConfigEntry<bool> configEnableWearVisualization;
        private ConfigEntry<bool> configEnableStructuralIntegrity;
        
        public ValheimNoWearAndTearPlugin()
        {
            
        }

        public void Awake()
        {
            configEnableWear = Config.Bind("General", "EnableWear", true,
                "If enabled, exposed structures are damaged over time.");
            configEnableWearVisualization = Config.Bind("General", "EnableWearVisualization", false,
                "If enabled, exposed structures will be displayed as 'worn' over time.");
            configEnableStructuralIntegrity = Config.Bind("General", "EnableStructuralIntegrity", true,
                "If enabled, structures are checked for their integrity.");

            if (!configEnableStructuralIntegrity.Value)
            {
                Debug.Log("[Valheim No Wear And Tear] Enabling infinite structural integrity ...");
                Harmony.CreateAndPatchAll(typeof(StructuralIntegrityPatch));
            }
            if (!configEnableWear.Value)
            {
                Debug.Log("[Valheim No Wear And Tear] Enabling no wear ...");
                Harmony.CreateAndPatchAll(typeof(WearPatch));
            }
            if (!configEnableWearVisualization.Value)
            {
                Debug.Log("[Valheim No Wear And Tear] Enabling no wear visualization (wear still happens!) ...");
                Harmony.CreateAndPatchAll(typeof(WearVisualizationPatch));
            }
        }
    }
}
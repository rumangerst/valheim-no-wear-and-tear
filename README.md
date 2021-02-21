﻿# Valheim No Wear And Tear

A simple mod that allows you to change following behaviours:

* Make structural stability always 100% (this might be helpful if you have issues with performance or disappearing structures)
* Disable structure wear-down (take damage from being exposed to the elements or in water)
* Alternative: Disable only visualization of structure wear-down (the health still goes down, but it is not ugly)

## Installation

1. Install [Valheim BepInEx](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)
2. Copy `valheim_no_wear_and_tear.dll` (in the ZIP file) into `Valheim/BepInEx/plugins`
3. Copy `de.mrnotsoevil.valheim.no-wear-and-tear.cfg` (in the ZIP file and also down below) into `Valheim/BepInEx/config` (Optional; this file is created on starting the game)

By default only the wear-down visualization is turned off (no alteration of the gameplay). 
Open the config file in Notepad or any other editor and set entries you want to remove from the game to `false`. 

## Example config

```
## Settings file was created by plugin Valheim No Wear And Tear v1.0.0.0
## Plugin GUID: de.mrnotsoevil.valheim.no-wear-and-tear

[General]

## If enabled, exposed structures are damaged over time.
# Setting type: Boolean
# Default value: true
EnableWear = true

## If enabled, exposed structures will be displayed as 'worn' over time.
# Setting type: Boolean
# Default value: false
EnableWearVisualization = false

## If enabled, structures are checked for their integrity.
# Setting type: Boolean
# Default value: true
EnableStructuralIntegrity = true
```

## Compiling the plugin

The `valheim-no-wear-and-tear/libs` folder should contain following DLLs:

* 0Harmony.dll (from BepInEx)
* BepInEx.dll (from BepInEx)
* BepInEx.Harmony.dll (from BepInEx)
* UnityEngine.dll (from BepInEx)
* UnityEngine.CoreModule.dll (from BepInEx)
* UnityEngine.PhysicsModule.dll (from BepInEx)
* assembly_valheim.dll (from Valheim managed directory)

You can use Visual Studio or Jetbrains Rider.

## Harmony patch information

* Patches `UpdateSupport` in `WearNTear` (Prefix) if `EnableStructuralIntegrity == false`
* Patches `UpdateWear` in `WearNTear` (Prefix) if `EnableWear == false`
* Patches `SetHealthVisual` in `WearNTear` (Postfix) if `EnableWearVisualization == false`

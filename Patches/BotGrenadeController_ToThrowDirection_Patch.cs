using SPT.Reflection.Patching;
using System.Reflection;
using UnityEngine;

namespace NerfBotGrenades
{
	internal class BotGrenadeController_ToThrowDirection_Patch : ModulePatch
	{
		protected override MethodBase GetTargetMethod()
		{
			return typeof(BotGrenadeController).GetProperty(nameof(BotGrenadeController.ToThrowDirection)).GetGetMethod();
		}

		[PatchPrefix]
		public static bool Prefix(ref Vector3 __result, BotGrenadeController __instance, Vector3 ____precisionOffset)
		{
#if DEBUG
			Vector3 original = __instance.AIGreanageThrowData.Direction + ____precisionOffset;
#endif
			__result = __instance.AIGreanageThrowData.Direction + (____precisionOffset * NerfBotGrenades_Plugin.Multiplier.Value);
#if DEBUG
			NerfBotGrenades_Plugin.PluginLogger.LogWarning($"Modified grenade result: {__result}, original: {original}");
#endif
			return false;
		}
	}
}

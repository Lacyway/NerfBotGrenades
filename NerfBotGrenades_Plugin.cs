using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace NerfBotGrenades
{
	[BepInPlugin("com.lacyway.nbg", "NerfBotGrenades", "1.0.0")]
	internal class NerfBotGrenades_Plugin : BaseUnityPlugin
	{
		internal static ManualLogSource PluginLogger;
		internal static ConfigEntry<float> Multiplier;

		protected void Awake()
		{
			PluginLogger = Logger;
			PluginLogger.LogInfo($"{nameof(NerfBotGrenades_Plugin)} has been loaded.");

			Multiplier = Config.Bind("1. Settings", "Multiplier", 0f, new ConfigDescription("The multiplier to bots inaccuracy with grenades",
				new AcceptableValueRange<float>(0f, 10f)));

			new BotGrenadeController_ToThrowDirection_Patch().Enable();
		}
	}
}

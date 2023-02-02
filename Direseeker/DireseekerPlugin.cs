using System;
using System.Diagnostics;
using BepInEx;
using DireseekerMod.Modules;
using R2API.Utils;

namespace Direseeker
{
	[BepInDependency("com.Moffein.AccurateEnemies", BepInDependency.DependencyFlags.SoftDependency)]
	[BepInDependency("com.bepis.r2api")]
	[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
	[BepInPlugin("com.rob.Direseeker", "Direseeker", "1.3.8")]
	[R2APISubmoduleDependency(new string[]
	{
		"PrefabAPI",
		"LanguageAPI",
		"SoundAPI",
		nameof(R2API.ContentAddition)
	})]
	public class DireseekerPlugin : BaseUnityPlugin
	{
		public static bool AccurateEnemiesLoaded = false;
		public static bool AccurateEnemiesCompat = true;

		public static PluginInfo pluginInfo;
		public void Awake()
		{
			AccurateEnemiesLoaded = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.Moffein.AccurateEnemies");
			pluginInfo = Info;
			Assets.PopulateAssets();
			Tokens.RegisterLanguageTokens();
			Prefabs.CreatePrefab();
			States.RegisterStates();
			Skills.RegisterSkills();
			Projectiles.CreateProjectiles();
			SpawnCards.CreateSpawnCards();
			Assets.UpdateAssets();
			new Hooks().ApplyHooks();
		}
	}
}

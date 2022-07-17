using System;
using System.Diagnostics;
using BepInEx;
using DireseekerMod.Modules;
using R2API.Utils;

namespace Direseeker
{
	[BepInDependency("com.bepis.r2api")]
	[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
	[BepInPlugin("com.rob.Direseeker", "Direseeker", "1.3.3")]
	[R2APISubmoduleDependency(new string[]
	{
		"PrefabAPI",
		"LanguageAPI",
		"SoundAPI",
		nameof(R2API.ContentAddition)
	})]
	public class DireseekerPlugin : BaseUnityPlugin
	{
		public static PluginInfo pluginInfo;
		public void Awake()
		{
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

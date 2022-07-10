using System;
using System.Linq;
using R2API;
using Zio.FileSystems;

namespace DireseekerMod.Modules
{
	public static class Tokens
	{
        public static SubFileSystem fileSystem;
        internal static string languageRoot => System.IO.Path.Combine(Tokens.assemblyDir, "language");

        internal static string assemblyDir
        {
            get
            {
                return System.IO.Path.GetDirectoryName(Direseeker.DireseekerPlugin.pluginInfo.Location);
            }
        }

        public static void RegisterLanguageTokens()
        {
            On.RoR2.Language.SetFolders += fixme;

            /*
			LanguageAPI.Add("DIRESEEKER_BOSS_BODY_NAME", "Direseeker");
			LanguageAPI.Add("DIRESEEKER_BOSS_BODY_SUBTITLE", "Track and Kill");
			LanguageAPI.Add("DIRESEEKER_BOSS_BODY_LORE", "Direseeker\n\nDireseeker is a giant Elder Lemurian that acts as a boss in the Stage 4 area Magma Barracks. Upon defeating it, the player will unlock the Miner character for future playthroughs. The path leading to Direseeker's location only appears in one of the three variants of the level, and even then Direseeker may or may not spawn with random chance. Completing the teleporter event will also prevent it from spawning.\nNote that in online co-op the boss may spawn for the Host, but not others, although they can still damage it.\nActivating the Artifact of Kin does not prevent it from appearing.\n\nCategories: Enemies | Bosses | Unlisted Enemies\n\nLanguages: Español");
			LanguageAPI.Add("DIRESEEKER_BOSS_BODY_OUTRO_FLAVOR", "..and so it left, in search of new prey.");
			LanguageAPI.Add("DIRESEEKER_SPAWN_WARNING", "<style=cWorldEvent>You hear a distant rumbling..</style>");
			LanguageAPI.Add("DIRESEEKER_SPAWN_BEGIN", "<style=cWorldEvent>The rumbling grows loud.</style>");
             */
        }

        //Credits to Anreol for this code
        private static void fixme(On.RoR2.Language.orig_SetFolders orig, RoR2.Language self, System.Collections.Generic.IEnumerable<string> newFolders)
        {
            if (System.IO.Directory.Exists(Tokens.languageRoot))
            {
                var dirs = System.IO.Directory.EnumerateDirectories(System.IO.Path.Combine(Tokens.languageRoot), self.name);
                orig(self, newFolders.Union(dirs));
                return;
            }
            orig(self, newFolders);
        }
	}
}

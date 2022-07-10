using System;
using RoR2;
using RoR2.Navigation;
using UnityEngine;

namespace DireseekerMod.Modules
{
	public static class SpawnCards
	{
		public static void CreateSpawnCards()
		{
			SpawnCards.bossSpawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
			SpawnCards.bossSpawnCard.name = "cscDireseekerBoss";
			SpawnCards.bossSpawnCard.prefab = Prefabs.masterPrefab;
			SpawnCards.bossSpawnCard.sendOverNetwork = true;
			SpawnCards.bossSpawnCard.hullSize = HullClassification.BeetleQueen;
			SpawnCards.bossSpawnCard.nodeGraphType = MapNodeGroup.GraphType.Ground;
			SpawnCards.bossSpawnCard.requiredFlags = NodeFlags.None;
			SpawnCards.bossSpawnCard.forbiddenFlags = NodeFlags.TeleporterOK;
			SpawnCards.bossSpawnCard.directorCreditCost = 800;
			SpawnCards.bossSpawnCard.occupyPosition = false;
			SpawnCards.bossSpawnCard.loadout = new SerializableLoadout();
			SpawnCards.bossSpawnCard.noElites = true;
			SpawnCards.bossSpawnCard.forbiddenAsBoss = false;
		}

		public static CharacterSpawnCard bossSpawnCard;
	}
}

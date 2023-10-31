using System;
using On.RoR2;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace DireseekerMod.Modules
{
	public class Hooks
	{
		private void InitButtonPositions()
		{
			this.buttonPosition = new Vector3[]
			{
				new Vector3(2f, -140.5f, -439f),
				new Vector3(110f, -179.2f, -150f),
				new Vector3(203f, -75f, -195.5f),
				new Vector3(51f, -86f, -200.6f),
				new Vector3(-154f, -153f, -103.6f),
				new Vector3(-0.5f, -135.5f, -12.5f),
				new Vector3(-37.5f, -127f, -287.8f)
			};
			this.buttonRotation = new Vector3[]
			{
				new Vector3(0f, 60f, 5f),
				new Vector3(0f, 45f, 0f),
				new Vector3(290f, 340f, 0f),
				new Vector3(270f, 0f, 0f),
				new Vector3(270f, 0f, 0f),
				new Vector3(0f, 0f, 0f),
				new Vector3(0f, 90f, 110f)
			};
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003EF4 File Offset: 0x000020F4
		public void ApplyHooks()
		{
			this.InitButtonPositions();

			On.RoR2.SceneDirector.Start += (orig, self) =>
			{
				if (NetworkServer.active && SceneManager.GetActiveScene().name == "dampcavesimple")
				{
					UnityEngine.Object.Destroy(GameObject.Find("HOLDER: Newt Statues and Preplaced Chests").transform.Find("GoldChest").gameObject);
					for (int i = 0; i < this.buttonPosition.Length; i++)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Assets.direseekerButton);
						gameObject.transform.position = this.buttonPosition[i];
						gameObject.transform.rotation = Quaternion.Euler(this.buttonRotation[i]);
						NetworkServer.Spawn(gameObject);
					}
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(Assets.direseekerEncounter);
					NetworkServer.Spawn(Assets.direseekerEncounter);
				}
				orig(self);
			};
		}

		public Vector3[] buttonPosition;
		public Vector3[] buttonRotation;
	}
}

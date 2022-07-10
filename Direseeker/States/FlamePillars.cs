using System;
using EntityStates.TitanMonster;
using RoR2;
using UnityEngine;

namespace DireseekerMod.States
{
	public class FlamePillars : FlamePillar
	{
		protected override void PlacePredictedAttack()
		{
			for (int i = 0; i < 2; i++)
			{
				int num = 0;
				Vector3 predictedTargetPosition = this.predictedTargetPosition;
				Vector3 a = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f) * Vector3.forward;
				for (int j = -(2 * FireGoldFist.fistCount / 2); j < 2 * FireGoldFist.fistCount / 2; j++)
				{
					Vector3 vector = predictedTargetPosition + a * FireGoldFist.distanceBetweenFists * (float)j;
					float num2 = 60f;
					RaycastHit raycastHit;
					bool flag = Physics.Raycast(new Ray(vector + Vector3.up * (num2 / 2f), Vector3.down), out raycastHit, num2, LayerIndex.world.mask, QueryTriggerInteraction.Ignore);
					if (flag)
					{
						vector = raycastHit.point;
					}
					base.PlaceSingleDelayBlast(vector, FireGoldFist.delayBetweenFists * (float)num);
					num++;
				}
			}
		}
	}
}

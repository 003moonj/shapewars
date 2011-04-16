// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GUI)]
	[Tooltip("Scales the GUI around a pivot point. By default only effects GUI rendered by this FSM, check Apply Globally to effect all GUI controls.")]
	public class ScaleGUI : FsmStateAction
	{
		[RequiredField]
		public FsmFloat scaleX;
		[RequiredField]
		public FsmFloat scaleY;
		[RequiredField]
		public FsmFloat pivotX;
		[RequiredField]
		public FsmFloat pivotY;
		public bool normalized;
		public bool applyGlobally;

		bool applied;
		
		public override void Reset()
		{
			scaleX = 1f;
			scaleY = 1f;
			pivotX = 0.5f;
			pivotY = 0.5f;
			normalized = true;
			applyGlobally = false;
		}

		public override void OnGUI()
		{
			if (applied) return;
			
			Vector2 scale = new Vector2(scaleX.Value, scaleY.Value);
			Vector2 pivotPoint = new Vector2(pivotX.Value, pivotY.Value);
			
			if (normalized)
			{
				pivotPoint.x *= Screen.width;
				pivotPoint.y *= Screen.height;
			}
			
			GUIUtility.ScaleAroundPivot(scale, pivotPoint);
			
			if (applyGlobally)
			{
				PlayMakerGUI.GUIMatrix = GUI.matrix;
				applied = true;
			}
		}
		
		public override void OnUpdate()
		{
			applied = false;
		}
	}
}
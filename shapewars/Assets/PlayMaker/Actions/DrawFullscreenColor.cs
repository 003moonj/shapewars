// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GUI)]
	[Tooltip("Fills the screen with a Color.")]
	public class DrawFullscreenColor : FsmStateAction
	{
		[RequiredField]
		public FsmColor color;
		
		public override void Reset()
		{
			color = Color.white;
		}
		
		public override void OnGUI()
		{
			Color guiColor = GUI.color;
			GUI.color = color.Value;
			GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), ActionHelpers.WhiteTexture);
			GUI.color = guiColor;
		}
	}
}
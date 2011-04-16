// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

using UnityEngine;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GUILayout)]
	[Tooltip("GUILayout BeginHorizontal.")]
	public class GUILayoutBeginHorizontal : GUILayoutAction
	{
		public Texture image;
		public FsmString text;
		public FsmString tooltip;
		public FsmString style;
		
		public override void Reset()
		{
			text = "";
			image = null;
			tooltip = "";
			style = "";
		}
		
		public override void OnGUI()
		{
			GUILayout.BeginHorizontal(new GUIContent(text.Value, image, tooltip.Value), style.Value, LayoutOptions);
		}
	}
}
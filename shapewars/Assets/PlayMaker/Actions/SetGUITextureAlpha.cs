// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GUIElement)]
	[Tooltip("Sets the Alpha of the GUITexture attached to a Game Object. Useful for fading GUI elements in/out.")]
	public class SetGUITextureAlpha : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(GUITexture))]
		public FsmOwnerDefault gameObject;
		[RequiredField]
		public FsmFloat alpha;
		public bool everyFrame;
		
		public override void Reset()
		{
			gameObject = null;
			alpha = 1.0f;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoGUITextureAlpha();
			
			if(!everyFrame)
				Finish();
		}
		
		public override void OnUpdate()
		{
			DoGUITextureAlpha();
		}
		
		void DoGUITextureAlpha()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go != null && go.guiTexture != null)
			{
				Color color = go.guiTexture.color;
				go.guiTexture.color = new Color(color.r, color.g, color.b, alpha.Value);
			}			
		}
	}
}
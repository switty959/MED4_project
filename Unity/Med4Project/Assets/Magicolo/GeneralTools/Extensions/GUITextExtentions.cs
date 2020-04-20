using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Magicolo {
	public static class GUITextExtentions {

		public static void SetColor(this Text guiText, Color color, string channels) {
			Color newColor = guiText.color;
			if (channels.Contains("R")) newColor.r = color.r;
			if (channels.Contains("G")) newColor.g = color.g;
			if (channels.Contains("B")) newColor.b = color.b;
			if (channels.Contains("A")) newColor.a = color.a;
			guiText.color = newColor;
		}
		
		public static void SetColor(this Text guiText, float color, string channels) {
			guiText.SetColor(new Color(color, color, color, color), channels);
		}
	}
}


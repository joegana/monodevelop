﻿#if MAC
using AppKit;
using MonoDevelop.Ide;

namespace MonoDevelop.DesignerSupport.Toolbox
{
	static class Styles
	{
		public static NSColor SectionForegroundColor { get; internal set; } = NSColor.Text;
		public static NSColor SectionBackgroundColor { get; private set; } = NSColor.ControlLightHighlight;

		public static NSColor CellBackgroundSelectedColor { get; private set; } = NSColor.SelectedTextBackground;
		public static NSColor CellBackgroundColor { get; private set; } = NSColor.ControlBackground;
		public static NSColor LabelSelectedForegroundColor { get; private set; }

		public static NSColor HeaderBackgroundColor { get; private set; }
		public static NSColor HeaderBorderBackgroundColor { get; private set; }

		static Styles ()
		{
			LoadStyles ();
			Ide.Gui.Styles.Changed += (o, e) => LoadStyles ();
		}

		public static void LoadStyles ()
		{
			if (IdeApp.Preferences.UserInterfaceTheme == Theme.Light) {
				HeaderBackgroundColor = NSColor.FromRgb (0.98f, 0.98f, 0.98f);
				HeaderBorderBackgroundColor = NSColor.FromRgb (0.96f, 0.96f, 0.96f);
				LabelSelectedForegroundColor = NSColor.Highlight;
			} else {
				HeaderBackgroundColor = NSColor.FromRgb (0.29f, 0.29f, 0.29f);
				HeaderBorderBackgroundColor = NSColor.FromRgb (0.29f, 0.29f, 0.29f);
				LabelSelectedForegroundColor = NSColor.SelectedText;
			}
		}
	}
}
#endif
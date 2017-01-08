using System;
using Android.Graphics;
using Android.Widget;
using FontTest;
using FontTest.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TestLabel), typeof(TestLabelRenderer))]
namespace FontTest.Droid
{
	public class TestLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);
			Control.Typeface = Typeface.DefaultBold;
		}
	}
}
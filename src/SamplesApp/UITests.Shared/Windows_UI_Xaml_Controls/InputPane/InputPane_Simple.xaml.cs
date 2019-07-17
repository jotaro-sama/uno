﻿using Uno.UI.Samples.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#if __ANDROID__
using Android.App;
using Android.Views;
#endif

namespace UITests.Shared.Windows_UI_Xaml_Controls.InputPane
{
	[SampleControlInfo("InputPane", "InputPane_Simple")]
	public sealed partial class InputPane_Simple : UserControl
	{
		private Windows.UI.ViewManagement.InputPane _inputPane;

		public InputPane_Simple()
		{
			this.InitializeComponent();

			_inputPane = Windows.UI.ViewManagement.InputPane.GetForCurrentView();
			_inputPane.Showing += (s, e) => Update();
			_inputPane.Hiding += (s, e) => Update();

			Update();
		}

		private void Update()
		{
			IsVisible.Text = $"IsVisible: {_inputPane.Visible.ToString()}";
			OccludedRect.Text = $"OccludedRect: {_inputPane.OccludedRect.ToString()}";
		}

		private void TryShow(object sender, RoutedEventArgs args) => _inputPane.TryShow();

		private void TryHide(object sender, RoutedEventArgs args) => _inputPane.TryHide();

		private void ShowNavigationBar(object sender, RoutedEventArgs args)
		{
#if __ANDROID__
			Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().ExitFullScreenMode();
#endif
		}

		private void HideNavigationBar(object sender, RoutedEventArgs args)
		{
#if __ANDROID__
			Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
#endif
		}
	}
}
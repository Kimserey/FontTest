using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FontTest
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class ViewModel : BaseViewModel
	{
		public ViewModel()
		{
			Click = new Command(() => Color = Color.Green);
		}

		Color _color = Color.Blue;
		public Color Color
		{
			get { return _color; }
			set {
				_color = value;
				OnPropertyChanged();
			}
		}

		public ICommand Click { get; set; }
	}

	public class TestLabel : Label { }

	public class Page : ContentPage
	{
		public Page()
		{
			var label = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "Welcome to Xamarin Forms!"
			};
			var test = new TestLabel
			{
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "Test here"
				//Text = '\xf118'.ToString()
			};
			var button = new Button
			{
				Text = "Change color"
			};

			Title = "FontTest";

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children = {
					label, test, button
				}
			};

			label.SetBinding(Label.TextColorProperty, "Color");
			test.SetBinding(Label.TextColorProperty, "Color");
			button.SetBinding(Button.CommandProperty, "Click");
		}
	}

	public class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new Page { 
				BindingContext = new ViewModel()
			});
		}
	}
}

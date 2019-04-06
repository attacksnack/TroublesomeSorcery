using System;
using Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TroublesomeSorcery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
    {
        private Button translateButton;
        private Entry userEntry;
        private Button callButton;

        public MainPage ()
		{
		    Label phoneWord = new Label
		    {
		        HorizontalTextAlignment = TextAlignment.Center,
		        Text = "Enter a Phoneword:"
		    };

		    userEntry = new Entry
		    {
		        Text = "1-855-SORCERY"
		    };

		    translateButton = new Button
		    {
		        Text = "Translate",
		    };
            translateButton.Clicked += TranslateButtonOnClicked;

		    callButton = new Button
		    {
		        Text = "Call",
		        IsEnabled = false
		    };

            var layout = new StackLayout
		    {
		        VerticalOptions = LayoutOptions.Center,
		        Children = { phoneWord, userEntry, translateButton, callButton }
		    };

		    this.Content = layout;
		}

	    private void TranslateButtonOnClicked(object sender, EventArgs eventArgs)
	    {
            string translatedText = PhonewordTranslator.ToNumber(userEntry.Text);
	        bool success = !string.IsNullOrEmpty(translatedText);
	        callButton.IsEnabled = success;
            if (success)
	        {
	            userEntry.Text = translatedText;
	            callButton.Text = "Call " + translatedText;
	        }
            else callButton.Text = "Call";
	    }
	}
}
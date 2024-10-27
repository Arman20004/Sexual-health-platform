using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sexual_health_platform
{
    public partial class GenderSurveyPage : ContentPage
    {
        public GenderSurveyPage()
        {
            InitializeComponent();
        }

        private void GenderPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable the "Next" button only when a gender is selected.
            NextButton.IsEnabled = GenderPicker.SelectedIndex != -1;
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgeSelectionPage());
        }
    }

}

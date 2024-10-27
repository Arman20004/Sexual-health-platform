using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sexual_health_platform
{
    public partial class AgeSelectionPage : ContentPage
    {
        public AgeSelectionPage()
        {
            InitializeComponent();
            BirthdatePicker.Date = DateTime.Today.AddYears(-7); // Default to minimum age of 13
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime selectedDate = e.NewDate;
            DateTime minAgeDate = DateTime.Today.AddYears(-7); // Set minimum age of 13

            if (selectedDate <= DateTime.Today && selectedDate <= minAgeDate)
            {
                SubmitButton.IsEnabled = true;
            }
            else
            {
                SubmitButton.IsEnabled = false;
                DisplayAlert("Invalid Date", "You must be at least 7 years old.", "OK");
            }
        }

        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            var birthDate = BirthdatePicker.Date;
            await DisplayAlert("Thank You", $"Your birthdate is: {birthDate.ToShortDateString()}", "OK");
            // Here you can proceed with further actions, such as saving data.
        }
    }

}

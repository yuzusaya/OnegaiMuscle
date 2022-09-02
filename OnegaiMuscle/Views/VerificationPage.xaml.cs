namespace OnegaiMuscle;

public partial class VerificationPage : ContentPage
{
	public VerificationPage()
	{
		InitializeComponent();
	}
    private void Entry_Focused(object sender, FocusEventArgs e)
    {
        box1.BorderColor = Color.FromHex("#232323");
        entry1.Text = "";
    }

    private void Entry_Focused_1(object sender, FocusEventArgs e)
    {
        box2.BorderColor = Color.FromHex("#232323");
        entry2.Text = "";
    }

    private void Entry_Focused_2(object sender, FocusEventArgs e)
    {
        box3.BorderColor = Color.FromHex("#232323");
        entry3.Text = "";
    }

    private void Entry_Focused_3(object sender, FocusEventArgs e)
    {
        box4.BorderColor = Color.FromHex("#232323");
        entry4.Text = "";
    }

    private void box1_Unfocused(object sender, FocusEventArgs e)
    {
        box1.BorderColor = Color.FromHex("#F5F5F5");
        box2.BorderColor = Color.FromHex("#F5F5F5");
        box3.BorderColor = Color.FromHex("#F5F5F5");
        box4.BorderColor = Color.FromHex("#F5F5F5");
    }

    private void InputView1_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length > 0)
        {
            entry2.Focus();
        }
    }
    private void InputView2_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length > 0)
        {
            entry3.Focus();
        }
    }
    private void InputView3_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length > 0)
        {
            entry4.Focus();
        }
    }
    private async void InputView4_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length > 0)
        {
            if (entry1.Text + entry2.Text + entry3.Text + entry4.Text == "6996")
            {
                entry4.Unfocus();
                await Shell.Current.GoToAsync($"//{nameof(BookingPage)}");
                Preferences.Set("LoginSuccess",true);
            }
            else
            {
                await DisplayAlert("Warning", "Your phone will be hacked soon", "Sorry");
                entry1.Focus();
            }
        }
    }
}
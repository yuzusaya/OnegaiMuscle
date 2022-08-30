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
    }

    private void Entry_Focused_1(object sender, FocusEventArgs e)
    {
        box2.BorderColor = Color.FromHex("#232323");
    }

    private void Entry_Focused_2(object sender, FocusEventArgs e)
    {
        box3.BorderColor = Color.FromHex("#232323");
    }

    private void Entry_Focused_3(object sender, FocusEventArgs e)
    {
        box4.BorderColor = Color.FromHex("#232323");
    }

    private void box1_Unfocused(object sender, FocusEventArgs e)
    {
        box1.BorderColor = Color.FromHex("#F5F5F5");
        box2.BorderColor = Color.FromHex("#F5F5F5");
        box3.BorderColor = Color.FromHex("#F5F5F5");
        box4.BorderColor = Color.FromHex("#F5F5F5");
    }
}
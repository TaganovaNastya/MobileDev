namespace _Maui1
{
    public partial class MainPage : ContentPage
    {
        Random rnd = new();

        public MainPage()
        {
            InitializeComponent();

            slider_R.ValueChanged += Slaider_All_ValueChanged;
            slider_G.ValueChanged += Slaider_All_ValueChanged;
            slider_B.ValueChanged += Slaider_All_ValueChanged;

            buRandonColor.Clicked += BuRandonColor_Clicked;

        }

        private void BuRandonColor_Clicked(object sender, EventArgs e)
        {
            slider_R.Value = rnd.Next(256);
            slider_G.Value = rnd.Next(256);
            slider_B.Value = rnd.Next(256);
        }

        private void Slaider_All_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            boxview_color.Color = Color.FromRgb((byte)slider_R.Value, (byte)slider_G.Value, (byte)slider_B.Value);
        }
    }
}
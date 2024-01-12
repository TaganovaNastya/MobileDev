namespace mauiCalculator
{
    public partial class MainPage : ContentPage
    {

        Calc calc = new();
        public MainPage()
        {
            InitializeComponent();

            calc.Changed += (s, e) => laDisplay.Text = calc.CurText;

            buCE.Clicked += (s, e) => calc.Clear();

            buNum0.Clicked += (s, e) => calc.PressNum(0);
            buNum1.Clicked += (s, e) => calc.PressNum(1);
            buNum2.Clicked += (s, e) => calc.PressNum(2);
            buNum3.Clicked += (s, e) => calc.PressNum(3);
            buNum4.Clicked += (s, e) => calc.PressNum(4);
            buNum5.Clicked += (s, e) => calc.PressNum(5);
            buNum6.Clicked += (s, e) => calc.PressNum(6);
            buNum7.Clicked += (s, e) => calc.PressNum(7);
            buNum8.Clicked += (s, e) => calc.PressNum(8);
            buNum9.Clicked += (s, e) => calc.PressNum(9);

            buDiv.Clicked += (s, e) => calc.PressOperator("div");
            buMul.Clicked += (s, e) => calc.PressOperator("mul");
            buSum.Clicked += (s, e) => calc.PressOperator("sum");
            buSub.Clicked += (s, e) => calc.PressOperator("sub");
            buSqrt.Clicked += (s, e) => calc.PressOperator("sqrt");
            buPow.Clicked += (s, e) => calc.PressOperator("pow");
            buPercent.Clicked += (s, e) => calc.PressOperator("percent");
            buReciprocal.Clicked += (s, e) => calc.PressOperator("reciprocal");
            buDecimal.Clicked += (s, e) => calc.PressDecimal();
            buChangeSign.Clicked += (s, e) => calc.ChangeSign();
            buEqual.Clicked += (s, e) => calc.PerformOperation();


            //buNum0.Clicked += (s, e) => calc.Press1();
        }

        
    }
}
using System.Globalization;

namespace mauiCalculator
{
    internal class Calc
    {
        private List<double> numbers;
        public string CurText { get; private set; }
        public string CurOper { get; private set; }

        public event EventHandler Changed;

        public Calc()
        {
            numbers = new List<double>();
        }

        internal void Clear()
        {
            CurText = null;
            numbers.Clear();
            Changed?.Invoke(this, EventArgs.Empty);
        }

        internal void PressNum(int v)
        {
            if (CurText == null)
            {
                CurText = v < 0 ? "-" : v.ToString();
            }
            else
            {
                CurText += v.ToString();
            }

            Changed?.Invoke(this, EventArgs.Empty);
        }

        internal void PressDecimal()
        {
            if (CurText == null || !CurText.Contains("."))
            {
                CurText += ".";
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        internal void PressOperator(string oper)
        {
            if (!string.IsNullOrEmpty(CurText))
            {
                double currentNumber;
                if (double.TryParse(CurText, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out currentNumber))
                {
                    numbers.Add(currentNumber);
                    CurText = null;
                    CurOper = oper;
                    Changed?.Invoke(this, EventArgs.Empty);
                }
                else if (CurText == "-")
                {
  
                    numbers.Add(0);
                    CurText = null;
                    CurOper = oper;
                    Changed?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    CurText = "Error";  // Обработка ошибки ввода числа
                }
            }
        }

        internal void ChangeSign()
        {
            if (!string.IsNullOrEmpty(CurText) && CurText != "0")
            {
                CurText = (double.Parse(CurText) * -1).ToString();
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        internal void PerformOperation()
        {
            if (CurOper != null)
            {
                if (!string.IsNullOrEmpty(CurText))
                {
                    double currentNumber;
                    if (double.TryParse(CurText, out currentNumber))
                    {
                        numbers.Add(currentNumber);
                        CurText = null;
                    }
                    else
                    {
                        CurText = "Error";  // Обработка ошибки ввода числа
                        return;
                    }
                }

                switch (CurOper)
                {
                    case "sum":
                        CurText = numbers.Sum().ToString();
                        break;
                    case "sub":
                        CurText = (numbers.First() - numbers.Skip(1).Sum()).ToString();
                        break;
                    case "mul":
                        CurText = numbers.Aggregate((x, y) => x * y).ToString();
                        break;
                    case "div":
                        double result = numbers.First();
                        if (numbers.Skip(1).All(x => x != 0))
                            CurText = (numbers.First() / numbers.Skip(1).Aggregate((x, y) => x * y)).ToString();
                        else
                            CurText = "Error";  // Обработка деления на ноль
                        break;
                    case "sqrt":
                        CurText = Math.Sqrt(numbers.First()).ToString();
                        break;
                    case "pow":
                        CurText = Math.Pow(numbers.First(), 2).ToString();
                        break;
                    case "percent":
                        CurText = (numbers.First() * numbers.Last() / 100).ToString();
                        break;
                    case "reciprocal":
                        if (numbers.First() != 0)
                            CurText = (1 / numbers.First()).ToString();
                        else
                            CurText = "Error";  // Обработка деления на ноль
                        break;
                    default:
                        CurText = "Error";  // Обработка неизвестной операции
                        break;
                }

                numbers.Clear();
                CurOper = null;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
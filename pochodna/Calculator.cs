namespace Derivative
{
    public class Calculator
    {
        public static string calc(string ex)
        {
            string before = "1";
            string[] frac;
            int power;
            int newPower;
            if (ex == "x") // derivative of x is always 1
                return "1";

            if (ex.Contains("x"))
            {
                if (ex.Split("x")[0] != "") // get y amount of x
                    before = ex.Split("x")[0];

                if (ex.Contains("^")) // derivative of x to the power of y equals: amount of x * power of x to the power of x - 1
                {
                    power = int.Parse(ex.Split("^")[1]);
                    newPower = power - 1;

                    if (before.Contains("/")) // if amount of x is a fraction
                    {
                        frac = before.Split("/");
                        if (frac[1] == "0")
                            return "Error division by 0";
                        before = $"{int.Parse(frac[0]) * power}/{frac[1]}";
                    }
                    else
                        before = $"{int.Parse(before) * power}";

                    if (newPower == 1)
                        return $"{before}x";

                    return $"{before}x^{newPower}";
                }
                return $"{before}"; // derivative of y amount of x equals y
            }
            return "0"; // derivative of any number is always 0
        }

        public static void loadDerivative(string eq)
        {
            List<string> result = new();
            List<int> opIndex = new() { 0 };
            for(int i = 0; i < eq.Length; i++)
            {
                if (eq[i] == '-' || eq[i] == '+' || i + 1 == eq.Length) // get single expressions of equation
                { 
                    int startEx = opIndex.Last();
                    startEx = startEx == 0 ? 0 : startEx + 1;
                    opIndex.Add(i);
                    string ex = eq.Substring(startEx, i - startEx);
                    if(i + 1 == eq.Length)
                        ex = eq.Substring(startEx, i + 1 - startEx);
                    result.Add(calc(ex));
                    if (i + 1 != eq.Length) // add + or -
                        result.Add(eq[i].ToString());
                }
            }
            foreach (var item in result)
                Console.Write(item);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Fractions are only acceptable before x with power or as individual");
            Console.WriteLine("Only powers of x are acceptable, the rest you have to do on your own :)");
            Console.WriteLine("Example input: 5x^3+5/6x^2-3x+x+2");
            loadDerivative(Console.ReadLine());
        }
    }
}
namespace FactorialAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5).ToString()); //обычный синхронный вызов
            Thread thread = new Thread(new ParameterizedThreadStart(FactorialAsync));  //поточный метод подсчёта факториала числа
            thread.Start(5);  //поточный метод подсчёта факториала числа

            Thread threadStep = new Thread(new ParameterizedThreadStart(StepenAsync));  //поточный метод возведения числа в степень
            threadStep.Start(new MyPow(5,3)); //поточный метод возведения числа в степень

        }
        static void FactorialAsync(object obj) //поточный метод подсчёта факториала числа
        {
            obj = Factorial((int)obj);
            Console.WriteLine(((int)obj).ToString());
        }

        static void StepenAsync(object obj) //поточный метод возведения числа в степень
        {
            MyPow pow = (MyPow)obj;
            Console.WriteLine(pow.GetRes().ToString());

        }
        static int Factorial(int n) 
        {
            int res = 1;
            for (int i = n; i > 0; i--)
            {
                res *= i;
            }
            return res;
        }
    }
    class MyPow
    {
        int _number;
        int _stepen;

        public MyPow(int number, int stepen) //моя степень при генерации
        {
            _number = number;
            _stepen = stepen;
        }

        public int GetRes()
        {
            int result= 1;
            for (int i = 0; i < _stepen; i++)
            {
                result *= _number;
            }
            return result;
        }
    }
}
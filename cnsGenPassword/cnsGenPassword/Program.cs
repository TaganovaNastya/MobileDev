namespace cnsGenPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> passwords = GeneratePasswords(4, 7, true, true, true, true, "");
            foreach (var password in passwords)
            {
                Console.WriteLine(password);
            }

            Console.WriteLine();

            List<string> passwords1 = GeneratePasswords(5, 8, true, false, false, false);
            foreach (var password in passwords1)
            {
                Console.WriteLine(password);
            }

            Console.WriteLine();

            List<string> passwords3 = GeneratePasswords(4, 12,true, true, false, false,  "@#");
            foreach (var password in passwords3)
            {
                Console.WriteLine(password);
            }

        }


        private static List<string> GeneratePasswords(int count, int length, bool useDigits = true, bool useLowercaseLetters = true, bool useUppercaseLetters = true, bool useSpecialCharacters = true, string customCharacters = "")
        {
            if (count <= 0)
            {
                Console.WriteLine("Количество паролей должно быть больше нуля");
                return new List<string>();
            }
            if (length < 6)
            {
                Console.WriteLine("Длина пароля должна быть не менее 6 символов");
                return new List<string>();
            }
            if (!useDigits && !useLowercaseLetters && !useUppercaseLetters && !useSpecialCharacters && string.IsNullOrEmpty(customCharacters))
            {
                Console.WriteLine("По крайней мере, один тип символов должен быть включен");
                return new List<string>();
            }


            string strPass = "";

            if (useDigits)
                strPass += "0123456789";
            if (useLowercaseLetters)
                strPass += "abcdefghijklmnopqrstuvwxyz";
            if (useUppercaseLetters)
                strPass += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (useSpecialCharacters)
                strPass += "!@#$%^&*()_+-=[]{}|;:'\"<>,.?/\\";
            strPass += customCharacters;

            List<string> passwords = new List<string>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                char[] password = new char[length];
                for (int j = 0; j < length; j++)
                {
                    password[j] = strPass[random.Next(0, strPass.Length)];
                }
                passwords.Add(new string(password));
            }

            return passwords;
        }
    }
}
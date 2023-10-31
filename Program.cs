using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

public class String_1
{
    public string line;

    public String_1(string lineinput)
    {
        this.line = lineinput;
    }
    public int CountDigits()
    {
        return line.Count(char.IsDigit);
    }
    public void only1Element()
    {
        List<char> chars = new List<char>();
        List<char> chars1 = new List<char>();
        foreach (char c in line)
        {
            if (!chars.Contains(c))
            {
                chars.Add(c);
            }
        }
        foreach (char c in chars)
        {
            int count = 0;
            foreach (char c2 in line)
            {
                if (c2 == c) count++;
            }
            if (count == 1) chars1.Add(c);
        }
        foreach (char c in chars1)
        {
            Console.Write(c + " ");
        }
        Console.WriteLine();
    }
    public void longestlength()
    {
        char currentChar = line[0];
        int currentLength = 1;
        char longestChar = currentChar;
        int longestLength = 1;
        for (int i = 1; i < line.Length; i++)
        {
            if (line[i] == currentChar) currentLength++;
            else
            {
                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                    longestChar = currentChar;
                }
                currentChar = line[i];
                currentLength = 1;
            }
        }
        if (currentLength > longestLength)
        {
            longestChar = currentChar;
            longestLength = currentLength;
        }
        for (int i = 0; i < longestLength; i++)
        {
            Console.Write(longestChar);
        }
        Console.WriteLine();
    }
    public int totalsymbols()
    {
        return line.Length;
    }

    public char this[int index]
    {
        get { return line[index]; }
    }
    public static bool operator !(String_1 str)
    {
        return string.IsNullOrEmpty(str.line);
    }
    public static bool operator &(String_1 str1, String_1 str2)
    {
        if (str1.line.Length != str2.line.Length)
        {
            return false;
        }

        for (int i = 0; i < str1.line.Length; i++)
        {
            if (char.ToLower(str1.line[i]) != char.ToLower(str2.line[i]))
            {
                return false;
            }
        }
        return true;
    }

    public static string toString(String_1 str)
    {
        return str.line;
    }
    public static String_1 toString_1(string str)
    {
        return new String_1(str);
    }

    public static bool palindrome(String_1 str)
    {
        string text = String_1.toString(str);
        char[] obrtext = text.ToCharArray();
        Array.Reverse(obrtext);
        string finaltext = new string(obrtext);
        if (text == finaltext) return true; else return false;

    }

}
class program
{
    static void Main()
    {
        Console.WriteLine("Введите произвольную строку");
        String_1 str = new String_1(Console.ReadLine());

        Console.WriteLine("Количестсво цифр в строке: {0}", str.CountDigits());

        Console.Write("Количесвто элементов повторяющихся в строке только один раз: ");
        str.only1Element();

        Console.WriteLine("Самая длинная последовательность повторяющихся символов: ");
        str.longestlength();

        Console.WriteLine("Число символов в строке: {0}", str.totalsymbols());

        Console.WriteLine("Какой символ по индексу вы хотите найти?");
        int ind = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Элемент с индексом {0} является {1}", ind, str[ind]);

        Console.WriteLine("Строка является пустой - {0}", !str);

        Console.WriteLine("Введите произвольную строку2");
        String_1 str2 = new String_1(Console.ReadLine());
        Console.WriteLine("Строки равны без учета регистра - {0}", str & str2);
        string str_1 = String_1.toString(str);
        String_1 STR = new String_1(str_1);
        Console.WriteLine("Преобразование класса в тип string - {0}", str_1);
        Console.WriteLine("Преобразование типа string в класс-строку - {0}", STR.line);

        Console.WriteLine("Строка является палиндромом - {0}", String_1.palindrome(str));
    }
}
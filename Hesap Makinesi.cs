using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool uygulamayiKapat = false;
            Console.WriteLine("================================");
            Console.WriteLine("   C# Konsol Hesap Makinesi   ");
            Console.WriteLine("================================\n");

            while (!uygulamayiKapat)
            {
                string numInput1 = "";
                string numInput2 = "";
                double sonuc = 0;

               
                Console.Write("Birinci sayıyı girin: ");
                numInput1 = Console.ReadLine();
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Geçersiz giriş! Lütfen sayısal bir değer girin: ");
                    numInput1 = Console.ReadLine();
                }

                
                Console.Write("İkinci sayıyı girin: ");
                numInput2 = Console.ReadLine();
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Geçersiz giriş! Lütfen sayısal bir değer girin: ");
                    numInput2 = Console.ReadLine();
                }

                
                Console.WriteLine("\nListeden bir işlem seçin:");
                Console.WriteLine("\t+ - Toplama");
                Console.WriteLine("\t- - Çıkarma");
                Console.WriteLine("\t* - Çarpma");
                Console.WriteLine("\t/ - Bölme");
                Console.Write("Seçiminiz? ");

                string islem = Console.ReadLine();

                try
                {
                    
                    sonuc = Calculator.IslemYap(cleanNum1, cleanNum2, islem);
                    if (double.IsNaN(sonuc))
                    {
                        Console.WriteLine("Bu işlem matematiksel olarak hatalı.\n");
                    }
                    else
                    {
                        Console.WriteLine($"\n--> Sonuç: {cleanNum1} {islem} {cleanNum2} = {sonuc:0.##}\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nHesaplama sırasında beklenmeyen bir hata oluştu.\n - Hata detayı: " + e.Message);
                }

                Console.WriteLine("--------------------------------");
                Console.Write("Uygulamayı kapatmak için 'n' tuşuna, yeni işlem yapmak için herhangi bir tuşa basın: ");

                if (Console.ReadLine()?.ToLower() == "n")
                {
                    uygulamayiKapat = true;
                }

                Console.Clear(); 
            }
        }
    }

    
    class Calculator
    {
        public static double IslemYap(double num1, double num2, string islem)
        {
            double sonuc = double.NaN;

            switch (islem)
            {
                case "+":
                    sonuc = num1 + num2;
                    break;
                case "-":
                    sonuc = num1 - num2;
                    break;
                case "*":
                    sonuc = num1 * num2;
                    break;
                case "/":
                   
                    if (num2 != 0)
                    {
                        sonuc = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Hata: Bir sayı sıfıra bölünemez!");
                    }
                    break;
                default:
                    Console.WriteLine("Hata: Geçersiz bir işlem türü seçtiniz.");
                    break;
            }
            return sonuc;
        }
    }
}

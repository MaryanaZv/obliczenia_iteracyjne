using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2_Zvarych54558
{
    class Program
    {
        static bool mzRealizacjaZeŚledzeniem;
        static void Main(string[] args)
        {
            ConsoleKeyInfo mzWybranaFunkcjonalność;

            Console.WriteLine("\n\n\t\tProgram 'ObliczeniaIteracyjne_54558' umożliwia " +
                    "wielokrotne \n\t\tobliczanie wartości z analizy szeregu potęgowego");
            Console.WriteLine("\n\n\tDzisiaj jest {0}.{1}.{2}, godzina {3, 0:t}", 
                    DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now);
            Console.WriteLine("\n\tNaciśnij dowolny klawisz żeby zacząć: ");
            Console.ReadKey();

            do
            {
                Console.Clear();

                Console.WriteLine("\n\n\tMENU funkcjonalne programu: ");

                Console.WriteLine("\n\tA. Obliczenie wartości (sumy) zadanego szeregu potęgowego");
                Console.WriteLine("\n\tB. Tablicowanie wartości zadanego szeregu potęgowego");
                Console.WriteLine("\n\tC. Tablicowanie wartości pierwiastka kwadratowego, " + 
                        "obliczanego \n\tmetodą Herona, z wartości zadanego szeregu potęgowego");
                Console.WriteLine("\n\tD. Tablicowanie wartości n-tego pierwiastka, " + 
                        "obliczanego \n\tmetodą Newtona, z wartości zadanego szeregu potęgowego");
                Console.WriteLine("\n\tE. Obliczanie odwrotności pierwiastka z liczby a metodą stycznych Newtona");

                Console.WriteLine("\n\tX. Zakończenie (wyjście z) programu");

                Console.WriteLine("\n\tNaciśnięciem odpowiedniego klawisza wybierz " +
                        "jedną z funkcjonalności");

                mzWybranaFunkcjonalność = Console.ReadKey();

                if (mzWybranaFunkcjonalność.Key == ConsoleKey.A)
                {
                    Console.WriteLine("\n\n\tCzy obliczenie ma być realizowane ze śledzeniem, czy bez " +
                        "(naciśnij klawisz T lub t jeżeli \n\tze śledzeniem, a dowolny inny klawisz " +
                        "(np. spację), gdy bez śledzenia): ");

                        if (Console.ReadKey().Key == ConsoleKey.T)
                            mzRealizacjaZeŚledzeniem = true;
                }

                switch (mzWybranaFunkcjonalność.Key)
                {
                    case ConsoleKey.A:

                        Console.WriteLine("\n\n\tWYBRANO: A. Obliczenie wartości (sumy) zadanego " +
                                "szeregu potęgowego");

                        float mzX, mzEps, mzSumaSzeregu;
                        ushort mzLicznikZsumowanychWyrazówSzeregu;

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj wartość zmiennej niezależnej X: ", out mzX);

                            if ((mzX <= -6.0F) || (mzX >= -2.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla X wykracza poza " +
                                    "przedział zbieżności szeregu!");

                        } while ((mzX <= -6.0F) || (mzX >= -2.0F));

                        if (mzRealizacjaZeŚledzeniem == true)
                        {
                            Console.WriteLine("\n\t\tTRACE: Wczytana wartość X wynosi: {0}", mzX);
                        }

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj dokładność obliczeń Eps: ", out mzEps);

                            if ((mzEps <= 0.0F) || (mzEps >= 1.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla Eps wykracza poza " +
                                    "przedział: (0; 1) !");

                            else if (mzRealizacjaZeŚledzeniem == true)
                            {
                                Console.WriteLine("\n\t\tTRACE: Wczytana wartość Eps wynosi: {0}", mzEps);
                                Console.WriteLine("\n\tNaciśnij dowolny klawisz żeby przejść do obliczenia sumy szeregu...");
                                Console.ReadKey();
                            }

                        } while ((mzEps <= 0.0F) || (mzEps >= 1.0F));

                        float mzW, mzS;
                        ushort mzN;

                        mzS = 0.0F;
                        mzN = 1;
                        mzW= 0.5F * (mzX + 4.0F);

                        do
                        {
                          mzS = mzS + mzW;
                          mzN++;
                          mzW = mzW* ((mzN * mzX + 4 * mzN) / (2 * mzN - 2));

                            if (mzRealizacjaZeŚledzeniem == true)
                            {
                                Console.WriteLine("\n\n\t\tTRACE: Obliczona suma n = {0} wyrazów szeregu wynosi: {1} " +
                                    "\n\t\tTRACE: Obliczowa wartość {2}-go wyrazu szeregu wynosi: {3} ", mzN, mzS, mzN, mzW);
                            }

                        } while (Math.Abs(mzW) > mzEps);
 
                        mzLicznikZsumowanychWyrazówSzeregu = mzN;
                        mzSumaSzeregu =mzS;

                        Console.WriteLine("\n\n\tWYNIKI: \n\n\tSuma szeregu = {0,8:F3} \n\n\tZsumowano n = {1} wyrazów " +
                            "szeregu potęgowego", mzSumaSzeregu, mzLicznikZsumowanychWyrazówSzeregu);

                        Console.ReadKey();

                        break;

                    case ConsoleKey.B:

                        Console.WriteLine("\n\n\tWYBRANO: B. Tablicowanie wartości zadanego szeregu potęgowego");

                        float mzXd, mzXg, mzH;

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj dolny przedział Xd: ", out mzXd);

                            if ((mzXd <= -6.0F) || (mzXd >= -2.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla Xd wykracza poza " +
                                    "przedział zbieżności szeregu!");
                        } while ((mzXd <= -6.0F) || (mzXd >= -2.0F));


                        do { 
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj górny przedział Xg: ", out mzXg);

                            if ((mzXg <= -6.0F) || (mzXg >= -2.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla mzXg wykracza poza " +
                                    "przedział zbieżności szeregu!");
                            else if (mzXg < mzXd)
                                Console.WriteLine("\n\tERROR: podana wartość dla Xg jest mniejsza od Xd");

                        } while ((mzXg <= -6.0F) || (mzXg >= -2.0F));

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj wartość przyrostu h: ", out mzH);

                            if (mzH < 0.0 ||mzH >= (mzXg - mzXd) / 2)
                                Console.WriteLine("\n\tERROR: podana wartość dla h nie spełnia warunek: 0.0 < h <= (Xg-Xd)/2!");

                        } while (mzH < 0.0 ||mzH >= (mzXg - mzXd) / 2);

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj dokładność obliczeń Eps: ", out mzEps);

                            if ((mzEps <= 0.0F) || (mzEps >= 1.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla Eps wykracza poza " +
                                    "przedział: (0; 1) !");

                        } while ((mzEps <= 0.0F) || (mzEps >= 1.0F));

                        Console.WriteLine("\n\n\t\t\t\tTablica wartości szeregu w zadanym przedziale: [Xd, Xg]");
                        Console.WriteLine("\n\tZmienna niezależna X\tSuma S(X) w formacie domyślnym\tLiczba zsumowanych wyrazów"+
                            "\tS(X) f-t wykładniczy     S(X) f-t stałopozycyjny\tS(X) f-t zwięzły");
                        Console.WriteLine("\n\t--------------------\t------------------------------\t--------------------------"+
                            "\t--------------------     -----------------------\t----------------");

                        for ( mzX = mzXd; mzX <= mzXg; mzX = mzX + mzH) {

                            mzSumaSzeregu = mzSumaSzereguPotęgowego(mzX, mzEps, out mzLicznikZsumowanychWyrazówSzeregu);

                            Console.WriteLine("\n\n\t\t{0, 6:F2}\t\t\t  {1, 8:F3}\t\t\t  {2}\t\t\t    {3, 8:E2}\t\t {4, 8:F2}\t\t  {5, 8:G2}",
                                                  mzX, mzSumaSzeregu, mzLicznikZsumowanychWyrazówSzeregu, mzSumaSzeregu, mzSumaSzeregu, mzSumaSzeregu);
                        }

                        Console.ReadKey();

                        break;

                    case ConsoleKey.C:

                        Console.WriteLine("\n\n\tWYBRANO: C. Tablicowanie wartości pierwiastka kwadratowego, " +
                        "obliczanego \n\tmetodą Herona, z wartości zadanego szeregu potęgowego");

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj dolny przedział Xd: ", out mzXd);

                            if ((mzXd <= -6.0F) || (mzXd >= -2.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla Xd wykracza poza " +
                                    "przedział zbieżności szeregu!");
                        } while ((mzXd <= -6.0F) || (mzXd >= -2.0F));

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj górny przedział Xg: ", out mzXg);

                            if ((mzXg <= -6.0F) || (mzXg >= -2.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla Xg wykracza poza " +
                                    "przedział zbieżności szeregu!");
                            else if (mzXg < mzXd)
                                Console.WriteLine("\n\tERROR: podana wartość dla Xg jest mniejsza od Xd");

                        } while ((mzXg <= -6.0F) || (mzXg >= -2.0F));

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj wartość przyrostu h: ", out mzH);

                            if (mzH < 0.0 ||mzH >= (mzXg - mzXd) / 2)
                                Console.WriteLine("\n\tERROR: podana wartość dla h nie spełnia warunek: 0.0 < h <= (Xg-Xd)/2!");

                        } while (mzH < 0.0 || mzH >= (mzXg - mzXd) / 2);

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj dokładność obliczeń Eps: ", out mzEps);

                            if ((mzEps <= 0.0F) || (mzEps >= 1.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla Eps wykracza poza " +
                                    "przedział: (0; 1) !");

                        } while ((mzEps <= 0.0F) || (mzEps >= 1.0F));

                        Console.WriteLine("\n\n\t\t\tTablica zmian wartości szeregu potęgowego");
                        Console.WriteLine("\n\tZmienna niezależna X\tSuma szeregu S(X)\tLiczba zsumowanych wyrazów" + 
                            "\tPierwiastek kwadratowy\t      Licznik iteracji");
                        Console.WriteLine("\n\t--------------------\t-----------------\t--------------------------" + 
                            "\t----------------------\t      ----------------");

                        short mzI;

                        short mzLicznikIteracji;

                        for (mzI = 0, mzX = mzXd; mzX <= mzXg; mzI++, mzX = mzXd + mzI * mzH)
                        {
                            mzSumaSzeregu = mzSumaSzereguPotęgowego(mzX, mzEps, out mzLicznikZsumowanychWyrazówSzeregu);

                            if (mzLicznikZsumowanychWyrazówSzeregu < 0)
                            {
                                Console.WriteLine("\n\tERROR: sumowanie szeregu potęgowego nie " + 
                                    "powiodło się: błąd w parametrach");
                            }
                            else
                            {
                                Console.WriteLine("\n\t   {0, 6:F2}\t\t   {1, 8:F2}\t\t\t  {2}\t\t\t\t" +
                                    "{3, 6:F2}\t\t\t{4}", mzX, mzSumaSzeregu, mzLicznikZsumowanychWyrazówSzeregu, 
                                    mzPierwiastek_Herona(mzSumaSzeregu, mzEps, out mzLicznikIteracji), mzLicznikIteracji);
                            }

                        }

                        Console.ReadKey();
                        
                        break;

                    case ConsoleKey.D:

                        Console.WriteLine("\n\n\tWYBRANO: D. Tablicowanie wartości n-tego pierwiastka, " +
                        "obliczanego \n\tmetodą Newtona, z wartości zadanego szeregu potęgowego");

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj dolny przedział Xd: ", out mzXd);

                            if ((mzXd <= -6.0F) || (mzXd >= -2.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla Xd wykracza poza " +
                                    "przedział zbieżności szeregu!");
                        } while ((mzXd <= -6.0F) || (mzXd >= -2.0F));


                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj górny przedział Xg: ", out mzXg);

                            if ((mzXg <= -6.0F) || (mzXg >= -2.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla Xg wykracza poza " +
                                    "przedział zbieżności szeregu!");
                            else if (mzXg < mzXd)
                                Console.WriteLine("\n\tERROR: podana wartość dla Xg jest mniejsza od Xd");

                        } while ((mzXg <= -6.0F) || (mzXg >= -2.0F));

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj wartość przyrostu h: ", out mzH);

                            if (mzH < 0.0 || mzH >= (mzXg - mzXd) / 2)
                                Console.WriteLine("\n\tERROR: podana wartość dla h nie spełnia warunek: 0.0 < h <= (Xg-Xd)/2!");

                        } while (mzH < 0.0 || mzH >= (mzXg - mzXd) / 2);

                        do
                        {
                            mzWczytanieLiczbyRzeczywistej("\n\tPodaj dokładność obliczeń Eps: ", out mzEps);

                            if ((mzEps <= 0.0F) || (mzEps >= 1.0F))
                                Console.WriteLine("\n\tERROR: podana wartość dla Eps wykracza poza " +
                                    "przedział: (0; 1) !");

                        } while ((mzEps <= 0.0F) || (mzEps >= 1.0F));

                        Console.WriteLine("\n\n\t\t\tTablica wartości n-tego z wartości szeregu potęgowego");
                        Console.WriteLine("\n\tZmienna niezależna X\tSuma szeregu S(X)\tLiczba zsumowanych wyrazów" +
                            "\tN-ty pierwiastek z wartosci szeregu\tLiczba wykonanych iteracji");
                        Console.WriteLine("\n\t--------------------\t-----------------\t--------------------------" +
                            "\t-----------------------------------\t--------------------------");
                     
                        float mzN_tyPierwiastek;

                        for (mzX = mzXd, mzI = 1; mzX <= mzXg; mzX = mzXd + mzI * mzH, mzI++)
                        {
                            mzSumaSzeregu = mzSumaSzereguPotęgowego(mzX, mzEps, out mzLicznikZsumowanychWyrazówSzeregu);

                            mzN_tyPierwiastek = mzN_tyPierwiastekNewtona(mzSumaSzeregu, mzI, mzEps, out mzLicznikIteracji);

                                Console.WriteLine("\n\t   {0, 6:F2}\t\t   {1, 8:F3}\t\t\t  {2}\t\t\t\t" +
                               "{3, 6:F2} (n = {4})\t\t\t     {5}", mzX, mzSumaSzeregu, mzLicznikZsumowanychWyrazówSzeregu,
                               mzN_tyPierwiastek, mzI, mzLicznikIteracji);
                        }

                        Console.ReadKey();
                        break;

                    case ConsoleKey.E:
                        mzPierwiastekOdwrotny();
                                
                        Console.ReadKey();
                        break;

                    case ConsoleKey.X:
                        Console.WriteLine("\n\n\n\tZakończenie działania programu!\n\t");
                        break;

                    default:
                        Console.WriteLine("\n\tERROR: nacisnąłeś niedozwolony klawisz " + 
                                "(znak) - nia ma takiej funkcjonalności w MENU programu");
                        Console.WriteLine("\n\tNaciśnij dowolny klawisz, żeby zacząć ponownie...");
                        Console.ReadKey();
                        break;
                }

            } while (mzWybranaFunkcjonalność.Key != ConsoleKey.X);

            Console.WriteLine("\n\n\tAutor programu: Maryana Zvarych, Nr albumu: 54558");
            Console.WriteLine("\n\tDzisiejsza data: {0}", DateTime.Now.ToString("d-MMM-yy"));
            Console.WriteLine("\n\tAktualna godzina: {0}\tminuta: {1}\tsekunda: {2}\tmillisekunda: {3}",
                    DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes,
                    DateTime.Now.TimeOfDay.Seconds, DateTime.Now.TimeOfDay.Milliseconds);
            Console.WriteLine("\n\tDla zakończenia programu naciśnij dowolny klawisz...");
            Console.ReadKey();
        }

        static void mzWczytanieLiczbyRzeczywistej(string mzZaproszenie, out float mzLiczba)
        {
            Console.Write("\n\t" + mzZaproszenie);
            while (!float.TryParse(Console.ReadLine(), out mzLiczba))
            {
                Console.WriteLine("\n\tERROR: w zapisie podanej liczby wystąpił niedozwolony znak!");
                Console.Write("\n\t" + "Ponownie" + mzZaproszenie);
            }
        }

        static float mzSumaSzereguPotęgowego(float mzX, float mzEps, out ushort mzN)
        {
            float mzW;
            float mzS;

            mzS = 0.0F;
            mzN = 1;
            mzW= 0.5F * (mzX + 4.0F);

            do
            {
               mzS =mzS + mzW;
               mzN++;
               mzW=mzW* ((mzN * mzX + 4 * mzN) / (2 * mzN - 2));

            } while (Math.Abs(mzW) > mzEps);

            return mzS;
        }

        static float mzPierwiastek_Herona(float mzA, float mzEps, out short mzI)
        {
            float mzXi, mzXi_1;

            if ((mzA < 0.0F) || (mzEps <= 0.0F) || (mzEps >= 1.0F))
            {
                mzI = -1;
                return 0.0F;
            }

            mzI = 0;
            mzXi = mzA / 2.0F;

            do
            {
                mzXi_1 = mzXi;

                mzI++;

                mzXi = (mzXi_1 + mzA / mzXi_1) / 2.0F;
            } while (Math.Abs(mzXi - mzXi_1) > mzEps);

            return mzXi;
        }

        static float mzN_tyPierwiastekNewtona(float mzA, short mzN, float mzEps, out short mzI)
        {
            float mzXi, mzXi_1;

            if ((mzA <= 0.0F) || (mzN < 0) || (mzEps <= 0.0F) || (mzEps >= 1.0F))
            {
                mzI = -1;

                return 0.0F;
            }

            mzI = 0;
            mzXi = mzA;

            do
            {
                mzXi_1 = mzXi;

                mzI++;

                mzXi = ((mzN - 1) * mzXi_1 + mzA / ((float)Math.Pow(mzXi_1, mzN - 1))) / mzN;
            } while (Math.Abs(mzXi - mzXi_1) > mzEps);

            return mzXi;
        }

        static void mzPierwiastekOdwrotny()
        {
            float mzA, mzEps, mzN, mzXi, mzXi_1;
            short mzI;

            mzWczytanieLiczbyRzeczywistej("\n\tProszę podać liczbę: ", out mzA);
            mzWczytanieLiczbyRzeczywistej("\n\tProszę podać stopień pierwiastka: ", out mzN);

            do
            {
                mzWczytanieLiczbyRzeczywistej("\n\tPodaj dokładność obliczeń Eps: ", out mzEps);

                if ((mzEps <= 0.0F) || (mzEps >= 1.0F))
                    Console.WriteLine("\n\tERROR: podana wartość dla Eps wykracza poza " +
                        "przedział: (0; 1) !");

            } while ((mzEps <= 0.0F) || (mzEps >= 1.0F));

            if ((mzA <= 0.0F) || (mzN < 0) || (mzEps <= 0.0F) || (mzEps >= 1.0F))
            {
                Console.WriteLine("\n\tERROR: Jest błąd w parametrach!!!");

            }

            mzI = 0;
            mzXi = mzA;

            do
            {
                mzXi_1 = mzXi;

                mzI++;

                mzXi = (float)Math.Pow((((mzN - 1.0F) * mzXi_1 + mzA / ((float)Math.Pow(mzXi_1, mzN - 1))) / mzN), -1);

            } while (Math.Abs(mzXi - mzXi_1) > mzEps);

            Console.WriteLine("\n\tWynnik wynosi: {0, 8:F3}", mzXi);
        }

    }
}

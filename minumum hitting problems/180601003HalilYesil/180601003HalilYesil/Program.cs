using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _180601003HalilYesil
{
    class Program
    {
        static void Main(string[] args)
        {

            //FilePath imi dosyaYolu değişkenime atıyorum
            string dosyaYolu = @"C:\Users\ASUS\Desktop\inp3.txt";


            string[] Satirlar = new string[4];
            Satirlar = File.ReadAllLines(dosyaYolu);

            //Bu ilk satırım Bana Oluşturacağım 1 0 lı matris yapısındaki sutun sayısını verecek.
            string ilkEleman = Satirlar[0];
            string[] Aralik = ilkEleman.Split(' ');


            //  ÇEVİRİCİ
            // Burda Dizimi 1 0 lı yapıya dönüştürüyorum tek boyutlu olacak şekilde.
            double[] DiziDonüstürme;
            DiziDonüstürme = new double[Satirlar.Length - 1];


            for (int i = 1; i < Satirlar.Length; i++)
            {
                string SplitData = Satirlar[i];
                string[] AfterSplit = SplitData.Split(' ');
                string ilkSatirSplitData = Satirlar[0];
                string[] ilkSatirAfterSplit = ilkSatirSplitData.Split(' ');
                double a = 0;
                string satirlar = Satirlar[i];
                for (int k = 0; k < ilkSatirAfterSplit.Length; k++)
                {


                    for (int j = 0; j < AfterSplit.Length; j++)
                    {
                        if (ilkSatirAfterSplit[k] == AfterSplit[j])
                        {
                            double b = (Math.Pow(10, ((ilkSatirAfterSplit.Length) - (k + 1))));
                            a += b;
                            break;

                        }


                    }

                }

                DiziDonüstürme[i - 1] += a;

            }


            //Sayıları 1 ve 0 diye yerleştiriyorum .
            //Eğer Evrensel kümemle satırdaki okuduğum rakam eşleşirse MatrisSayilar arrayimde
            // o satırın aynı sütununa denk gelecek şekilde  1 yerleştirerek dolduruyorum.6
            double[,] MatrisSayilar;
            MatrisSayilar = new double[DiziDonüstürme.Length, Aralik.Length];
            for (int i = 0; i < DiziDonüstürme.Length; i++)
            {
                double gecici = DiziDonüstürme[i];

                for (int j = Aralik.Length - 1; j >= 0; j--)
                {

                    double deger;
                    deger = gecici % 2;
                    MatrisSayilar[i, j] = deger;
                    gecici -= deger;
                    gecici /= 10;


                }

            }

            bool bulunduMu = false;
            //Bir Elemanli Hitting Set

            for (int i = 0; i < Aralik.Length; i++)
            {
                int sayac = 0;
                for (int j = 0; j < DiziDonüstürme.Length; j++)
                {
                    if (MatrisSayilar[j, i] == 1)
                    {
                        sayac += 1;
                        continue;
                    }
                    else
                        break;
                }
                if (sayac == DiziDonüstürme.Length)
                {
                    Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "}");
                    bulunduMu = true;
                    break;
                }


            }
            if (!bulunduMu)
            {
                //2 Elemanli Hitting set
                for (int i = 0; i < Aralik.Length - 1; i++)
                {
                    bool cikis = false;
                    for (int k = i + 1; k < Aralik.Length; k++)
                    {

                        int sayac = 0;
                        for (int j = 0; j < DiziDonüstürme.Length; j++)
                        {
                            //j satır
                            if (MatrisSayilar[j, i] == 1 || MatrisSayilar[j, k] == 1)
                            {
                                sayac += 1;

                            }
                            if (sayac == DiziDonüstürme.Length)
                            {
                                Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "," + Aralik[k] + "}");
                                cikis = true;
                                bulunduMu = true;
                                break;
                            }

                        }
                        if (cikis)
                        {
                            break;
                        }

                    }

                    if (cikis)
                    {
                        break;
                    }
                }


            }
            if (!bulunduMu)
            {
                //3 Elemanli Hitting Set
                for (int i = 0; i < Aralik.Length - 2; i++)
                {
                    bool cikis = false;
                    for (int l = i + 1; l < Aralik.Length - 1; l++)
                    {


                        for (int k = l + 1; k < Aralik.Length; k++)
                        {

                            int sayac = 0;
                            for (int j = 0; j < DiziDonüstürme.Length; j++)
                            {
                                //j satır
                                if (MatrisSayilar[j, i] == 1 || MatrisSayilar[j, k] == 1 || MatrisSayilar[j, l] == 1)
                                {
                                    sayac += 1;

                                }
                                if (sayac == DiziDonüstürme.Length)
                                {
                                    Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "," + Aralik[l] + "," + Aralik[k] + "}");
                                    bulunduMu = true;
                                    cikis = true;
                                    break;
                                }
                                else if (sayac <= j)
                                    break;

                            }
                            if (cikis)
                            {
                                break;
                            }

                        }

                        if (cikis)
                        {
                            break;
                        }
                    }
                    if (cikis)
                    {
                        break;
                    }

                }

            }
            if (!bulunduMu)
            {
                //4 Elemanlı Hitting Set
                for (int i = 0; i < Aralik.Length - 3; i++)
                {
                    bool cikis = false;
                    for (int l = i + 1; l < Aralik.Length - 2; l++)
                    {


                        for (int k = l + 1; k < Aralik.Length - 1; k++)
                        {
                            for (int m = k + 1; m < Aralik.Length; m++)
                            {


                                int sayac = 0;
                                for (int j = 0; j < DiziDonüstürme.Length; j++)
                                {
                                    //j satır
                                    if (MatrisSayilar[j, i] == 1 || MatrisSayilar[j, k] == 1 || MatrisSayilar[j, l] == 1 || MatrisSayilar[j, m] == 1)
                                    {
                                        sayac += 1;

                                    }

                                    if (sayac == DiziDonüstürme.Length)
                                    {
                                        Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "," + Aralik[l] + "," + Aralik[k] + "," + Aralik[m] + "}");
                                        bulunduMu = true;
                                        cikis = true;
                                        break;
                                    }
                                    else if (sayac <= j)
                                        break;

                                }
                                if (cikis)
                                {
                                    break;
                                }
                            }
                            if (cikis)
                            {
                                break;
                            }

                        }

                        if (cikis)
                        {
                            break;
                        }
                    }
                    if (cikis)
                    {
                        break;
                    }

                }

            }
            if (!bulunduMu)
            {
                //5 Elemanlı Hitting Set
                for (int i = 0; i < Aralik.Length - 4; i++)
                {
                    bool cikis = false;
                    for (int l = i + 1; l < Aralik.Length - 3; l++)
                    {


                        for (int k = l + 1; k < Aralik.Length - 2; k++)
                        {
                            for (int m = k + 1; m < Aralik.Length - 1; m++)
                            {
                                for (int n = m + 1; n < Aralik.Length; n++)
                                {

                                    int sayac = 0;
                                    for (int j = 0; j < DiziDonüstürme.Length; j++)
                                    {
                                        //j satır
                                        if (MatrisSayilar[j, i] == 1 || MatrisSayilar[j, k] == 1 || MatrisSayilar[j, l] == 1 || MatrisSayilar[j, m] == 1 || MatrisSayilar[j, n] == 1)
                                        {
                                            sayac += 1;

                                        }

                                        if (sayac == DiziDonüstürme.Length)
                                        {
                                            Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "," + Aralik[l] + "," + Aralik[k] + "," + Aralik[m] + "," + Aralik[n] + "}");
                                            bulunduMu = true;
                                            cikis = true;
                                            break;
                                        }
                                        else if (sayac <= j)
                                            break;

                                    }
                                    if (cikis)
                                    {
                                        break;
                                    }
                                }
                                if (cikis)
                                {
                                    break;
                                }
                            }
                            if (cikis)
                            {
                                break;
                            }

                        }

                        if (cikis)
                        {
                            break;
                        }
                    }
                    if (cikis)
                    {
                        break;
                    }

                }

            }
            if (!bulunduMu)
            {
                //6 Elemanlı Hitting Set
                for (int i = 0; i < Aralik.Length - 5; i++)
                {
                    bool cikis = false;
                    for (int l = i + 1; l < Aralik.Length - 4; l++)
                    {


                        for (int k = l + 1; k < Aralik.Length - 3; k++)
                        {
                            for (int m = k + 1; m < Aralik.Length - 2; m++)
                            {
                                for (int n = m + 1; n < Aralik.Length - 1; n++)
                                {
                                    for (int o = n + 1; o < Aralik.Length; o++)
                                    {


                                        int sayac = 0;
                                        for (int j = 0; j < DiziDonüstürme.Length; j++)
                                        {
                                            //j satır
                                            if (MatrisSayilar[j, i] == 1 || MatrisSayilar[j, k] == 1 || MatrisSayilar[j, l] == 1 || MatrisSayilar[j, m] == 1 || MatrisSayilar[j, n] == 1 || MatrisSayilar[j, o] == 1)
                                            {
                                                sayac += 1;

                                            }

                                            if (sayac == DiziDonüstürme.Length)
                                            {
                                                Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "," + Aralik[l] + "," + Aralik[k] + "," + Aralik[m] + "," + Aralik[n] + "," + Aralik[o] + "}");
                                                bulunduMu = true;
                                                cikis = true;
                                                break;
                                            }
                                            else if (sayac <= j)
                                                break;

                                        }
                                        if (cikis)
                                        {
                                            break;
                                        }
                                    }
                                    if (cikis)
                                    {
                                        break;
                                    }
                                }
                                if (cikis)
                                {
                                    break;
                                }
                            }
                            if (cikis)
                            {
                                break;
                            }

                        }

                        if (cikis)
                        {
                            break;
                        }
                    }
                    if (cikis)
                    {
                        break;
                    }

                }

            }
            if (!bulunduMu)
            {
                //7 Elemanlı Hitting Set
                for (int i = 0; i < Aralik.Length - 6; i++)
                {
                    bool cikis = false;
                    for (int l = i + 1; l < Aralik.Length - 5; l++)
                    {


                        for (int k = l + 1; k < Aralik.Length - 4; k++)
                        {
                            for (int m = k + 1; m < Aralik.Length - 3; m++)
                            {
                                for (int n = m + 1; n < Aralik.Length - 2; n++)
                                {
                                    for (int o = n + 1; o < Aralik.Length - 1; o++)
                                    {
                                        for (int p = o + 1; p < Aralik.Length; p++)
                                        {



                                            int sayac = 0;
                                            for (int j = 0; j < DiziDonüstürme.Length; j++)
                                            {
                                                //j satır
                                                if (MatrisSayilar[j, i] == 1 || MatrisSayilar[j, k] == 1 || MatrisSayilar[j, l] == 1 || MatrisSayilar[j, m] == 1 || MatrisSayilar[j, n] == 1 || MatrisSayilar[j, o] == 1 || MatrisSayilar[j, p] == 1)
                                                {
                                                    sayac += 1;

                                                }

                                                if (sayac == DiziDonüstürme.Length)
                                                {
                                                    Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "," + Aralik[l] + "," + Aralik[k] + "," + Aralik[m] + "," + Aralik[n] + "," + Aralik[o] + "," + Aralik[p] + "}");
                                                    bulunduMu = true;
                                                    cikis = true;
                                                    break;
                                                }
                                                else if (sayac <= j)
                                                    break;

                                            }
                                            if (cikis)
                                            {
                                                break;
                                            }
                                        }
                                        if (cikis)
                                        {
                                            break;
                                        }


                                    }
                                    if (cikis)
                                    {
                                        break;
                                    }
                                }
                                if (cikis)
                                {
                                    break;
                                }
                            }
                            if (cikis)
                            {
                                break;
                            }

                        }

                        if (cikis)
                        {
                            break;
                        }
                    }
                    if (cikis)
                    {
                        break;
                    }

                }

            }
            if (!bulunduMu)
            {
                //8 Elemanlı Hitting Set
                for (int i = 0; i < Aralik.Length - 7; i++)
                {
                    bool cikis = false;
                    for (int l = i + 1; l < Aralik.Length - 6; l++)
                    {


                        for (int k = l + 1; k < Aralik.Length - 5; k++)
                        {
                            for (int m = k + 1; m < Aralik.Length - 4; m++)
                            {
                                for (int n = m + 1; n < Aralik.Length - 3; n++)
                                {
                                    for (int o = n + 1; o < Aralik.Length - 2; o++)
                                    {
                                        for (int p = o + 1; p < Aralik.Length - 1; p++)
                                        {


                                            for (int r = p + 1; r < Aralik.Length; r++)
                                            {


                                                int sayac = 0;
                                                for (int j = 0; j < DiziDonüstürme.Length; j++)
                                                {
                                                    //j satır
                                                    if (MatrisSayilar[j, i] == 1 || MatrisSayilar[j, k] == 1 || MatrisSayilar[j, l] == 1 || MatrisSayilar[j, m] == 1 || MatrisSayilar[j, n] == 1 || MatrisSayilar[j, o] == 1 || MatrisSayilar[j, p] == 1 || MatrisSayilar[j, r] == 1)
                                                    {
                                                        sayac += 1;

                                                    }

                                                    if (sayac == DiziDonüstürme.Length)
                                                    {
                                                        Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "," + Aralik[l] + "," + Aralik[k] + "," + Aralik[m] + "," + Aralik[n] + "," + Aralik[o] + "," + Aralik[p] + "," + Aralik[r] + "}");
                                                        bulunduMu = true;
                                                        cikis = true;
                                                        break;
                                                    }
                                                    else if (sayac <= j)
                                                        break;

                                                }
                                                if (cikis)
                                                {
                                                    break;
                                                }
                                            }
                                            if (cikis)
                                            {
                                                break;
                                            }
                                        }
                                        if (cikis)
                                        {
                                            break;
                                        }


                                    }
                                    if (cikis)
                                    {
                                        break;
                                    }
                                }
                                if (cikis)
                                {
                                    break;
                                }
                            }
                            if (cikis)
                            {
                                break;
                            }

                        }

                        if (cikis)
                        {
                            break;
                        }
                    }
                    if (cikis)
                    {
                        break;
                    }

                }

            }
            if (!bulunduMu)
            {
                //9 Elemanlı Hitting Set
                for (int i = 0; i < Aralik.Length - 8; i++)
                {
                    bool cikis = false;
                    for (int l = i + 1; l < Aralik.Length - 7; l++)
                    {


                        for (int k = l + 1; k < Aralik.Length - 6; k++)
                        {
                            for (int m = k + 1; m < Aralik.Length - 5; m++)
                            {
                                for (int n = m + 1; n < Aralik.Length - 4; n++)
                                {
                                    for (int o = n + 1; o < Aralik.Length - 3; o++)
                                    {
                                        for (int p = o + 1; p < Aralik.Length - 2; p++)
                                        {


                                            for (int r = p + 1; r < Aralik.Length - 1; r++)
                                            {
                                                for (int s = r + 1; s < Aralik.Length; s++)
                                                {



                                                    int sayac = 0;
                                                    for (int j = 0; j < DiziDonüstürme.Length; j++)
                                                    {
                                                        //j satır
                                                        if (MatrisSayilar[j, i] == 1 || MatrisSayilar[j, k] == 1 || MatrisSayilar[j, l] == 1 || MatrisSayilar[j, m] == 1 || MatrisSayilar[j, n] == 1 || MatrisSayilar[j, o] == 1 || MatrisSayilar[j, p] == 1 || MatrisSayilar[j, r] == 1 || MatrisSayilar[j, s] == 1)
                                                        {
                                                            sayac += 1;

                                                        }

                                                        if (sayac == DiziDonüstürme.Length)
                                                        {
                                                            Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "," + Aralik[l] + "," + Aralik[k] + "," + Aralik[m] + "," + Aralik[n] + "," + Aralik[o] + "," + Aralik[p] + "," + Aralik[r] + "," + Aralik[s] + "}");
                                                            bulunduMu = true;
                                                            cikis = true;
                                                            break;
                                                        }
                                                        else if (sayac <= j)
                                                            break;

                                                    }
                                                    if (cikis)
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (cikis)
                                                {
                                                    break;
                                                }
                                            }
                                            if (cikis)
                                            {
                                                break;
                                            }
                                        }
                                        if (cikis)
                                        {
                                            break;
                                        }


                                    }
                                    if (cikis)
                                    {
                                        break;
                                    }
                                }
                                if (cikis)
                                {
                                    break;
                                }
                            }
                            if (cikis)
                            {
                                break;
                            }

                        }

                        if (cikis)
                        {
                            break;
                        }
                    }
                    if (cikis)
                    {
                        break;
                    }

                }

            }
            if (!bulunduMu)
            {
                //10 Elemanlı Hitting Set
                for (int i = 0; i < Aralik.Length - 9; i++)
                {
                    bool cikis = false;
                    for (int l = i + 1; l < Aralik.Length - 8; l++)
                    {


                        for (int k = l + 1; k < Aralik.Length - 7; k++)
                        {
                            for (int m = k + 1; m < Aralik.Length - 6; m++)
                            {
                                for (int n = m + 1; n < Aralik.Length - 5; n++)
                                {
                                    for (int o = n + 1; o < Aralik.Length - 4; o++)
                                    {
                                        for (int p = o + 1; p < Aralik.Length - 3; p++)
                                        {


                                            for (int r = p + 1; r < Aralik.Length - 2; r++)
                                            {
                                                for (int s = r + 1; s < Aralik.Length - 1; s++)
                                                {

                                                    for (int t = s + 1; t < Aralik.Length; t++)
                                                    {



                                                        int sayac = 0;
                                                        for (int j = 0; j < DiziDonüstürme.Length; j++)
                                                        {
                                                            //j satır
                                                            if (MatrisSayilar[j, i] == 1 || MatrisSayilar[j, k] == 1 || MatrisSayilar[j, l] == 1 || MatrisSayilar[j, m] == 1 || MatrisSayilar[j, n] == 1 || MatrisSayilar[j, o] == 1 || MatrisSayilar[j, p] == 1 || MatrisSayilar[j, r] == 1 || MatrisSayilar[j, s] == 1 || MatrisSayilar[j, t] == 1)
                                                            {
                                                                sayac += 1;

                                                            }

                                                            if (sayac == DiziDonüstürme.Length)
                                                            {
                                                                Console.WriteLine("Minumum hitting set = {" + Aralik[i] + "," + Aralik[l] + "," + Aralik[k] + "," + Aralik[m] + "," + Aralik[n] + "," + Aralik[o] + "," + Aralik[p] + "," + Aralik[r] + "," + Aralik[s] + "," + Aralik[t] + "}");
                                                                bulunduMu = true;
                                                                cikis = true;
                                                                break;
                                                            }
                                                            else if (sayac <= j)
                                                                break;

                                                        }
                                                        if (cikis)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    if (cikis)
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (cikis)
                                                {
                                                    break;
                                                }
                                            }
                                            if (cikis)
                                            {
                                                break;
                                            }
                                        }
                                        if (cikis)
                                        {
                                            break;
                                        }


                                    }
                                    if (cikis)
                                    {
                                        break;
                                    }
                                }
                                if (cikis)
                                {
                                    break;
                                }
                            }
                            if (cikis)
                            {
                                break;
                            }

                        }

                        if (cikis)
                        {
                            break;
                        }
                    }
                    if (cikis)
                    {
                        break;
                    }

                }

            }


            Console.ReadLine();



        }


    }
}



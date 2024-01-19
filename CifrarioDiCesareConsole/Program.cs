using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifrarioDiCesareConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Alfabeto_Latino = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string FrequenzaAlfabetoIT1 = "e";
            string FrequenzaAlfabetoIT2 = "a";
            string FrequenzaAlfabetoIT3 = "i";

            Console.WriteLine("Fase crittografica");
            Console.WriteLine();

            //mette tutto in minuscolo
            //string MessaggioInChiaro = "Miao oppure miao? nessuno sa dirlo con certezza. è proprio una disdetta fatta e finita";
            string MessaggioInChiaro = "C'era una volta un gruppo di amici appassionati di ping pong che avevano un'energia senza fine e una passione sfrenata per il gioco. Vivevano in una piccola città dove, ogni giorno, si ritrovavano in una vecchia sala giochi per giocare a ping pong dal mattino fino alla sera.\r\n\r\nL'avventura di questa intensa amicizia e competizione iniziò quando Marco, un giovane entusiasta del ping pong, decise di aprire una piccola sala giochi nel cuore della città. Rapidamente, il suo amico Luca, appassionato anch'esso, si unì all'avventura, seguito da Sara e Matteo.\r\n\r\nDa quel giorno, la sala giochi divenne il luogo di ritrovo per questa eccezionale squadra di giocatori. I quattro amici passavano intere giornate a sfidarsi a colpi di pagaie e palline veloci. La loro competizione era sempre accesa, ma la risata e il divertimento erano sempre presenti.\r\n\r\nLe partite di ping pong diventarono un'epica saga quotidiana, con colpi incredibili, scambi rapidi e salti acrobatici per raggiungere la palla. La sala giochi vibrava di energia e risate mentre i quattro amici si sfidavano senza sosta.\r\n\r\nLa passione per il ping pong crebbe sempre di più, e la fama di questa squadra di giocatori matti si diffuse nella città. Alcuni curiosi si unirono al gruppo, cercando di tenere il passo con l'energia e la velocità di gioco dei quattro amici. La sala giochi divenne un luogo di incontro per gli amanti del ping pong di tutta la città.\r\n\r\nIl tempo volava mentre i quattro amici giocavano, ridevano e facevano nuove amicizie. Anche quando il sole tramontava e la sala giochi chiudeva, la loro passione per il ping pong continuava. Organizzavano tornei notturni improvvisati nelle strade illuminate dalla luna, portando il loro gioco ovunque andassero.\r\n\r\nQuesta storia di amicizia e passione per il ping pong dimostra che, a volte, il vero spirito del gioco va oltre la competizione. I quattro amici, con il loro amore per il ping pong, creavano legami indelebili e portavano la gioia e la spensieratezza in ogni partita. E così, il suono dei colpi di pagaia e le risate degli amici si diffusero attraverso la città, creando una storia leggendaria di amicizia e pazzi tornei di ping pong.";
            MessaggioInChiaro = RimuoviAccenti(MessaggioInChiaro.ToLower());
            Console.WriteLine("La frase da cifrare è: " + MessaggioInChiaro);

            //mette tutto in minuscolo
            string Chiave = "d";
            Chiave = Chiave.ToLower();
            Console.WriteLine($"La chiave è: {Chiave}");

            int ChiaveNum = Array.IndexOf(Alfabeto_Latino, Chiave);
            string MessaggioCifrato=null;
            foreach (char c in MessaggioInChiaro)
            {
                string lettera = c.ToString();

                if(Array.IndexOf(Alfabeto_Latino, lettera) != -1)
                {
                    if (Array.IndexOf(Alfabeto_Latino, lettera) + ChiaveNum > 25)
                    {
                        int indice = Array.IndexOf(Alfabeto_Latino, lettera) + ChiaveNum - 26;
                        lettera = Alfabeto_Latino[indice];
                    }
                    else
                    {
                        lettera = Alfabeto_Latino[Array.IndexOf(Alfabeto_Latino, lettera) + ChiaveNum];
                    }
                }
                
                MessaggioCifrato += lettera;
            }

            Console.WriteLine("La frase codificata è: " + MessaggioCifrato);

            Console.WriteLine("Continuare?");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Fase crittoanalitica");

            string Frequenza = FrequenzaMaggiore(MessaggioCifrato);
            Console.WriteLine("La lettera con maggior frequenza è: " +Frequenza);

            Console.WriteLine("La chiave è:");
            int IndiceChiaveSupposta = Math.Abs(Array.IndexOf(Alfabeto_Latino, Frequenza) - Array.IndexOf(Alfabeto_Latino, FrequenzaAlfabetoIT1));
            Console.WriteLine("Prova 1: " + Alfabeto_Latino[IndiceChiaveSupposta]);

            IndiceChiaveSupposta = Math.Abs(Array.IndexOf(Alfabeto_Latino, Frequenza) - Array.IndexOf(Alfabeto_Latino, FrequenzaAlfabetoIT2));
            Console.WriteLine("Prova 2: " + Alfabeto_Latino[IndiceChiaveSupposta]);

            IndiceChiaveSupposta = Math.Abs(Array.IndexOf(Alfabeto_Latino, Frequenza) - Array.IndexOf(Alfabeto_Latino, FrequenzaAlfabetoIT3));
            Console.WriteLine("Prova 3: " + Alfabeto_Latino[IndiceChiaveSupposta]);
        }

        public static string RimuoviAccenti(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }

        public static string FrequenzaMaggiore (string TestoCifrato)
        {
            string[] Alfabeto_Latino = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            Dictionary<string, int> Frequenze= new Dictionary<string, int>();

            foreach(char c in TestoCifrato)
            {
                string lettera=c.ToString();

                if (Array.IndexOf(Alfabeto_Latino, lettera) != -1)
                {
                    if (Frequenze.ContainsKey(lettera))
                    {
                        Frequenze[lettera] += 1;
                    }
                    else
                    {
                        Frequenze.Add(lettera, 1);
                    }
                }
            }

            string MaxLettera = null;
            int MaxVolte = 0;
            foreach(var Coppia in Frequenze)
            {
                string Chiave = Coppia.Key;
                int Valore = Coppia.Value;

                if (MaxVolte < Valore)
                {
                    MaxVolte = Valore;
                    MaxLettera = Chiave;
                }
            }

            return MaxLettera;
        }
    }
}

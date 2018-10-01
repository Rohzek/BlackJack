using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Blackjack.Classes
{
    public static class Saving
    {
        static String path = "score.sav";
        static Stream stream;
        static BinaryFormatter serializer = new BinaryFormatter();

        // Can load multiple save files
        static List<Betting> readFile()
        {
            stream = new FileStream(path, FileMode.Open);
            List<Betting> readFiles = (List<Betting>)serializer.Deserialize(stream);
            stream.Close();

            return readFiles;
        }

        // Get just the save file we want, as there is no multiples
        public static Betting readSave()
        {
            List<Betting> bet = readFile();
            Betting[] bets = bet.ToArray();

            return bets[0];
        }

        // Writes the save file we provide to file
        public static void writeFile(Betting bet)
        {
            List<Betting> bets = new List<Betting>();
            bets.Add(bet);

            stream = new FileStream(path, FileMode.Create);

            using (stream)
            {
                serializer.Serialize(stream, bets);
            }

            stream.Close();
        }

        // Deletes file
        public static void deleteFile()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        // Checks to see if save exists
        public static bool checkForSave()
        {
            if (File.Exists(path))
            {
                return true;
            }

            return false;
        }
    }
}

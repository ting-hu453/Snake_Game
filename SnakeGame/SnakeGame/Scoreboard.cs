using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;  //Need to add reference to JSON framework and System.Text.JSON in Project>Add Reference>Extensions

namespace SnakeGame
{
    class Scoreboard
    {
        private const int LIST_COUNT = 10;
        static List<Player> highScores = new List<Player>();
        
        string fileName;
        string fullPath;

        /// <summary>
        /// The working parts of the class. This method reads and writes data
        /// to and from a json file. It then calls another methods to sort the
        /// scores from high to low.
        /// </summary>
        public Scoreboard()
        {
            fileName = "HighScores.json";
            fullPath = Path.GetFullPath(fileName);

            try
            {
                // A StreamReader to read our json file to get the data.
                using (StreamReader r = new StreamReader(fullPath))
                {
                    // The actual json data in string format
                    string json = r.ReadToEnd();

                    // Populates a list of type Player taking the string format of json and
                    // converting it to actual usable data.
                    List<Player> items = JsonConvert.DeserializeObject<List<Player>>(json);
                    
                    // This creates new players to keep track of the data from the json file so it does not get overwritten
                    foreach (var item in items)
                    {
                        Player tempPlayer = new Player(item.publicName, item.publicScore);
                        tempPlayer.publicScore = item.publicScore;
                        tempPlayer.publicName = item.publicName;
                        highScores.Add(tempPlayer);
                    }

                    // Calls the sorting method to get the highscores in order
                    sortByScore();
                }
                // Overrides the current json file with the new sorted data.
                File.WriteAllText(@fullPath, JsonConvert.SerializeObject(highScores));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        /// <summary>
        /// This method checks if the most recent score is within the top 10 scores.
        /// </summary>
        /// <param name="score">The current players score</param>
        /// <returns>If it is true, there is a new high score in the top 10.</returns>
        public bool checkIfHighScore(int score)
        {
            bool flag = false;
            for (int i = 0; i < highScores.Count && !flag; i++)
            {
                if (score > highScores[i].publicScore)
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// If there is a new highscore in the top 10, this method
        /// adds it to the list, calls the sort to sort it from
        /// highest to lowest, then deletes the lowest (11th object)
        /// </summary>
        /// <param name="p">An object of class Player.</param>
        public void updateHighScores(Player p)
        {
            
            highScores.Add(p);
            sortByScore();
            highScores.RemoveAt(highScores.Count - 1);

            try
            {
                File.WriteAllText(@fullPath, JsonConvert.SerializeObject(highScores));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        /// <summary>
        /// Sorts the player objects by their scores going highest to lowest.
        /// </summary>
        public static void sortByScore()
        {
            int n = highScores.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (highScores[j].publicScore < highScores[j + 1].publicScore)
                    {
                        Player temp = highScores[j];
                        highScores[j] = highScores[j + 1];
                        highScores[j + 1] = temp;
                    }
                }
            }
        }

        public List<Player> getHighScores()
        {
            return highScores;
        }

    }
}

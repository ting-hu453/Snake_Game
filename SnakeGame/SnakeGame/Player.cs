

namespace SnakeGame
{  
    public class Player
    {
        private string name;
        private int score;

        // Public name/score is needed so we can use them in the JSON file.
        // Having privte variables makes it so JSON.net cannot read/write them.
        public string publicName { get; set; }
        public int publicScore { get; set; }
        

        // Default Player Constructor
        public Player()
        {
            name = publicName;
            score = publicScore;
        }

        // Player Constructor
        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
            publicName = name;
            publicScore = score;
        }

        public int getScore()
        {
            return score;
        }

        public string getName()
        {
            return name;
        }

        public void setScore(int score)
        {
            this.score = score;
            publicScore = score;
        }

        public void setName(string name)
        {
            this.name = name;
            publicName = name;
        }
    }
}

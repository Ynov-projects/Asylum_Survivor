using UnityEngine;

public static class Traductions
{
    public static string getTraduction(string traduction)
    {
        bool fr = PlayerPrefs.GetInt("language") == 1;

        switch (traduction)
        {
#region "settings"
            case "language":
                return fr ? "langage" : "language";
            case "language1":
                return fr ? "francais" : "french";
            case "language2":
                return fr ? "anglais" : "english";
            case "difficulty1":
                return fr ? "facile" : "easy";
            case "difficulty2":
                return fr ? "moyen" : "medium";
            case "difficulty3":
                return fr ? "difficile" : "hardcore";
            case "difficulty4":
                return "impossible";
            case "return":
                return fr ? "retour" : "return";
            case "play":
                return fr ? "jouer" : "play";
            case "quit":
                return fr ? "quitter" : "quit";
            case "options":
                return "options";
#endregion
        }
        return "Tu t'es trompé de traduction";
    }
}

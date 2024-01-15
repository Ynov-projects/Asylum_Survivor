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
            #region "ingame"
            case "flashLightInfo":
                return fr ?
                    "Pressez F pour activer/désactiver la torche" :
                    "Press F to start/stop using your flashlight";
            case "beginningInfo":
                return fr ?
                    "Vous perdez la tête. Ayez toujours une lumière allumée et restez loin des patients fous. Trouvez le code pour sortir par la porte principale. Bonne chance..." :
                    "You are losing your mind. Make sure to always have a light on and stay away from patients, they're also crazy. Find the code to open the main door. Good luck...";
            case "pillsInfo":
                return fr ?
                    "Pressez P pour utliser vos pilules contre la folie" :
                    "Press P to use your pills against dementia";
            case "runInfo":
                return fr ? "Courez au plus vite avec MAJ GAUCHE" : "Run as fast as you can with LEFT SHIFT";
            case "mainDoorInfo":
                return fr ?
                    "Trouvez le code pour partir. Pressez A pour essayer" :
                    "Find the code to escape this place. Press A to test it";
            case "winning":
                return fr ? "victoire" : "you win";
            case "losing":
                return fr ? "defaite" : "you lose";
            #endregion
            #region "buttonsUI"
            case "retrybutton":
                return fr ? "rejouer" : "retry";
            case "quitbutton":
                return fr ? "quitter" : "quit";
            case "mainbutton":
                return fr ? "retour menu" : "main menu";
            case "submitbutton":
                return fr ? "tester" : "submit";
                #endregion
        }
        return "Tu t'es trompé de traduction";
    }
}

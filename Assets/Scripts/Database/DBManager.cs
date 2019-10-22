using System.Collections;
using System.Collections.Generic;

public static class DBManager {

    public static string username;
    public static bool isUserLoggedIn { get { return username != null; } }
   
    public static void LogOut()
    {
        username = null;
    }

}

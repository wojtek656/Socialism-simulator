struct GlobalItems
{
    public static double yourCash = 0;
    public static double totalEarned = 0;
    public static int plnPerClick = 1;
    public static int plnPerSecond = 0;

    public static void AddMoney()
    {
        yourCash += plnPerSecond;
    }

}



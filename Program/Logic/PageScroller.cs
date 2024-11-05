public static class PageScroller
{
    public static int NextPage(ConsoleKey key, int page)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (page > 1) { page--; }
                return page;
            case ConsoleKey.RightArrow:
                page++;
                return page;
            default:
                return page;
        }
    }
}
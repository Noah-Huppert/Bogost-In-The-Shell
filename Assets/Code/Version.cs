public static class Version{
    public static readonly int MAJOR = 0;
    public static readonly int MINOR = 0;
    public static readonly int PATCH = 3;

    public static string Assemble () {
        return string.Format ("{0}.{1}.{2}", MAJOR, MINOR, PATCH);
    } 
}
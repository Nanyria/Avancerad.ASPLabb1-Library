namespace WebLibrary
{
    public static class StaticDetails
    {
        public static string LibraryAPIBase { get; set; }

        public enum APIType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}

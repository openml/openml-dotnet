namespace OpenML.Response.FreeQuery
{
    /// <summary>
    /// Result of free query to the openMl database
    /// </summary>
    public class FreeQueryResult
    {
        /// <summary>
        /// Summary of the query result - number of rows processed etc...
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Executed query
        /// </summary>
        public string Query { get; set; }
        public bool Id { get; set; }
        /// <summary>
        /// Time to finidh the query
        /// </summary>
        public float Time { get; set; }
        /// <summary>
        /// Columns in the returned dataset
        /// </summary>
        public Column[] Columns { get; set; }
        /// <summary>
        /// Data returned by the query
        /// </summary>
        public string[][] Data { get; set; }
    }
}
namespace OpenML.Response.FreeQuery
{
    /// <summary>
    /// Column definition of data returned by the free sql query result
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Column name
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Data type of the column
        /// </summary>
        public string Datatype { get; set; }
    }
}
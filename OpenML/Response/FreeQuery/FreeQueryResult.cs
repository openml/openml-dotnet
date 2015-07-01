namespace OpenML.Response.FreeQuery
{
    public class FreeQueryResult
    {
        public string RawResult { get; private set; }

        public FreeQueryResult(string rawResult)
        {
            RawResult = rawResult;
        }
    }
}

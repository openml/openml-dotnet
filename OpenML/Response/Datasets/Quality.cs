namespace OpenML.Response.Datasets
{
    /// <summary>
    /// OpenMl data quality with value
    /// Describes information about the dataset as a whole, e.g. Number of features, number of instances etc.
    /// </summary>
    public class Quality
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}

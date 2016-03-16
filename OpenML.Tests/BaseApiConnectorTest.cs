namespace OpenML.Tests
{
    public class BaseApiConnectorTest
    {
        public BaseApiConnectorTest()
        {
            Connector = new OpenMlConnector("");
        }

        public OpenMlConnector Connector { get; set; }
    }
}

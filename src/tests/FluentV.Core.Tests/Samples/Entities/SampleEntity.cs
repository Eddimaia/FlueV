namespace FluentV.Core.Tests.Samples.Entities;
public class SampleEntity
{
    public object NoRule = null!;
    public object Required = null!;
    public int MinusOne = -1;
    public string EmptyString = string.Empty;
    public string WhiteSpaceString = " ";
    public SampleEntity NullSampleEntity = null!;

    public string MoreThanOneRule = null!;
}

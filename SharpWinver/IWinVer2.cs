namespace SharpWinver;

public interface IWinVer2 : IWinVer
{
    string BuildBranch { get; }

    string BuildStamp { get; }
}

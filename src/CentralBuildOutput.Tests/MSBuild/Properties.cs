namespace Treasure.Build.CentralBuildOutput.Tests.MSBuild;

using Microsoft.Build.Utilities.ProjectCreation;
using System.Text.Json;

internal class Properties
{
    public CentralBuildOutputProperties CentralBuildOutput { get; }

    public CoverletProperties Coverlet { get; }

    public CommonMSBuildProperties MSBuildCommon { get; }

    public CommonMSBuildMacros MSBuildMacros { get; }

    public MSBuildOtherProperties MSBuildOther { get; }

    public MSBuildReservedWellKnownProperties MSBuildRWK { get; }

    public VSTestProperties VSTest { get; }

    private Properties(
        CentralBuildOutputProperties centralBuildOutput,
        CoverletProperties coverlet,
        CommonMSBuildProperties msBuildCommon,
        CommonMSBuildMacros msBuildMacros,
        MSBuildOtherProperties msBuildOther,
        MSBuildReservedWellKnownProperties msBuildRWK,
        VSTestProperties vsTest)
    {
        this.CentralBuildOutput = centralBuildOutput;
        this.Coverlet = coverlet;
        this.MSBuildCommon = msBuildCommon;
        this.MSBuildMacros = msBuildMacros;
        this.MSBuildOther = msBuildOther;
        this.MSBuildRWK = msBuildRWK;
        this.VSTest = vsTest;
    }

    public static Properties Load(ProjectCreator creator)
        => new Properties(
            CentralBuildOutputProperties.Load(creator),
            CoverletProperties.Load(creator),
            CommonMSBuildProperties.Load(creator),
            CommonMSBuildMacros.Load(creator),
            MSBuildOtherProperties.Load(creator),
            MSBuildReservedWellKnownProperties.Load(creator),
            VSTestProperties.Load(creator));

    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions()
    {
        WriteIndented = true,
    });
}

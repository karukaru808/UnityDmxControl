using CIFER.Tech.Utils;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace Fixture.Editor
{
    [ScriptedImporter(1, "qxf")]
    public class FixtureImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var fixtureDefinition = CiferTechXmlUtils.Deserialize<FixtureDefinition>(ctx.assetPath);

            var fixtureObject = ScriptableObject.CreateInstance<FixtureObject>();
            fixtureObject.Creator = fixtureDefinition.Creator;
            fixtureObject.Manufacturer = fixtureDefinition.Manufacturer;
            fixtureObject.Model = fixtureDefinition.Model;
            fixtureObject.Type = fixtureDefinition.Type;
            fixtureObject.Channel = fixtureDefinition.Channel;
            fixtureObject.Mode = fixtureDefinition.Mode;
            fixtureObject.Physical = fixtureDefinition.Physical;

            ctx.AddObjectToAsset("QXF", fixtureObject);
            ctx.SetMainObject(fixtureObject);
        }
    }
}
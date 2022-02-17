using UnityEngine;

namespace Fixture
{
    public class FixtureObject : ScriptableObject
    {
        public creatorType Creator;
        public string Manufacturer;
        public string Model;
        public typeType Type;
        public channelType[] Channel;
        public modeType[] Mode;
        public physicalType Physical;
    }
}
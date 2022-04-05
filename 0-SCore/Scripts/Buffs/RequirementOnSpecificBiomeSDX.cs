﻿using System.Xml;

// 	<requirement name="RequirementOnSpecificBiomeSDX, SCore" biome="something" />

public class RequirementOnSpecificBiomeSDX : RequirementBase
{
    public string strBiome = "";

    public override bool ParamsValid(MinEventParams _params)
    {
        if (_params.Self.MinEventContext.Biome == null)
            //Debug.Log(" RequirementOnSpecificBiomeSDX: Biome is null ");
            return false;

        if (_params.Self.MinEventContext.Biome.m_sBiomeName == null)
            //Debug.Log(" RequirementONSpecificBiomeSDX: Biome Name is null");
            return false;
        //Debug.Log(" Current Biome: " + _params.Self.MinEventContext.Biome.m_sBiomeName);
        if (_params.Self.MinEventContext.Biome.m_sBiomeName == strBiome)
            return true;

        return false;
    }

    public override bool ParseXmlAttribute(XmlAttribute _attribute)
    {
        var name = _attribute.Name;
        if (name != null)
            if (name == "biome")
            {
                strBiome = _attribute.Value;
                return true;
            }

        return base.ParseXmlAttribute(_attribute);
    }
}
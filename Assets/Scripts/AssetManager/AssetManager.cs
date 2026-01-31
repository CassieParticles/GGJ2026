
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public static class AssetManager
{
    private static Dictionary<Groups, GroupAssetSheet> assetSheets =  new Dictionary<Groups, GroupAssetSheet>();

    public static void AddSheet(GroupAssetSheet sheet)
    {
        //Early exit if sheet isn't set
        if (sheet.Group == Groups.Null)
        {
            return;
        }
        
        //Ensure assetSheets has up-to-date sheet
        if (!assetSheets.TryAdd(sheet.Group,sheet))
        {
            assetSheets[sheet.Group] = sheet;
        }

        ValidateSheets();
    }

    public static void ValidateSheets()
    {
        foreach (Groups group in assetSheets.Keys)
        {
            if (assetSheets[group] == null)
            {
                assetSheets.Remove(group);
                continue;
            }
        }
    }

    public static GroupAssetSheet GetSheet(Groups group)
    {
        if (group == Groups.Null)
        {
            return null;
        }

        GroupAssetSheet sheet;
        if (assetSheets.TryGetValue(group, out sheet))
        {
            //Check if entry is still valid
            if (sheet == null)
            {
                assetSheets.Remove(group);
                return null;
            }
            return sheet;
        }
        
        return null;
    }
}

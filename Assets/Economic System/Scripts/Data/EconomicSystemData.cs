using UnityEngine;
using System.Collections.Generic;

public class EconomicSystemData
{
    // constructor

    public EconomicSystemData()
    {
        _placesDicById = new Dictionary<int, TargetPlaceData>();
        _groupsDicById = new Dictionary<int, EcoPlayerGroupData>();
    }

    // data

    Dictionary<int, TargetPlaceData> _placesDicById;

    Dictionary<int, EcoPlayerGroupData> _groupsDicById;

    public Dictionary<int, TargetPlaceData> placesDicById { get { return _placesDicById; } }

    public Dictionary<int, EcoPlayerGroupData> groupsDicById { get { return _groupsDicById; } }

    public const int PlaceIdBase = 1000;
    public const int GroupIdBase = 10000;
    public const int GroupIdPlus = 10000;
    int placeIdCounter = 0;
    int groupIdCounter = 0;
    
    // functions

    public int AddPlaceData(TargetPlaceType type)
    {
        int id = PlaceIdBase + placeIdCounter;

        if (type == TargetPlaceType.City)
        {
            CityData city = new CityData(id, type);
            _placesDicById[id] = city;
        }

        placeIdCounter++;
        return id;
    }

    /// <summary>
    /// id: place id
    /// </summary>
    public void DeletePlaceData(int id)
    {
        if (_placesDicById.ContainsKey(id))
        {
            _placesDicById.Remove(id);
        }
    }

    public int AddGroupData(EcoPlayerData proto, int cnt)
    {
        int groupId = GroupIdBase + groupIdCounter * GroupIdPlus;
        int startId = groupId + 1;
        EcoPlayerGroupData group = new EcoPlayerGroupData(groupId, proto, cnt, startId);
        _groupsDicById[groupId] = group;
        groupIdCounter++;
        return groupId;
    }

    /// <summary>
    /// id: group id
    /// </summary>
    public void DeleteGroupData(int id)
    {
        if (_groupsDicById.ContainsKey(id))
        {
            _groupsDicById[id].Free();
            _groupsDicById.Remove(id);
        }
    }
}


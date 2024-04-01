using System;
using System.Collections.Generic;
using System.Linq;
using Memoria;
using Memoria.Prime;
public static class NarrowMapList
{
    public static Boolean IsCurrentMapNarrow(Int32 ScreenWidth) => IsNarrowMap(FF9StateSystem.Common.FF9.fldMapNo, PersistenSingleton<EventEngine>.Instance?.fieldmap?.camIdx ?? -1, ScreenWidth);
    public static Boolean IsNarrowMap(Int32 mapId, Int32 camId, Int32 ScreenWidth)
    {
        if (SpecificScenesNarrow(mapId))
            return true;

        if (MapWidth(mapId) <= ScreenWidth)
            return true;

        return false;
    }
    public static Boolean SpecificScenesNarrow(Int32 mapId)
    {
        Int32 currIndex = PersistenSingleton<EventEngine>.Instance.eBin.getVarManually(EBin.MAP_INDEX_SVR);
        foreach (KeyValuePair<int, int> entry in SpecificScenesNarrow_List)
        {
            if (mapId == entry.Key && currIndex == entry.Value)
                return true;
            // hall alexandria: meeting garnet, zorn thorn, steiner calling
            if (mapId == 153 && (currIndex == 325 || currIndex == 328 || currIndex == 316)) 
                return true;
        }
        return false;
    }

    public static Int32 MapWidth(int mapId)
    {
        if (SpecificScenesNarrow(mapId))
            return 320;

        Int32 width = 900;

        foreach (KeyValuePair<int, int> entry in WidthDictionary)
        {
            if (mapId == entry.Key && !SpecificScenesNarrow(entry.Key))
                width = (Int32)entry.Value;
        }

        if (PersistenSingleton<EventEngine>.Instance?.fieldmap?.camIdx == 1)
        { 
            foreach (KeyValuePair<int, int> entry in WidthDictionary_cam2)
            {
                if (mapId == entry.Key && !SpecificScenesNarrow(entry.Key))
                    width = (Int32)entry.Value;
            }
        }

        return width;
    }
    public static Int32 SmallestMapWidth(int mapId)
    {
        Int32 width = MapWidth(mapId);
        foreach (KeyValuePair<int, int> entry in WidthDictionary)
        {
            if (mapId == entry.Key)
                width = Math.Min((Int32)entry.Value, width);
        }
        foreach (KeyValuePair<int, int> entry in WidthDictionary_cam2)
        {
            if (mapId == entry.Key)
                width = Math.Min((Int32)entry.Value, width);
        }
        //Log.Message("smallest width:" + width);
        return width;
    }

    public static readonly Dictionary<int, int> SpecificScenesNarrow_List = new Dictionary<int, int>
    {
        // {mapNo,index}
        {50,0},     // first scene
        {150,325},  // Zidane infiltrate Alex Castle
        {154,304},  // cutscene zorn&thorn
        //{153,328},  // steiner guards call // can't have twice the same key TOFIX
        {352,3},    // Arrival at Dali: vivi visible before sleeping
        {355,18},   // Steiner to the barmaid
        {600,32},   // Throne, meet cid
        {606,0},   // telescope
        {615,57},   // Meet garnet on Lindblum castle
        {1602,16},  // scene at Madain Sari night w/ Vivi/Zidane/Eiko eavesdropping, bugged if you see too much
        {1823,331}, // Garnet coronation, garnet visible
        {1815,0},   // Love quiproquo at the docks
        {1816,315}, // Love quiproquo at the docks
        {2211,8},   // Lindblum meeting after Alexander scene: ATE with kuja at his ship, Zorn & Thorn visible too soon and blending
        {2705,-1},  // Pandemonium, you're not alone sequence, several glitches
        {2706,-1},  // Pandemonium, you're not alone sequence, several glitches
        {2707,-1},  // Pandemonium, you're not alone sequence, several glitches
        {2708,-1}   // Pandemonium, you're not alone sequence, several glitches
    };

    public static readonly Dictionary<int, int> WidthDictionary_cam2 = new Dictionary<int, int>
    {
        
        //{map,width},
        {51,640},
        {52,320},
        //{63,800},
        //{65,320},
        //{66,320},
        //{116,320}, //I GIVE UP
        {153,432},
        {154,640},
        //{355,320},
        //{600,320},
        //{615,320},
        {801,336},
        {951,336},
        {953,336},
        {1205,384},
        {1206,320},
        {1208,640},
        {1214,432},
        {1215,640},
        {1461,368},
        {1462,512},
        {1608,336},
        {1652,336},
        {1663,416},
        {1707,336},
        {1759,336},
        {1801,320},
        {1806,432},
        {1807,640},
        {1823,320},
        {2000,352},
        {2150,320},
        {2157,320},
        {2172,320},
        {2209,336},
        {2217,320},
        {2363,336},
        //{2510,448},//464},
        {2552,480},
        {2553,480},
        {2554,608},
        {2755,336},
        {2756,336},
    };

    public static readonly Dictionary<int, int> WidthDictionary = new Dictionary<int, int>
    {
        //{map,width},
        {50,480},
        {51,480},
        {52,320},
        {53,320},
        {54,432},
        {55,400},
        {56,320},
        {57,448},
        {58,320},
        {59,320},
        {60,368},
        {61,320},
        {62,320},
        {63,320},
        {64,480},
        {65,320},
        {66,320},
        {67,368},
        {68,320},
        {69,320},
        {100,320},
        {101,640},
        {102,384},
        {103,624},
        {104,320},
        {105,320},
        {106,528},
        {107,480},
        {108,320},
        {109,384},
        {110,432},
        {111,448},
        {112,560},
        {113,480},
        {114,352},
        {115,432},
        {116,320},//416}, // I GIVE UP
        {117,416},
        {150,368},
        {151,320},
        {152,800},
        {153,320},
        {154,352},
        {155,416},
        {156,640},
        {157,400},
        {158,480},
        {159,416},
        {160,320},
        {161,368},
        {162,384},
        {163,320},
        {164,320},
        {165,320},
        {166,320},
        {167,320},
        {200,480},
        {201,368},
        {202,480},
        {203,336},
        {204,480},
        {205,320},
        {206,384},
        {207,384},
        {208,480},
        {209,320},
        {250,480},
        {251,384},
        {252,384},
        {253,480},
        {254,400},
        {255,320},
        {256,320},
        {257,416},
        {258,480},
        {259,320},
        {261,320},
        {262,368},
        {300,320},
        {301,320},
        {302,480},
        {303,592},
        {304,432},
        {305,320},
        {306,320},
        {307,464},
        {308,320},
        {309,320},
        {310,320},
        {311,320},
        {312,480},
        {350,448},
        {351,480},
        {352,480},
        {353,416},
        {354,320},
        {355,416},
        {356,416},
        {357,320},
        {358,320},
        {359,320},
        {400,320},
        {401,410}, //640}, // people appearing
        {402,480},
        {403,640},
        {404,432},
        {405,400},
        {406,480},
        {407,384},
        {408,448},
        {450,432},
        {451,320}, //480},
        {452,320},
        {453,320},
        {454,320},
        {455,320},
        {456,320}, //410},//640}, scrolling too far. // temp out
        {457,320},
        {500,320},
        {501,320}, //512},
        {502,336},
        {503,336},
        {504,430}, //432}, -2
        {505,320}, //640},
        {506,352},
        {507,320}, //512},
        {550,352},
        {551,320},
        {552,448},
        {553,384},
        {554,480},
        {555,480},
        {556,384},
        {557,480},
        {558,416},
        {559,512},
        {560,320},
        {561,400},
        {562,416},
        {563,432},
        {564,432},
        {565,368},
        {566,400},
        {567,320},
        {568,400},
        {569,400},
        {570,320},
        {571,400},
        {572,416},
        {573,432},
        {574,320},
        {575,416},
        {576,320},
        {600,448},
        {601,320},
        {602,480},
        {603,544},
        {604,448},
        {605,432},
        {606,320},
        {607,320},
        {608,448},
        {609,320},
        {610,448},
        {611,576},
        {612,544},
        {613,400},
        {614,544},
        {615,512},
        {616,480},
        {617,544},
        {618,464},
        {619,432},
        {620,352},
        {650,512},
        {651,640},
        {652,480},
        {653,640},
        {654,640},
        {655,512},
        {656,400},
        {657,400},
        {658,400},
        {659,400},
        {660,640},
        {661,432},
        {662,448},
        {663,400},
        {701,320},
        {702,624},
        {703,576},
        {704,576},
        {705,384},
        {706,448},
        {707,480},
        {750,320},
        {751,384},
        {752,480},
        {753,400},
        {754,320},
        {755,400},
        {756,416},
        {757,480},
        {758,320},
        {759,418},
        {760,336},
        {761,544},
        {762,544},
        {763,416},
        {764,320},
        {765,320},
        {766,320},
        {767,544},
        {768,448},
        {800,320},
        {801,560},
        {802,352},
        {803,352},
        {804,432},
        {805,320}, //480}, //608}, PARALLAX
        {806,400},
        {807,432},
        {808,320}, //480}, //608}, PARALLAX
        {809,512},
        {810,576},
        {811,512},
        {812,512},
        {813,384},
        {814,336},
        {815,416},
        {816,336},
        {850,512},
        {851,400},
        {852,480},
        {853,512},
        {854,512},
        {855,400},
        {856,480},
        {900,448},
        {901,400},
        {902,752},
        {903,768},
        {904,576},
        {905,640},
        {906,512},
        {907,416},
        {908,320}, //432}, //PARALLAX
        {909,592},
        {910,448},
        {911,368},
        {912,640},
        {913,400},
        {914,576},
        {915,416},
        {916,464},
        {930,320},
        {931,800},
        {932,320},//416},
        {950,384},
        {951,512},
        {952,512},
        {953,448},
        {954,720},
        {956,448},
        {1000,322},
        {1001,320},
        {1002,320},
        {1003,320},
        {1004,512},
        {1005,512},
        {1006,320},
        {1007,320},
        {1008,416},
        {1009,320},
        {1010,640},
        {1011,528},
        {1012,464},
        {1013,320},
        {1014,640},
        {1015,528},
        {1016,528},
        {1017,384},
        {1018,384},
        {1050,320},
        {1051,416},
        {1052,592},
        {1053,608},
        {1054,400},
        {1055,480},
        {1056,464},
        {1057,560},
        {1058,384},
        {1059,528},
        {1060,640},
        {1100,320},
        {1101,416},
        {1103,608},
        {1104,400},
        {1105,480},
        {1107,560},
        {1108,384},
        {1109,528},
        {1110,640},
        {1150,368},
        {1151,336},
        {1152,448},
        {1153,320}, //800},
        {1200,320},
        {1201,384},
        {1202,432},
        {1203,432},
        {1204,480},
        {1205,416},
        {1206,416},
        {1207,480},
        {1208,320},
        {1209,640},
        {1210,384},
        {1211,448},
        {1212,352},
        {1213,368},
        {1214,320},
        {1215,352},
        {1216,416},
        {1217,640},
        {1218,400},
        {1219,480},
        {1220,416},
        {1221,320},
        {1222,368},
        {1224,528},
        {1226,320},
        {1227,480},
        {1250,320},
        {1251,368},
        {1252,320},
        {1253,320},
        {1254,368},
        {1255,432},
        {1256,432},
        {1300,352},
        {1302,448},
        {1305,480},
        {1306,416},
        {1307,512},
        {1309,416},
        {1313,400},
        {1314,320},
        {1315,480},
        {1357,320},
        {1364,544},
        {1400,640},
        {1401,320},
        {1402,640},
        {1403,368},
        {1404,384},
        {1405,528},
        {1406,320},
        {1407,512},
        {1408,400},
        {1409,512},
        {1410,320},
        {1411,496},
        {1412,640},
        {1413,512},
        {1414,400},
        {1415,512},
        {1416,640},
        {1417,528},
        {1418,512},
        {1419,608},
        {1420,448},
        {1421,512},
        {1422,528},
        {1423,800},
        {1424,400},
        {1425,480},
        {1450,480},
        {1451,432},
        {1452,384},
        {1453,384},
        {1454,512},
        {1455,320},
        {1456,400},
        {1457,320},
        {1458,336},
        {1459,320},
        {1460,512},
        {1461,448},
        {1462,320},
        {1463,320},
        {1464,432},
        {1500,336},
        {1501,528},
        {1502,416},
        {1503,416},
        {1504,512},
        {1505,512},
        {1506,336},
        {1507,320},
        {1508,352},
        {1509,384},
        {1550,576},
        {1551,416},
        {1552,416},
        {1553,624},
        {1554,464},
        {1555,640},
        {1556,320},
        {1557,320},
        {1600,400},
        {1601,400},
        {1602,400},
        {1603,512},
        {1604,960},
        {1605,336},
        {1606,336},
        {1607,320},
        {1608,352},
        {1609,320},
        {1610,320},
        {1650,352},
        {1651,448},
        {1652,480},
        {1653,512},
        {1654,512},
        {1655,320},
        {1656,384},
        {1657,352},
        {1658,368},
        {1659,480},
        {1660,336},
        {1661,336},
        {1662,336},
        {1663,320},
        {1700,400},
        {1701,400},
        {1702,400},
        {1703,512},
        {1704,960},
        {1705,336},
        {1706,320},
        {1707,352},
        {1750,320},
        {1751,336},
        {1752,352},
        {1753,320},
        {1754,640},
        {1755,320},
        {1756,320},
        {1757,352},
        {1758,448},
        {1759,480},
        {1800,320},
        {1801,416},
        {1803,368},
        {1806,320},
        {1807,352},
        {1808,416},
        {1809,640},
        {1810,400},
        {1816,416},
        {1817,368},
        {1818,320},
        {1819,416},
        {1821,528},
        {1822,320},
        {1823,432},
        {1824,480},
        {1850,320},
        {1851,640},
        {1852,384},
        {1853,624},
        {1854,320},
        {1855,528},
        {1856,480},
        {1865,432},
        {1866,320},
        {1900,448},
        {1901,400},
        {1902,752},
        {1903,768},
        {1904,576},
        {1905,640},
        {1906,512},
        {1907,416},
        {1908,320}, //432}, //PARALLAX
        {1909,592},
        {1910,448},
        {1911,368},
        {1912,640},
        {1913,400},
        {1914,576},
        {1915,416},
        {1950,496},
        {1951,352},
        {1952,352},
        {1953,384},
        {2000,352},
        {2001,480},
        {2002,368},
        {2003,448},
        {2004,368},
        {2005,320},
        {2006,368},
        {2007,432},
        {2008,320},
        {2009,320},
        {2050,320},
        {2051,640},
        {2052,384},
        {2053,624},
        {2054,480},
        {2055,352},
        {2101,320},
        {2102,448},
        {2103,384},
        {2104,480},
        {2105,480},
        {2106,416},
        {2107,512},
        {2108,320},
        {2109,416},
        {2110,432},
        {2111,432},
        {2112,368},
        {2113,400},
        {2114,320},
        {2150,448},
        {2151,320},
        {2152,480},
        {2153,544},
        {2155,432},
        {2157,320},
        {2158,448},
        {2159,320},
        {2160,448},
        {2161,576},
        {2162,544},
        {2163,400},
        {2165,544},
        {2167,480},
        {2168,544},
        {2169,464},
        {2170,432},
        {2172,512},
        {2173,448},
        {2200,384},
        {2201,560},
        {2202,336},
        {2203,352},
        {2204,336},
        {2205,336},
        {2206,560},
        {2207,512},
        {2208,336},
        {2209,560},
        {2211,928},
        {2212,400},
        {2213,400},
        {2214,512},
        {2215,480},
        {2216,480},
        {2217,432},
        {2220,544},
        {2221,512},
        {2222,384},
        {2250,320},
        {2251,480},
        {2252,480},
        {2253,592},
        {2254,336},
        {2255,320},
        {2256,672},
        {2257,336},
        {2258,592},
        {2259,528},
        {2260,320},
        {2261,352},
        {2300,512},
        {2301,512},
        {2303,336},
        {2304,512},
        {2305,320},
        {2350,656},
        {2351,320},
        {2352,400},
        {2353,400},
        {2354,368},
        {2355,384},
        {2356,352},
        {2357,464},
        {2358,544},
        {2359,416},
        {2360,448},
        {2361,320},
        {2362,352},
        {2363,384},
        {2364,512},
        {2365,336},
        {2403,416},
        {2404,416},
        {2405,320},
        {2406,384},
        {2450,320},
        {2451,384},
        {2452,640},
        {2453,320},
        {2454,528},
        {2455,448},
        {2456,432},
        {2458,320},
        {2500,352},
        {2501,352},
        {2502,368},
        {2503,368},
        {2504,512},
        {2505,448},
        {2506,512},
        {2507,592},
        {2508,432},
        {2509,512},
        {2510,320},
        {2512,320},
        {2513,336},
        {2550,496},
        {2551,400},
        {2552,352},
        {2553,416},
        {2554,464},
        {2600,416}, //464},
        {2601,400},
        {2602,384},
        {2603,560},
        {2604,416}, //512},
        {2605,368}, //608},
        {2606,398}, //512},
        {2607,398}, //432},
        {2608,320},
        {2650,368},
        {2651,320}, //528},
        {2652,448},
        {2653,512},
        {2654,352},
        {2655,416},
        {2656,480},
        {2657,384},
        {2658,400},
        {2659,464},
        {2660,472}, //528},
        {2661,480},
        {2700,448},
        {2701,320},
        {2702,624},
        {2703,464},
        {2704,432},
        {2705,320},
        {2706,400},
        {2707,640},
        {2708,448},
        {2709,480},
        {2710,576},
        {2711,624},
        {2712,512},
        {2713,592},
        {2714,608},
        {2715,320},
        {2716,384}, //416},
        {2717,528},
        {2718,592},
        {2719,320},
        {2750,432},
        {2751,432},
        {2752,320},
        {2753,448},
        {2754,480},
        {2755,496},
        {2756,960},
        {2800,512},
        {2801,480},
        {2802,480},
        {2803,496},
        {2850,496},
        {2851,384},
        {2852,464},
        {2853,512},
        {2854,496},
        {2856,384},
        {2900,320},
        {2901,320},
        {2902,320},
        {2903,544},
        {2904,368},
        {2905,448},
        {2906,400},
        {2907,544},
        {2908,320},
        {2909,320},
        {2910,320},
        {2911,480},
        {2912,320},
        {2913,368},
        {2914,320},
        {2915,384},
        {2916,437},
        {2917,320},
        {2918,320},
        {2919,320},
        {2920,336},
        {2921,336},
        {2922,384},
        {2923,688},
        {2924,320},
        {2925,320},
        {2926,320},
        {2927,320},
        {2928,368},
        {2929,320},
        {2930,320},
        {2932,960},
        {2933,320},
        {2934,320},
        {2950,320},
        {2951,480},
        {2952,512},
        {2953,336},
        {2954,480},
        {2955,576},
        {3011,320},
        {3050,480},
        {3100,368},
    };
}

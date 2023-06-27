using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskiInsurance;

/// <summary>
/// A struct that is used as an intermediary between receiving json content and parsing to a clientRecord
/// </summary>
public struct ClientRecordJsonRecieve
{
    public string ID
    {
        get;
        set;
    }
    public int TimeStampUnix
    {
        get;
        set;
    }

    public string RiderName
    {
        get;
        set;
    }
    public byte RiderAge
    {
        get;
        set;
    }
    public byte RiderExperience
    {
        get;
        set;
    }
    public byte SkiPower
    {
        get;
        set;
    }
    public byte SkiSeats
    {
        get;
        set;
    }
    public int SkiPrice
    {
        get;
        set;
    }
    public byte SkiAge
    {
        get;
        set;
    }
    public short Excess
    {
        get;
        set;
    }

    public int Total
    {
        get;
        set;
    }

    /// <summary>
    /// Returns a ClientRecord representing the object
    /// </summary>
    /// <returns></returns>
    public ClientRecord ToClientRecord()
    {
        ClientRecord toReturn = new ClientRecord();

        toReturn.ID = ID;
        toReturn.TimeStampUnix = TimeStampUnix;
        toReturn.RiderName = RiderName;
        toReturn.RiderAge = RiderAge;
        toReturn.RiderExperience = RiderExperience;
        toReturn.SkiPower = SkiPower;
        toReturn.SkiSeats = SkiSeats;
        toReturn.SkiPrice = SkiPrice;
        toReturn.SkiAge = SkiAge;
        toReturn.Excess = Excess;
        toReturn.Total = Total;

        return toReturn;
    }
}
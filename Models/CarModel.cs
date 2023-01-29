using DevTrustTest.Enums;
using System;

namespace DevTrustTest.Models;

public class CarModel
{
    /// <summary>
    ///     Path to car id
    /// </summary>
    public long CarId { get; set; }
    /// <summary>
    ///     Path to mark of car
    /// </summary>
    public string Mark { get; set; }
    /// <summary>
    ///     Path to car number
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    ///     Path to type of car
    /// </summary>
    public CarType CarType { get; set; }
    /// <summary>
    ///     Path to date of create car
    /// </summary>
    public DateOnly CreateDate { get; set; }

    public override string ToString()
    {
        return $"{CarId} {Mark} {Number} {CarType} {CreateDate}";
    }
}

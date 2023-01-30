using DevExpress.Xpf.Core;
using DevTrustTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevTrustTest.Interfaces;

public interface ICarDataService
{
    public List<CarModel> GetCarData();
}

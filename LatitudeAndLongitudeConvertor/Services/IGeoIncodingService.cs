using LatitudeAndLongitudeConvertor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatitudeAndLongitudeConvertor.Services
{
    public interface IGeocodingService
    {
        Task<List<LocationResult>> GetCoordinatesAsync(string locationName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LogInEx1.Models;

namespace LogInEx1.Service
{
    public class LocationService : ILocationService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<LocationViewModel> GetAll()
        {
            var locationList = db.Locations.ToList();
            return locationList.Select(loc => LocDto(loc)).ToList();
        }

        private static LocationViewModel LocDto(Location loc)
        {
            return new LocationViewModel
            {
                LocationId = loc.LocationId,
                LocationName = loc.LocationName,
                Address = loc.Address,
                City = loc.City,
                State = loc.State,
                ZipCode = loc.ZipCode,
                Email = loc.Email,
                Phone = loc.Phone
            };
        }

        public LocationViewModel FindById(int id)
        {
            var location = db.Locations.Find(id);
            return location != null ? LocDto(location) : null;
        }

        public LocationViewModel Create(LocationViewModel location)
        {
            var loc = fromLoc(location);
            db.Locations.Add(loc);
            db.SaveChanges();

            location.LocationId = loc.LocationId;
            return LocDto(loc);
        }

        private static Location fromLoc(LocationViewModel location)
        {
            var loc = new Location
            {
                LocationId   = location.LocationId,
                LocationName = location.LocationName,
                Address      = location.Address,
                City         = location.City,
                State        = location.State,
                ZipCode      = location.ZipCode,
                Email        = location.Email,
                Phone        = location.Phone
            };
            return loc;
        }

        public LocationViewModel Save(LocationViewModel location)
        {
            var loc = fromLoc(location);
            db.Entry(loc).State = EntityState.Modified;
            db.SaveChanges();
            return LocDto(loc);
        }

        public void Delete(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LogInEx1.Models;

namespace LogInEx1.Service
{
    public class PositionService : IPositionService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<PositionViewModel> GetAll()
        {
            var positionList = db.Positions.ToList();
            return positionList.Select(pos => PosDto(pos)).ToList();
        }

        private static PositionViewModel PosDto(Position pos)
        {
            return new PositionViewModel
            {
                PositionId    = pos.PositionId,
                PositionTitle = pos.PositionTitle
            };
        }

        public PositionViewModel FindById(int id)
        {
            var position = db.Positions.Find(id);
            return position != null ? PosDto(position) : null;
        }

        public PositionViewModel Create(PositionViewModel position)
        {
            var pos = fromPos(position);
            db.Positions.Add(pos);
            db.SaveChanges();

            position.PositionId = pos.PositionId;
            return PosDto(pos);
        }

        private static Position fromPos(PositionViewModel position)
        {
            var pos = new Position
            {
                PositionId    = position.PositionId,
                PositionTitle = position.PositionTitle
            };
            return pos;
        }

        public PositionViewModel Save(PositionViewModel position)
        {
            var pos = fromPos(position);
            db.Entry(pos).State = EntityState.Modified;
            db.SaveChanges();

            return PosDto(pos);
        }

        public void Delete(int id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}